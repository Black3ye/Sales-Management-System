<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Sales_management_system.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 257px;
            width: 1134px;
            
        }
        .tbl{
            width:100%; 
            font-family:Arial; 
            height: 217px; 
            margin-left:40%; 
            margin-top:30%;
            background:rgba(255,255,255, 0.3);
            box-shadow: 0px 4px 16px;
        }
        .btn{
            background-color:#424242; 
            margin-left: 116px;
            margin-top: 9px;
            border-style:none;
        }
        .btn:hover{
            background-color:#919191;
        }
        .style{
            background-color:black;
            margin-left:60%;
            height:100%;
            width:30%
        }
    </style>
</head>
<body style="background-color:#F2F4F4;">
        <form id="form1" runat="server">
            <asp:Panel ID="Panel1" runat="server" Width="100%" Height="20%">
                    <table class="tbl">
                        <tr>
                            <td><asp:Label ID="Label1" runat="server" Text="Sales Management System" style="margin-left:50px; font-size:23px;"></asp:Label></td>
                            <td><asp:Panel ID="Panel2" runat="server" Height="174px" Width="501px" style="margin-left: auto; align-content:center;">
                                    <asp:Label ID="Label2" runat="server" Text="Log In " Font-Size="15pt" style="text-align:center;" Width="496px"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="250px" style="margin-left: 116px; margin-top: 12px;" placeholder="Username" ValidateRequestMode="Enabled" Height="25px" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:TextBox ID="TextBox2" runat="server" Width="250px"  style="margin-left: 116px; margin-top: 16px;" type="Password" placeholder="Password" ValidateRequestMode="Enabled" Height="25px"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Log In" Width="258px" Height="35px" ForeColor="White" />
                                </asp:Panel></td>
                        </tr>
                    </table>
            </asp:Panel>
        </form>
</body>
</html>
