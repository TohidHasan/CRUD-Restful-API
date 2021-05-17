using CRUDRestfulAPI.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUDRestfulAPI.Services
{
    public class UserAccessService
    {

        string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        public USER_PROFILE GetUserAccess(string UserId, string Password)
        {
            string vMsg = string.Empty;

            #region Insert Employee
            string ErrorCode = "", ErrorMsg = "";
            OracleConnection con = new OracleConnection(ConStr);
            OracleCommand cmd = new OracleCommand();
            USER_PROFILE ObjUSER_PROFILE = new USER_PROFILE();

            try
            {

                cmd.CommandText = "SP_USER_PROFILE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                
                cmd.Parameters.Add("pUserId", OracleDbType.NVarchar2).Value = UserId;
                cmd.Parameters.Add("pPassword", OracleDbType.NVarchar2).Value = Password;
                
                OracleParameter param = new OracleParameter("pServiceFlag", DBNull.Value);
                param.Direction = ParameterDirection.Output;
                param.Size = 500;
                cmd.Parameters.Add(param);

                OracleParameter param1 = new OracleParameter("perror_code", DBNull.Value);
                param1.Direction = ParameterDirection.Output;
                param1.Size = 500;
                cmd.Parameters.Add(param1);

                OracleParameter param2 = new OracleParameter("perror_msg", DBNull.Value);
                param2.Direction = ParameterDirection.Output;
                param2.Size = 500;
                cmd.Parameters.Add(param2);

                cmd.Parameters.Add("presult_set_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                con.Open();
                //cmd.Transaction = con.BeginTransaction();

                OracleDataReader dr = cmd.ExecuteReader();

                ErrorCode = cmd.Parameters["perror_code"].Value.ToString();
                ErrorMsg = cmd.Parameters["perror_msg"].Value.ToString();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Employee ObjEmployee1 = new Employee();
                        ObjUSER_PROFILE.USER_ID = dr["user_id"].ToString();
                        ObjUSER_PROFILE.USER_PASSWORD = dr["user_password"].ToString();
                        ObjUSER_PROFILE.SERVICE_FLAG = dr["service_flag"].ToString();
                        
                    }
                }
                dr.Close();





                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    vMsg = "No Data Found";
                }

            }
            catch (Exception ex)
            {
                vMsg = ex.Message;
                throw ex;
            }
            finally
            {
                con.Close();

                cmd.Dispose();
            }

            #endregion



            return ObjUSER_PROFILE;
        }





    }
}