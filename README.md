# Titl MÆjstor

<!-- bedzevi -->
![Version](https://img.shields.io/badge/verzija-1.0.0-blue)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?logo=.net&logoColor=white)

<img
    src="preview.png"
    width="200"
    align="right"
/>

Mala aplikacija koja služi da pretvori
titlove u UTF-8-BOM i prepravi simbole
kao što su Æ u Ć.

Prevucite .srt fajl ili fajlove kako bi
ih konvertovali. Veličina prozora je
promenljiva.

## :warning: **Originalni (prevučeni) fajl ili fajlovi će biti izmenjeni** :warning:

### Konverzije podržanih karaktera
| Pre | Posle |
|-----|-------|
|  æ  |   ć   |
|  Æ  |   Ć   |
|  è  |   č   |
|  È  |   Č   |
|  ð  |   đ   |
|  Ð  |   Đ   |

### Tehnikalije
- C# Forms Aplikacija
- [.Net 6 Framework](https://dotnet.microsoft.com/en-us/download)
- Nuget Paketi
  - [UTF.Unknown](https://www.nuget.org/packages/UTF.Unknown/)
  - [System.Text.Encoding.CodePages](https://www.nuget.org/packages/System.Text.Encoding.CodePages)
