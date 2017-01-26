using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class setcollectionpointrep : System.Web.UI.Page
{

    String id = " ";
    int code;
    DRserviceManager d = new DRserviceManager();
    Department d1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            id = Request.QueryString["id"];
            code = 1003;
            d1 = d.DRfindCurrentCollectionPoint(code);
            TextBox1.Text = d1.collectionpoint;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string SelectedValue = RadioButtonList1.SelectedValue;
        TextBox1.Text = SelectedValue;
        d.DRupdateCollectionPoint(SelectedValue, 1001);
    }
}