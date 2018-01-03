<%@ Page  EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Slider.aspx.cs" Inherits="PresentationLayer.Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
     
  <script type="text/javascript">
      function sample() {
          setInterval(repeat, 1500);
      }
      function repeat() {
          //find button
          var objButton = document.getElementById("cphBody_btnCallCSFunction");
          //Call server side button click
          objButton.click(); //It will call server side event btnCallCSFunction_Click
      }
      window.onload = function () {
          sample();
      }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
  
    <ul runat="server" style="list-style-type:none">
        <li>
            <asp:ImageButton ID="PrevImgBtn" runat="server" Height="241px" ImageUrl="~/PageImages/leftbutton.jpg" Width="100px" style="position:absolute;margin-top:3%; top: 226px; left: 18px;" OnClick="PrevImgBtn_Click"/>
        </li>
        <li>

             <asp:ImageButton ID="NextImagetn" runat="server" Height="241px"  ImageUrl="~/PageImages/rightbutton.jpg" Width="100px" style="margin-left:75%;position:absolute; top: 262px; left: 181px;" OnClick="NextImagetn_Click"/>
        </li>
       
              <asp:UpdatePanel runat="server" id="upDate" EnableViewState="false">   
                  <ContentTemplate>    
        <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_OnItemDataBound" OnItemCommand="rptImages_ItemCommand">
       
            <ItemTemplate> 
                
                    <li  class="inactive" runat="server" id="li">
                    
                         <%--OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("TS_IMAGE_URL") %>'--%>
                    
                    <asp:ImageButton ID="SL" runat="server"  CommandName="ImageClick" CommandArgument='<%# Eval("TS_IMAGE_URL") %>' style='height: 250px; width:59%;margin-left:21%;margin-top:5%'  ImageUrl='<%# Eval("TS_IMAGE_URL") %>' />
     
                   </li>
            </ItemTemplate>
              
        </asp:Repeater>
          </ContentTemplate> 
                <Triggers>
               <asp:AsyncPostBackTrigger ControlID="PrevImgBtn" />
               <asp:AsyncPostBackTrigger ControlID="NextImagetn" />
               <asp:AsyncPostBackTrigger ControlID="btnCallCSFunction" />

           </Triggers>
       </asp:UpdatePanel> 
    </ul>
     <div style="display:none;">


<asp:Button ID="btnCallCSFunction" runat="server"


Text="This button will not shown on screen" onclick="btnCallCSFunction_Click"/>


</div>
</asp:Content>
