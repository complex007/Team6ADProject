using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        string userRole = Roles.GetRolesForUser(Login1.UserName)[0];
        switch (userRole)
        {
            case "departmentemployee":
            case "departmentrepresentative":
                Response.Redirect("~/Department/DErequestItem.aspx");
                break;
            case "departmenthead":
                Response.Redirect("~/Department/DHapproveReject.aspx");
                break;
            case "storeclerk":
                Response.Redirect("~/Department/DHapproveReject.aspx");
                break;
            case "storesupervisor":
            case "storemanager":
                Response.Redirect("~/Store/SSapproveRejectOrder.aspx");
                break;
            default:
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                break;
        }
    }
}