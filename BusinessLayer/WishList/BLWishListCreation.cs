using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer.WishList
{
    public class BLWishListCreation
    {
        string feild1;

        DataAccessLayerClass ObjDataAccessLayerClass = new DataAccessLayerClass();
        public DataSet gvWishList(int userid)
        {
            // feild1 = fde;  
            DataSet ds = new DataSet();
            try
            {

                String query = " SELECT distinct (SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID) as TI_IMAGE_URL ,b.TP_PRODUCT_NAME,c.TW_PRICE,c.TW_QUANTITY,c.TW_AMOUNT from TBL_IMAGE a,TBL_PRODUCT b,TBL_WISHLIST c where a.TI_PRODUCT_ID=c.TW_PRODUCT_ID and b.TP_PRODUCT_ID=c.TW_PRODUCT_ID  and c.TW_USER_ID=" + userid + "";
                ds = ObjDataAccessLayerClass.GetData(query);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public void AddToCart(BLWishListProperty getPro)
        {
            string T;
            DataSet ds1 = new DataSet();
            string query1 = "select TP_PRODUCT_ID,TI_IMAGE_URL from TBL_PRODUCT,TBL_IMAGE where TP_PRODUCT_ID=TI_PRODUCT_ID AND TP_PRODUCT_NAME='" + getPro.proName + "'";
            ds1 = ObjDataAccessLayerClass.GetData(query1);
            T = ds1.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString();


            string imgurl = ds1.Tables[0].Rows[0]["TI_IMAGE_URL"].ToString().Trim().Split('/').Last(); /*   Getting image Url   */

            string query = "SELECT TI_PRODUCT_ID FROM TBL_IMAGE WHERE TI_IMAGE_URL LIKE '" + imgurl + "'";
            DataSet ds = new DataSet();
            ds = ObjDataAccessLayerClass.GetData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string DelQuery = "DELETE FROM TBL_ITEMVIEW";
                ObjDataAccessLayerClass.RunQuery(DelQuery);

                string GetQuery = "INSERT INTO TBL_ITEMVIEW VALUES('" + ds.Tables[0].Rows[0]["TI_PRODUCT_ID"].ToString() + "')";
                ObjDataAccessLayerClass.RunQuery(GetQuery);
            }



            string query22 = "INSERT INTO TBL_CART (TCT_USER_ID,TCT_PRODUCT_ID,TCT_PRICE,TCT_QUANTITY,TCT_AMOUNT) VALUES (" + getPro.id + ",'" + T + "'," + getPro.price + "," + getPro.quantity + "," + getPro.amount + ")";
            ObjDataAccessLayerClass.RunQuery(query22);
            string query33 = "delete from tbl_wishlist where tw_product_id='" + T + "'";
            ObjDataAccessLayerClass.RunQuery(query33);
        }


        public void remove(BLWishListProperty getPro)
        {
            string T;
            DataSet ds1 = new DataSet();
            string query1 = "select distinct TP_PRODUCT_ID from TBL_PRODUCT,TBL_IMAGE where TP_PRODUCT_ID=TI_PRODUCT_ID AND TP_PRODUCT_NAME='" + getPro.proName + "'";
            ds1 = ObjDataAccessLayerClass.GetData(query1);
            T = ds1.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString();
            string query = "delete from tbl_wishlist where tw_product_id='" + T + "'";
            ObjDataAccessLayerClass.RunQuery(query);
        }

        public void DeleteFromWishList(BLWishListProperty getPro)
        {
            string T;
            DataSet ds1 = new DataSet();
            string query1 = "select TP_PRODUCT_ID,TI_IMAGE_URL from TBL_PRODUCT,TBL_IMAGE where TP_PRODUCT_ID=TI_PRODUCT_ID AND TP_PRODUCT_NAME='" + getPro.proName + "'";
            ds1 = ObjDataAccessLayerClass.GetData(query1);
            T = ds1.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString();
            string query33 = "delete from tbl_wishlist where tw_product_id='" + T + "'";
            ObjDataAccessLayerClass.RunQuery(query33);
        }

    }
}
