Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Client
    Inherits System.Web.UI.Page
    Dim Global_class As Declarations = New Declarations
    Dim str As String
    Dim dt As DataTable = New DataTable
    Dim uid As String
    Dim un As String
    Dim flag As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Customer - Sales Management System"
        uid = Request.QueryString.Item("UID")
        un = Request.QueryString.Item("UN")
        If Not IsPostBack Or flag = True Then
            str = "SELECT * FROM [dbo].[CLIENT]"
            RequestSQL()
            GridView1.DataSource = dt
            GridView1.DataBind()
            ViewState("Global") = Global_class
        End If

    End Sub
    Private Sub RequestSQL()
        Dim sda As SqlDataAdapter = New SqlDataAdapter(str, Declarations.scon)
        Dim cmd As SqlCommandBuilder = New SqlCommandBuilder(sda)
        dt.Clear()
        sda.Fill(dt)
    End Sub

    Private Sub Button_insertc_Click(sender As Object, e As EventArgs) Handles Button_insertc.Click
        Dim Global_class As Declarations = ViewState("Global")
        Dim str As String = "INSERT INTO dbo.CLIENT([C_NAME], [C_LASTNAME], [C_ADDRESS], [C_PHONE]) VALUES('" + Txtname.Text + "','" + Txtlastname.Text + "','" + Txtaddress.Text + "','" + Txtphone.Text + "');"
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)
        Dim cm As SqlCommand = New SqlCommand(str, con)
        con.Open()
        Try
            cm.ExecuteNonQuery()
            con.Close()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The client was saved correctly');", True)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error Adding the client');", True)
        End Try
        Response.Redirect("Client.aspx?UID=" & uid & "&UN=" & un)
        ViewState("Global") = Global_class
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim Global_class As Declarations = ViewState("Global")
        GridView1.EditIndex = e.NewEditIndex
        flag = True
        ViewState("Global") = Global_class
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        Dim Global_class As Declarations = ViewState("Global")
        GridView1.EditIndex = -1
        flag = False
        ViewState("Global") = Global_class
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim Global_class As Declarations = ViewState("Global")
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim Id As Integer = Convert.ToInt32(row.Cells(1).Text)
        Dim Name As String = TryCast(row.Cells(2).Controls(0), TextBox).Text
        Dim lastname As String = TryCast(row.Cells(3).Controls(0), TextBox).Text
        Dim address As String = TryCast(row.Cells(4).Controls(0), TextBox).Text
        Dim phone As String = TryCast(row.Cells(5).Controls(0), TextBox).Text
        Dim str As String = "UPDATE dbo.CLIENT SET C_NAME = '" + Name + "', C_LASTNAME = '" + lastname + "', C_ADDRESS = '" + address + "', C_PHONE = '" + phone + "' WHERE IDCLIENT= '" & Id & "'"
        Dim cmd As SqlCommand = New SqlCommand(str)
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)
        cmd.Connection = con
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        GridView1.EditIndex = -1
        flag = False
        Response.Redirect("Client.aspx?UID=" & uid & "&UN=" & un)
        ViewState("Global") = Global_class
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim Global_class As Declarations = ViewState("Global")
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim idvar As String = row.Cells(2).Text
        idvar += " " + row.Cells(3).Text
        Dim Ans As MsgBoxResult
        Ans = MsgBox("Do you want delete  " + idvar + " ?", vbYesNo)
        If Ans = MsgBoxResult.Yes Then
            Dim str As String = "DELETE FROM dbo.CLIENT WHERE IDCLIENT= '" + row.Cells(1).Text + "'"
            Dim con As SqlConnection = New SqlConnection(Declarations.scon)
            Dim cmd As SqlCommand = New SqlCommand(str, con)
            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The client selected was don't deleted ');", True)
            End Try
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The client was deleted sucesfully');", True)
            Response.Redirect("Client.aspx?UID=" & uid & "&UN=" & un)
        End If
        ViewState("Global") = Global_class
    End Sub

    Protected Sub Btnsearch_Click(sender As Object, e As EventArgs) Handles Btnsearch.Click
        Dim Global_class As Declarations = ViewState("Global")
        Dim result As String
        If RadioButtonList1.SelectedValue = 1 Then
            result = "SELECT * FROM dbo.CLIENT WHERE IDCLIENT = '" + Search.Text + "'"
        ElseIf RadioButtonList1.SelectedValue = 2 Then
            result = "SELECT * FROM dbo.CLIENT WHERE C_NAME = '" + Search.Text + "'"
        ElseIf RadioButtonList1.SelectedValue = 3 Then
            result = "SELECT * FROM dbo.CLIENT WHERE C_LASTNAME = '" + Search.Text + "'"
        Else
            result = "SELECT * FROM dbo.CLIENT"
        End If
        Dim sda As SqlDataAdapter = New SqlDataAdapter(result, Declarations.scon)
        Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(sda)
        Dim dt2 As DataTable = New DataTable
        dt2.Clear()
        sda.Fill(dt2)
        GridView1.DataSource = dt2
        GridView1.DataBind()
        ViewState("Global") = Global_class
    End Sub
End Class