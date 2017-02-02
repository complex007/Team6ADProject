using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using System.Security.Principal;

public partial class SCsendOrdertoSupplier : System.Web.UI.Page
{
    SCserviceManager sc = new SCserviceManager();
    int role;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        role = Convert.ToInt32(User.Identity.Name);
        if (GridView1.Rows.Count==0)
        {
            //Button1.Visible = false;
            Button2.Visible = false;
        }
        if (!IsPostBack)
        {
            int sno = 1;
            ViewState["sno"] = sno;
            DataTable dt = new DataTable();
            ViewState["list"] = dt;
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;
            Item item = sc.getsuppliercode(DropDownList2.SelectedValue);

            TenderQuotation price1 = sc.getprice(item.supplier1, DropDownList2.SelectedValue);
            Label4.Text = price1.price.ToString()+"(Unit Price)";
            TenderQuotation price2 = sc.getprice(item.supplier2, DropDownList2.SelectedValue);
            Label1.Text = price2.price.ToString()+"(Unit Price)";
            TenderQuotation price3 = sc.getprice(item.supplier3, DropDownList2.SelectedValue);
            Label5.Text = price3.price.ToString()+"(Unit price)";



            RadioButton1.Text = item.supplier1;
            RadioButton2.Text = item.supplier2;
            RadioButton3.Text = item.supplier3;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton1.Checked = true;

            


        }


    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       Item item= sc.getsuppliercode(DropDownList2.SelectedValue);


        TenderQuotation price1 = sc.getprice(item.supplier1, DropDownList2.SelectedValue);
        Label4.Text = price1.price.ToString() + "(Unit Price)";
        TenderQuotation price2 = sc.getprice(item.supplier2, DropDownList2.SelectedValue);
        Label1.Text = price2.price.ToString() + "(Unit Price)";
        TenderQuotation price3 = sc.getprice(item.supplier3, DropDownList2.SelectedValue);
        Label5.Text = price3.price.ToString() + "(Unit price)";



        RadioButton1.Text = item.supplier1;
        RadioButton2.Text = item.supplier2;
        RadioButton3.Text = item.supplier3;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton1.Checked = true;
      

       


    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
 
        //Button1.Visible = true;
        Button2.Visible = true;
        Item item = sc.getsuppliercode(DropDownList2.SelectedValue);

        TenderQuotation price1 = sc.getprice(item.supplier1, DropDownList2.SelectedValue);
    
        TenderQuotation price2 = sc.getprice(item.supplier2, DropDownList2.SelectedValue);
       
        TenderQuotation price3 = sc.getprice(item.supplier3, DropDownList2.SelectedValue);
      
      // OrderItem order = sc.getorderquantity(DropDownList2.SelectedValue);
        int quantity =Convert.ToInt32(TextBox1.Text);
        //double qty = order.orderquantity;
        double cost;
        if (RadioButton1.Checked)
        {
            if (GridView1.Rows.Count == 0)
            {
                ViewState["sno"] = 1;

            }
            int sno = (int)ViewState["sno"];
          
            cost = price1.price;
            double amount = quantity * cost;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["list"];
            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("S.no");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Description");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Supplier");
               // dt.Columns.Add("Special Request");
            }
            dt.Rows.Add(sno,item.itemcode, item.itemdescription,quantity, price1.price, amount, item.supplier1);








            GridView1.DataSource = dt;
            GridView1.DataBind();

            ViewState["list"] = dt;
           
            sno++;
            ViewState["sno"] = sno;

        }
        else if(RadioButton2.Checked)
        {
            if (GridView1.Rows.Count == 0)
            {
                ViewState["sno"] = 1;

            }
            int sno = (int)ViewState["sno"];
            cost = price2.price;
            double amount = quantity * cost;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["list"];
           
            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("S.no");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Description");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Supplier");
              //  dt.Columns.Add("Special Request");
            }
            dt.Rows.Add(sno,item.itemcode, item.itemdescription, quantity, price2.price, amount, item.supplier2);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState["list"] = dt;
       
            sno++;
            ViewState["sno"] = sno;
        }
        else if(RadioButton3.Checked)
        {
            if (GridView1.Rows.Count == 0)
            {
                ViewState["sno"] = 1;

            }
            int sno = (int)ViewState["sno"];
            cost = price3.price;
            double amount = quantity * cost;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["list"];
            //int quant = Convert.ToInt32(TextBox1.Text);
            if (dt.Rows.Count == 0)
            {
           
                dt.Columns.Add("S.no");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Description");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Supplier");
              //  dt.Columns.Add("Special Request");
            }
            dt.Rows.Add(sno,item.itemcode, item.itemdescription, quantity, price3.price, amount, item.supplier3);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState["list"] = dt;
           
            sno++;
            ViewState["sno"] = sno;
        }
      


       
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void MyButtonClick(object sender, System.EventArgs e)
    {
        //Get the button that raised the event
        Button btn = (Button)sender;

        //Get the row that contains this button
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
       
        
        
        
    }
    
    public virtual void DeleteRow(int rowIndex)
    {

    }
    protected virtual void OnRowDeleted(GridViewDeletedEventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
      
        for (int i=0;i<GridView1.Rows.Count;i++)
        {
            Item item = new Item();
            
            item.itemcode = GridView1.Rows[i].Cells[1].Text;
            if(RadioButton1.Checked)
            {
                item.supplier1 =GridView1.Rows[i].Cells[6].Text;
            }
            else if(RadioButton2.Checked)
            {
                item.supplier1 = GridView1.Rows[i].Cells[6].Text;
            }
            else if(RadioButton3.Checked)
            {
                item.supplier1 = GridView1.Rows[i].Cells[6].Text;
            }
            item.reorderquantity = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
            sc.raiseReorder(item, role);

        }
        ViewState.Remove("list");
        DataTable dt = new DataTable();
        ViewState["list"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        this.Page_Load(null, null);
      
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int flag = 0;
        DataTable dt = new DataTable();
       // dt = (DataTable)ViewState["list"];
        foreach (GridViewRow row in GridView1.Rows)

        {

            CheckBox chk = (CheckBox)row.FindControl("chkSelect");

            if (chk!=null&&chk.Checked)

            {
                flag++;
                int RecordID = Convert.ToInt32(row.RowIndex);


                // delete the row
                for(int i=0;i<7;i++)
                {
                    GridView1.Rows[RecordID].Cells[i].Text = string.Empty;
                }

               
          


            }
        }
        if (flag > 0)
        {
            dt.Columns.Add("S.no");
            dt.Columns.Add("Item Number");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Supplier");
            //dt = (DataTable)ViewState["list"];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[2].Text != "")
                {
                    dt.Rows.Add(new object[] { GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, GridView1.Rows[i].Cells[2].Text, GridView1.Rows[i].Cells[3].Text, GridView1.Rows[i].Cells[4].Text, GridView1.Rows[i].Cells[5].Text, GridView1.Rows[i].Cells[6].Text });
                }
            }

            // rebind to reflect changes

            dt.AcceptChanges();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState["list"] = dt;
            int sno = (int)ViewState["sno"];

            ViewState["sno"] = sno;
            if (GridView1.Rows.Count == 0)
            {
                int desiredSize = 0;

                while (dt.Columns.Count > desiredSize)
                {
                    dt.Columns.RemoveAt(desiredSize);
                }
                //dt.Rows.Clear();
                ViewState["list"] = dt;
            }
        }

    }

 
}