using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Configuration;
using DataAccessLayer;



namespace BusinessLayer
{
    public class Business
    {
    }
    //for forget password  
    public class ForgetDetails
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        public string emailid
        { get; set; }
        public DataSet GetData(ForgetDetails getdata)
        {
            DataSet ds = new DataSet();
            try
            {
                try
                {
                    //string query = "SELECT Username,Password FROM users Where Email= '" + getdata.emailid + "'";
                    string query = "SELECT TU_USER_NAME,TU_PASSWORD FROM TBL_USER Where TU_EMAIL_ID= '" + getdata.emailid + "'";
                    ds = objDataAccessLayerClass.GetData(query);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }

    //for change password

    public class ChangeDetails
    {
        DataAccessLayerClass obj1DataAccessLayerClass = new DataAccessLayerClass();
        public string curpassword
        { get; set; }
        public string newpassword
        { get; set; }
        public DataSet GetData(ChangeDetails getdata)
        {
            DataSet ds = new DataSet();
            try
            {
                try
                {
                    //string query = "select * from users where Password='" + getdata.curpassword + "'";
                    string query = "select * from TBL_USER where TU_PASSWORD='" + getdata.curpassword + "'";

                    ds = obj1DataAccessLayerClass.GetData(query);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public int RunQuery(ChangeDetails getdat, int userid)
        {
            int status = 0;


            try
            {
                // string query1 = "update users set Password='" + getdat.newpassword + "' where Password='" + getdat.curpassword + "'";
                string query1 = "update TBL_USER set TU_PASSWORD='" + getdat.newpassword + "' where TU_USER_ID=" + userid + "";
                // string query1 = "update TBL_USER set TU_PASSWORD='" + getdat.newpassword + "' where TU_PASSWORD='" + getdat.curpassword + "'";
                // OracleCommand cmd1 = new OracleCommand("update TBL_USER set TU_PASSWORD='" + txtnewpass.Text + "' where TU_USER_NAME='" + Session["TU_USER_NAME"].ToString() + "'", oraConn);
                status = obj1DataAccessLayerClass.RunQuery(query1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return status;
        }

    }

    //for report
    public class ReportDetails1
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();

        public string startdate
        { get; set; }
        public string enddate
        { get; set; }
        public DataSet GetData(ReportDetails1 getdata)
        {
            DataSet ds = new DataSet();
            try
            {
                try
                {

                    string query = "SELECT TBL_CATEGORY.TCY_CATEGORY_NAME, TBL_PRODUCT.TP_PRODUCT_NAME,TBL_ORDERDETAILS.TOS_PRICE,TBL_ORDERDETAILS.TOS_QUANTITY,TBL_ORDERDETAILS.TOS_DATE FROM TBL_CATEGORY,TBL_PRODUCT,TBL_ORDERDETAILS WHERE TBL_CATEGORY.TCY_CATEGORY_ID=TBL_PRODUCT.TP_CATEGORY_ID AND TBL_PRODUCT.TP_PRODUCT_ID=TBL_ORDERDETAILS.TOS_PRODUCT_ID AND  TRUNC(TBL_ORDERDETAILS.TOS_DATE) BETWEEN TRUNC(TO_DATE('" + getdata.startdate + "','DD-MM-YY')) AND TRUNC(TO_DATE('" + getdata.enddate + "','DD-MM-YY'))";

                    ds = objDataAccessLayerClass.GetData(query);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
    public class ReportDetails2
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        public Int32 month
        { get; set; }
        public Int32 year
        { get; set; }

        public DataSet GetData(ReportDetails2 getdata)
        {
            DataSet ds = new DataSet();
            try
            {
                try
                {
                    if (Convert.ToInt32(getdata.month) == 0 && Convert.ToInt32(getdata.month) == 0)
                    {
                        var FirstDayOfMonth = new DateTime(getdata.year, 01, 1).ToString("dd/MM/yyyy");
                        var LastDayOfMonth = new DateTime(getdata.year, 12, 31).ToString("dd/MM/yyyy");
                        string query = "SELECT TBL_CATEGORY.TCY_CATEGORY_NAME, TBL_PRODUCT.TP_PRODUCT_NAME,TBL_ORDERDETAILS.TOS_PRICE,TBL_ORDERDETAILS.TOS_QUANTITY,TBL_ORDERDETAILS.TOS_DATE FROM TBL_CATEGORY,TBL_PRODUCT,TBL_ORDERDETAILS WHERE TBL_CATEGORY.TCY_CATEGORY_ID=TBL_PRODUCT.TP_CATEGORY_ID AND TBL_PRODUCT.TP_PRODUCT_ID=TBL_ORDERDETAILS.TOS_PRODUCT_ID AND TBL_ORDERDETAILS.TOS_DATE BETWEEN TO_DATE('" + FirstDayOfMonth + "','DD-MM-YY') AND TO_DATE('" + LastDayOfMonth + "','DD-MM-YY')";
                        ds = objDataAccessLayerClass.GetData(query);
                    }
                    else
                    {
                        var FirstDayOfMonth = new DateTime(getdata.year, getdata.month, 1).ToString("dd/MM/yyyy");
                        var LastDayOfMonth = new DateTime(getdata.year, getdata.month, 31).ToString("dd/MM/yyyy");

                        string query = "SELECT TBL_CATEGORY.TCY_CATEGORY_NAME, TBL_PRODUCT.TP_PRODUCT_NAME,TBL_ORDERDETAILS.TOS_PRICE,TBL_ORDERDETAILS.TOS_QUANTITY,TBL_ORDERDETAILS.TOS_DATE FROM TBL_CATEGORY,TBL_PRODUCT,TBL_ORDERDETAILS WHERE TBL_CATEGORY.TCY_CATEGORY_ID=TBL_PRODUCT.TP_CATEGORY_ID AND TBL_PRODUCT.TP_PRODUCT_ID=TBL_ORDERDETAILS.TOS_PRODUCT_ID AND TBL_ORDERDETAILS.TOS_DATE BETWEEN TO_DATE('" + FirstDayOfMonth + "','DD-MM-YY') AND TO_DATE('" + LastDayOfMonth + "','DD-MM-YY')";
                        ds = objDataAccessLayerClass.GetData(query);
                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
    public class MonthDetails
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        public DataSet GetData(MonthDetails getdata)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT  TCS_CODE,TCS_TEXT from TBL_CODES  ";
                ds = objDataAccessLayerClass.GetData(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }
    }

}



