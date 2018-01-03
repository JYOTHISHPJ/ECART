using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace PresentationLayer
{
    public partial class Forgetpassword : System.Web.UI.Page
    {
        ForgetDetails objForgetDetails = new ForgetDetails();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();


                objForgetDetails.emailid = txtEmail.Text;

                ds = objForgetDetails.GetData(objForgetDetails);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress(txtEmail.Text);
                    // Recipient e-mail address.
                    Msg.To.Add(txtEmail.Text);
                    Msg.Subject = "Your Password Details";
                    // Msg.Body = "Hi,<br/><br/> Greetings!<br/>You are just a step away from accessing your Ecart account<br/><br/> The following email was sent to you by Ecart. <br/>Please check your Login Details<br/><br/><b>Your Username: " + ds.Tables[0].Rows[0]["Username"] + "<br/><br/>Your Password: " + ds.Tables[0].Rows[0]["Password"] + "<br/></b><br/>";
                    Msg.Body = "Hi,<br/><br/> Greetings!<br/>You are just a step away from accessing your Ecart account<br/><br/> The following email was sent to you by Ecart. <br/>Please check your Login Details<br/><br/><b>Your Username: " + ds.Tables[0].Rows[0]["TU_USER_NAME"] + "<br/><br/>Your Password: " + ds.Tables[0].Rows[0]["TU_PASSWORD"] + "<br/></b><br/>";
                    Msg.Body += "<br/><br/>If you did not make this request, you can ignore this message and your password will remain the same.<br/><br/>Best Regards , <br/> Team Ecart<br/>";
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("assuretechecart@gmail.com", "assuretechecart@2016");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    //Msg = null;
                    lbltxt.Text = "Your Password Details Has Been Sent To Your Mail";
                    // Clear the textbox valuess
                    txtEmail.Text = "";
                }
                else
                {
                    lbltxt.Text = "The Email You Entered Doesnt Exists.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }

        }
    }
}