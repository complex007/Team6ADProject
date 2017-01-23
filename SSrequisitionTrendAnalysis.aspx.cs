using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SS
{
    public partial class SSrequisitionTrendAnalysis : System.Web.UI.Page
    {
        string cate;
        string time1;
        string time2;
        string time3;
        string cateselect;
        List<ListItem> selecteditem;
        DateTime selecttime;
        SSserviceManager ssmanager = new SSserviceManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            cate = ListBox5.SelectedValue.ToString();
            time1 = Lbmonth1.Text;
            time2 = Lbmonth2.Text;
            time3 = Lbmonth3.Text;
            cateselect = Label1.Text;
            selecttime = Calendar1.SelectedDate;
            selecteditem = new List<ListItem>();
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected) selecteditem.Add(item);

            if (cate == null)
            {
                Button1.Enabled = false;
            }
            if (selecttime == null)
            {
                Btnmonth1.Enabled = false;
                Btnmonth2.Enabled = false;
                Btnmonth3.Enabled = false;
            }
            if (cateselect == null || selecteditem == null || time1 == null)
            {
                Btngenerate.Enabled = false;
            }
            string que = "select c.category,d.deptcode,Year(d.collectiondate) as requistionyear ,Month(d.collectiondate) as requsitionmonth, sum(b.actualquantity) as requisitionquantity from DisbursementItem b,Item c, Disbursement d where  b.itemcode = c.itemcode and d.disbursementid = b.disbursementid group by  c.category,d.deptcode,Month(d.collectiondate),YEAR(d.collectiondate)";
            CryDataSet ds = ssmanager.setRequisitionDataSet(que);
           SSrequisitionTrend cryview2 = new SSrequisitionTrend();
            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = cate;          
        }

        protected void Btngenerate_Click(object sender, EventArgs e)
        {
            cateselect = Label1.Text;
            string depcode = "";
            foreach (ListItem i in selecteditem)
            {
                depcode += "'" + i.Text + "',";
            }
            string resultdep = depcode.Substring(0, depcode.Length - 1);

            string que = "select c.category,d.deptcode,Year(d.collectiondate) as requistionyear ,Month(d.collectiondate) as requsitionmonth, sum(b.actualquantity) as requisitionquantity from DisbursementItem b,Item c, Disbursement d "
                +
                "where  b.itemcode=c.itemcode and d.disbursementid=b.disbursementid and c.category='"
                + cateselect +
                "' and d.deptcode in ("
                + resultdep
                + ") and  d.collectiondate like  ('"
                + time1
                + "-%' )"
                +
                " group by  c.category,d.deptcode,Month(d.collectiondate),YEAR(d.collectiondate)"
                + " union "
                + " select c.category,d.deptcode,Year(d.collectiondate) as requistionyear ,Month(d.collectiondate) as requsitionmonth, sum(b.actualquantity) as requisitionquantity from DisbursementItem b,Item c, Disbursement d "
                +
               "where  b.itemcode=c.itemcode and d.disbursementid=b.disbursementid and c.category='"
                + cateselect +
                 "' and d.deptcode in ("
                + resultdep
                + ") and  d.collectiondate like  ('"
                + time2
                + "-%' )"
                +
                     " group by  c.category,d.deptcode,Month(d.collectiondate),YEAR(d.collectiondate)"
                + " union "
                + " select c.category,d.deptcode,Year(d.collectiondate) as requistionyear ,Month(d.collectiondate) as requsitionmonth, sum(b.actualquantity) as requisitionquantity from DisbursementItem b,Item c, Disbursement d "
                +
                 "where  b.itemcode=c.itemcode and d.disbursementid=b.disbursementid and c.category='"
                + cateselect +
                 "' and d.deptcode in ("
                + resultdep
                + ") and  d.collectiondate like  ('"
                + time3
                + "-%' )"
                +
                    " group by  c.category,d.deptcode,Month(d.collectiondate),YEAR(d.collectiondate)"
                ;
            CryDataSet ds = ssmanager.setRequisitionDataSet(que);
            SSrequisitionTrend cryview2 = new SSrequisitionTrend();
            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;

            //List<Supplier> selectedsupplier = new List<Supplier>();
            //DateTime date1 = DateTime.Parse(time1);
            //DateTime date2 = DateTime.Parse(time2);
            //DateTime date3 = DateTime.Parse(time3);
            //suppliers = ClassList.findSupplierByCategory(cate);
            //for (int i = 0; i < selecteditem.Count; i++)
            //{
            //    if (CheckBoxList1.Items[i].Selected)
            //    {
            //        selectedsupplier.Add(suppliers[i]);                  
            //    }
            //}

            //CryDataSet dset = new CryDataSet();
            //CryDataSetTableAdapters.reordertrend21TableAdapter reordertrend = new CryDataSetTableAdapters.reordertrend21TableAdapter();

            //reordertrend.Fill(dset.reordertrend21);
            //var total = dset.reordertrend21.Select(y => y).ToList();
            //reordertrend.FillBy(dset.reordertrend2,cate,time1,time2,time3);
            //for ( int j=0; j<selectedsupplier.Count;j++)
            //{                
            //    var com = dset.reordertrend2.
            //        Where(x =>x.suppliercode == selectedsupplier[j].suppliercode).
            //        Select(y=> new {y.category,y.amount }).ToList();
            //    total.Add(com);               
            //}

            //SSreorderTrend cryview = new SSreorderTrend();
            //cryview.SetDataSource(total);
            //CrystalReportViewer1.ReportSource = cryview;

        }


        protected void Btnmonth2_Click(object sender, EventArgs e)
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
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