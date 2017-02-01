using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for SCserviceManager
/// </summary>
public class SCserviceManager
{
    team6adprojectdbEntities sce = new team6adprojectdbEntities();
    public SCserviceManager()
    {
        
    }
    //Update catalogue
    public Item getItem(string itcode)
    {
        Item it = sce.Items.Where(x => x.itemcode == itcode).FirstOrDefault();
        return it;
    }
    public List<Item> getCatalogue()
    {
        List<Item> catalogue = new List<Item>();
        catalogue = sce.Items.Where(x=>x.del==0).Select(y => y).ToList();
        //catalogue = sce.Items.Select(y => y).ToList();
        return catalogue;
    }

    public void deleteItem(string itcode)
    {
        Item it = getItem(itcode);
        //sce.Items.Remove(it);

        it.del = 1;
        sce.SaveChanges();
    }

    public void updateCatalogue(Item i)
    {
        var req = (from item in sce.Items
                  where item.itemcode == i.itemcode
                  select item).FirstOrDefault();

        req.itemdescription = i.itemdescription;
        req.category = i.category;
        req.reorderlevel = i.reorderlevel;
        req.reorderquantity = i.reorderquantity;
        req.unitofmeasure = i.unitofmeasure;
        req.bin = i.bin;

        sce.SaveChanges();
    }

    public void saveCatalogue(Item i)
    {
        sce.Items.Add(i);
        sce.SaveChanges();
    }

    //Update stock supplier
    public List<string> getItemcode()
    {
        List<string> list = sce.Items.Select(x => x.itemcode).ToList();
        return list;
    }

    public List<string> getSuppliercode()
    {
        List<string> list = sce.Suppliers.Select(x => x.suppliercode).ToList();
        return list;
    }

    public void updateItem(Item i)
    {
        var req = (from item in sce.Items
                   where item.itemcode == i.itemcode
                   select item).FirstOrDefault();
        req.supplier1 = i.supplier1;
        req.supplier2 = i.supplier2;
        req.supplier3 = i.supplier3;

        //Item it = getItem(i.itemcode);
        //it.supplier1 = i.supplier1;
        //it.supplier2 = i.supplier2;
        //it.supplier3 = i.supplier3;
        sce.SaveChanges();
    }

    //Updata supplier information
    public List<Supplier> getSupplier()
    {
        List<Supplier> slist = sce.Suppliers.Where(x=>x.del==0).Select(x => x).ToList();
        //List<Supplier> slist=sce.Suppliers.Select(x => x).ToList();
        return slist;
    }

    public Supplier getSupplier(string suppliercode)
    {
        return sce.Suppliers.Find(suppliercode);       
    }

    public void updateSupplier(Supplier s)
    {
        var req = (from supplier in sce.Suppliers
                   where supplier.suppliercode == s.suppliercode
                   select supplier).FirstOrDefault();

        req.suppliername = s.suppliername;
        req.contactname = s.contactname;
        req.phonenumber = s.phonenumber;
        req.faxnumber = s.faxnumber;
        req.address = s.address;
        req.gstregistrationno = s.gstregistrationno;

        sce.SaveChanges();
    }

    public void saveSupplier(Supplier s)
    {
        sce.Suppliers.Add(s);
        sce.SaveChanges();
    }

    public void deleteSupplier(Supplier s)
    {
        s.del = 1;
        //sce.Suppliers.Remove(s);
        sce.SaveChanges();
    }

    //Update tender information
    public List<string> getSuppliername()
    {
        List<string> list = sce.Suppliers.Select(x => x.suppliername).ToList();
        return list;
    }

    public Supplier getSupplierByName(string suppliername)
    {
        Supplier s = sce.Suppliers.Where(x => x.suppliername == suppliername).Select(y => y).FirstOrDefault();
        return s;
    }

    public IEnumerable<dynamic> getTenderQuotation(string suppliercode)
    {
        var req = from tender in sce.TenderQuotations
                  join item in sce.Items on tender.itemcode equals item.itemcode
                  where tender.suppliercode == suppliercode
                  select new { itemdesc = item.itemdescription, price = tender.price };
                      
        //var req = sce.TenderQuotations.Where(x => x.itemcode == getItemcode(scode) && x.suppliercode == scode)

        return req;
    }

