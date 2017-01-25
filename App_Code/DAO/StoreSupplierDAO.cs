using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SS
{
    public class StoreSupplierDAO
    {
       static  team6adprojectdbEntities ds = new team6adprojectdbEntities();
        public static List<SOrder> findUnapprovedOrders()
        {
            List<SOrder>  orders = new List<SOrder>();         
            orders = ds.SOrders.Where(x => x.approvercode == null).Select(y => y).ToList<SOrder>();
            return orders;
        }
        public static Supplier findSupplierByCode(string suppliercode)
        {
            Supplier supplier = new Supplier();
            supplier = ds.Suppliers.Where(x => x.suppliercode == suppliercode).Select(y => y).FirstOrDefault();
            return supplier;
        }
        public static Employee findEmployeeByCode(int employeecode)
        {
            Employee employee = new Employee();
            employee = ds.Employees.Where(x => x.employeecode == employeecode).Select(y => y).FirstOrDefault();
            return employee;
        }
        //public static List<OrderItem> findOrderItemByPurchaseOrder(int purchaseorder)
        //{
        //    List<OrderItem> orderitems = new List<OrderItem>();
        //    orderitems = ds.OrderItems.Where(x => x.purchaseordernumber == purchaseorder).Select(y => y).ToList<OrderItem>();
        //    return orderitems;
        //}

        //add 1/19
        public static SOrder findUnapprovedOrderByPurchaseOrder(int purchaseorder)
        {
            SOrder thisorder = ds.SOrders.Where(x => x.purchaseordernumber == purchaseorder && x.approvercode==null).Select(y => y).FirstOrDefault();
            return thisorder;
        }

        public static void deleteOrderByPurchaseOrder(int purchaseorder)
        {
            SOrder thisorder = findUnapprovedOrderByPurchaseOrder(purchaseorder);
            ds.SOrders.Remove(thisorder);
            ds.SaveChanges();
        }

        public static void approveOrderByPurchaseOrder(int purchaseorder, int approvercode, DateTime findThreeworkingday)
            {
            SOrder s = findUnapprovedOrderByPurchaseOrder(purchaseorder);
            DateTime dt;
            //need to change approvercode after session['employeecode'] is create
            s.approvercode = 1029;
            s.approvaldate = DateTime.Today;
            if (s.approvaldate.HasValue)
            {
                dt = s.approvaldate.Value;
                s.expecteddeliverydate = findThreeworkingday;
            }
            ds.SaveChanges();
          
        }
        

        public static List<Supplier> findSupplierByCategory(string cate)
        {
            List<Supplier> suppliers = new List<Supplier>();

            List<Supplier> su1 = ds.Items.Where(y=>y.category==cate).Select(x => x.Supplier).Distinct().ToList<Supplier>();
            List<Supplier> su2= ds.Items.Where(y => y.category == cate).Select(x => x.Supplier4).Distinct().ToList<Supplier>();
            List<Supplier> su3 = ds.Items.Where(y => y.category == cate).Select(x => x.Supplier5).Distinct().ToList<Supplier>();
            for (int i=0;i<su1.Count;i++)
            {
                string j = su1[i].suppliername;
                 
                    suppliers.Add(su1[i]);   
            }

            for (int i = 0; i < su2.Count; i++)
            {
                string j = su2[i].suppliername;
                suppliers.Add(su2[i]);         
            }
            for (int i = 0; i <su3.Count; i++)
            {
                string j = su3[i].suppliername;
                suppliers.Add(su3[i]);
             }

            List<Supplier> result = suppliers.Distinct().ToList<Supplier>();
            return result;
        }
        public static CryDataSet setReorderDataSet(string que)
        {
            string sr = que;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=team6adprojectdb;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            CryDataSet ds = new CryDataSet();           
            SqlDataAdapter ad = new SqlDataAdapter(que, con);
            ad.Fill(ds.reordertrend3);
            return ds;
        }
        public static CryDataSet setRequisitionDataSet(string que)
        {
            string sr = que;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=team6adprojectdb;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            CryDataSet ds = new CryDataSet();
            SqlDataAdapter ad = new SqlDataAdapter(que, con);
            ad.Fill(ds.requisitiontrend);
            return ds;
        }
        public static List<AdjustmentVoucher> findUnapprovedVouchers()
        {
            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();

            list = ds.AdjustmentVouchers.Where(x => x.approvercode == null).Select(y => y).ToList<AdjustmentVoucher>();
            return list;
        }

        public static AdjustmentVoucher findUnapprovedAdjByVoucherNumber(int vouchernumber)
        {

            AdjustmentVoucher adj = ds.AdjustmentVouchers.Where(x => x.vouchernumber == vouchernumber&&x.approvercode==null).Select(y => y).FirstOrDefault();
            return adj;
        }
        public static void deleteAdjustmentByVoucherNumber(int vouchernumber)
        {
            AdjustmentVoucher adj = findUnapprovedAdjByVoucherNumber(vouchernumber);

            ds.AdjustmentVouchers.Remove(adj);
            ds.SaveChanges();
        }
        public static void approveAdjVoucher(int vouchernumber, int userNo)
        {
            AdjustmentVoucher adj = findUnapprovedAdjByVoucherNumber(vouchernumber);

            adj.approvercode = userNo;
            adj.approvaldate = DateTime.Today;
            ds.SaveChanges();

        }
    }
}