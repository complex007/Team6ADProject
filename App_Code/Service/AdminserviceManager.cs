using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for AdminserviceManager
/// </summary>
public class AdminserviceManager
{
    public MembershipCreateStatus AddEmployeeToForms(Employee emp)
    {
        MembershipCreateStatus result = EmployeeDAO.InsertEmployeeIntoFormsAuth(emp);
        return result;
    }
    public void clearAllForms()
    {
        EmployeeDAO.ClearFormsAuth();
    }
}