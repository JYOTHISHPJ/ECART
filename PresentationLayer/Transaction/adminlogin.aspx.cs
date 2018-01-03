using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
namespace PresentationLayer
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string useradm, passadm;
        BusAdminLog objadmin = new BusAdminLog();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                useradm = TextBox2.Text;
                passadm = TextBox3.Text;
                

                DataSet ds= new DataSet();
                ds = objadmin.adminlogin(useradm, passadm);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    Response.Redirect("../Masters/AdminHome.aspx");
                }
                else
                {
                    Label4.Text = "The Username & Password You Enter Doesnot Exist";
                }
            }
            catch
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            TextBox2.Text = String.Empty;
            TextBox3.Text = String.Empty;
            Label4.Text = "";
        }
    }
}