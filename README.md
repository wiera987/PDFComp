# PDFComp
Existing comparison tools can make it difficult to track differences in PDFs when chapter structures or layouts change.
PDFComp is a Windows application that lets you compare corresponding pages while highlighting text differences with markers.

![PDFComp_3 2_MainForm](https://github.com/user-attachments/assets/f04a3e9f-8936-4cb8-8013-388c14aa6733)


## Overview
PDFComp offers two types of operations:
an automatic operation for quickly checking text, and a manual operation for carefully reviewing documents with major changes.
You can freely use both operations-compare documents as if you were marking up paper with a highlighter.

You can compare the entire document at once or focus on a specific part of a page. You can also compare particular chapters or sections by selecting bookmarks.
The first pages you compare are saved as a page pair, allowing you to move through both documents in sync or jump directly to pages that contain differences.
Even documents that are difficult to follow with automatic comparison alone can be reviewed carefully and thoroughly.

### Main Features
| Category | Description |
| --- | --- |
| PDF Display & Viewing | Displays two PDFs side by side and supports basic operations such as scrolling, searching, rotating, and zooming. |
| Difference Comparison | Compares text and **[Experimental]** character attributes such as color and strikethrough. |
| Automatic Operation | After selecting a comparison mode, uses `Jump to Prev/Next` to move to differences while keeping page navigation synchronized. |
| Manual Operation | Compares documents one page at a time while visually checking the currently displayed pages. |
| Comparison Modes | Page-based comparison with `Compare Page`, bookmark-based comparison with `Compare Bookmark`, and full-document comparison with `Compare Document`. |
| Range-Specific Comparison | Specifies comparison areas using `Bounds mode`, and allows re-comparison while keeping existing results. |
| Navigation | (Automatic) Jump to pages with differences; (Manual) synchronized page turning, individual page turning, and keyboard shortcuts. |
| Auxiliary Features | Text search, text copy, image copy, bookmark copy, and clearing markers. |

### Changes in PDFComp 3.2.0 
- **[Experimental]** Added support for comparing font colors, text attributes such as strikethrough and underline, and the colors of text attributes.  
- Added support for ignoring whitespace-only differences.  
- Added a blinking mode for difference markers.  
- These settings can be changed from the Options dialog.  
- Fixed: Improved the behavior of "Jump to Next" when one page corresponds to multiple pages.

### Application requirements

* Microsoft Windows 11(24H2) with .NET Framework 4.8

## Usage
### Installation

Download the ZIP file from [release](https://github.com/wiera987/PDFComp/releases) and run `PDFComp.exe`.

### Operation
**Automatic operation**  
This video shows PDFComp automatically detecting differences in the body text while excluding the header, and finally blinking the markers.  
The compared areas on the left and right flash in yellow, making the comparison range easy to identify at a glance.
![PDFComp_Ver3.2_Auto](https://github.com/user-attachments/assets/169768aa-5914-4e7e-8408-7638b6837d6b)

**Manual operation**  
This video shows how to use manual operation. Manual operation is useful when automatic comparison cannot detect the intended differences.
By letting the user specify exactly which parts to compare, the review process becomes more reliable and precise.
![PDFComp_Ver3.2_Manual](https://github.com/user-attachments/assets/bb1e96f2-ec07-4547-8aff-7eaeee6dd43c)

Use `Compare Page` when you want to compare one page at a time in manual operation.  
Use `Compare Bookmark` or `Compare Document` when you want to compare across multiple pages.  
`Compare Bookmark` compares pages by the range of the selected bookmark. Pages without bookmarks are compared together as one grouped range.  
`Compare Document` compares the entire document at once without considering bookmarks.  

`Pan` mode lets you drag the PDF to scroll.  
`Text` mode lets you select and copy text.  
`Bounds` mode lets you specify the comparison range for each PDF. Results outside the selected range remain as they are, and the specified range is compared again.  
Note: The comparison range specified with Bounds mode applies to all pages included in the selected comparison mode. To compare only the currently visible page, use `Compare Page`.

`Fit One Page` changes the PDF display to fit the window size.  
`Fit Width` changes the PDF display to fit the width of the window.

See also [How to use PDFComp](https://github.com/wiera987/PDFComp/wiki) for additional tips.

## Development environment

This program was developed in C# and built in the following environment.

* Microsoft Windows 11(24H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### Libraries

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [PDFium binaries](https://github.com/bblanchon/pdfium-binaries) - This project hosts pre-compiled binaries of the PDFium library.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.
* [MingCute Icon](https://github.com/Richard9394/MingCute) - MingCute is a set of simple and exquisite open-source icon library.

The `PdfiumViewer` linked in this program uses a forked custom version of [PdfiumViewer](https://github.com/wiera987/PdfiumViewer).

### How to build PDFComp

1. Download the source code for [PDFComp](https://github.com/wiera987/PDFComp) and the custom version of [PdfiumViewer](https://github.com/wiera987/PdfiumViewer), then open the Visual Studio solution file.
Since the PDFComp solution references the custom PdfiumViewer.csproj,
the custom PdfiumViewer must be extracted into a folder placed at the same directory level as PDFComp.

3. Download the DLL from [PDFium binaries](https://github.com/bblanchon/pdfium-binaries) and place it in the same folder as `PDFComp.exe`.

    * `pdfium.dll` : VERSION=149.0  BUILD=7811

4. Finally, build the `PDFComp` project.

## License

This project is licensed under the Apache License, Version 2.0.
