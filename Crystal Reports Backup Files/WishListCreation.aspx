<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="WishListCreation.aspx.cs" Inherits="PresentationLayer.WishListCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server"  Height="166px"  ImageUrl="~/Images/info-amazon-wishlist.png" Width="411px" style="margin-left: 100px;" />
        <asp:GridView ID="gvWishList" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" CellSpacing="23" onrowcommand="CustomersGridView_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="TI_IMAGE_URL" HeaderText="PRODUCT " >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
      <asp:BoundField ItemStyle-Width="150px" DataField="TP_PRODUCT_NAME"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="150px" DataField="TW_PRICE" HeaderText="PRICE" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
           <asp:BoundField ItemStyle-Width="150px" DataField="TW_QUANTITY" HeaderText="QUANTITY" >
      <ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
       <asp:BoundField ItemStyle-Width="150px" DataField="TW_AMOUNT" HeaderText="TOTAL" >
      <ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>

            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button runat="server" ID="btnDelete" Text="Add To Cart" OnClick="btnAdd_Click" />
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
