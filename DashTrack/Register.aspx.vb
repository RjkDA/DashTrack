Imports System.Data
Imports System.Data.SqlClient
Public Class Register
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=DESKTOP-KHH66AM\SQLEXPRESS;Database=DashTrack;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name, UN, PW, Email, Phone, Q, A As String

        Dim capital, small, specialChar, number As Boolean

        name = TextBox1.Text
        UN = TextBox2.Text
        PW = TextBox3.Text
        Email = TextBox4.Text
        Phone = TextBox5.Text
        Q = DropDownList1.SelectedValue
        A = TextBox6.Text

        For i As Integer = 0 To PW.Count - 1
            If Asc(PW(i)) >= 65 And Asc(PW(i)) <= 90 Then
                capital = True

            ElseIf Asc(PW(i)) >= 97 And Asc(PW(i)) <= 122 Then
                small = True
            ElseIf IsNumeric(PW(i)) = True Then
                number = True
            Else
                specialChar = True
            End If
        Next

        If PW.Count < 8 Or number = False Or capital = False Or small = False Or specialChar = False Then
            MsgBox("Password should be at least 8 characters long and must have at least one capital letter, one small letter, a number, and one special character", vbExclamation, "Error")
            Exit Sub
        End If

        Dim cmdInsert As New SqlCommand("Insert Into InfoTable (Name, UserName, Password, Email, Phone, SecurityQ, SecurityA) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", con)

        With cmdInsert.Parameters
            .Clear()
            .AddWithValue("@p1", name)
            .AddWithValue("@p2", UN)
            .AddWithValue("@p3", PW)
            .AddWithValue("@p4", Email)
            .AddWithValue("@p5", Phone)
            .AddWithValue("@p6", Q)
            .AddWithValue("@p7", A)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdInsert.ExecuteNonQuery()
            Response.Write("User Added")

        Catch ex As Exception
            If ex.Message.Contains("Cannot insert duplicate key in object") Then
                MsgBox("User Name taken, please try again", vbExclamation, "Error")
            Else
                Response.Write(ex.Message)
            End If

        Finally
            con.Close()
        End Try

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click

        Response.Redirect("LoginPage.Aspx")

    End Sub

    Private Sub Register_Init(sender As Object, e As EventArgs) Handles Me.Init
        TextBox3.TextMode = TextBoxMode.Password
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class