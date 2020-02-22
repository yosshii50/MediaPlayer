Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class IntervalNextTest

    Dim WrkIntervalNext As New IntervalNext_Cls

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        WrkIntervalNext.StartInt(CInt(TextBox1.Text), AddressOf ExecSub)

    End Sub

    Private Sub ExecSub()

        'Debug.WriteLine(Now.ToString)
        PictureBox1.BackColor = Color.FromArgb(CInt(Rnd() * 255), CInt(Rnd() * 255), CInt(Rnd() * 255))

    End Sub

End Class