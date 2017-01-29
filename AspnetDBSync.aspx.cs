using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    team6adprojectdbEntities ctx;
    protected void Page_Load(object sender, EventArgs e)
    {
        ctx = new team6adprojectdbEntities();
        GridView1.DataSource = ctx.Employees.ToList();
        GridView1.DataBind();
        refreshGridView2();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Employee emp = ctx.Employees.ToList()[Convert.ToInt32(e.CommandArgument)];
        MembershipCreateStatus createStatus = EmployeeDAO.InsertEmployeeIntoFormsAuth(emp);
        //MembershipUser newUser = Membership.CreateUser(emp.employeename, "abcdefgh1@", emp.employeeemail, null, null, true, out createStatus);
        string Text = "";
        switch (createStatus)
        {
            case MembershipCreateStatus.Success:
                Text = "The user account was successfully created!";
                break;
            case MembershipCreateStatus.DuplicateUserName:
                Text = "There already exists a user with this username.";
                break;

            case MembershipCreateStatus.DuplicateEmail:
                Text = "There already exists a user with this email address.";
                break;
            case MembershipCreateStatus.InvalidEmail:
                Text = "There email address you provided in invalid.";
                break;
            case MembershipCreateStatus.InvalidAnswer:
                Text = "There security answer was invalid.";
                break;
            case MembershipCreateStatus.InvalidPassword:
                Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";

                break;
            default:
                Text = "There was an unknown error; the user account was NOT created.";
                break;
        }
        Label1.Text = Text;
        string createRole = emp.role;
        if (!Roles.RoleExists(createRole))
        {
            Roles.CreateRole(createRole);
            Label1.Text = Text + "[Role created: " + createRole + "]";
            refreshGridView2();
        }
    }
    public void refreshGridView2()
    {
        GridView2.DataSource = Roles.GetAllRoles();
        GridView2.DataBind();
    }
}