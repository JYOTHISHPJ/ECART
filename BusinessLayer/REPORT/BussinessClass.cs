using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Configuration;

namespace BusinessLayer
{
    public class BussinessLayerClass
    {
        DataAccessLayerClass objDataAccessLayer = new DataAccessLayerClass();
        SessionClass ObjSessionClass = new SessionClass();
        int i = 0, j = 0;
        public int flag = 2;
        public SessionClass login(String Email1, String Password1)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //string qr = "select * from testing";
            string qr = "select * from TBL_USER";


            ds = objDataAccessLayer.GetData(qr);

            dt = ds.Tables[0];


            int n = dt.Rows.Count;

            try
            {
                for (i = 0; i < n; i++)
                {
                    String Email = dt.Rows[i]["TU_EMAIL_ID"].ToString();
                    String Password = dt.Rows[i]["TU_PASSWORD"].ToString();
                    if (Email == Email1 && Password == Password1)
                    {

                        string qr1 = "select TU_user_id,TU_ACTIVE from tbl_user where TU_email_id='" + Email + "'";
                        ds = objDataAccessLayer.GetData(qr1);
                        string id = ds.Tables[0].Rows[0]["TU_USER_ID"].ToString();

                        string acti = ds.Tables[0].Rows[0]["TU_ACTIVE"].ToString();

                        if (acti == "T" || acti == "t")
                        {
                            j = 1;

                            ObjSessionClass.sn_userid = id;
                            ObjSessionClass.status = j;
                        }

                        else if (acti == "F" || acti == "f")
                        {
                            j = 2;

                            ObjSessionClass.sn_userid = id;
                            ObjSessionClass.status = j;
                        }
                        break;
                    }
                    else
                    {
                        j = 0;
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return ObjSessionClass;
        }


        public int register(PropertyClass get, int otp)
        {
            int status = 0;
            DataSet ds1 = new DataSet();
            DataTable dt = new DataTable();
            DateTime date = DateTime.Today;
            int id;

            string a = "F";


            try
            {

                //string querych = "SELECT mail_id FROM testing Where mail_id= '" + get.mail + "'";
                string querych = "SELECT TU_email_id FROM tbl_user Where TU_email_id= '" + get.mail + "'";
                ds1 = objDataAccessLayer.GetData(querych);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    flag = 3;
                    return flag;


                }
                else
                {


                    //string query = "select max (USER_ID) from testing";

                    string query = "select max (TU_USER_ID) from TBL_USER";
                    ds1 = objDataAccessLayer.GetData(query);
                    dt = ds1.Tables[0];

                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                    {
                        id = Convert.ToInt32(dt.Rows[0][0]);
                        id = id + 1;
                    }
                    else
                    {
                        id = 1;
                    }


                    //string query1 = "insert into testing (USER_ID,USER_NAME,ADDRESS,MOB_NO,MAIL_ID,PASSWORD,C_DATE,E_DATE,ACTIVE,OTP)values(" + id + ",'" + get.name + "','" + get.address + "'," + get.mobno + ",'" + get.mail + "','" + get.password + "',SYSDATE,SYSDATE+60,'" + a + "'," + otp + ")";
                    string query1 = "insert into TBL_USER (TU_USER_ID,TU_USER_NAME,TU_ADDRESS,TU_MOB_NO,TU_EMAIL_ID,TU_PASSWORD,TU_OTP,TU_CREATED_DATE,TU_EXP_DATE,TU_ACTIVE)values(" + id + ",'" + get.name + "','" + get.address + "'," + get.mobno + ",'" + get.mail + "','" + get.password + "'," + otp + ",SYSDATE,SYSDATE+60,'" + a + "')";
                    status = objDataAccessLayer.RunQuery(query1);
                    return status;

                }
            }



            catch (Exception ex)
            {
                throw new ApplicationException("not inserted", ex);
            }


        }
        public DataSet cartdetails(BussinessLayerClass getd)
        {
            DataSet ds = new DataSet();

            //String query = "select b.reference_no,c.user_name,a.amount,a.p_date from testing c,tbl_order b,tbl_orderdetails a where c.user_id = b.user_id and a.order_id = b.order_id and a.user_id=c.user_id";
            String query = "select b.TOR_reference_no,c.TU_user_name,a.TOS_amount,a.TOS_date from TBL_USER c,tbl_order b,tbl_orderdetails a where c.TU_user_id = b.TOR_user_id and a.TOS_order_id = b.TOR_order_id and a.TOS_user_id=c.TU_user_id";
            ds = objDataAccessLayer.GetData(query);
            return ds;
        }

    }

}

