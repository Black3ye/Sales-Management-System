<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Sales_management_system.Menu" MasterPageFile="Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .sections{
            margin-top:175px;
            height:600px;
        }
        .psection2{
            position: absolute;
            top: 115%;
            margin-left:200px;
            font-size:19pt;
            font-family:Arial;
            width:600px;
            height:40px;
        }
        .wsmst{
            position: absolute;
            top: 112%;
            margin-left:150px; 
            font-family:Arial;
            font-size:25pt;
        }
        .wdsmst{
            position: absolute;
            top: 172%;
            margin-left:65%; 
            font-family:Arial;
            font-size:25pt;
        }
        .psection3{
            position: absolute;
            top: 175%;
            margin-left:67%;
            font-size:19pt;
            font-family:Arial;
            width:600px;
            height:40px;
        }
        .li{
            margin-top:40px;
        }
        .slider{
            margin-top:4.5%;
            margin-left:55%;
            height:40%;
            width:40%;
            position:absolute;
            transform:translate(-50%, -50);
            transition-timing-function:ease;
            background-image:url('image/bronco.jpg');
            background-size:100% 100%;
            animation:slider 20s infinite linear;
            box-shadow: 0px 4px 16px;
        }
        @keyframes slider{
            0% {background-image:url('image/bronco.jpg');}
            14.3% {background-image:url('image/Backimagen.jpg');}
            28.6% {background-image:url('image/charge.jpg');}
            42.9% {background-image:url('image/escape.jpg');}
            57.1% {background-image:url('image/f-150.jpg');}
            71.4% {background-image:url('image/sunset.jpg');}
            85.7% {background-image:url('image/skyline.jpg');}
        }
        .gall{
            position: absolute;
            top: 260%;
            margin-left:25%; 
            font-family:Arial;
            font-size:25pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="sections">
        <asp:Panel ID="Panel1" runat="server" Width="100%" style="height:300px;">
            <br />
            <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Welcome" style="margin-left:45.40%; margin-top:45%; font-family:Arial;" Font-Size="40pt"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Jose Garcia" style="margin-left:43.50%; font-family:Arial;" Font-Size="23pt"></asp:Label>
            </asp:Panel>
    </section>
    <section class="sections" >
        <div style="height:600px;  width:100%; background-color:#F2F4F4;">
        <asp:Label ID="Label3" CssClass="wsmst" runat="server" Text="What is SMS?"></asp:Label>
        <br />
        <p class="psection2">SMS (Sales Management System) is a platform for managing sales records
            in order to facilitate the digitization of sales. Our goal is to improve the experience
            of using our tool and create others to facilitate the administrative tasks of a dealer.</p>
        <br />
        </div>
    </section>
    <section class="sections" >
        <div style="height:600px;  width:100%;">
        <asp:Label ID="Label4" CssClass="wdsmst" runat="server" Text="What does SMS do?"></asp:Label>
        <br />
        <ul class="psection3">
            <li class="li">Manage Customer Information</li>
            <li class="li">Manage Sales Information</li>
            <li class="li">Create Reports</li>
        </ul>
        <br />
        </div>
    </section>
    <section class="sections" >
        <div style="height:600px;  width:100%; background-color:#F2F4F4;">
            <asp:Label ID="Label5" CssClass="gall" runat="server" Text="Gallery"></asp:Label>
            <div class="slider">

            </div>
        </div>
    </section>
    
</asp:Content>