    public Item getItemByItemdescription(string itemdescription)
    {
        Item i = sce.Items.Where(x => x.itemdescription == itemdescription).Select(y => y).FirstOrDefault();
        return i;
    }

   public void deleteTenderQuotation(TenderQuotation t)
    {    
        sce.TenderQuotations.Remove(t);
        sce.SaveChanges();
    }

    public TenderQuotation getTenderQuotationByKey(string suppliercode,string itemcode)
    {
        
        TenderQuotation tq = sce.TenderQuotations.Where(x => x.suppliercode == suppliercode && x.itemcode == itemcode).FirstOrDefault();
        //TenderQuotation tq = sce.TenderQuotations.Where(x => x.itemcoditemcode) == .FirstOrDefault(); 

        return tq;
    }

    public void updateTenderQuotation(TenderQuotation tq)
    {
        TenderQuotation tender = new TenderQuotation();
        tender = getTenderQuotationByKey(tq.suppliercode, tq.itemcode);
        tender.price = tq.price;

        sce.SaveChanges();
    }
    //public void updateTenderQuotation(Item i,TenderQuotation tq)
    //{

    //    Item item = new Item();
    //    item = getItem(i.itemcode);
    //    item.itemdescription = i.itemdescription;

    //    TenderQuotation tender = new TenderQuotation();
    //    tender = getTenderQuotationByKey(tq.suppliercode, tq.itemcode);
    //    tender.price = tq.price;

    //    sce.SaveChanges();     
    //}

    //public List<Item> getItemByListcode(List<string> list)
    //{
    //    List<Item> ilist = new List<Item>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        Item item = sce.Items.Where(x => x.itemcode == list[i]).Select(y => y).FirstOrDefault();
    //        ilist.Add(item);
    //    }
    //    return ilist;
    //}
    //public List<double> getPriceByListcode(List<string> list)
    //{
    //    List<double> plist = new List<double>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        double price = sce.TenderQuotations.Where(x => x.itemcode == list[i]).Select(y => y.price).FirstOrDefault();
    //        plist.Add(price);
    //    }
    //    return plist;
    //}

    //Report stock discrepancy
    public List<string> getItemCodeBySupplierCode(string suppliercode)
    {
        List<string> list = new List<string>();
        list = sce.TenderQuotations.Where(x => x.suppliercode == suppliercode).Select(y => y.itemcode).ToList();
        return list;
    }

   
    public void adjustItem(AdjustmentVoucher adjust)
    {

        //sce.AdjustmentItems.Add(adjust);

        //sce.SaveChanges();

        sce.AdjustmentVouchers.Add(adjust);
        sce.SaveChanges();


    }
    public string[] listDeliverCollectionPoint()
    {

        string[] cols = StoreDepartmentDAO.listDeliverCollectionPoint().ToArray<string>();
        return cols;
    }
    public List<Disbursement> findDeliverDisburseByCollectionPoint(string colpoint)
    {
        List<Disbursement> dlist = new List<Disbursement>();
        dlist = StoreDepartmentDAO.findDeliverDisburseByCollectionPoint(colpoint);
        return dlist;
    }
    public List<DisbursementItem> findDeliverDisburseItemByDisburseid(int id)
    {
        List<DisbursementItem> items = new List<DisbursementItem>();
        items = StoreDepartmentDAO.findDeliverDisburseItemByDisburseid(id);
        return items;
    }
    public void UpdateDisbursementItem(List<DisbursementItem> items)
    {
        StoreDepartmentDAO.UpdateDisbursementItem(items);
    }
    public DisbursementItem findDisbursementByDisburseAndItem(int disid, string itmid)
    {
        DisbursementItem item = new DisbursementItem();
        item = StoreDepartmentDAO.findDisbursementByDisburseAndItem(disid, itmid);
        return item;
    }
    public Item findItemByItemcode(string id)
    {
        Item it = new Item();
        it = StoreDepartmentDAO.findItemByItemcode(id);
        return it;
    }
    public double findPriceBySupplierAndItem(string suppliercode, string itemcode)
    {
        double price = StoreDepartmentDAO.findPriceBySupplierAndItem(suppliercode, itemcode);
        return price;
    }
    public void createAdjustmentVoucher(AdjustmentVoucher item)
    {
        StoreDepartmentDAO.createAdjustmentVoucher(item);

    }

    //Vishal's additions
    //Vishal's additions
    //Vishal's additions

