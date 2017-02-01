using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class AuthserviceManager
{
    public Employee findEmployeeByName(string name)
    {
        Employee e = AuthenticationDAO.findEmployeeByName(name);
        return e;
    }
}