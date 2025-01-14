# PDFComp
Compare two PDF files and highlight different characters.

![PDFComp_3 0_MainForm](https://github.com/user-attachments/assets/a10aae2a-4c8a-45b9-b398-9ff2a608c8f6)

## Background

There are tools that automatically compare the differences between two PDF files, but you can't detect the difference well unless they are almost the same text.
When comparing PDF files with a revised paragraph structure, the pages you want are not compared and you need to specify the pages again.
This PDFComp is an application that specializes in manual operation and allows you to quickly move pages and check one page at a time.
The latest version also adds an automatic comparison mode that uses bookmarks.

PDFComp 3.0.0
'Compare bookmark' and 'Compare book' are now supported.

### Application requirements

* Microsoft Windows 11(22H2) with .NET Framework 4.8

## Usage
### Installation

Download the zip file from [release](https://github.com/wiera987/PDFComp/releases) and execute PDFComp.exe contained in it.

### Operation

* The 'Open' button open two pdf files. (or drop the file)
* The '<<' and '>>' buttons navigate two pdf pages at the same time. (arrow left and right keys)
* The '<' and '>' buttons move between the pages of the respective PDF file. (Ctrl+arrow keys, Alt+arrow keys)
* The '<-' and '->' buttons navigate to the page with the differences while comparing the two PDF files.
* The 'Compare page' button is to compare and highlight displaied pages. (space key)
* The 'Compare bookmark' button is to compare and highlight the differences on the selected bookmark pages.
* The 'Compare book' button is to compare and highlight the differences across the whole PDF file.
* The 'Clear markers' context menu is to clear the different markers.
* The 'Copy text' context menu copies text.
* The 'Copy' menus copies PDF images and Bookmark text. If the 'Enable color reduction copy' menu is checked, the colors will be reduced to 256 when copying an image.
* The 'Find...' menu show the text search window. You can search for each PDF.

Use 'Compare page' to manually compare one page at a time.
To compare across pages, use 'Compare bookmark' or 'Compare book'.
'Compare bookmark' requires bookmarks in the PDF file and will compare pages with reference to the chapter structure of the currently selected bookmark item. For pages without bookmarks, the comparison will be on a page-by-page basis.
'Compare book' will compare the whole file at once, without considering the chapter structure.

If you hit the space key repeatedly, the part with the difference will flash.
Pan mode can be grabbed to scroll the PDF.
Text mode allows you to select and copy characters.
Bounds mode can specify comparison targets for each PDF. Make a new comparison while preserving the previous result.

In the 'Fit one page', the display of the PDF file changes according to the window size.
In the 'Fit width', the display of the PDF file changes according to the horizontal size of the window.

[How to use PDFComp](https://github.com/wiera987/PDFComp/wiki) also has some tips, so be sure to check it out.

## Development

This program was developed in C # and was built in the following environment:

* Microsoft Windows 11(22H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### Libraries

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer/) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.
* [MingCute Icon](https://github.com/Richard9394/MingCute) - MingCute is a set of simple and exquisite open-source icon library.

and The [PdfiumViewer] linked in this program uses a forked custom version(https://github.com/wiera987/PdfiumViewer) of [PdfiumViewer].

### Building PDFComp
Clone the source code for [PDFComp] and the custom version of [PdfiumViewer] and open the Visual Studio solution file.
Install the following a package from Manage NuGet Packages menu:

* PdfiemViewer.Native.x86_xx.xxxx (for your environment)

Also, the custom version of PdfiumViewer.csproj is referenced from the [PDFComp] solution.
For this reason, the custom version of [PdfiumViewer] should be extracted to a folder in the same hierarchy as [PDFComp].

Finally, build the PDFComp project.

## License

This project is licensed under the Apache License, Version2.0.
