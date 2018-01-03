<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="PresentationLayer.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">
    <style>
    body
    {
        background-color: #b2babb ;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">
    <div id="divGridView">
            <asp:GridView ID="dtg" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" CellSpacing="2" AutoGenerateColumns="False" OnPageIndexChanging="OnPageIndexChanging">
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
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_edit" OnClick="deactivate">DEACTIVATION</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                 <asp:BoundField DataField="TU_USER_ID" HeaderText="USER ID"/>
                 <asp:BoundField DataField="TU_USER_NAME" HeaderText="USER NAME"/>
                    <asp:BoundField DataField="TU_ADDRESS" HeaderText="ADDRESS" />
                     <asp:BoundField DataField="TU_MOB_NO" HeaderText="MOBILE NUMBER" />
                        <asp:BoundField DataField="TU_EMAIL_ID" HeaderText="EMAIL ID" />
                     <asp:BoundField DataField="TU_PASSWORD" HeaderText="PASSWORD" />
                        <asp:BoundField DataField="TU_OTP" HeaderText="OTP" />
                    <asp:BoundField DataField="TU_CREATED_DATE" HeaderText="CREATED DATE" />
                    <asp:BoundField DataField="TU_EXP_DATE" HeaderText="EXPIRY DATE" />
                    <asp:BoundField DataField="TU_ACTIVE" HeaderText="ACTIVE" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
