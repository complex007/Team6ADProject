using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public static class DepartmentDAO
{
    static team6adprojectdbEntities ctx = new team6adprojectdbEntities();

    public static Department findDepartmentById(string dept)
    {
        return ctx.Departments.Find(dept);
    }
    public static List<Item> PopulateCatDropDownList(string category)
    {
        List<Item> Ilist = new List<Item>();
        Ilist = ctx.Items.Where(x => x.category == category).ToList();

        return Ilist;
    }
    public static void submitRequisitionItemList(List<String> qty, List<String> itemcode, int empcode)
    {
        try
        {
            int ReqSize = qty.Count;
            Employee e1 = ctx.Employees.Where(x => x.role == "departmentemployee" && x.employeecode == empcode).First();
            string dcode = e1.deptcode;
            var t = new Requisition
            {
                employeecode = empcode,
                deptcode = dcode,
                status = 0,
            };
            ctx.Requisitions.Add(t);
            ctx.SaveChanges();
            Requisition r1 = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).OrderByDescending(x => x.requisitionid).Take(1).Single();
            int rid = r1.requisitionid;
            for (int i = 0; i < ReqSize; i++)
            {
                var t1 = new RequisitionItem
                {
                    requisitionid = rid,
                    itemcode = itemcode.ElementAt(i),
                    quantity = Convert.ToInt32(qty.ElementAt(i)),
                    status = 0,
                };
                ctx.RequisitionItems.Add(t1);
                ctx.SaveChanges();
            }
        }
        catch (NullReferenceException n)
        {
            System.Diagnostics.Debug.Write("ensure all fields are filled");
        }
        catch (FormatException f)
        {
            System.Diagnostics.Debug.Write("input is wrong format");
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.Write("contact administrator for error: " + e);
        }
    }
    public static List<dynamic> retreiveRequistionsItems(int empcode)
    {
        List<dynamic> ridItemListDesc = new List<dynamic>();
        try
        {
            List<Requisition> ridList = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).ToList();
            List<int> ridIDList = ridList.Select(l => l.requisitionid).ToList();
            for (int i = 0; i < ridIDList.Count; i++)
            {
                int ridvar = ridIDList.ElementAt(i);
                var ridItemDesc = (from r in ctx.RequisitionItems
                                   join e in ctx.Items
                                   on r.itemcode equals e.itemcode
                                   where r.requisitionid == ridvar && r.status == 0
                                   select new
                                   {
                                       itemcode = r.itemcode,
                                       itemdesc = e.itemdescription,
                                       itemqty = r.quantity,
                                       rid = r.requisitionid,
                                       status = r.status,
                                       unit = e.unitofmeasure
                                   }).ToList();
                ridItemListDesc.AddRange(ridItemDesc);
            }
        }
        catch (NullReferenceException n)
        {
            System.Diagnostics.Debug.Write("no pending requisition items found");
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.Write("contact administrator for error: " + e);
        }

        return ridItemListDesc;
    }
    public static void updateRequistionsItems(string itemcode, string qty, string reqid, string orgqty)
    {
        try
        {
            int rid = Convert.ToInt32(reqid);
            int quantity = Convert.ToInt32(qty);
            int oquantity = Convert.ToInt32(orgqty);
            RequisitionItem rutable = ctx.RequisitionItems.Where(x => x.requisitionid == rid && x.itemcode == itemcode && x.quantity == oquantity && x.status == 0).First();
            rutable.quantity = quantity;
            ctx.SaveChanges();
        }
        catch (NullReferenceException n)
        {
            System.Diagnostics.Debug.Write("unable to update");
        }
        catch (FormatException f)
        {
            System.Diagnostics.Debug.Write("input is wrong format");
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.Write("contact administrator for error: " + e);
        }
    }
    public static void deleteRequistionsItems(string itemcode, string qty, string reqid, int empcode)
    {
        try
        {
            int rid = Convert.ToInt32(reqid);
            int quantity = Convert.ToInt32(qty);
            RequisitionItem reqitemtable = ctx.RequisitionItems.Where(x => x.requisitionid == rid && x.itemcode == itemcode && x.quantity == quantity && x.status == 0).First();
            ctx.RequisitionItems.Remove(reqitemtable);
            ctx.SaveChanges();
            //Check if Req is empty after delete items
            List<Requisition> ridList = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).ToList();
            List<int> ridIDList = ridList.Select(l => l.requisitionid).ToList();
            List<RequisitionItem> ridItemList = new List<RequisitionItem>();
            for (int i = 0; i < ridIDList.Count; i++)
            {
                int ridvar = ridIDList.ElementAt(i);
                var rec = ctx.RequisitionItems.Where(x => x.requisitionid == ridvar && x.status == 0).FirstOrDefault();
                if (rec == null)
                {
                    Requisition reqtable = ctx.Requisitions.Where(x => x.requisitionid == rid && x.employeecode == empcode).First();
                    ctx.Requisitions.Remove(reqtable);
                    ctx.SaveChanges();
                }
            }
        }
        catch (NullReferenceException n)
        {
            System.Diagnostics.Debug.Write("unable to delete");
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.Write("contact administrator for error: " + e);
        }
    }
    public static string getUnit(string itemcode)
    {
        string itemunit = "";
        itemunit = ctx.Items.Where(x => x.itemcode == itemcode).Select(l => l.unitofmeasure).First();

        return itemunit;
    }
    public static Department DRfindCurrentCollectionPoint(int id)
    {
        //  string CollectionPoint;
        Department d1 = new Department();

        Employee e1 = ctx.Employees.Where(x => x.role == "departmentrepresentative" && x.employeecode == id).First();
        string deptcode = e1.deptcode;
        d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
        return d1;
    }
    public static void DRupdateCollectionPoint(string Cpoint, int repcode)
    {
        try
        {
            Employee e1 = ctx.Employees.Where(x => x.role == "departmentrepresentative" && x.employeecode == repcode).First();
            string deptcode = e1.deptcode;
            Department d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            d1.collectionpoint = Cpoint;
            ctx.SaveChanges();
        }
        catch (NullReferenceException n)
        {
            errormessage("no collection point found");
        }
        catch (Exception e)
        {
            errormessage("contact administrator for error: " + e);
        }
    }
    public static Department DHfindCurrentCollectionPoint(int id)
    {
        Department d1 = new Department();
        Employee e1 = ctx.Employees.Where(x => x.employeecode == id).First();
        string deptcode = e1.deptcode;
        d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
        return d1;
    }
    public static void DHupdateCollectionPoint(string Cpoint, int headcode)
    {
        try
        {
            Employee e1 = ctx.Employees.Where(x => x.employeecode == headcode).First();
            string deptcode = e1.deptcode;
            Department d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            d1.collectionpoint = Cpoint;
            ctx.SaveChanges();
        }
        catch (NullReferenceException n)
        {
            errormessage("no collection point found");
        }
        catch (Exception e)
        {
            errormessage("contact administrator for error: " + e);
        }
    }
    public static Employee getDepartmentRepresentative(int headcode)
    {
        string dept;

        Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).First();
        dept = e1.deptcode;
        Employee e2 = ctx.Employees.Where(x => x.deptcode == dept && x.role == "departmentrepresentative").First();
        return e2;
    }
    public static Employee getDepartmentRepresentativeByDept(string dept)
    {
        Employee e = ctx.Employees.Where(x => x.deptcode == dept && x.role == "departmentrepresentative").FirstOrDefault();
        return e;
    }
    public static List<Employee> PopulateEmpList(int headcode)
    {
        string dept;

        Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).First();
        dept = e1.deptcode;
        List<Employee> Elist = ctx.Employees.Where(x => x.deptcode == dept && x.role != "departmenthead").ToList();
        ctx.SaveChanges();
        return Elist;
    }
    public static void setRepresentative(int empCode)
    {
        try
        {
            Employee e1 = ctx.Employees.Where(x => x.employeecode == empCode).First();
            e1.role = "departmentrepresentative";
            ctx.SaveChanges();
        }
        catch (NullReferenceException n)
        {
            errormessage("no employee found");
        }
        catch (Exception e)
        {
            errormessage("cannot set collection point because : " + e);
        }
    }
    public static void changePreviousRepresentative(int empCode)
    {
        try
        {
            Employee e1 = ctx.Employees.Where(x => x.employeecode == empCode).First();
            e1.role = "departmentemployee";
            ctx.SaveChanges();
        }
        catch (NullReferenceException n)
        {
            errormessage("no employee found");
        }
        catch (Exception e)
        {
            errormessage("contact admin. error message: " + e);
        }
    }
    public static List<Requisition> DHgetRequisitionItems(int headcode)
    {
        string dept;

        Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).FirstOrDefault();
        List<Requisition> rl;
        dept = e1.deptcode;
        rl = ctx.Requisitions.Where(x => x.deptcode == dept && x.approvercode == null && x.approvaldate == null).ToList();
        return rl;
    }
    public static IEnumerable<dynamic> getItems(int reqid)
    {

        var rlist = ctx.RequisitionItems.Where(x => x.requisitionid == reqid).Select(x => new { x.requisitionid, x.Item.itemdescription, x.quantity }).ToList();
        return rlist;
    }
    public static void approveRequisition(int id, int headcode)
    {
        try
        {
            Requisition r = ctx.Requisitions.Where(x => x.requisitionid == id).First();
            DateTime date = DateTime.Today;
            r.approvaldate = date;
            r.approvercode = headcode;
            ctx.SaveChanges();
        }
        catch (Exception e)
        {
            errormessage("cannot approve. contact admin for error:  " + e);
        }
    }
    public static void rejectRequisition(int id)
    {
        Requisition r = ctx.Requisitions.Where(x => x.requisitionid == id).First();
        ctx.Requisitions.Remove(r);
        ctx.SaveChanges();
    }
    public static string getEmployee(int requid)
    {
        int code;
        string email;

        Requisition r = ctx.Requisitions.Where(x => x.requisitionid == requid).First();
        code = r.employeecode;
        Employee e = ctx.Employees.Where(x => x.employeecode == code).First();
        email = e.employeeemail;
        return email;

    }
    public static List<Employee> getAllEmployees(int headcode)
    {
        string deptcode;

        List<Employee> elist = new List<Employee>();
        Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "departmenthead").First();
        deptcode = e.deptcode;
        elist = ctx.Employees.Where(x => x.deptcode == deptcode && x.role == "departmentemployee").ToList();
        return elist;
    }
    public static void delegateAuthority(int headcode, int ecode, DateTime from, DateTime to)
    {
        string deptcode;
        try
        {
            Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "departmenthead").First();
            deptcode = e.deptcode;
            Department d = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            d.delegatecode = ecode;
            d.startdate = from;
            d.enddate = to;
            ctx.SaveChanges();
        }
        catch (Exception e)
        {
            errormessage("delegation unsuccessful. contact admin for error:  " + e);
        }
    }
    public static void executeDelegation(string deptcode)
    {
        int headcode = findHeadByDepartment(deptcode).employeecode;
        int ecode = (int)ctx.Departments.Find(deptcode).delegatecode;
        Employee heademp = ctx.Employees.Where(x => x.employeecode == headcode && (x.role == "departmenthead" || x.role == "delegatedhead")).First();
        heademp.role = "delegatedhead";
        string dcode = heademp.deptcode;
        Employee delemp = ctx.Employees.Where(x => x.employeecode == ecode).First();
        delemp.role = "delegatedemployee";
        ctx.SaveChanges();
        string dheadrole = "delegatedhead";
        if (!Roles.RoleExists(dheadrole))
        {
            Roles.CreateRole(dheadrole);
        }
        if (!Roles.IsUserInRole(heademp.employeecode.ToString(), dheadrole))
        {
            Roles.AddUserToRole(heademp.employeecode.ToString(), dheadrole);
            Roles.RemoveUserFromRole(heademp.employeecode.ToString(), "departmenthead");
        }
        string demprole = "delegatedemployee";
        if (!Roles.RoleExists(demprole))
        {
            Roles.CreateRole(demprole);
        }
        if (!Roles.IsUserInRole(delemp.employeecode.ToString(), demprole))
        {
            Roles.AddUserToRole(delemp.employeecode.ToString(), demprole);
            Roles.RemoveUserFromRole(heademp.employeecode.ToString(), "departmentemployee");
        }
    }



