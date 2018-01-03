<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Product Manager.aspx.cs" Inherits="PresentationLayer.Product_Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHead" runat="server">
    <style type="text/css">
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {

            $("#cphAdminBody_txt_datepicker").datepicker({ dateFormat: 'dd-mm-yy' });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#cphAdminBody_txt_datepicker").keyup(function () {
                if ($(this).val().length == 2) {
                    $(this).val($(this).val() + "-");
                } else if ($(this).val().length == 5) {
                    $(this).val($(this).val() + "-");
                }
            });
        });
    </script>

    <script>
        function productimage(a, b) {
            document.getElementById(b).value = a.value;
        }

        function slider(a, b) {
            document.getElementById(b).value = a.value;
        }

        function image1 (a, b)
        {
            document.getElementById(b).value = a.value;
        }
        function image2(a, b) {
            document.getElementById(b).value = a.value;
        }
        </script>

    <style>
        body {
            background-color: #b2babb;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminBody" runat="server">
    <br />
    <br />
    <br />
    <div style="margin-left: 21%">
        <asp:Label ID="lbl_productid" runat="server" Text="PRODUCT ID" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productid" runat="server" Style="margin-left: 4.3%" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rproduct" runat="server" ControlToValidate="txt_productid"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Product ID is mandatory"></asp:RequiredFieldValidator>
        <asp:Label ID="lbl_categoryid" runat="server" Text="CATEGORY ID" Style="margin-left: 3.4%"></asp:Label>
        <asp:DropDownList ID="ddl_categoryid" runat="server" Style="margin-left: 15px;" Height="25px" Width="147px" AppendDataBoundItems="true" >
            <asp:ListItem Value="0">SELECT</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lbl_productname" runat="server" Text="PRODUCT NAME" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productname" runat="server" Style="margin-left: 13px;" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_productname"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Product Name is mandatory"></asp:RequiredFieldValidator>
        <asp:Label ID="lbl_brandname" runat="server" Text="BRAND NAME" Style="margin-left: 1.6%"></asp:Label>
        <asp:TextBox ID="txt_brandname" runat="server" Style="margin-left: 1%" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_brandname"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="BrandName is mandatory"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lbl_price" runat="server" Text="PRICE" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_price" runat="server" Style="margin-left: 93px;" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_price"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Price is mandatory"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revprice" runat="server" ControlToValidate="txt_price" SetFocusOnError="true" ValidationExpression="^\d*[0-9](|.\d*[0-9]|)*$" ForeColor="Red"
            ErrorMessage="Enter Numeric Values" ValidationGroup="Checking" Style="margin-left: -7%; position: absolute"></asp:RegularExpressionValidator>
        <asp:Label ID="lbl_quantity" runat="server" Text="QUANTITY" Style="margin-left: 72px;"></asp:Label>
        <asp:TextBox ID="txt_quantity" runat="server" Style="margin-left: 35px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_quantity"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Quantity is mandatory"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_quantity" SetFocusOnError="true" ValidationExpression="^\d*[0-9](|.\d*[0-9]|)*$" ForeColor="Red"
            ErrorMessage="Please Enter Numeric Values" ValidationGroup="dfngbhf" Style="margin-left: -7.57%; position: absolute"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" STYLE="margin-left:295PX;position:absolute;color:transparent" onchange="productimage(this, 'cphAdminBody_txt_productimage');"/>
        <asp:Label ID="lbl_image" runat="server" Text="PRODUCT IMAGE" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_productimage" Enabled="false"  runat="server" Style="margin-left: 8px;" MaxLength="200"></asp:TextBox>
         <asp:Label ID="lbl_sliderimage" runat="server" Text="SLIDER IMAGE" Style="margin-left: 19%"></asp:Label>
        <asp:FileUpload ID="FileUpload2" runat="server" STYLE="margin-left:155PX;position:absolute;color:transparent" onchange="slider(this, 'cphAdminBody_txt_sliderimage');"/>
        <asp:TextBox ID="txt_sliderimage" Enabled="false" runat="server" Style="margin-left: 0.8%"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_subimage1" runat="server" Text="IMAGE1" Style="margin-left: 1%"></asp:Label>
        <asp:FileUpload ID="FileUpload3" runat="server" STYLE="margin-left:225PX;position:absolute;color:transparent" onchange="image1(this, 'cphAdminBody_txt_image1');"/>
        <asp:TextBox ID="txt_image1" Enabled="false" runat="server" Style="margin-left: 79px" MaxLength="200"></asp:TextBox>
        <asp:Label ID="lbl_image2" runat="server" Text="IMAGE2" Style="margin-left: 19%"></asp:Label>
      <asp:FileUpload ID="FileUpload4" runat="server" STYLE="margin-left:202PX;position:absolute;color:transparent" onchange="image2(this, 'cphAdminBody_txt_image2');"/>
        <asp:TextBox ID="txt_image2" runat="server" Enabled="false" Style="margin-left: 55px" MaxLength="200"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_date" runat="server" Text="FEATURES" Style="margin-left: 1%"></asp:Label>
        <asp:TextBox ID="txt_details" runat="server" Style="margin-left: 63px;" MaxLength="200"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_details"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Features  is mandatory"></asp:RequiredFieldValidator>
        <asp:Label ID="lbl_features" runat="server" Text="DATE" Style="margin-left: 50px;"></asp:Label>
        <input id="txt_datepicker" runat="server" type="text" style="margin-left: 76px;" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_datepicker"
            ValidationGroup="Checking" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Date  is mandatory"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_datepicker" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" runat="server" ErrorMessage="Invalid Date" ValidationGroup="dfngbhf" ForeColor="#FF3300" Style="margin-left: -6%; position: absolute"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btn_save" runat="server" Text="SAVE" Style="margin-left: 34%;" OnClick="btn_save_Click" ValidationGroup="Checking" />
        <asp:Button ID="btn_clear" runat="server" Text="CLEAR" OnClick="btn_clear_Click" />
        <br />
        <br />
        <asp:Label ID="lblSearch" runat="server" Style="padding-right: 136px; margin-left: 15%;" Text="SEARCH PRODUCT ID HERE"></asp:Label>
        <asp:TextBox ID="txt_search" runat="server" Style="margin-left: -128px" MaxLength="10"></asp:TextBox>
        <asp:Button ID="btn_filter" runat="server" Text="FILTER" Style="margin-left: 10px" OnClick="filter" />
        <br />
        <br />
        <div id="divGridView" style="margin-left: -27%;">
            <asp:GridView ID="dtg" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" CellSpacing="2" AutoGenerateColumns="False" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
                <EmptyDataTemplate>NO RECORD FOUND</EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_edit" OnClick="edit">EDIT</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbn_delete" OnClick="delete">DELETE</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TP_PRODUCT_ID" HeaderText="PRODUCT ID" />
                    <asp:BoundField DataField="TP_CATEGORY_ID" HeaderText="CATEGORY ID" />
                    <asp:BoundField DataField="TP_PRODUCT_NAME" HeaderText="PRODUCT NAME" />
                    <asp:BoundField DataField="TP_BRAND_NAME" HeaderText="BRAND NAME" />
                    <asp:BoundField DataField="TP_PRICE" HeaderText="PRICE" />
                    <asp:BoundField DataField="TP_QUANTITY" HeaderText="QUANTITY" />
                    <asp:BoundField DataField="TP_DATE" HeaderText="DATE" />
                    <asp:BoundField DataField="TI_IMAGE_URL" HeaderText="PRODUCT IMAGE" />
                    <asp:BoundField DataField="TS_IMAGE_URL" HeaderText="SLIDER IMAGE" />
                    <asp:BoundField DataField="TF_FEATURES" HeaderText="FEATURES" />
                </Columns>
            </asp:GridView>
        </div>
        <%--<asp:GridView ID="dtg" runat="server">
        </asp:GridView>--%>
        <br />
    </div>
</asp:Content>
