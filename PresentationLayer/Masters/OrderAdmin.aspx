<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderAdmin.aspx.cs" Inherits="PresentationLayer.OrderAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">
    
    <div id="divMain" style="margin-left: 38%; margin-top: 5%;"  >
        <asp:Label ID="lblReference" runat="server" Text="REFERENCE NO : "></asp:Label>
        <asp:TextBox ID="txtReference" runat="server" Style="margin-left: 60px;" MaxLength="10" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCategoryId" runat="server" ControlToValidate="txtReference"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage=" * Category ID is mandatory"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lblUserId" runat="server" Text="USER ID :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUserId" runat="server" Style="margin-left: 30px;" MaxLength="50" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtUserId" ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage=" * Category Name is mandatory"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text="STATUS : "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddstatus" runat="server" AppendDataBoundItems="true" style="margin-left: 9%;" Height="22px" Width="150px">
            <asp:ListItem>ORDERED</asp:ListItem>
            <asp:ListItem>CANCELLED</asp:ListItem>
            <asp:ListItem>DELIVERED</asp:ListItem>
            <asp:ListItem>SHIPPED</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" Style="margin-left: 100px;" />
        <asp:Button ID="btnInsert" runat="server" Text="UPDATE" OnClick="btnInsert_Click" ValidationGroup="Checking" CausesValidation="False" EnableTheming="True" />

    </div>

    <div id="divGridView" style="margin-left: 35%; margin-top: 2%;">
        <asp:GridView ID="gvCategory" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="false" OnSelectedIndexChanged="gvCategory_SelectedIndexChanged">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
            <EmptyDataTemplate> NO RECORD FOUND</EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="ACTION">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnEdit" OnClick="lbtnEdit_Click"> Edit </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TOR_REFERENCE_NO" HeaderText="REFERENCE NO" />
                <asp:BoundField DataField="TU_USER_NAME" HeaderText="USERNAME" />
                <asp:BoundField DataField="TOR_ORDER_STATUS" HeaderText="ORDER STATUS" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
