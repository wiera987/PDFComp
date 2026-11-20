# PDFComp
既存の比較ツールでは、章構成やレイアウトが変わった場合にPDFの差分を追いにくいことがありました。  
PDFCompは、テキストの差分をマーカーで表示しながら、対応するページを見比べて確認できるWindows向けアプリケーションです。

![PDFComp_3 2_MainForm](https://github.com/user-attachments/assets/f04a3e9f-8936-4cb8-8013-388c14aa6733)

## 概要

PDFComp は、２つの使い方があります。
文章を手軽に確認するオート操作と、大きく変更された文章を丹念に比較していくマニュアル操作です。  
どちらの操作も分け隔てなく行えるので、紙にマーカーを引くように自由に比較してみてください。

文章全体をまとめて比較することも、ページの一部を指定して比較することも可能です。ブックマークを指定して特定の章やセクションを比較することも可能です。  
最初に比較したページ同士をページペアとして保持するので、ページ送りをそろえて移動したり、差分のあるページへ順に移動したりできます。  
自動比較だけでは追いにくい文書でも、丁寧にレビューを進められます。

### 主な機能
| 機能分類 | 内容 |
|---|---|
| PDF表示・閲覧 | 2つのPDFを並べて表示し、スクロール・検索・回転・拡大などの基本操作に対応 |
| 差分比較 | テキストの比較と、 **[実験的]** 文字の色/取り消し線などの文字属性の比較 |
| オート操作 | 比較モードの選択後、`Jump to Prev/Next` でページ送りを同期しながら差分に移動 |
| マニュアル操作 | 表示中のページを見ながら、必要な箇所を1ページずつ比較して確認 |
| 比較モード | `Compare Page` によるページ単位、`Compare Bookmark` によるブックマーク単位、`Compare Document` による文書全体 |
| 範囲指定比較 | `Bounds mode` による比較範囲の指定、既存結果を残したままの再比較 |
| ナビゲーション | (オート) 差分ページジャンプ、（マニュアル）同時ページ送り、個別ページ送り、キーボードショートカット |
| 補助機能 | テキスト検索、テキストコピー、画像コピー、ブックマークコピー、マーカーのクリア |

### PDFComp 3.3.0 の変更点
- **日本語・ドイツ語UIを追加。** Windowsの表示言語に合わせる自動設定にも対応しました。
- **左右のPDFビューに表示履歴を追加。** 確認していた箇所へ戻ったり、再び進んだりできます。
- **差分ジャンプのキーボードショートカットを追加。** キー操作で前後の差分へ連続移動できます。
- **差分移動と範囲比較を改善。** 空白ページをまたぐ差分ジャンプを修正し、用紙サイズや回転が混在するPDFでの範囲比較を改善しました。

### 動作環境

* Microsoft Windows 11(24H2) with .NET Framework 4.8

## 使い方
### インストール

[release](https://github.com/wiera987/PDFComp/releases)からZIPファイルをダウンロードして、PDFComp.exeを実行します。

### 操作方法
**自動操作**  
この動画では、PDFComp がヘッダーを除外して本文の差異を自動的に検出して、最後にマーカーを点滅させる様子を紹介しています。  
左右の比較範囲が黄色くフラッシュするので、比較範囲がひと目で分かるようになっています。  
![PDFComp_Ver3.2_Auto](https://github.com/user-attachments/assets/169768aa-5914-4e7e-8408-7638b6837d6b)

**マニュアル操作**  
この動画では、マニュアル操作の方法を紹介しています。自動比較では意図した差異を検出できない場合に、マニュアル操作が役立ちます。  
比較したい箇所をユーザーが指定することで、レビュー作業をより確実に進められます。  
![PDFComp_Ver3.2_Manual](https://github.com/user-attachments/assets/bb1e96f2-ec07-4547-8aff-7eaeee6dd43c)

**比較モード**  
マニュアル操作で1ページずつ比較する場合は、`Compare Page`を使用します.  
ページをまたがる比較には、`Compare Bookmark`か`Compare Document`を使用します.  
`Compare Bookmark`は選択したブックマークの範囲単位でページを比較します。ブックマークが定義されていないページについてはそれらをまとめた単位で比較します.  
`Compare Document`はブックマークを考慮せずにドキュメント全体を一度に比較します.  

`Pan`モードはつかんでPDFをスクロールできます.  
`Text`モードは文字を選択してコピーできます.  
`Bounds`モードは左右それぞれのページの比較範囲を指定できます。範囲外はそのまま以前の結果を残し、指定範囲を新しく比較をします.  
Note: `Bounds mode` による範囲指定は、比較モードで指定した全ページに影響します。見えているページだけ比較するには`Compare Page`を使用します. 

`Fit One Page` では、ウィンドウのサイズに合わせてPDFファイルの表示が変わります.
`Fit Width` では、ウィンドウの横幅に合わせてPDFファイルの表示が変わります.

### ジャンプのショートカット

| 操作 | ショートカット | 代替キー |
| --- | --- | --- |
| 次へジャンプ | `F8` | `N` |
| 前へジャンプ | `Shift+F8` | `P` |

`Jump to Prev/Next` ボタンと同じ動作をします。
専用のファンクションキーがないキーボードでは、`N`／`P`を使用してください。
`N`／`P` は左右いずれかのPDF表示にキーボードフォーカスがあるときだけ使えます。PDF表示をクリックしてから操作してください。
文字入力欄やコンボボックスでは、通常の入力やIME操作をこのショートカットキーより優先します。

[PDFCompの使い方](https://github.com/wiera987/PDFComp/wiki) にもヒントが載っていますので、ご覧ください。

## 開発環境

このプログラムはC#で開発されており、次の環境でビルドされました。

* Microsoft Windows 11(24H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### ライブラリ

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [PDFium binaries](https://github.com/bblanchon/pdfium-binaries) - This project hosts pre-compiled binaries of the PDFium library.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.
* [MingCute Icon](https://github.com/Richard9394/MingCute) - MingCute is a set of simple and exquisite open-source icon library.

また本プログラムでリンクしている [`PdfiumViewer`]はフォークしたカスタム版の[PdfiumViewer](https://github.com/wiera987/PdfiumViewer)を使用しています.

### PDFCompのビルド方法

1. [`PDFComp`]とカスタム版の[`PdfiumViewer`]のソースコードをダウンロードして、Visual Studioのソリューションファイルを開きます。  
[`PDFComp`]のソリューションからカスタム版のPdfiumViewer.csprojを参照しているため、
カスタム版の[`PdfiumViewer`]は、[`PDFComp`]と同じ階層のフォルダに並べて展開しておく必要があります。

3. [`PDFium binaries`]からDLLをダウンロードして、PDFComp.exeと同じフォルダに配置します。  
   * `pdfium.dll` : VERSION=149.0 BUILD=7811

4. 最後に `PDFComp`プロジェクトをビルドします。

## ライセンス

このプロジェクトは the Apache License, Version2.0 のもとでライセンスされています.

