using DemoUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUI.UI
{
    public partial class HomePageUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = "http://localhost:50189/api/ViewAll";
                APIServiceResponse objAPIServiceResponse = new APIServiceResponse();
                Employee objEmployee = new Employee();
                List<Employee> listOfEmployee = new List<Employee>();
                string Bodydata = JsonConvert.SerializeObject(objEmployee);

                listOfEmployee = httpRequestService.GetAllRequest(url, "", Bodydata, "application/json", HttpMethod.Get);

                gvShowAll.Visible = true;
                gvShowAll.DataSource = listOfEmployee;
                gvShowAll.DataBind();
                Session["EMPLOYEE_LIST"] = null;
                Session["EMPLOYEE_LIST"] = listOfEmployee;

            }

        }

        protected void gvShowAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Employee> vEmployeeInfoList = new List<Employee>();
            Employee objEmployee = new Employee();
            int i = gvShowAll.SelectedIndex;
            lshideselectindex.Value = i.ToString();

            if (Session["EMPLOYEE_LIST"] != null)
            {
                vEmployeeInfoList.AddRange((List<Employee>)Session["EMPLOYEE_LIST"]);
            }
            objEmployee = vEmployeeInfoList[gvShowAll.SelectedIndex];
            Session["SESSION_EMPLOYEE_ID"] = null;
            Session["SESSION_EMPLOYEE_ID"] = objEmployee.EmployeeId;

            Response.Redirect("EmployeeRegistrationUI.aspx");

            //string hg = objEmployee.EmployeeId;

        }

        protected void gvShowAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = gvShowAll.SelectedIndex;
            lshideselectindex.Value = i.ToString();

            GridViewRow row = (GridViewRow)gvShowAll.Rows[e.RowIndex];
            
            try
            {

                List<Employee> vEmployeeInfoList1 = new List<Employee>();

                List<Employee> vEmployeeInfoList = new List<Employee>();

                string sesionEMPLOYEE_LIST = string.Empty;
                if (Session["EMPLOYEE_LIST"] != null)
                {
                    sesionEMPLOYEE_LIST = Session["EMPLOYEE_LIST"].ToString();
                    vEmployeeInfoList.AddRange((List<Employee>)Session["EMPLOYEE_LIST"]);
                }

                //List<object> OLD_GV_Memo_List = new List<object>();
                //foreach (Employee Loop_Obj_Memo in vEmployeeInfoList)
                //{
                //    if (!Loop_Obj_Memo.bIsDeleted)
                //        OLD_GV_Memo_List.Add(Loop_Obj_Memo);
                //}

                
            }

            catch (Exception ex)
            {
                throw ex;
            }


            
            //string url = "http://localhost:50189/api/Delete";
            //APIServiceResponse objAPIServiceResponse = new APIServiceResponse();
            //Employee objEmployee = new Employee();
            //objEmployee.Name = txtName.Text;
            //objEmployee.Position = txtPosition.Text;
            //objEmployee.Age = txtAge.Text;
            //objEmployee.Salary = txtSalary.Text;

            //string Bodydata = JsonConvert.SerializeObject(objEmployee);

            //objAPIServiceResponse = httpRequestService.MakeRequest(url, "", Bodydata, "application/json", HttpMethod.Post);


            //if (objAPIServiceResponse.STATUS == "SUCCESS")
            //{
            //    Response.Write("<script>alert('" + objAPIServiceResponse.MESSAGE + "');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('" + objAPIServiceResponse.MESSAGE + "');</script>");
            //}


        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeRegistrationUI.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInUI.aspx");
        }
    }
}