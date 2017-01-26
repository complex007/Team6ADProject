using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class SCserviceManager
    {
        public string[] listDeliverCollectionPoint()
        {

           string [] cols=StoreDepartmentDAO.listDeliverCollectionPoint().ToArray<string>();
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
        public DisbursementItem findDisbursementByDisburseAndItem(int disid,string itmid)
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
            double price = StoreDepartmentDAO.findPriceBySupplierAndItem(suppliercode,   itemcode);
            return price;
        }
        public  void createAdjustmentVoucher(AdjustmentVoucher item)
        {
            StoreDepartmentDAO.createAdjustmentVoucher(item);

        }
    }