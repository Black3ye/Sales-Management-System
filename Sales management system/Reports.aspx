<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reports.aspx.vb" Inherits="Sales_management_system.Reports" MasterPageFile="Principal.Master" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title></title>
        <style type="text/css">
            .button{
                Height:163px;
                Width:191px;
                color:#797d7f;
                background-color:White;  
            }
            .pbutton{
                margin-left:42%; 
                Height:163px;
                Width:191px;
                color:#797d7f;
                background-color:White;
            }
            .button:hover,.pbutton:hover{
                background-color: #f8f9f9 ;
                color:black;
            }
        </style>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Clients" BorderColor="Transparent" CssClass="pbutton" />
            <asp:Button ID="Button6" runat="server" Text="Sales" BorderColor="Transparent" CssClass="button"/>
            <br />
            
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

    </asp:Content>