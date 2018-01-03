using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public static class usersession
    {

        public static string userid
        {

            get
            {
                if (HttpContext.Current.Session["Userid"] != null)
                    return HttpContext.Current.Session["Userid"].ToString();
                else
                    return string.Empty;

            }
            set { HttpContext.Current.Session["Userid"] = value; }
        }
    }
    public partial class CartLogin : System.Web.UI.Page
    {
        SessionClass objSessionClass = new SessionClass();

        BussinessLayerClass objBussinessLayerClass = new BussinessLayerClass();

        public string Email1, Password1;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string prodId = (string)(Session["productIdAddToCart"]);
            Email1 = txt_Email.Text;
            Password1 = txt_Password.Text;
            objSessionClass = objBussinessLayerClass.login(Email1, Password1);
            if (objSessionClass.status == 1)
            {
                usersession.userid = objSessionClass.sn_userid;
                HttpContext.Current.Session["Userid"] = objSessionClass.sn_userid;
                Label4.Visible = true;

                Label4.Text = "login success";
                if (!string.IsNullOrEmpty(prodId))
                    Response.Redirect("../Transaction/AddToCart.aspx");
                else
                    Response.Redirect("../Transaction/Slider.aspx");
            }

            if (objSessionClass.status == 2)
            {
                Response.Redirect("../Transaction/AccountActivation.aspx?pEMAIL=" + txt_Email.Text);  
            }
            else
            {
                Label4.Visible = true;
                Label4.Text = ("Invalid Login");

            }


        }

    }
}