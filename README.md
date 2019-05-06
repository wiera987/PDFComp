# PDFComp
Compare two PDF files and highlight different characters.

<img src="https://user-images.githubusercontent.com/50268838/57225045-2575a780-7046-11e9-9f16-0b3a44c5f5ee.png" width="480">

## Background

There is a tool that automatically compares the differences between two PDF files, but it seems difficult to compare pages as the user thought.This is an application that easily navigates and compares single pages, highlights differences and displays them.

As it is an experimental project so far, it has only the minimum required functionality.

### Prerequisites

* Microsoft Windows 7 sp1 with .NET Framework 4.5.2

## Usage
### Installation

Download the program from [release](https://github.com/wiera987/PDFComp/releases) and run PDFComp.exe.

### Operation

* 'Open' button open 2 pdf files.
* '<Prev' and '>Next' button navigate both pdf files.
* '<' and '>' button navigate single pdf file.
* 'Compare page' button is to compare and hilight displaied pages.

## Development

It was developed in the following environment.

* Microsoft Windows 7 sp1 with .NET Framework 4.5.2
* Microsoft Visual Studio Community 2019

### Built With

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer/) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [NetDiff](https://github.com/skanmera/NetDiff/) - This is the C # implementation of the Diff algorithm.

and this [release](https://github.com/wiera987/PDFComp/releases) has forked [PdfiumViewer](https://github.com/wiera987/PdfiumViewer)

### Building PDFComp
Clone the source code and open the Visual Studio solution file.
Install the following three packages from NuGet:

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx (for your environment)
* Diff4Net

Build the PDFComp project in C#.

## License

This project is licensed under the Apache License, Version2.0.
