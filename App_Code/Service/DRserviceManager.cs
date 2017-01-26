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
    DepartmentDAO ddao = new DepartmentDAO();
    public DRserviceManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Department DRfindCurrentCollectionPoint(int id)
    {
        return ddao.DRfindCurrentCollectionPoint(id);

    }
    public void DRupdateCollectionPoint(string Cpoint, int repcode)
    {
        ddao.DRupdateCollectionPoint(Cpoint, repcode);
    }
}