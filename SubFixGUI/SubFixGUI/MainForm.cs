using System.Text;
using UtfUnknown;
using System.Diagnostics;

namespace SubConvGUI {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void labela_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("explorer.exe", @"https://github.com/xTeamStanly");
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e) {

            if(e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop) == true) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }

        }

        private class PathMessage {
            public string Path { get; set; }
            public string Message { get; set; }

            public PathMessage(string path, string message) { 
                Path = path;
                Message = message;
            }

            public PathMessage() { Path = ""; Message = ""; }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e) {

            if(e.Data == null) {
                MessageBox.Show("Desila se greška prilikom učitavanja podataka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(filePaths.Length == 0) {
                MessageBox.Show("Desila se greška prilikom učitavanja podataka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // lista neuspesnih
            List<PathMessage> failedPaths = new List<PathMessage>();
            int successCounter = 0;

            bool fileExists = false;
            DetectionResult detectionResult = null;
            DetectionDetail detectionDetail = null;
            Encoding encoding = null;


            foreach (string filePath in filePaths) {

                // da li fajl postoji, ako je folder dodaje se u listu neuspesnih
                fileExists = File.Exists(filePath);
                if(fileExists == false) {
                    failedPaths.Add(new PathMessage {
                        Path = filePath, Message = "Nije fajl!"
                    });
                    continue;
                }

                try {
                    // proveri ekstenziju fajla
                    string fileExtension = Path.GetExtension(filePath).ToLower();
                    if(fileExtension != ".srt") {
                        failedPaths.Add(new PathMessage {
                            Path = filePath, Message = "Ekstenzija fajla nije .srt!"
                        });
                        continue;
                    }

                    detectionResult = CharsetDetector.DetectFromFile(filePath);
                    if(detectionResult == null) {
                        failedPaths.Add(new PathMessage {
                            Path = filePath, Message = "Detekcija neuspešna!"
                        });
                        continue;
                    }

                    detectionDetail = detectionResult.Detected;
                    if(detectionDetail == null) {
                        failedPaths.Add(new PathMessage {
                            Path = filePath, Message = "Fajl nije tekstualan ili je prazan!"
                        });
                        continue;
                    }

                    encoding = detectionDetail.Encoding;
                    if(encoding == null) {
                        failedPaths.Add(new PathMessage {
                            Path = filePath, Message = "Encoding fajla nije detektovan!"
                        });
                        continue;
                    }

                    string fileContent = File.ReadAllText(filePath, encoding);

                    // konvertuj trenutni encoding u utf8bom
                    byte[] currentEncodingBytes = encoding.GetBytes(fileContent);
                    byte[] utf8bytes = Encoding.Convert(encoding, Encoding.UTF8, currentEncodingBytes);
                    fileContent = Encoding.UTF8.GetString(utf8bytes);

                    fileContent = fileContent
                        .Replace("æ", "ć")
                        .Replace("Æ", "Ć")
                        .Replace("È", "Č")
                        .Replace("è", "č")
                        .Replace("ð", "đ")
                        .Replace("Ð", "Đ");

                    // prepisujemo preko postojeceg fajla
                    StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
                    streamWriter.WriteLine(fileContent);
                    streamWriter.Close();

                    successCounter++;

                } catch(Exception ex) {
                    failedPaths.Add(new PathMessage {
                        Path = filePath, Message = "Greška"
                    });
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string finalString = $"Konvertovan/o je {successCounter} fajl/a!";

            if(failedPaths.Count > 0) { finalString += "\n\nGreška/e:\n"; }
            foreach (PathMessage filePath in failedPaths) {
                finalString += $"{filePath.Path} ({filePath.Message})\n";
            }

            MessageBox.Show(finalString, "Rezultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}