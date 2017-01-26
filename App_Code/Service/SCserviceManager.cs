using SS.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Service
{
    public class SCserviceManager
    {
        public string[] listDeliverCollectionPoint()
        {

           string [] cols=StockDepartmentDAO.listDeliverCollectionPoint().ToArray<string>();
            return cols;
        }
        public List<Disbursement> findDeliverDisburseByCollectionPoint(string colpoint)
        {
            List<Disbursement> dlist = new List<Disbursement>();
            dlist = StockDepartmentDAO.findDeliverDisburseByCollectionPoint(colpoint);
            return dlist;
        }
        public List<DisbursementItem> findDeliverDisburseItemByDisburseid(int id)
        {
            List<DisbursementItem> items = new List<DisbursementItem>();
            items = StockDepartmentDAO.findDeliverDisburseItemByDisburseid(id);
            return items;
        }
        public void UpdateDisbursementItem(List<DisbursementItem> items)
        {
            StockDepartmentDAO.UpdateDisbursementItem(items);
        }
        public DisbursementItem findDisbursementByDisburseAndItem(int disid,string itmid)
        {
            DisbursementItem item = new DisbursementItem();
            item = StockDepartmentDAO.findDisbursementByDisburseAndItem(disid, itmid);
            return item;
        }
        public Item findItemByItemcode(string id)
        {
            Item it = new Item();
            it = StockDepartmentDAO.findItemByItemcode(id);
             return it;
        }
        public double findPriceBySupplierAndItem(string suppliercode, string itemcode)
        {
            double price = StockDepartmentDAO.findPriceBySupplierAndItem(suppliercode,   itemcode);
            return price;
        }
        public  void createAdjustmentVoucher(AdjustmentVoucher item)
        {
            StockDepartmentDAO.createAdjustmentVoucher(item);

        }
    }

}