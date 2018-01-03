<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="PresentationLayer.PresentationLayer.AddToCart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= lblAddtoCart.ClientID %>').style.display = "none";
            document.getElementById('<%= lblWishlist.ClientID %>').style.display = "none";
        }
        setTimeout("HideLabel();", 6000);
    </script>
    <style type="text/css">
        .view-part {
            width: 10%;
            float: left;
        }

        .content-part {
            width: 40%;
            float: left;
            margin-top: 5%;
            margin-left: -2%;
        }

        .image-part {
            width: 25%;
            float: left;
            margin-left: 3%;
            margin-top: 4%;
        }

        .addtocart-head {
            width: 25%;
            float: left;
            margin-top: 5%;
            margin-left: -8%;
        }

        .addtocart {
            border-color: aliceblue;
            border: thick 2px;
        }


        .blankstar {
            background-image: url(../Images/blank_star.png);
            width: 16px;
            height: 16px;
        }

        .waitingstar {
            background-image: url(../Images/half_star.png);
            width: 16px;
            height: 16px;
        }

        .shiningstar {
            background-image: url(../Images/shining_star.png);
            width: 16px;
            height: 16px;
        }

        .lblCustComments {
            font-style: oblique;
            font-size: 20px;
        }

        .lblComment {
            font-style: italic;
            flood-color: aquamarine;
        }

        .lblReviewHead {
            font-style: oblique;
            font-size: 25px;
        }

        .comments {
            border-top-color: aliceblue;
            margin-top: 30%;
            background: #C9C9C9;
        }

        .span100 {
            font-size: 20px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }

        #product_image {
            width: 225px;
            height: 260px;
        }

        .main-head {
            background: #C9C9C9;
            margin-top: -1.6%;
        }

        .Features {
            position: absolute;
            margin-left: 23%;
            margin-top: -36%;
            width: 400px;
            height: 130px;
        }

        @supports (-webkit-appearance:none) {
            .main-head {
                margin-top: -31.4%;
            }
        }

        @supports (-webkit-appearance:none) {
            #div-comment {
                background: #C9C9C9;
                margin-top: 26%;
            }
        }

        @supports (-webkit-appearance:none) {

            .main-head {
                margin-top: -1.4%;
                position: absolute;
                margin-left: 0%;
                width: 98.7%;
                background: #C9C9C9;
            }

            .Features {
                position: absolute;
                margin-left: 23%;
                margin-top: -31%;
                width: 400px;
                height: 130px;
            }
        }



        .ratings-div {
            margin-left: 7%;
        }

        #imgbtnList {
            width: 30px;
            height: 30px;
        }

        .dlImages {
            margin-top: -25%;
        }



        .form {
            background: #C9C9C9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <br />
    <div class="main-head" style="background-color: #C9C9C9;">
        <div class="a-container" style="height: 30%">
            <div class="view-part" runat="server">
                <asp:DataList ID="dlMultipleImagesShow" runat="server"
                    Font-Names="Verdana" Font-Size="Small" RepeatColumns="1"
                    CellPadding="8" CellSpacing="30"
                    RepeatDirection="Vertical" OnItemCommand="imMultipleImages_Click"
                    Width="100px" HorizontalAlign="Left" CssClass="dlImages">
                    <ItemTemplate>
                        <br />
                        <asp:ImageButton ID="imMultipleImages" runat="server" Width="50px" Height="50px" CommandName="ImageClick"
                            CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'
                            ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="image-part">
                <asp:UpdatePanel ID="imgChange" runat="server">
                    <ContentTemplate>
                        <asp:Image runat="server" ID="product_image" style="height:230px;width:160px"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="content-part">
                <span runat="server" id="product_Name"></span>
                <br />
                <span runat="server" class="available">Available in These Sellers</span>
                <br />
                <span runat="server" id="product_price"></span>
                <br />
                <span runat="server" id="product_quantity"></span>
                <br />
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Rating ID="Rating2" runat="server" AutoPostBack="true" StarCssClass="blankstar"
                            WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
                            EmptyStarCssClass="blankstar">
                        </asp:Rating>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="addtocart-head">
                <span class="span100">100% Purchase Protection</span><br />
                <br />
                <div class="addtocart">

                    <asp:UpdatePanel ID="UpdatePanelQuantity" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text="Quantity  :"></asp:Label>
                            <asp:DropDownList ID="drpQuantity" runat="server"></asp:DropDownList><br />
                            <br />
                            <asp:Button ID="btnaddtocart" runat="server" Style="border-color: #adb1b8 #a2a6ac #8d9096; border-style: solid; cursor: pointer; border-width: 1px; background: linear-gradient(to bottom,#f7dfa5,#f0c14b); height: 35px; width: 190px;" Text="Add To Cart" ToolTip="Add To Shopping Cart" OnClick="btnaddtocart_Click" /><br />
                            <asp:Label ID="lblAddtoCart" runat="server" Style="color: green"></asp:Label>
                            <br />
                            <asp:Button ID="btnAddToWishList" runat="server" Style="border-color: #adb1b8 #a2a6ac #8d9096; border-style: solid; cursor: pointer; border-width: 1px; background: linear-gradient(to bottom,#f6c88f,#ed9220); height: 30px; width: 190px;" Text="Add To WishList" ToolTip="Add To Your WishList" OnClick="btnAddToWishList_Click" />
                            <br />
                            <asp:Label ID="lblWishlist" runat="server" Style="color: green"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="div-comment" class="comments">
            <span runat="server" id="review" class="lblReviewHead"></span>
            <br />
            <br />
            <div class="ratings-div">
                <asp:Label ID="lblComments" runat="server" Text="Comments "></asp:Label>
                <asp:TextBox ID="txtComments" runat="server" Height="20px" Width="250px"></asp:TextBox>
                <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
                <br />
                <br />

                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Rating ID="Rating1" runat="server" AutoPostBack="true" StarCssClass="blankstar"
                                WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
                                EmptyStarCssClass="blankstar" OnChanged="Rating1_Changed">
                            </asp:Rating>
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblCustComments" runat="server" Text="Customer Comments " CssClass="lblCustComments"></asp:Label><br />
                            <asp:Label ID="lblShowComments1" runat="server" CssClass="lblComment"></asp:Label><br />
                            <asp:Label ID="lblShowComments2" runat="server" CssClass="lblComment"></asp:Label><br />
                            <asp:Label ID="lblShowComments3" runat="server" CssClass="lblComment"></asp:Label><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Label runat="server" ID="lblFeatures" CssClass="Features"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

