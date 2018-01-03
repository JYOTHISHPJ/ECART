<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportform.aspx.cs" Inherits="PresentationLayer.Reportform" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src='../crystalreportviewers13/js/crviewer/crv.js' type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_Show" runat="server" Text="Show Report" OnClick="btn_Show_Click" BackColor="#0099FF" />
       
         <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" style="margin-left: 150px" 
            HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" HasCrystalLogo="False" 
            HasDrilldownTabs="False" HasPageNavigationButtons="False" Height="50px" ToolPanelWidth="150px" Width="350px" 
            ShowAllPageIds="True" ToolPanelView="None"/>

               
    </div>
        <asp:Label ID="lbl_Report" runat="server" Text="Label" Visible="false"></asp:Label>
    </form>
</body>

</html>
