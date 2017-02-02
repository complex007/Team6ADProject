using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHdeligateAuthority : System.Web.UI.Page
{
    static int headcode;
    DHserviceManager d = new DHserviceManager();

    static bool button1_was_clicked = false;
    static bool button2_was_clicked = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        headcode = Convert.ToInt32(User.Identity.Name);
        if (!IsPostBack)
        {
            Calendar1.Visible = false;
            Calendar3.Visible = false;
            List<Employee> elist = new List<Employee>();
            elist = d.getAllEmployees(headcode);
            DropDownList1.DataSource = elist;
            DropDownList1.DataTextField = "employeename";
            DropDownList1.DataValueField = "employeecode";
            DropDownList1.DataBind();
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;

        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {


        TextBox1.Text = Calendar1.SelectedDate.ToString();
        Calendar1.Visible = false;

    }


    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        if (Calendar3.Visible)
        {
            Calendar3.Visible = false;
        }
        else
        {
            Calendar3.Visible = true;

        }

    }
    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = Calendar3.SelectedDate.ToString();
        Calendar3.Visible = false;

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
            if (Page.IsValid)
            {
                int ecode;
                string startdate, enddate;
                DateTime from, to;
                startdate = TextBox1.Text;
                enddate = TextBox2.Text;
                from = Convert.ToDateTime(startdate);
                to = Convert.ToDateTime(enddate);
                ecode = Convert.ToInt32(DropDownList1.SelectedValue);
                d.delegateAuthority(headcode, ecode, from, to);
                if (from.CompareTo(DateTime.Now) <= 0)
                {
                    d.executeDelegation();
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        //}
        //catch (Exception ex)
        //{
        //    MessageBox1.Show(this.Page, "delegation failed. try again");
        //    System.Diagnostics.Debug.WriteLine(ex);
        //}
    }

}
//public static class MessageBox1
//{
//    public static void Show(this Page Page, String Message)
//    {
//        Page.ClientScript.RegisterStartupScript(
//           Page.GetType(),
//           "MessageBox",
//           "<script language='javascript'>alert('" + Message + "');</script>"
//        );
//    }
//}