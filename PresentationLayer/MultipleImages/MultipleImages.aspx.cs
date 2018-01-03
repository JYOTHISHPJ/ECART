using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using BusinessLayer.MultipleImagesBL;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class MultipleImages : System.Web.UI.Page
    {
        MultipleImagesBLClass objMultipleImagesBLClass = new MultipleImagesBLClass();
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        DataSet dt1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnShowImages_Click(object sender, EventArgs e)
        {
            dt1 = objMultipleImagesBLClass.ShowMultipleImages();
            dlMultipleImages.DataSource = dt1;
            dlMultipleImages.DataBind();
            Session["imgUrl"] = dt1.Tables[0].Rows[0]["TI_IMAGE_URL"].ToString();
        }

        protected void imMultipleImages_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objBusinessLayerClass.productId((string)Session["imgUrl"]);
            if (dt.Rows.Count > 0)
                Response.Redirect("../Transaction/AddToCart.aspx");
        }
    }
}