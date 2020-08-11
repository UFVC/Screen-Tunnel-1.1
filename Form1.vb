Imports System.ComponentModel

Public Class Form1
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        PictureBox1.Image = screenshot
        PictureBox1.Image = InvertGDI(PictureBox1.Image)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Application.Restart()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub
End Class
