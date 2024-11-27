Imports System.Runtime.InteropServices

Public Class Form1
    Dim canvas As Bitmap
    Dim g, gFinal As Graphics
    Dim playerX, playerY As Integer

    Dim jumping As Boolean 'True if mid-jump, false if not jumping
    Dim jumpmove As Integer 'Used to control jump speed
    Dim jumpheight As Integer 'max height of jump

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        canvas = New Bitmap(Me.Width, Me.Height)
        g = Graphics.FromImage(canvas)
        gFinal = Me.CreateGraphics

        playerX = 100
        playerY = getHeight() - 25 '25 is the height of the player
        jumpheight = 15 'set initial jump height

        GameTimer.Start()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'if the space bar is pressed and the character is not already jumping
        If e.KeyChar = " " And jumping = False Then
            jumping = True 'set jumping to true so we can't double jump
            jumpmove = jumpheight 'set the initial jump speed
        End If
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        'Draw background (could be image)
        g.Clear(Color.Black)

        'jump 
        If jumping = True Then
            playerY = playerY - jumpmove 'move the character
            jumpmove = jumpmove - 1 'reduce the speed (will move back down when negative)
        End If

        'Check for ground collision
        If playerY >= getHeight() - 25 Then
            playerY = getHeight() - 25 '25 is the height of the player
            jumping = False
        End If


        'draw player (could be image)
        g.FillRectangle(Brushes.White, playerX, playerY, 25, 25)

        'draw canvas on the form
        gFinal.DrawImage(canvas, 0, 0)

    End Sub


    Function getWidth() As Integer
        'Returns the usable width of the form
        Return Me.ClientSize.Width
    End Function

    Function getHeight() As Integer
        'Returns the usable height of the form
        Return Me.ClientSize.Height
    End Function
End Class
