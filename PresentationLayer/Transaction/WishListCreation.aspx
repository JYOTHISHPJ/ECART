<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="WishListCreation.aspx.cs" Inherits="PresentationLayer.WishListCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div id="divGV" style="margin-left: 22%; margin-top: 4%;">
        <asp:GridView ID="gvWishList" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" CellSpacing="23" 
            OnRowCommand="CustomersGridView_RowCommand"> <%--OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"--%> 
            <Columns>

                <asp:ImageField ItemStyle-Width="150px" DataImageUrlField="TI_IMAGE_URL" dataimageurlformatstring="~\Images\{0}" HeaderText="PRODUCT ">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:ImageField>

                <asp:BoundField ItemStyle-Width="130px" DataField="TP_PRODUCT_NAME" HeaderText="PRODUCT NAME">
                    <ItemStyle Width="130px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TW_PRICE" HeaderText="PRICE">

                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TW_QUANTITY" HeaderText="QUANTITY">
                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TW_AMOUNT" HeaderText="TOTAL">
                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDelete" Text="Add To Cart"  OnClick="btnAdd_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDel" Text="Remove"  OnClick="btDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>

</asp:Content>
