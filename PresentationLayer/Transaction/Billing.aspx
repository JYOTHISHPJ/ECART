<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="PresentationLayer.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style> body {
        background-color: #b2babb ;
    }</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
 
    <div style="margin-left:500px; margin-top:75px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Order Details" Font-Names="Constantia" Font-Size="XX-Large" ForeColor="#660066" Font-Bold="True" ></asp:Label>
    </div>
    
    <div runat="server" id="order" style="margin-left:250px; margin-top:-10px;">
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/empty_cart.png" Width="398px" Visible="false" Height="316px" />
<asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
   onrowcommand="CustomersGridView_RowCommand"  OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged"   style="margin-bottom: 30px; margin-right: 0px; margin-top: 118px;" Height="16px" HorizontalAlign="Justify" OnRowUpdating="gvOrder_RowUpdating" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
    <Columns>
    
        <asp:BoundField ItemStyle-Width="100px" DataField="TOR_REFERENCE_NO" HeaderText="REFERENCE NO" >
      
        <FooterStyle Width="10px" />
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
              <asp:BoundField ItemStyle-Width="100px" DataField="TOR_ORDER_DATE" HeaderText="DATE OF BOOKING" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
             <asp:BoundField ItemStyle-Width="100px" DataField="TOR_ORDER_STATUS" HeaderText="STATUS" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
           
       <asp:TemplateField HeaderText="VIEW">
        <ItemTemplate>
       <asp:LinkButton runat="server"   ID="View" OnClick="lnkView_Click">VIEW ORDER</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
     <asp:TemplateField HeaderText="ORDER CANCELLATION ">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="Cancel" OnClick="Delete_Click">CANCEL ORDER</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
</asp:GridView>
        </div>
    <div style=" margin-left:250px";>
    <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True"
   OnPageIndexChanging="OnPageIndexChanging2" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged"  style="margin-bottom: 34px; margin-right: 0px; margin-top: 118px;"  OnRowUpdating="gvOrder_RowUpdating" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
    <Columns>
    
        <asp:BoundField ItemStyle-Width="150px" DataField="TP_PRODUCT_NAME" HeaderText="PRODUCT NAME" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
              <asp:BoundField ItemStyle-Width="150px" DataField="TOS_DATE" HeaderText="DATE OF BOOKING" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
          
          <asp:BoundField ItemStyle-Width="150px" DataField="TOS_AMOUNT" HeaderText="PRICE" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
          
          <asp:BoundField ItemStyle-Width="150px" DataField="TOS_QUANTITY" HeaderText="QUANTITY" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
           <asp:BoundField ItemStyle-Width="150px" DataField="TOR_ORDER_STATUS" HeaderText="STATUS" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        
       
    </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
</asp:GridView>

        </div>
    <div  runat="server" id="total" >
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Label ID="Label2" runat="server" Text="Total =" Font-Size="X-Large" ForeColor="#FF0066"></asp:Label>
        &nbsp;&nbsp;
    <asp:Label ID="lblTotal" runat="server" Font-Size="Large"></asp:Label>
    </div>
    <br />
    <br />
    <br />

</asp:Content>
