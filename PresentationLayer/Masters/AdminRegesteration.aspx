<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminRegesteration.aspx.cs" Inherits="PresentationLayer.AdminRegesteration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">
    <style type="text/css">
        </style>
    
    
    <style>
    body
    {
        background-color: #b2babb ;
    }
    </style>
<script type="text/javascript">
    function checkQuote(event) {
        if (event.which == 39) {
            event.which = 0;
            return false;
        }
    }
 
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">
    <div style="margin-left:30%;width:488px;height:285px;border-color:blue;border:double">
        <br />
        <br />
        <br />
        <br />
    <asp:Label ID="lbl_user" runat="server" Text="USER NAME" style="margin-left:23%"></asp:Label>
    <asp:TextBox ID="txt_user" runat="server" MaxLength="50" onkeypress="return checkQuote(event);"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" SetFocusOnError="true" ValidationGroup="Admin" ControlToValidate="txt_user" ForeColor="Red" ErrorMessage=" * Mandatory "></asp:RequiredFieldValidator>
        <br />
        <br />
     <asp:Label ID="lbl_pass" runat="server" Text="PASSWORD" style="margin-left:23%"></asp:Label>
    <asp:TextBox ID="txt_pass" runat="server" MaxLength="50"  onkeypress="return checkQuote(event);"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" SetFocusOnError="true" ValidationGroup="Admin" ControlToValidate="txt_pass" ForeColor="Red"  ErrorMessage=" * Mandatory "></asp:RequiredFieldValidator>
   <br />
    <br />
      <asp:Button ID="btn_save" runat="server" Text="SAVE" OnClick="btn_save_Click" style="margin-left:36%"  ValidationGroup="Admin" />
    <asp:Button ID="btn_clear" runat="server" Text="CLEAR" OnClick="btn_clear_Click" />
    </div>
    <br />
    <br />
    <br />
    <div style="margin-left:34%">
  
        <asp:GridView ID="dtg" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" CellSpacing="2" AutoGenerateColumns="False">
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
                <Columns >
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate >
                            <asp:LinkButton runat="server" ID="lbn_edit" OnClick="edit">EDIT</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_delete" OnClick="DELETE">DELETE</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="USERNAME" HeaderText="USERNAME"/> 
                 <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD"/>
                     </Columns>
            </asp:GridView>
  </div>
</asp:Content>
