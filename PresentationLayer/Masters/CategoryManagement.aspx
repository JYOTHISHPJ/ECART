﻿<%@ Page Title="Category Management" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="PresentationLayer.CategoryManagement.CategoryManagement" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">

    <style>
        body {
            background-color: #b2babb;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">

    <div id="divMain" style="margin-left: 38%; margin-top: 5%;">
        <asp:Label ID="lblCategoryId" runat="server" Text="CATEGORY ID : "></asp:Label>
        <asp:TextBox ID="txtCategoryId" runat="server" Style="margin-left: 60px;" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCategoryId" runat="server" ControlToValidate="txtCategoryId"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage=" * Category ID is mandatory"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lblCategoryName" runat="server" Text="CATEGORY NAME :"></asp:Label>
        <asp:TextBox ID="txtCategoryName" runat="server" Style="margin-left: 30px;" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage=" * Category Name is mandatory"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lblParentId" runat="server" Text="PARENT ID : "></asp:Label>
        <asp:DropDownList ID="ddlParentId" runat="server" AppendDataBoundItems="true" Style="margin-left: 10.6%; width: 19.5%;">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" Style="margin-left: 100px;" />
        <asp:Button ID="btnInsert" runat="server" Text="INSERT" OnClick="btnInsert_Click" ValidationGroup="Checking" />

    </div>

    <div id="divGridView" style="margin-left: 32.5%; margin-top: 2%;">
        <asp:GridView ID="gvCategory" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="false" AutoGenerateDeleteButton="True" OnRowDeleting="gvCategory_RowDeleting" OnRowDataBound="gvCategory_RowDataBound">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
            <EmptyDataTemplate>NO RECORD FOUND</EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="ACTION">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnEdit" OnClick="lbtnEdit_Click"> Edit </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TCY_CATEGORY_ID" HeaderText="CATEGORY ID" />
                <asp:BoundField DataField="TCY_CATEGORY_NAME" HeaderText="CATEGORY NAME" />
                <asp:BoundField DataField="TCY_PARENT_ID" HeaderText="PARENT ID" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
