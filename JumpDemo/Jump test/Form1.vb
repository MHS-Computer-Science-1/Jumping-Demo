Public Class Form1
    Dim canvas As Bitmap
    Dim canvaspen, formpen As Graphics
    Dim playerX, playerY As Integer

    Dim jumping As Boolean 'True if mid-jump, false if not jumping
    Dim jumpmove As Integer 'Used to control jump speed
    Dim jumpheight As Integer 'max height of jump

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        canvas = New Bitmap(Me.Width, Me.Height)
        canvaspen = Graphics.FromImage(canvas)
        formpen = Me.CreateGraphics

        playerX = 100
        playerY = Me.Height - 100
        jumpheight = 12 'set initial jump height

        Timer1.Start()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'if the space bar is pressed and the character is not already jumping
        If e.KeyChar = " " And jumping = False Then
            jumping = True 'set jumping to true so we can't double jump
            jumpmove = jumpheight 'set the initial jump speed
        End If
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Draw background (could be image)
        canvaspen.Clear(Color.Black)

        'jump 
        If jumping = True Then
            playerY = playerY - jumpmove 'move the character
            jumpmove = jumpmove - 1 'reduce the speed (will move back down when negative)
            'if the character has come back down
            If jumpmove = -1 * jumpheight - 1 Then
                jumping = False 'stop jump, can jump again
            End If
        End If


        'draw player (could be image)
        canvaspen.FillRectangle(Brushes.White, playerX, playerY, 25, 25)

        'draw canvas on the form
        formpen.DrawImage(canvas, 0, 0)

    End Sub
End Class
