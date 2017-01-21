using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ClassList
{
    static team6adprojectdbEntities ds = new team6adprojectdbEntities();

    public static List<SOrder> findUnapprovedOrders()
    {
        List<SOrder> orders = new List<SOrder>();
        orders = ds.SOrders.Where(x => x.approvercode == null).Select(y => y).ToList<SOrder>();
        //orders = ds.SOrders.Where(x => x.approvercode == null).ToList();
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
    public static List<OrderItem> findOrderItemByPurchaseOrder(int purchaseorder)
    {
        List<OrderItem> orderitems = new List<OrderItem>();

        orderitems = ds.OrderItems.Where(x => x.purchaseordernumber == purchaseorder).Select(y => y).ToList<OrderItem>();
        return orderitems;
    }

    //add 1/19
    public static SOrder findOrderByPurchaseOrder(int purchaseorder)
    {
        SOrder thisorder = ds.SOrders.Where(x => x.purchaseordernumber == purchaseorder).Select(y => y).FirstOrDefault();
        return thisorder;
    }

    public static void deleteOrderByPurchaseOrder(int purchaseorder)
    {
        SOrder thisorder = findOrderByPurchaseOrder(purchaseorder);
        ds.SOrders.Remove(thisorder);
        ds.SaveChanges();
    }

    public static void approveOrderByPurchaseOrder(int purchaseorder)
    {
        SOrder s = findOrderByPurchaseOrder(purchaseorder);
        DateTime dt;
        //need to change approvercode after session['employeecode'] is create
        s.approvercode = 1029;
        s.approvaldate = DateTime.Today;
        if (s.approvaldate.HasValue)
        {
            dt = s.approvaldate.Value;
            s.expecteddeliverydate = findThreeworkingday(dt);
        }
        ds.SaveChanges();

    }
    public static DateTime findThreeworkingday(DateTime today)
    {

        DateTime endday = today;

        if (today.DayOfWeek == DayOfWeek.Monday)
        {
            endday = today.AddDays(4);
        }
        if (today.DayOfWeek == DayOfWeek.Tuesday)
        {
            endday = today.AddDays(6);
        }
        if (today.DayOfWeek == DayOfWeek.Wednesday)
        {
            endday = today.AddDays(6);
        }
        if (today.DayOfWeek == DayOfWeek.Thursday)
        {
            endday = today.AddDays(6);
        }
        if (today.DayOfWeek == DayOfWeek.Friday)
        {
            endday = today.AddDays(6);
        }
        if (today.DayOfWeek == DayOfWeek.Saturday)
        {
            endday = today.AddDays(5);
        }
        if (today.DayOfWeek == DayOfWeek.Sunday)
        {
            endday = today.AddDays(5);
        }
        return endday;
    }

    public static void sendEmail(string message)
    {
        SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
        MailMessage mail = new MailMessage();
        // string reason = TextBox1.Text;
        mail.Body = message;

        //Setting From , To and CC
        mail.From = new MailAddress("hellocomplex007@gmail.com");
        mail.To.Add(new MailAddress("hellocomplex007@gmail.com"));
        //  mail.CC.Add(new MailAddress("843168572@qq.com"));
        smtpClient.Send(mail);
    }
    public static List<Item> findItembycategory(string category)
    {
        List<Item> list = new List<Item>();
        list = ds.Items.Where(x => x.category == category).Select(y => y).ToList<Item>();
        return list;

    }

    public static List<Supplier> findSupplierbysuppliercode(string suppliercode)
    {
        List<Supplier> list = new List<Supplier>();

        list = ds.Suppliers.Where(x => x.suppliercode == suppliercode).Select(y => y).ToList<Supplier>();
        return list;
    }

    //public static string[] findSupplierByCategory(string category)
    //{
    //    List<Supplier> list = new List<Supplier>();
    //    List<Item> items = findItembycategory(category);
    //   List<string> names =new List<string>();
    //    foreach (Item i in items)
    //    {
    //        string n1 = i.Supplier.suppliername;
    //        string n2 = i.Supplier4.suppliername;
    //        string n3= i.Supplier5.suppliername;

    //       foreach(string i in names)
    //        {
    //            if(i.Equals(n1))
    //            {
    //                names.Add(n1);
    //            }
    //            if (i.Equals(n1))
    //            {
    //                names.Add(n1);
    //            }
    //            if (i.Equals(n1))
    //            {
    //                names.Add(n1);
    //            }
    //        }
    //    }
    //    return names;

    //}

    public static List<string> findSupplierNameBySupplier(string category)
    {
        List<string> names = null;
        var req = (from q in ds.Items.Where(x => x.category == category)
                   select new
                   {
                       SupplierName1 = q.Supplier,
                       SupplierName2 = q.Supplier4,
                       SupplierName3 = q.Supplier5
                   }
                  ).ToList();

        return names;
    }
    public static string[] findSupplierNameBySupplier(List<Supplier> list)
    {
        string[] names = new string[list.Count];

        for (int i = 0; i < list.Count; i++)
        {
            string name = list[1].suppliername;
            names[i] = name;
        }

        return names;
    }
    public static Item findItembyitemcode(string itemcode)
    {
        Item item;

        item = ds.Items.Where(x => x.itemcode == itemcode).Select(y => y).FirstOrDefault();
        return item;
    }

    public static List<AdjustmentVoucher> findUnapprovedvoucher()
    {
        List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();

        list = ds.AdjustmentVouchers.Where(x => x.approvercode == null).Select(y => y).ToList<AdjustmentVoucher>();
        return list;
    }
    public static List<AdjustmentItem> findAdjitembyvouchernumber(int vouchernumber)
    {
        List<AdjustmentItem> list = new List<AdjustmentItem>();

        list = ds.AdjustmentItems.Where(x => x.vouchernumber == vouchernumber).Select(y => y).ToList<AdjustmentItem>();
        return list;
    }


    public static void approveAdjVoucher(int vouchernumber)
    {
        AdjustmentVoucher adj = findAdjbyvouchernumber(vouchernumber);

        adj.approvercode = 1029;
        adj.approvaldate = DateTime.Today;
        ds.SaveChanges();

    }
    public static AdjustmentVoucher findAdjbyvouchernumber(int vouchernumber)
    {

        AdjustmentVoucher adj = ds.AdjustmentVouchers.Where(x => x.vouchernumber == vouchernumber).Select(y => y).FirstOrDefault();
        return adj;
    }

    public static void deleteadjustmentByvouchernumber(int vouchernumber)
    {
        AdjustmentVoucher adj = findAdjbyvouchernumber(vouchernumber);

        ds.AdjustmentVouchers.Remove(adj);
        ds.SaveChanges();
    }
}