<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="PresentationLayer.PresentationLayer.AddToCart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .view-part {
            width: 10%;
            float: left;
        }

        .content-part {
            width: 40%;
            float: left;
            margin-top:5%;
        }

        .image-part {
            width: 25%;
            margin-left: 8%;
            float: left;
        }

        .addtocart-head {
            width: 25%;
            float: left;
            margin-top:5%;
            
        }

        .addtocart {
            border-color: aliceblue;
            border:thick 2px;
        }

        body {
            margin: 0px auto;
            width: 980px;
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            background: #C9C9C9;
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
        .lblCustComments{
            font-style:oblique;
            font-size:20px;
        }
        .lblComment{
            font-style:italic;
            flood-color:aquamarine;
        }
        .lblReviewHead{
            font-style:oblique;
            font-size:25px;
        }
        .comments{
            border-top-color:aliceblue;
        }
        .span100{
            font-size:20px;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="a-container" style="height: 30%">
        <div class="view-part">
        </div>
        <div class="image-part">
            <asp:Image runat="server" ID="product_image" />
        </div>
        <div class="content-part">
            <span runat="server" id="product_Name"></span>
            <br />
            <span runat="server" class="available">Available in These Sellers</span>
            <br />
            <span runat="server" id="product_price"></span>
            <br />
            <span runat="server" id="product_quantity"></span><br />
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Rating ID="Rating2" runat="server" AutoPostBack="true" StarCssClass="blankstar"
                        WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
                        EmptyStarCssClass="blankstar" >
                    </asp:Rating>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="addtocart-head">
            <span class="span100">100% Purchase Protection</span><br /><br />
            <div class="addtocart">
                
                <asp:UpdatePanel ID="UpdatePanelQuantity" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity  :"></asp:Label>
                        <asp:DropDownList ID="drpQuantity" runat="server"></asp:DropDownList><br />
                        <br />
                        <asp:Button ID="btnaddtocart" runat="server" Text="Add To Cart" Width="190px" Height="40px" OnClick="btnaddtocart_Click" /><br />
                        <br />
                        <asp:Button ID="btnAddToWishList" runat="server" Text="Add To WishList" Width="190px" Height="30px" OnClick="btnAddToWishList_Click"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div style="margin-top: 30%" class="comments">
        <span runat="server" id="review" class="lblReviewHead"></span>
        <br />
        <br />
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
            <asp:Label ID="lblCustComments" runat="server" Text="Customer Comments " CssClass="lblCustComments"></asp:Label><br />
            <asp:Label ID="lblShowComments1" runat="server" CssClass="lblComment"></asp:Label><br />
            <asp:Label ID="lblShowComments2" runat="server" CssClass="lblComment"></asp:Label><br />
            <asp:Label ID="lblShowComments3" runat="server" CssClass="lblComment"></asp:Label><br />
        </div>
    </div>
</asp:Content>
