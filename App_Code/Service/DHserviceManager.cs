using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;


/// <summary>
/// Summary description for DHserviceManager
/// </summary>
public class DHserviceManager
    {
        DepartmentDAO ddao = new DepartmentDAO();
        public DHserviceManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public Department DHfindCurrentCollectionPoint(int id)
        {
            return ddao.DHfindCurrentCollectionPoint(id);
        }
        public void DHupdateCollectionPoint(string Cpoint, int headcode)
        {
            ddao.DHupdateCollectionPoint(Cpoint, headcode);
        }
        public Employee getDepartmentRepresentative(int headcode)
        {
            return ddao.getDepartmentRepresentative(headcode);
        }
        public List<Employee> PopulateEmpList(int headcode)
        {
            return ddao.PopulateEmpList(headcode);
        }
        public void setRepresentative(int empCode)
        {
            ddao.setRepresentative(empCode);
        }
        public void changePreviousRepresentative(int empCode)
        {
            ddao.changePreviousRepresentative(empCode);
        }
        public List<Requisition> DHgetRequestionItems(int headcode)
        {
            return ddao.DHgetRequestionItems(headcode);
        }
        public IEnumerable<dynamic> getItems(int reqid)
        {
            return ddao.getItems(reqid);
        }

        public void approve(int id, int headcode)
        {

            ddao.approve(id, headcode);
        }

        public void reject(int id)
        {

            ddao.reject(id);

        }

        public void sendRejectEmail(string comments)
        {
            if (comments != null)
            {
                sendEmail(comments);
            }
            else
            {
                comments = "your request was rejected";
                sendEmail(comments);
            }
        }

        public void sendEmail(string message)
        {
            // string email;
            // List<int> ids = new List<int>();

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //  String val = GridView1.Rows[i].Cells[0].Text;
            //  if (!String.IsNullOrEmpty(val))
            // ids.Add(Convert.ToInt32(val));
            // }
            //  foreach (int id in ids)
            // {
            //   email = d.getEmployee(id);

            SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
            MailMessage mail = new MailMessage();
            // string reason = TextBox1.Text;
            mail.Body = message;

            //Setting From , To and CC
            mail.From = new MailAddress("kaparnanair02@gmail.com");
            // mail.From = new MailAddress(email);
            mail.To.Add(new MailAddress("kaparnanair02@gmail.com"));
            // mail.CC.Add(new MailAddress("843168572@qq.com"));
            // mail.To.Add(new MailAddress(email));
            smtpClient.Send(mail);
            //  }
        }

        public string getEmployee(int requid)
        {
            return ddao.getEmployee(requid);


        }

        public Employee getDepartmentRepresentativeByDept(string dept)
        {
            return ddao.getDepartmentRepresentativeByDept(dept);
        }
        public List<Employee> getAllEmployees(int headcode)
        {
            return ddao.getAllEmployees(headcode);
        }

        public void delegateAuthority(int headcode, int ecode, DateTime from, DateTime to)
        {
            ddao.delegateAuthority(headcode, ecode, from, to);
        }

        public void retriveAuthority(int headcode)
        {
            ddao.retriveAuthority(headcode);
        }
        public List<RequisitionItem> findRequisitionItemsByHead(int headcode)
        {
            List<RequisitionItem> items = ddao.findRequisitionItemsByHead(  headcode);
            return items;
        }
        public Requisition findRequisitionByRequisitionId(int requisitionid)
        {
            Requisition item=ddao.findRequisitionByRequisitionId(requisitionid);
            return item;

        }
    }
