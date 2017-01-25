using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHsetCollectionPoint : System.Web.UI.Page
{
    String id = " ";
    int code;
    DHserviceManager d = new DHserviceManager();
    Department d1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            id = Request.QueryString["id"];
            code = 1004;
            d1=d.DHfindCurrentCollectionPoint(code);
            TextBox1.Text = d1.collectionpoint;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string SelectedValue = RadioButtonList1.SelectedValue;
        TextBox1.Text = SelectedValue;
        d.DHupdateCollectionPoint(SelectedValue, 1004);
    }
}