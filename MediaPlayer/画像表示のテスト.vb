Option Explicit On '型宣言を強制
Option Strict On 'タイプ変換を厳密に

Public Class 画像表示のテスト

    'Private WithEvents PicBox As New PictureBox
    'Private PicBox As New PictureBox

    Private Sub 画像表示のテスト_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'PicBox.BackColor = Color.Black
        'PicBox.Dock = DockStyle.Fill
        'Me.Controls.Add(PicBox)


        'LoadImage = New Bitmap("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0005.jpg")

        Dim WrkVPicture As New ViewPicture()
        Me.Controls.Add(WrkVPicture)


        WrkVPicture.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0005.jpg")

        'Call ViewPix(PicBox, LoadImage, WorkImage)
    End Sub

End Class