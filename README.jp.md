# PDFComp
２つのPDFファイルの文字を比較して、異なる部分をハイライト表示します。

![PDFComp_3 1_MainForm](https://github.com/user-attachments/assets/c7d06a98-609c-4f78-a509-539faa3c7cfe)

## 背景

2つのPDFファイルの違いを自動的に比較するツールはありますが、ほとんど同じテキストでないと上手に違いを検出することは出来ません。
段落構成を見直したようなPDFファイルを比較するときは、思ったページ同士が比較されずページの再指定が必要になります。
このPDFCompはマニュアル操作に特化しページを素早く移動して、１ページずつ確認していくためのアプリケーションです。
また最新版では、ブックマークを利用した自動的に比較するモードを追加しました。

PDFComp 3.1.0
'Compare Bookmark'モードがデフォルトの比較方法になりました。'Compare Book'は'Compare Document'に改名しました。
新しいフラッシュインジケーターを追加しました。'Jump to Prev/Next'ボタンを使用したときに比較された領域が一時的に強調表示され、2つのドキュメントの比較対象を示します。

### 動作環境

* Microsoft Windows 11(24H2) with .NET Framework 4.8

## 使い方
### インストール

[release](https://github.com/wiera987/PDFComp/releases)からZIPファイルをダウンロードして、PDFComp.exeを実行します。

### 操作方法

* 'Open' ボタンで 2つのPDFファイルを開きます. (もしくはファイルをドロップ)
* '<<' と '>>' ボタンで　同時に2つのPDFファイルのページを移動します. (左右の矢印キー)
* '<' と '>' ボタンは、それぞれのPDFファイルのページを移動します. (CTRL+矢印キー、ALT+矢印キー)
* 'Jump to Prev/Next'ボタン('<-' と '->')は、２つのPDFファイルを比較しながら差異や次のページまで移動します.
   この動作は'Jump to Diffs/Pages'ボタンで切り替えます.
* 'Compare Page' ボタンを押すと、ページの差異をハイライト表示します. (スペースキー)
* 'Compare Bookmark' ボタンを押すと、選択されているブックマークのページの差異をハイライト表示します. 
* 'Compare Document' ボタンを押すと、PDF1冊分のページを比較してハイライト表示します.
* 'Clear Markers' のコンテキストメニューで、ハイライト表示している差分マーカーをクリアします.
* 'Copy Text'  のコンテキストメニューでテキストをコピーします.
* 'Copy' メニューは PDFイメージやしおりのテキストをコピーします. 'Enable color reduction copy'メニューにチェックをつけると、イメージコピー時に256色に減色します.
* 'Find...' メニューは、テキスト検索のためのウインドウを開きます. それぞれのPDFを検索できます.

マニュアル操作で1ページずつ比較する場合は、'Compare Page'を使用します.
ページをまたがる比較には、'Compare Bookmark'か'Compare Document'を使用します.
'Compare Bookmark'は選択したブックマークの範囲のページを比較します。ブックマークがないページはそれらをまとめ比較します.
'Compare Document'はブックマークを考慮せずにドキュメント全体を一度に比較します.

スペースキーを連打すると、差異の部分が点滅します.
PanモードはつかんでPDFをスクロールできます.
Textモードは文字を選択してコピーできます.
BoundsモードはそれぞれのPDFの比較対象を指定できます。以前の結果を残したまま新しい比較をします.

'Fit One Page' では、ウィンドウのサイズに合わせてPDFファイルの表示が変わります.
'Fit Width' では、ウィンドウの横幅に合わせてPDFファイルの表示が変わります.

[PDFCompの使い方](https://github.com/wiera987/PDFComp/wiki) にもヒントが載っていますので、ご覧ください。

## 開発環境

このプログラムはC#で開発されており、次の環境でビルドされました。

* Microsoft Windows 11(24H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### ライブラリ

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.
* [MingCute Icon](https://github.com/Richard9394/MingCute) - MingCute is a set of simple and exquisite open-source icon library.

また本プログラムでリンクしている [PdfiumViewer]はフォークしたカスタム版の[PdfiumViewer](https://github.com/wiera987/PdfiumViewer)を使用しています.

### PDFCompのビルド方法

[PDFComp]とカスタム版の[PdfiumViewer]のソースコードをダウンロードして、Visual Studioのソリューションファイルを開きます。
'ソリューションのNuGetパッケージの管理'メニューから次のパッケージをインストールします。

* PdfiemViewer.Native.x86_xx.xxxx

[PDFComp]のソリューションから、カスタム版のPdfiumViewer.csprojを参照しているため、カスタム版の[PdfiumViewer]は、[PDFComp]と同じ階層のフォルダに展開しておく必要があります。

最後に PDFCompプロジェクトをビルドします。

## ライセンス

このプロジェクトは the Apache License, Version2.0 のもとでライセンスされています.

