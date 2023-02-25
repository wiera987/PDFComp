# PDFComp
Compare two PDF files and highlight different characters.

<img src="https://user-images.githubusercontent.com/50268838/221343544-6091211d-d513-426d-8aae-e756b3c5d02e.png" width="480">

## Background

There are tools that automatically compare the differences between two PDF files, but you can't detect the difference well unless they are almost the same text.
When comparing PDF files with a revised paragraph structure, the pages you want are not compared and you need to specify the pages again.
This PDFComp is an application that specializes in manual operation and allows you to quickly move pages and check one page at a time.

The GUI has been updated and features such as navigation to difference pages and search history have been added.
Clicking on a page number to enter and copying an image with reduced color has been added.

### Application requirements

* Microsoft Windows 11(22H2) with .NET Framework 4.8

## Usage
### Installation

Download the zip file from [release](https://github.com/wiera987/PDFComp/releases) and execute PDFComp.exe contained in it.

### Operation

* The 'Open' button open two pdf files. (or drop the file)
* The '<Prev' and '>Next' buttons navigate two pdf pages at the same time. (arrow left and right keys)
* The '<' and '>' buttons move between the pages of the respective PDF file. (Ctrl+arrow keys, Alt+arrow keys)
* The '<<' and '>>' buttons navigate to the page with the differences while comparing the two PDF files.
* The 'Compare page' button is to compare and hilight displaied pages. (space key)
* The 'Clear markers' context menu is to clear the different markers.
* The 'Copy text' context menu copies text.
* The 'Copy' menus copies PDF images and Bookmark text. If the 'Enable color reduction copy' menu is checked, the colors will be reduced to 256 when copying an image.
* The 'Find...' menu show the text search window. You can search for each PDF.

If you hit the space key repeatedly, the part with the difference will flash.
Pan mode can be grabbed to scroll the PDF.
Text mode allows you to select and copy characters.
Bounds mode can specify comparison targets for each PDF. Make a new comparison while preserving the previous result.

## Development

This program was developed in C # and was built in the following environment:

* Microsoft Windows 11(22H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### Libraries

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer/) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.

and The [PdfiumViewer] linked in this program uses a forked custom version(https://github.com/wiera987/PdfiumViewer) of [PdfiumViewer].

### Building PDFComp
Clone the source code and open the Visual Studio solution file.
Install the following two packages from Manage NuGet Packages menu:

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx (for your environment)

Also, the custom version of PdfiumViewer.csproj is referenced from the [PDFComp] solution.
For this reason, the custom version of [PdfiumViewer] should be extracted to a folder in the same hierarchy as [PDFComp].

Finally, build the PDFComp project.

## License

This project is licensed under the Apache License, Version2.0.
