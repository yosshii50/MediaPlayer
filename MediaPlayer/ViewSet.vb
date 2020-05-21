Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class ViewSet
    Inherits ViewPicture

    Private IntervalNext_Obj As New IntervalNext_Cls
    Public Setting_Obj As New Setting_Cls

    Public Sub SettingCopy(ByVal BaseViewSet As ViewSet)
        Me.Setting_Obj.FileName = BaseViewSet.Setting_Obj.FileName
        Me.Setting_Obj.ViewTime = BaseViewSet.Setting_Obj.ViewTime
    End Sub

    Public Sub OpenSettingFormDirect()

        Dim SettingForm_Obj As New SettingForm

        Dim RetCode As Boolean = SettingForm_Obj.OpenSettingFormDirect(Setting_Obj)

        If RetCode = True Then

            Me.ReView()

        End If

    End Sub

    Private FileList() As String
    Private FileIdx As Integer

    Public Sub ReView()

        Erase FileList

        If Not Setting_Obj.FileName Is Nothing Then
            FileList = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(Setting_Obj.FileName), System.IO.Path.GetFileName(Setting_Obj.FileName), System.IO.SearchOption.AllDirectories)
        End If

        FileIdx = 0
        Call ExecSub()
        IntervalNext_Obj.StartInt(Setting_Obj.ViewTime, AddressOf ExecSub)

    End Sub

    Private Sub ExecSub()

        If FileList Is Nothing Then
            Exit Sub
        End If

        Dim RetCode As Boolean
        RetCode = Me.LoadFile(FileList(FileIdx))

        If FileList.Count - 1 = FileIdx Then
            '最後の画像を表示した場合

            '最初に戻る
            FileIdx = 0

        Else

            '次の画像を表示
            FileIdx = FileIdx + 1

        End If

        If RetCode = False Then
            '画像の表示でエラーが発生した場合

            If FileList.Count > 1 Then
                '表示する画像が２個以上ある場合

                '次の画像を表示
                Call ExecSub()

            End If

        End If

    End Sub



End Class
