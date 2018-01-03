using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using BusinessLayer.WishList;

namespace PresentationLayer.PresentationLayer
{
    public partial class AddToCart : System.Web.UI.Page
    {
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        DataTable dt = new DataTable();
        string field1;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            Label1.Text = "0 Users have rated this Product";
            Label2.Text = "Average rating for this Product is 0";
            if (!IsPostBack)
            {
                try
                {
                    dt = objBusinessLayerClass.getProductDetails();
                    Session["Product"] = dt.Rows[0]["TP_PRODUCT_ID"].ToString();
                    string imgUrl = dt.Rows[0]["TI_IMAGE_URL"].ToString();
                    imgUrl = "~/Images/" + imgUrl;
                    product_image.ImageUrl = imgUrl;
                    product_Name.InnerText = dt.Rows[0]["TP_PRODUCT_NAME"].ToString();
                    product_price.InnerText = "PRICE :  " + dt.Rows[0]["TP_PRICE"].ToString();
                    dt1 = objBusinessLayerClass.findQuantity();
                    if (Convert.ToInt32(dt1.Rows[0]["TP_QUANTITY"].ToString()) > 0)
                        product_quantity.InnerText = "QUANTITY Available : " + dt.Rows[0]["TP_QUANTITY"].ToString();
                    else
                        product_quantity.InnerText = "QUANTITY Available : Not In Stock";
                    int[] array = { 1, 2, 3, 4, 5 };
                    drpQuantity.DataSource = array;
                    drpQuantity.DataBind();
                    review.InnerText = "Customer Reviews On " + dt.Rows[0]["TP_PRODUCT_NAME"].ToString();

                    DataSet dsFeature = new DataSet();
                    dsFeature = objBusinessLayerClass.getFeatures(Session["Product"].ToString());
                    lblFeatures.Text = "FEATURES : " + dsFeature.Tables[0].Rows[0]["TF_FEATURES"].ToString();

                    DataSet ds = new DataSet();
                    ds = objBusinessLayerClass.productImages();
                    dlMultipleImagesShow.DataSource = ds;
                    dlMultipleImagesShow.DataBind();

                    DataTable dtComments = new DataTable();
                    dtComments = objBusinessLayerClass.getComments(Session["Product"].ToString());
                    if (dtComments.Rows.Count != 0)
                    {
                        lblShowComments1.Text = dtComments.Rows[0]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[0]["TU_USER_NAME"];
                        if (dtComments.Rows.Count > 1)
                        {
                            lblShowComments2.Text = dtComments.Rows[1]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[1]["TU_USER_NAME"];
                            if (dtComments.Rows.Count > 2)
                                lblShowComments3.Text = dtComments.Rows[2]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[2]["TU_USER_NAME"];
                        }
                    }
                    BindRatings();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                }
            }

        }

        protected void btnaddtocart_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            field1 = (string)(Session["Userid"]);
            int userid = Convert.ToInt32(field1);
            try
            {
                dt = objBusinessLayerClass.findQuantity();
                if (Convert.ToInt32(dt.Rows[0]["TP_QUANTITY"].ToString()) > 0)
                {
                    if (!string.IsNullOrEmpty(field1))
                    {
                        int productQuantity = Convert.ToInt32(drpQuantity.SelectedValue);
                        dt = objBusinessLayerClass.addToCart(productQuantity, userid);
                        lblAddtoCart.Text = "Your Product Is Added To Cart";
                        lblAddtoCart.Visible = true;
                    }
                    else
                    {
                        dt = objBusinessLayerClass.getId();
                        Session["productIdAddToCart"] = dt.Rows[0]["TIW_PRODUCT_ID"];
                        Response.Redirect("../Login/login.aspx");
                    }
                }
                else
                    lblAddtoCart.Text = "Product Is Out Of Stock";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void Rating1_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            field1 = (string)(Session["Userid"]);
            int userid = Convert.ToInt16(field1);
            if (!string.IsNullOrEmpty(field1))
            {
                int productRating = Rating1.CurrentRating;
                string productIdGet = Session["Product"].ToString();
                objBusinessLayerClass.RatingChanged(productRating, productIdGet, userid);
                BindRatings();
            }
            else
            {
                dt = objBusinessLayerClass.getId();
                Session["productIdAddToCart"] = dt.Rows[0]["TIW_PRODUCT_ID"];
                Response.Redirect("../Login/login.aspx");
            }
        }
        public void BindRatings()
        {
            DataTable dt = new DataTable();
            int Total = 0;
            try
            {
                string productId = Session["Product"].ToString();
                dt = objBusinessLayerClass.BindRatingToPage(productId);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Total += Convert.ToInt32(dt.Rows[i][0].ToString());
                    }
                    int Average = Total / (dt.Rows.Count);
                    Rating1.CurrentRating = Average;
                    Rating2.CurrentRating = Average;
                    Label1.Text = dt.Rows.Count + " " + "Users have rated this Product";
                    Label2.Text = "Average rating for this Product is" + " " + Convert.ToString(Average);
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

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            field1 = (string)(Session["Userid"]);
            int userid = Convert.ToInt16(field1);
            if (!string.IsNullOrEmpty(field1))
            {
                if (!string.IsNullOrEmpty(txtComments.Text))
                {
                    objBusinessLayerClass.addComments(txtComments.Text, userid);
                    txtComments.Text = string.Empty;
                }
            }
            else
            {
                dt = objBusinessLayerClass.getId();
                Session["productIdAddToCart"] = dt.Rows[0]["TIW_PRODUCT_ID"];
                Response.Redirect("../Login/login.aspx");
            }
            DataTable dtComments = new DataTable();
            dtComments = objBusinessLayerClass.getComments(Session["Product"].ToString());
            if (dtComments.Rows.Count != 0)
            {
                lblShowComments1.Text = dtComments.Rows[0]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[0]["TU_USER_NAME"];
                if (dtComments.Rows.Count > 1)
                {
                    lblShowComments2.Text = dtComments.Rows[1]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[1]["TU_USER_NAME"];
                    if (dtComments.Rows.Count > 2)
                        lblShowComments3.Text = dtComments.Rows[2]["TR_COMMENTS"].ToString() + "  By " + dtComments.Rows[2]["TU_USER_NAME"];
                }
            }
            BindRatings();
        }

        protected void btnAddToWishList_Click(object sender, EventArgs e)
        {
            field1 = (string)(Session["Userid"]);
            int userid = Convert.ToInt16(field1);
            int productQuantity = Convert.ToInt32(drpQuantity.SelectedValue);
            if (!string.IsNullOrEmpty(field1))
            {
                BLwishlistcreationpage objBLwishlistcreationpage = new BLwishlistcreationpage();
                objBLwishlistcreationpage.AddToWishList(productQuantity, userid);
                lblWishlist.Text = "Product Added To Your WishList";
                lblWishlist.Enabled = true;
            }
            else
                Response.Redirect("../Login/login.aspx");
        }
        protected void imMultipleImages_Click(object sender, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ImageClick")
            {
                DataTable dt = new DataTable();
                string url = e.CommandArgument.ToString();
                product_image.ImageUrl = url;
            }
        }
    }
}