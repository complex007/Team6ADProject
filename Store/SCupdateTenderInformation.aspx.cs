using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCupdateTenderInformation : System.Web.UI.Page
{
    //Service
    SCserviceManager scService = new SCserviceManager();
 
    //Populate data into dropdownlist
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindGridView();        
        }
    }
    private void bindGridView()
    {
        List<string> slist = scService.getSuppliername();
        DropDownList1.DataSource = slist;
        DropDownList1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;
        //bindGridView();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string suppliername = DropDownList1.SelectedValue;
      
        Supplier s = scService.getSupplierByName(suppliername);
        Label.Text = s.address;
        string suppliercode= s.suppliercode;

        //List<string> itemcode = scService.getItemCodeBySupplierCode(suppliercode);
        //List<Item> list = scService.getItemByListcode(itemcode);
        //List<double> plist = scService.getPriceByListcode(itemcode);

        List<dynamic> list = scService.getTenderQuotation(suppliercode).ToList();

        GridView1.DataSource = list;
        GridView1.DataBind();

    }

    //Select row in GridView
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1,
                "Select$" + e.Row.RowIndex);

            e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        //bindGridView();
        GridView1.Rows[index].Attributes.Add("style", "background-color:#FDCB0A");
        // GridView1.Rows[index].Attributes.Add("class", "mycustomclass");
    }

    //protected void Modify_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = GridView1.SelectedRow;
    //    TextBox1.Text = row.Cells[0].Text;
    //    TextBox2.Text = row.Cells[1].Text;

    //}

    //protected void Create_Click(object sender, EventArgs e)
    //{
    //    TextBox1.Text = " ";
    //    TextBox2.Text = " ";
    //}

    //protected void Delete_Click(object sender, EventArgs e)
    //{
    //    GridViewRow row = GridView1.SelectedRow;
    //    string itemdescription = row.Cells[0].Text;

    //    //TextBox1.Text = itemdescription;

    //    Item i = scService.getItemByItemdescription(itemdescription);

    //    TenderQuotation t = new TenderQuotation();
    //    t.suppliercode = scService.getSupplierByName(DropDownList1.SelectedValue).suppliercode;
    //    t.itemcode = i.itemcode;
    //    t.price = Convert.ToDouble(row.Cells[1].Text);

    //    scService.deleteTenderQuotation(t);
    //}

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Item i = scService.getItemByItemdescription(GridView1.SelectedRow.Cells[0].Text);
        TextBox1.Text = GridView1.SelectedRow.Cells[0].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox3.Text = i.itemcode;
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        string itemdescription = row.Cells[0].Text;
        Item i = scService.getItemByItemdescription(itemdescription);
        //i.itemdescription = TextBox1.Text;
        

        string suppliername = DropDownList1.SelectedValue;
        Supplier s = scService.getSupplierByName(suppliername);

        TenderQuotation tq = new TenderQuotation();
        tq.suppliercode = s.suppliercode;
        tq.itemcode = i.itemcode;
        tq.price = Convert.ToDouble(TextBox2.Text);
        //scService.updateTenderQuotation(i, tq);


        scService.updateTenderQuotation(tq);
        Response.Redirect("SCupdateTenderInformation.aspx");
    }
  
}