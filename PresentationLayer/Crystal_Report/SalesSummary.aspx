<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SalesSummary.aspx.cs" Inherits="PresentationLayer.Crystal_Report.SalesSummary" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">
    <script src='../crystalreportviewers13/js/crviewer/crv.js' type="text/javascript"></script>
    <title> Sales Summary Report </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">
    <asp:Button ID="btnShowReport" runat="server" Text="SHOW REPORT" Style="background-color: rgb(0, 153, 255); margin-left: 46%; margin-top: 20%;" OnClick="btnShowReport_Click" />
    <div id="divReport" style="margin-top: -19%; margin-left: 2%;">
        <CR:CrystalReportViewer ID="crvReport" runat="server" AutoDataBind="true" Style="margin-left: 150px"
            HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" HasCrystalLogo="False"
            HasDrilldownTabs="False" Height="50px" ToolPanelWidth="150px" Width="350px"
            ShowAllPageIds="True" ToolPanelView="None" />
    </div>
    <asp:Label ID="lbl_Report" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>
