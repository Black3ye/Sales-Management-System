<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Client.aspx.vb" Inherits="Sales_management_system.Client"  EnableEventValidation="false" MasterPageFile="Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        .textbox {
            height: 20px;
            width: 230px;
            margin-left: 7%;
            margin-top:70px;
            border-radius:3px;
        }
        .textbox1{
            height: 20px;
            width: 500px;
            margin-left: 7%;
            margin-top:70px;
            border-radius:4px;
        }
        .button {
            margin-top:50px;
            margin-left: 90%;
            Width:90px;
            height:30px;
            color:White;
            background-color:#424242;
        }
        .button:hover{
            color:black;
            background-color:#919191;
        }
         
        .title{
            margin-left:65%;
            margin-top:35px;
            font-size:30pt;
            font-family:Arial;
        }
        .labelddl{
            margin-left:7%;
            margin-top:100px;
        }
        .ddl{
            height: 25px; 
            width: 150px; 
            margin-left: 7%;
        }
        .grid{
            width:100%;
            border-color:#B2BABB;
        }
        .btnmod{
            width:105px;
            height:30px;
            align-content:center;
            border-radius:3px;
        }
        .Search{
            height: 20px;
            width: 300px;
            margin-top:70px;
            border-radius:3px;
        }
        .radiob{
            margin-left:3%;
            border-style:none;
        }
        .gvb{
            Width:90px;
            height:30px;
            color:White;
            background-color:#424242;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:500px;">
        <br />
        <br />
        <br />
        <div style="width:80%; height:40px; font-family:Arial; font-size:20px; margin-left:11%; text-align:center;">Adding Customer</div>
        <table style="width:90%; align-self:center; margin-left:50px;" >
            <tr>
                <td>
                    <asp:TextBox ID="Txtname" runat="server"  placeholder="Name" CssClass="textbox" AutoCompleteType="Disabled" autocomplete="false" BorderStyle="Solid"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Txtlastname" runat="server"  placeholder="Last Name" CssClass="textbox" AutoCompleteType="Disabled" autocomplete="false" BorderStyle="Solid"/>
                </td>
             </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Txtaddress" runat="server" placeholder="Address"  CssClass="textbox1" AutoCompleteType="Disabled" autocomplete="false" BorderStyle="Solid"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="Txtphone" runat="server" placeholder="Phone" CssClass="textbox" AutoCompleteType="Disabled" autocomplete="false" BorderStyle="Solid"/>
                </td>
                <td>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>
                
            <tr>
                <td></td><td></td>
                <td>
                    <asp:Button ID="Button_insertc" runat="server" Text="Insert" BorderStyle="None" CssClass="button"/>
                </td>
                
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div>
    <div style="width:80%; height:40px; font-family:Arial; font-size:20px; margin-left:11%; text-align:center;">Customer Records</div>
        <asp:Panel ID="Panel1" runat="server" style="height:500px; width:80%; margin-left:12%; align-content:center;" Font-Names="Arial">
            <div style="margin-left:40%;">
                <asp:TextBox ID="Search" runat="server" placeholder="Search" CssClass="Search"></asp:TextBox><asp:Button ID="Btnsearch" runat="server" Text="Search" BorderStyle="None" style="Width:90px; height:27px; color:White; background-color:#424242;"/>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Search By:"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="22px" RepeatDirection="Horizontal" Width="339px" >
                    <asp:ListItem Text="ID" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Name" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Last Name" Value="3" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CssClass="grid" BorderStyle="Solid" HorizontalAlign="Center" AllowCustomPaging="True" AllowPaging="True" AutoGenerateColumns="False"  ViewStateMode="Enabled" ValidateRequestMode="Disabled">
                <HeaderStyle Height="35px" Font-Names="Arial" Font-Size="15px" />
                <RowStyle Height="35px" Font-Names="Arial"/>
                <Columns>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button">
                <ControlStyle CssClass="gvb" />
                    <HeaderStyle Width="250px" />
                </asp:CommandField>
                    <asp:BoundField DataField="IDCLIENT" HeaderText="ID" ItemStyle-Width="50px" SortExpression="ID" ReadOnly="true">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="C_NAME" HeaderText="Name" ItemStyle-Width="75px" SortExpression="Name">
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="C_LASTNAME" HeaderText="Lastname" ItemStyle-Width="135px" SortExpression="Lastname">
                    <ItemStyle Width="135px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="C_ADDRESS" HeaderText="Address" SortExpression="Address"/>
                    <asp:BoundField DataField="C_PHONE" HeaderText="Phone" ItemStyle-Width="115px" SortExpression="Phone">
                    <ItemStyle Width="115px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
