<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="QuickCartPage.aspx.cs" Inherits="PresentationLayer.QuickCartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div runat="server" id="gvDiv" style="margin-left: 24%;">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvQuickCart" runat="server" OnRowCommand="CustomersGridView_RowCommand" AutoGenerateColumns="False" CellPadding="4" Style="margin-left: 6px;" OnSelectedIndexChanged="gvQuickCart_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">

            <EmptyDataTemplate>NO RECORD FOUND</EmptyDataTemplate>
            <Columns>



                <asp:ImageField ItemStyle-Width="150px" DataImageUrlField="TI_IMAGE_URL" DataImageUrlFormatString="~\Images\{0}" HeaderText="SHOPPING CART ">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:ImageField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TP_PRODUCT_NAME" HeaderText="PRODUCT NAME">
                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TCT_PRICE" HeaderText="PRICE">

                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="75px" DataField="TCT_QUANTITY" HeaderText="QUANTITY">
                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>



                <asp:BoundField ItemStyle-Width="75px" DataField="TCT_AMOUNT" HeaderText="AMOUNT">
                    <ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="ACTION">
                    <HeaderStyle Width="75" />
                    <ItemStyle Width="75" />
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDeleteFromCart" Text="Remove" OnClick="btDel_Click" />
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

        <div runat="server" id="total" style="margin-top: 3%;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl1" runat="server" style="font-size: 20px; color: rgb(137, 0, 0); margin-left: 29%;" Text="TOTAL : "></asp:Label>
            <asp:Label runat="server"  ID="lbl_total" style="font-size: 21px; text-decoration: underline double;" Text="0"></asp:Label>

            <br /> <br />
            <asp:Button runat="server" ID="btnProceed"  Text="Proceed To Checkout" Height="27px" Style="margin-left: 23%;" Width="162px" BackColor="#990000" Font-Names="Times New Roman" Font-Size="Medium" ForeColor="White" OnClick="btnProceed_Click" />
        </div>
    </div>
    <br />
    <br />

</asp:Content>
