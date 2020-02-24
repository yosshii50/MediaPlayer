Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class Form1

    Private Const DefaultSplitterWidth As Integer = 10
    Private WrkMenuFileAccessHistory As New MenuFileAccessHistory(AddressOf MenuLoadHistory_Click, 30)

    '画面読込時
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'ファイルアクセスログの読込
        Call FileLogLoad()

    End Sub

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
    Private Function Separate(ByVal BaseControl As Control, ByVal IsHorizontal As Boolean) As MultiContainer

        '新しいコンテナを追加
        Dim NewContainer As New MultiContainer(BaseControl.Parent, IsHorizontal)
        Call MenuSpChangeSingle(NewContainer)

        NewContainer.Panel1.Controls.Add(BaseControl)

        Dim BasePicBox As ViewSet = DirectCast(BaseControl, ViewSet)

        Dim WrkPicBox As New ViewSet
        WrkPicBox.ContextMenuStrip = ContextMenuStripPublic
        Call WrkPicBox.SettingCopy(BasePicBox)
        NewContainer.Panel2.Controls.Add(WrkPicBox)
        Call WrkPicBox.ReView()

        Return NewContainer
    End Function

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

    '最大表示
    Private Sub MenuMaxView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMaxView.Click

        MenuMaxView.Checked = Not MenuMaxView.Checked
        If MenuMaxView.Checked = True Then
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub

    '区切線表示
    Private Sub MenuSp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSp.Click

        MenuSp.Checked = Not MenuSp.Checked
        Call MenuSpChangeAll(Me)

    End Sub
    Private Sub MenuSpChangeAll(ByVal BaseControl As Control)

        For Each WrkControl As Control In BaseControl.Controls

            'Debug.WriteLine(TypeName(WrkControl))

            If TypeOf WrkControl Is MultiContainer Then
                Call MenuSpChangeSingle(DirectCast(WrkControl, MultiContainer))
            End If

            If TypeOf WrkControl Is SplitterPanel _
            Or TypeOf WrkControl Is MultiContainer Then

                '再帰的呼び出し
                Call MenuSpChangeAll(WrkControl)

            End If

        Next
    End Sub
    Private Sub MenuSpChangeSingle(ByVal WrkMultiContainer As MultiContainer)
        If MenuSp.Checked = True Then
            WrkMultiContainer.SplitterWidth = DefaultSplitterWidth
        Else
            WrkMultiContainer.SplitterWidth = 1
        End If
    End Sub

    '設定保存
    Private LastSettingFileName As String
    Private Sub MenuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSave.Click

        'ファイル保存のダイアログ
        With New SaveFileDialog()

            .FileName = System.IO.Path.GetFileName(LastSettingFileName)
            If LastSettingFileName <> "" Then
                .InitialDirectory = System.IO.Path.GetDirectoryName(LastSettingFileName)
            End If
            .Filter = "設定ファイル(*.mpset)|*.mpset|すべてのファイル(*.*)|*.*"
            .FilterIndex = 1
            '.Title = "開くファイルを選択してください"
            ''ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            'ofd.RestoreDirectory = True

            'ダイアログを表示する
            If .ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名を表示する

                LastSettingFileName = .FileName

                '履歴の追加
                Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, LastSettingFileName)

                'メニューの履歴を保存
                Call FileLogSave()

                '設定情報を保存
                Call SaveMPSET(LastSettingFileName)

            End If

        End With

    End Sub
    Private Sub SaveMPSET(ByVal WrkFileName As String)

        Dim SaveStr As String = ""

        SaveStr = SaveStr & "MainSizeWidth" & vbTab & Me.Width & vbCrLf
        SaveStr = SaveStr & "MainSizeHeight" & vbTab & Me.Height & vbCrLf
        SaveStr = SaveStr & SaveMPSETAll(Me)

        Dim WrkStreamWriter As System.IO.StreamWriter

        Try
            WrkStreamWriter = New System.IO.StreamWriter(WrkFileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
            WrkStreamWriter.WriteLine(SaveStr)
            WrkStreamWriter.Close()
        Catch ex As System.IO.FileNotFoundException
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("設定保存に失敗しました。")
        End Try

    End Sub
    Private Function SaveMPSETAll(ByVal BaseControl As Control) As String

        Dim SaveStr As String = ""

        For Each WrkControl As Control In BaseControl.Controls

            'Debug.WriteLine(TypeName(WrkControl))

            If TypeOf WrkControl Is ViewSet Then
                SaveStr = SaveStr & SaveMPSETSingle(DirectCast(WrkControl, ViewSet))
            End If

            If TypeOf WrkControl Is SplitterPanel _
            Or TypeOf WrkControl Is MultiContainer Then

                If TypeOf WrkControl Is MultiContainer Then

                    Dim WrkMultiContainer As MultiContainer = DirectCast(WrkControl, MultiContainer)

                    SaveStr = SaveStr & "MultiContainer" & vbTab
                    If WrkMultiContainer.Orientation = Orientation.Vertical Then
                        SaveStr = SaveStr & "Vertical" & vbTab
                    Else
                        SaveStr = SaveStr & "Horizontal" & vbTab
                    End If
                    SaveStr = SaveStr & WrkMultiContainer.SplitterDistance & vbCrLf

                End If

                '再帰的呼び出し
                SaveStr = SaveStr & SaveMPSETAll(WrkControl)

            End If

        Next

        Return SaveStr
    End Function
    Private Function SaveMPSETSingle(ByVal WrkViewSet As ViewSet) As String
        Return "ViewSet" & vbTab & WrkViewSet.Setting_Obj.ViewTime & vbTab & WrkViewSet.Setting_Obj.FileName & vbCrLf
    End Function

    '設定読込/ファイル選択
    Private Sub MenuLoadSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuLoadSelect.Click

        'ファイル読込のダイアログ
        With New OpenFileDialog()

            .FileName = System.IO.Path.GetFileName(LastSettingFileName)
            If LastSettingFileName <> "" Then
                .InitialDirectory = System.IO.Path.GetDirectoryName(LastSettingFileName)
            End If
            .Filter = "設定ファイル(*.mpset)|*.mpset|すべてのファイル(*.*)|*.*"
            .FilterIndex = 1
            '.Title = "開くファイルを選択してください"
            ''ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            'ofd.RestoreDirectory = True

            'ダイアログを表示する
            If .ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき、選択されたファイル名を表示する

                LastSettingFileName = .FileName

                '履歴の追加
                Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, LastSettingFileName)

                Call LoadMPSET(LastSettingFileName)

            End If

        End With

    End Sub
    '履歴選択時の処理
    Private Sub MenuLoadHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim WrkToolStripMenuItem As ToolStripMenuItem
        WrkToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        Call WrkMenuFileAccessHistory.AddHistory(MenuLoad, WrkToolStripMenuItem.Text)

        Call LoadMPSET(WrkToolStripMenuItem.Text)

    End Sub
    Private Sub LoadMPSET(ByVal FileName As String)

        '現在の設定を削除
        Dim BaseControl As Control = MenuNew_Clear(Me, Me)

        '設定読込
        Dim WrkStr As String = ""
        Try
            WrkStr = System.IO.File.ReadAllText(FileName, System.Text.Encoding.GetEncoding("Shift_JIS"))
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("設定読込に失敗しました。")
            Exit Sub
        End Try

        Dim SettingList() As String = Split(WrkStr, vbCrLf)
        For SettingIdx As Integer = 0 To SettingList.Count - 1
            SettingIdx = LoadMPSETCall(SettingList, SettingIdx, BaseControl)
        Next

    End Sub
    Private Function LoadMPSETCall(ByVal SettingList() As String, ByVal SettingIdx As Integer, ByVal BaseControl As Control) As Integer

        If SettingList(SettingIdx) = "" Then
            Return SettingIdx
        End If

        Dim SettingSingle() As String = Split(SettingList(SettingIdx), vbTab)

        If SettingSingle(0) = "MultiContainer" Then

            Dim WrkMultiContainer As MultiContainer

            If SettingSingle(1) = "Horizontal" Then
                WrkMultiContainer = Separate(BaseControl, True)
            Else
                WrkMultiContainer = Separate(BaseControl, False)
            End If

            WrkMultiContainer.SplitterDistance = CInt(SettingSingle(2))

            For Each WrkControl As Control In WrkMultiContainer.Panel1.Controls
                If TypeOf WrkControl Is ViewSet Then
                    SettingIdx = LoadMPSETCall(SettingList, SettingIdx + 1, WrkControl)
                    Exit For
                End If
            Next
            For Each WrkControl As Control In WrkMultiContainer.Panel2.Controls
                If TypeOf WrkControl Is ViewSet Then
                    SettingIdx = LoadMPSETCall(SettingList, SettingIdx + 1, WrkControl)
                    Exit For
                End If
            Next

        End If

        If SettingSingle(0) = "ViewSet" Then

            Call LoadMPSETViewSet(BaseControl, SettingSingle(1), SettingSingle(2))

        End If

        If SettingSingle(0) = "MainSizeWidth" Then
            Me.Width = CInt(SettingSingle(1))
        End If

        If SettingSingle(0) = "MainSizeHeight" Then
            Me.Height = CInt(SettingSingle(1))
        End If

        Return SettingIdx
    End Function
    Private Sub LoadMPSETViewSet(ByVal BaseControl As Control, ByVal SetViewTime As String, ByVal SetFileName As String)

        If TypeOf BaseControl Is ViewSet Then
            Dim WrkViewSet As ViewSet = DirectCast(BaseControl, ViewSet)

            WrkViewSet.Setting_Obj.FileName = SetFileName

            Dim WrkViewTime As Integer
            WrkViewTime = CInt(SetViewTime)
            WrkViewSet.Setting_Obj.ViewTime = WrkViewTime

            Call WrkViewSet.ReView()
        End If

    End Sub

    'ファイル履歴の書込
    Private Sub FileLogSave()

        Dim WrkStreamWriter As System.IO.StreamWriter
        Dim WrkFileName As String = FileLoadLogFileName()

        'ファイルアクセスログ取得
        Dim WrkStr As String

        WrkStr = WrkMenuFileAccessHistory.GetHistory(MenuLoad)

        Try
            WrkStreamWriter = New System.IO.StreamWriter(WrkFileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
            WrkStreamWriter.WriteLine(WrkStr)
            WrkStreamWriter.Close()
        Catch ex As System.IO.FileNotFoundException
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("履歴書込に失敗しました。")
            Exit Sub
        End Try

    End Sub

    'ファイル履歴の読込
    Private Sub FileLogLoad()

        'ファイルアクセスログ取得
        Dim WrkStr As String = ""
        Try
            WrkStr = System.IO.File.ReadAllText(FileLoadLogFileName(), System.Text.Encoding.GetEncoding("Shift_JIS"))
        Catch ex As System.IO.FileNotFoundException
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("履歴読込に失敗しました。")
            Exit Sub
        End Try

        '履歴情報セット/一括作成
        Call WrkMenuFileAccessHistory.SetHistory(MenuLoad, WrkStr)
        
    End Sub

    'ファイルアクセスログのファイル名取得
    Private Function FileLoadLogFileName() As String

        '実行パス取得
        Dim WrkExeName As String
        WrkExeName = System.Reflection.Assembly.GetExecutingAssembly().Location
        WrkExeName = System.IO.Path.GetFileNameWithoutExtension(WrkExeName)

        Return WrkExeName & ".conf.txt"
    End Function

    '新規
    Private Sub MenuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuNew.Click

        '現在の設定を削除
        Call MenuNew_Clear(Me, Me)

    End Sub
    Private Function MenuNew_Clear(ByVal RootControl As Control, ByVal BaseControl As Control) As Control

        For Each WrkControl As Control In BaseControl.Controls

            'Debug.WriteLine(TypeName(WrkControl))

            If TypeOf WrkControl Is ViewSet Then
                RootControl.Controls.Add(WrkControl)
                Return WrkControl
            End If

            If TypeOf WrkControl Is SplitterPanel _
            Or TypeOf WrkControl Is MultiContainer Then

                '再帰的呼び出し
                Dim RetControl As Control = MenuNew_Clear(RootControl, WrkControl)

                If TypeOf WrkControl Is MultiContainer Then
                    WrkControl.Dispose()
                End If

                Return RetControl
            End If

        Next

        Return Nothing
    End Function

    '終了
    Private Sub MenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExit.Click
        Me.Dispose()
    End Sub
End Class
