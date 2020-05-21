Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class ViewPicture
    Inherits PictureBox

    Private LoadImage As Bitmap '読み込んでいるイメージデータ
    'Private PlayVLCCtl As New AxAXVLC.AxVLCPlugin2 'VLC再生
    Private PlayVLCCtl As New PictureBox  'VLC再生

    Public Sub New()
        'Me.BackColor = Color.Black
        Me.BackColor = Color.FromArgb(CInt(Rnd() * 255), CInt(Rnd() * 255), CInt(Rnd() * 255))
        Me.Dock = DockStyle.Fill
    End Sub

    '現在表示している画像のファイル名
    Private _NowFileName As String
    Public ReadOnly Property NowFileName() As String
        Get
            Return _NowFileName
        End Get
    End Property

    '現在表示している動画のファイル名
    Private _NowPlayFile As String
    Public ReadOnly Property NowPlayFile() As String
        Get
            Return _NowPlayFile
        End Get
    End Property

    Public Sub SizeChangedStart()
        AddHandler Me.SizeChanged, AddressOf PicBox_SizeChanged
    End Sub
    Public Sub SizeChangedStop()
        RemoveHandler Me.SizeChanged, AddressOf PicBox_SizeChanged
    End Sub

    '動画の再生
    Public Function PlayFile(ByVal SetPlsyFileName As String) As Boolean

        If SetPlsyFileName Is Nothing Then
            Return True
        End If

        _NowPlayFile = SetPlsyFileName

        PlayVLCCtl.ContextMenuStrip = Me.ContextMenuStrip
        PlayVLCCtl.Location = New Point(0, 0)
        Call PlayVLCResize(Me)

        'フォームに追加する
        Me.Controls.Add(PlayVLCCtl)

        'AxVLCPlugin2View.playlist.items.clear()
        'PlayVLCCtl.AutoLoop = True
        'PlayVLCCtl.playlist.add(New Uri(SetPlsyFileName).AbsoluteUri)
        'PlayVLCCtl.playlist.play()

        'Try
        '    LoadImage = New Bitmap(_NowPlayFile)
        'Catch ex As Exception
        '    Return False
        'End Try

        'Call ViewPix()

        Call SizeChangedStop()
        Call SizeChangedStart()

        Return True
    End Function

    Public Function LoadFile(ByVal SetViewFileName As String) As Boolean
        Return LoadFile(SetViewFileName, True)
    End Function
    Public Function LoadFile(ByVal SetViewFileName As String, ByVal IsAutoRefresh As Boolean) As Boolean

        If SetViewFileName Is Nothing Then
            Return True
        End If

        _NowFileName = SetViewFileName

        'Bitmapオブジェクトの作成
        Try
            LoadImage = New Bitmap(_NowFileName)
        Catch ex As Exception
            Return False
        End Try

        Call ViewPix(Me, LoadImage)

        If IsAutoRefresh = True Then
            Me.Refresh()
        End If

        Call SizeChangedStop()
        Call SizeChangedStart()

        Return True
    End Function

    Private Sub PicBox_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call ViewPix(Me, LoadImage)
        Call PlayVLCResize(Me)
    End Sub

    Private Sub PlayVLCResize(ByRef ParentPictureBox As PictureBox)

        '安全装置
        If ParentPictureBox.Width = 0 Then
            Exit Sub
        End If
        If ParentPictureBox.Height = 0 Then
            Exit Sub
        End If

        PlayVLCCtl.Width = ParentPictureBox.Width
        PlayVLCCtl.Height = ParentPictureBox.Height

    End Sub

    '画面に表示
    Private Sub ViewPix(ByRef ViewPictureBox As PictureBox, ByRef BaseImageBITMAP As Bitmap)

        Dim TmpBITMAP As Bitmap '描画用イメージデータ

        '安全装置
        If ViewPictureBox Is Nothing Then
            Exit Sub
        End If
        If BaseImageBITMAP Is Nothing Then
            Exit Sub
        End If
        If ViewPictureBox.Width = 0 Then
            Exit Sub
        End If
        If ViewPictureBox.Height = 0 Then
            Exit Sub
        End If

        '描画先とするImageオブジェクトを作成する
        'Dim canvas As New Bitmap(WrkPicBox.Width, WrkPicBox.Height)
        TmpBITMAP = New Bitmap(ViewPictureBox.Width, ViewPictureBox.Height)

        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(TmpBITMAP)

        '補間方法として高品質双三次補間を指定する
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        Dim WPos As ViewPosition
        WPos = GetPosition(BaseImageBITMAP.Width, BaseImageBITMAP.Height, TmpBITMAP.Width, TmpBITMAP.Height)

        '画像を縮小して描画する
        g.DrawImage(BaseImageBITMAP, WPos.x, WPos.y, WPos.width, WPos.height)

        g.Dispose()

        '表示する
        Dim OldBITMAP As Image
        OldBITMAP = ViewPictureBox.Image
        ViewPictureBox.Image = TmpBITMAP
        If Not OldBITMAP Is Nothing Then
            OldBITMAP.Dispose()
        End If

    End Sub

    Private Structure ViewPosition
        Dim x As Integer
        Dim y As Integer
        Dim width As Integer
        Dim height As Integer
    End Structure
    Private Function GetPosition(ByVal SizeSrcW As Integer, ByVal SizeSrcH As Integer, ByVal SizeDstW As Integer, ByVal SizeDstH As Integer) As ViewPosition

        Dim WrkPosition As ViewPosition
        Dim SizeRtiW As Integer = CInt(SizeSrcW * (SizeDstH / SizeSrcH))
        Dim SizeRtiH As Integer = CInt(SizeSrcH * (SizeDstW / SizeSrcW))

        If SizeRtiW > SizeDstW Then
            WrkPosition.x = 0
            WrkPosition.y = CInt((SizeDstH - SizeRtiH) / 2)
            WrkPosition.width = SizeDstW
            WrkPosition.height = SizeRtiH
        Else
            WrkPosition.x = CInt((SizeDstW - SizeRtiW) / 2)
            WrkPosition.y = 0
            WrkPosition.width = SizeRtiW
            WrkPosition.height = SizeDstH
        End If

        Return WrkPosition
    End Function
End Class
