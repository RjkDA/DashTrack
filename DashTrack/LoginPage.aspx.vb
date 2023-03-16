Imports System.Data
Imports System.Data.SqlClient
Public Class Login_Page
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=DESKTOP-KHH66AM\SQLEXPRESS;Database=DashTrack;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim email, pw As String

        email = TextBox1.Text
        pw = TextBox2.Text

        Dim cmdUN As New SqlCommand("Select Email, Password, UserID from InfoTable Where Email = @p1 and Password = @p2", con)

        With cmdUN.Parameters
            .Clear()
            .AddWithValue("@p1", email)
            .AddWithValue("@p2", pw)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim dr As SqlDataReader = cmdUN.ExecuteReader()
            Dim dt As DataTable = New DataTable()
            dt.Load(dr)
            If dt.Rows.Count() = 1 Then
                Response.Write("Access Granted")
                System.Web.HttpContext.Current.Session("Email") = email
                System.Web.HttpContext.Current.Session("UserID") = dt.Rows(0)("UserID")
                Response.Redirect("MainPage.aspx")
            Else
                MsgBox("Incorrect Username or Password", vbExclamation, "Error")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Register.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("ForgotPassword.aspx")
    End Sub

    Private Sub Login_Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        TextBox2.TextMode = TextBoxMode.Password
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class