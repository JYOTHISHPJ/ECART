<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Salesstatistics.aspx.cs" Inherits="PresentationLayer.Salesstatistics" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
    <%-- <link rel="stylesheet" href="/resources/demos/style.css" />--%>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script src='../crystalreportviewers13/js/crviewer/crv.js' type="text/javascript"></script>
    <link href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            $("#datepicker").keyup(function () {
                if ($(this).val().length == 2) {
                    $(this).val($(this).val() + "-"); 9
                } else if ($(this).val().length == 5) {
                    $(this).val($(this).val() + "-");
                }
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#datepicker1").keyup(function () {
                if ($(this).val().length == 2) {
                    $(this).val($(this).val() + "-");
                } else if ($(this).val().length == 5) {
                    $(this).val($(this).val() + "-");
                }
            });
        });
    </script>
    <script>
        $(function () {
            $("#cphBody_datepicker").datepicker({ dateFormat: 'dd-mm-y' });
        });
    </script>



    <script>
        $(function () {
            $("#cphBody_datepicker1").datepicker({ dateFormat: 'dd-mm-y' });
        });
    </script>

    <style>
        body {
            background-color: #B2BABB;
        }
    </style>
    

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div>
        <div class="group1" id="group1" runat="server" style="height: 410px; margin-left: 100px">
            <div>
                <p>
                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Style="margin-left: 250px; margin-top: 150px; font-size: 40px; font-style: normal" Text="Product Wise Sales Statistics Report "></asp:Label>
                </p>
            </div>

            <div style="margin-left: 140px; margin-top: 40px;">
                <asp:RadioButton ID="RadioButton1" GroupName="radiobuttonname" runat="server" Text="<b>By Date</b>" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                <div id="first">
                    <div>

                        <asp:Label ID="Label2" runat="server" Style="margin-left: 140px;" Text="Start Date [dd//mm/yy]"></asp:Label>

                        <input id="datepicker" type="text" runat="server" validationgroup="reset_val_group_name" style="margin-left: 106px;" />

                    </div>
                    <br />
                    <div>

                        <asp:Label ID="Label3" runat="server" Style="margin-left: 140px;" Text="End Date [dd//mm/yy]"></asp:Label>

                        <input id="datepicker1" type="text" runat="server" validationgroup="reset_val_group_name" style="margin-left: 110px;" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="datepicker" ControlToValidate="datepicker1" ErrorMessage="Enter higher date !" ForeColor="Red" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                    </div>
                </div>
                <br />
                <br />
                <div style="height: 176px">
                    <asp:RadioButton ID="RadioButton2" GroupName="radiobuttonname" runat="server" Text="<b>By Month</b>" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
                    <div>
                        <div id="second ">
                            <div>
                                <asp:Label ID="Label4" runat="server" Style="margin-left: 140px;" Text="Year"></asp:Label>

                                <asp:TextBox ID="TextBox1" runat="server" Style="margin-left: 227px;" ToolTip="Enter year" MaxLength="4" TextMode="Number">2016</asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^\d*[0-9](|.\d*[0-9]|)*$">Enter valid year</asp:RegularExpressionValidator>
                            </div>
                            <br />
                            <div>

                                <asp:Label ID="Label5" runat="server" Style="margin-left: 140px;" Text="Month"></asp:Label>

                                <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-left: 212px;" Height="22px" Width="174px" ToolTip="Select month" AppendDataBoundItems="True" AutoPostBack="True">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btn_Reset" runat="server" Height="28px" OnClick="btn_Reset_Click" Style="margin-left: 349px" Text="Reset" ToolTip="Click to Clear" Width="93px" />
                    <asp:Button ID="btn_Show" runat="server" Text="Show Report" Style="margin-left: 54px; margin-top: 50px;" OnClick="btn_Show_Click" Height="28px" Width="93px" ToolTip="Click to show report" />

                </div>
            </div>

        </div>

          </div>

        <div class="group2" id="group2" runat="server">
            <asp:Button ID="btn_Back" runat="server" Text="Back" Style="margin-right: 200px" Height="28px" Width="93px" OnClick="btn_Back_Click" ToolTip="Click to go back" />
            <br />
            <br />
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Style="margin-left: 200px;" AutoDataBind="true" EnableTheming="True" HasCrystalLogo="False" HasDrilldownTabs="False" HasGotoPageButton="False" HasPageNavigationButtons="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" Height="50px" ToolPanelView="None" Width="350px" />

        </div>

  

</asp:Content>
