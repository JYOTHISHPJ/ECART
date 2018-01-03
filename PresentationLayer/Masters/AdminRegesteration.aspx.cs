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
    public partial class AdminRegesteration : System.Web.UI.Page
    {
        Business_Property Business_Property_obj = new Business_Property();
        Manager Manager_obj = new Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Manager_obj.Gridadmin();
            dtg.DataSource = ds;
            dtg.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "SAVE")
            {
                Business_Property_obj.admin_user = txt_user.Text;
                Business_Property_obj.admin_pass = txt_pass.Text;
                DataSet D1 = new DataSet();
                D1 = Manager_obj.admincheck(Business_Property_obj);
                DataTable DT = new DataTable();
                DT = D1.Tables[0];
                if (DT.Rows.Count == 0)
                {
                    int result = Manager_obj.adminentry(Business_Property_obj);
                    if (result == 1)
                    {
                        Response.Write("<Script LANGUAGE='JavaScript'>alert('success')</script>");
                        DataSet ds = new DataSet();
                        ds = Manager_obj.Gridadmin();
                        dtg.DataSource = ds;
                        dtg.DataBind();
                    }
                }
                else
                {
                    Response.Write("<Script LANGUAGE='JavaScript'>alert('Entry Already Exists')</script>");
                }
            }

            else
            {
                Business_Property_obj.admin_user = txt_user.Text;
                Business_Property_obj.admin_pass = txt_pass.Text;
                int result1 = Manager_obj.admiupdate(Business_Property_obj);
                if (result1 == 1)
                {
                    Response.Write("<Script LANGUAGE='JavaScript'>alert('success')</script>");
                    DataSet ds = new DataSet();
                    ds = Manager_obj.Gridadmin();
                    dtg.DataSource = ds;
                    dtg.DataBind();
                    btn_save.Text = "SAVE";
                }
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_user.Enabled = true;
            txt_user.Text = String.Empty;
            txt_pass.Text = String.Empty;
        }
        public void edit(object sender, EventArgs e)
        {
            txt_user.Enabled = false;
            GridViewRow dtg_edit = (GridViewRow)((LinkButton)sender).NamingContainer;
            txt_user.Text = dtg_edit.Cells[2].Text;
            txt_pass.Text = dtg_edit.Cells[3].Text;
            btn_save.Text = "UPDATE";
        }
        public void DELETE(object sender, EventArgs e)
        {
            GridViewRow dtg_edit = (GridViewRow)((LinkButton)sender).NamingContainer;
            string admndele = txt_user.Text = dtg_edit.Cells[2].Text;
            Manager_obj.admdelete(admndele);
            DataSet ds1 = new DataSet();
            ds1 = Manager_obj.Gridadmin();
            dtg.DataSource = ds1;
            dtg.DataBind();
        }
    }
}