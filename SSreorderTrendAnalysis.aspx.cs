using CrystalDecisions.Web;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SS
{
    public partial class SSreorderTrendAnalysis : System.Web.UI.Page
    {
        string cate;
        string time1;
        string time2;
        string time3;
        string cateselect;
        List<ListItem> selecteditem;
        List<Supplier> suppliers ;
        DateTime selecttime;
        SSserviceManager ssmanager = new SSserviceManager();
        protected void Page_Load(object sender, EventArgs e)
        {
             cate = ListBox5.SelectedValue.ToString();
             time1 =Lbmonth1.Text;
             time2 =Lbmonth2.Text;
             time3 =Lbmonth3.Text;
             cateselect = Label1.Text;
            selecttime = Calendar1.SelectedDate;
            selecteditem = new List<ListItem>();            
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected) selecteditem.Add(item);

            if (cate==null)
            {
                Button1.Enabled = false;             
            }
            if(selecttime==null)
            {
                Btnmonth1.Enabled = false;
                Btnmonth2.Enabled = false;
                Btnmonth3.Enabled = false;
            }
            if (cateselect == null || selecteditem == null || time1== null )
            {
                Btngenerate.Enabled = false;
            }

            
            
            string que = " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber  group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)";
            CryDataSet ds = ssmanager.setReorderDataSet(que);
            SSreorderTrend cryview2 = new SSreorderTrend();

            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // string cate = ListBox5.SelectedValue.ToString();
             Label1.Text=cate;
            suppliers = ssmanager.findSupplierByCategory(cate);
            CheckBoxList1.DataSource = suppliers;
            CheckBoxList1.DataBind();
        }

        protected void Btngenerate_Click(object sender, EventArgs e)
        {
            cateselect = Label1.Text;
            string supcode = "";
             foreach(ListItem i in selecteditem)
            {
                supcode += "'" + i.Text + "',";
            }
            string resultsupplier = supcode.Substring(0, supcode.Length - 1);

            string que = " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect+
                "' and d.suppliercode in ("
                +resultsupplier
                + ") and  d.deliverydate like  ('"
                +time1
                +"-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                +"union"
                + " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect +
                "' and d.suppliercode in ("
                + resultsupplier
                + ") and  d.deliverydate like  ('"
                + time2
                + "-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                +"union"
                + " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect +
                "' and d.suppliercode in ("
                + resultsupplier
                + ") and  d.deliverydate like  ('"
                + time3
                + "-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                ;
            CryDataSet ds = ssmanager.setReorderDataSet(que);
            SSreorderTrend cryview2 = new SSreorderTrend();

            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;

        }

       
        protected void Btnmonth2_Click(object sender, EventArgs e)
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if(month.Length==1)
            {
                Lbmonth2.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth2.Text = year + "-" + month;
            }
            
        }

        protected void Btnmonth1_Click(object sender, EventArgs e)
        {
            
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
            {
                Lbmonth1.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth1.Text = year + "-" + month;
            }
        }

        protected void Btnmonth3_Click(object sender, EventArgs e)
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
            {
                Lbmonth3.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth3.Text = year + "-" + month;
            }
        }
    }

}