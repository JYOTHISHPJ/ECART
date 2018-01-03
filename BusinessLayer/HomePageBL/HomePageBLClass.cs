using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using DataAccessLayer;

namespace BusinessLayer.HomePageBL
{
    public class HomePageBLClass
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();

        public DataSet BindGridFeaturedProducts()
        {
            string query1 = "SELECT TI_IMAGE_URL,TI_PRODUCT_ID FROM TBL_IMAGE WHERE ROWID IN(SELECT MIN(ROWID) FROM TBL_IMAGE GROUP BY TI_PRODUCT_ID) AND TI_PRODUCT_ID IN (SELECT TF_PRODUCT_ID FROM TBL_FEATURED)";
            DataSet dtFeat = new DataSet();
            dtFeat = objDataAccessLayerClass.GetData(query1);
            return dtFeat;
        }

        public DataSet BindGridLatestProducts()
        {
            string query2 = "SELECT TP_PRODUCT_ID,(SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE ROWNUM=1 AND TP_PRODUCT_ID=TI_PRODUCT_ID) AS TI_IMAGE_URL FROM TBL_PRODUCT WHERE ABS(SYSDATE-TP_DATE)<21";
            //SELECT TP_DATE FROM TBL_PRODUCT WHERE ABS(SYSDATE-TP_DATE)<10;
            DataSet dtLat = new DataSet();
            dtLat = objDataAccessLayerClass.GetData(query2);
            return dtLat;
        }
    }
}