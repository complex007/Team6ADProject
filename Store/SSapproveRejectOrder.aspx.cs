using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class SSapproveRejectOrder : System.Web.UI.Page
{
    List<SOrder> orders;
    SSserviceManager ssmanager = new SSserviceManager();
    int userNo = 1029;
    protected void Page_Load(object sender, EventArgs e)
    {
        orders = ssmanager.findUnapprovedOrders();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (!IsPostBack)
        {
            if (orders.Count == 0)
            {
                Label1.Text = "No unapproved orders.";
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                TextBox1.Visible = false;
                Label2.Visible = false;
            }
            else
            {
                refreshGV2();
            }
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Details":
                {
                    List<OrderItem> oitems = orders[Convert.ToInt32(e.CommandArgument)].OrderItems.ToList();
                    if (oitems.Count != 0)
                    {
                        GridView1.DataSource = oitems;
                        GridView1.DataBind();
                        Label1.Text = "";
                    }
                    else
                        Label1.Text = "No items found in order";
                    break;
                }
            case "Reject":
                {
                    int poNum = orders[Convert.ToInt32(e.CommandArgument)].purchaseordernumber;

                    try
                    {
                        if (TextBox1.Text.Trim() == "")
                            ssmanager.deleteOrderByPurchaseOrder(poNum, userNo);
                        else
                            ssmanager.deleteOrderByPurchaseOrder(poNum, userNo, TextBox1.Text);
                    }
                    catch (SSexception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                    Label1.Text = String.Format("Order {0} rejected.", poNum);
                    refreshGV2();
                    break;
                }
            case "Approve":
                {
                    int poNum = orders[Convert.ToInt32(e.CommandArgument)].purchaseordernumber;
                    try
                    {
                        ssmanager.approveOrderByPurchaseOrder(poNum, userNo);
                    }
                    catch (SSexception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                    Label1.Text = String.Format("Order number {0} is approved and planned to deliver on {1}.", poNum, DateTime.Parse(SSserviceManager.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy"));
                    refreshGV2();
                    break;
                }
            default:
                {
                    Label1.Text = "Sorry, please try again.";
                    break;
                }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        foreach (SOrder i in orders)
        {
            try
            {
                ssmanager.approveOrderByPurchaseOrder(i.purchaseordernumber, userNo);
            }
            catch (SSexception ex)
            {
                Label1.Text = ex.Message;
            }
        }
        refreshGV2();
        Label1.Text = "All orders approved today and are planned to deliver on " + DateTime.Parse(SSserviceManager.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + ".";
    }
    protected void refreshGV2()
    {
        orders = ssmanager.findUnapprovedOrders();
        GridView2.DataSource = orders;
        GridView2.DataBind();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        foreach (SOrder i in orders)
        {
            int poNum = i.purchaseordernumber;
            string toemail = i.Employee.employeeemail;
            toemail = "hellocomplex007@gmail.com";
            //ClassList.deleteOrderByPurchaseOrder(poNum);
            try
            {
                if (TextBox1.Text.Trim() == "")
                    ssmanager.deleteOrderByPurchaseOrder(poNum, userNo);
                else
                    ssmanager.deleteOrderByPurchaseOrder(poNum, userNo, TextBox1.Text);
            }
            catch (SSexception ex)
            {
                Label1.Text = ex.Message;
            }
            refreshGV2();
        }
        TextBox1.Text = "";
        refreshGV2();
        Label1.Text = "All orders have been rejected.";
    }
}