using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer;
using System.Net;
using System.Net.Mail;
namespace PresentationLayer
{
    public partial class AccountActivation : System.Web.UI.Page
    {
        string sEmail;
        string varOTP;

        public void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                first.Visible = true;
                second.Visible = false;
            }
        }

        public void SendCode_Click(object sender, EventArgs e)
        {
            BusActivation objbuss = new BusActivation();
            try
            {
         
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                ds = objbuss.active(Request.QueryString["pEMAIL"]);
                 Session["OTP"]= ds.Tables[0].Rows[0]["TU_OTP"].ToString();
                dt1 = ds.Tables[0];
                ds = objbuss.send(Request.QueryString["pEMAIL"]);
                dt2 = ds.Tables[0];
                sEmail = ds.Tables[0].Rows[0]["TU_EMAIL_ID"].ToString();
             

                if (dt1.Rows.Count > 0)
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress(sEmail);
                    // Recipient e-mail address.
                    Msg.To.Add(sEmail);
                    Msg.Subject = "Your activation code";
                    Msg.Body = "Hi,<br/><br/> Greetings!<br/>You are just a step away from accessing your Ecart account<br/><br/> The following email was sent to you by Ecart. <br/>Please check your Login Details<br/><br/><b>Your Username: " + dt1.Rows[0]["TU_USER_NAME"] + "<br/><br/>Your activation code: " + dt1.Rows[0]["TU_OTP"] + "<br/></b><br/>";

                    Msg.Body += "<br/><br/>If you did not make this request, you can ignore this message.<br/><br/>Best Regards , <br/> Team Ecart<br/>";
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("assuretechecart@gmail.com", "assuretechecart@2016");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                 
                    lbltxt.Text = "**your activation code Details Sent to your mail";
                    first.Visible = false;
                    second.Visible = true;
                   
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }

        public void ConfirmCode_Click(object sender, EventArgs e)
        {
            BusActivation objbuss = new BusActivation();
            string txt = txt_Act.Text;
            varOTP = Session["OTP"].ToString();
            if (varOTP == txt)
          {
              objbuss.update(Request.QueryString["pEMAIL"]);
              //Response.Redirect("../Transaction/Slider.aspx");
              Response.Redirect("../Login/login.aspx");
          }
          else
          {
              lbltxt.Text = "The activation code you entered not exists.";
         
          
          }

        }
    }
}