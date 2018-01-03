using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BusinessLayerClass
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        DataSet ds = new DataSet();
        public DataTable productId(string imgUrl)
        {
            try
            {
                string query = "SELECT TI_PRODUCT_ID FROM TBL_IMAGE WHERE TI_IMAGE_URL LIKE '" + imgUrl + "'";
                ds = objDataAccessLayerClass.GetData(query);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string DelQuery = "DELETE FROM TBL_ITEMVIEW";
                    objDataAccessLayerClass.RunQuery(DelQuery);

                    string GetQuery = "INSERT INTO TBL_ITEMVIEW VALUES('" + ds.Tables[0].Rows[0]["TI_PRODUCT_ID"].ToString() + "')";
                    objDataAccessLayerClass.RunQuery(GetQuery);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

        public DataTable getProductDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW";
                ds = objDataAccessLayerClass.GetData(query);

                string getProductQuery = "SELECT DISTINCT TI_IMAGE_URL,TP_PRODUCT_ID,TP_PRODUCT_NAME,TP_BRAND_NAME,TP_PRICE,TP_QUANTITY FROM TBL_IMAGE,TBL_PRODUCT WHERE TP_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"].ToString() + "' AND TI_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"].ToString() + "'";
                ds = objDataAccessLayerClass.GetData(getProductQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        public DataTable  findQuantity()
        {
            try
            {
                string query = "SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW";
                ds = objDataAccessLayerClass.GetData(query);
                string queryGetQuantity = "SELECT TP_QUANTITY FROM TBL_PRODUCT WHERE TP_PRODUCT_ID='"+ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"]+"'";
                ds = objDataAccessLayerClass.GetData(queryGetQuantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

        public DataTable addToCart(int Quantity, int UserId)
        {
            DataSet ds = new DataSet();
            DataSet dsId = new DataSet();
            try
            {
                string getProductId = "SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW";
                ds = objDataAccessLayerClass.GetData(getProductId);

                string getProductDetails = "SELECT TP_PRODUCT_ID,TP_PRICE FROM TBL_PRODUCT WHERE TP_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"].ToString() + "'";
                ds = objDataAccessLayerClass.GetData(getProductDetails);

                string getAddToCartData="SELECT TCT_PRODUCT_ID FROM TBL_CART WHERE TCT_USER_ID="+UserId+" AND TCT_PRODUCT_ID='"+ds.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString()+"'";
                dsId = objDataAccessLayerClass.GetData(getAddToCartData);
               
                int Price = Convert.ToInt32(ds.Tables[0].Rows[0]["TP_PRICE"].ToString());
                int Amount = Price * Quantity;
                if (dsId.Tables[0].Rows.Count == 0)
                {
                    string query = "INSERT INTO TBL_CART (TCT_USER_ID,TCT_PRODUCT_ID,TCT_PRICE,TCT_QUANTITY,TCT_AMOUNT) VALUES (" + UserId + ",'" + ds.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString() + "'," + Price + "," + Quantity + "," + Amount + ")";
                    objDataAccessLayerClass.RunQuery(query);
                }
                else
                {
                    string query = "UPDATE TBL_CART SET TCT_QUANTITY=TCT_QUANTITY+" + Quantity + ",TCT_AMOUNT=TCT_AMOUNT+" + Amount + " WHERE TCT_USER_ID="+UserId+" AND TCT_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TP_PRODUCT_ID"].ToString() + "'";
                    objDataAccessLayerClass.RunQuery(query);
                }
                string UpdateQuantity = "UPDATE TBL_PRODUCT SET TP_QUANTITY=TP_QUANTITY-'" + Quantity + "' WHERE TP_PRODUCT_ID='" + ds.Tables[0].Rows[0]["TP_PRODUCT_ID"] + "'";
                objDataAccessLayerClass.RunQuery(UpdateQuantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        public void RatingChanged(int productRating, string productIdGet, int userId)
        {
            string queryGetRating = "SELECT * FROM TBL_REVIEW WHERE TR_USER_ID="+userId+" AND TR_PRODUCT_ID='"+productIdGet+"'";
            DataSet ds = new DataSet();
            ds = objDataAccessLayerClass.GetData(queryGetRating);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string query = "INSERT INTO TBL_REVIEW (TR_PRODUCT_ID,TR_USER_ID,TR_RATING) VALUES ('" + productIdGet + "'," + 1 + "," + productRating + ") ";
                objDataAccessLayerClass.RunQuery(query);
            }
            else
            {
                string queryUpdate = "UPDATE TBL_REVIEW SET TR_RATING="+productRating+" WHERE TR_USER_ID="+userId+"";
                objDataAccessLayerClass.RunQuery(queryUpdate);
            }
        }
        public DataTable BindRatingToPage(string productId)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT TR_RATING FROM TBL_REVIEW WHERE TR_PRODUCT_ID='" + productId + "' AND TR_RATING IS NOT NULL";
                ds = objDataAccessLayerClass.GetData(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }
        public void addComments(string comments, int user)
        {
            string getProductId = "SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW";
            ds = objDataAccessLayerClass.GetData(getProductId);
            string productId = ds.Tables[0].Rows[0]["TIW_PRODUCT_ID"].ToString();
            string queryCommentCheck = "SELECT * FROM TBL_REVIEW WHERE TR_PRODUCT_ID='" + productId + "' AND TR_USER_ID=" + user + "";
            ds=objDataAccessLayerClass.GetData(queryCommentCheck);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string query = "UPDATE TBL_REVIEW SET TR_COMMENTS='" + comments + "' WHERE TR_USER_ID LIKE " + user + " AND TR_PRODUCT_ID='" + productId + "'";
                objDataAccessLayerClass.RunQuery(query);
            }
            else
            {

                string queryInsert = "INSERT INTO TBL_REVIEW (TR_PRODUCT_ID,TR_USER_ID,TR_COMMENTS) VALUES ('" + productId + "'," + user + ",'" + comments + "')";
                objDataAccessLayerClass.RunQuery(queryInsert);
            }
            //string query = "UPDATE TBL_REVIEW SET TR_COMMENTS='" + comments + "' WHERE TR_USER_ID LIKE " + user + " AND TR_PRODUCT_ID='" + productId + "'";
            //objDataAccessLayerClass.RunQuery(query);
        }
        public DataTable getComments(string productId)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT DISTINCT TU_USER_ID,TU_USER_NAME,TR_COMMENTS FROM TBL_REVIEW,TBL_USER WHERE TU_USER_ID=TR_USER_ID AND TR_PRODUCT_ID LIKE '" + productId + "' AND TR_COMMENTS IS NOT NULL AND ROWNUM<4";
                ds = objDataAccessLayerClass.GetData(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

        public DataSet getFeatures(string productId)
        {
            try
            {
                string query = "SELECT TF_FEATURES FROM TBL_FEATURED WHERE TF_PRODUCT_ID='" + productId + "'";
                ds = objDataAccessLayerClass.GetData(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        public DataSet productImages()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE TI_PRODUCT_ID=(SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW)";
                ds = objDataAccessLayerClass.GetData(query);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        public DataTable getId()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW";
                ds = objDataAccessLayerClass.GetData(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds.Tables[0];
        }

    }
}
