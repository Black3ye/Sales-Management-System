<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SalesReport.aspx.vb" Inherits="Sales_management_system.SalesReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .rep{
            margin-left:20%;
            margin-top:10%;
        }
        .title{
            margin-top:20%;
            font-size:20pt;
            font-family:Arial;
            margin-left:45%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Text="Sales Report" CssClass="title"></asp:Label>
        <table class="rep">
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1194px" Font-Names="Verdana" ToolbaritemborderWidth ="1px" ToolbaritemPressedBorderstyle="Solid" 
                        ToolbaritemPressedBorderwidth="1px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedHoverBackColor="153, 187, 226">
                        <LocalReport ReportPath="Report\RptSales.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ReportDataSource1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
