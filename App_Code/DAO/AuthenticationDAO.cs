using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class AuthenticationDAO
{
    static team6adprojectdbEntities ds = new team6adprojectdbEntities();
    public static Employee findEmployeeByName(string name)
    {
        Employee e = ds.Employees.Where(x => x.employeename == name).FirstOrDefault();
        return e;
    }
}
