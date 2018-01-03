<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PresentationLayer.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
       

    </title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="samplecss" runat="server" style="margin-left:400px; margin-top:150px; background-color:#DCD0C0; height: 337px; width: 412px;background: url(a.jpg) no-repeat ; -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Label ID="Label7" runat="server" Text="WELCOME TO ECART" Font-Bold="True" Font-Italic="False" ForeColor="#0099FF"></asp:Label>

                    <br/>
                    <br />

          <fieldset>
    <div>
     <h1 style="font-family:Rockwell; font-size: x-large;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Register</h1>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text= "Username" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        &nbsp;<asp:TextBox ID="txt_Username" runat="server" CssClass="roundedcorner" Style="margin-left: 56px; margin-top: 23px;" Width="122px" ToolTip="Enter Username"></asp:TextBox>
                     
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txt_Username"
                runat="server" />
        </div>

                    <div>
                    </div>
         <div>
                        <asp:Label ID="Label2" runat="server" Text= "Address" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        &nbsp;<asp:TextBox ID="txt_Address" runat="server" CssClass="roundedcorner" Style="margin-left: 71px; margin-top: 23px;" Width="122px" ToolTip="Enter Address"></asp:TextBox>
                     
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txt_Username"
                runat="server" />
        </div><div></div>
        <div> <asp:Label ID="Label3" runat="server" Text= "Mobile No" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        &nbsp;<asp:TextBox ID="txt_Mobno" runat="server" CssClass="roundedcorner" Style="margin-left: 56px; margin-top: 23px;" Width="122px" ToolTip="Enter mbno" MaxLength="10" ></asp:TextBox>
                     
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txt_Mobno"
runat="server" />
          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ValidationExpression="^[0-9]{7,10}$"
      ControlToValidate="txt_Mobno" ForeColor="Red" ErrorMessage="invalid"  ></asp:RegularExpressionValidator>--%>
</div><div></div>
 <div><asp:Label ID="Label4" runat="server" Text= "E-mail" style="margin-left:30px" ForeColor="Black"></asp:Label>
                   
   &nbsp; <asp:TextBox ID="txt_Email" runat="server" CssClass="roundedcorner" Style="margin-left: 76px; margin-top: 23px;" Width="122px" ToolTip="Enter Username"> </asp:TextBox>
              <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txt_Email" runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txt_Email" ForeColor="Red" ErrorMessage="Invalid" />
                    </div>     <div></div>
      <br/>
     <div> <asp:Label ID="Label5" runat="server" Text="Password" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        &nbsp;<asp:TextBox ID="txt_Password" runat="server" CssClass="roundedcorner" Style="margin-left: 60px; margin-top: 8px;" Width="122px" TabIndex="1" TextMode="Password" ToolTip="Enter Password" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txt_Password"
                runat="server" /> 

      </div>
                  <div>
                        <asp:Button ID="btn_Register" runat="server" CssClass="roundedcorner" Text="register"  Style="margin-left: 165px; margin-top: 30px;" Width="82px" TabIndex="3" ToolTip="Click to login" Height="30px" BackColor="#0099FF" OnClick="btn_Register_Click" />
                </div>
   
        <asp:Label ID="Label6" runat="server" Text="Label"  Visible="false"></asp:Label>
    </div>
              </fieldset></div>
    </form>
</body>
</html>
