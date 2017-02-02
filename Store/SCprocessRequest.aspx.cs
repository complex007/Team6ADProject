using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using Model;
using System.Security.Principal;

public partial class SCprocessRequest : System.Web.UI.Page
{
    SCserviceManager sc = new SCserviceManager();
    int role;
    //static int clerkcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        IIdentity id = User.Identity;
        role = Convert.ToInt32(User.Identity.Name);
        if (!IsPostBack)
        {
            //    clerkcode = Request.QueryString[];
            //}
            List<String> unique = sc.getuniqueitems();
            List<String> unique2 = sc.getuniqueitems2();

            //List<String> unique = new List<string>();
            //List<String> unique2 = new List<string>();




            dynamic MyDynamic = new System.Dynamic.ExpandoObject();

            List<dynamic> req = new List<dynamic>();
            List<dynamic> request = new List<dynamic>();
            List<dynamic> req2 = new List<dynamic>();
            List<dynamic> request2 = new List<dynamic>();



            if (unique2.Count != 0)
            {

                foreach (String i in unique2)
                {
                    req2 = sc.getrequestdeptstatus2(i).ToList();
                    request2.AddRange(req2);
                }
                Label1.Text = "Owed Request";
                GridView1.DataSource = request2;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    foreach (String i in unique)
                    {
                        req = sc.getrequestdeptstatus(i).ToList();
                        request.AddRange(req);
                    }
                    Label1.Text = "New Request";
                    GridView1.DataSource = request;
                    GridView1.DataBind();
                }

            }
            else if (unique.Count != 0)
            {
                foreach (String i in unique)
                {
                    req = sc.getrequestdeptstatus(i).ToList();
                    request.AddRange(req);
                }
                Label1.Text = "New Request";
                GridView1.DataSource = request;
                GridView1.DataBind();
            }

