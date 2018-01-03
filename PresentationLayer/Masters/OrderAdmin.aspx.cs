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
    public partial class OrderAdmin : System.Web.UI.Page
    {
        OrderBusMaster objOrder=new OrderBusMaster();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds = objOrder.order();
                //  dt = ds.Tables[0];
                gvCategory.DataSource = ds;
                gvCategory.DataBind();
                txtUserId.Enabled = false;
                txtReference.Enabled = false;
            }

        }

        protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtReference.Text = String.Empty;
            txtUserId.Text = String.Empty;
            ddstatus.SelectedIndex = 0;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            string refno = txtReference.Text;
            string user = txtUserId.Text;
            string status = ddstatus.SelectedItem.Text;
            objOrder.update(refno, user, status);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds = objOrder.order();
            //  dt = ds.Tables[0];
            gvCategory.DataSource = ds;
            gvCategory.DataBind();


        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            txtReference.Enabled = false;
            txtReference.Text = gvr.Cells[1].Text;
            txtUserId.Text = gvr.Cells[2].Text;
     
                ddstatus.Text = gvr.Cells[3].Text;
     
                
           
        }

    }
}