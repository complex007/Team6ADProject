using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SSApproveRejectOrder : System.Web.UI.Page
{
    List<SOrder> orders;
    protected void Page_Load(object sender, EventArgs e)
    {
        orders = ClassList.findUnapprovedOrders();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (!IsPostBack)
        {

            if (orders.Count == 0)
            {
                Label1.Text = "No unapproved orders.";
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
                    ClassList.deleteOrderByPurchaseOrder(poNum);
                    Label1.Text = String.Format("Order {0} rejected.", poNum);
                    if (TextBox1.Text.Trim() == "")
                        ClassList.sendEmail(String.Format("Order no. {0} has been rejected.", poNum));
                    else
                        ClassList.sendEmail(String.Format("Order no. {0} has been rejected. Reason given: {1}", poNum, TextBox1.Text));
                    refreshGV2();
                    break;
                }
            case "Approve":
                {
                    int poNum = orders[Convert.ToInt32(e.CommandArgument)].purchaseordernumber;
                    ClassList.approveOrderByPurchaseOrder(poNum);
                    Label1.Text = String.Format("Order number {0} is approved and planned to deliver on {1}.", poNum, DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy"));
                    refreshGV2();
                    break;
                }
            default:
                {
                    Label1.Text = "Toto, I've a feeling we're not in Kansas anymore.";
                    break;
                }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        foreach (SOrder i in orders)
        {
            ClassList.approveOrderByPurchaseOrder(i.purchaseordernumber);
        }
        refreshGV2();
        Label1.Text = "All orders approved today and are planned to deliver on " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + ".";
    }
    protected void refreshGV2()
    {
        orders = ClassList.findUnapprovedOrders();
        GridView2.DataSource = orders;
        GridView2.DataBind();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        foreach (SOrder i in orders)
        {
            int poNum = i.purchaseordernumber;
            ClassList.deleteOrderByPurchaseOrder(poNum);
            if (TextBox1.Text.Trim() == "")
                ClassList.sendEmail(String.Format("Order no. {0} has been rejected.", poNum));
            else
                ClassList.sendEmail(String.Format("Order no. {0} has been rejected. Reason given: {1}", poNum, TextBox1.Text));
            refreshGV2();

        }
        TextBox1.Text = "";
        refreshGV2();
        Label1.Text = "All orders have been rejected.";
    }
}