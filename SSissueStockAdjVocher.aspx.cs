using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SSissueStockAdjVocher : System.Web.UI.Page
{
    string id = "";
    string action = "";
    string reason = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            id = Request.QueryString["id"];
        }
        if (Request.QueryString["action"] != null)
        {
            action = Request.QueryString["action"];
            reason = TextBox2.Text;
        }
        Session["reason"] = TextBox2.Text;
        reason = Session["reason"].ToString();
        if (!IsPostBack)
        {
            List<AdjustmentVoucher> adjs = ClassList.findUnapprovedvoucher();
            if (adjs.Count == 0)
            {
                Label1.Text = "No approved adjustment";
            }
            else
            {
                GridView1.DataSource = adjs;
                GridView1.DataBind();
            }

            if (id != null && action != null)
            {
                if (action.Equals("Details"))
                {
                    List<AdjustmentItem> list = ClassList.findAdjitembyvouchernumber(Convert.ToInt32(id));
                    GridView2.DataSource = list;
                    GridView2.DataBind();
                }
                if (action.Equals("Reject"))
                {
                    if (TextBox2.Text.Trim() != "")
                    {
                        AdjustmentVoucher adj = ClassList.findAdjbyvouchernumber(Convert.ToInt32(id));
                        ClassList.deleteadjustmentByvouchernumber(Convert.ToInt32(id));
                        adjs.Remove(adj);
                        string message = "Your order: " + adj.vouchernumber + " is rejected. Reason: " + reason;
                        ClassList.sendEmail(message);
                        TextBox2.Text = "";
                        Response.Redirect("~/SSissueStockAdjVocher.aspx");
                    }
                    else
                    {
                        Label1.Text = "Please write in reject reason!";
                    }
                }
                if (action.Equals("Approve"))
                {
                    AdjustmentVoucher adj = ClassList.findAdjbyvouchernumber(Convert.ToInt32(id));
                    ClassList.approveAdjVoucher(Convert.ToInt32(id));
                    adjs.Remove(adj);
                    GridView1.DataBind();
                    Label1.Text = "The order is approved today and planed to deliver at " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + " .";
                }

                if (action.Equals("ApproveAll"))
                {
                    foreach (AdjustmentVoucher i in adjs)
                    {
                        ClassList.approveAdjVoucher(i.vouchernumber);
                    }

                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    Label1.Text = "The adjustments approved today are planed to deliver at " + DateTime.Parse(ClassList.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + " .";
                }
                if (action.Equals("RejectAll"))
                {
                    if (TextBox2.Text.Trim() != "")
                    {
                        foreach (AdjustmentVoucher i in adjs)
                        {
                            ClassList.deleteadjustmentByvouchernumber(i.vouchernumber);
                            string message = "Your adjustments: " + i.vouchernumber + " is rejected. Reason: " + reason;
                            ClassList.sendEmail(message);
                        }
                        TextBox2.Text = "";
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        Label1.Text = "All orders are rejected .";

                    }
                    else
                    {
                        Label1.Text = "Please write in reject reason!";
                    }
                }
            }
        }
        else
        {
            if (action.Equals("Reject"))
            {

                if (TextBox2.Text.Trim() != "")
                {
                    AdjustmentVoucher adj = ClassList.findAdjbyvouchernumber(Convert.ToInt32(id));
                    ClassList.deleteadjustmentByvouchernumber(Convert.ToInt32(id));
                    string message = "Your order: " + adj.vouchernumber + " is rejected. Reason: " + reason;
                    ClassList.sendEmail(message);
                    TextBox2.Text = "";
                    Response.Redirect("~/SSissueStockAdjVocher.aspx");
                }
                else
                {
                    Label1.Text = "Please write in reject reason!";
                }
            }
            if (action.Equals("RejectAll"))
            {
                List<AdjustmentVoucher> orders = ClassList.findUnapprovedvoucher();
                if (TextBox2.Text.Trim() != "")
                {
                    foreach (AdjustmentVoucher i in orders)
                    {
                        ClassList.deleteadjustmentByvouchernumber(i.vouchernumber);
                        string message = "Your order: " + i.vouchernumber + " is rejected. Reason: " + reason;
                        ClassList.sendEmail(message);
                    }
                    TextBox2.Text = "";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    Label1.Text = "All orders are rejected .";
                }
                else
                {
                    Label1.Text = "Please xxxxxx write in reject reason!";
                }
            }
        }
    }
}