using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SS
{
    public class SSserviceManager
    {
        public List<SOrder> findUnapprovedOrders()
        {
            List<SOrder> olist = ClassList.findUnapprovedOrders();
            return olist;
        }

        public Supplier findSupplierByCode(string suppliercode)
        {
            
            Supplier that = ClassList.findSupplierByCode(suppliercode);
            if(that==null)
            {
                throw new SSexception("supplier not found");
            }
            else
            {
                return that;
            }          
        }
   
        public void deleteOrderByPurchaseOrder(int purchaseorder)
        {
           try
            {
                ClassList.deleteOrderByPurchaseOrder(purchaseorder);
            }
            catch(Exception e)
            {
                throw new SSexception("delete order failed because order not found :" + e.Message);
            }
        }

        public void approveOrderByPurchaseOrder(int purchaseorder)
        {
            try
            {
                ClassList.approveOrderByPurchaseOrder(purchaseorder);
            }
            catch (Exception e)
            {
                throw new SSexception("approve order failed because order not found :"+ e.Message);
            }
        }
        public List<Supplier> findSupplierByCategory(string cate)
        {
            List<Supplier> slist = ClassList.findSupplierByCategory(cate);
            if (slist == null)
            {
                throw new SSexception("supplier not found for this category");
            }
            else
            {
                return slist;
            }
        }
        public CryDataSet setReorderDataSet(string que)
        {
            return ClassList.setReorderDataSet(que);
        }
        public CryDataSet setRequisitionDataSet(string que)
        {
            return ClassList.setRequisitionDataSet(que);
        }

        public List<AdjustmentVoucher> findUnapprovedVouchers()
        {
            List<AdjustmentVoucher> alist = ClassList.findUnapprovedVouchers();
            return alist;
        }
        public void deleteAdjustmentByVoucherNumber(int vouchernumber)
        {
            try
            {
                ClassList.deleteAdjustmentByVoucherNumber(vouchernumber);
            }
            catch(Exception e)
            {
                throw new SSexception("delete adjustment voucher failed because adjustment voucher not found :" + e.Message); 
            }
        }
        public void approveAdjVoucher(int vouchernumber)
        {
            try
            {
                ClassList.approveAdjVoucher(vouchernumber);
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


    }
}