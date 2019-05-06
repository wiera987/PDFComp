# PDFComp
Compare two PDF files and highlight different characters.

## Background

There is a tool that automatically compares the differences between two PDF files, but it seems difficult to compare pages as the user thought.This is an application that easily navigates and compares single pages, highlights differences and displays them.
As it is an experimental project so far, it has only the minimum required functionality.

## Usage
### Prerequisites

* Microsoft Windows7 sp1 with .NET Framework 4.5.2

### Installing

Download the program and run PDFComp.exe.

## Development

It was developed in the following environment.

* Microsoft Windows7 sp1 with .NET Framework 4.5.2
* Microsoft Visual Studio Community 2019

### Built With

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer/) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [NetDiff](https://github.com/skanmera/NetDiff/) - This is the C # implementation of the Diff algorithm.

### Building PDFComp
Clone the source code and open the Visual Studio solution file.
Install the following three packages from NuGet:

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx (for your environment)
* Diff4Net

Build the PDFComp project.

## License

This project is licensed under the Apache License, Version2.0.

