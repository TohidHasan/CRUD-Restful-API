using DemoUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUI
{
    public partial class EmployeeRegistrationUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Employee> vEmployeeInfoList = new List<Employee>();
                Employee objEmployee = new Employee();
                string employeeId = string.Empty;
                if (Session["EMPLOYEE_LIST"] != null)
                {
                    vEmployeeInfoList.AddRange((List<Employee>)Session["EMPLOYEE_LIST"]);
                }
                if (Session["SESSION_EMPLOYEE_ID"] != null)
                {
                    employeeId = Session["SESSION_EMPLOYEE_ID"].ToString();
                }

                if (vEmployeeInfoList.Count > 0)
                {
                    objEmployee = vEmployeeInfoList.Find(q => q.EmployeeId == employeeId);
                }

                if (objEmployee != null)
                {

                    if (!string.IsNullOrEmpty(objEmployee.Name))
                    {
                        txtName.Text = objEmployee.Name;
                    }

                    if (!string.IsNullOrEmpty(objEmployee.Position))
                    {
                        txtPosition.Text = objEmployee.Position;
                    }
                    if (!string.IsNullOrEmpty(objEmployee.Age))
                    {
                        txtAge.Text = objEmployee.Age;
                    }
                    if (!string.IsNullOrEmpty(objEmployee.Salary))
                    {
                        txtSalary.Text = objEmployee.Salary;
                    }

                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = string.Empty;
            string employeeId = string.Empty;
            if (Session["EMPLOYEE_LIST"] != null)
            {
                url = "http://localhost:50189/api/Edit";
            }
            else
            {
                url = "http://localhost:50189/api/Add";
                ClearField();
            }

            if (Session["SESSION_EMPLOYEE_ID"] != null)
            {
                employeeId = Session["SESSION_EMPLOYEE_ID"].ToString();
            }

            APIServiceResponse objAPIServiceResponse = new APIServiceResponse();
            Employee objEmployee = new Employee();
            objEmployee.EmployeeId = employeeId;
            objEmployee.Name = txtName.Text;
            objEmployee.Position = txtPosition.Text;
            objEmployee.Age = txtAge.Text;
            objEmployee.Salary = txtSalary.Text;

            string Bodydata = JsonConvert.SerializeObject(objEmployee);

            objAPIServiceResponse = httpRequestService.MakeRequest(url, "", Bodydata, "application/json", HttpMethod.Post);


            if (objAPIServiceResponse.STATUS == "SUCCESS")
            {
                Response.Write("<script>alert('" + objAPIServiceResponse.MESSAGE + "');</script>");
                ClearField();
            }
            else
            {
                Response.Write("<script>alert('" + objAPIServiceResponse.MESSAGE + "');</script>");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageUI.aspx");
        }


        public void ClearField()
        {
            txtName.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtSalary.Text = string.Empty;
            Session["EMPLOYEE_LIST"] = null;
            Session["SESSION_EMPLOYEE_ID"] = null;
        }
    }
}