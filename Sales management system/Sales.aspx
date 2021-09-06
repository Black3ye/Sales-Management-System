<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sales.aspx.vb" Inherits="Sales_management_system.Sales" MasterPageFile="Principal.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sales Menu</title>
    <style type="text/css">
        .textbox {
            height: 20px;
            width: 230px;
            margin-left: 7%;
            margin-top:70px;
            border-radius:3px;
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
            border-style:solid;
        }
        .grid{
            width:100%;
            border-color:#B2BABB;
        }
        .gvb{
            Width:90px;
            height:30px;
            color:White;
            background-color:#424242;
        }
        .Search{
            height: 20px;
            width: 300px;
            margin-top:70px;
            border-radius:3px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:500px;">
        <br />
        <br />
        <br />
        <div style="width:80%; height:40px; font-family:Arial; font-size:20px; margin-left:11%; text-align:center;">Adding Sale</div>
        <table style="width:90%; align-self:center; margin-left:50px;" >
            <tr>
                <td>
                    <asp:TextBox ID="Txtprice" runat="server" placeholder="Total Price" CssClass="textbox"/>
                </td>
            </tr>
            <tr>

                    <td style="height:100px; align-items:flex-end;">
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Lblmodel" runat="server" Text="Select Model:" CssClass="labelddl"/>
                    <br />
                    <asp:DropDownList ID="Ddlmodel" runat="server" CssClass="ddl" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>

                    <td style="height:100px; align-items:flex-end;">
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblvehicle" runat="server" Text="Vehicle ID" CssClass="labelddl"/>
                    <br />
                    <asp:DropDownList ID="Ddlvehicle" runat="server" CssClass="ddl"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:100px; align-items:flex-end;">
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Lblclient" runat="server" Text="Select Client ID" CssClass="labelddl"/>
                    <br />
                    <asp:DropDownList ID="Ddlclient" runat="server" CssClass="ddl"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td><td></td>
                <td>
                    <asp:Button ID="Button_inserte" runat="server" Text="Insert" BorderStyle="None" CssClass="button"/>
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
    <div style="width:80%; height:40px; font-family:Arial; font-size:20px; margin-left:11%; text-align:center;">Sales Records</div>
        <asp:Panel ID="Panel1" runat="server" style="height:500px; width:80%; margin-left:12%; align-content:center;" Font-Names="Arial">
            <div style="margin-left:40%;">
                <asp:TextBox ID="Search" runat="server" placeholder="Search" CssClass="Search"></asp:TextBox><asp:Button ID="Btnsearch" runat="server" Text="Search" BorderStyle="None" style="Width:90px; height:27px; color:White; background-color:#424242;"/>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Search By:"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="22px" RepeatDirection="Horizontal" Width="339px" >
                    <asp:ListItem Text="ID" Value="1"></asp:ListItem>
                    <asp:ListItem Text="ID Client" Value="2"></asp:ListItem>
                    <asp:ListItem Text="ID Vehicle" Value="3" ></asp:ListItem>
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
                    <HeaderStyle Width="100px" />
                </asp:CommandField>
                    <asp:BoundField DataField="IDSALES" HeaderText="ID" ItemStyle-Width="100px" SortExpression="ID" ReadOnly="true">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL_PRICE" HeaderText="Price" ItemStyle-Width="100px" SortExpression="Total Price">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDVEHICLE" HeaderText="Vehicle ID" ItemStyle-Width="100px" SortExpression="ID Vehicle">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDCLIENT" HeaderText="Client ID" ItemStyle-Width="100px" SortExpression="ID Client"/>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>

