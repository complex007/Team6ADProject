using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DRserviceManager
/// </summary>

public class DRserviceManager
{
    public DRserviceManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Department DRfindCurrentCollectionPoint(int id)
    {
        return DepartmentDAO.DRfindCurrentCollectionPoint(id);

    }
    public void DRupdateCollectionPoint(string Cpoint, int repcode)
    {
        DepartmentDAO.DRupdateCollectionPoint(Cpoint, repcode);
    }
}