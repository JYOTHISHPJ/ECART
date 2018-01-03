using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.WishList;
using System.Data;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class WishListCreation : System.Web.UI.Page
    {
        public string field1;
        public int userid;
        public int id, quantity, pric, amount;
        BLWishListCreation ObjBLWishListCreation = new BLWishListCreation();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        BLWishListProperty ObjBLWishListProperty = new BLWishListProperty();
        protected void Page_Load(object sender, EventArgs e)
        {
            field1 = (string)(Session["Userid"]);


            userid = Convert.ToInt16(field1);
            if (userid == 0)
            {
                Response.Redirect("../Login/login.aspx");
            }
            if (!IsPostBack)
            {
                ds = ObjBLWishListCreation.gvWishList(userid);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    //Response.Write("<script LANGUAGE='JavaScript'>('no data found')</script>");
                    Response.Redirect("WishList.aspx");
                }
                else
                {

                    dt = ds.Tables[0];
                    gvWishList.DataSource = dt;
                    gvWishList.DataBind();
                }
            }

        }

        protected void GridView1_SelectedIndexChanged1(object sender, GridViewCommandEventArgs e)
        {
            //if(e.CommandName=="AddToCart")
            //{

            //}
        }

        protected void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet Ds11 = new DataSet();

            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            ObjBLWishListProperty.id = Convert.ToInt32(field1);
            ObjBLWishListProperty.proName = gvRow.Cells[1].Text;
            ObjBLWishListProperty.price = Convert.ToInt32(gvRow.Cells[2].Text);
            ObjBLWishListProperty.quantity = Convert.ToInt32(gvRow.Cells[3].Text);
            ObjBLWishListProperty.amount = Convert.ToInt32(gvRow.Cells[4].Text);

            //ObjBLWishListCreation.AddToCart(ObjBLWishListProperty);

            BusinessLayerClass objBusinessLayerClass = new BusinessLayerClass();
            objBusinessLayerClass.addToCart(ObjBLWishListProperty.quantity, ObjBLWishListProperty.id);
            ObjBLWishListCreation.DeleteFromWishList(ObjBLWishListProperty);
            //use these values in query string or any logic you prefer for cross page posting
            ds = ObjBLWishListCreation.gvWishList(userid);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //Response.Write("<script LANGUAGE='JavaScript'>('no data found')</script>");
                Response.Redirect("WishList.aspx");
            }
            gvWishList.DataSource = ds.Tables[0];
            gvWishList.DataBind();

        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            DataSet Ds11 = new DataSet();

            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            ObjBLWishListProperty.id = Convert.ToInt32(field1);
            ObjBLWishListProperty.proUrl = gvRow.Cells[0].Text;
            ObjBLWishListProperty.proName = gvRow.Cells[1].Text;
            ObjBLWishListProperty.price = Convert.ToInt32(gvRow.Cells[2].Text);
            ObjBLWishListProperty.quantity = Convert.ToInt32(gvRow.Cells[3].Text);
            ObjBLWishListProperty.amount = Convert.ToInt32(gvRow.Cells[4].Text);




            ObjBLWishListCreation.remove(ObjBLWishListProperty);
            //use these values in query string or any logic you prefer for cross page posting
            ds = ObjBLWishListCreation.gvWishList(userid);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            dt = ds.Tables[0];
            gvWishList.DataSource = dt;
            gvWishList.DataBind();
        }


    }
}