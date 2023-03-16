Imports System.Data.SqlClient
Imports System.Data

Public Class MainPage
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=DESKTOP-KHH66AM\SQLEXPRESS;Database=DashTrack;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Private Sub MainPage_Init(sender As Object, e As EventArgs) Handles Me.Init


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Goes to income/gas exp
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim email As String = System.Web.HttpContext.Current.Session("Email")

        Dim DA As New SqlDataAdapter("Select SUM(Income-Gas) As ProfitLoss, Cast(CompletedOn As datetime) As CompletedOn From StatsTable ST Inner Join InfoTable IT ON IT.UserID = ST.UserID Where IT.Email = '" + email + "' Group By Cast(CompletedOn As datetime)", con)
        Dim DAA As New SqlDataAdapter("Select SUM(Income) As IncomeSum, SUM(Gas) as GasSum From StatsTable ST Inner Join InfoTable IT ON IT.UserID = ST.UserID Where IT.Email = '" + email + "'", con)
        Dim DAAA As New SqlDataAdapter("Select Top 10 SUM(Income-Gas) As ProfitLoss, Email From StatsTable ST Inner Join InfoTable IT ON IT.UserID = ST.UserID Group By Email Order By SUM(ProfitLoss) Desc", con)
        Dim DAAAA As New SqlDataAdapter("Select Income, Gas, Cast(CompletedOn As datetime) As CompletedOn From StatsTable ST Inner Join InfoTable IT ON IT.UserID = ST.UserID Where IT.Email = '" + email + "'", con)

        Dim DT As New DataTable

        Try
            DA.Fill(DT)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Chart1.Titles.Add("Net Profit")
        Chart1.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Legends.Add("Legend1")
        Chart1.Legends("Legend1").Enabled = True
        Chart1.DataSource = DT
        Chart1.Series("Series1").XValueMember = "CompletedOn"
        Chart1.Series("Series1").YValueMembers = "ProfitLoss"
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").IsVisibleInLegend = True
        Chart1.DataBind()

        Dim DTT As New DataTable

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            DAA.Fill(DTT)
            GridView1.DataSource = DTT
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim DTTT As New DataTable

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            DAAA.Fill(DTTT)
            GridView2.DataSource = DTTT
            GridView2.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        Dim DTTTT As New DataTable

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            DAAAA.Fill(DTTTT)
            GridView3.DataSource = DTTTT
            GridView3.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try


    End Sub
End Class