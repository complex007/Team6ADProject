using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Employee emp = new Employee();
        emp.employeename = CreateUserWizard1.UserName;
        emp.employeeemail = CreateUserWizard1.Email;
        DropDownList deptList = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("DeptList");
        emp.deptcode = deptList.SelectedItem.Text;
        DropDownList roleList = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("RoleList");
        emp.role = roleList.SelectedValue;
        emp.del = 0;
        EmployeeDAO.CreateNewEmployee(emp);

        string createRole = emp.role;
        if (!Roles.RoleExists(createRole))
        {
            Roles.CreateRole(createRole);
        }
        Roles.AddUserToRole(emp.employeename, createRole);
    }
}