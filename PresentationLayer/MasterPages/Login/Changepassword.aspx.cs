using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Configuration;
using BusinessLayer;


namespace PresentationLayer
{
    public partial class Changepassword : System.Web.UI.Page
    {
        public string curpassword, newpassword;
        ChangeDetails objChangeDetails = new ChangeDetails();
      string field1;
      int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                field1 = (string)(Session["Userid"]);
                userid = Convert.ToInt16(field1);

     
            
        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            int status;
            objChangeDetails.curpassword = txtcurrentpass.Text;
            objChangeDetails.newpassword = txtnewpass.Text;
            lblmsg.Text = "";
            DataSet ds = new DataSet();
           // DataTable dt = new DataTable();
            ds = objChangeDetails.GetData(objChangeDetails);

       

           
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblmsg.Text = "Invalid current password";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                status = objChangeDetails.RunQuery(objChangeDetails, userid);

          
                if (status == 1)
                {
                    lblmsg.Text = "Password changed successfully";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblmsg.Text = " password not changed ..try again";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}

