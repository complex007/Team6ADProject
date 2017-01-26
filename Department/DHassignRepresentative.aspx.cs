using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHassignRepresentative : System.Web.UI.Page
{
    string id;
    int headcode;
    static Employee e1;
    DHserviceManager d = new DHserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Request.QueryString["id"];
            headcode = 1000;
          e1 = d.getDepartmentRepresentative(headcode);
            List<Employee> elist = d.PopulateEmpList(headcode);
            DropDownList1.DataSource = elist;
            DropDownList1.DataTextField = "employeename";
            DropDownList1.DataValueField = "employeecode";
            DropDownList1.DataBind();
            
           Label1.Text = e1.employeename;          
        }

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Label1.Text = DropDownList1.SelectedItem.Text;
        int selectedVal = Convert.ToInt32(DropDownList1.SelectedValue);
        d.setRepresentative(selectedVal);        
        d.changePreviousRepresentative(e1.employeecode);
    }
}