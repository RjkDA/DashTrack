Imports System.Data
Imports System.Data.SqlClient
Public Class Forgot_Password
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=DESKTOP-KHH66AM\SQLEXPRESS;Database=DashTrack;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox2.Text <> TextBox3.Text Then
            MsgBox("Passwords Must Match")
            Return
        End If

        Dim cmdUpdate As New SqlCommand("Update InfoTable Set Password = @p2 Where Email = @p1", con)

        With cmdUpdate.Parameters
            .Clear()
            .AddWithValue("@p1", TextBox1.Text)
            .AddWithValue("@p2", TextBox2.Text)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim RowsAffected As Integer = cmdUpdate.ExecuteNonQuery()
            If RowsAffected = 1 Then
                Response.Write("Customer Data Updated")
                Response.Redirect("LoginPage.aspx")
            Else
                Response.Write("Password Not Changed")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("LoginPage.aspx")
    End Sub

    Private Sub Forgot_Password_Init(sender As Object, e As EventArgs) Handles Me.Init
        TextBox2.TextMode = TextBoxMode.Password
        TextBox3.TextMode = TextBoxMode.Password
    End Sub
End Class