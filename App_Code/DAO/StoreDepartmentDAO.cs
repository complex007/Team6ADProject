using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class StoreDepartmentDAO
{
    static team6adprojectdbEntities ds = new team6adprojectdbEntities();

    public static List<string> findDeliverRequestDeptCode()
    {
        List<string> rd = ds.Disbursements.Where(y => y.collectiondate == null).Select(x => x.deptcode).Distinct().ToList<string>();
        return rd;
    }
    public static List<string> listDeliverCollectionPoint()
    {
        List<string> requestdeptcode = findDeliverRequestDeptCode();
        List<string> clist = new List<string>();
        foreach (string i in requestdeptcode)
        {
            string cp = ds.Departments.Where(x => x.deptcode == i).Select(y => y.collectionpoint).FirstOrDefault();
            if (!clist.Contains(cp))
            {
                clist.Add(cp);
            }

        }
        return clist;
    }
    public static List<Disbursement> findDeliverDisburseByCollectionPoint(string collectionpoint)
    {
        List<Department> requestdept = new List<Department>();
        List<Disbursement> dlist = new List<Disbursement>();

        requestdept = ds.Departments.Where(x => x.collectionpoint == collectionpoint).ToList<Department>();

        foreach (Department i in requestdept)
        {
            List<Disbursement> eachdlist = ds.Disbursements.Where(x => x.deptcode == i.deptcode && x.collectiondate == null).ToList<Disbursement>();
            dlist.AddRange(eachdlist);
        }

        return dlist;
    }

    public static List<DisbursementItem> findDeliverDisburseItemByDisburseid(string deptcode, string col)
    {
        List<DisbursementItem> ditems = new List<DisbursementItem>();

        ditems = ds.DisbursementItems.Where(x => x.Disbursement.deptcode == deptcode && x.Disbursement.Department.collectionpoint == col && x.Disbursement.collectiondate == null).ToList<DisbursementItem>();
        return ditems;
    }


    public static void UpdateDisbursementItem(List<DisbursementItem> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            string itmid = items[i].itemcode;
            int disid = items[i].disbursementid;
            DisbursementItem item = ds.DisbursementItems.Where(x => x.itemcode == itmid && x.disbursementid == disid).FirstOrDefault();
            item.actualquantity = items[i].actualquantity;
        }
        int id = items[0].disbursementid;
        Disbursement dis = ds.Disbursements.Where(x => x.disbursementid == id).FirstOrDefault();
        dis.collectiondate = DateTime.Today;
        ds.SaveChanges();
    }



    public static DisbursementItem findDisbursementByDisburseAndItem(int disid, string itmid)
    {
        DisbursementItem item = ds.DisbursementItems.Where(x => x.disbursementid == disid && x.itemcode == itmid).FirstOrDefault();
        return item;
    }
    public static Item findItemByItemcode(string id)
    {
        Item it = new Item();
        it = ds.Items.Where(x => x.itemcode == id).FirstOrDefault();
        return it;
    }
    public static double findPriceBySupplierAndItem(string suppliercode, string itemcode)
    {
        double price = ds.TenderQuotations.Where(x => x.suppliercode == suppliercode && x.itemcode == itemcode).Select(y => y.price).FirstOrDefault();
        return price;
    }
    public static void createAdjustmentVoucher(AdjustmentVoucher item)
    {
        int items = item.AdjustmentItems.Count;
        ds.AdjustmentVouchers.Add(item);
        ds.SaveChanges();
    }
    public static Requisition findLastUnapprovedRequisition(int userNo, string deptcode)
    {
        Requisition lastUnapproved = ds.Requisitions.Where(x => x.employeecode == userNo && x.deptcode == deptcode && x.approvercode == null).LastOrDefault();
        if (lastUnapproved == null)
        {
            Requisition result = new Requisition();
            result.deptcode = deptcode;
            result.employeecode = userNo;
            result.status = 0;
            ds.Requisitions.Add(result);
            ds.SaveChanges();
            return result;
        }
        else
            return lastUnapproved;
    }

    public static List<Requisition> findRequisitionidByStatus02()
    {
        List<Requisition> rlist = ds.Requisitions.Where(x => x.status == 0 || x.status == 2).ToList<Requisition>();
        return rlist;
    }
    public static List<String> getuniqueitems()
    {
        List<String> unique = new List<String>();
        List<String> listDistinct = new List<String>();
        unique = ds.RequisitionItems.Where(y => y.status == 0).Select(x => x.itemcode).ToList();
        listDistinct = unique.GroupBy(
         i => i,
         (key, group) => group.First()
     ).ToList();
        return listDistinct;
    }
    public static List<String> getuniqueitems2()
    {
        List<String> unique = new List<String>();
        List<String> listDistinct = new List<String>();
        unique = ds.RequisitionItems.Where(y => y.status == 2).Select(x => x.itemcode).ToList();
        listDistinct = unique.GroupBy(
         i => i,
         (key, group) => group.First()
     ).ToList();
        return listDistinct;
    }
    public static IEnumerable<dynamic> getrequestdept(String item)
    {

        //List<int> dept = new List<int>();
        //dept = sce.RequisitionItems.Where(x => x.itemcode==item).Select(y=> y.requisitionid).ToList();
        //return dept;


        var req = (from p in ds.RequisitionItems.Where(x => x.itemcode == item && x.status == 0 && x.Item.quantityonhand > 0)
                   select new
                   {

                       BIN = p.Item.bin,
                       Description = p.Item.itemdescription,
                       Quantity = p.quantity,
                       Actualqty = p.Item.quantityonhand,
                       RequisitionID = p.Requisition.requisitionid,
                       DepartmentName = p.Requisition.Department.deptname,
                       deptneeded = p.quantity,
                       Allocated = "",
                       p.itemcode
                   }).ToList();


        return req;



    }

    public static IEnumerable<dynamic> getrequestdeptstatus2(String item)
    {

        //List<int> dept = new List<int>();
        //dept = sce.RequisitionItems.Where(x => x.itemcode==item).Select(y=> y.requisitionid).ToList();
        //return dept;


        var req = (from p in ds.RequisitionItems.Where(x => x.itemcode == item && x.status == 2 && x.Item.quantityonhand > 0)
                   select new
                   {

                       BIN = p.Item.bin,
                       Description = p.Item.itemdescription,
                       Quantity = p.quantity,
                       Actualqty = p.Item.quantityonhand,
                       RequisitionID = p.Requisition.requisitionid,
                       DepartmentName = p.Requisition.Department.deptname,
                       deptneeded = p.quantity,
                       Allocated = "",
                       p.itemcode
                   }).ToList();


        return req;
    }
    public static Disbursement addtodisbursement(Disbursement disb)
    {
        Disbursement disbursement = findunapproveddisbursement().Where(x => x.deptcode == disb.deptcode && x.representativecode == disb.representativecode).LastOrDefault();
        if (disbursement == null)
        {
            ds.Disbursements.Add(disb);
            ds.SaveChanges();
            Disbursement disbid = ds.Disbursements.OrderByDescending(x => x.disbursementid).First();
            return disbid;
        }
        else
        {
            return disbursement;
        }
    }
    public static List<Disbursement> findunapproveddisbursement()
    {
        List<Disbursement> orders = new List<Disbursement>();
        orders = ds.Disbursements.Where(x => x.collectiondate == null).Select(y => y).ToList<Disbursement>();
        return orders;
    }
    public static void addtodisbursementitem(Disbursement disb, DisbursementItem disbitem)
    {
        if (disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode).Count() == 0)
        {
            ds.DisbursementItems.Add(disbitem);
            ds.SaveChanges();
        }
        else
        {
            if (disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode && x.actualquantity == null).Count() != 0)
            {
                DisbursementItem disbursementitem = disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode && x.actualquantity == null).First();
                disbursementitem.allocatedquantity = disbursementitem.allocatedquantity + disbitem.allocatedquantity;
                ds.SaveChanges();
            }
        }
    }
    public static string getdepartmentcode(string d)
    {
        string dcode;
        Department d1 = ds.Departments.Where(x => x.deptname == d).First();
        dcode = d1.deptcode;
        return dcode;
    }
    public static int getrepresentativecode(string dcode)
    {
        int repcode;
        Employee e = ds.Employees.Where(x => x.deptcode == dcode && x.role == "departmentrepresentative").First();
        repcode = e.employeecode;
        return repcode;

    }

}
