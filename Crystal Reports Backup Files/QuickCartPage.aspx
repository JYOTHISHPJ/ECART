<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="QuickCartPage.aspx.cs" Inherits="PresentationLayer.QuickCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div >
        
    <asp:GridView ID="gvQuickCart" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  CellSpacing="23" style="margin-left: 6px; Height:148px; Width:792px">

         <AlternatingRowStyle BackColor="White" />

         <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="TI_IMAGE_URL" HeaderText="Shopping Cart " >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
      <asp:BoundField ItemStyle-Width="150px" DataField="TP_PRODUCT_NAME"  >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="150px" DataField="TCT_PRICE" HeaderText="PRICE" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
           <asp:BoundField ItemStyle-Width="150px" DataField="TCT_QUANTITY" HeaderText="QUANTITY" >
      <ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
     
        
    </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
         <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
        
        <div id="total" style="margin-left:630px">
        <asp:Label ID="lbl1" runat="server" Text="Total:"></asp:Label>
          <asp:Label ID="lbl_total" runat="server" Text="0"></asp:Label>
        
            </div>
        <asp:Button ID="btnProceed" runat="server" Text="Proceed To Checkout" Height="27px" style="margin-left:864px;" Width="162px" BackColor="#990000" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" OnClick="btnProceed_Click" />
        </div>
    <br />
    <br />
    
</asp:Content>
