namespace SubConvGUI {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labela = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labela
            // 
            this.labela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labela.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labela.LinkArea = new System.Windows.Forms.LinkArea(26, 6);
            this.labela.Location = new System.Drawing.Point(0, 0);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(378, 194);
            this.labela.TabIndex = 0;
            this.labela.TabStop = true;
            this.labela.Text = "Prevucite .srt fajlove\r\nby Stamen (Jul 2022)";
            this.labela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labela.UseCompatibleTextRendering = true;
            this.labela.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labela_LinkClicked);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 194);
            this.Controls.Add(this.labela);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MainForm";
            this.Text = "Titl MÆjstor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private LinkLabel labela;
    }
}