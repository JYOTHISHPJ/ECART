using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text.RegularExpressions;
namespace PresentationLayer.MasterPages
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        public int userid;
        public string field1;
        public  static string txt;
        
        MasterBusiness ObjMasterBusiness = new MasterBusiness();
      
        public TextBox txtSearch;
        protected void Page_Load(object sender, EventArgs e)
        {
            field1 = (string)(Session["Userid"]);
            userid = Convert.ToInt32(field1);

            if (userid != 0)
            {
                string username = ObjMasterBusiness.GetUsername(userid);
                btndropdown.InnerText = "Hello "+username;
            }
 
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
            string SearchText = txtSearch.Text.ToUpper().Trim();
            Regex regex = new Regex(@"\s{2,}");
            string text = regex.Replace(SearchText.Trim(), " ");
            Response.Redirect("~/ProductListing/ProductListing.aspx?searchtext="+text);
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAdmin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Transaction/adminlogin.aspx");
        }

        protected void imgbtnCartLogo_Click(object sender, ImageClickEventArgs e)
        {
            if (userid == 0)
            {
                Response.Redirect("~/Login/login.aspx");
            }

            else
                Response.Redirect("~/Transaction/QuickCartPage.aspx");
        }

        protected void lbtnSignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Transaction/Slider.aspx");
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductListing/ProductListing.aspx?searchtext=All");
        }

        protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Transaction/Slider.aspx");
        }    

    }


}