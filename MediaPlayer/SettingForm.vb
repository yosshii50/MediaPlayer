﻿Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class SettingForm

    'Dim BaseViewPicture As ViewPicture
    Dim BaseSetting As Setting_Cls
    Dim RetCode As Boolean

    Public Function OpenSettingFormDirect(ByRef WrkSetting As Setting_Cls) As Boolean

        'BaseViewPicture = WrkViewPicture
        BaseSetting = WrkSetting

        TextBox1.Text = BaseSetting.FileName
        TextBox2.Text = BaseSetting.ViewTime.ToString

        RetCode = False
        Me.ShowDialog()

        Return RetCode
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        BaseSetting.FileName = TextBox1.Text
        BaseSetting.ViewTime = CInt(TextBox2.Text)

        RetCode = True
        Me.Dispose()
    End Sub
    'ファイル変更
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim WrkFileName As String = TextBox1.Text
        If OpenFile(WrkFileName) = True Then
            TextBox1.Text = WrkFileName
        End If

    End Sub

    Public Function OpenFile(ByRef WrkFileName As String) As Boolean

        'OpenFileDialogクラスのインスタンスを作成
        Dim WrkOpenFile As New OpenFileDialog()

        With WrkOpenFile

            .FileName = System.IO.Path.GetFileName(WrkFileName)
            If WrkFileName <> "" Then
                .InitialDirectory = System.IO.Path.GetDirectoryName(WrkFileName)
            End If
            .Filter = "すべてのファイル(*.*)|*.*"
            .FilterIndex = 1
            '.Title = "開くファイルを選択してください"
            ''ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            'ofd.RestoreDirectory = True

            'ダイアログを表示する
            If .ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名を表示する
                WrkFileName = .FileName

                Return True
            End If

        End With

        Return False
    End Function


End Class