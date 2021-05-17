using DemoUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUI.UI
{
    public partial class LogInUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:50189/api/UserAccess";
            APIServiceResponse objAPIServiceResponse = new APIServiceResponse();
            USER_PROFILE objUSER_PROFILE = new USER_PROFILE();
            objUSER_PROFILE.USER_ID = txtUserId.Text;
            objUSER_PROFILE.USER_PASSWORD = txtPassword.Text;
            string uriData = "?UserId="+ objUSER_PROFILE.USER_ID + "&Password="+ objUSER_PROFILE.USER_PASSWORD;

            objAPIServiceResponse = httpRequestService.MakeRequest(url, uriData, "", "application/json", HttpMethod.Get);

            if (objAPIServiceResponse.STATUS == "SUCCESS")
            {
                Response.Redirect("HomePageUI.aspx");
                ClearField();
            }
            else
            {
                Response.Write("<script>alert('" + "Error Message: "+ objAPIServiceResponse.MESSAGE + "');</script>");
            }

        }

        public void ClearField()
        {
            txtUserId.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }


    }
}