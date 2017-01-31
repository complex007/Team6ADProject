using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCupdateCatalog : System.Web.UI.Page
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
        List<Item> catalogue = scService.getCatalogue();
        GridView1.DataSource = catalogue;
        GridView1.DataBind();
    }
    /// <summary>
    /// pagination
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindGridView();
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



    protected void Delete_Click(object sender, EventArgs e)
    {

        GridViewRow row = GridView1.SelectedRow;
        string itemcode = row.Cells[0].Text;
        scService.deleteItem(itemcode);

        Response.Redirect("SCupdateCatalog.aspx");
    }

    protected void Modify_Click(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        TextBox1.Text = row.Cells[0].Text;
        TextBox6.Text = row.Cells[1].Text;
        TextBox2.Text = row.Cells[2].Text;
        TextBox3.Text = row.Cells[3].Text;
        TextBox4.Text = row.Cells[4].Text;
        TextBox7.Text = row.Cells[5].Text;
        
        Item i= scService.getItem(row.Cells[0].Text);
        TextBox5.Text = i.bin.ToString();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Item i = new Item();
        i.itemcode = TextBox1.Text;
        i.category = TextBox6.Text;
        i.itemdescription= TextBox2.Text;
        i.reorderlevel= Convert.ToInt32(TextBox3.Text);
        i.reorderquantity= Convert.ToInt32(TextBox4.Text);
        i.unitofmeasure = TextBox7.Text;

        List<string> list = scService.getItemcode();
        bool exits = false;

        for (int x = 0; x < list.Count; x++)
        {
            if (i.itemcode == list[x])
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
            scService.updateCatalogue(i);
        }
        else if (exits == false)
        {
            scService.saveCatalogue(i);
        }

        Response.Redirect("SCupdateCatalog.aspx");

    }
    
    protected void Create_Click(object sender, EventArgs e)
    {
        Response.Redirect("SCupdateCatalog.aspx");
        //TextBox1.Text = " ";
        //TextBox2.Text = " ";
        //TextBox3.Text = " ";
        //TextBox4.Text = " ";
        //TextBox5.Text = " ";
        //TextBox6.Text = " ";
        //TextBox7.Text = " ";

    }
}