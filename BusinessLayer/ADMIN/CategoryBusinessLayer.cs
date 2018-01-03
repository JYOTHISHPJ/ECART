using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer.CategoryManagement
{
    public class CategoryBusinessLayer
    {
        DataAccessLayerClass objDataAccessLayerClass = new DataAccessLayerClass();
        string query;

        public int RunQuery(TableCategory objTableCategory,string status)
        {
            
            try
            {
                if (status == "INSERT")
                    query = "INSERT INTO TBL_CATEGORY VALUES('" + objTableCategory.CategoryId + "','" + objTableCategory.CategoryName + "','" + objTableCategory.ParentId + "')";
                else
                    query = "UPDATE TBL_CATEGORY SET TCY_CATEGORY_NAME = '" + objTableCategory.CategoryName + "', TCY_PARENT_ID = '" + objTableCategory.ParentId + "' WHERE TCY_CATEGORY_ID='" + objTableCategory.CategoryId + "'";
                return objDataAccessLayerClass.RunQuery(query);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DataSet GetData()
        {
            query = "SELECT * FROM TBL_CATEGORY";
            return objDataAccessLayerClass.GetData(query);
        }

        public DataSet DropDownData()
        {
            query = "SELECT TCY_CATEGORY_ID FROM TBL_CATEGORY WHERE TCY_PARENT_ID IS NULL";
            return objDataAccessLayerClass.GetData(query);
        }
        public int DeleteRow(string categoryId)
        {
            query = "DELETE FROM TBL_CATEGORY WHERE TCY_CATEGORY_ID ='"+categoryId+"'";
            return objDataAccessLayerClass.RunQuery(query);
        }

        public int CheckCategory(string categoryId)
        {
            int status = 0;
            query = "SELECT * FROM TBL_CATEGORY WHERE TCY_PARENT_ID ='" + categoryId + "'";
            DataSet ds = objDataAccessLayerClass.GetData(query);
            if (ds.Tables[0].Rows.Count > 0)
                status = 1;

            query = "SELECT * FROM TBL_PRODUCT WHERE TP_CATEGORY_ID ='" + categoryId + "'";
            ds = objDataAccessLayerClass.GetData(query);
            if (ds.Tables[0].Rows.Count > 0)
                status = 1;

            return status;
        }

    }
}
