# PDFComp
Compare two PDF files and highlight different characters.

![PDFComp_3 1_MainForm](https://github.com/user-attachments/assets/c7d06a98-609c-4f78-a509-539faa3c7cfe)

## Background

There are tools that automatically compare the differences between two PDF files, but you can't detect the difference well unless they are almost the same text.
When comparing PDF files with a revised paragraph structure, the pages you want are not compared and you need to specify the pages again.
This PDFComp is an application that specializes in manual operation and allows you to quickly move pages and check one page at a time.
The latest version also adds an automatic comparison mode that uses bookmarks.

PDFComp 3.1.0
Default mode is now 'Compare Bookmark', and 'Compare Book' is now 'Compare Document'.
New: Flash indicators! Now, the compared areas are temporarily highlighted when you jump to the next/prev difference, making it easy to see the target in both files.

### Application requirements

* Microsoft Windows 11(24H2) with .NET Framework 4.8

## Usage
### Installation

Download the zip file from [release](https://github.com/wiera987/PDFComp/releases) and execute PDFComp.exe contained in it.

### Operation

* The 'Open' button opens two PDF files (or you can drop the files).
* The '<<' and '>>' buttons move both PDF pages simultaneously (you can also use the left and right arrow keys).
* The '<' and '>' buttons move between the pages of each PDF independently (Ctrl+arrow keys, Alt+arrow keys).
* The 'Jump to Prev/Next' buttons ('<-' and '->') navigate either to the next difference or to the next page while comparing the two PDF files.
  You can switch this behavior using the 'Jump to Diffs/Pages' toggle.
* The 'Compare Page' button compares and highlights the currently displayed pages (space key).
* The 'Compare Bookmark' button compares and highlights differences on the pages associated with the selected bookmark.
* The 'Compare Document' button compares and highlights differences across the entire PDF file.
* The 'Clear Markers' context menu clears all difference markers.
* The 'Copy Text' context menu copies text.
* The 'Copy' menus copy PDF images and Bookmarks text. If 'Enable color reduction copy' is checked, image colors are reduced to 256 when copying.
* The 'Find...' menu opens the text search window. You can search each PDF individually.

Use 'Compare Page' to manually compare one page at a time.
To compare across multiple pages, use 'Compare Bookmark' or 'Compare Document'.
'Compare Bookmark' compares the pages associated with the selected bookmark. Pages without bookmarks are compared as a single range.
'Compare Document' compares the entire PDF at once, without using any bookmark or chapter structure.

Pressing the space key repeatedly flashes the regions containing differences.
Pan mode allows you to drag the page to scroll the PDF.
Text mode allows you to select and copy text.
Bounds mode lets you specify comparison targets for each PDF, enabling new comparisons while preserving previous results.

'Fit One Page' scales the page to fit the entire window.
'Fit Width' scales the page to match the window's width.

See also: [How to use PDFComp](https://github.com/wiera987/PDFComp/wiki) for additional tips.

## Development

This program was developed in C # and was built in the following environment:

* Microsoft Windows 11(24H2) with .NET Framework 4.8
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
