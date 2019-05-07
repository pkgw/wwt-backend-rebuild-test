using System;
using System.Data;
using System.Data.SqlClient;

namespace WWTMVC5.WWTWeb
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

  
        internal static SqlConnection GetConnectionLogging(string connStr )
        {
        
            SqlConnection myConnection = null;
            myConnection = new SqlConnection(connStr);
            return myConnection;
        }


        public static string PostFeedback( SqlConnection con, string GUID, byte type )
        {
            // type 1 = Windows client
            // type 2 = Web Client

            string strErrorMsg;
            //SqlConnection myConnection5 = GetConnectionLogging(con);

            try
            {
                con.Open();

                SqlCommand Cmd = null;
                Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 20;
                Cmd.Connection = con;

                Cmd.CommandText = "spLoginUser";

                SqlParameter CustParm = new SqlParameter("@pUserGUID", SqlDbType.VarChar);
                CustParm.Value = GUID.ToUpper();
                Cmd.Parameters.Add(CustParm);

                SqlParameter CustParm2 = new SqlParameter("@pCLientType", SqlDbType.TinyInt);
                CustParm2.Value = type;
                Cmd.Parameters.Add(CustParm2);



                Cmd.ExecuteNonQuery();


            }
            catch (InvalidCastException)
            { }

            catch (Exception ex)
            {
                //throw ex.GetBaseException();
                strErrorMsg = ex.Message;
                return strErrorMsg;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return "ok";

        }
   

        public static string PostLogin( SqlConnection con, string GUID, byte type, string version )
        {
            // type 1 = Windows client
            // type 2 = Web Client

            string strErrorMsg;
            //SqlConnection myConnection5 = GetConnectionLogging(con);

            try
            {
                con.Open();

                SqlCommand Cmd = null;
                Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 20;
                Cmd.Connection = con;

                Cmd.CommandText = "spLoginUserVersion";

                SqlParameter CustParm = new SqlParameter("@pUserGUID", SqlDbType.VarChar);
                CustParm.Value = GUID.ToUpper();
                Cmd.Parameters.Add(CustParm);

                SqlParameter CustParm2 = new SqlParameter("@pCLientType", SqlDbType.TinyInt);
                CustParm2.Value = type;
                Cmd.Parameters.Add(CustParm2);

                SqlParameter CustParm3 = new SqlParameter("@pUserVer", SqlDbType.VarChar);
                CustParm3.Value = version;
                Cmd.Parameters.Add(CustParm3);



                Cmd.ExecuteNonQuery();


            }
            catch (InvalidCastException)
            { }

            catch (Exception ex)
            {
                //throw ex.GetBaseException();
                strErrorMsg = ex.Message;
                return strErrorMsg;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return "ok";

        }
    }
}
