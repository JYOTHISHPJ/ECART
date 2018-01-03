<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Slider.aspx.cs" Inherits="PresentationLayer.Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Content/Slideshow.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.2/jquery.min.js"></script>

    <script type="text/javascript">
        function sample() {
            setInterval(repeat, 2500);
        }
        function repeat() {
            //find button
            var objButton = document.getElementById("cphBody_btnCallCSFunction");
            //Call server side button click
            objButton.click(); //It will call server side event btnCallCSFunction_Click
        }
        window.onload = function () {
            sample();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <ul runat="server" style="list-style-type: none">
        <li>
            <asp:ImageButton ID="PrevImgBtn" runat="server" Width="30px" Height="52px" outline="0" ImageUrl="../Images/imgPrev.png" Style="z-index: 999999; position: absolute; margin-top: 10%; margin-left: -2%;" OnClick="PrevImgBtn_Click" />
        </li>
        <li>

            <asp:ImageButton ID="NextImagetn" runat="server" Width="30px" Height="52px" outline="0" ImageUrl="../Images/imgNext.png" Style="z-index: 999999; margin-left: 92%; position: absolute; margin-top: 10%;" OnClick="NextImagetn_Click" />
        </li>

        <asp:UpdatePanel runat="server" ID="upDate" EnableViewState="false">
            <ContentTemplate>
                <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_OnItemDataBound" OnItemCommand="rptImages_ItemCommand">

                    <ItemTemplate>

                        <li runat="server" id="li">

                            <%-- CommandName="ImageClick" CommandArgument='<%# Eval("TS_IMAGE_URL") %>'--%>

                            <asp:ImageButton OnCommand="Image_Click" ID="SL" runat="server" CommandName="ImageClick" CommandArgument='<%# Eval("TS_IMAGE_URL") %>' Style="position: absolute; margin-top: -1.2%; margin-left: -3.2%; width: 98.7%; height: 52%;" ImageUrl='<%# Eval("TS_IMAGE_URL") %>' />

                        </li>
                    </ItemTemplate>

                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="PrevImgBtn" />
                <asp:AsyncPostBackTrigger ControlID="NextImagetn" />
                <asp:AsyncPostBackTrigger ControlID="btnCallCSFunction" />
            </Triggers>
        </asp:UpdatePanel>
    </ul>
    <div style="display: none;">
        <asp:Button ID="btnCallCSFunction" runat="server"
            Text="This button will not shown on screen" OnClick="btnCallCSFunction_Click" />
    </div>




    <div id="divDataList" style="position: absolute; margin-top: 23%;">
    <asp:DataList ID="dlFeaturedProducts" runat="server" Font-Names="Verdana" Font-Size="Small" RepeatColumns="7"
        CellPadding="8" CellSpacing="50"
        RepeatDirection="Horizontal" Width="75%" HorizontalAlign="Left" OnSelectedIndexChanged="dlFeaturedProducts_SelectedIndexChanged1" OnItemCommand="dlFeaturedProducts_ItemCommand" >
        <HeaderStyle Font-Size="X-Large" Font-Bold="true" Font-Italic="true" ForeColor="#ff0000" Font-Names="Andalus"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderTemplate>
            Featured Products
        </HeaderTemplate>
        <ItemTemplate>
            <br />
            <asp:ImageButton ID="imFeat" runat="server" Width="100px" Height="120px"
                CommandName="ImageClick" CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
            <br />
        </ItemTemplate>

    </asp:DataList>
        <br />
    <asp:DataList ID="dlLatestProducts" runat="server"
        Font-Names="Verdana" Font-Size="Small" RepeatColumns="7"
        CellPadding="8" CellSpacing="50"
        RepeatDirection="Horizontal" OnSelectedIndexChanged="dlLatestProducts_SelectedIndexChanged"
        Width="75%" HorizontalAlign="Left" OnItemCommand="dlLatestProducts_ItemCommand">
        <HeaderStyle Font-Size="X-Large" Font-Bold="true" Font-Italic="true" ForeColor="#ff0000" Font-Names="Andalus"
            HorizontalAlign="Left" VerticalAlign="Middle" />

        <HeaderTemplate>
            Latest Products
        </HeaderTemplate>
        <ItemTemplate>
            <br />
            <asp:ImageButton ID="imLat" runat="server" Width="100px" Height="120px"
                CommandName="ImageClick" ImageUrl='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>' CommandArgument='<%# Bind("TI_IMAGE_URL","~/Images/{0}") %>'></asp:ImageButton>
            <br />
        </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>
