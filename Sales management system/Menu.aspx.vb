Public Class Menu
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Home - Sales Management System"
        Label2.Text = Request.QueryString.Item("UN")
        If Session.IsNewSession = True Then
            Response.Redirect("Login.aspx")
        End If
        If Session.Contents.Count < "1" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

End Class