Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Module MPSETSaveLoad

    Private LastSettingFileName As String

    Public Function Save() As String

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

                Return LastSettingFileName
            End If

        End With

        Return ""
    End Function

    Public Sub SaveMPSET(ByVal BaseControl As Control, ByVal WrkFileName As String)

        Dim SaveStr As String = ""

        SaveStr = SaveStr & "MainSizeWidth" & vbTab & BaseControl.Width & vbCrLf
        SaveStr = SaveStr & "MainSizeHeight" & vbTab & BaseControl.Height & vbCrLf
        SaveStr = SaveStr & SaveMPSETAll(BaseControl)

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
        Return "ViewSet" & vbTab & WrkViewSet.Setting_Obj.ViewTime _
                         & vbTab & WrkViewSet.Setting_Obj.FileName _
                         & vbTab & WrkViewSet.Setting_Obj.ViewType _
                         & vbTab & WrkViewSet.Setting_Obj.MovieName & vbCrLf
    End Function

    Delegate Function MenuNew_Clear_Dlg() As Control
    Delegate Function Separate_Dlg(ByVal BaseControl As Control, ByVal IsHorizontal As Boolean) As MultiContainer

    Public Function LoadSelect() As String

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

                Return LastSettingFileName
            End If

        End With

        Return ""
    End Function

    Public Sub LoadMPSET(ByVal WrkForm As Control, ByVal MenuNew_Clear As MenuNew_Clear_Dlg, ByVal Separate As Separate_Dlg, ByVal FileName As String)

        '現在の設定を削除
        Dim BaseControl As Control = MenuNew_Clear()

        If System.IO.File.Exists(FileName) = False Then
            MsgBox("設定ファイルが見つかりません。")
            Exit Sub
        End If

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
            SettingIdx = LoadMPSETCall(WrkForm, Separate, SettingList, SettingIdx, BaseControl)
        Next

    End Sub
    Private Function LoadMPSETCall(ByVal WrkForm As Control, ByVal Separate As Separate_Dlg, ByVal SettingList() As String, ByVal SettingIdx As Integer, ByVal BaseControl As Control) As Integer

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
                    SettingIdx = LoadMPSETCall(WrkForm, Separate, SettingList, SettingIdx + 1, WrkControl)
                    Exit For
                End If
            Next
            For Each WrkControl As Control In WrkMultiContainer.Panel2.Controls
                If TypeOf WrkControl Is ViewSet Then
                    SettingIdx = LoadMPSETCall(WrkForm, Separate, SettingList, SettingIdx + 1, WrkControl)
                    Exit For
                End If
            Next

        End If

        If SettingSingle(0) = "ViewSet" Then

            ReDim Preserve SettingSingle(4)

            Call LoadMPSETViewSet(BaseControl, SettingSingle(1), SettingSingle(2), SettingSingle(3), SettingSingle(4))

        End If

        If SettingSingle(0) = "MainSizeWidth" Then
            WrkForm.Width = CInt(SettingSingle(1))
        End If

        If SettingSingle(0) = "MainSizeHeight" Then
            WrkForm.Height = CInt(SettingSingle(1))
        End If

        Return SettingIdx
    End Function
    Private Sub LoadMPSETViewSet(ByVal BaseControl As Control, ByVal SetViewTime As String, ByVal SetFileName As String, ByVal SetViewType As String, ByVal SetMovieName As String)

        If TypeOf BaseControl Is ViewSet Then
            Dim WrkViewSet As ViewSet = DirectCast(BaseControl, ViewSet)

            WrkViewSet.Setting_Obj.FileName = SetFileName

            Dim WrkViewTime As Decimal
            WrkViewTime = CDec(SetViewTime)
            WrkViewSet.Setting_Obj.ViewTime = WrkViewTime

            If Setting_Cls.ViewType_Enum.Picture = CDbl(SetViewType) Then
                WrkViewSet.Setting_Obj.ViewType = Setting_Cls.ViewType_Enum.Picture
            ElseIf Setting_Cls.ViewType_Enum.Movie = CDbl(SetViewType) Then
                WrkViewSet.Setting_Obj.ViewType = Setting_Cls.ViewType_Enum.Movie
            End If

            WrkViewSet.Setting_Obj.MovieName = SetMovieName

            Call WrkViewSet.ReView()
        End If

    End Sub

End Module