            if (GridView1.Rows.Count == 2)
            {
                int i = 0;

                if (GridView1.Rows[i].Cells[1].Text.Equals(GridView1.Rows[i + 1].Cells[1].Text) && GridView1.Rows[i].Cells[5].Text.Equals(GridView1.Rows[i + 1].Cells[5].Text))
                {
                    int qty = Convert.ToInt32(GridView1.Rows[0].Cells[6].Text) + Convert.ToInt32(GridView1.Rows[1].Cells[6].Text);
                    GridView1.Rows[0].Cells[6].Text = qty.ToString();
                    GridView1.Rows[i + 1].Cells[0].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[1].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[2].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[3].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[4].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[5].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[6].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[7].Text = string.Empty;
                    GridView1.Rows[i + 1].Cells[8].Text = string.Empty;

                    // GridView1.DataBind();
                }
            }
            else if (GridView1.Rows.Count > 2)
            {

                for (int i = 0; i < GridView1.Rows.Count - 1; i++)
                {
                    if (GridView1.Rows[i].Cells[1].Text.Equals(GridView1.Rows[i + 1].Cells[1].Text) && GridView1.Rows[i].Cells[5].Text.Equals(GridView1.Rows[i + 1].Cells[5].Text))
                    {
                        int qty = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text) + Convert.ToInt32(GridView1.Rows[i + 1].Cells[6].Text);
                        GridView1.Rows[i].Cells[6].Text = qty.ToString();
                        GridView1.Rows[i].Cells[2].Text = qty.ToString();
                        GridView1.Rows[i + 1].Cells[0].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[1].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[2].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[3].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[4].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[5].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[6].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[7].Text = string.Empty;
                        GridView1.Rows[i + 1].Cells[8].Text = string.Empty;

                    }
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("BIN");
            dt.Columns.Add("DESCRIPTION");
            dt.Columns.Add("QUANTITY");
            dt.Columns.Add("ACTUALQTY");
            dt.Columns.Add("REQUISITIONID");
            dt.Columns.Add("DEPARTMENTNAME");
            dt.Columns.Add("DEPTNEEDED");
            dt.Columns.Add("ALLOCATED");
            dt.Columns.Add("ITEMCODE");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[5].Text != "")
                    dt.Rows.Add(new object[] { GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, GridView1.Rows[i].Cells[2].Text, GridView1.Rows[i].Cells[3].Text, GridView1.Rows[i].Cells[4].Text, GridView1.Rows[i].Cells[5].Text, GridView1.Rows[i].Cells[6].Text, GridView1.Rows[i].Cells[7].Text, GridView1.Rows[i].Cells[8].Text });
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count != 0)
            {
                GenerateUniqueData(0);


                //getallocations();
                GridView1.HeaderRow.Cells[8].Visible = false;
                GridView1.HeaderRow.Cells[4].Visible = false;

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.Rows[i].Cells[8].Visible = false;
                    GridView1.Rows[i].Cells[4].Visible = false;
                }

            }
            else if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "No Request to Process";
            }
        }
    }




    private void GenerateUniqueData(int cellno)
    {

        int z = 0;
        int j = 0;
        int y = 0;

        List<int> spare = new List<int>();
        List<int> allocated = new List<int>();
        List<int> dneed = new List<int>();
        dneed.Add(Convert.ToInt32(GridView1.Rows[0].Cells[6].Text));
        int initialvalue = Convert.ToInt32(GridView1.Rows[0].Cells[3].Text);
        if (GridView1.Rows.Count == 1)
        {
            GridViewRow row = GridView1.Rows[j];
            TextBox tx = (TextBox)row.FindControl("Textfrom");
            allocated = sc.recommendDistribution(initialvalue, dneed);
            tx.Text = allocated[0].ToString();
        }
        int flag = 1;
        string initialnamevalue = GridView1.Rows[0].Cells[cellno].Text;
        Double qty = Convert.ToDouble(GridView1.Rows[0].Cells[2].Text);
        Double temp = 0;
        for (int i = 1; i < GridView1.Rows.Count; i++)
        {

            if (GridView1.Rows[i].Cells[cellno].Text == initialnamevalue)
            {

                temp = Convert.ToDouble(GridView1.Rows[i].Cells[2].Text);
                qty = qty + temp;

                GridView1.Rows[i].Cells[cellno].Text = string.Empty;
                GridView1.Rows[i].Cells[1].Text = string.Empty;
                GridView1.Rows[i].Cells[2].Text = string.Empty;
                GridView1.Rows[i].Cells[3].Text = string.Empty;
                dneed.Add(Convert.ToInt32(GridView1.Rows[i].Cells[6].Text));
                int K = allocated.Count;
                K++;
                int fl = 0;
                if (GridView1.Rows[i].RowIndex == GridView1.Rows.Count - 1)
                {
                    y = z + dneed.Count;
                    allocated = sc.recommendDistribution(initialvalue, dneed);
                    int q = allocated.Count;
                    K++;
                    int f = 0;
                    for (j = z; j < y; j++)
                    {
                        if (f != q)
                        {
                            GridViewRow row = GridView1.Rows[j];
                            TextBox tx = (TextBox)row.FindControl("Textfrom");
                            //GridView1.Rows[j].Cells[7].Text = allocated[f].ToString();
                            tx.Text = allocated[f].ToString();

                        }
                        fl++;

                    }
                }



            }

            else
            {


                flag++;
                if (flag == 2)
                {
                    GridView1.Rows[0].Cells[2].Text = qty.ToString();
                    flag++;
                }

                else if (flag > 2)
                {

                    GridView1.Rows[(int)Session["value"]].Cells[2].Text = qty.ToString();
                }

                initialnamevalue = GridView1.Rows[i].Cells[cellno].Text;

                qty = Convert.ToDouble(GridView1.Rows[i].Cells[2].Text);
                Session["value"] = i;
                y = z + dneed.Count;
                allocated = sc.recommendDistribution(initialvalue, dneed);
                int K = allocated.Count;
                K++;
                int fla = 0;
                for (j = z; j < y; j++)
                {
                    GridViewRow row = GridView1.Rows[j];
                    TextBox tx = (TextBox)row.FindControl("Textfrom");
                    if (fla != K)
                    {
                        //GridView1.Rows[j].Cells[7].Text = allocated[fla].ToString();
                        tx.Text = allocated[fla].ToString();
                    }
                    fla++;

                }
                spare.AddRange(dneed);
                z = spare.Count;

                dneed.Clear();

                initialvalue = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);

                dneed.Add(Convert.ToInt32(GridView1.Rows[i].Cells[6].Text));
                if (GridView1.Rows[i].RowIndex == GridView1.Rows.Count - 1)
                {
                    y = z + dneed.Count;
                    allocated = sc.recommendDistribution(initialvalue, dneed);
                    int q = allocated.Count;
                    K++;
                    int f = 0;
                    for (j = z; j < y; j++)
                    {
                        if (f != q)
                        {
                            GridViewRow row = GridView1.Rows[j];
                            TextBox tx = (TextBox)row.FindControl("Textfrom");
                            //GridView1.Rows[j].Cells[7].Text = allocated[f].ToString();
                            tx.Text = allocated[f].ToString();
                        }
                        fla++;

                    }
                }

            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        List<String> error = new List<string>();
        if (GridView1.Rows.Count != 0)
        {

            GridViewRow r = GridView1.Rows[0];
            TextBox t = (TextBox)r.FindControl("Textfrom");
            int actual = Convert.ToInt32(GridView1.Rows[0].Cells[3].Text);
            List<int> dneed = new List<int>();
            dneed.Add(Convert.ToInt32(t.Text));
            String itemdescription = GridView1.Rows[0].Cells[1].Text;
            for (int k = 1; k < GridView1.Rows.Count; k++)
            {
                GridViewRow row = GridView1.Rows[k];
                TextBox tx = (TextBox)row.FindControl("Textfrom");
                if (GridView1.Rows[k].Cells[3].Text.Equals(""))
                {
                    for (int j = k; j > 0; j--)
                    {
                        if (GridView1.Rows[j].Cells[3].Text != "")
                        {
                            actual = Convert.ToInt32(GridView1.Rows[j].Cells[3].Text);
                            break;
                        }
                    }
                    dneed.Add(Convert.ToInt32(tx.Text));
                    if (GridView1.Rows[k].RowIndex == GridView1.Rows.Count - 1)
                    {
                        if (dneed.Sum() > actual)
                        {
                            error.Add(itemdescription);

                        }
                    }
                }
                else
                {
                    if (dneed.Sum() > actual)
                    {
                        error.Add(itemdescription);

                    }
                    if (GridView1.Rows.Count > 0)
                    {
                        actual = Convert.ToInt32(GridView1.Rows[k].Cells[3].Text);
                        dneed.Clear();
                        dneed.Add(Convert.ToInt32(tx.Text));
                        itemdescription = GridView1.Rows[k].Cells[1].Text;
                    }
                    if (GridView1.Rows[k].RowIndex == GridView1.Rows.Count - 1)
                    {
                        if (dneed.Sum() > actual)
                        {
                            error.Add(itemdescription);

                        }
                    }
                }
            }
        }

        //

        if (error.Count == 0)
        {


            List<String> deptList = new List<string>();
            List<String> dlist = new List<string>();
            string itemcode, dept;
            int allocatedqty, actualqty1 = 0, repcode;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Disbursement disb = new Disbursement();
                Disbursement disbid = new Disbursement();
                String d = GridView1.Rows[i].Cells[5].Text;


                dept = sc.getdepartmentcode(d);
                repcode = sc.getrepresentativecode(dept);

                disb.representativecode = repcode;
                disb.deptcode = dept;
                disbid = sc.addtodisbursement(disb);


                GridViewRow row = GridView1.Rows[i];
                TextBox tx = (TextBox)row.FindControl("Textfrom");

                itemcode = GridView1.Rows[i].Cells[8].Text;

                allocatedqty = Convert.ToInt32(tx.Text);
                DisbursementItem disbitem = new DisbursementItem();
                disbitem.disbursementid = disbid.disbursementid;
                disbitem.itemcode = itemcode;
                disbitem.allocatedquantity = allocatedqty;
                sc.addtodisbursementitem(disbid, disbitem);






                int deptneedsum = 0;
                int initialactualqty = 0;
                int deptneed = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);
                if (GridView1.Rows[i].Cells[2].Text.Equals(""))
                {
                    deptneedsum = 0;
                }
                else
                {
                    deptneedsum = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                }
                int allocated = Convert.ToInt32(tx.Text);
                int requid = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                if (GridView1.Rows[i].Cells[3].Text.Equals(""))
                {
                    initialactualqty = 0;
                }
                else
                {
                    initialactualqty = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                }
                String dep = GridView1.Rows[i].Cells[5].Text;
                dept = sc.getdepartmentcode(dep);
                int requisition = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                Requisition employeecode = sc.getemployeecode(requisition);

                if (GridView1.Rows[i].Cells[3].Text != " ")
                {
                    if (initialactualqty > deptneedsum)
                    {
                        initialactualqty = initialactualqty - deptneedsum;
                        Item reorderlevel = sc.getreorderlevel(GridView1.Rows[i].Cells[8].Text);
                        if (initialactualqty <= reorderlevel.reorderlevel)
                        {
                            sc.raiseReorder(reorderlevel, role);

                            //Add clerk code here
                        }

                    }
                    else
                    {
                        initialactualqty = deptneedsum - initialactualqty;
                        Item reorderlevel = sc.getreorderlevel(GridView1.Rows[i].Cells[8].Text);
                        if (initialactualqty <= reorderlevel.reorderlevel)
                        {
                            sc.raiseReorder(reorderlevel, role);
                        }

                    }

                }
                if (GridView1.Rows[i].Cells[3].Text.Equals(""))
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (GridView1.Rows[j].Cells[3].Text != "")
                        {
                            actualqty1 = Convert.ToInt32(GridView1.Rows[j].Cells[3].Text);
                            break;
                        }
                    }


                }
                else
                {
                    actualqty1 = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                }
                string itemcode1 = GridView1.Rows[i].Cells[8].Text;






                RequisitionItem status = sc.getstatus(requid, itemcode1);

                if (deptneed == allocated)
                {
                    sc.updateStatus(requid, itemcode1, actualqty1 - allocated);
                }
                else if (deptneed != allocated)
                {
                    sc.owestatus(requid, itemcode1, deptneed - allocated, allocated, dept, employeecode.employeecode, status);
                }
            }
            Response.Redirect("SCprocessRequest.aspx");

        }
        else if (error.Count > 0)
        {
            //String s = "";
            //  BulletedList1.Items.Add("Allocation Exceeded the Actual Quantity");
            for (int i = 0; i < error.Count; i++)
            {
                BulletedList1.Items.Add(error[i]);
            }
            // Label1.Text = s;

        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}