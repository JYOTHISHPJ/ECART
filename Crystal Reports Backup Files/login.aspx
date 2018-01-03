<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PresentationLayer.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 
    <form id="form1" runat="server">
   
                    
      <div class="samplecss" runat="server" style="margin-left:400px; margin-top:150px; background-color:#DCD0C0; height: 337px; width: 412px;background: url(a.jpg) no-repeat ; -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;">
                    <br/>
                    <br />
          <fieldset>
                    <h1 style="font-family:Rockwell; font-size: x-large;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LOGIN</h1>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text= "E-mail" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txt_Email" runat="server" CssClass="roundedcorner" Style="margin-left: 56px; margin-top: 23px;" Width="122px" ToolTip="Enter Username"></asp:TextBox>
                         
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txt_Email" ForeColor="Red" ErrorMessage="Invalid email address." />
                    </div>

                    <div>
                    </div>
                      <div>
                    <%--<div class="loginbuttonbox" style="border: 0px; color: #fff; text-shadow: 0 1px rgba(0,0,0,0.1);">--%>
                        <asp:Label ID="Label2" runat="server" Text="Password" style="margin-left:30px" ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txt_Password" runat="server" CssClass="roundedcorner" Style="margin-left: 36px; margin-top: 8px;" Width="122px" TabIndex="1" TextMode="Password" ToolTip="Enter Password" MaxLength="15"></asp:TextBox>
                    </div>
                  <div>
                        <asp:Button ID="btn_Login" runat="server" CssClass="roundedcorner" Text="Login"  Style="margin-left: 137px; margin-top: 30px;" Width="82px" TabIndex="3" ToolTip="Click to login" Height="30px" BackColor="#0099FF" OnClick="btn_Login_Click" />
                 
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                      <a href="Forgetpassword.aspx">Forgot Password</a>

                  </div>
          <div></div>
          

            
              </fieldset>
                         
                 <div>
          <asp:Label ID="Label4" runat="server" Text="Label" Visible="false" ></asp:Label>
    </div>
          </div>
    </form>
</body>
</html>
