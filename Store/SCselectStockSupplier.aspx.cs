using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCselectStockSupplier : System.Web.UI.Page
{
    //Service
    SCserviceManager scService = new SCserviceManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        List<string> itemcode = scService.getItemcode();
        DropDownList1.DataSource = itemcode;
        DropDownList1.DataBind();

        List<string> suppliercode = scService.getSuppliercode();
        DropDownList2.DataSource = suppliercode;
        DropDownList2.DataBind();

        //suppliercode.Remove(DropDownList2.SelectedValue);
        DropDownList3.DataSource = suppliercode;
        DropDownList3.DataBind();

        //suppliercode.Remove(DropDownList3.SelectedValue);
        DropDownList4.DataSource = suppliercode;
        DropDownList4.DataBind();
        }
    }
    
    protected void Update_Click(object sender, EventArgs e)
    {
        string itemcode = DropDownList1.SelectedValue;
        Item i = scService.getItem(itemcode);
        i.supplier1 = DropDownList2.SelectedValue;
        i.supplier2 = DropDownList3.SelectedValue;
        i.supplier3 = DropDownList4.SelectedValue;

        scService.updateItem(i);
        Response.Write("<script>alert('Item suppliers have been updated.');</script>");

        Label1.Text = i.supplier1;
        Label2.Text = i.supplier2;
        Label3.Text = i.supplier3;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string itemcode = DropDownList1.SelectedValue;
        Item i = scService.getItem(itemcode);
        Label1.Text = i.supplier1;
        Label2.Text = i.supplier2;
        Label3.Text = i.supplier3;
    }
}