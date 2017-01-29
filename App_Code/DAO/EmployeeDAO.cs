using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for EmployeeDAO
/// </summary>
public static class EmployeeDAO
{
    static team6adprojectdbEntities ctx = new team6adprojectdbEntities();
    public static Employee FindEmployeebyID(int id)
    {
        return ctx.Employees.Find(id);
    }
    public static MembershipCreateStatus InsertEmployeeIntoFormsAuth(Employee emp)
    {
        MembershipCreateStatus createStatus;
        MembershipUser newUser = Membership.CreateUser(emp.employeename, "abcdefgh1@", emp.employeeemail, null, null, true, out createStatus);
        string createRole = emp.role;
        if (!Roles.RoleExists(createRole))
        {
            Roles.CreateRole(createRole);
        }
        return createStatus;
    }
    public static void CreateNewEmployee(Employee emp)
    {
        ctx.Employees.Add(emp);
        ctx.SaveChanges();
    }
    public static void ClearFormsAuth()
    {
        foreach (MembershipUser m in Membership.GetAllUsers())
        {
            Membership.DeleteUser(m.UserName);
        }
    }
}