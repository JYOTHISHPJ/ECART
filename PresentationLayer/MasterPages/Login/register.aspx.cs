using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PresentationLayer
{
    public partial class CartRegister : System.Web.UI.Page
    {
        public int status;

        BussinessLayerClass objBusinessLayerClass = new BussinessLayerClass();
        PropertyClass objPropertyClass = new PropertyClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
           public static string CreateRandomPassword(int PasswordLength)
        {
           string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

               
  protected void btn_Register_Click(object sender, EventArgs e)
   {



            string onetime = CreateRandomPassword(5);
      
            int otp=Convert.ToInt32(onetime);
              
           DataSet ds = new DataSet();

            objPropertyClass.name = txt_Username.Text;
            objPropertyClass.address = txt_Address.Text;
            objPropertyClass.mobno = txt_Mobno.Text;
           

            objPropertyClass.mail = txt_Email.Text;
           objPropertyClass.password = txt_Password.Text;
             status = objBusinessLayerClass.register(objPropertyClass,otp);
             if (status == 3)
             {
                 Label6.Visible = true;
                 Label6.Text = "Email id already exists";
                 txt_Email.Text = null;
             }
            

             else if (status == 1)
            {
                Label6.Visible = true; 
                Label6.Text = "register success";
                Response.Redirect("~/Transaction/AccountActivation.aspx?pEMAIL=" + txt_Email.Text);
            }
            else 
            {
                Label6.Visible = true; 
                Label6.Text = "register not success";
            }
        }
        }
    }

