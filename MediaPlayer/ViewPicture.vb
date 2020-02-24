﻿Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class ViewPicture
    Inherits PictureBox

    Private LoadImage As Bitmap '読み込んでいるイメージデータ

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

    Public Sub SizeChangedStart()
        AddHandler Me.SizeChanged, AddressOf PicBox_SizeChanged
    End Sub
    Public Sub SizeChangedStop()
        RemoveHandler Me.SizeChanged, AddressOf PicBox_SizeChanged
    End Sub

    Public Sub LoadFile(ByVal SetViewFileName As String)
        Call LoadFile(SetViewFileName, True)
    End Sub
    Public Sub LoadFile(ByVal SetViewFileName As String, ByVal IsAutoRefresh As Boolean)

        If SetViewFileName Is Nothing Then
            Exit Sub
        End If

        _NowFileName = SetViewFileName

        'Bitmapオブジェクトの作成
        LoadImage = New Bitmap(_NowFileName)

        Call ViewPix()

        If IsAutoRefresh = True Then
            Me.Refresh()
        End If

        Call SizeChangedStop()
        Call SizeChangedStart()
    End Sub

    Private Sub PicBox_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Call ViewPix()
    End Sub

    '画面に表示
    Private Sub ViewPix()
        Call ViewPix(Me, LoadImage)
    End Sub
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