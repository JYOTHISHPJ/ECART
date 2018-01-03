using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
namespace PresentationLayer
{
    public partial class Product_Manager : System.Web.UI.Page
    {
        public static string oldurl, url, sliderimagebrowse, image1browse,image2browse,productimagebrowse;
        Manager Manager_obj = new Manager();
        Business_Property Business_Property_obj = new Business_Property();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dq = new DataSet();
                dq = Manager_obj.fillcategory();
                ddl_categoryid.DataSource = dq;
                ddl_categoryid.DataTextField = "TCY_CATEGORY_ID";
                ddl_categoryid.DataBind();
                // DataSet ds = new DataSet();
                // ds = Manager_obj.getid();
                // DataTable dt = new DataTable();
                // dt = ds.Tables[0];
                // Manager_obj.Griddetails();
                DataSet ds = new DataSet();
                ds = Manager_obj.Griddetails();
                dtg.DataSource = ds;
                dtg.DataBind();
                DateTime date = DateTime.Today;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, date.Day);
                txt_datepicker.Value = firstDayOfMonth.ToString("dd-MM-yyyy");

            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (ddl_categoryid.SelectedItem.Text == "SELECT")
            {
                Response.Write("<Script LANGUAGE='JavaScript'>alert('Choose a category')</script>");
            }
            else
            {
                if (FileUpload1.HasFile)
                {

                    productimagebrowse = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Images/") + productimagebrowse);
                }
                else
                {
                    productimagebrowse = txt_productimage.Text;
                }
                    if (FileUpload2.HasFile)
                    {

                        sliderimagebrowse = Path.GetFileName(FileUpload2.FileName);
                        FileUpload2.SaveAs(Server.MapPath("~/Transaction/") + sliderimagebrowse);
                    }
                    else
                    {
                        sliderimagebrowse = txt_sliderimage.Text;
                    }
                        if (FileUpload3.HasFile)
                        {

                            image1browse = Path.GetFileName(FileUpload3.FileName);
                            FileUpload3.SaveAs(Server.MapPath("~/Images/") + image1browse);
                        }
                        if (FileUpload4.HasFile)
                        {

                            image2browse = Path.GetFileName(FileUpload4.FileName);
                            FileUpload4.SaveAs(Server.MapPath("~/Images/") + image2browse);
                        }
                                Business_Property Business_Property_obj = new Business_Property();
                                Business_Property_obj.product_id = txt_productid.Text;
                                Business_Property_obj.product_name = txt_productname.Text;
                                Business_Property_obj.brand_name = txt_brandname.Text;
                                Business_Property_obj.price = int.Parse(txt_price.Text);
                                Business_Property_obj.quantity = int.Parse(txt_quantity.Text);
                                Business_Property_obj.product_image = productimagebrowse;
                                Business_Property_obj.slider_image = sliderimagebrowse;
                                Business_Property_obj.date = txt_datepicker.Value;
                                Business_Property_obj.details = txt_details.Text;
                                Business_Property_obj.category_id = ddl_categoryid.SelectedItem.Text;
                                Business_Property_obj.image1 = image1browse;
                                Business_Property_obj.image2 = image2browse;
                                DataSet ds = new DataSet();
                                ds = Manager_obj.getid();
                                DataTable dt = new DataTable();
                                if (btn_save.Text == "SAVE")
                                {
                                    FileUpload3.Visible = true;
                                    FileUpload4.Visible = true;
                                    DataSet ds23 = new DataSet();
                                    ds23 = Manager_obj.checkproductid(Business_Property_obj);
                                    DataTable DT23 = new DataTable();
                                    DT23 = ds23.Tables[0];
                                    if (DT23.Rows.Count == 0)
                                    {
                                        dt = ds.Tables[0];
                                        int newid;
                                        if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                                        {
                                            newid = Convert.ToInt32(dt.Rows[0][0]);
                                            newid = newid + 1;
                                        }
                                        else
                                        {
                                            newid = 1;
                                        }
                                        Business_Property_obj.TS_SLIDER_ID = newid;
                                        //Business_Property_obj.TS_SLIDER_ID = Manager_obj.getid();
                                        int result = Manager_obj.insertproduct(Business_Property_obj);
                                        if (result == 1)
                                        {
                                            int result1 = Manager_obj.insertimage(Business_Property_obj);
                                            if (result1 == 1)
                                            {
                                                Business_Property_obj.product_image = image1browse;
                                                Manager_obj.insertimage(Business_Property_obj);
                                                Business_Property_obj.product_image = image2browse;
                                                Manager_obj.insertimage(Business_Property_obj);
                                                if (!string.IsNullOrEmpty(Business_Property_obj.slider_image))
                                                {
                                                    Manager_obj.insertslider(Business_Property_obj);
                                                }
                                                int result2 = 1;
                                                if (result2 == 1)
                                                {
                                                    int result3 = Manager_obj.insertfeatured(Business_Property_obj);
                                                    if (result3 == 1)
                                                    {
                                                        Response.Write("<Script LANGUAGE='JavaScript'>alert('success')</script>");
                                                        DataSet ds3 = new DataSet();
                                                        ds3 = Manager_obj.Griddetails();
                                                        dtg.DataSource = ds3;
                                                        dtg.DataBind();
                                                        txt_productid.Enabled = true;
                                                        txt_productid.Text = String.Empty;
                                                        txt_productname.Text = String.Empty;
                                                        txt_brandname.Text = String.Empty;
                                                        txt_brandname.Text = String.Empty;
                                                        txt_price.Text = String.Empty;
                                                        txt_productimage.Text = String.Empty;
                                                        txt_sliderimage.Text = String.Empty;
                                                        txt_datepicker.Value = String.Empty;
                                                        txt_details.Text = String.Empty;
                                                        txt_quantity.Text = String.Empty;
                                                        txt_image1.Text = String.Empty;
                                                        txt_image2.Text = String.Empty;
                                                        ddl_categoryid.SelectedIndex = 0;


                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<Script LANGUAGE='JavaScript'>alert('failed')</script>");

                                            }
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<Script LANGUAGE='JavaScript'>alert('Product ID already exists')</script>");

                                    }
                                }


                                else
                                {
                                    int result2;

                                    int result = Manager_obj.updatecategory(Business_Property_obj);
                                    if (result == 1)
                                    {
                                        txt_productimage.Text = productimagebrowse; ;
                                        int result1 = Manager_obj.updateimage(oldurl, txt_productimage.Text);
                                        if (result1 == 1)
                                        {
                                            Business_Property_obj.slider_image = sliderimagebrowse;
                                            if (!string.IsNullOrEmpty(Business_Property_obj.slider_image))
                                            {
                                                DataSet D1 = new DataSet();
                                                DataTable DTT = new DataTable();
                                                D1 = Manager_obj.sliderselect(Business_Property_obj);
                                                DTT = D1.Tables[0];
                                                if (DTT.Rows.Count == 0)
                                                {
                                                    dt = ds.Tables[0];
                                                    int newid;
                                                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                                                    {
                                                        newid = Convert.ToInt32(dt.Rows[0][0]);
                                                        newid = newid + 1;
                                                    }
                                                    else
                                                    {
                                                        newid = 1;
                                                    }
                                                    Business_Property_obj.TS_SLIDER_ID = newid;
                                                    Manager_obj.insertslider(Business_Property_obj);
                                                    Manager_obj.updateslider(Business_Property_obj);
                                                }
                                                else
                                                {
                                                    Manager_obj.updateslider(Business_Property_obj);
                                                }
                                                result2 = 1;
                                            }
                                            else
                                            {
                                                Manager_obj.deleteslider(Business_Property_obj.product_id);
                                                result2 = 1;
                                            }
                                            if (result2 == 1)
                                            {
                                                int result3 = Manager_obj.updatefeatured(Business_Property_obj);
                                                if (result3 == 1)
                                                {
                                                    Response.Write("<Script LANGUAGE='JavaScript'>alert('updated')</script>");

                                                    DataSet ds1 = new DataSet();
                                                    ds1 = Manager_obj.Griddetails();
                                                    dtg.DataSource = ds1;
                                                    dtg.DataBind();
                                                    txt_productid.Enabled = true;
                                                    txt_productid.Text = String.Empty;
                                                    txt_productname.Text = String.Empty;
                                                    txt_brandname.Text = String.Empty;
                                                    txt_brandname.Text = String.Empty;
                                                    txt_price.Text = String.Empty;
                                                    txt_productimage.Text = String.Empty;
                                                    txt_sliderimage.Text = String.Empty;
                                                    txt_datepicker.Value = String.Empty;
                                                    txt_details.Text = String.Empty;
                                                    txt_quantity.Text = String.Empty;
                                                    btn_save.Text = "SAVE";
                                                    ddl_categoryid.SelectedIndex = 0;
                                                    FileUpload3.Visible = true;
                                                    FileUpload4.Visible = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<Script LANGUAGE='JavaScript'>alert('failed')</script>");

                                    }
                                }
                            }
                        

                    
                
            
        }
        public void edit(object sender, EventArgs e)
        {

            GridViewRow dtg_edit = (GridViewRow)((LinkButton)sender).NamingContainer;
            txt_productid.Text = dtg_edit.Cells[2].Text;
            txt_productid.Enabled = false;
            txt_image1.Enabled = false;
            txt_image2.Enabled = false;
            ddl_categoryid.Text = dtg_edit.Cells[3].Text;
            txt_productname.Text = dtg_edit.Cells[4].Text;
            txt_brandname.Text = dtg_edit.Cells[5].Text;
            txt_price.Text = dtg_edit.Cells[6].Text;
            txt_quantity.Text = dtg_edit.Cells[7].Text;
            txt_productimage.Text = dtg_edit.Cells[9].Text;
            oldurl = dtg_edit.Cells[9].Text;
            txt_sliderimage.Text = dtg_edit.Cells[10].Text;
            FileUpload3.Visible = false;
            FileUpload4.Visible = false;
            if (txt_sliderimage.Text == "&nbsp;")
            {
                txt_sliderimage.Text = String.Empty;

            }
            txt_details.Text = dtg_edit.Cells[11].Text;
            DateTime date = Convert.ToDateTime(dtg_edit.Cells[8].Text);
            txt_datepicker.Value = date.ToString("dd-MM-yyyy");

            btn_save.Text = "UPDATE";
            Business_Property_obj.product_id = txt_productid.Text;
            Business_Property_obj.product_name = txt_productname.Text;
            Business_Property_obj.brand_name = txt_brandname.Text;
            Business_Property_obj.price = int.Parse(txt_price.Text);
            Business_Property_obj.quantity = int.Parse(txt_quantity.Text);
            Business_Property_obj.product_image = txt_productimage.Text;
            Business_Property_obj.slider_image = txt_sliderimage.Text;
            Business_Property_obj.date = txt_datepicker.Value;
            Business_Property_obj.details = txt_details.Text;
            Business_Property_obj.category_id = ddl_categoryid.SelectedItem.Text;

        }
        public void delete(object sender, EventArgs e)
        {
            GridViewRow dtg_edit = (GridViewRow)((LinkButton)sender).NamingContainer;

            string delete = dtg_edit.Cells[2].Text;
            int result = Manager_obj.deletefeatured(delete);

            Manager_obj.deleteslider(delete);

            int result2 = Manager_obj.deleteimage(delete);

            int result4 = Manager_obj.deletecart(delete);

            int result5 = Manager_obj.deleteorderdetails(delete);

            int result6 = Manager_obj.deletereview(delete);
            int result8 = Manager_obj.deleteitemview(delete);

            int result7 = Manager_obj.deletewishlist(delete);
            int result3 = Manager_obj.deleteproduct(delete);
            if (result3 == 1)
            {
                Response.Write("<Script LANGUAGE='JavaScript'>alert('Entry deleted successfully')</script>");
                DataSet ds = new DataSet();
                ds = Manager_obj.Griddetails();
                dtg.DataSource = ds;
                dtg.DataBind();
                ds.Dispose();
            }
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_productid.Enabled = true;
            txt_productid.Text = String.Empty;
            txt_productname.Text = String.Empty;
            txt_brandname.Text = String.Empty;
            txt_brandname.Text = String.Empty;
            txt_price.Text = String.Empty;
            txt_productimage.Text = String.Empty;
            txt_sliderimage.Text = String.Empty;
            DateTime date = DateTime.Today;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, date.Day);
            txt_datepicker.Value = firstDayOfMonth.ToString("dd-MM-yyyy");
            txt_details.Text = String.Empty;
            txt_quantity.Text = String.Empty;
            btn_save.Text = "SAVE";
            ddl_categoryid.SelectedIndex = 0;
            txt_image1.Text = String.Empty;
            txt_image2.Text = String.Empty;
            txt_search.Text = String.Empty;
            FileUpload3.Visible = true;
            FileUpload4.Visible = true;
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtg.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = Manager_obj.Griddetails();
            dtg.DataSource = ds;
            dtg.DataBind();
        }

        protected void filter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                DataSet ds = new DataSet();
                ds = Manager_obj.filter(txt_search.Text);
                dtg.DataSource = ds;
                dtg.DataBind();

            }
            else
            {
                Response.Write("<Script LANGUAGE='JavaScript'>alert('Enter Product Id to search')</script>");
            }
        }



    }
}