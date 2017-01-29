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
    public static Employee findEmployeebyID (int id)
    {
        return ctx.Employees.Find(id);
    }
    public static MembershipCreateStatus insertEmployeeIntoFormsAuth (Employee emp)
    {
        MembershipCreateStatus createStatus;
        MembershipUser newUser = Membership.CreateUser(emp.employeecode.ToString(), "abcdefgh1@", emp.employeeemail, null, null, true, out createStatus);
        return createStatus;
    }
}