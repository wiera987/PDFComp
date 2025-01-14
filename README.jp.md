# PDFComp
２つのPDFファイルの文字を比較して、異なる部分をハイライト表示します。

![PDFComp_3 0_MainForm](https://github.com/user-attachments/assets/a10aae2a-4c8a-45b9-b398-9ff2a608c8f6)

## 背景

2つのPDFファイルの違いを自動的に比較するツールはありますが、ほとんど同じテキストでないと上手に違いを検出することは出来ません。
段落構成を見直したようなPDFファイルを比較するときは、思ったページ同士が比較されずページの再指定が必要になります。
このPDFCompはマニュアル操作に特化しページを素早く移動して、１ページずつ確認していくためのアプリケーションです。
また最新版では、ブックマークを利用した自動的に比較するモードを追加しました。

PDFComp 3.0.0
'Compare bookmark'と'Compare book'に対応しました。

### 動作環境

* Microsoft Windows 11(22H2) with .NET Framework 4.8

## 使い方
### インストール

[release](https://github.com/wiera987/PDFComp/releases)からZIPファイルをダウンロードして、PDFComp.exeを実行します。

### 操作方法

* 'Open' ボタンで 2つのpdfファイルを開きます. (もしくはファイルをドロップ)
* '<<' と '>>' ボタンで　同時に2つのPDFファイルのページを移動します. (左右の矢印キー)
* '<' と '>' ボタンは、それぞれのPDFファイルのページを移動します. (CTRL+矢印キー、ALT+矢印キー)
* '<-' と '->'ボタンは、２つのPDFファイルを比較しながら差異のあるページまで移動します.
* 'Compare page' ボタンを押すと、ページの差異をハイライト表示します. (スペースキー)
* 'Compare bookmark' ボタンを押すと、選択されているブックマークのページの差異をハイライト表示します. 
* 'Compare book' ボタンを押すと、PDF1冊分のページを比較してハイライト表示します.
* 'Clear markers' のコンテキストメニューで、ハイライト表示している差分マーカーをクリアします.
* 'Copy text'  のコンテキストメニューでテキストをコピーします.
* 'Copy' メニューは PDFイメージやしおりのテキストをコピーします. 'Enable color reduction copy'メニューにチェックをつけると、イメージコピー時に256色に減色します.
* 'Find...' メニューは、テキスト検索のためのウインドウを開きます. それぞれのPDFを検索できます.

マニュアル操作で1ページずつ比較する場合は、'Compare page'を使用します。
ページをまたがる比較には、'Compare bookmark'か'Compare book'を使用します。
'Compare bookmark'はPDFファイルにブックマークが必要で、現在選択されているブックマーク項目の章構成を参照してのページ同士を比較します。ブックマークが存在しないページでは１ページ単位の比較になります。
'Compare book'は章構成は考慮せず一度にファイル全体を比較します。

スペースキーを連打すると、差異の部分が点滅します.
PanモードはつかんでPDFをスクロールできます.
Textモードは文字を選択してコピーできます.
BoundsモードはそれぞれのPDFの比較対象を指定できます。以前の結果を残したまま新しい比較をします。

「1ページに合わせる」では、ウィンドウのサイズに合わせてPDFファイルの表示が変わります。
「幅に合わせる」では、ウィンドウの横幅に合わせてPDFファイルの表示が変わります。

[PDFCompの使い方](https://github.com/wiera987/PDFComp/wiki) にもヒントが載っていますので、ご覧ください。

## 開発環境

このプログラムはC#で開発されており、次の環境でビルドされました。

* Microsoft Windows 11(22H2) with .NET Framework 4.8
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

