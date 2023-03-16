Imports System.Data
Imports System.Data.SqlClient
Public Class DataAdd
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=DESKTOP-KHH66AM\SQLEXPRESS;Database=DashTrack;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim user As Integer = System.Web.HttpContext.Current.Session("UserID")

        If TextBox1.Text = "" Then
            MsgBox("Please enter Income", vbExclamation, "Error")
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            MsgBox("Please enter Gas", vbExclamation, "Error")
            Exit Sub
        End If

        Dim income, gas As String
        Dim complete As DateTime = DateTime.Now.ToString()
        Dim pl, pls As Decimal

        income = TextBox1.Text
        gas = TextBox2.Text

        Dim cmdInsert As New SqlCommand("Insert Into StatsTable (Income, Gas, UserID, CompletedOn, ProfitLoss, ProfitLossSum) Values (@p1, @p2, @p3, @p4, @p5, @p6)", con)

        With cmdInsert.Parameters
            .Clear()
            .AddWithValue("@p1", income)
            .AddWithValue("@p2", gas)
            .AddWithValue("@p3", user)
            .AddWithValue("@p4", complete)
            .AddWithValue("@p5", pl)
            .AddWithValue("@p6", pls)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdInsert.ExecuteNonQuery()
            Response.Write("Record Added")
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class