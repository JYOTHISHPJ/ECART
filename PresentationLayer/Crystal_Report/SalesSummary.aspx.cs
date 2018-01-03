using BusinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer.Crystal_Report
{
    public partial class SalesSummary : System.Web.UI.Page
    {
        BussinessLayerClass objBusinessLayerClass = new BussinessLayerClass();
        ReportDocument report = new ReportDocument();

        string reportpath;
        protected void Page_Load(object sender, EventArgs e)
        {

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

                crvReport.ReportSource = report;
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            dsCart objdscart = new dsCart();

            DataTable dt = new DataTable();


            reportpath = Server.MapPath("~") + "\\Crystal_Report\\CrystalReport1.rpt";
            ds = objBusinessLayerClass.cartdetails(objBusinessLayerClass);

            dt = ds.Tables[0];

            objdscart.Tables["CART"].Merge(dt);

            report.Load(reportpath);
            report.SetDataSource(objdscart);


            if (report.Rows.Count == 0)
            {
                Response.Write("<script>alert('No data found..Please enter again ')</script>");
                crvReport.Visible = false;
            }
            else 
            {
                Session["se"] = report;
                crvReport.Visible = true;

                crvReport.ReportSource = report;
                crvReport.DataBind();
            }
        }

    }
}