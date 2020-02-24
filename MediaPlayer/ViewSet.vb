Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class ViewSet
    Inherits ViewPicture

    Private IntervalNext_Obj As New IntervalNext_Cls
    Private Setting_Obj As New Setting_Cls

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

        Me.LoadFile(FileList(FileIdx))

        If FileList.Count - 1 = FileIdx Then
            FileIdx = 0
        Else
            FileIdx = FileIdx + 1
        End If

    End Sub




End Class
