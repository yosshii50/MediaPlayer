Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class Form1

    'メニューが表示されたとき
    Dim ContextMenuStripBaseControl As Control
    Private Sub ContextMenuStripPublic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStripPublic.Click

        Dim menu As ContextMenuStrip = DirectCast(sender, ContextMenuStrip)

        'メニューが起動された時の対象コントロールを保持
        ContextMenuStripBaseControl = DirectCast(menu.SourceControl, Control)

    End Sub

    '左右分割
    Private Sub MenuVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVertical.Click
        Call Separate(ContextMenuStripBaseControl, False)
    End Sub
    '上下分割
    Private Sub MenuHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuHorizontal.Click
        Call Separate(ContextMenuStripBaseControl, True)
    End Sub
    '画面分割
    Private Sub Separate(ByVal BaseControl As Control, ByVal IsHorizontal As Boolean)

        '新しいコンテナを追加
        Dim NewContainer As New MultiContainer(BaseControl.Parent, IsHorizontal)

        NewContainer.Panel1.Controls.Add(BaseControl)

        Dim BasePicBox As ViewSet = DirectCast(BaseControl, ViewSet)

        Dim WrkPicBox As New ViewSet
        WrkPicBox.ContextMenuStrip = ContextMenuStripPublic
        Call WrkPicBox.SettingCopy(BasePicBox)
        NewContainer.Panel2.Controls.Add(WrkPicBox)
        Call WrkPicBox.ReView()

    End Sub

    '削除
    Private Sub MenuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDelete.Click

        Dim DeleteSideSplitterPanel As SplitterPanel '削除側のパネル
        DeleteSideSplitterPanel = DirectCast(ContextMenuStripBaseControl.Parent, SplitterPanel)

        Dim DeleteContainer As MultiContainer
        DeleteContainer = DirectCast(DeleteSideSplitterPanel.Parent, MultiContainer)

        Dim BaseControl As Control
        BaseControl = DirectCast(DeleteContainer.Parent, Control)

        Call DeleteContainer.Delete(BaseControl, DeleteSideSplitterPanel)

    End Sub

    '設定画面
    Private Sub MenuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSettings.Click

        Dim ViewSet_Obj As ViewSet
        ViewSet_Obj = DirectCast(ContextMenuStripBaseControl, ViewSet)
        ViewSet_Obj.OpenSettingFormDirect()

    End Sub

End Class
