using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
namespace BusinessLayer
{
   public  class MasterBusiness
    {

       DataAccessLayerClass ObjMasterDataAccess = new  DataAccessLayerClass();
       DataSet ds = new DataSet();
      
       public DataSet Search(string str1)
       {
           string querry = "SELECT * FROM TBL_PRODUCT WHERE  tp_product_name='" + str1 + "' or tp_brand_name='" + str1 + "'";
           DataSet ds= ObjMasterDataAccess.GetData(querry);
           return ds;

       }
       public DataSet SelectSlider()
       {

           string querry = "SELECT TS_IMAGE_URL FROM TBL_SLIDER";
           DataSet DS2 = ObjMasterDataAccess.GetData(querry);
           return DS2;

       }

       public void productId(string imgUrl)
       {
           try
           {
               string query = "SELECT TS_PRODUCT_ID FROM TBL_SLIDER WHERE TS_IMAGE_URL LIKE '" + imgUrl + "'";
               ds = ObjMasterDataAccess.GetData(query);

               if (ds.Tables[0].Rows.Count > 0)
               {
                   string DelQuery = "DELETE FROM TBL_ITEMVIEW";
                   ObjMasterDataAccess.RunQuery(DelQuery);

                   string GetQuery = "INSERT INTO TBL_ITEMVIEW VALUES('" + ds.Tables[0].Rows[0]["TS_PRODUCT_ID"].ToString() + "')";
                   ObjMasterDataAccess.RunQuery(GetQuery);
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {

           }
       }

       public string GetUsername(int userid)
       {
           string query = "SELECT TU_USER_NAME FROM TBL_USER WHERE TU_USER_ID="+userid+"";
           DataSet ds = ObjMasterDataAccess.GetData(query);
           return (ds.Tables[0].Rows[0][0].ToString());
       }


    }
}
