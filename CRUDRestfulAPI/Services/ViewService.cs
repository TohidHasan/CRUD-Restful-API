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
    public class ViewService
    {

        string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();

        public Employee View(string pEmployeeId)
        {
            string vMsg = string.Empty;

            #region Insert Employee
            string ErrorCode = "", ErrorMsg = "";
            OracleConnection con = new OracleConnection(ConStr);
            OracleCommand cmd = new OracleCommand();
            Employee objEmployee = new Employee();
            //List<Employee> listObjEmployee = new List<Employee>();

            try
            {

                cmd.CommandText = "SP_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                OracleParameter param = new OracleParameter("pEmployee_Id", pEmployeeId);
                param.Direction = ParameterDirection.InputOutput;
                param.Size = 500;
                cmd.Parameters.Add(param);
                //cmd.Parameters.Add(("pEmployee_Id", OracleDbType.NVarchar2).Value = objEmployee.EmployeeId, ParameterDirection.InputOutput);
                //cmd.Parameters.Add("pEmployee_Id", OracleDbType.Int32).Value = objEmployee.EmployeeId;
                cmd.Parameters.Add("pName", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pPosition", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pAge", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pSalary", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pOption", OracleDbType.NVarchar2).Value = "GetById";


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
                        objEmployee.EmployeeId = dr["employee_id"].ToString();
                        objEmployee.Name = dr["employee_name"].ToString();
                        objEmployee.Position = dr["position"].ToString();
                        objEmployee.Age = dr["age"].ToString();
                        objEmployee.Salary = dr["salary"].ToString();

                        //listObjEmployee.Add(objEmployee);
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



            return objEmployee;
        }







        public List<Employee> ViewAll()
        {
            string vMsg = string.Empty;

            #region Insert Employee
            string ErrorCode = "", ErrorMsg = "";
            OracleConnection con = new OracleConnection(ConStr);
            OracleCommand cmd = new OracleCommand();
            Employee objEmployee = new Employee();
            List<Employee> listObjEmployee = new List<Employee>();

            try
            {

                cmd.CommandText = "SP_Employee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                OracleParameter param = new OracleParameter("pEmployee_Id", DBNull.Value);
                param.Direction = ParameterDirection.InputOutput;
                param.Size = 500;
                cmd.Parameters.Add(param);
                //cmd.Parameters.Add(("pEmployee_Id", OracleDbType.NVarchar2).Value = objEmployee.EmployeeId, ParameterDirection.InputOutput);
                //cmd.Parameters.Add("pEmployee_Id", OracleDbType.Int32).Value = objEmployee.EmployeeId;
                cmd.Parameters.Add("pName", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pPosition", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pAge", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pSalary", OracleDbType.NVarchar2).Value = string.Empty;
                cmd.Parameters.Add("pOption", OracleDbType.NVarchar2).Value = "GetAll";


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
                        Employee ObjEmployee1 = new Employee();
                        ObjEmployee1.EmployeeId = dr["employee_id"].ToString();
                        ObjEmployee1.Name = dr["employee_name"].ToString();
                        ObjEmployee1.Position = dr["position"].ToString();
                        ObjEmployee1.Age = dr["age"].ToString();
                        ObjEmployee1.Salary = dr["salary"].ToString();

                        listObjEmployee.Add(ObjEmployee1);
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



            return listObjEmployee;
        }




    }
}