using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.OracleClient;


namespace BusinessLayer.quickcart
{
    public class BLQuickCart
    {

        DataAccessLayerClass ObjDataAccessLayerClass = new DataAccessLayerClass();
        public DataSet QuickCart(int userid)
        {
            DataSet ds = new DataSet();
            try
            {
                //SELECT distinct (SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID) as TI_IMAGE_URL ,b.TP_PRODUCT_NAME,c.TW_PRICE,c.TW_QUANTITY,c.TW_AMOUNT from TBL_IMAGE a,TBL_PRODUCT b,TBL_WISHLIST c where a.TI_PRODUCT_ID=c.TW_PRODUCT_ID and b.TP_PRODUCT_ID=c.TW_PRODUCT_ID  and c.TW_USER_ID=" + userid + "

                String query = "SELECT distinct (SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID) as TI_IMAGE_URL,b.TP_PRODUCT_NAME,c.TCT_PRICE,c.TCT_QUANTITY,c.TCT_AMOUNT from TBL_IMAGE a,TBL_PRODUCT b,TBL_CART c where  a.TI_PRODUCT_ID=c.TCT_PRODUCT_ID and b.TP_PRODUCT_ID=c.TCT_PRODUCT_ID and c.TCT_USER_ID=" + userid + " ";
                ds = ObjDataAccessLayerClass.GetData(query);

            }
            catch (Exception e)
            { }
            return ds;
        }
        public DataSet totalamt(int userid)
        {
            DataSet ds = new DataSet();
            string query2 = "select sum(TCT_AMOUNT) from tbl_cart where TCT_USER_ID=" + userid + "";
            ds = ObjDataAccessLayerClass.GetData(query2);
            return ds;
        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public int AddToorderList(int userid)
        {
            int a = 0;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            int orderid;
            try
            {
                string referenceNum = CreateRandomPassword(4);
                int ReferNum = Convert.ToInt32(referenceNum);

                string query = "select max(TOR_ORDER_ID) from tbl_order";

                ds = ObjDataAccessLayerClass.GetData(query);
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                {
                    orderid = Convert.ToInt32(dt.Rows[0][0]);
                    orderid = orderid + 1;
                }
                else
                {
                    orderid = 1;
                }
                string query3 = "insert into tbl_order values(" + orderid + "," + userid + ",SYSDATE,'ORDERED'," + ReferNum + ")";
                ObjDataAccessLayerClass.RunQuery(query3);

                OracleParameter[] pm = new OracleParameter[3];
                pm[0] = new OracleParameter();
                pm[0].ParameterName = "userid";
                pm[0].Direction = ParameterDirection.Input;
                pm[0].OracleType = OracleType.Int32;
                pm[0].Size = 10;
                pm[0].Value = userid;

                pm[1] = new OracleParameter();
                pm[1].ParameterName = "orderid";
                pm[1].Direction = ParameterDirection.Input;
                pm[1].OracleType = OracleType.Int32;
                pm[1].Size = 10;
                pm[1].Value = orderid;

                pm[2] = new OracleParameter();
                pm[2].ParameterName = "status";
                pm[2].Direction = ParameterDirection.Output;
                pm[2].OracleType = OracleType.Int32;
                pm[2].Size = 10;
                pm[2].Value = 0;
                a = ObjDataAccessLayerClass.ExecuteSP(ref pm, "dprscl");
                //Convert.ToInt32(command.Parameters["@ReturnValue"].Value);
                //return Convert.ToInt32(pm[2].Value;
                string query33 = "delete from tbl_cart where tct_user_id=" + userid + "";
                ObjDataAccessLayerClass.RunQuery(query33);


            }
            catch (Exception e)
            { }
            return a;
        }
        public void removeFromCart(BLQuickCartProperty getPro)
        {
            string T;
            DataSet ds1 = new DataSet();
            string query1 = "select distinct TP_PRODUCT_ID from TBL_PRODUCT,TBL_IMAGE where TP_PRODUCT_ID=TI_PRODUCT_ID AND TP_PRODUCT_NAME='" + getPro.proName + "'";
            ds1 = ObjDataAccessLayerClass.GetData(query1);
            T = ds1.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString();
            string query = "delete from tbl_cart where tct_product_id='" + T + "'";
            ObjDataAccessLayerClass.RunQuery(query);
        }

    }
}




