using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
public class Service1 : IService
{
    SCserviceManager scmanager = new SCserviceManager();
    DHserviceManager dhmanager = new DHserviceManager();
    public string[] listDeliverCollectionPoint()
    {
        string[] cols = scmanager.listDeliverCollectionPoint();
        return cols;
    }
    public WCFDisbursement[] findDeliverDisburseByCollectionPoint(string colpoint)
    {
        List<Disbursement> dlist = new List<Disbursement>();
        dlist = scmanager.findDeliverDisburseByCollectionPoint(colpoint);
        List<WCFDisbursement> wdkust = new List<WCFDisbursement>();
        foreach (Disbursement i in dlist)
        {
            WCFDisbursement wdept = WCFDisbursement.Make(i.disbursementid, i.deptcode, i.representativecode, i.collectiondate);
            wdkust.Add(wdept);
        }
        return wdkust.ToArray();
    }
    public WCFDisbursementItem[] findDeliverDisburseItemByDisburseid(string id)
    {
        int disid = Convert.ToInt32(id);
        List<DisbursementItem> items = scmanager.findDeliverDisburseItemByDisburseid(disid);
        List<WCFDisbursementItem> itemarray = new List<WCFDisbursementItem>();
        foreach (DisbursementItem i in items)
        {
            WCFDisbursementItem item = WCFDisbursementItem.Make(i.disbursementid, i.itemcode, i.allocatedquantity, i.actualquantity);
            itemarray.Add(item);
        }
        return itemarray.ToArray();
    }

    public void UpdateDisbursementItem(List<WCFDisbursementItem> disitems)
    {
        List<DisbursementItem> items = new List<DisbursementItem>();
        for (int i = 0; i < disitems.Count; i++)
        {
            DisbursementItem item = scmanager.findDisbursementByDisburseAndItem(disitems[i].Disbursementid, disitems[i].Itemcode);
            item.actualquantity = disitems[i].Actualquantity;
            items.Add(item);
        }
        scmanager.UpdateDisbursementItem(items);
    }
    public WCFItem findItemByItemcode(string id)
    {
        Item it = scmanager.findItemByItemcode(id);
        WCFItem ite = WCFItem.Make(it.itemcode, it.category, it.itemdescription, it.bin, it.quantityonhand, it.reorderlevel, it.reorderquantity, it.unitofmeasure, it.Supplier.suppliercode, it.Supplier4.suppliercode, it.Supplier5.suppliercode, it.del);
        return ite;
    }

    public void createAdjustment(List<WCFAdjustmentItem> adjitems)
    {
        AdjustmentVoucher adjs = new AdjustmentVoucher();
        double cost = 0;
        foreach (WCFAdjustmentItem i in adjitems)
        {
            AdjustmentItem item = new AdjustmentItem();
            item.itemcode = i.Itemcode;
            item.quantity = i.Quantity;
            item.reason = i.Reason;
            double price = scmanager.findPriceBySupplierAndItem(i.Suppliercode, i.Itemcode);
            cost += item.quantity * price;
            adjs.AdjustmentItems.Add(item);
        }
        adjs.issuedate = DateTime.Today;
        adjs.cost = cost;
        adjs.clerkcode = 1027;
        string di = adjs.ToString();
        scmanager.createAdjustmentVoucher(adjs);
    }

    public List<WCFRequisitionItem> findRequisitionItemsByHead(string head)
    {
        int headcode = Convert.ToInt32(head);
        List<WCFRequisitionItem> rilist = new List<WCFRequisitionItem>();
        List<RequisitionItem> rlist = dhmanager.findRequisitionItemsByHead(headcode);
        foreach (RequisitionItem j in rlist)
        {
            WCFRequisitionItem wcfitem = WCFRequisitionItem.Make(j.requisitionid, j.itemcode, j.quantity, j.status);
            rilist.Add(wcfitem);
        }
        return rilist;

    }

    public void rejectRequisition(string requisitionid)
    {
        int id = Convert.ToInt32(requisitionid);
        Requisition item = dhmanager.findRequisitionByRequisitionId(id);
        //dhmanager.sendRejectEmail("android reject requisition");
        dhmanager.reject(id);
    }

    public void approveRequisition(string[] reidandheid)
    {
        int rid = Convert.ToInt32(reidandheid[0]);
        int hid = Convert.ToInt32(reidandheid[1]);
        dhmanager.approve(rid, hid);
    }
    public List<WCFEmployee> populateEmployee(string headcode)
    {
        int hcode = Convert.ToInt32(headcode);
        List<WCFEmployee> wcfelist = new List<WCFEmployee>();
        List<Employee> elist = dhmanager.PopulateEmpList(hcode);
        foreach (Employee i in elist)
        {
            WCFEmployee e = WCFEmployee.Make(i.employeecode, i.employeename, i.employeeemail, i.deptcode, i.role, i.del);
            wcfelist.Add(e);
        }
        return wcfelist;
    }
    public void setRepresentative(WCFEmployee remp)
    {
        int emcode = remp.Employeecode;
        string deptcode = remp.Deptcode;
        Employee re = dhmanager.getDepartmentRepresentativeByDept(deptcode);
        int recode = re.employeecode;
        dhmanager.changePreviousRepresentative(recode);
        dhmanager.setRepresentative(emcode);
    }
    public void updateCollectionPoint(string[] cpointandhecode)
    {
        string cpoint = cpointandhecode[0];
        int hecode = Convert.ToInt32(cpointandhecode[1]);
        dhmanager.DHupdateCollectionPoint(cpoint, hecode);
    }
    public string[] findCurrentCollectionPoint(string headid)
    {
        int head = Convert.ToInt32(headid);
        Department thatdept = dhmanager.DHfindCurrentCollectionPoint(head);
        string collectionpoint = thatdept.collectionpoint;
        string[] col = new string[] { collectionpoint };
        return col;
    }
}