public static void retriveAuthority(int headcode)
{
    string deptcode;

    Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "delegatedhead" || x.role == "departmenthead").FirstOrDefault();
    e.role = "departmenthead";
    deptcode = e.deptcode;
    Employee e1 = ctx.Employees.Where(x => x.role == "delegatedemployee" || x.role == "departmentemployee" && x.deptcode == deptcode).FirstOrDefault();
    e1.role = "departmentemployee";
    Department d = ctx.Departments.Where(x => x.deptcode == deptcode).First();
    d.delegatecode = null;
    d.startdate = null;
    d.enddate = null;
    ctx.SaveChanges();
    if (Roles.IsUserInRole(e.employeecode.ToString(), "delegatedhead"))
    {
        Roles.AddUserToRole(e.employeecode.ToString(), "departmenthead");
        Roles.RemoveUserFromRole(e.employeecode.ToString(), "delegatedhead");
    }
    if (Roles.IsUserInRole(e.employeecode.ToString(), "delegatedemployee"))
    {
        Roles.AddUserToRole(e1.employeecode.ToString(), "departmentemployee");
        Roles.RemoveUserFromRole(e.employeecode.ToString(), "delegatedemployee");
    }
}
public static void errormessage(string myStringVariable)
{
    System.Diagnostics.Debug.Write(myStringVariable);
}
public static List<RequisitionItem> findRequisitionItemsByHead(int headcode)
{
    Employee head = ctx.Employees.Where(x => x.employeecode == headcode).FirstOrDefault();
    string deptcode = head.deptcode;
    List<Requisition> items = ctx.Requisitions.Where(x => x.deptcode == deptcode && x.approvercode == null && x.approvaldate == null).ToList<Requisition>();
    List<RequisitionItem> ritems = new List<RequisitionItem>();
    foreach (Requisition i in items)
    {
        ritems.AddRange(i.RequisitionItems);
    }
    return ritems;

}
public static Requisition findRequisitionByRequisitionId(int requisitionid)
{
    Requisition item = ctx.Requisitions.Where(x => x.requisitionid == requisitionid).FirstOrDefault();
    return item;

}
public static Employee findHeadByDepartment(string deptcode)
{
    return ctx.Employees.Where(x => x.deptcode == deptcode && (x.role == "delegatedhead" || x.role == "departmenthead")).FirstOrDefault();
}
public static List<Department> ListAllDepartments()
{
    return ctx.Departments.ToList();
}
}
