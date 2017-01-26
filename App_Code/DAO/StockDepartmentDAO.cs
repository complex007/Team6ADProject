using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.DAO
{
    public class ClassDepartment
    {
        static team6adprojectdbEntities5 ds = new team6adprojectdbEntities5();

        public static List<string> findDeliverRequestDeptCode()
        {
            List<string> rd = ds.Disbursements.Where(y => y.collectiondate == null).Select(x => x.deptcode).Distinct().ToList<string>();
            return rd;
        }
        public static List<string> listDeliverCollectionPoint()
        {
            List<string> requestdeptcode = findDeliverRequestDeptCode();
            List<string> clist = new List<string>();
          foreach(string i in requestdeptcode)
            {
                string cp = ds.Departments.Where(x => x.deptcode == i).Select(y => y.collectionpoint).FirstOrDefault();
                clist.Add(cp);
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

        public static List<DisbursementItem> findDeliverDisburseItemByDisburseid(int id)
        {
            List<DisbursementItem> ditems = new List<DisbursementItem>();
            ditems = ds.DisbursementItems.Where(x => x.disbursementid == id).ToList<DisbursementItem>();
            return ditems;
        }
        public static void UpdateDisbursementItem(List<DisbursementItem> items)
        {
            for(int i =0; i<items.Count;i++)
            {
                string itmid = items[i].itemcode;
                int disid = items[i].disbursementid;
                DisbursementItem item = ds.DisbursementItems.Where(x => x.itemcode ==itmid && x.disbursementid ==disid ).FirstOrDefault();
                item.actualquantity = items[i].actualquantity;
            }
            int id = items[0].disbursementid;
            Disbursement dis = ds.Disbursements.Where(x => x.disbursementid ==id ).FirstOrDefault();
            dis.collectiondate = DateTime.Today;
            ds.SaveChanges();
        }



        public static DisbursementItem findDisbursementByDisburseAndItem(int disid,string itmid)
        {
            DisbursementItem item = ds.DisbursementItems.Where(x => x.disbursementid == disid&&x.itemcode==itmid).FirstOrDefault();
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
            int items=item.AdjustmentItems.Count;
            ds.AdjustmentVouchers.Add(item);
            ds.SaveChanges();

        }

    }
}