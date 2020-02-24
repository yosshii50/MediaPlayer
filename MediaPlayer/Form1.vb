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
    Private Sub Separate(ByVal BaseControl As Control, ByVal IsHorizontal As Boolean)

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

        Debug.WriteLine("--------------------")
        Call SaveMPSET(LastSettingFileName)
        Exit Sub

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
    Private Sub SaveMPSET(ByVal FileName As String)

        Dim SaveStr As String
        SaveStr = SaveMPSETAll(Me)

        MsgBox(FileName & vbCrLf & SaveStr)

    End Sub
    Private Function SaveMPSETAll(ByVal BaseControl As Control) As String

        Dim SaveStr As String = ""

        For Each WrkControl As Control In BaseControl.Controls

            Debug.WriteLine(TypeName(WrkControl))

            If TypeOf WrkControl Is ViewPicture Then
                SaveStr = SaveStr & SaveMPSETSingle(DirectCast(WrkControl, ViewPicture))
            End If

            If TypeOf WrkControl Is SplitterPanel _
            Or TypeOf WrkControl Is MultiContainer Then

                '再帰的呼び出し
                SaveStr = SaveStr & SaveMPSETAll(WrkControl)

            End If

        Next

        Return SaveStr
    End Function
    Private Function SaveMPSETSingle(ByVal WrkViewPicture As ViewPicture) As String




        Return WrkViewPicture.NowFileName & vbCrLf
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

        MsgBox(FileName)

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
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("履歴読込に失敗しました。")
        End Try

    End Sub

    'ファイル履歴の読込
    Private Sub FileLogLoad()

        'ファイルアクセスログ取得
        Dim LoadEnable As Boolean = False
        Dim WrkStr As String = ""
        Try
            WrkStr = System.IO.File.ReadAllText(FileLoadLogFileName(), System.Text.Encoding.GetEncoding("Shift_JIS"))
            LoadEnable = True
        Catch ex As System.IO.FileNotFoundException
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("履歴読込に失敗しました。")
        End Try

        If LoadEnable = True Then
            Call WrkMenuFileAccessHistory.SetHistory(MenuLoad, WrkStr)
        End If

    End Sub

    'ファイルアクセスログのファイル名取得
    Private Function FileLoadLogFileName() As String

        '実行パス取得
        Dim WrkExeName As String
        WrkExeName = System.Reflection.Assembly.GetExecutingAssembly().Location
        WrkExeName = System.IO.Path.GetFileNameWithoutExtension(WrkExeName)

        Return WrkExeName & ".conf.txt"
    End Function

    '終了
    Private Sub MenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExit.Click
        Me.Dispose()
    End Sub

End Class
