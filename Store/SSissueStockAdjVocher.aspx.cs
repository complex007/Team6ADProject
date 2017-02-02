using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SSissueStockAdjVocher : System.Web.UI.Page
{
    List<AdjustmentVoucher> adjs;
    SSserviceManager ssmanager = new SSserviceManager();
    int role;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        role = Convert.ToInt32(User.Identity.Name);
        adjs = ssmanager.findUnapprovedVouchers();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (!IsPostBack)
        {
            if (adjs.Count == 0)
            {
                Label1.Text = "No unapproved adjustment vouchers.";
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


                    List<AdjustmentItem> adjitems = adjs[Convert.ToInt32(e.CommandArgument)].AdjustmentItems.ToList();
                    if (adjitems.Count != 0)
                    {
                        GridView1.DataSource = adjitems;
                        GridView1.DataBind();
                        Label1.Text = "";

                    }
                    else
                        Label1.Text = "No items found in adjustment voucher.";
                    break;
                }
            case "Reject":
                {
                    int poNum = adjs[Convert.ToInt32(e.CommandArgument)].vouchernumber;
                    string toemail = adjs[Convert.ToInt32(e.CommandArgument)].Employee.employeeemail;
                    try
                    {
                        if (TextBox1.Text.Trim() == "")
                            ssmanager.deleteAdjustmentByVoucherNumber(poNum, role);
                        else
                            ssmanager.deleteAdjustmentByVoucherNumber(poNum, role, TextBox1.Text);
                    }
                    //ClassList.deleteAdjustmentByVoucherNumber(poNum);
                    catch (SSexception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                    Label1.Text = String.Format("Adjustment voucher {0} rejected.", poNum);

                    refreshGV2();
                    break;
                }
            case "Approve":
                {
                    int poNum = adjs[Convert.ToInt32(e.CommandArgument)].vouchernumber;
                    try
                    {
                        ssmanager.approveAdjustmentByVoucherNumber(poNum, role);
                    }
                    catch (SSexception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                    //ClassList.approveAdjVoucher(poNum);
                    Label1.Text = String.Format("Adjustment voucher number {0} is approved by {1}.", poNum, SSserviceManager.findThreeworkingday(DateTime.Today).ToString("MM-dd-yyyy"));
                    refreshGV2();
                    break;
                }
            default:
                {
                    Label1.Text = "Sorry, please try again. ";
                    break;
                }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        foreach (AdjustmentVoucher i in adjs)
        {
            try
            {
                ssmanager.approveAdjustmentByVoucherNumber(i.vouchernumber, role);
            }
            catch (SSexception ex)
            {
                Label1.Text = ex.Message;
            }
        }
        refreshGV2();
        Label1.Text = "All Adjustment vouchers approved today and are planned to deliver on " + DateTime.Parse(SSserviceManager.findThreeworkingday(DateTime.Today).ToString()).ToString("MM-dd-yyyy") + ".";
    }
    protected void refreshGV2()
    {
        adjs = StoreSupplierDAO.findUnapprovedVouchers();
        GridView2.DataSource = adjs;
        GridView2.DataBind();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        foreach (AdjustmentVoucher i in adjs)
        {
            int poNum = i.vouchernumber;
            string toemail = i.Employee.employeeemail;
            try
            {
                ssmanager.deleteAdjustmentByVoucherNumber(poNum, role);
            }
            //ClassList.deleteAdjustmentByVoucherNumber(poNum);
            catch (SSexception ex)
            {
                Label1.Text = ex.Message;
            }
            Label1.Text = String.Format("Adjustment voucher {0} rejected.", poNum);
            if (TextBox1.Text.Trim() == "")
                ssmanager.sendMailToEmployee(String.Format("Adjustment voucher no. {0} has been rejected.", poNum), "hellocomplex007@gmail.com", toemail);
            // ClassList.sendEmail(String.Format("Adjustment voucher no. {0} has been rejected.", poNum));
            else
                ssmanager.sendMailToEmployee(String.Format("Adjustment voucher no. {0} has been rejected. Reason given: {1}", poNum, TextBox1.Text), "hellocomplex007@gmail.com", toemail);
            // ClassList.sendEmail(String.Format("Adjustment voucher no. {0} has been rejected. Reason given: {1}", poNum, TextBox1.Text));
            refreshGV2();

        }
        TextBox1.Text = "";
        refreshGV2();
        Label1.Text = "All Adjustment vouchers have been rejected.";
    }
}
