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
    public partial class UserManagement : System.Web.UI.Page
    {
        Manager Manager_obj = new Manager();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet ds2 = new DataSet();
            ds2 = Manager_obj.userdetails();
            dtg.DataSource = ds2;
            dtg.DataBind();
        }



        public void deactivate(object sender, EventArgs e)
        {
            GridViewRow dtg_edit = (GridViewRow)((LinkButton)sender).NamingContainer;
            string id = dtg_edit.Cells[1].Text;
            if (dtg_edit.Cells[10].Text == "T")
            {
                int result = Manager_obj.deactivate(id);
                if (result == 1)
                {
                    Response.Write("<Script LANGUAGE='JavaScript'>alert('USER DEACTIVATED')</script>");
                    DataSet ds2 = new DataSet();
                    ds2 = Manager_obj.userdetails();
                    dtg.DataSource = ds2;
                    dtg.DataBind();
                }
            }
            else
            {
                Response.Write("<Script LANGUAGE='JavaScript'>alert('USER ALREADY DEACTIVATED')</script>");
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtg.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = Manager_obj.userdetails();
            dtg.DataSource = ds;
            dtg.DataBind();
        }
    
    
    
    }
}