    public IEnumerable<dynamic> gettransaction(String itemcode)
    {
        var transactions = sce.Transactions.Where(x => x.itemcode == itemcode).Select(y => new { Date = y.date, Department = y.deptsupplier, quantity = y.quantitychange, balance = y.balance }).ToList();
        return transactions;
    }
    public void raiseReorder(Item item, int userNo)
    {
        StoreSupplierDAO.addItemOrder(item, userNo, item.supplier1);
    }

    public Item getitemdetails(String id)
    {

        Item item = sce.Items.Where(x => x.itemcode == id).First();
        return item;
    }
    public List<Transaction> gettransactions(String id)
    {
        List<Transaction> trans = new List<Transaction>();
        trans = sce.Transactions.Where(x => x.itemcode == id).ToList();
        return trans;
    }
    //public List<> getrequest()
    //{

    //var req = (from z in sce.Requisitions.Select(x => x).DefaultIfEmpty()
    //           from p in sce.RequisitionItems.Where(x => x.requisitionid == z.requisitionid).DefaultIfEmpty()
    //           from t in sce.Items.Where(x => x.itemcode == p.itemcode).DefaultIfEmpty()
    //           select new
    //           {
    //               Bin = t.bin,
    //               Description = t.itemdescripion,
    //               Quantity = p.quantity,
    //               Actual_qty = t.quantityonhand,
    //               Department = z.Department.deptname,
    //               dept_needed = p.quantity,
    //               code = t.itemcode

    //           }).ToList();
    //}


    public List<String> getuniqueitems()
    {
        List<String> unique = new List<String>();
        List<String> listDistinct = new List<String>();
        unique = sce.RequisitionItems.Where(y => y.status == 0).Select(x => x.itemcode).ToList();
        listDistinct = unique.GroupBy(
         i => i,
         (key, group) => group.First()
     ).ToList();
        return listDistinct;
    }
    public List<String> getuniqueitems2()
    {
        List<String> unique = new List<String>();
        List<String> listDistinct = new List<String>();
        unique = sce.RequisitionItems.Where(y => y.status == 2).Select(x => x.itemcode).ToList();
        listDistinct = unique.GroupBy(
         i => i,
         (key, group) => group.First()
     ).ToList();
        return listDistinct;
    }
    public List<dynamic> getrequestdeptstatus(string item)
    {
        List<dynamic> list = StoreDepartmentDAO.getrequestdept(item).ToList();

        return list;
    }

    public List<dynamic> getrequestdeptstatus2(string item)
    {
        List<dynamic> list = StoreDepartmentDAO.getrequestdeptstatus2(item).ToList();

        return list;
    }

    public Item getsuppliercode(string itemcode)
    {

        Item supplier = sce.Items.Where(x => x.itemcode == itemcode).First();


        return supplier;
    }
    public TenderQuotation getprice(String suppliercode, String item)
    {


        TenderQuotation price = sce.TenderQuotations.Where(x => x.suppliercode == suppliercode && x.itemcode == item).First();
        return price;

    }
    //public OrderItem getorderquantity(String code)
    //{
    //    OrderItem qty = sce.OrderItems.Where(c => c.itemcode == code).First();
    //        return qty;
    //}
    public IEnumerable<dynamic> getdept(string location)
    {
        var dept = sce.Departments.Where(x => x.collectionpoint == location).Select(y => new { deptname = y.deptname, deptcode = y.deptcode }).ToList();

        return dept;
    }
    public List<int> getdis(String deptcode)


    {
        List<int> dis = sce.Disbursements.Where(x => x.deptcode == deptcode && x.collectiondate == null).Select(y => y.disbursementid).ToList();
        return dis;

    }
    public IEnumerable<dynamic> getdisbursementitems(int disid)
    {

        var disitems = sce.DisbursementItems.Where(x => x.disbursementid == disid && x.actualquantity == null).Select(y => new {
            Itemcode = y.itemcode,
            ItemDescription = y.Item.itemdescription,
            AllocatedQuantity = y.allocatedquantity,
            actualquantity = y.allocatedquantity,
            disbursementid = y.disbursementid

        }).ToList();
        return disitems;
    }

