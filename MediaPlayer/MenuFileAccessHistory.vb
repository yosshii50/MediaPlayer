Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class MenuFileAccessHistory

    Private Const FileAccessHistoryAddStr As String = "FileAccessHistory" '履歴として追加されたメニューか判断する文字列

    '親イベント
    Delegate Sub MenuFileAccessHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private BaseMenuFileAccessHistory_Click As MenuFileAccessHistory_Click

    'インスタンス生成
    Public Sub New(ByVal WrkMenuFileAccessHistory_Click As MenuFileAccessHistory_Click, ByVal SetMaxCount As Integer)

        '親イベントの実行位置保持
        BaseMenuFileAccessHistory_Click = WrkMenuFileAccessHistory_Click

        '最大件数保持
        _MaxCount = SetMaxCount

    End Sub

    '履歴の最大件数
    Private _MaxCount As Integer
    Public ReadOnly Property MaxCount() As Integer
        Get
            Return _MaxCount
        End Get
        'Set(ByVal value As Integer)
        '    _MaxCount = value
        'End Set
    End Property
    Public Sub SetMaxCount(ByVal SetToolStripMenuItem As ToolStripMenuItem, ByVal value As Integer)
        _MaxCount = value

        '最大数を超えた場合削除
        Call AddToolStripMenuItem_MaxDelete(SetToolStripMenuItem, _MaxCount)

    End Sub

    '履歴の追加
    Public Sub AddHistory(ByVal SetToolStripMenuItem As ToolStripMenuItem, ByVal SetFileName As String)

        '履歴に追加
        Call AddToolStripMenuItem(SetToolStripMenuItem, SetFileName, False)

    End Sub

    '履歴情報セット/一括作成
    Public Sub SetHistory(ByVal SetToolStripMenuItem As ToolStripMenuItem, ByVal HistoryStr As String)

        '一度全部削除
        Call AddToolStripMenuItem_MaxDelete(SetToolStripMenuItem, 0)

        '文字列の内容を[改行]毎に追加
        For Each SetFileName As String In Split(HistoryStr, vbCrLf)

            '履歴に追加
            Call AddToolStripMenuItem(SetToolStripMenuItem, SetFileName, True)

        Next

    End Sub

    '履歴情報の呼び出し
    Public Function GetHistory(ByVal SetToolStripMenuItem As ToolStripMenuItem) As String

        Dim WrkStr As String = ""

        For Each WrkToolStripDropDownItem As ToolStripItem In SetToolStripMenuItem.DropDownItems
            If WrkToolStripDropDownItem.Name = FileAccessHistoryAddStr Then
                '履歴として追加されたメニューの場合

                WrkStr = WrkStr & WrkToolStripDropDownItem.Text & vbCrLf

            End If
        Next

        Return WrkStr
    End Function

    '履歴に追加
    Private Sub AddToolStripMenuItem(ByVal SetToolStripMenuItem As ToolStripMenuItem, ByVal SetFileName As String, ByVal IsAdd As Boolean)

        '空白の場合そのまま終了
        If SetFileName = "" Then
            Exit Sub
        End If

        '既に同じものが存在する場合

        'メニューへの追加位置取得
        Dim WrkDelPos As Integer
        For WrkDelPos = 0 To SetToolStripMenuItem.DropDownItems.Count - 1
            If SetToolStripMenuItem.DropDownItems(WrkDelPos).Name = FileAccessHistoryAddStr Then
                '追加された履歴の場合

                If SetToolStripMenuItem.DropDownItems(WrkDelPos).Text = SetFileName Then
                    '同じファイルの場合

                    Dim DelToolStripMenuItem As ToolStripMenuItem
                    DelToolStripMenuItem = DirectCast(SetToolStripMenuItem.DropDownItems(WrkDelPos), ToolStripMenuItem)

                    'その履歴を削除
                    RemoveHandler DelToolStripMenuItem.Click, AddressOf MenuLoadHistory_Click
                    SetToolStripMenuItem.DropDownItems.Remove(DelToolStripMenuItem)

                    Exit For
                End If

            End If
        Next

        '追加するメニュー
        Dim WrkToolStripMenuItem As ToolStripMenuItem
        WrkToolStripMenuItem = New ToolStripMenuItem(SetFileName, Nothing, Nothing, FileAccessHistoryAddStr)

        If IsAdd = False Then
            '先頭に追加する場合(通常)

            Dim WrkInsPos As Integer 'メニューへの追加位置

            'メニューへの追加位置取得
            For WrkInsPos = 0 To SetToolStripMenuItem.DropDownItems.Count - 1
                If SetToolStripMenuItem.DropDownItems(WrkInsPos).Name = FileAccessHistoryAddStr Then
                    '最初に見つけた履歴位置で終了
                    Exit For
                End If
            Next

            'メニューの追加位置に追加
            SetToolStripMenuItem.DropDownItems.Insert(WrkInsPos, WrkToolStripMenuItem)

        Else
            '末尾に追加する場合(一括作成時)

            'メニューの最後に追加
            SetToolStripMenuItem.DropDownItems.Add(WrkToolStripMenuItem)

        End If

        'イベントハンドルを設定
        AddHandler WrkToolStripMenuItem.Click, AddressOf MenuLoadHistory_Click

        '最大数を超えた部分を削除
        Call AddToolStripMenuItem_MaxDelete(SetToolStripMenuItem, _MaxCount)

    End Sub

    '指定件数を超えた部分を削除
    Private Sub AddToolStripMenuItem_MaxDelete(ByVal SetToolStripMenuItem As ToolStripMenuItem, ByVal WrkMaxCount As Integer)

        Dim WrkMaxPos As Integer
        Dim WrkHisCnt As Integer

        '削除対象のメニュー
        Dim DelToolStripMenuItem() As ToolStripMenuItem

        '削除対象のメニューをクリアしておく
        Erase DelToolStripMenuItem

        '削除対象を検索
        For WrkMaxPos = 0 To SetToolStripMenuItem.DropDownItems.Count - 1

            If SetToolStripMenuItem.DropDownItems(WrkMaxPos).Name = FileAccessHistoryAddStr Then
                '追加された履歴の場合

                WrkHisCnt = WrkHisCnt + 1

                If WrkHisCnt > WrkMaxCount Then
                    '最大を超えている場合

                    If DelToolStripMenuItem Is Nothing Then
                        ReDim DelToolStripMenuItem(0)
                    Else
                        ReDim Preserve DelToolStripMenuItem(DelToolStripMenuItem.Count)
                    End If

                    DelToolStripMenuItem(DelToolStripMenuItem.Count - 1) = DirectCast(SetToolStripMenuItem.DropDownItems(WrkMaxPos), ToolStripMenuItem)

                End If

            End If
        Next

        '削除対象が存在するか
        If Not DelToolStripMenuItem Is Nothing Then
            '削除対象が存在する場合

            '削除対象を全て削除
            For WrkMaxPos = 0 To DelToolStripMenuItem.Count - 1
                '履歴削除を実行

                'イベントハンドルを解除
                RemoveHandler DelToolStripMenuItem(WrkMaxPos).Click, AddressOf MenuLoadHistory_Click

                'メニューから削除
                SetToolStripMenuItem.DropDownItems.Remove(DelToolStripMenuItem(WrkMaxPos))

            Next

        End If

    End Sub

    '履歴のメニューから選択された時のイベント
    Private Sub MenuLoadHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '親イベントに処理を渡す
        Call BaseMenuFileAccessHistory_Click(sender, e)

    End Sub

End Class
