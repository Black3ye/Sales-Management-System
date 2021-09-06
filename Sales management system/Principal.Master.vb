Public Class Principal
    Inherits System.Web.UI.MasterPage
    Public uid As String = " "
    Public un As String = " "
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        uid = Request.QueryString.Item("UID")
        un = Request.QueryString.Item("UN")
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub B_Sales_Click(sender As Object, e As EventArgs) Handles B_Sales.Click
        Response.Redirect("Sales.aspx?UID=" & uid & "&UN=" & un)
    End Sub

    Protected Sub B_logout_Click(sender As Object, e As EventArgs) Handles B_logout.Click
        Session.Contents.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Buffer = True
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1D)
        Response.Expires = -1500
        Response.CacheControl = "no-cache"
        Response.Redirect("Login.aspx")

    End Sub

    Protected Sub B_report_Click(sender As Object, e As EventArgs) Handles B_report.Click
        Response.Redirect("Reports.aspx?UID=" & uid & "&UN=" & un)
    End Sub

    Protected Sub B_Home_Click(sender As Object, e As EventArgs) Handles B_Home.Click
        Response.Redirect("Menu.aspx?UID=" & uid & "&UN=" & un)
    End Sub

    Protected Sub B_Client_Click(sender As Object, e As EventArgs) Handles B_Client.Click
        Response.Redirect("Client.aspx?UID=" & uid & "&UN=" & un)
    End Sub
End Class