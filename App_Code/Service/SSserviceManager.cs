using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;


public class SSserviceManager
    {
        public List<SOrder> findUnapprovedOrders()
        {
            List<SOrder> olist = StoreSupplierDAO.findUnapprovedOrders();
            return olist;
        }

        public Supplier findSupplierByCode(string suppliercode)
        {
            
            Supplier that = StoreSupplierDAO.findSupplierByCode(suppliercode);
            if(that==null)
            {
                throw new SSexception("supplier not found");
            }
            else
            {
                return that;
            }          
        }
   
        public void deleteOrderByPurchaseOrder(int purchaseorder, int userNo)
        {
            string fromemail = StoreSupplierDAO.findEmployeeByCode(userNo).employeeemail;
            SOrder po = StoreSupplierDAO.findUnapprovedOrderByPurchaseOrder(purchaseorder);
            string toemail = po.Employee.employeeemail;
            try
            {
                StoreSupplierDAO.deleteOrderByPurchaseOrder(purchaseorder);
            }
            catch(Exception e)
            {
                throw new SSexception("delete order failed because order not found :" + e.Message);
            }
            sendMailToEmployee(String.Format("Order no. {0} has been rejected.", purchaseorder), fromemail, toemail);
        }

        public void deleteOrderByPurchaseOrder(int purchaseorder, int userNo, string message)
        {
            string fromemail = StoreSupplierDAO.findEmployeeByCode(userNo).employeeemail;
            SOrder po = StoreSupplierDAO.findUnapprovedOrderByPurchaseOrder(purchaseorder);
            string toemail = po.Employee.employeeemail;
            try
            {
                StoreSupplierDAO.deleteOrderByPurchaseOrder(purchaseorder);
            }
            catch (Exception e)
            {
                throw new SSexception("delete order failed because order not found :" + e.Message);
            }
            sendMailToEmployee(String.Format("Order no. {0} has been rejected. Reason given: {1}", purchaseorder, message), fromemail, toemail);
        }

        public void approveOrderByPurchaseOrder(int purchaseorder, int userNo)
        {
            try
            {
                StoreSupplierDAO.approveOrderByPurchaseOrder(purchaseorder, userNo, findThreeworkingday(DateTime.Now));
            }
            catch (Exception e)
            {
                throw new SSexception("approve order failed because order not found :"+ e.Message);
            }
        }
        public List<Supplier> findSupplierByCategory(string cate)
        {
            List<Supplier> slist = StoreSupplierDAO.findSupplierByCategory(cate);
            if (slist == null)
            {
                throw new SSexception("supplier not found for this category");
            }
            else
            {
                return slist;
            }
        }
        public SS.CryDataSet setReorderDataSet(string que)
        {
            return StoreSupplierDAO.setReorderDataSet(que);
        }
        public SS.CryDataSet setRequisitionDataSet(string que)
        {
            return StoreSupplierDAO.setRequisitionDataSet(que);
        }

        public List<AdjustmentVoucher> findUnapprovedVouchers()
        {
            List<AdjustmentVoucher> alist = StoreSupplierDAO.findUnapprovedVouchers();
            return alist;
        }
        public void deleteAdjustmentByVoucherNumber(int vouchernumber, int userNo)
        {
            string fromemail = StoreSupplierDAO.findEmployeeByCode(userNo).employeeemail;
            AdjustmentVoucher av = StoreSupplierDAO.findUnapprovedAdjByVoucherNumber(vouchernumber);
            string toemail = av.Employee.employeeemail;
            try
            {
                StoreSupplierDAO.deleteAdjustmentByVoucherNumber(vouchernumber);
            }
            catch(Exception e)
            {
                throw new SSexception("delete adjustment voucher failed because adjustment voucher not found :" + e.Message); 
            }
            sendMailToEmployee(String.Format("Adjustment voucher no. {0} has been rejected.", vouchernumber), fromemail, toemail);
        }
        public void deleteAdjustmentByVoucherNumber(int vouchernumber, int userNo, string message)
        {
            string fromemail = StoreSupplierDAO.findEmployeeByCode(userNo).employeeemail;
            AdjustmentVoucher av = StoreSupplierDAO.findUnapprovedAdjByVoucherNumber(vouchernumber);
            string toemail = av.Employee.employeeemail;
            try
            {
                StoreSupplierDAO.deleteAdjustmentByVoucherNumber(vouchernumber);
            }
            catch (Exception e)
            {
                throw new SSexception("delete adjustment voucher failed because adjustment voucher not found :" + e.Message);
            }
            sendMailToEmployee(String.Format("Order no. {0} has been rejected. Reason given: {1}", vouchernumber, message), fromemail, toemail);
        }
        public void approveAdjustmentByVoucherNumber(int vouchernumber, int userNo)
        {
            try
            {
                AdjustmentVoucher av = StoreSupplierDAO.findUnapprovedAdjByVoucherNumber(vouchernumber);
                foreach(AdjustmentItem i in av.AdjustmentItems)
                {
                    i.Item.quantityonhand = i.Item.quantityonhand + i.quantity;

                    if (i.Item.quantityonhand < i.Item.reorderlevel && !StoreSupplierDAO.hasUndeliveredOrders(i.itemcode))
                    {
                        raiseReorder(i.Item, 1031);
                    }
                }
                StoreSupplierDAO.approveAdjVoucher(vouchernumber, userNo);
            }
            catch (Exception e)
            {
                throw new SSexception("approve adjustment voucher failed because adjustment voucher not found :" + e.Message);
            }
        }

        public void sendMailToEmployee(string message, string fromemail, string toemail)
        {
            SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
            MailMessage mail = new MailMessage();
            // string reason = TextBox1.Text;
            mail.Body = message;

            //Setting From , To and CC
            mail.From = new MailAddress(fromemail);
            mail.To.Add(new MailAddress(toemail));
            //  mail.CC.Add(new MailAddress("843168572@qq.com"));
            smtpClient.Send(mail);
        }

        public static DateTime findThreeworkingday(DateTime today)
        {

            DateTime endday = today;
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                endday = today.AddDays(4);
            }
            else if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                endday = today.AddDays(6);
            }
            else if (today.DayOfWeek == DayOfWeek.Wednesday)
            {
                endday = today.AddDays(6);
            }
            else if (today.DayOfWeek == DayOfWeek.Thursday)
            {
                endday = today.AddDays(6);
            }
            else if (today.DayOfWeek == DayOfWeek.Friday)
            {
                endday = today.AddDays(6);
            }
            else if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                endday = today.AddDays(5);
            }
            else
            {
                endday = today.AddDays(5);
            }
            return endday;
        }
        public static void raiseReorder(Item item, int userNo)
        {
            string itemSupplier = item.supplier1;
            StoreSupplierDAO.addItemOrder(item, userNo, itemSupplier);
        }
    }