using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using DataAccessLayer;

namespace BusinessLayer.ProductListingBL
{
    public class ProductListingBLClass
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();

        public DataSet ShowProductListing(string def)
        {
            string query1 = "SELECT DISTINCT TI_IMAGE_URL,TP_PRODUCT_NAME,TP_BRAND_NAME,TP_PRICE,TCY_CATEGORY_NAME FROM TBL_IMAGE,TBL_PRODUCT,TBL_CATEGORY WHERE (TI_PRODUCT_ID=TP_PRODUCT_ID) AND (TP_CATEGORY_ID=TCY_CATEGORY_ID) AND (UPPER(TP_BRAND_NAME) like'" + def + "%' OR UPPER(TP_PRODUCT_NAME) like'" + def + "%' OR UPPER(TCY_CATEGORY_NAME) like'" + def + "%' AND (ROWNUM<2))";
            DataSet dtProdList = new DataSet();
            dtProdList = objDataAccessLayerClass.GetData(query1);
            return dtProdList;
        }

        public DataSet filterByCategory()
        {
            string query = "SELECT DISTINCT TCY_CATEGORY_ID,TCY_CATEGORY_NAME FROM TBL_CATEGORY WHERE TCY_PARENT_ID IS NULL ORDER BY TCY_CATEGORY_NAME";
            DataSet ds = new DataSet();
            ds = objDataAccessLayerClass.GetData(query);
            return ds;
        }

        public DataSet Filtering(string ParentId)
        {
            string query2 = "SELECT DISTINCT TCY_CATEGORY_ID,TCY_CATEGORY_NAME FROM TBL_CATEGORY WHERE TCY_PARENT_ID='" + ParentId + "' ORDER BY TCY_CATEGORY_NAME ";
            DataSet ds = new DataSet();
            ds = objDataAccessLayerClass.GetData(query2);
            return ds;
        }
        public DataSet ShowAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT DISTINCT TP_PRODUCT_ID AS TI_PRODUCT_ID,TP_PRODUCT_NAME,TP_BRAND_NAME,TP_PRICE,(SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID ) TI_IMAGE_URL FROM TBL_PRODUCT WHERE TP_PRODUCT_NAME IS NOT NULL";
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

        public DataSet ChildFilter(string Parent)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "SELECT  DISTINCT TP_PRODUCT_ID,TP_PRODUCT_NAME FROM TBL_PRODUCT WHERE TP_CATEGORY_ID IN(SELECT TCY_CATEGORY_ID FROM TBL_CATEGORY WHERE TCY_CATEGORY_NAME='" + Parent + "')";
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

        public DataSet filter(Dictionary<string, string> ABC)
        {
            DataSet ds = new DataSet();


            string query3 = "SELECT DISTINCT TP_PRODUCT_ID AS TI_PRODUCT_ID,TP_PRODUCT_NAME,TP_BRAND_NAME,TP_PRICE,(SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID ) TI_IMAGE_URL FROM TBL_PRODUCT WHERE TP_PRODUCT_NAME IN(";

            foreach (KeyValuePair<string, string> pair in ABC)
            {
                query3 = query3 + "'" + pair.Value + "',";
            }

            //foreach (string abc in ABC)
            //{
            //    query3 = query3 + "'" + abc + "',";
            //}

            query3 = query3.Remove(query3.Length - 1);
            query3 = query3 + ")";
            ds = objDataAccessLayerClass.GetData(query3);
            return ds;
        }
    }
}
