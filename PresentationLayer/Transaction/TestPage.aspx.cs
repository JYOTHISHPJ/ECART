using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Text.RegularExpressions;


namespace PresentationLayer.PresentationLayer
{
    public partial class TestPage : System.Web.UI.Page
    {
        BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void iphone6_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                string imgurl = iphone6.ImageUrl.Trim().Split('/').Last(); /*   Getting image Url   */
                dt = objBusinessLayerClass.productId(imgurl);
                Server.Transfer("AddToCart.aspx");
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}