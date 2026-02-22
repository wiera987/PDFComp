import fitz  # PyMuPDF
print(f"PyMuPDF version loaded: {fitz.__version__}")

# https://pymupdf.readthedocs.io/latest/recipes-annotations.html#how-to-use-freetext

def create_full_annotation_test_pdf(output="annotation_full_suite2.pdf"):
    doc = fitz.open()

    # ---------------------------------------------------------
    # Page 1: Sticky Note / FreeText
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 1: Sticky Note / FreeText")

    # Sticky Note
    #page.add_text_annot((100, 100), "This is a sticky note annotation.")

    # FreeText
    '''
    page.add_freetext_annot(
        fitz.Rect(50, 150, 300, 200),
        "This is a FreeText annotation.",
        fontsize=12,
        fontname="helv",
        fill_color=(1, 1, 0)
    )
    '''

    # ---------------------------------------------------------
    # Page 2: Highlight / Underline / Strikeout / Squiggly
    # ---------------------------------------------------------
    page = doc.new_page()
    text = "This is a sample sentence for annotation rendering tests."
    page.insert_text((50, 50), "Page 2: Markup Annotations")
    page.insert_text((50, 100), text)

    #page.insert_text((50, 150), "Test string : Color, Text", color=(0.9, 0.3, 0))
    page.insert_text((50, 150), "Test string : Color, Text")

    page.insert_text((50, 200), "Test string : highlight, Annotations")
    page.insert_text((50, 250), "Test string : underline, Annotations")
    page.insert_text((50, 300), "Test string : strikeout, Annotations")
    page.insert_text((50, 350), "Test string : squiggly, Annotations")

    page.insert_text((50, 400), "Adobe Acrobat Annotations")
    page.insert_text((50, 450), "Test string : Color, Text")
    page.insert_text((50, 500), "Test string : note, Annotations")

    page.insert_text((50, 550), "Test string : highlight, Annotations")
    page.insert_text((50, 600), "Test string : underline, Annotations")
    page.insert_text((50, 650), "Test string : strikeout, Annotations")
    page.insert_text((50, 700), "Test string : squiggly, Annotations")


    # Get text bbox
    '''
    text_instances = page.search_for("sample sentence")
    if text_instances:
        rect = text_instances[0]
        page.add_highlight_annot(rect)
        page.add_underline_annot(rect)
        page.add_strikeout_annot(rect)
        page.add_squiggly_annot(rect)

    page.add_highlight_annot(page.search_for("highlight")[0])
    page.add_underline_annot(page.search_for("underline")[0])
    page.add_strikeout_annot(page.search_for("strikeout")[0])
    page.add_squiggly_annot(page.search_for("squiggly")[0])
    '''

    # ---------------------------------------------------------
    # Page 3: Shapes (Rectangle, Ellipse, Line)
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 3: Shape Annotations")

    '''
    page.add_rect_annot(fitz.Rect(50, 100, 200, 200))
    page.add_circle_annot(fitz.Rect(250, 100, 400, 200))
    page.add_line_annot(fitz.Point(50, 250), fitz.Point(300, 350))
    '''

    # ---------------------------------------------------------
    # Page 4: Link Annotation
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 4: Link Annotation")

    link_rect = fitz.Rect(50, 100, 250, 130)
    page.insert_text((50, 120), "Click here to open GitHub")
    '''
    link_data = {
      "kind": fitz.LINK_URI,      # 外部リンクの種類
      "from": link_rect,          # クリック可能な範囲
      "uri": "https://github.com" # リンク先URL
    }
    page.insert_link(link_data)
    '''

    # ---------------------------------------------------------
    # Page 5: Ink (handwriting)
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 5: Ink Annotation")

    '''
    paths = [
        # 線1: カクカクした線
        [(100, 100), (150, 150), (100, 200)],
        # 線2: なめらかな線（多くの点を指定する）
        [(200, 100), (210, 120), (230, 130),
        (250, 120), (260, 100)]
    ]
    annot = page.add_ink_annot(paths)
    annot.set_border(width=3)           # 線の太さ
    annot.update()                      # 変更を適用
    '''

    # ---------------------------------------------------------
    # Page 6: Transparency / Overlap Tests
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 6: Transparency / Overlap Tests")

    sample_text = "Transparency and overlap test text."
    page.insert_text((50, 100), sample_text)

    '''
    rects = page.search_for("test text")
    if rects:
        r = rects[0]

        # Highlight with different opacities
        for i, opacity in enumerate([0.2, 0.5, 0.8]):
            annot = page.add_highlight_annot(r)
            annot.set_opacity(opacity)
            annot.update()

        # Overlap highlight + strikeout
        strike = page.add_strikeout_annot(r)
        strike.set_colors({"stroke": (1, 0, 0)})
        strike.update()

    # Rectangle + FreeText overlap
    rect_overlap = fitz.Rect(50, 200, 250, 300)
    page.add_rect_annot(rect_overlap)

    page.add_freetext_annot(
        rect_overlap,
        "Overlapping FreeText",
        fontsize=14,
        fill_color=(0.8, 0.8, 1)
    )
    '''

    # ---------------------------------------------------------
    # Page 7: Edge Cases / Abnormal Cases
    # ---------------------------------------------------------
    page = doc.new_page()
    page.insert_text((50, 50), "Page 7: Edge / Abnormal Cases")

    '''
    # Annotation at page edge
    page.add_text_annot((5, 5), "Edge note")

    # Near-zero size annotation
    tiny_rect = fitz.Rect(100, 100, 101, 101)
    page.add_rect_annot(tiny_rect)

    # Very long FreeText
    long_text = "This is a very long FreeText annotation. " * 20 # Define long_text here
    page.add_freetext_annot(
        fitz.Rect(50, 150, 400, 250),
        long_text,
        fontsize=8,
        fill_color=(1, 1, 0.8)
    )
    '''

    # Fully transparent highlight
    page.insert_text((50, 300), "Fully transparent highlight test")
    '''
    rects = page.search_for("transparent")
    if rects:
        annot = page.add_highlight_annot(rects[0])
        annot.set_opacity(0.0)
        annot.update()
    '''

    # ---------------------------------------------------------
    # Save
    # ---------------------------------------------------------
    doc.save(output)
    doc.close()
    print(f"Generated: {output}")


if __name__ == "__main__":
    create_full_annotation_test_pdf()
