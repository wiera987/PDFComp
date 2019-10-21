# PDFComp
Compare two PDF files and highlight different characters.

<img src="https://user-images.githubusercontent.com/50268838/57225045-2575a780-7046-11e9-9f16-0b3a44c5f5ee.png" width="480">

## Background

There are tools that automatically compare the differences between two PDF files, but you can't detect the difference well unless they are almost the same text.
When comparing PDF files with a revised paragraph structure, the pages you want are not compared and you need to specify the pages again.
This PDFComp is an application that specializes in manual operation and allows you to quickly move pages and check one page at a time.

As it is an experimental project so far, it has only the minimum required functionality.

### Application requirements

* Microsoft Windows 7 sp1 with .NET Framework 4.5.2

## Usage
### Installation

Download the zip file from [release](https://github.com/wiera987/PDFComp/releases) and execute PDFComp.exe contained in it.

### Operation

* The 'Open' button open two pdf files.　(or drop the file)
* The '<Prev' and '>Next' buttons navigate two pdf pages at the same time. (arrow left and right keys)
* The '<' and '>' buttons move between the pages of the respective PDF file. (Ctrl+arrow keys, Alt+arrow keys)
* The 'Compare page' button is to compare and hilight displaied pages. (space key)
* The 'Clear markers' context menu is to clear the different markers.
* The 'Copy text' context menu copies text.
* 'Copy' menus copies PDF images and Bookmark text.
* The 'Find...' menu show the text search window.

## Development

This program was developed in C # and was built in the following environment:

* Microsoft Windows 7 sp1 with .NET Framework 4.5.2
* Microsoft Visual Studio Community 2019

### Libraries

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer/) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [NetDiff](https://github.com/skanmera/NetDiff/) - This is the C # implementation of the Diff algorithm.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.

and The [PdfiumViewer] linked in this program uses a forked custom version(https://github.com/wiera987/PdfiumViewer) of [PdfiumViewer].

### Building PDFComp
Clone the source code and open the Visual Studio solution file.
Install the following three packages from Manage NuGet Packages menu:

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx (for your environment)
* Diff4Net

Also, build a custom version of [PdfiumViewer] and replace [PdfiumViewer].

Finally, build the PDFComp project.

## License

This project is licensed under the Apache License, Version2.0.
