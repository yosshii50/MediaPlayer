Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class Setting_Cls

    Private _FileName As String
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Private _ViewTime As Integer
    Public Property ViewTime() As Integer
        Get
            Return _ViewTime
        End Get
        Set(ByVal value As Integer)
            _ViewTime = value
        End Set
    End Property

End Class
