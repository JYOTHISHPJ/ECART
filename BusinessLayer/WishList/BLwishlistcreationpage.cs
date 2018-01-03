using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using System.Data.OracleClient;
using System.Configuration;


namespace BusinessLayer.WishList
{
    public class BLwishlistcreationpage
    {
        DataAccessLayerClass ObjDataAccessLayerClass = new DataAccessLayerClass();
        public void AddToWishList(int qnty, int userid)
        {
            string T, price, quantity;
            DataSet ds = new DataSet();

            string query2 = "select  TIW_PRODUCT_ID from TBL_ITEMVIEW ";
            ds = ObjDataAccessLayerClass.GetData(query2);
            T = ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"].ToString();
            // ds.Clear();
            string query3 = "select TP_PRICE from  tbl_product where TP_PRODUCT_ID='" + T + "'";
            ds = ObjDataAccessLayerClass.GetData(query3);

            price = ds.Tables[0].Rows[0]["TP_PRICE"].ToString();
            //   quantity=ds.Tables[0].Rows[0]["TP_QUANTITY"].ToString();


            int pr = Convert.ToInt32(price);

            int amt = pr * qnty;
            string WishCheck = "select tw_product_id,tw_quantity from  tbl_WISHLIST WHERE TW_PRODUCT_ID='" + T + "' ";
            ds = ObjDataAccessLayerClass.GetData(WishCheck);
            DataTable dt = new DataTable();

            //  int Amount = Price * Quantity;
            dt = ds.Tables[0];
            //// int t=dt.Rows.Count;
            if (dt.Rows.Count != 0)
            {
                int Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["tw_quantity"].ToString());
                qnty = qnty + Quantity;
                int Amt = pr * qnty;
                string query = " UPDATE  TBL_WISHLIST SET TW_QUANTITY= " + qnty + ", TW_AMOUNT=" + Amt + " WHERE TW_PRODUCT_ID='" + T + "' AND TW_USER_ID=" + userid + "";
                ObjDataAccessLayerClass.RunQuery(query);
                //string UpdateQuantity = "UPDATE TBL_PRODUCT SET TP_QUANTITY=TP_QUANTITY-'" + Quantity + "' WHERE TP_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TP_PRODUCT_ID"] + "'";
                //objDataAccessLayerClass.RunQuery(UpdateQuantity);
            }
            else
            {

                string query4 = "insert into tbl_wishlist values(" + userid + ",'" + T + "'," + pr + "," + qnty + "," + amt + ")";
                ObjDataAccessLayerClass.RunQuery(query4);
            }
        }
    }
}
