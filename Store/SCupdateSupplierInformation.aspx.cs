using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCupdateSupplierInformation : System.Web.UI.Page
{
    //Service
    SCserviceManager scService = new SCserviceManager();

    //Populate data into GridView
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGridView();
        }
        //List<Item> catalogue = scService.getCatalogue();
        //GridView1.DataSource = catalogue;
        //GridView1.DataBind();
    }
    private void bindGridView()
    {
        List<Supplier> slist = scService.getSupplier();
        GridView1.DataSource = slist;
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
        bindGridView();
        GridView1.Rows[index].Attributes.Add("style", "background-color:#FDCB0A");
        // GridView1.Rows[index].Attributes.Add("class", "mycustomclass");
    }

    //button 
    protected void Delete_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        string suppliercode = row.Cells[0].Text;
        Supplier s = scService.getSupplier(suppliercode);
        scService.deleteSupplier(s);

        Response.Redirect("SCupdateSupplierInformation.aspx");
    }

    protected void Modify_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        TextBox1.Text = row.Cells[0].Text;
        TextBox2.Text = row.Cells[1].Text;
        TextBox3.Text = row.Cells[2].Text;
        TextBox4.Text = row.Cells[3].Text;
        TextBox5.Text = row.Cells[4].Text;
        TextBox6.Text = row.Cells[5].Text;
        TextBox7.Text = row.Cells[6].Text;

    }

    protected void Create_Click(object sender, EventArgs e)
    {
        Response.Redirect("SCupdateSupplierInformation.aspx");
        //TextBox1.Text = " ";
        //TextBox2.Text = " ";
        //TextBox3.Text = " ";
        //TextBox4.Text = " ";
        //TextBox5.Text = " ";
        //TextBox6.Text = " ";
        //TextBox7.Text = " ";
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SCupdateSupplierInformation.aspx");
        //TextBox1.Text = " ";
        //TextBox2.Text = " ";
        //TextBox3.Text = " ";
        //TextBox4.Text = " ";
        //TextBox5.Text = " ";
        //TextBox6.Text = " ";
        //TextBox7.Text = " ";

    }

    protected void Save_Click(object sender, EventArgs e)
    {
        Supplier s = new Supplier();
        s.suppliercode = TextBox1.Text;
        s.suppliername = TextBox2.Text;
        s.contactname = TextBox3.Text;
        s.phonenumber = TextBox4.Text;
        s.faxnumber = TextBox5.Text;
        s.address = TextBox6.Text;
        s.gstregistrationno = TextBox7.Text;

        List<string> list = scService.getSuppliercode();
        bool exits = false;

        for (int x = 0; x < list.Count; x++)
        {
            if (s.suppliercode == list[x])
            {
                exits = true;
                break;
            }
            else
            {
                exits = false;            
            }
        }

        if (exits == true)
        {
            scService.updateSupplier(s);
        }
        else if(exits == false)
        {
            scService.saveSupplier(s);
        }
        Response.Redirect("SCupdateSupplierInformation.aspx");
    }
}