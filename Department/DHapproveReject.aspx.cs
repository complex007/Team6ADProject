using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHapproveReject : System.Web.UI.Page
{
    static int headcode;
    DHserviceManager d = new DHserviceManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        headcode = Convert.ToInt32(User.Identity.Name);
        if (!IsPostBack)
        {
            List<Requisition> r = d.DHgetRequestionItems(headcode);
            List<dynamic> item = new List<dynamic>();
            List<dynamic> items = new List<dynamic>();
            if (r.Count > 0)
            {
                foreach (Requisition i in r)
                {
                    item = d.getItems(i.requisitionid).ToList();
                    items.AddRange(item);
                }

                //if (items != null)
                //{
                GridView1.DataSource = items;
                GridView1.DataBind();
                GenerateUniqueData(0);
            }
            else
            {
                GridView1.Visible = false;
                Label1.Text = "No request exist currently";
            }
            //}
            //else
            //{
            //    GridView1.DataSource = null;
            //    GridView1.DataBind();
            //    Label1.Text = "No requests exist currently";
            //}
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            List<int> ids = new List<int>();

          for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                String val = GridView1.Rows[i].Cells[0].Text;
                if (!String.IsNullOrEmpty(val))
                    ids.Add(Convert.ToInt32(val));
            }
            foreach (int id in ids)
            {
                d.approve(id, headcode);
            }
        }
        catch(Exception e1)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Label1.Text = "Approved Successfully";
        }
    }
   
    private void GenerateUniqueData(int cellno)
    {
        //Logic for unique names
        //Step 1:
         string initialnamevalue = GridView1.Rows[0].Cells[cellno].Text;
        //Step 2:
        for (int i = 1; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows[i].Cells[cellno].Text == initialnamevalue)
                GridView1.Rows[i].Cells[cellno].Text = string.Empty;
            else
                initialnamevalue = GridView1.Rows[i].Cells[cellno].Text;
        }
    }
    protected void Reject_Click(object sender, EventArgs e)
    {
        string comments;
        comments = TextBox1.Text;
        d.sendRejectEmail(comments);
        
        try
        {
            
            List<int> ids = new List<int>();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                String val = GridView1.Rows[i].Cells[0].Text;
                if (!String.IsNullOrEmpty(val))
                    ids.Add(Convert.ToInt32(val));
            }
            foreach (int id in ids)
            {
                d.reject(id);
            }
        }
        catch (Exception e1)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Label1.Text = "Rejected";
        }
    }

    
}