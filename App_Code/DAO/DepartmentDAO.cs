using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.DAO
{
    public class DepartmentDAO
    {
        team6adprojectdbEntities5 ctx = new team6adprojectdbEntities5();

        public DepartmentDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<Item> PopulateCatDropDownList(string category)
        {
            List<Item> Ilist = new List<Item>();
            Ilist = ctx.Items.Where(x => x.category == category).ToList();

            return Ilist;
        }
        public void submitRequisitionItemList(List<String> qty, List<String> itemcode, int empcode)
        {
            try
            {
                int ReqSize = qty.Count;
                Employee e1 = ctx.Employees.Where(x => x.role == "departmentemployee" && x.employeecode == empcode).First();
                string dcode = e1.deptcode;
                var t = new Requisition
                {
                    employeecode = empcode,
                    deptcode = dcode,
                    status = 0,
                };
                ctx.Requisitions.Add(t);
                ctx.SaveChanges();
                Requisition r1 = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).OrderByDescending(x => x.requisitionid).Take(1).Single();
                int rid = r1.requisitionid;
                for (int i = 0; i < ReqSize; i++)
                {
                    var t1 = new RequisitionItem
                    {
                        requisitionid = rid,
                        itemcode = itemcode.ElementAt(i),
                        quantity = Convert.ToInt32(qty.ElementAt(i)),
                        status = 0,
                    };
                    ctx.RequisitionItems.Add(t1);
                    ctx.SaveChanges();
                }
            }
            catch (NullReferenceException n)
            {
                System.Diagnostics.Debug.Write("ensure all fields are filled");
            }
            catch (FormatException f)
            {
                System.Diagnostics.Debug.Write("input is wrong format");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("contact administrator for error: " + e);
            }
        }
        public List<dynamic> retreiveRequistionsItems(int empcode)
        {
            List<dynamic> ridItemListDesc = new List<dynamic>();
            try
            {
                List<Requisition> ridList = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).ToList();
                List<int> ridIDList = ridList.Select(l => l.requisitionid).ToList();
                for (int i = 0; i < ridIDList.Count; i++)
                {
                    int ridvar = ridIDList.ElementAt(i);
                    var ridItemDesc = (from r in ctx.RequisitionItems
                                       join e in ctx.Items
                                       on r.itemcode equals e.itemcode
                                       where r.requisitionid == ridvar && r.status == 0
                                       select new
                                       {
                                           itemcode = r.itemcode,
                                           itemdesc = e.itemdescription,
                                           itemqty = r.quantity,
                                           rid = r.requisitionid,
                                           status = r.status,
                                           unit = e.unitofmeasure
                                       }).ToList();
                    ridItemListDesc.AddRange(ridItemDesc);
                }
            }
            catch (NullReferenceException n)
            {
                System.Diagnostics.Debug.Write("no pending requisition items found");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("contact administrator for error: " + e);
            }

            return ridItemListDesc;
        }
        public void updateRequistionsItems(string itemcode, string qty, string reqid, string orgqty)
        {
            try
            {
                int rid = Convert.ToInt32(reqid);
                int quantity = Convert.ToInt32(qty);
                int oquantity = Convert.ToInt32(orgqty);
                RequisitionItem rutable = ctx.RequisitionItems.Where(x => x.requisitionid == rid && x.itemcode == itemcode && x.quantity == oquantity && x.status == 0).First();
                rutable.quantity = quantity;
                ctx.SaveChanges();
            }
            catch (NullReferenceException n)
            {
                System.Diagnostics.Debug.Write("unable to update");
            }
            catch (FormatException f)
            {
                System.Diagnostics.Debug.Write("input is wrong format");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("contact administrator for error: " + e);
            }
        }
        public void deleteRequistionsItems(string itemcode, string qty, string reqid, int empcode)
        {
            try
            {
                int rid = Convert.ToInt32(reqid);
                int quantity = Convert.ToInt32(qty);
                RequisitionItem reqitemtable = ctx.RequisitionItems.Where(x => x.requisitionid == rid && x.itemcode == itemcode && x.quantity == quantity && x.status == 0).First();
                ctx.RequisitionItems.Remove(reqitemtable);
                ctx.SaveChanges();
                //Check if Req is empty after delete items
                List<Requisition> ridList = ctx.Requisitions.Where(x => x.employeecode == empcode && x.status == 0).ToList();
                List<int> ridIDList = ridList.Select(l => l.requisitionid).ToList();
                List<RequisitionItem> ridItemList = new List<RequisitionItem>();
                for (int i = 0; i < ridIDList.Count; i++)
                {
                    int ridvar = ridIDList.ElementAt(i);
                    var rec = ctx.RequisitionItems.Where(x => x.requisitionid == ridvar && x.status == 0).FirstOrDefault();
                    if (rec == null)
                    {
                        Requisition reqtable = ctx.Requisitions.Where(x => x.requisitionid == rid && x.employeecode == empcode).First();
                        ctx.Requisitions.Remove(reqtable);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (NullReferenceException n)
            {
                System.Diagnostics.Debug.Write("unable to delete");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("contact administrator for error: " + e);
            }
        }
        public string getUnit(string itemcode)
        {
            string itemunit = "";
            itemunit = ctx.Items.Where(x => x.itemcode == itemcode).Select(l => l.unitofmeasure).First();

            return itemunit;
        }
        public Department DRfindCurrentCollectionPoint(int id)
        {
            //  string CollectionPoint;
            Department d1 = new Department();

            Employee e1 = ctx.Employees.Where(x => x.role == "departmentrepresentative" && x.employeecode == id).First();
            string deptcode = e1.deptcode;
            d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            return d1;
        }
        public void DRupdateCollectionPoint(string Cpoint, int repcode)
        {
            try
            {
                Employee e1 = ctx.Employees.Where(x => x.role == "departmentrepresentative" && x.employeecode == repcode).First();
                string deptcode = e1.deptcode;
                Department d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
                d1.collectionpoint = Cpoint;
                ctx.SaveChanges();
            }
            catch (NullReferenceException n)
            {
                errormessage("no collection point found");
            }
            catch (Exception e)
            {
                errormessage("contact administrator for error: " + e);
            }
        }
        public Department DHfindCurrentCollectionPoint(int id)
        {
            Department d1 = new Department();
            Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == id).First();
            string deptcode = e1.deptcode;
            d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            return d1;
        }
        public void DHupdateCollectionPoint(string Cpoint, int headcode)
        {
            try
            {
                Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).First();
                string deptcode = e1.deptcode;
                Department d1 = ctx.Departments.Where(x => x.deptcode == deptcode).First();
                d1.collectionpoint = Cpoint;
                ctx.SaveChanges();
            }
            catch (NullReferenceException n)
            {
                errormessage("no collection point found");
            }
            catch (Exception e)
            {
                errormessage("contact administrator for error: " + e);
            }
        }
        public Employee getDepartmentRepresentative(int headcode)
        {
            string dept;

            Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).First();
            dept = e1.deptcode;
            Employee e2 = ctx.Employees.Where(x => x.deptcode == dept && x.role == "departmentrepresentative").First();
            return e2;
        }
        public Employee getDepartmentRepresentativeByDept(string dept)
        {
            Employee e= ctx.Employees.Where(x => x.deptcode == dept && x.role == "departmentrepresentative").FirstOrDefault();
            return e;
        }
        public List<Employee> PopulateEmpList(int headcode)
        {
            string dept;

            Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).First();
            dept = e1.deptcode;
            List<Employee> Elist = ctx.Employees.Where(x => x.deptcode == dept && x.role != "departmenthead").ToList();
            ctx.SaveChanges();
            return Elist;
        }
        public void setRepresentative(int empCode)
        {
            try
            {
                Employee e1 = ctx.Employees.Where(x => x.employeecode == empCode).First();
                e1.role = "departmentrepresentative";
                ctx.SaveChanges();
            }
            catch (NullReferenceException n)
            {
                errormessage("no employee found");
            }
            catch (Exception e)
            {
                errormessage("cannot set collection point because : " + e);
            }
        }
        public void changePreviousRepresentative(int empCode)
        {
            try
            {
                Employee e1 = ctx.Employees.Where(x => x.employeecode == empCode).First();
                e1.role = "departmentemployee";
                ctx.SaveChanges();
            }
            catch (NullReferenceException n)
            {
                errormessage("no employee found");
            }
            catch (Exception e)
            {
                errormessage("contact admin. error message: " + e);
            }
        }
        public List<Requisition> DHgetRequestionItems(int headcode)
        {
            string dept;

            Employee e1 = ctx.Employees.Where(x => x.role == "departmenthead" && x.employeecode == headcode).FirstOrDefault();
            List<Requisition> rl;
            dept = e1.deptcode;
            rl = ctx.Requisitions.Where(x => x.deptcode == dept && x.approvercode == null && x.approvaldate == null).ToList();
            return rl;
        }
        public IEnumerable<dynamic> getItems(int reqid)
        {

            var rlist = ctx.RequisitionItems.Where(x => x.requisitionid == reqid).Select(x => new { x.requisitionid, x.Item.itemdescription, x.quantity }).ToList();
            return rlist;
        }
        public void approve(int id, int headcode)
        {
            try
            {
                Requisition r = ctx.Requisitions.Where(x => x.requisitionid == id).First();
                DateTime date = DateTime.Today;
                r.approvaldate = date;
                r.approvercode = headcode;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                errormessage("cannot approve. contact admin for error:  " + e);
            }
        }
        public void reject(int id)
        {
            Requisition r = ctx.Requisitions.Where(x => x.requisitionid == id).First();
            ctx.Requisitions.Remove(r);
            ctx.SaveChanges();
        }
        public string getEmployee(int requid)
        {
            int code;
            string email;

            Requisition r = ctx.Requisitions.Where(x => x.requisitionid == requid).First();
            code = r.employeecode;
            Employee e = ctx.Employees.Where(x => x.employeecode == code).First();
            email = e.employeeemail;
            return email;

        }
        public List<Employee> getAllEmployees(int headcode)
        {
            string deptcode;

            List<Employee> elist = new List<Employee>();
            Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "departmenthead").First();
            deptcode = e.deptcode;
            elist = ctx.Employees.Where(x => x.deptcode == deptcode && x.role != "departmenthead").ToList();
            return elist;
        }
        public void delegateAuthority(int headcode, int ecode, DateTime from, DateTime to)
        {
            string deptcode;
            try
            {
                Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "departmenthead").First();
                e.role = "delegatedHead";
                deptcode = e.deptcode;
                Employee e1 = ctx.Employees.Where(x => x.employeecode == ecode).First();
                e1.role = "delegatedemployee";
                Department d = ctx.Departments.Where(x => x.deptcode == deptcode).First();
                d.delegatecode = ecode;
                d.startdate = from;
                d.enddate = to;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                errormessage("delegation unsuccessful. contact admin for error:  " + e);
            }
        }
        public void retriveAuthority(int headcode)
        {
            string deptcode;

            Employee e = ctx.Employees.Where(x => x.employeecode == headcode && x.role == "delegatedHead").First();
            e.role = "departmenthead";
            deptcode = e.deptcode;
            Employee e1 = ctx.Employees.Where(x => x.role == "delegatedemployee").First();
            e1.role = "departmentEmployee";
            Department d = ctx.Departments.Where(x => x.deptcode == deptcode).First();
            d.delegatecode = null;
            d.startdate = null;
            d.enddate = null;
            ctx.SaveChanges();

        }
        public void errormessage(string myStringVariable)
        {
            System.Diagnostics.Debug.Write(myStringVariable);
        }
        public List<RequisitionItem> findRequisitionItemsByHead(int headcode)
        {
            Employee head = ctx.Employees.Where(x => x.employeecode == headcode).FirstOrDefault();
            string deptcode = head.deptcode;
            List<Requisition> items = ctx.Requisitions.Where(x => x.deptcode == deptcode && x.approvercode == null && x.approvaldate == null).ToList<Requisition>();
            List<RequisitionItem> ritems = new List<RequisitionItem>();
            foreach (Requisition i in items)
            {
                ritems.AddRange(i.RequisitionItems);
            }
            return ritems;

        }
        public Requisition findRequisitionByRequisitionId(int requisitionid)
        {
            Requisition item = ctx.Requisitions.Where(x => x.requisitionid==requisitionid).FirstOrDefault();
            return item;

        }
    }
}