Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class MultiContainer
    Inherits SplitContainer

    Public Sub New(ByVal WrkBaseContainer As Control, ByVal IsHorizontal As Boolean)

        Me.BackColor = Color.Black
        Me.Dock = DockStyle.Fill
        If IsHorizontal = True Then
            Me.Orientation = Orientation.Horizontal
        End If
        Me.Panel1.BackColor = Color.FromArgb(CInt(Rnd() * 255), CInt(Rnd() * 255), CInt(Rnd() * 255))
        Me.Panel2.BackColor = Color.FromArgb(CInt(Rnd() * 255), CInt(Rnd() * 255), CInt(Rnd() * 255))
        If Me.Orientation = Orientation.Horizontal Then
            Me.SplitterDistance = Me.Height \ 2
        Else
            Me.SplitterDistance = Me.Width \ 2
        End If

        WrkBaseContainer.Controls.Add(Me)

    End Sub

    Public Sub Delete(ByVal BaseControl As Control, ByVal DeleteSideSplitterPanel As SplitterPanel)

        '削除側でないパネルを保持側とする
        Dim RetentionSideSplitterPanel As SplitterPanel '保持側のパネル
        If Me.Panel1 Is DeleteSideSplitterPanel Then
            RetentionSideSplitterPanel = Me.Panel2
        Else
            RetentionSideSplitterPanel = Me.Panel1
        End If

        '保持側のコントロールを親コントロールに移動
        For Each WrkCont As Control In RetentionSideSplitterPanel.Controls
            BaseControl.Controls.Add(WrkCont)
        Next

        '自分自身を削除
        Me.Dispose()
        '↑削除側パネルもまとめて削除される

    End Sub

    Public Function Panel1_Separate(ByVal IsHorizontal As Boolean) As MultiContainer
        Dim NewContainer As New MultiContainer(Me.Panel1, IsHorizontal)
        Return NewContainer
    End Function
    Public Function Panel2_Separate(ByVal IsHorizontal As Boolean) As MultiContainer
        Dim NewContainer As New MultiContainer(Me.Panel2, IsHorizontal)
        Return NewContainer
    End Function

End Class
