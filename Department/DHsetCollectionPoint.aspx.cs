using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHsetCollectionPoint : System.Web.UI.Page
{
    int code;
    DHserviceManager d = new DHserviceManager();
    Department d1;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        code = Convert.ToInt32(User.Identity.Name);
        if (!IsPostBack)
        {
            d1=d.DHfindCurrentCollectionPoint(code);
            Label3.Text = d1.collectionpoint;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string SelectedValue = RadioButtonList1.SelectedValue;
        Label3.Text = SelectedValue;
        d.DHupdateCollectionPoint(SelectedValue, code);
    }
}