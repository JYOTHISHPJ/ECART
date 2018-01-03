using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{




    public class DataAccessLayerClass
    {
        OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
      

        public DataSet GetData(string query)
        {
            DataSet ds = new DataSet();
            try
            {               
                Conn.Open();
                OracleDataAdapter adap = new OracleDataAdapter(query, Conn);
                adap.Fill(ds);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                Conn.Close();
                ds.Dispose();
            }         
            return ds;
           
        }

        public int RunQuery(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                Conn.Open();
                OracleCommand command = new OracleCommand(query, Conn);
                int res = command.ExecuteNonQuery();
                if (res > 0)
                    return 1;   // If insertion is Succesful
                else
                    return 0;   // If insertion is Unsuccesful
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                Conn.Close();
                ds.Dispose();
            }
            
            
        }
        public int ExecuteSP(ref OracleParameter[] parameters, string procedureName)
        {
            OracleCommand cmd = new OracleCommand();
            int rval = 0;
            try
            {
                Conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (OracleParameter pm in parameters)
                {
                    cmd.Parameters.Add(pm);
                }
                cmd.CommandText = procedureName;
                cmd.Connection = Conn;
                rval = cmd.ExecuteNonQuery();

            }
            catch (OracleException sqlerr)
            {

                throw sqlerr;

            }
            catch (Exception err)
            {

                throw err;
            }
            finally
            {
                Conn.Close();
            }
            return rval;
        }
    }
}
