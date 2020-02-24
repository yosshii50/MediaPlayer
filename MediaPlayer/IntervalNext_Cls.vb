Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class IntervalNext_Cls

    Dim WithEvents IntTimer As New Timer

    Public Sub StartInt(ByVal SetInterval As Decimal, ByVal RunSub As TickSub)

        If SetInterval = 0 Then
            Call StopInt()
            Exit Sub
        End If

        SetSub = RunSub
        IntTimer.Interval = CInt(SetInterval * 1000)
        IntTimer.Enabled = True
    End Sub

    Public Sub StopInt()
        IntTimer.Enabled = False
    End Sub

    Delegate Sub TickSub()
    Private SetSub As TickSub

    Private Sub IntTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles IntTimer.Tick
        Call SetSub()
    End Sub

End Class
