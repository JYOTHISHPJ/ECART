<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="PresentationLayer.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-top:150px";>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
   onrowcommand="CustomersGridView_RowCommand"  OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" Width="1351px" style="margin-bottom: 30px; margin-right: 0px; margin-top: 118px;" Height="412px" HorizontalAlign="Justify" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
    <Columns>
    
        <asp:BoundField ItemStyle-Width="150px" DataField="TOR_REFERENCE_NO" HeaderText="REFERENCE NO" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
              <asp:BoundField ItemStyle-Width="150px" DataField="TOR_ORDER_DATE" HeaderText="DATE OF BOOKING" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
             <asp:BoundField ItemStyle-Width="150px" DataField="TOR_ORDER_STATUS" HeaderText="STATUS" >
      
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
           
       <asp:TemplateField HeaderText="View">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click">VIEW ORDER</asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
     <asp:TemplateField HeaderText="ORDER CANCELLATION ">
        <ItemTemplate>
       <asp:LinkButton runat="server" ID="lnkView1" OnClick="DELETE_CLICK">CANCEL ORDER</asp:LinkButton>
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
    <asp:GridView ID="GridView2" runat="server" runat="server" AutoGenerateColumns="False" AllowPaging="True"
   OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" Width="1351px" style="margin-bottom: 34px; margin-right: 0px; margin-top: 118px;" Height="412px" HorizontalAlign="Justify" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
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
</asp:Content>