    public List<int> getpurchaseid(String suppliercode)
    {
        List<int> purchaseid = sce.SOrders.Where(y => y.suppliercode == suppliercode && y.deliveryordernumber == null && y.approvercode != null).Select(x => x.purchaseordernumber).ToList();
        return purchaseid;
    }
    public IEnumerable<dynamic> getorderdetails(int purchaseid)
    {
        var order = sce.OrderItems.Where(x => x.purchaseordernumber == purchaseid).Select(y => new {
            purchaseid = y.purchaseordernumber,
            ItemCode = y.itemcode,
            ItemDescription = y.Item.itemdescription,
            Quantity = y.orderquantity,
            Actual = y.orderquantity,
            Remarks = ""
        }).ToList();
        return order;
    }
    public List<int> recommendDistribution(int available, List<int> requested)
    {
        List<int> result = requested;
        while (requested.Sum() > available)
        {
            int highest = requested.Max();
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == highest)
                {
                    result[i]--;
                    break;
                }
            }
        }
        return result;
    }

    public void updateStatus(int reqid, String itemcode, int actual)
    {

        RequisitionItem r = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.itemcode == itemcode).First();
        r.status = 1;
        Item i = sce.Items.Where(x => x.itemcode == itemcode).First();
        i.quantityonhand = actual;
        sce.SaveChanges();

    }
    public Requisition getemployeecode(int reqid)
    {
        Requisition employeeid = sce.Requisitions.Where(x => x.requisitionid == reqid).First();
        return employeeid;
    }
    public void owestatus(int reqid, String itemcode, int owe, int allocated, String dept, int employeecode, RequisitionItem status)
    {
        RequisitionItem r = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.itemcode == itemcode).First();
        r.quantity = allocated;
        Item i = sce.Items.Where(x => x.itemcode == itemcode).First();
        i.quantityonhand = 0;
        r.status = 1;
        sce.SaveChanges();
        if (status.status == 0)
        {
            List<RequisitionItem> rlist = sce.RequisitionItems.Where(x => x.Requisition.deptcode == dept && x.itemcode == itemcode && x.status == 0).ToList();
            foreach (RequisitionItem k in rlist)
            {
                sce.RequisitionItems.Remove(k);

            }
        }
        Requisition lastUnconfirmedAuto = findLastUnapprovedOrderSC(dept, employeecode);

        if (lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid).Count() == 0)
        {

            RequisitionItem reqitem = new RequisitionItem();
            reqitem.requisitionid = lastUnconfirmedAuto.requisitionid;
            reqitem.itemcode = itemcode;
            reqitem.quantity = owe;
            reqitem.status = 2;
            sce.RequisitionItems.Add(reqitem);
            lastUnconfirmedAuto.RequisitionItems.Add(reqitem);
            sce.SaveChanges();
        }
        else
        {


            if (lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid && x.status == 2).Count() != 0)
            {
                RequisitionItem oi = lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid && x.status == 2).First();
                oi.quantity = oi.quantity + owe;
                sce.SaveChanges();

            }
            else
            {
                Requisition nwrq = generatenewrequisition(dept, employeecode);

                RequisitionItem req = new RequisitionItem();

                req.requisitionid = nwrq.requisitionid;
                req.itemcode = itemcode;
                req.quantity = owe;
                req.status = 2;
                sce.RequisitionItems.Attach(req);
                sce.RequisitionItems.Add(req);
                sce.SaveChanges();

            }

        }



    }

    public void deliverstatus(int reqid, String itemcode, int owe, int allocated, String dept, int employeecode)
    {
        RequisitionItem r = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.itemcode == itemcode).First();
        r.quantity = allocated;
        Item i = sce.Items.Where(x => x.itemcode == itemcode).First();
        r.status = 3;
        sce.SaveChanges();
        Requisition lastUnconfirmedAuto = findLastUnapprovedOrderSC(dept, employeecode);

        if (lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid).Count() == 0)
        {

            RequisitionItem reqitem = new RequisitionItem();
            reqitem.requisitionid = lastUnconfirmedAuto.requisitionid;
            reqitem.itemcode = itemcode;
            reqitem.quantity = owe;
            reqitem.status = 2;
            sce.RequisitionItems.Add(reqitem);
            lastUnconfirmedAuto.RequisitionItems.Add(reqitem);
            sce.SaveChanges();
        }
        else
        {


            if (lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid && x.status == 2).Count() != 0)
            {
                RequisitionItem oi = lastUnconfirmedAuto.RequisitionItems.Where(x => x.itemcode == itemcode && x.requisitionid == lastUnconfirmedAuto.requisitionid && x.status == 2).First();
                oi.quantity = oi.quantity + owe;
                sce.SaveChanges();

            }
            else
            {
                Requisition nwrq = generatenewrequisition(dept, employeecode);

                RequisitionItem req = new RequisitionItem();

                req.requisitionid = nwrq.requisitionid;
                req.itemcode = itemcode;
                req.quantity = owe;
                req.status = 2;
                sce.RequisitionItems.Attach(req);
                sce.RequisitionItems.Add(req);
                sce.SaveChanges();

            }

        }



    }



    public Requisition generatenewrequisition(String dept, int employeecode)
    {
        Requisition result = new Requisition();
        result.employeecode = employeecode;
        result.deptcode = dept;
        sce.Requisitions.Add(result);
        sce.SaveChanges();
        Requisition newreq = sce.Requisitions.OrderByDescending(x => x.requisitionid).First();
        return newreq;

    }
    public Requisition findLastUnapprovedOrderSC(String dept, int employeecode)
    {
        Requisition lastUnapproved = findUnapprovedOrders().Where(x => x.employeecode == employeecode && x.deptcode == dept).LastOrDefault();
        if (lastUnapproved == null)
        {
            Requisition result = new Requisition();
            result.employeecode = employeecode;
            result.deptcode = dept;
            sce.Requisitions.Add(result);
            sce.SaveChanges();
            return result;
        }
        else
            return lastUnapproved;
    }
    public List<Requisition> findUnapprovedOrders()
    {
        List<Requisition> orders = new List<Requisition>();
        orders = sce.Requisitions.Where(x => x.approvercode == null).Select(y => y).ToList<Requisition>();
        return orders;
    }
    public string getdepartmentcode(string d)
    {
        string dcode;
        Department d1 = sce.Departments.Where(x => x.deptname == d).First();
        dcode = d1.deptcode;
        return dcode;
    }
    public int getrepresentativecode(string dcode)
    {
        int repcode;
        Employee e = sce.Employees.Where(x => x.deptcode == dcode && x.role == "departmentrepresentative").First();
        repcode = e.employeecode;
        return repcode;

    }
    public void addtodisbursementitem(Disbursement disb, DisbursementItem disbitem)
    {
        if (disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode).Count() == 0)
        {
            sce.DisbursementItems.Add(disbitem);
            sce.SaveChanges();
        }
        else
        {
            if (disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode && x.actualquantity == null).Count() != 0)
            {
                DisbursementItem disbursementitem = disb.DisbursementItems.Where(x => x.disbursementid == disbitem.disbursementid && x.itemcode == disbitem.itemcode && x.actualquantity == null).First();
                disbursementitem.allocatedquantity = disbursementitem.allocatedquantity + disbitem.allocatedquantity;
                sce.SaveChanges();
            }
        }


    }
    public Disbursement addtodisbursement(Disbursement disb)
    {
        Disbursement disbursement = findunapproveddisbursement().Where(x => x.deptcode == disb.deptcode && x.representativecode == disb.representativecode).LastOrDefault();
        if (disbursement == null)
        {
            sce.Disbursements.Add(disb);
            sce.SaveChanges();
            Disbursement disbid = sce.Disbursements.OrderByDescending(x => x.disbursementid).First();
            return disbid;
        }
        else
        {
            return disbursement;
        }
    }
    public List<Disbursement> findunapproveddisbursement()
    {
        List<Disbursement> orders = new List<Disbursement>();
        orders = sce.Disbursements.Where(x => x.collectiondate == null).Select(y => y).ToList<Disbursement>();
        return orders;
    }
    public Item getreorderlevel(String itemcode)
    {
        Item reorderlevel = sce.Items.Where(x => x.itemcode == itemcode).First();
        return reorderlevel;
    }
    public List<RequisitionItem> getrequisitions(string deptcode)
    {
        List<RequisitionItem> rlist = sce.RequisitionItems.Where(x => x.Requisition.deptcode == deptcode && x.status == 1).ToList();
        return rlist;

    }
    public List<Requisition> getreq(string deptcode)
    {
        List<Requisition> rlist = sce.Requisitions.Where(x => x.deptcode == deptcode && x.status == 0).ToList();
        return rlist;

    }
    public void updatedisb(String deptcode)
    {
        Disbursement disb = sce.Disbursements.Where(x => x.deptcode == deptcode && x.collectiondate == null).First();
        disb.collectiondate = DateTime.Now;
        sce.SaveChanges();
    }
    public RequisitionItem getstatus(int reqid, string itemcode)
    {
        RequisitionItem status = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.itemcode == itemcode).First();
        return status;
    }
    public void updatestatusto3(int reqid, string itemcode)
    {
        RequisitionItem req = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.itemcode == itemcode).First();
        req.status = 3;
        sce.SaveChanges();

    }
    public void updatedisbursement(int disbid, string itemcode, int actual)
    {
        DisbursementItem disb = sce.DisbursementItems.Where(x => x.disbursementid == disbid && x.itemcode == itemcode).First();
        disb.actualquantity = actual;
        sce.SaveChanges();

    }
    public int getreqcount(int reqid)
    {
        int count = sce.RequisitionItems.Where(x => x.requisitionid == reqid).Count();
        return count;
    }
    public int getstatuscount(int reqid)
    {
        int count = sce.RequisitionItems.Where(x => x.requisitionid == reqid && x.status == 3).Count();
        return count;
    }

    public void updaterequisition(int reqid, int approvercode)
    {
        Requisition req = sce.Requisitions.Where(x => x.requisitionid == reqid).First();
        req.approvercode = approvercode;
        req.approvaldate = DateTime.Now;
        req.status = 1;
        sce.SaveChanges();

    }
    public void updateorderitems(int purchaseid, String itemcode, string remarks)
    {
        OrderItem orderitem = sce.OrderItems.Where(x => x.purchaseordernumber == purchaseid && x.itemcode == itemcode).First();
        orderitem.remarks = remarks;
        sce.SaveChanges();
    }
    public void updatesorder(int purchaseid, int userid, String deliveryno)
    {
        SOrder order = sce.SOrders.Where(x => x.purchaseordernumber == purchaseid).First();
        order.deliverydate = DateTime.Now;
        order.receivercode = userid;
        order.deliveryordernumber = deliveryno;
        sce.SaveChanges();

    }
    public List<TenderQuotation> getsuppliercodes(String itemcode)
    {
        List<TenderQuotation> supplier = new List<TenderQuotation>();
        supplier = sce.TenderQuotations.Where(x => x.itemcode == itemcode).ToList();
        return supplier;
    }
    public void addadjustmentvoucher(double price, int clerkid, string itemcode, int quantity)
    {
        AdjustmentVoucher unapproved = findUnapprovedadjustment(clerkid, price, clerkid, quantity);
        if (unapproved.AdjustmentItems.Where(x => x.itemcode == itemcode && x.vouchernumber == unapproved.vouchernumber).Count() == 0)
        {
            AdjustmentItem item = new AdjustmentItem();
            item.vouchernumber = unapproved.vouchernumber;
            item.itemcode = itemcode;
            item.quantity = quantity;
            item.reason = "Delivery Discrepancy";
            sce.AdjustmentItems.Add(item);
            sce.SaveChanges();
        }
        else
        {
            AdjustmentItem item = unapproved.AdjustmentItems.Where(x => x.itemcode == itemcode && x.vouchernumber == unapproved.vouchernumber).First();
            item.quantity = item.quantity + quantity;
            sce.SaveChanges();


        }

    }
    public List<AdjustmentVoucher> findUnapprovedvouchers()
    {
        List<AdjustmentVoucher> orders = new List<AdjustmentVoucher>();
        orders = sce.AdjustmentVouchers.Where(x => x.approvercode == null).Select(y => y).ToList<AdjustmentVoucher>();
        return orders;
    }
    public AdjustmentVoucher findUnapprovedadjustment(int code, double price, int clerkid, int quantity)
    {
        AdjustmentVoucher orders = new AdjustmentVoucher();
        orders = findUnapprovedvouchers().Where(x => x.clerkcode == code).Select(y => y).LastOrDefault();
        if (orders == null)
        {
            AdjustmentVoucher voucher = new AdjustmentVoucher();
            voucher.issuedate = DateTime.Now;
            voucher.cost = quantity * price;
            voucher.clerkcode = clerkid;
            sce.AdjustmentVouchers.Add(voucher);
            sce.SaveChanges();
            return voucher;
        }
        else
        {
            orders.cost = orders.cost + (quantity * price);
            sce.SaveChanges();
            return orders;
        }
    }

}