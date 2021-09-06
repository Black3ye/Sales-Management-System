Public Class Reports
    Inherits System.Web.UI.Page
    Dim uid As String
    Dim un As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Report Menu - Sales Management System"
        uid = Request.QueryString.Item("UID")
        un = Request.QueryString.Item("UN")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = "window.open('Report/ClientReport.aspx?UID=" & uid & "&UN=" & un & "', '_blank');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim s As String = "window.open('Report/SalesReport.aspx?UID=" & uid & "&UN=" & un & "', '_blank');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)
    End Sub
End Class