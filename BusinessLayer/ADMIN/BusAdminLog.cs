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
   public class BusAdminLog
    {
       string query;
       DataAccessLayerClass objdataget = new DataAccessLayerClass();

       public DataSet adminlogin(string useradm,string passadm )
       {
           DataSet ds = new DataSet();
           query = "SELECT USERNAME,PASSWORD FROM TBL_ADMIN WHERE  USERNAME='" + useradm + "' AND PASSWORD='" + passadm + "' ";
           ds = objdataget.GetData(query);
           return ds;
       }
    }
}
