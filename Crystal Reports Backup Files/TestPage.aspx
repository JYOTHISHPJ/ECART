<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="PresentationLayer.PresentationLayer.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ImageButton ID="iphone6" runat="server" ImageUrl="~/Images/iphone.png" OnClick="iphone6_Click" />

</asp:Content>
