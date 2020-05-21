Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class SettingForm

    'Dim BaseViewPicture As ViewPicture
    Dim BaseSetting As Setting_Cls
    Dim RetCode As Boolean

    Public Function OpenSettingFormDirect(ByRef WrkSetting As Setting_Cls) As Boolean

        'BaseViewPicture = WrkViewPicture
        BaseSetting = WrkSetting

        Select Case BaseSetting.ViewType
            Case Setting_Cls.ViewType_Enum.Picture
                RadioButton1.Checked = True
            Case Setting_Cls.ViewType_Enum.Movie
                RadioButton2.Checked = True
        End Select
        TextBox1.Text = BaseSetting.FileName
        TextBox2.Text = BaseSetting.ViewTime.ToString
        PlayFilename.Text = BaseSetting.MovieName

        RetCode = False

        Me.ShowDialog()

        Return RetCode
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If RadioButton1.Checked = True Then
            BaseSetting.ViewType = Setting_Cls.ViewType_Enum.Picture
        ElseIf RadioButton2.Checked = True Then
            BaseSetting.ViewType = Setting_Cls.ViewType_Enum.Movie
        End If
        BaseSetting.FileName = TextBox1.Text
        BaseSetting.ViewTime = CDec(TextBox2.Text)
        BaseSetting.MovieName = PlayFilename.Text

        RetCode = True
        Me.Close()
        Me.Dispose()
    End Sub

    'キャンセル
    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.Close()
        Me.Dispose()
    End Sub

    'ファイル変更
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call OpenFile(TextBox1.Text, False)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call OpenFile(PlayFilename.Text, True)
    End Sub

    Public Function OpenFile(ByRef WrkFileName As String, ByVal SetFileExists As Boolean) As Boolean

        'OpenFileDialogクラスのインスタンスを作成
        Dim WrkOpenFile As New OpenFileDialog()

        With WrkOpenFile

            .FileName = System.IO.Path.GetFileName(WrkFileName)
            If WrkFileName <> "" Then
                .InitialDirectory = System.IO.Path.GetDirectoryName(WrkFileName)
            End If
            .Filter = "すべてのファイル(*.*)|*.*"
            .FilterIndex = 1
            '.CheckFileExists = SetFileExists '存在しないファイルでもOK(ワイルドカード用)
            '.Multiselect = True

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