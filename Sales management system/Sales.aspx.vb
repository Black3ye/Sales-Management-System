Imports System.Data.SqlClient
Public Class Sales
    Inherits System.Web.UI.Page
    Dim dt As DataTable = New DataTable
    Dim str As String
    Dim Global_class As Declarations = New Declarations
    Public uid As String
    Public un As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Sales Menu - Sales Management System"
        uid = Request.QueryString.Item("UID")
        un = Request.QueryString.Item("UN")
        If Not IsPostBack Then
            str = "SELECT IDCLIENT FROM dbo.CLIENT"
            RequestSQL()
            Ddlclient.DataSource = dt
            Ddlclient.DataValueField = "IDCLIENT"
            Ddlclient.DataBind()
            str = "SELECT M_NAME FROM dbo.MODELS"
            RequestSQL()
            Ddlmodel.DataSource = dt
            Ddlmodel.DataValueField = "M_NAME"
            Ddlmodel.DataBind()
            str = "SELECT IDSALES, TOTAL_PRICE, IDVEHICLE, IDCLIENT FROM dbo.SALES WHERE IDVENDOR='" & uid & "'"
            RequestSQL()
            GridView1.DataSource = dt
            GridView1.DataBind()
            Ddlmodel.Items.Insert(0, New ListItem("", ""))
            Ddlclient.Items.Insert(0, New ListItem("", ""))
            Ddlvehicle.Items.Insert(0, New ListItem("", ""))
            If Ddlmodel.Text = "" Then
                Ddlvehicle.Enabled = False
                Ddlvehicle.SelectedIndex = 0
            Else
                Ddlvehicle.Enabled = True
            End If
            ViewState("Global") = Global_class
        End If

    End Sub
    Private Sub RequestSQL()
        Dim sda As SqlDataAdapter = New SqlDataAdapter(str, Declarations.scon)
        Dim cmd As SqlCommandBuilder = New SqlCommandBuilder(sda)
        dt.Clear()
        sda.Fill(dt)
    End Sub

    Private Sub Ddlmodel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ddlmodel.SelectedIndexChanged
        Dim Global_class As Declarations = ViewState("Global")
        If Ddlmodel.Text = "" Then
            Ddlvehicle.Enabled = False
            Ddlvehicle.ClearSelection()
            Ddlvehicle.Items.Insert(0, New ListItem("", ""))
        Else
            Ddlvehicle.Enabled = True
            str = "SELECT IDVEHICLE FROM dbo.VEHICLE WHERE IDMODELS = '" & Ddlmodel.SelectedIndex & "'AND BFLAG = 0"
            RequestSQL()
            Ddlvehicle.DataSource = dt
            Ddlvehicle.DataValueField = "IDVEHICLE"
            Ddlvehicle.DataBind()
            Ddlvehicle.Items.Insert(0, New ListItem("", ""))
        End If

        ViewState("Global") = Global_class
    End Sub

    Private Sub Button_inserte_Click(sender As Object, e As EventArgs) Handles Button_inserte.Click
        Dim Global_class As Declarations = ViewState("Global")
        str = "INSERT INTO [dbo].[SALES]([TOTAL_PRICE],[IDVEHICLE],[IDCLIENT],[IDVENDOR]) VALUES ('" + Txtprice.Text + "','" + Ddlvehicle.Text + "','" + Ddlclient.Text + "','" + uid + "');"
        Dim cmd As SqlCommand = New SqlCommand(str)
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)
        cmd.Connection = con
        cmd.Connection.Open()
        Try
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            str = "UPDATE dbo.VEHICLE SET BFLAG = 1 WHERE IDVEHICLE='" + Ddlvehicle.Text + "'"
            Dim cmd1 As SqlCommand = New SqlCommand(str)
            cmd1.Connection = con
            cmd1.Connection.Open()
            cmd1.ExecuteNonQuery()
            cmd1.Connection.Close()
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The Sale was saved');", True)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The Sale was not saved');", True)
        End Try
        Response.Redirect("Sales.aspx?UID=" & uid & "&UN=" & un)
        ViewState("Global") = Global_class
    End Sub

    Protected Sub Btnsearch_Click(sender As Object, e As EventArgs) Handles Btnsearch.Click
        Dim Global_class As Declarations = ViewState("Global")
        Dim result As String
        Try
            If RadioButtonList1.SelectedValue = 1 Then
                result = "SELECT * FROM dbo.SALES WHERE IDSALES = '" + Search.Text + "'"
            ElseIf RadioButtonList1.SelectedValue = 2 Then
                result = "SELECT * FROM dbo.SALES WHERE IDCLIENT = '" + Search.Text + "'"
            ElseIf RadioButtonList1.SelectedValue = 3 Then
                result = "SELECT * FROM dbo.SALES WHERE IDVEHICLE = '" + Search.Text + "'"
            Else
                result = "SELECT * FROM dbo.SALES"
            End If

            Dim sda As SqlDataAdapter = New SqlDataAdapter(result, Declarations.scon)
            Dim cmb As SqlCommandBuilder = New SqlCommandBuilder(sda)
            Dim dt2 As DataTable = New DataTable
            dt2.Clear()
            sda.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Not found record');", True)
            End If
            GridView1.DataSource = dt2
            GridView1.DataBind()
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please select a option to search');", True)
        End Try
        ViewState("Global") = Global_class
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim Global_class As Declarations = ViewState("Global")
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim pvehicles As Integer = Convert.ToInt32(row.Cells(3).Text)
        Dim Id As Integer = Convert.ToInt32(row.Cells(1).Text)
        Dim price As String = TryCast(row.Cells(2).Controls(0), TextBox).Text
        Dim idvehicle As String = TryCast(row.Cells(3).Controls(0), TextBox).Text
        Dim idclient As String = TryCast(row.Cells(4).Controls(0), TextBox).Text
        Dim str As String = "UPDATE dbo.SALES SET TOTAL_PRICE = '" + price + "', IDVEHICLE = '" + idvehicle + "', IDCLIENT = '" + idclient + "' WHERE IDSALES= '" & Id & "'"
        Dim cmd As SqlCommand = New SqlCommand(str)
        Dim con As SqlConnection = New SqlConnection(Declarations.scon)
        cmd.Connection = con
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        str = "UPDATE dbo.VEHICLE SET BFLAG = 1 WHERE IDVEHICLE='" + idvehicle + "'"
        Dim cmd1 As SqlCommand = New SqlCommand(str)
        cmd1.Connection = con
        cmd1.Connection.Open()
        cmd1.ExecuteNonQuery()
        cmd1.Connection.Close()
        str = "UPDATE dbo.VEHICLE SET BFLAG = 0 WHERE IDVEHICLE='" & pvehicles & "'"
        Dim cmd2 As SqlCommand = New SqlCommand(str)
        cmd2.Connection = con
        cmd2.Connection.Open()
        cmd2.ExecuteNonQuery()
        cmd2.Connection.Close()
        GridView1.EditIndex = -1
        Response.Redirect("Sales.aspx?UID=" & uid & "&UN=" & un)
        ViewState("Global") = Global_class
    End Sub

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim Global_class As Declarations = ViewState("Global")
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim idvar As String = row.Cells(2).Text
        idvar += " " + row.Cells(3).Text
        Dim Ans As MsgBoxResult
        Ans = MsgBox("Do you want delete  " + idvar + " ?", vbYesNo)
        If Ans = MsgBoxResult.Yes Then
            Dim str As String = "DELETE FROM dbo.SALES WHERE IDSALES= '" + row.Cells(1).Text + "'"
            Dim con As SqlConnection = New SqlConnection(Declarations.scon)
            Dim cmd As SqlCommand = New SqlCommand(str, con)
            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The sale selected was don't deleted ');", True)
            End Try
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('The sale was deleted sucesfully');", True)
            Response.Redirect("Sales.aspx?UID=" & uid & "&UN=" & un)
        End If
        ViewState("Global") = Global_class
    End Sub

    Private Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim Global_class As Declarations = ViewState("Global")
        GridView1.EditIndex = e.NewEditIndex
        ViewState("Global") = Global_class
    End Sub

    Private Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        Dim Global_class As Declarations = ViewState("Global")
        GridView1.EditIndex = -1
        ViewState("Global") = Global_class
    End Sub
End Class