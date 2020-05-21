Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class Setting_Cls

    Enum ViewType_Enum
        Picture
        Movie
    End Enum
    Private _ViewType As ViewType_Enum
    Public Property ViewType() As ViewType_Enum
        Get
            Return _ViewType
        End Get
        Set(ByVal value As ViewType_Enum)
            _ViewType = value
        End Set
    End Property

    Private _FileName As String
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Private _ViewTime As Decimal
    Public Property ViewTime() As Decimal
        Get
            Return _ViewTime
        End Get
        Set(ByVal value As Decimal)
            _ViewTime = value
        End Set
    End Property

    Private _MovieName As String
    Public Property MovieName() As String
        Get
            Return _MovieName
        End Get
        Set(ByVal value As String)
            _MovieName = value
        End Set
    End Property

End Class
