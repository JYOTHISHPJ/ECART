<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Product Manager.aspx.cs" Inherits="PresentationLayer.Product_Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#cphBody_txt_datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <br />
    <br />
    <br />
    <div style="margin-left: 10%">
        <asp:Label ID="lbl_productid" runat="server" Text="PRODUCT ID" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productid" runat="server" Style="margin-left: 4.3%"></asp:TextBox>
        <asp:Label ID="lbl_categoryid" runat="server" Text="CATEGORY ID" Style="margin-left: 3%"></asp:Label>
        <asp:DropDownList ID="ddl_categoryid" runat="server" Style="margin-left: 1.3%" Height="25px" Width="147px"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lbl_productname" runat="server" Text="PRODUCT NAME ID" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productname" runat="server" Style="margin-left: 1%"></asp:TextBox>
        <asp:Label ID="lbl_brandname" runat="server" Text="BRAND NAME" Style="margin-left: 2.8%"></asp:Label>
        <asp:TextBox ID="txt_brandname" runat="server" Style="margin-left: 1%"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_price" runat="server" Text="PRICE" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_price" runat="server" Style="margin-left: 7.8%"></asp:TextBox>
        <asp:Label ID="lbl_quantity" runat="server" Text="QAUNTITY" Style="margin-left: 2.8%"></asp:Label>
        <asp:TextBox ID="txt_quantity" runat="server" Style="margin-left: 2.7%"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_image" runat="server" Text="PRODUCT IMAGE" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productimage" runat="server" Style="margin-left: 2%"></asp:TextBox>
        <asp:Label ID="lbl_sliderimage" runat="server" Text="SLIDER IMAGE" Style="margin-left: 2.6%"></asp:Label>
        <asp:TextBox ID="txt_sliderimage" runat="server" Style="margin-left: 1%"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_date" runat="server" Text="FEATURES" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_details" runat="server" Style="margin-left: 5.5%"></asp:TextBox>
        <asp:Label ID="lbl_features" runat="server" Text="DATE" Style="margin-left: 3%"></asp:Label>
        <input id="txt_datepicker" runat="server" type="text" style="margin-left: 5.4%" />
        <br />
        <br />
        <div id="divGridView">
            <asp:GridView ID="dtg" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
                <EmptyDataTemplate> NO RECORD</EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_edit" OnClick="edit">EDIT</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_delete" OnClick="delete">DELETE</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TP_PRODUCT_ID" HeaderText="PRODUCT ID"/>
                </Columns>
            </asp:GridView>
        </div>
        <%--<asp:GridView ID="dtg" runat="server">
        </asp:GridView>--%>
        <br />
        <asp:Button ID="btn_save" runat="server" Text="SAVE" Style="margin-left: 20%" OnClick="btn_save_Click" />
        <asp:Button ID="btn_clear" runat="server" Text="CLEAR" OnClick="btn_clear_Click" />
    </div>
</asp:Content>

