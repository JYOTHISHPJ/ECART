using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer.quickcart;
namespace PresentationLayer
{
    public partial class QuickCartPage : System.Web.UI.Page
    {
        public string field1;
        public int userid;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        BLQuickCart ObjBLQuickCart = new BLQuickCart();
        BLQuickCartProperty objBLQuickCartProperty = new BLQuickCartProperty();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                {
                    //Session["Userid"] = 1;
                    field1 = (string)(Session["Userid"]);
                    userid = Convert.ToInt16(field1);
                    //  userid = 1;
                    ds = ObjBLQuickCart.QuickCart(userid);

                    //ObjBLQuickCart.amount = Convert.ToInt32(gvRow.Cells[5].Text);
                    ds1 = ObjBLQuickCart.totalamt(userid);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    string t = ds1.Tables[0].Rows[0]["sum(TCT_AMOUNT)"].ToString();

                    if (dt.Rows.Count == 0)
                    {

                        //Label mpLabel = (Label)Master.FindControl("");
                        // mpLabel.Text = "no data found";
                        //Response.Redirect("../Transaction/Slider.aspx");
                        //Response.Write("<Script LANGUAGE='JavaScript'>alert('no data found')</script>");
                        lbl_total.Visible = false;
                        btnProceed.Visible = false;
                        lbl1.Visible = false;
                        dt = ds.Tables[0];
                        gvQuickCart.DataSource = dt;
                        gvQuickCart.DataBind();
                    }
                    else
                    {

                        dt = ds.Tables[0];
                        gvQuickCart.DataSource = dt;
                        gvQuickCart.DataBind();
                        lbl_total.Text = t;

                    }

                }


            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Session["Userid"] != null)
            {
               // userid = 1;
                int result = ObjBLQuickCart.AddToorderList(Convert.ToInt32(Session["Userid"].ToString()));
                if (result == 1)
                {
                    Response.Write("inserted");
                    Response.Redirect("~/Transaction/Billing.aspx");
                }
                else
                {
                    Response.Write("failed");
                }
            }
            else
            {
                //Response.Write("plzz login");
                Response.Redirect("..Login/login.aspx");
            }
        }


        protected void btDel_Click(object sender, EventArgs e)
        {


            field1 = (string)(Session["Userid"]);
            userid = Convert.ToInt16(field1);
            DataSet Ds11 = new DataSet();

            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            objBLQuickCartProperty.id = Convert.ToInt32(field1);
            objBLQuickCartProperty.proName = gvRow.Cells[1].Text;


            ObjBLQuickCart.removeFromCart(objBLQuickCartProperty);
            //use these values in query string or any logic you prefer for cross page posting
            ds = ObjBLQuickCart.QuickCart(userid);
            ds1 = ObjBLQuickCart.totalamt(userid);
            DataTable dt = new DataTable();
            // dt = ds.Tables[0];
            string t = ds1.Tables[0].Rows[0]["sum(TCT_AMOUNT)"].ToString();
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                lbl_total.Visible = false;
                btnProceed.Visible = false;
                lbl1.Visible = false;
                dt = ds.Tables[0];
                gvQuickCart.DataSource = dt;
                gvQuickCart.DataBind();
            }
            gvQuickCart.DataSource = dt;
            gvQuickCart.DataBind();
            lbl_total.Text = t;

        }

        protected void gvQuickCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}