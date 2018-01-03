<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductListing.aspx.cs" Inherits="PresentationLayer.ProductListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function postBackByObject(mEvent) {
            var o;
            // Internet Explorer    
            if (mEvent.srcElement) {
                o = mEvent.srcElement;
            }
                // Netscape and Firefox
            else if (mEvent.target) {
                o = mEvent.target;
            }
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                __doPostBack("", "");
            }
        }
    </script>
    <script type="text/javascript">
        // Javascript - make sure this appears in the html after the control you are trying to find
        var txtSearch = document.getElementById('<%=Master.FindControl("txtSearch").ClientID %>');
        </script>
    <style type="text/css">
        #divMultipleImages {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="height: 479px; width: 24%; top: 34px; left: 1189px; ">

       <%-- <asp:TreeView ID="tvUserGroupMenus" CssClass="caption" runat="server" onclick="javascript:postBackByObject(event)"
                            OnTreeNodeCheckChanged="tvUserGroupMenus_OnTreeNodeCheckChanged" OnSelectedNodeChanged="tvUserGroupMenus_SelectedNodeChanged" ShowCheckBoxes="All">
                            <NodeStyle Font-Names="Arial" Font-Bold="False" Font-Size="100%" ForeColor="Black"
                                HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="True" />
                            <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" />
                        </asp:TreeView>--%>


        <asp:TreeView ID="tvFiltering" BorderStyle="Groove" BorderColor="Bisque" OnTreeNodeCheckChanged="tvFiltering_OnTreeNodeCheckChanged" 
            ShowCheckBoxes="All" onclick="javascript:postBackByObject(event)" 
            RootNodeStyle-ForeColor="Black" runat="server" ForeColor="Black" OnSelectedNodeChanged="tvFiltering_OnSelectedNodeCheckChanged">
        <NodeStyle Font-Names="Arial" Font-Bold="True" Font-Size="100%" ForeColor="Black"
                                HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Italic="True"  />
                            <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <br />
    <div id="divMultipleImages" runat="server" style="margin-left: 30%; margin-top: -530px">
        <asp:UpdatePanel ID="imgFilter" runat="server">
            <ContentTemplate>
                <asp:DataList ID="dlProductListing" runat="server"
                    Font-Names="Verdana" Font-Size="Small" RepeatColumns="2"
                    CellPadding="8" CellSpacing="50"
                    RepeatDirection="Horizontal" OnItemCommand="imProductListing_Click"
                    Width="100%" HorizontalAlign="Left" Height="312px" OnSelectedIndexChanged="dlProductListing_SelectedIndexChanged">
                    <ItemTemplate>
                        <asp:ImageButton ID="imProductListing" runat="server" AlternateText="Product Image"
                            CommandName="ImageClick" CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'
                            Width="100px" Height="120px" ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
                        <br />
                        <b>Product Name : </b>
                        <asp:Label ID="lblProdName" runat="server" Text='<%# Bind("TP_PRODUCT_NAME") %>'></asp:Label>
                        <br />
                        <b>Brand Name : </b>
                        <asp:Label ID="lblBrandName" runat="server" Text='<%# Bind("TP_BRAND_NAME") %>'></asp:Label>
                        <br />
                        <b>Price : </b>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("TP_PRICE") %>'></asp:Label>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
