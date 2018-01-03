using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using DataAccessLayer;
using System.Net;
namespace BusinessLayer
{
   public class BusActivation
    {
       string query;
       DataAccessLayerClass objdataget = new DataAccessLayerClass();
       DataSet dt = new DataSet();
       public DataSet active(string T)
       {
           
           query = "SELECT TU_USER_NAME ,TU_OTP FROM TBL_USER WHERE TU_EMAIL_ID='"+T+"'";
           dt = objdataget.GetData(query);
           return dt;
       }
       public DataSet send(string T)
       {
           query = "SELECT TU_EMAIL_ID FROM TBL_USER WHERE  TU_EMAIL_ID='" + T + "'";
           dt = objdataget.GetData(query);
           return dt;
       }
       public void update(string T)
       {

           query = "UPDATE TBL_USER SET TU_ACTIVE='T' WHERE TU_EMAIL_ID='" + T + "'";
          objdataget.RunQuery(query);

       }

       public string CheckOTP(string emailid)
       {
           query = "SELECT TU_OTP FROM TBL_USER WHERE TU_EMAIL_ID='" + emailid + "'";
           dt = objdataget.GetData(query);
           return dt.Tables[0].Rows[0][0].ToString();
       }
    }
}
