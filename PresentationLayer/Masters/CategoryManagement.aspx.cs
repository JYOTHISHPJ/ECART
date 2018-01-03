using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.CategoryManagement;
using System.Data;

namespace PresentationLayer.CategoryManagement
{
    public partial class CategoryManagement : System.Web.UI.Page
    {
        CategoryBusinessLayer objCategoryBusinessLayer = new CategoryBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
               
        }

        protected void BindData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objCategoryBusinessLayer.GetData();
            dt = ds.Tables[0];
            gvCategory.DataSource = dt;
            gvCategory.DataBind();
            ddlParentId.Items.Clear();
            ddlParentId.Items.Add("NO PARENT");
            ds = objCategoryBusinessLayer.DropDownData();
            ddlParentId.DataSource = ds;
            ddlParentId.DataTextField = "TCY_CATEGORY_ID";
            ddlParentId.DataValueField = "TCY_CATEGORY_ID";
            ddlParentId.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Clear()
        {
            txtCategoryId.Text = String.Empty;
            txtCategoryName.Text = String.Empty;
            ddlParentId.SelectedIndex = 0;
            btnInsert.Text = "INSERT";
            txtCategoryId.Enabled = true;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                TableCategory objTableCategory = new TableCategory();
                objTableCategory.CategoryId = txtCategoryId.Text;
                objTableCategory.CategoryName = txtCategoryName.Text;
                if (ddlParentId.SelectedItem.Text == "NO PARENT")
                    objTableCategory.ParentId = "";                    
                else
                    objTableCategory.ParentId = ddlParentId.SelectedItem.Value;
                int status = objCategoryBusinessLayer.RunQuery(objTableCategory,btnInsert.Text);
                BindData();
                if (status == 1)
                {
                    if (btnInsert.Text == "INSERT")
                        Response.Write("<script> alert('Category Added Succesfully') </script>");
                    else
                        Response.Write("<script> alert('Category Updated Succesfully') </script>");
                }
                else if (status == 2)
                    Response.Write("<script>alert(' Entered PARENT ID Is Not Valid...')</script>");
                else
                    Response.Write("<script>alert('Oops...Something Went Wrong...Try Again...')</script>");
                Clear();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('ERROR...Please Try Again...')</script>");
            }
        }

        protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = gvCategory.Rows[e.RowIndex].Cells[2];
            int status = objCategoryBusinessLayer.CheckCategory(cell.Text);
            if (status == 1)
            {
                Response.Write("<script>alert('ERROR...Cannot Delete CATEGORY Having Childs...')</script>");
                return;
            }
            objCategoryBusinessLayer.DeleteRow(cell.Text);
            BindData();

        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            txtCategoryId.Enabled = false;
            txtCategoryId.Text = gvr.Cells[2].Text;
            txtCategoryName.Text = gvr.Cells[3].Text;
            if (gvr.Cells[4].Text != "&nbsp;")
                ddlParentId.SelectedValue = gvr.Cells[4].Text;
            else
                ddlParentId.SelectedIndex = 0;
            btnInsert.Text = "UPDATE";
        }

        protected void gvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ACTION";
            }
        }

    }
}
