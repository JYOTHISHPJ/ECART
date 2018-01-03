<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Forgetpassword.aspx.cs" Inherits="PresentationLayer.Forgetpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left: 36%; margin-top: 10%;">
<table cellspacing:"2" cellpadding:"2" border="0">
<tr><td></td><td>Forgot Your  Password ?</td></tr>
<tr><td>Enter Your Email:</td><td><asp:TextBox ID="txtEmail" runat="server" /></td></tr>
<tr><td></td><td><asp:button ID="btnSubmit" Text="Submit"  runat="server" onclick="btnSubmit_Click" CssClass="Button"/></td></tr>
<tr><td colspan="2" style=" color:red"><asp:Label ID="lbltxt" runat="server"/></td></tr>
</table>
</div>
</asp:Content>
