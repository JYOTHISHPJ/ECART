using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
   public class OrderBusMaster
    {
       string query;
       DataAccessLayerClass objdataget = new DataAccessLayerClass();
       public DataSet order()
       {
           DataSet ds = new DataSet();
           query = "select TOR_REFERENCE_NO,TU_USER_NAME,TOR_ORDER_STATUS FROM TBL_ORDER,TBL_USER  WHERE TU_USER_ID=TOR_USER_ID";
          ds= objdataget.GetData(query);
           return ds;
       }
    
     public void update(string refno,string user,string status)
       {
           query = "update TBL_ORDER SET  TOR_ORDER_STATUS='" + status + "' where TOR_REFERENCE_NO='" + refno + "'";
           objdataget.RunQuery(query);

       }
   
   }
}
