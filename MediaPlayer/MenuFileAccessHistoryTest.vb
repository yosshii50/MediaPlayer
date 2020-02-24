Public Class MenuFileAccessHistoryTest

    Private WrkMenuFileAccessHistory As New MenuFileAccessHistory(AddressOf MenuLoadHistory_Click, 3)

    '履歴選択時の処理
    Private Sub MenuLoadHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim WrkToolStripMenuItem As ToolStripMenuItem
        WrkToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        Call MsgBox(WrkToolStripMenuItem.Text & "/" & WrkToolStripMenuItem.Name)

        Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, WrkToolStripMenuItem.Text)

    End Sub

    '設定保存
    Private Sub MenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSave.Click

        Dim WrkStr As String = InputBox("設定保存")

        If WrkStr <> "" Then

            '履歴の追加
            Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, WrkStr)

        End If

    End Sub

    '設定読込/選択
    Private Sub MenuLoadSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuLoadSelect.Click

        Dim WrkStr As String = InputBox("設定読込/選択")

        If WrkStr <> "" Then

            '履歴の追加
            Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, WrkStr)

        End If

    End Sub

    '履歴読込
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call WrkMenuFileAccessHistory.SetHistory(MenuLoad, TextBox1.Text)
    End Sub

    '履歴保存
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = WrkMenuFileAccessHistory.GetHistory(MenuLoad)
    End Sub

    '最大値変更
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim WrkStr As String = InputBox("最大値変更", , WrkMenuFileAccessHistory.MaxCount)

        If WrkStr <> "" Then
            WrkMenuFileAccessHistory.SetMaxCount(MenuLoad, CInt(WrkStr))
        End If

    End Sub
End Class