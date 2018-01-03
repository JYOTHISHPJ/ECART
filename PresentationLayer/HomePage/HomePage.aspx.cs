using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer.HomePageBL;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class HomePage : System.Web.UI.Page
    {
        HomePageBLClass objHomePageBLClass = new HomePageBLClass();
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        DataSet dt1, dt2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt1 = objHomePageBLClass.BindGridFeaturedProducts();
                dlFeaturedProducts.DataSource = dt1;
                dlFeaturedProducts.DataBind();

                dt2 = objHomePageBLClass.BindGridLatestProducts();
                dlLatestProducts.DataSource = dt2;
                dlLatestProducts.DataBind();
            }
        }

        protected void dlFeaturedProducts_SelectedIndexChanged(object sender, DataListCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "ImageClick") // check command is cmd_delete
                {
                    // get you required value
                    //int CustomerID = Convert.ToInt32(e.CommandArgument);
                    string imgurl = e.CommandArgument.ToString().Trim().Split('/').Last(); /*   Getting image Url   */
                    dt = objBusinessLayerClass.productId(imgurl);
                    if (dt.Rows.Count > 0)
                        Response.Redirect("~/Transaction/AddToCart.aspx");
                    //Write some code for what you need 
                    else
                        Response.Redirect("~/Slider.aspx");

                }
            }
        }

        protected void dlLatestProducts_SelectedIndexChanged(object sender, DataListCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "ImageClick") // check command is cmd_delete
                {
                    // get you required value
                    //int CustomerID = Convert.ToInt32(e.CommandArgument);
                    string imgurl = e.CommandArgument.ToString().Trim().Split('/').Last(); /*   Getting image Url   */
                    dt = objBusinessLayerClass.productId(imgurl);
                    if (dt.Rows.Count > 0)
                        Response.Redirect("~/Transaction/AddToCart.aspx");
                    //Write some code for what you need 
                    else
                        Response.Redirect("~/Slider.aspx");

                }
            }

        }
    }
}