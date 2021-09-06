Imports System.Web.UI.ScriptManager
Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient
Public Class SalesReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DataforReport()
        End If
    End Sub
    Public Sub DataforReport()
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)

        Dim Sql As String = "SELECT * FROM [dbo].[SALES]"
        Dim sda As SqlDataAdapter = New SqlDataAdapter(Sql, con)
        Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(sda)
        Dim dt As New DataTable
        con.Open()
        Try
            dt.Clear()
            sda.Fill(dt)
        Finally
            con.Close()
        End Try
        Dim rds = New ReportDataSource("DSSale", dt)


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Reportes\RptSales.rdlc"
        ReportViewer1.DataBind()
    End Sub
End Class