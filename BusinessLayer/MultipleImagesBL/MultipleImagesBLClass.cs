using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using DataAccessLayer;

namespace BusinessLayer.MultipleImagesBL
{
    public class MultipleImagesBLClass
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        
        public DataSet ShowMultipleImages()
        {
            string query1 = "SELECT TI_IMAGE_URL FROM TBL_IMAGE WHERE TI_PRODUCT_ID=(SELECT TIW_PRODUCT_ID FROM TBL_ITEMVIEW)";
            DataSet dtMulImg = new DataSet();
            dtMulImg = objDataAccessLayerClass.GetData(query1);
            return dtMulImg;
        }
    }
}