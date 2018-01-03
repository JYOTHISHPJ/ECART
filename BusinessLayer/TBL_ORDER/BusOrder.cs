using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
   public class BusOrder
   {
       string r,t;
       string query;
       DataAccessLayerClass objdataget = new DataAccessLayerClass();
       public DataSet order(int userid)
       {
           DataSet dt = new DataSet();
           query = "SELECT DISTINCT TOR_REFERENCE_NO,TOR_ORDER_DATE,TOR_ORDER_STATUS FROM TBL_ORDER  where TOR_USER_ID=" + userid + " ORDER BY TOR_ORDER_DATE DESC";
       dt=objdataget.GetData(query);
           return dt;
       }

       public DataSet totalamt()
       {
           DataSet ds = new DataSet();


           string query2 = "select sum(TOS_AMOUNT) from TBL_ORDERDETAILS where TOS_ORDER_ID='" + t + "' ";
           ds = objdataget.GetData(query2);
           return ds;
       }
 

       public DataSet  build()
       {
          
           DataSet ds = new DataSet();
           query = "SELECT TOS_ORDER_ID,TOS_PRICE,TOS_QUANTITY,TOR_ORDER_STATUS,TOS_AMOUNT,TOS_DATE,TP_PRODUCT_NAME,TOR_REFERENCE_NO FROM TBL_ORDERDETAILS,TBL_PRODUCT,TBL_ORDER WHERE TOS_ORDER_ID=TOR_ORDER_ID AND TOS_PRODUCT_ID=TP_PRODUCT_ID AND TOS_ORDER_ID='" + t + "'  ";
           ds = objdataget.GetData(query);
           return ds;
       }
   /*    public void TEMP()
       {
           DataSet ds = new DataSet();
           query = "SELECT TOR_ORDER_ID FROM TBL_ORDER WHERE TOR_REFERENCE_NO='"+r+"'";
           ds = objdataget.GetData(query);
           t = ds.Tables[0].Rows[0].ToString();
       }*/
       public void referene(string rownum)
       {
            r = rownum;
            DataSet ds = new DataSet();
            query = "SELECT TOR_ORDER_ID FROM TBL_ORDER WHERE TOR_REFERENCE_NO='" + r + "'";
            ds = objdataget.GetData(query);
            t = ds.Tables[0].Rows[0]["TOR_ORDER_ID"].ToString();
      }

      public int Cancel(string refno)
       {
           query = "UPDATE TBL_ORDER SET TOR_ORDER_STATUS = 'CANCELLED' WHERE TOR_REFERENCE_NO='"+refno+"'";
           return objdataget.RunQuery(query);
       }

    }
}
