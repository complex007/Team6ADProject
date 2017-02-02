using Model;
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
        AdminserviceManager am = new AdminserviceManager();
        DHserviceManager dm = new DHserviceManager();
        string userRole = Roles.GetRolesForUser(Login1.UserName)[0];
        Department dept = am.FindEmployeebyID(Convert.ToInt32(Login1.UserName)).Department;
        if (dept.delegatecode.HasValue && dept.startdate.HasValue && dept.enddate.HasValue)
        {
            if (((DateTime)dept.startdate).CompareTo(DateTime.Now) <= 0)
            {
                if (((DateTime)dept.enddate).CompareTo(DateTime.Now) >= 0)
                {
                    dm.executeDelegation();
                }
                else
                {
                    dm.retrieveAuthority(dept.Employees.Where(x => x.role == "departmenthead" || x.role == "delegatedhead").First().employeecode);
                }
            }
        }

        switch (userRole)
        {
            case "departmentemployee":
            case "departmentrepresentative":
                Response.Redirect("~/Department/DErequestItem.aspx");
                break;
            case "departmenthead":
            case "delegatedemployee":
                Response.Redirect("~/Department/DHapproveReject.aspx");
                break;
            case "delegatedhead":
                Response.Redirect("~/Department/DHRetriveAuthority.aspx");
                break;
            case "storeclerk":
                Response.Redirect("~/Store/retrieveStockCard.aspx");
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