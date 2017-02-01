using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using System.Security.Principal;

public partial class SCDeliverOrders : System.Web.UI.Page
{

    SCserviceManager sc = new SCserviceManager();
    int role;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        role = Convert.ToInt32(User.Identity.Name);
        if (!IsPostBack)
        {
            DropDownList3.DataBind();
            DropDownList3.SelectedIndex = 0;


            List<dynamic> dept = sc.getdept(DropDownList3.SelectedItem.Text).ToList();

            RadioButtonList1.DataSource = dept;
            RadioButtonList1.DataTextField = "deptname";
            RadioButtonList1.DataValueField = "deptcode";
            RadioButtonList1.DataBind();
            RadioButtonList1.SelectedIndex = 0;

            List<int> dis = sc.getdis(RadioButtonList1.SelectedValue);
            List<dynamic> disbursementitems = new List<dynamic>();

            foreach (int i in dis)
            {
                List<dynamic> disitem = sc.getdisbursementitems(i).ToList();
                disbursementitems.AddRange(disitem);
            }

            if (disbursementitems.Count != 0)
            {
                GridView1.DataSource = disbursementitems;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                //for (int i = 0; i < GridView1.Rows.Count; i++)
                //{
                //    String itemcode = GridView1.Rows[i].Cells[0].Text;
                //    List<TenderQuotation> supplier = new List<TenderQuotation>();
                //    //supplier.Add("Select");
                //    supplier = sc.getsuppliercodes(itemcode);
                //    GridViewRow row = GridView1.Rows[i];
                //    DropDownList tx = (DropDownList)row.FindControl("MyDD");
                //    foreach (TenderQuotation name in supplier)
                //    {
                //        tx.Items.Add(name.suppliercode);
                //        tx.DataBind();
                //    }


                //}
            }
        }
        if (GridView1.Rows.Count != 0)
        {



            //getallocations();

            GridView1.HeaderRow.Cells[4].Visible = false;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                GridView1.Rows[i].Cells[4].Visible = false;
            }

        }







        if (GridView1.Rows.Count == 0)
        {
            Label3.Text = "No items to deliver";
        }
        else
        {
            Label3.Text = "Order Items";
        }

    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String itemcode = e.Row.Cells[0].Text;
            List<TenderQuotation> supplier = new List<TenderQuotation>();
            //supplier.Add("Select");
            supplier = sc.getsuppliercodes(itemcode);
            //Find the DropDownList in the Row
            DropDownList ddlCountries = (e.Row.FindControl("MyDD") as DropDownList);
            foreach (TenderQuotation name in supplier)
            {
                ddlCountries.Items.Add(name.suppliercode);

                ddlCountries.DataBind();
            }


            //Add Default Item in the DropDownList
            ddlCountries.Items.Insert(0, new ListItem("select"));

            // Select the Country of Customer in DropDownList

        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        List<dynamic> dept = sc.getdept(DropDownList3.SelectedItem.Text).ToList();

        RadioButtonList1.DataSource = dept;
        RadioButtonList1.DataTextField = "deptname";
        RadioButtonList1.DataValueField = "deptcode";
        RadioButtonList1.DataBind();
        RadioButtonList1.SelectedIndex = 0;
        List<int> dis = sc.getdis(RadioButtonList1.SelectedValue);
        List<dynamic> disbursementitems = new List<dynamic>();

        foreach (int i in dis)
        {
            List<dynamic> disitem = sc.getdisbursementitems(i).ToList();
            disbursementitems.AddRange(disitem);
        }

        GridView1.DataSource = disbursementitems;
        GridView1.DataBind();

        if (GridView1.Rows.Count != 0)
        {



            //getallocations();

            GridView1.HeaderRow.Cells[4].Visible = false;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                GridView1.Rows[i].Cells[4].Visible = false;
            }

        }


    }




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {




    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<int> dis = sc.getdis(RadioButtonList1.SelectedValue);
        List<dynamic> disitems = new List<dynamic>();

        foreach (int i in dis)
        {
            List<dynamic> disitem = sc.getdisbursementitems(i).ToList();
            disitems.AddRange(disitem);
        }
        GridView1.DataSource = disitems;
        GridView1.DataBind();




    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        String actualqty;
        List<RequisitionItem> rlist = new List<RequisitionItem>();
        List<Requisition> reqlist = new List<Requisition>();
        string deptcode;
        deptcode = RadioButtonList1.SelectedValue;
        int approvercode = sc.getrepresentativecode(deptcode);
        // deptcode=sc.getdepartmentcode(deptname);
        rlist = sc.getrequisitions(deptcode);
        reqlist = sc.getreq(deptcode);

        int allocated;



        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            String suppliercode = "";
            TenderQuotation price = new TenderQuotation();
            GridViewRow row = GridView1.Rows[i];
            String itemcode = GridView1.Rows[i].Cells[0].Text;
            TextBox tx = (TextBox)row.FindControl("Textfrom");
            allocated = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
            actualqty = tx.Text;
            DropDownList supplier = (row.FindControl("MyDD") as DropDownList);
            if (!supplier.SelectedItem.Text.Equals("select"))
            {
                suppliercode = supplier.SelectedItem.Text;
                price = sc.getprice(suppliercode, itemcode);
            }
            int actualquantity = Convert.ToInt32(actualqty);

            int disbursementid = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
            if (allocated == actualquantity)
            {

                for (int j = 0; j < rlist.Count; j++)
                {
                    if (rlist[j].itemcode == itemcode)
                    {
                        sc.updatestatusto3(rlist[j].requisitionid, itemcode);
                        sc.updatedisbursement(disbursementid, itemcode, actualquantity);
                    }
                }

            }
            else if (allocated != actualquantity)
            {
                sc.addadjustmentvoucher(price.price, role, itemcode, allocated - actualquantity);
                for (int j = 0; j < rlist.Count; j++)
                {
                    if (rlist[j].itemcode == itemcode)
                    {
                        sc.deliverstatus(rlist[j].requisitionid, itemcode, allocated - actualquantity, actualquantity, deptcode, rlist[j].Requisition.employeecode);
                        sc.updatedisbursement(disbursementid, itemcode, actualquantity);
                    }
                }
            }
        }
        for (int z = 0; z < reqlist.Count; z++)
        {
            int reqcount = sc.getreqcount(reqlist[z].requisitionid);
            int statuscount = sc.getstatuscount(reqlist[z].requisitionid);
            if (reqcount == statuscount)
            {
                sc.updaterequisition(reqlist[z].requisitionid, approvercode);
            }

        }
        sc.updatedisb(deptcode);

        List<int> dis = sc.getdis(RadioButtonList1.SelectedValue);
        List<dynamic> disitems = new List<dynamic>();

        foreach (int i in dis)
        {
            List<dynamic> disitem = sc.getdisbursementitems(i).ToList();
            disitems.AddRange(disitem);
        }
        GridView1.DataSource = disitems;
        GridView1.DataBind();

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}