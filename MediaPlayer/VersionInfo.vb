Public Class VersionInfo

    Public Function OpenFormDirect() As Boolean

        Me.Show()

        Return True
    End Function

    'バージョン情報表示
    Private Sub VersionInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim WrkStr As String = ""

        Dim ver As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)

        WrkStr = WrkStr & "MediaPlayer Ver-" & ver.ProductMajorPart & "." & ver.ProductMinorPart & "." & ver.ProductBuildPart & vbCrLf
        WrkStr = WrkStr & "" & vbCrLf
        WrkStr = WrkStr & "実行には VLC-2.2.5.1(x32) が必要です" & vbCrLf
        WrkStr = WrkStr & "" & vbCrLf
        WrkStr = WrkStr & ver.ToString

        Version.Text = WrkStr

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Form_Obj As New 画像表示のテスト
        Form_Obj.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Form_Obj As New ViewPictureTest
        Form_Obj.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Form_Obj As New MultiContainerTest
        Form_Obj.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Form_Obj As New MenuFileAccessHistoryTest
        Form_Obj.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Form_Obj As New IntervalNextTest
        Form_Obj.Show()
    End Sub
End Class