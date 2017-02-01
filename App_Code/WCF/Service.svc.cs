﻿using Model;
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
    AuthserviceManager amanager = new AuthserviceManager();
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

            WCFRequisitionItem wcfitem = WCFRequisitionItem.Make(j.requisitionid, j.itemcode, j.Item.itemdescription, j.quantity, j.status);
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
    public WCFEmployee findCurrentRepresentative(string headid)
    {
        int head = Convert.ToInt32(headid);
        Employee current = dhmanager.getDepartmentRepresentative(head);
        WCFEmployee wcfcurrent = WCFEmployee.Make(current.employeecode, current.employeename, current.employeeemail, current.deptcode, current.role, current.del);
        return wcfcurrent;
    }
    public WCFEmployee Login(WCFLogin login)
    {
        Employee e = amanager.findEmployeeByName(login.Username);
        WCFEmployee wcfe = WCFEmployee.Make(e.employeecode, e.employeename, e.employeeemail, e.deptcode, e.role, e.del);
        return wcfe;
    }
    public string[] getuniqueitems()
    {
        string[] list = scmanager.getuniqueitems().ToArray<string>();
        return list;

    }
    public string[] getuniqueitems2()
    {
        string[] list = scmanager.getuniqueitems2().ToArray<string>();
        return list;
    }
    public List<WCFRequestDept> getrequestdeptstatus(string item)
    {
        IEnumerable<dynamic> rdlist = scmanager.getrequestdeptstatus(item);
        List<WCFRequestDept> redelist = getrequestdept(rdlist.ToList());
        return redelist;

    }
    public List<WCFRequestDept> getrequestdeptstatus2(string item)
    {
        List<dynamic> rdlist = scmanager.getrequestdeptstatus2(item);
        List<WCFRequestDept> redelist = getrequestdept(rdlist);

        return redelist;
    }
    public List<WCFRequestDept> getrequestdept(List<dynamic> rdlist)
    {
        List<WCFRequestDept> redelist = new List<WCFRequestDept>();
        int available = 0;
        List<int> requested = new List<int>();

        foreach (dynamic i in rdlist)
        {

            string itemdescription = i.Description;
            int quantityonhand = i.Actualqty;
            int requisitionid = i.RequisitionID;
            string deptname = i.DepartmentName;
            int deptneededquantity = i.deptneeded;
            int allocatedquantity = 0;
            string itemcode = i.itemcode;
            string bin = i.BIN;

            WCFRequestDept deitem = WCFRequestDept.Make(bin, itemdescription, quantityonhand, requisitionid, deptname, deptneededquantity, allocatedquantity, itemcode);
            redelist.Add(deitem);
            available = quantityonhand;

        }
        for (int j = 0; j < redelist.Count; j++)
        {
            for (int n = j + 1; n < redelist.Count; n++)
            {
                if (redelist[j].Deptname == redelist[n].Deptname)
                {
                    if (redelist[j].Requisitionid < redelist[n].Requisitionid)
                    {
                        redelist[j].Deptneededquantity += redelist[n].Deptneededquantity;
                        redelist.Remove(redelist[n]);
                    }
                }
            }
        }

        foreach (WCFRequestDept it in redelist)
        {
            requested.Add(it.Deptneededquantity);
        }

        List<int> allocatedlist = scmanager.recommendDistribution(available, requested);
        for (int i = 0; i < allocatedlist.Count; i++)
        {
            redelist[i].Allocatedquantity = allocatedlist[i];
        }

        return redelist;
    }
    public void sendRequestDepts(List<WCFRequestDept> rdlist)
    {
        foreach (WCFRequestDept i in rdlist)
        {
            string deptname = i.Deptname;
            string deptcode = scmanager.getdepartmentcode(deptname);
            int recode = scmanager.getrepresentativecode(deptcode);
            Disbursement disburse = new Disbursement();
            disburse.deptcode = deptcode;
            disburse.representativecode = recode;
            Disbursement newdisburse = scmanager.addtodisbursement(disburse);
            int id = newdisburse.disbursementid;
            DisbursementItem disburseitem = new DisbursementItem();
            disburseitem.disbursementid = id;
            disburseitem.itemcode = i.Itemcode;
            disburseitem.allocatedquantity = i.Allocatedquantity;
            scmanager.addtodisbursementitem(disburse, disburseitem);
        }
    }
}

