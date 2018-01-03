using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
namespace BusinessLayer
{
    public class Manager
    {
        string query;
        DataAccessLayerClass obj_DataAccess = new DataAccessLayerClass();
        public int insertproduct(Business_Property Business_Property_obj)
        {

            query = "INSERT INTO TBL_PRODUCT VALUES('" + Business_Property_obj.product_id + "','" + Business_Property_obj.category_id + "','" + Business_Property_obj.product_name + "','" + Business_Property_obj.brand_name + "','" + Business_Property_obj.price + "','" + Business_Property_obj.quantity + "',TO_DATE('" + Business_Property_obj.date + "','DD/MM/YYYY'))";
            return obj_DataAccess.RunQuery(query);
        }
        public int insertimage(Business_Property Business_Property_obj)
        {
            query = "INSERT INTO TBL_IMAGE VALUES('" + Business_Property_obj.product_id + "','" + Business_Property_obj.product_image + "')";
            return obj_DataAccess.RunQuery(query);

        }
        public int insertslider(Business_Property Business_Property_obj)
        {

            query = "INSERT INTO TBL_SLIDER VALUES('" + Business_Property_obj.TS_SLIDER_ID + "','" + Business_Property_obj.slider_image + "','" + Business_Property_obj.product_id + "')";
            return obj_DataAccess.RunQuery(query);

        }
        public int insertfeatured(Business_Property Business_Property_obj)
        {
            query = "INSERT INTO TBL_FEATURED VALUES('" + Business_Property_obj.product_id + "','" + Business_Property_obj.details + "')";
            return obj_DataAccess.RunQuery(query);
        }
        public DataSet fillcategory()
        {
            query = "SELECT TCY_CATEGORY_ID FROM TBL_CATEGORY WHERE TCY_PARENT_ID IS NOT NULL";
            return obj_DataAccess.GetData(query);
        }
        public DataSet getid()
        {
            query = "SELECT MAX(TS_SLIDER_ID) FROM TBL_SLIDER";
            return obj_DataAccess.GetData(query);
            // return int.Parse(newid);
        }
        public DataSet Griddetails()
        {
            query = "SELECT TBL_PRODUCT.TP_PRODUCT_ID,TBL_PRODUCT.TP_CATEGORY_ID,TBL_PRODUCT.TP_PRODUCT_NAME,TBL_PRODUCT.TP_BRAND_NAME,TBL_PRODUCT.TP_PRICE,TBL_PRODUCT.TP_QUANTITY,TBL_PRODUCT.TP_DATE,TBL_IMAGE.TI_IMAGE_URL,TBL_SLIDER.TS_IMAGE_URL,TBL_FEATURED.TF_FEATURES FROM TBL_IMAGE,TBL_PRODUCT,TBL_SLIDER,TBL_FEATURED WHERE TBL_PRODUCT.TP_PRODUCT_ID=TBL_IMAGE.TI_PRODUCT_ID AND TBL_SLIDER.TS_PRODUCT_ID(+)=TBL_PRODUCT.TP_PRODUCT_ID AND TBL_FEATURED.TF_PRODUCT_ID=TBL_PRODUCT.TP_PRODUCT_ID";

            return obj_DataAccess.GetData(query);

        }
        public int updatecategory(Business_Property Business_Property_obj)
        {
            query = "UPDATE TBL_PRODUCT SET TP_CATEGORY_ID='" + Business_Property_obj.category_id + "',TP_PRODUCT_NAME='" + Business_Property_obj.product_name + "',TP_BRAND_NAME='" + Business_Property_obj.brand_name + "',TP_PRICE='" + Business_Property_obj.price + "',TP_QUANTITY='" + Business_Property_obj.quantity + "',TP_DATE=TO_DATE('" + Business_Property_obj.date + "','DD/MM/YYYY') WHERE TP_PRODUCT_ID='" + Business_Property_obj.product_id + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int updateimage(string oldurl, string newurl)
        {
            query = "UPDATE TBL_IMAGE SET TI_IMAGE_URL='" + newurl + "'WHERE TI_IMAGE_URL='" + oldurl + "'";
            return obj_DataAccess.RunQuery(query);
        }

        public int updateslider(Business_Property Business_Property_obj)
        {
            query = "UPDATE TBL_SLIDER SET TS_IMAGE_URL='" + Business_Property_obj.slider_image + "'WHERE TS_PRODUCT_ID='" + Business_Property_obj.product_id + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int updatefeatured(Business_Property Business_Property_obj)
        {
            query = "UPDATE TBL_FEATURED SET TF_FEATURES='" + Business_Property_obj.details + "'WHERE TF_PRODUCT_ID='" + Business_Property_obj.product_id + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deleteproduct(string delete)
        {
            query = "DELETE FROM TBL_PRODUCT WHERE TP_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deleteimage(string delete)
        {
            query = "DELETE FROM TBL_IMAGE WHERE TI_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deleteslider(string delete)
        {
            query = "DELETE FROM TBL_SLIDER WHERE TS_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deletefeatured(string delete)
        {
            query = "DELETE FROM TBL_FEATURED WHERE TF_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public DataSet userdetails()
        {

            query = "SELECT TU_USER_ID,TU_USER_NAME,TU_ADDRESS,TU_MOB_NO,TU_EMAIL_ID,TU_PASSWORD,TU_OTP,TU_CREATED_DATE,TU_EXP_DATE,TU_ACTIVE FROM TBL_USER";

            return obj_DataAccess.GetData(query);

        }
        public int deactivate(string id)
        {
            query = "UPDATE TBL_USER SET TU_ACTIVE='F',TU_OTP=000000 WHERE TU_USER_ID='" + id + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int adminentry(Business_Property Business_Property_obj)
        {
            query = "INSERT INTO TBL_ADMIN VALUES('" + Business_Property_obj.admin_user + "','" + Business_Property_obj.admin_pass + "')";
            return obj_DataAccess.RunQuery(query);
        }
        public DataSet Gridadmin()
        {
            query = " SELECT * FROM TBL_ADMIN";
            return obj_DataAccess.GetData(query);
        }
        public int admiupdate(Business_Property Business_Property_obj)
        {
            query = "UPDATE TBL_ADMIN SET PASSWORD='" + Business_Property_obj.admin_pass + "' WHERE USERNAME='" + Business_Property_obj.admin_user + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int admdelete(string admndele)
        {
            query = "DELETE FROM TBL_ADMIN WHERE USERNAME='" + admndele + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public DataSet admincheck(Business_Property Business_Property_obj)
        {
            query = "SELECT * FROM TBL_ADMIN WHERE USERNAME='" + Business_Property_obj.admin_user + "'";
            return obj_DataAccess.GetData(query);
        }
        public DataSet checkproductid(Business_Property Business_Property_obj)
        {
            query = "SELECT * FROM TBL_PRODUCT WHERE TP_PRODUCT_ID='" + Business_Property_obj.product_id + "'";
            return obj_DataAccess.GetData(query);

        }

        public int deletecart(string delete)
        {
            query = "DELETE FROM TBL_CART WHERE TCT_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deleteorderdetails(string delete)
        {
            query = "DELETE FROM TBL_ORDERDETAILS WHERE TOS_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }

        public int deletereview(string delete)
        {
            query = "DELETE FROM TBL_REVIEW WHERE TR_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deletewishlist(string delete)
        {
            query = "DELETE FROM TBL_WISHLIST WHERE TW_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public int deleteitemview(string delete)
        {
            query = "DELETE FROM  TBL_ITEMVIEW WHERE TIW_PRODUCT_ID='" + delete + "'";
            return obj_DataAccess.RunQuery(query);
        }
        public DataSet sliderselect(Business_Property Business_Property_obj)
        {
            query = "SELECT * FROM TBL_SLIDER WHERE TS_PRODUCT_ID='" + Business_Property_obj.product_id + "'";
            return obj_DataAccess.GetData(query);
        }

        public DataSet filter(string search)
        {
            query = "SELECT TBL_PRODUCT.TP_PRODUCT_ID,TBL_PRODUCT.TP_CATEGORY_ID,TBL_PRODUCT.TP_PRODUCT_NAME,TBL_PRODUCT.TP_BRAND_NAME,TBL_PRODUCT.TP_PRICE,TBL_PRODUCT.TP_QUANTITY,TBL_PRODUCT.TP_DATE,TBL_IMAGE.TI_IMAGE_URL,TBL_SLIDER.TS_IMAGE_URL,TBL_FEATURED.TF_FEATURES FROM TBL_IMAGE,TBL_PRODUCT,TBL_SLIDER,TBL_FEATURED WHERE TBL_PRODUCT.TP_PRODUCT_ID='" + search + "' AND TBL_SLIDER.TS_PRODUCT_ID(+)=TBL_PRODUCT.TP_PRODUCT_ID AND TBL_FEATURED.TF_PRODUCT_ID='" + search + "' AND TBL_IMAGE.TI_PRODUCT_ID='" + search + "'";

            return obj_DataAccess.GetData(query);

        }

    }
}
