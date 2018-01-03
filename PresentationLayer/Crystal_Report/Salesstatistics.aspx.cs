using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using PresentationLayer.Crystal_Report;

namespace PresentationLayer
{
    public partial class Salesstatistics : System.Web.UI.Page
    {
        MonthDetails objMonthDetails = new MonthDetails();
        public int status = 0;
        ReportDetails1 objReportDetails1 = new ReportDetails1();
        ReportDetails2 objReportDetails2 = new ReportDetails2();
        string reportpath;
        DataSet1 repobj = new DataSet1();
        ReportDocument report = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                group2.Visible = false;



                // DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                ds = objMonthDetails.GetData(objMonthDetails);
                //dt = ds.Tables[0];
                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "TCS_CODE";
                DropDownList1.DataTextField = "TCS_TEXT";
                DropDownList1.DataBind();


                DateTime Date = DateTime.Today;
                var FirstDayOfMonth = new DateTime(Date.Year, Date.Month, 1);
                datepicker.Value = FirstDayOfMonth.ToString("dd-MM-yy");
                datepicker1.Value = DateTime.Today.ToString("dd-MM-yy");



            }


        }
        private void Page_Init(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["se"] = null;
            }
            else if (Session["se"] != null)
            {
                report = (ReportDocument)Session["se"];

                CrystalReportViewer1.ReportSource = report;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        // reset button
        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            DropDownList1.Text = null;
            TextBox1.Text = "2016";
            DateTime Date = DateTime.Today;
            var FirstDayOfMonth = new DateTime(Date.Year, Date.Month, 1);
            datepicker.Value = FirstDayOfMonth.ToString("dd-MM-yy");
            datepicker1.Value = DateTime.Today.ToString("dd-MM-yy");

        }
        //  show button
        protected void btn_Show_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                TextBox1.Enabled = false;
                DropDownList1.Enabled = false;
                status = 1;
            }
            else if (RadioButton2.Checked == true)
            {
                datepicker.Disabled = true;
                datepicker1.Disabled = true;
                status = 2;
                btn_Show.CausesValidation = false;
            }
            else
            {
                Response.Write("<script>alert(' Please Select Any Option ')</script>");
            }

            // for first radiobutton 

            if (status == 1)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {


                    //start and end date
                    objReportDetails1.startdate = datepicker.Value;
                    objReportDetails1.enddate = datepicker1.Value;


                    ds = objReportDetails1.GetData(objReportDetails1);
                    dt = ds.Tables[0];
                    repobj.Tables["datatable1"].Merge(dt);
                    reportpath = Server.MapPath("~") + "\\Crystal_Report\\firstrep.rpt";
                    report.Load(reportpath);
                    report.SetDataSource(repobj);
                    if (report.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('No data found..Please enter again ')</script>");
                        CrystalReportViewer1.Visible = false;
                    }
                    else
                    {
                        CrystalReportViewer1.Visible = true;
                        Session["se"] = report;
                        CrystalReportViewer1.ReportSource = report;
                        CrystalReportViewer1.DataBind();

                    }
                    group2.Visible = true;
                    group1.Visible = false;

                }
                catch (Exception ex)
                {

                    Response.Write("<span style= 'color:white'> Error occured  :  </span>" + ex.Message.ToString());
                }
            }

            // for second radiobutton

            if (status == 2)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    //yearbox
                    if (String.IsNullOrEmpty(TextBox1.Text))
                        objReportDetails2.year = 2016;
                    else
                        objReportDetails2.year = Convert.ToInt32(TextBox1.Text);
                    //monthlist
                    objReportDetails2.month = Convert.ToInt32(DropDownList1.SelectedItem.Value);




                    ds = objReportDetails2.GetData(objReportDetails2);
                    dt = ds.Tables[0];



                    repobj.Tables["datatable1"].Merge(dt);
                    reportpath = Server.MapPath("~") + "\\Crystal_Report\\firstrep.rpt";



                    report.Load(reportpath);
                    report.SetDataSource(repobj);


                    if (report.Rows.Count == 0)
                    {
                        Response.Write("<script>alert('No data found..Please enter again ')</script>");
                        CrystalReportViewer1.Visible = false;
                    }
                    else
                    {
                        CrystalReportViewer1.Visible = true;
                        Session["se"] = report;
                        CrystalReportViewer1.ReportSource = report;
                        CrystalReportViewer1.DataBind();

                    }
                    group2.Visible = true;
                    group1.Visible = false;



                }
                catch (Exception ex)
                {

                    Response.Write("<span style= 'color:white'> Error occured  :  </span>" + ex.Message.ToString());
                }
            }



        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            group1.Visible = true;
            group2.Visible = false;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            DropDownList1.Enabled = false;




        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {



            TextBox1.Enabled = true;
            DropDownList1.Enabled = true;

        }

        

    }
}