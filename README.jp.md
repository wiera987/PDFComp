# PDFComp
�Q��PDF�t�@�C���̕������r���āA�قȂ镔�����n�C���C�g�\�����܂��B

<img src="https://user-images.githubusercontent.com/50268838/221343544-6091211d-d513-426d-8aae-e756b3c5d02e.png" width="480">

## �w�i

2��PDF�t�@�C���̈Ⴂ�������I�ɔ�r����c�[���͂���܂����A�قƂ�Ǔ����e�L�X�g�łȂ��Ə��ɈႢ�����o���邱�Ƃ͏o���܂���B
�i���\�������������悤��PDF�t�@�C�����r����Ƃ��́A�v�����y�[�W���m����r���ꂸ�y�[�W�̍Ďw�肪�K�v�ɂȂ�܂��B
����PDFComp�̓}�j���A������ɓ������y�[�W��f�����ړ����āA�P�y�[�W���m�F���Ă������߂̃A�v���P�[�V�����ł��B

���كy�[�W�ւ̈ړ��A���������Ȃǂ̋@�\���ǉ�����܂����B
�y�[�W�ԍ����N���b�N���Ă̓��́A���F���Ẳ摜�R�s�[���ǉ�����܂����B

### �����

* Microsoft Windows 11(22H2) with .NET Framework 4.8

## �g����
### �C���X�g�[��

[release](https://github.com/wiera987/PDFComp/releases)����ZIP�t�@�C�����_�E�����[�h���āAPDFComp.exe�����s���܂��B

### ������@

* 'Open' �{�^���� 2��pdf�t�@�C�����J���܂�. (�������̓t�@�C�����h���b�v)
* '<Prev' �� '>Next' �{�^���Ł@������2��PDF�t�@�C���̃y�[�W���ړ����܂�. (���E�̖��L�[)
* '<' �� '>' �{�^���́A���ꂼ���PDF�t�@�C���̃y�[�W���ړ����܂�. (CTRL+���L�[�AALT+���L�[)
* '<<' �� '>>'�{�^���́A�Q��PDF�t�@�C�����r���Ȃ��獷�ق̂���y�[�W�܂ňړ����܂�.
* 'Compare page' �{�^���������ƁA�y�[�W�̍��ق��n�C���C�g�\�����܂�. (�X�y�[�X�L�[)
* 'Clear markers' �̃R���e�L�X�g���j���[�ŁA�n�C���C�g�\�����Ă��鍷���}�[�J�[���N���A���܂�.
* 'Copy text'  �̃R���e�L�X�g���j���[�Ńe�L�X�g���R�s�[���܂�.
* 'Copy' ���j���[�� PDF�C���[�W�₵����̃e�L�X�g���R�s�[���܂�. 'Enable color reduction copy'���j���[�Ƀ`�F�b�N������ƁA�C���[�W�R�s�[����256�F�Ɍ��F���܂�.
* 'Find...' ���j���[�́A�e�L�X�g�����̂��߂̃E�C���h�E���J���܂�. ���ꂼ���PDF�������ł��܂�.

�X�y�[�X�L�[��A�ł���ƁA���ق̕������_�ł��܂�.
Pan���[�h�͂����PDF���X�N���[���ł��܂�.
Text���[�h�͕�����I�����ăR�s�[�ł��܂�.
Bounds���[�h�͂��ꂼ���PDF�̔�r�Ώۂ��w��ł��܂��B�ȑO�̌��ʂ��c�����܂ܐV������r�����܂��B


## �J����

���̃v���O������C#�ŊJ������Ă���A���̊��Ńr���h����܂����B

* Microsoft Windows 11(22H2) with .NET Framework 4.8
* Microsoft Visual Studio Community 2022

### ���C�u����

* [PdfiumViewer](https://github.com/pvginkel/PdfiumViewer) - PdfiumViewer is a PDF viewer based on the PDFium project.
* [diff-match-patch](https://github.com/google/diff-match-patch/) - Diff Match Patch is a high-performance library in multiple languages that manipulates plain text.

�܂��{�v���O�����Ń����N���Ă��� [PdfiumViewer]�̓t�H�[�N�����J�X�^���ł�[PdfiumViewer](https://github.com/wiera987/PdfiumViewer)���g�p���Ă��܂�.

### PDFComp�̃r���h���@

�\�[�X�R�[�h���_�E�����[�h���āAVisual Studio�̃\�����[�V�����t�@�C�����J���܂��B
'�\�����[�V������NuGet�p�b�P�[�W�̊Ǘ�'���j���[���玟�̂Q���C���X�g�[�����܂��B

* PdfiumViewer
* PdfiemViewer.Native.x86_xx.xxxx

�܂��A[PDFComp]�̃\�����[�V��������A�J�X�^���ł�PdfiumViewer.csproj���Q�Ƃ��Ă��܂��B
���̂��߃J�X�^���ł�[PdfiumViewer]�́A[PDFComp]�Ɠ����K�w�̃t�H���_�ɓW�J���Ă����܂��B

�Ō�� PDFComp�v���W�F�N�g���r���h���܂��B

## ���C�Z���X

���̃v���W�F�N�g�� the Apache License, Version2.0 �̂��ƂŃ��C�Z���X����Ă��܂�.

