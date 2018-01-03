<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="PresentationLayer.Changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="margin-top: 16%; margin-left: 33%;">
    
      <table  class="style1" style="border: thin solid #008080">
            <tr>
                <td colspan="3" 
                    style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">
                    Change Password</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Enter Current Password :
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtcurrentpass" runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtcurrentpass" ErrorMessage="!!" ForeColor="Red" 
                      ValidationGroup="vgNew"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Enter New Password :</td>
                <td class="style4">
                    <asp:TextBox ID="txtnewpass" runat="server" Width="120px" ValidationGroup="vgNew" TextMode="Password"></asp:TextBox>
                    <br/> 
                    <asp:RegularExpressionValidator style="color: Red; margin-left: -19%; margin-top: 9%; position: absolute;" ValidationGroup="vgNew" ID="Regex1" runat="server" ControlToValidate="txtnewpass"
                            ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$" ErrorMessage="Password must contain: Minimum 6 characters atleast 1 uppercase,1 lowercase,1 symbol and 1 Number " ForeColor="Red" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtnewpass" ErrorMessage="!!" ForeColor="Red" 
                       ValidationGroup="vgNew" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Confirm Password : </td>
                <td class="style4">
                    <asp:TextBox ID="txtconfirmpass" runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtconfirmpass" ErrorMessage="!!" ForeColor="Red" 
                       ValidationGroup="vgNew" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtnewpass" ControlToValidate="txtconfirmpass" 
                       ValidationGroup="vgNew" ErrorMessage="  Password mismatch !!" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="btnchangepass" ValidationGroup="vgNew" runat="server" Text="Change Password" 
                        onclick="btnchangepass_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
</div>
</asp:Content>
