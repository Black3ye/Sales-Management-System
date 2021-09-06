Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Login - Sales Management System"

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "SELECT * FROM [dbo].[VENDOR] WHERE USERNAME='" + TextBox1.Text.Trim + "'COLLATE SQL_Latin1_General_CP1_CS_AS AND PASSWORD='" + TextBox2.Text.Trim + "' COLLATE SQL_Latin1_General_CP1_CS_AS"
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(str, con)
        Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(sda)
        Dim dt As DataTable = New DataTable
        dt.Clear()
        Try
            sda.Fill(dt)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error: Could not establish connetion with the database');", True)
        End Try

        If dt.Rows.Count > 0 Then
            Session.Add("username", TextBox1.Text)
            Dim name As String = dt.Rows(0).Item("NAME") + " " + dt.Rows(0).Item("LASTNAME")
            Dim id As String = dt.Rows(0).Item("IDVENDOR")
            FormsAuthentication.SetAuthCookie(TextBox1.Text, False)
            FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, False)
            Response.Redirect("Menu.aspx?UID=" & id & "&UN=" & name)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Username/Password Incorrect');", True)
        End If



    End Sub
End Class