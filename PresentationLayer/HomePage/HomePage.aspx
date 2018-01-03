<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PresentationLayer.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DataList ID="dlFeaturedProducts" runat="server"
            Font-Names="Verdana" Font-Size="Small" RepeatColumns="4"
            CellPadding="8" CellSpacing="50"
             RepeatDirection="Horizontal" OnSelectedIndexChanged="dlFeaturedProducts_SelectedIndexChanged"
            Width="75%" HorizontalAlign="Left">  
            <HeaderStyle Font-Size="Larger" Font-Bold="true" Font-Italic="true" ForeColor="#ff0000" Font-Names="Andalus"
                HorizontalAlign="Left" VerticalAlign="Middle" />

              <HeaderTemplate>
                Featured Products</HeaderTemplate>
            <ItemTemplate>
                <br />
                <asp:ImageButton ID="imFeat" runat="server" OnClick="imFeat_Click" Width="100px" Height="120px" 
                    CommandName="ImageClick" CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
                <br />
            </ItemTemplate>
        </asp:DataList>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DataList ID="dlLatestProducts" runat="server"
            Font-Names="Verdana" Font-Size="Small" RepeatColumns="4"
            CellPadding="8" CellSpacing="50"
             RepeatDirection="Horizontal" OnSelectedIndexChanged="dlLatestProducts_SelectedIndexChanged"
            Width="75%" HorizontalAlign="Left">
            <HeaderStyle Font-Size="Larger" Font-Bold="true" Font-Italic="true" ForeColor="#ff0000" Font-Names="Andalus"
                HorizontalAlign="Left" VerticalAlign="Middle" />

              <HeaderTemplate>
                Latest Products</HeaderTemplate>
            <ItemTemplate>
                <br />
                <asp:ImageButton ID="imLat" runat="server"  Width="100px" Height="120px" 
                    OnCommand="ImageClick" ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'>
                    
                </asp:ImageButton>
                <br />
            </ItemTemplate>
        </asp:DataList>
</asp:Content>