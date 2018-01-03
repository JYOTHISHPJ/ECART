<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductListing.aspx.cs" Inherits="PresentationLayer.ProductListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        #divMultipleImages {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="height:479px; width:15%;top: 34px; left: 1189px;">

        <asp:TreeView ID="TreeViewFiltering" RootNodeStyle-ForeColor="Black" runat="server" ForeColor="Black">
            

        </asp:TreeView>
        </div>
    <br />
    <div id="divMultipleImages" runat="server" style="margin-left:200px;margin-top:-530px">
        
        <asp:DataList ID="dlProductListing" runat="server"
            Font-Names="Verdana" Font-Size="Small" RepeatColumns="3"
            CellPadding="8" CellSpacing="50"
            RepeatDirection="Horizontal"
            Width="100%" HorizontalAlign="Left" Height="312px" 
            OnItemCommand="imProductListing_Click" >
           <%-- OnSelectedIndexChanged="dlProductListing_SelectedIndexChanged"--%>
            <ItemTemplate>
                <asp:ImageButton  ID="imProductListing" runat="server" CommandName="ImageClick" CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' AlternateText="Product Image" Width="100px" Height="120px" ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
                <br />
                <b> Product Name : </b>
                <asp:Label ID="lblProdName" runat="server" Text='<%# Bind("TP_PRODUCT_NAME") %>'></asp:Label>
                <br />
                <b> Brand Name : </b>
                <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("TP_BRAND_NAME") %>'></asp:Label>
                <br />
                <b> Price : </b>
                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("TP_PRICE") %>'></asp:Label>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
