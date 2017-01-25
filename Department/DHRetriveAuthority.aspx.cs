using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RetriveAuthority : System.Web.UI.Page
{
    string id;
    static int headcode;
    DHserviceManager d = new DHserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Request.QueryString["id"];
            headcode = 1012;
        }

        }

    protected void Button1_Click(object sender, EventArgs e)
    {
        d.retriveAuthority(headcode);
        Response.Redirect("~/login.aspx");
    }
}