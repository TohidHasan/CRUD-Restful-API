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
    public class DeleteService
    {



        string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();

        public string Delete(Employee objEmployee)
        {
            string vMsg = string.Empty;

            #region Insert Employee
            string ErrorCode = "", ErrorMsg = "";
            OracleConnection con = new OracleConnection(ConStr);
            OracleCommand cmd = new OracleCommand();



            try
            {

                cmd.CommandText = "SP_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                OracleParameter param = new OracleParameter("pEmployee_Id", objEmployee.EmployeeId);
                param.Direction = ParameterDirection.InputOutput;
                //param3.Size = 500;
                cmd.Parameters.Add(param);
                //cmd.Parameters.Add(("pEmployee_Id", OracleDbType.NVarchar2).Value = objEmployee.EmployeeId, ParameterDirection.InputOutput);
                //cmd.Parameters.Add("pEmployee_Id", OracleDbType.Int32).Value = objEmployee.EmployeeId;
                cmd.Parameters.Add("pName", OracleDbType.NVarchar2).Value = objEmployee.Name;
                cmd.Parameters.Add("pPosition", OracleDbType.NVarchar2).Value = objEmployee.Position;
                cmd.Parameters.Add("pAge", OracleDbType.NVarchar2).Value = objEmployee.Age;
                cmd.Parameters.Add("pSalary", OracleDbType.NVarchar2).Value = objEmployee.Salary;
                cmd.Parameters.Add("pOption", OracleDbType.NVarchar2).Value = "Delete";


                OracleParameter param1 = new OracleParameter("perror_code", DBNull.Value);
                param1.Direction = ParameterDirection.Output;
                //param3.Size = 500;
                cmd.Parameters.Add(param1);

                OracleParameter param2 = new OracleParameter("perror_msg", DBNull.Value);
                param2.Direction = ParameterDirection.Output;
                //param4.Size = 500;
                cmd.Parameters.Add(param2);

                cmd.Parameters.Add("presult_set_cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;



                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                con.Open();
                cmd.Transaction = con.BeginTransaction();
                int dr = cmd.ExecuteNonQuery();

                string errorCode = cmd.Parameters["perror_code"].Value.ToString();
                vMsg = cmd.Parameters["perror_msg"].Value.ToString();

                ErrorCode = cmd.Parameters["perror_code"].Value.ToString();
                ErrorMsg = cmd.Parameters["perror_msg"].Value.ToString();

                if (string.IsNullOrEmpty(ErrorMsg))
                {
                    cmd.Transaction.Commit();
                }
                else
                {
                    cmd.Transaction.Rollback();
                    vMsg = "Error Message: " + ErrorMsg;
                }
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                vMsg = ex.Message;
                throw ex;
            }


            #endregion



            return vMsg;
        }



    }
}