using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DEpendingRequest : System.Web.UI.Page
{

    DEserviceManager eM = new DEserviceManager();
    string category;
    int ecode;

    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        ecode = Convert.ToInt32(User.Identity.Name);
        List<dynamic> rRIL = new List<dynamic>();
        if (!IsPostBack)
        {

            rRIL = eM.retreiveRequistionsItems(ecode);
            bool isEmpty = !rRIL.Any();
            if (isEmpty)
            
            {
                Label1.Visible = true;
                Label1.Text = "No pending request";
                
            }

            else
            {
                GridView1.DataSource = rRIL;
                GridView1.DataBind();

                GridView1.Columns[3].Visible = false;//rid
                GridView1.Columns[4].Visible = false;//original qty
                GridView1.Columns[5].Visible = false;//itemcode

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (!chkRow.Checked)
                        {
                            TextBox txtRow = (row.Cells[2].FindControl("txtBoxQty") as TextBox);
                            txtRow.ReadOnly = true;
                        }
                    }
                }
            }
            


        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Changed " + GridView1.SelectedIndex);
    }


    protected void updateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //UPDATE LOGIC

                        TextBox txtRow = (row.Cells[2].FindControl("txtBoxQty") as TextBox);
                        string itemcodeid = row.Cells[5].Text;
                        string itemqty = txtRow.Text;
                        string reqid = row.Cells[3].Text;
                        string origqty = row.Cells[4].Text;
                        System.Diagnostics.Debug.WriteLine("SELECTED " + itemcodeid + " " + itemqty + " " + reqid);
                        eM.updateRequistionsItems(itemcodeid, itemqty, reqid, origqty);
                        System.Diagnostics.Debug.WriteLine("UPDATED " + itemcodeid + " " + itemqty + " " + reqid + " org " + origqty);
                        
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, "update failed. try again");
            System.Diagnostics.Debug.WriteLine(ex);
        }

    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //DELETE LOGIC
                        string itemcodeid = row.Cells[5].Text;
                        string itemqty = row.Cells[4].Text;
                        string reqid = row.Cells[3].Text;
                        System.Diagnostics.Debug.WriteLine("SELECTED " + itemcodeid + " " + itemqty + " " + reqid);
                        eM.deleteRequistionsItems(itemcodeid, itemqty, reqid, ecode);
                        System.Diagnostics.Debug.WriteLine("DELETED " + itemcodeid + " " + itemqty + " " + reqid);
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, "delete failed. try again");
            System.Diagnostics.Debug.WriteLine(ex);
        }


    }

    protected void chkRow_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
        {
            //txtBoxQty.Enable = true;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        TextBox txtRow = (row.Cells[2].FindControl("txtBoxQty") as TextBox);
                        txtRow.ReadOnly = false;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("True");


        }
        else
        {
            // txtBoxQty.Enable = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (!chkRow.Checked)
                    {
                        TextBox txtRow = (row.Cells[2].FindControl("txtBoxQty") as TextBox);
                        txtRow.ReadOnly=true;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("False");
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;
        //BindData();
    }
}
public static class MessageBox
{
    public static void Show(this Page Page, String Message)
    {
        Page.ClientScript.RegisterStartupScript(
           Page.GetType(),
           "MessageBox",
           "<script language='javascript'>alert('" + Message + "');</script>"
        );
    }
}