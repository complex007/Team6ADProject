using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;

public partial class SCretrieveStockCard : System.Web.UI.Page
{
    
    SCserviceManager sc = new SCserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataBind();
            DropDownList1.SelectedIndex = 0;
            Item item = sc.getitemdetails(DropDownList1.SelectedItem.Text);
            Label2.Text = item.itemdescription;
            Label3.Text = item.bin;
            Label4.Text = item.unitofmeasure;
            Label5.Text = item.supplier1;
            Label6.Text = item.supplier2;
            Label7.Text = item.supplier3;

            List<Transaction> trans = sc.gettransactions(DropDownList1.SelectedItem.Text);
            GridView1.DataSource = trans;
            GridView1.DataBind();

        }


    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        Item item= sc.getitemdetails(DropDownList1.SelectedItem.Text);
        Label2.Text = item.itemdescription;
        Label3.Text = item.bin;
        Label4.Text = item.unitofmeasure;
        Label5.Text = item.supplier1;
        Label6.Text = item.supplier2;
        Label7.Text = item.supplier3;
        List<Transaction> trans = sc.gettransactions(DropDownList1.SelectedItem.Text);
        GridView1.DataSource = trans;
        GridView1.DataBind();


    }
}