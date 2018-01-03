<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="MultipleImages.aspx.cs" Inherits="PresentationLayer.MultipleImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-left: 80px">
        <asp:Button ID="btnShowImages" runat="server" BackColor="#FFC54A" BorderStyle="Groove" BorderWidth="2px" Font-Names="Tahoma" Font-Size="Medium" Text="Show Images" ToolTip="Click To View Multiple Images" OnClick="btnShowImages_Click" />
    </div>
    <br />

    <div id="divMultipleImages" runat="server">
        <asp:DataList ID="dlMultipleImages" runat="server"
            Font-Names="Verdana" Font-Size="Small" RepeatColumns="5"
            CellPadding="8" CellSpacing="50"
            RepeatDirection="Horizontal" 
            Width="100%" HorizontalAlign="Left" Height="312px">
            <ItemTemplate>
                <br />
                <asp:ImageButton ID="imMultipleImages" runat="server" CommandName="ImageClick" OnClick="imMultipleImages_Click" CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' AlternateText="Product Image" Width="100px" Height="120px" ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
