using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;



namespace PresentationLayer
{
    /* public static class usersession
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
     }*/

    public partial class WishList : System.Web.UI.Page
    {
        public int aa;
        protected void Page_Load(object sender, EventArgs e)
        {
            //usersession.userid = "1";

            //  string ss = usersession.userid;
            // aa = Convert.ToInt16(login.userid);

        }

    }
}