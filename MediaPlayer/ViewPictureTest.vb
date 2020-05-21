Public Class ViewPictureTest

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0005.jpg")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0006.jpg")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0006.jpg")
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0007.jpg")
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0008.jpg")
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0009.jpg")
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0010.jpg")
        ViewPicture1.LoadFile("D:\!Delete\2020-01-19 Scan\2020-01-11\DOC200119-20200119181104\Page0011.jpg")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        ''Buttonクラスのインスタンスを作成する
        'Dim AxVLCPlugin2View As AxAXVLC.AxVLCPlugin2 = New AxAXVLC.AxVLCPlugin2
        '
        'AxVLCPlugin2View.Location = New Point(0, 0)
        'AxVLCPlugin2View.Size = New System.Drawing.Size(ViewPicture1.Width, ViewPicture1.Height)
        '
        ''フォームに追加する
        'ViewPicture1.Controls.Add(AxVLCPlugin2View)
        '
        ''AxVLCPlugin2View.playlist.items.clear()
        'AxVLCPlugin2View.AutoLoop = True
        'AxVLCPlugin2View.playlist.add(New Uri("D:\!Delete\SAMPLE\MOV.mp4").AbsoluteUri)
        'AxVLCPlugin2View.playlist.play()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ViewPicture1.PlayFile("D:\!Delete\SAMPLE\MOV.mp4")
    End Sub
End Class