# PDFComp
２つのPDFファイルの文字を比較して、異なる部分をハイライト表示します。

<img src="https://user-images.githubusercontent.com/50268838/57225045-2575a780-7046-11e9-9f16-0b3a44c5f5ee.png" width="480">

## 背景

2つのPDFファイルの違いを自動的に比較するツールはありますが、ほとんど同じテキストでないと上手に違いを検出することは出来ません。
段落構成を見直したようなPDFファイルを比較するときは、思ったページ同士が比較されずページの再指定が必要になります。
このPDFCompはマニュアル操作に特化しページを素早く移動して、１ページずつ確認していくためのアプリケーションです。
今のところ実験的なプロジェクトなので、必要最低限の機能しかありません。

### 動作環境

* Microsoft Windows 7 sp1 with .NET Framework 4.5.2

## 使い方
### インストール

[release](https://github.com/wiera987/PDFComp/releases)からZIPファイルをダウンロードして、PDFComp.exeを実行します。

### 操作方法

* 'Open' ボタンで 2つのpdfファイルを開きます. (もしくはファイルをドロップ)
* '<Prev' と '>Next' ボタンで　同時に2つのPDFファイルのページを移動します. (左右の矢印キー)
* '<' と '>' ボタンは、それぞれのPDFファイルのページを移動します. (CTRL+矢印キー、ALT+矢印キー)
* 'Compare page' ボタンを押すと、ページの差異をハイライト表示します. (スペースキー)
* 'Clear markers' のコンテキストメニューで、ハイライト表示している差分マーカーをクリアします.
* 'Copy text'  のコンテキストメニューでテキストをコピーします.
* 'Copy' メニューは PDFイメージやしおりのテキストをコピーします.
* 'Find...' メニューは、テキスト検索のためのウインドウを開きます.

## 開発環境

このプログラムはC#で開発されており、次の環境でビルドされました。

* Microsoft Windows7 sp1 with .NET Framework 4.5.2
* Microsoft Visual Studio Community 2019

### ライブラリ

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [NetDiff](https://github.com/skanmera/NetDiff/) - This is the C # implementation of the Diff algorithm.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.

また本プログラムでリンクしている [PdfiumViewer]はフォークしたカスタム版の[PdfiumViewer](https://github.com/wiera987/PdfiumViewer)を使用しています.

### PDFCompのビルド方法

ソースコードをダウンロードして、Visual Studioのソリューションファイルを開きます。
'ソリューションのNuGetパッケージの管理'メニューから次の３つをインストールします。

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx
* Diff4Net

また、カスタム版の[PdfiumViewer]をビルドして、[PdfiumViewer]と置き換えます。

最後に PDFCompプロジェクトをビルドします。

## ライセンス

このプロジェクトは the Apache License, Version2.0 のもとでライセンスされています.

