using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Web.UI.HtmlControls;
using BusinessLayer.HomePageBL;

namespace PresentationLayer
{
    public partial class Slider : System.Web.UI.Page
    {
        HomePageBLClass objHomePageBLClass = new HomePageBLClass();
        DataSet dt1, dt2;
        public static int i = 0;
        MasterBusiness ObjMasterBusiness = new MasterBusiness();
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //HtmlGenericControl body = this.Master.FindControl("body") as HtmlGenericControl;

            //body.Attributes.Add("onload", "sample()");
            //ClientScript.RegisterStartupScript(GetType(), "hiya", "sample();", true);
            DataSet dS = new DataSet();
            dS = ObjMasterBusiness.SelectSlider();
            rptImages.DataSource = dS;
            rptImages.DataBind();
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


        protected void rptImages_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemIndex == i)
                e.Item.Visible = true;
            else
                e.Item.Visible = false;
        }


        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            //DataSet dt = ObjMasterBusiness.SelectSlider();
            //if (i > 0)
            //    i = i - 1;
            //else
            //    i = dt.Tables[0].Rows.Count - 1;
            //rptImages.DataSource = dt;
            //rptImages.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            //DataSet dt = ObjMasterBusiness.SelectSlider();
            //if (i < dt.Tables[0].Rows.Count-1)

            //    i = i + 1;
            //else
            //    i = 0;
            //rptImages.DataSource = dt;
            //rptImages.DataBind();
        }

        protected void rptImages_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        Response.Redirect("AddToCart.aspx");
                    //Write some code for what you need 
                    else
                        Response.Redirect("../Login/login.aspx");

                }
            }
        }
        protected void PrevImgBtn_Click(object sender, EventArgs e)
        {
            fnprev();
        }


        protected void NextImagetn_Click(object sender, EventArgs e)
        {
            fnNext();
        }
        public void fnNext()
        {
            DataSet dt = new DataSet();
            dt = ObjMasterBusiness.SelectSlider();
            if (i < dt.Tables[0].Rows.Count - 1)

                i = i + 1;
            else
                i = 0;
            rptImages.DataSource = dt;
            rptImages.DataBind();
        }
        public void fnprev()
        {

            DataSet dt = new DataSet();
            dt = ObjMasterBusiness.SelectSlider();
            if (i > 0)
                i = i - 1;
            else
                i = dt.Tables[0].Rows.Count - 1;
            rptImages.DataSource = dt;
            rptImages.DataBind();


        }
        protected void btnCallCSFunction_Click(object sender, EventArgs e)
        {
            fnNext();
        }
        protected void Image_Click(object sender, CommandEventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                if (e.CommandName == "ImageClick")
                {
                    string imgurl = e.CommandArgument.ToString().Trim().Split('/').Last(); /*   Getting image Url   */
                    ObjMasterBusiness.productId(imgurl);
                    Response.Redirect("~/Transaction/AddToCart.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void dlFeaturedProducts_SelectedIndexChanged(object sender, DataListCommandEventArgs e)
        {

        }

        protected void dlLatestProducts_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void dlFeaturedProducts_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    if (e.CommandName == "ImageClick") // check command is cmd_delete
            //    {
            //        // get you required value
            //        //int CustomerID = Convert.ToInt32(e.CommandArgument);
            //        string imgurl = e.CommandArgument.ToString().Trim().Split('/').Last(); /*   Getting image Url   */
            //        dt = objBusinessLayerClass.productId(imgurl);
            //        if (dt.Rows.Count > 0)
            //            Response.Redirect("~/Transaction/AddToCart.aspx");
            //        //Write some code for what you need 
            //        else
            //            Response.Redirect("~/Slider.aspx");

            //    }
            //}
        }

        protected void dlFeaturedProducts_ItemCommand(object source, DataListCommandEventArgs e)
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
                        Response.Redirect("~/Transaction/Slider.aspx");

                }
            }
        }

        protected void dlLatestProducts_ItemCommand(object source, DataListCommandEventArgs e)
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
                        Response.Redirect("~/Transaction/Slider.aspx");

                }
            }
        }

    }

}
