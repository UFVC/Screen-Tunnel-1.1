# Screen-Tunnel-1.1
This is a application that renders a infinite tunnel comprised of the contents on your screen, which also inverts in and out.
It's a bit slow but you can remove the "inverting" code section.

    -->Remove the following

<SNIPPET>

    
    Private Shared Function InvertGDI(ByVal imgSource As Image) _
         As Image
        Dim bmpDest As Bitmap = Nothing
        Using bmpSource As Bitmap = New Bitmap(imgSource)
            bmpDest = New Bitmap(bmpSource.Width, bmpSource.Height)

            For x As Integer = 0 To bmpSource.Width - 1

                For y As Integer = 0 To bmpSource.Height - 1
                    Dim clrPixel As Color = bmpSource.GetPixel(x, y)
                    clrPixel = Color.FromArgb(255 - clrPixel.R, 255 -
                  clrPixel.G, 255 - clrPixel.B)
                    bmpDest.SetPixel(x, y, clrPixel)
                Next
            Next
        End Using

        Return CType(bmpDest, Image)
    End Function
    ...
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ...
        PictureBox1.Image = InvertGDI(PictureBox1.Image)
    End Sub
    
