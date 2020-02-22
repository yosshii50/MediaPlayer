Public Class MultiContainerTest

    'メニューが表示されたとき
    Dim ContextMenuStripBaseControl As Control
    Private Sub ContextMenuStripPublic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStripPublic.Click

        Dim menu As ContextMenuStrip = DirectCast(sender, ContextMenuStrip)

        'メニューが起動された時の対象コントロールを保持
        ContextMenuStripBaseControl = DirectCast(menu.SourceControl, Control)

    End Sub

    Private Sub 左右分割ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 左右分割ToolStripMenuItem.Click
        Call Separate(ContextMenuStripBaseControl, False)
    End Sub
    Private Sub 上下分割ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上下分割ToolStripMenuItem.Click
        Call Separate(ContextMenuStripBaseControl, True)
    End Sub
    Private Sub Separate(ByVal BaseControl As Control, ByVal IsHorizontal As Boolean)

        '新しいコンテナを追加
        Dim NewContainer As New MultiContainer(BaseControl.Parent, IsHorizontal)

        NewContainer.Panel1.Controls.Add(BaseControl)

        Dim WrkPicBox As New PictureBox
        WrkPicBox.Dock = DockStyle.Fill
        WrkPicBox.ContextMenuStrip = ContextMenuStripPublic
        WrkPicBox.BackColor = Color.FromArgb(Rnd() * 255, Rnd() * 255, Rnd() * 255)
        NewContainer.Panel2.Controls.Add(WrkPicBox)

    End Sub


    Private Sub 削除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 削除ToolStripMenuItem.Click

        Dim DeleteSideSplitterPanel As SplitterPanel '削除側のパネル
        DeleteSideSplitterPanel = DirectCast(ContextMenuStripBaseControl.Parent, SplitterPanel)

        Dim DeleteContainer As MultiContainer
        DeleteContainer = DirectCast(DeleteSideSplitterPanel.Parent, MultiContainer)

        Dim BaseControl As Control
        BaseControl = DirectCast(DeleteContainer.Parent, Control)

        'Call DeleteSplitterPanel(DeleteContainer, BaseControl, DeleteSideSplitterPanel)
        Call DeleteContainer.Delete(BaseControl, DeleteSideSplitterPanel)

    End Sub

    'Private Sub DeleteSplitterPanel(ByVal DeleteContainer As MultiContainer, ByVal BaseControl As Control, ByVal DeleteSideSplitterPanel As SplitterPanel)
    '
    '    Dim RetentionSideSplitterPanel As SplitterPanel '保持側のパネル
    '    If DeleteContainer.Panel1 Is DeleteSideSplitterPanel Then
    '        RetentionSideSplitterPanel = DeleteContainer.Panel2
    '    Else
    '        RetentionSideSplitterPanel = DeleteContainer.Panel1
    '    End If
    '
    '    For Each WrkCont As Control In RetentionSideSplitterPanel.Controls
    '        BaseControl.Controls.Add(WrkCont)
    '    Next
    '    DeleteContainer.Dispose()
    '
    'End Sub


End Class