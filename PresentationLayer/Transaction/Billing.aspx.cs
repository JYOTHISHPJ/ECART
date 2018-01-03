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
    public partial class Billing : System.Web.UI.Page
    {
        BusOrder objbusorder=new BusOrder();
        BusOrderProper objbusproper =new BusOrderProper();
        string field1;
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                field1 = (string)(Session["Userid"]);
                userid = Convert.ToInt16(field1);

                if (Session["Userid"] == null)
                {
                    Response.Redirect("~/Login/login.aspx");
                }
                else
                {
                    if (!this.IsPostBack)
                    {
                        DataSet dt = new DataSet();
                        DataTable dt1 = new DataTable();
                        //   DataTable dt2 = new DataTable();
                        dt = objbusorder.order(userid);
                        dt1 = dt.Tables[0];
                        //  dt = objbusorder.build();
                        //   dt2 = dt.Tables[0]
                     gvOrder.DataSource = dt1;
                     gvOrder.DataBind();

                        if (dt1.Rows.Count == 0)
                        {
                            Image1.Visible = true;
                        }

                        //     GridView2.DataSource = dt2;
                        //     GridView2.DataBind();
                        //   GridView2.Visible = false;



                        total.Visible = false;
          
                      
                    
                    
                    
                    
                    }
               }
            }
            catch
            {

            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrder.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = objbusorder.order(userid);


            gvOrder.DataSource = ds;
            gvOrder.DataBind();
        }

        protected void OnPageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            gvOrderDetails.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = objbusorder.build();


            gvOrderDetails.DataSource = ds;
            gvOrderDetails.DataBind();
        }
        protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    
        protected void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

          
             //   GridView1.Visible = false;
            gvOrderDetails.Visible = true;
                total.Visible = true;


                DataSet ds1 = new DataSet();
                ds1 = objbusorder.totalamt();
                //  dt1 = ds1.Tables[0];
                string txt = ds1.Tables[0].Rows[0]["sum(TOS_AMOUNT)"].ToString();


                //GridView2.DataSource = dt;

                lblTotal.Text = txt;





                // int index = Convert.ToInt32(e.CommandArgument);


                //    GridViewRow selectedRow = GridView1.Rows[index];
                //   TableCell contactName = selectedRow.Cells[1];
                //  string contact = contactName.Text;

                // Display the selected author.
                //   Message.Text = "You selected " + contact + ".";


        }
        public void lnkView_Click(object sender, EventArgs e)
        {
            try
            {
                gvOrder.Visible = false;
               
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
                string rownum = grdrow.Cells[0].Text;
                string date = grdrow.Cells[1].Text;
                string status = grdrow.Cells[2].Text;
                objbusorder.referene(rownum);
                gvOrderDetails.Visible = true;


                DataSet dt = new DataSet();

                DataTable dt2 = new DataTable();

                dt = objbusorder.build();
                dt2 = dt.Tables[0];
                if(dt2.Rows.Count==0)
                {
                    Image1.Visible = true;
                }

                gvOrderDetails.DataSource = dt2;
                gvOrderDetails.DataBind();
                
              //  GridView2.Visible = false;
            }
            catch
            {
               
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string rownum = grdrow.Cells[0].Text;
            int res = objbusorder.Cancel(rownum);
            DataSet dt = new DataSet();

            DataTable dt2 = new DataTable();

            dt = objbusorder.order(userid);
            dt2 = dt.Tables[0];


            gvOrder.DataSource = dt2;
            gvOrder.DataBind();


          /*  if (res == 1)
            {
                Response.Write("<script> alert('Ordered Cancelled Succesfully') </script>");
                
            }
            else
                Response.Write("<script> alert('Ordered Cannot Be Cancelled') </script>");*/
        }
        protected void gvOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
       
    }
}