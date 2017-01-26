using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
[ServiceContract]
public interface IService
{
    //host = http://10.10.2.73/adproteam6/WCF/Service1.svc
    //the string you pass from android jsonparser should be exactly the same with the JSON example behind the OperationContract.
    //all these JSON examples are tested and can successfully get values or update database.

    [OperationContract]
    [WebGet(UriTemplate = "/collectionpoint", ResponseFormat = WebMessageFormat.Json)]
    string[] listDeliverCollectionPoint();
    //JSON example:["Kent_Ridge", "Utown",  "Deck"]

    [OperationContract]
    [WebGet(UriTemplate = "/collectionpoint/{colpoint}", ResponseFormat = WebMessageFormat.Json)]
    WCFDisbursement[] findDeliverDisburseByCollectionPoint(string colpoint);
    //JSON example:[ {  "Collectiondate": null,  "Deptcode": "ZOOL",  "Disbursementid": 6,  "Representativecode": 1019  }]

    [OperationContract]
    [WebGet(UriTemplate = "/disbursement/{disbursementid}", ResponseFormat = WebMessageFormat.Json)]
    WCFDisbursementItem[] findDeliverDisburseItemByDisburseid(string disbursementid);
    //  JSON example:[
    //  {
    //    "Actualquantity": 11,
    //    "Allocatedquantity": 57,
    //    "Disbursementid": 2,
    //    "Itemcode": "E002"
    //  },
    //  {
    //    "Actualquantity": 11,
    //    "Allocatedquantity": 33,
    //    "Disbursementid": 2,
    //    "Itemcode": "E005"
    //  },
    //  {
    //    "Actualquantity": 11,
    //    "Allocatedquantity": 37,
    //    "Disbursementid": 2,
    //    "Itemcode": "E020"
    //  },
    //  {
    //    "Actualquantity": 11,
    //    "Allocatedquantity": 14,
    //    "Disbursementid": 2,
    //    "Itemcode": "F034"
    //  },
    //  {
    //    "Actualquantity": 11,
    //    "Allocatedquantity": 23,
    //    "Disbursementid": 2,
    //    "Itemcode": "T020"
    //  }
    //]


    [OperationContract]
    [WebInvoke(UriTemplate = "/disbursement/update", Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
    void UpdateDisbursementItem(List<WCFDisbursementItem> disitems);
    //JSON example: same with "/disbursement/{disbursementid}"

    [OperationContract]
    [WebGet(UriTemplate = "/item/{itemid}", ResponseFormat = WebMessageFormat.Json)]
    WCFItem findItemByItemcode(string itemid);
    //JSON example:
    //        {
    //  "Bin": "A1",
    //  "Category": "Clip",
    //  "Del": 0,
    //  "Itemcode": "C001",
    //  "Itemdescription": "Clips Double 1\"",
    //  "Quantityonhand": 60,
    //  "Reorderlevel": 50,
    //  "Reorderquantity": 30,
    //  "Supplier1": "ALPA",
    //  "Supplier2": "CHEP",
    //  "Supplier3": "BANE",
    //  "Unitofmeasure": "Dozen"
    //}


    [OperationContract]
    [WebInvoke(UriTemplate = "/adjustmentitems/create", Method = "POST",
   RequestFormat = WebMessageFormat.Json,
   ResponseFormat = WebMessageFormat.Json)]
    void createAdjustment(List<WCFAdjustmentItem> adjitems);
    //JSON example:
    //        [
    //  {
    //    "Suppliercode": "ALPA",
    //    "Quantity": 1,
    //    "Reason": "Lost",
    //    "Itemcode": "E002"
    //  },
    //  {
    //    "Suppliercode": "ALPA",
    //    "Quantity": 1,
    //    "Reason": "Lost",
    //    "Itemcode": "E005"
    //  }
    //]

    [OperationContract]
    [WebGet(UriTemplate = "/requisitionitems/{headcode}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFRequisitionItem> findRequisitionItemsByHead(string headcode);
    //JSON example:
    //        [
    //  {
    //    "Itemcode": "F021",
    //    "Quantity": 74,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "F035",
    //    "Quantity": 64,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "H011",
    //    "Quantity": 8,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "S011",
    //    "Quantity": 87,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "S012",
    //    "Quantity": 38,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "S021",
    //    "Quantity": 32,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  },
    //  {
    //    "Itemcode": "S101",
    //    "Quantity": 94,
    //    "Requisitionid": 2,
    //    "Status": 0
    //  }
    //]


    [OperationContract]
    [WebInvoke(UriTemplate = "/requisitionitems/reject", Method = "POST",
   RequestFormat = WebMessageFormat.Json,
   ResponseFormat = WebMessageFormat.Json)]
    void rejectRequisition(string requisitionid);
    // JSON example: "5"


    [OperationContract]
    [WebInvoke(UriTemplate = "/requisitionitems/approve", Method = "POST",
  RequestFormat = WebMessageFormat.Json,
  ResponseFormat = WebMessageFormat.Json)]
    void approveRequisition(string[] reidandheid);
    //JSON example:["2","1012"]

    [OperationContract]
    [WebGet(UriTemplate = "/employee/{headcode}", ResponseFormat = WebMessageFormat.Json)]
    List<WCFEmployee> populateEmployee(string headcode);
    //JSON example:
    //            [
    //  {
    //    "Del": 0,
    //    "Deptcode": "REGR",
    //    "Employeecode": 1013,
    //    "Employeeemail": "scarlett093@gmail.com",
    //    "Employeename": "Scarlett",
    //    "Role": "departmentrepresentative"
    //  },
    //  {
    //    "Del": 0,
    //    "Deptcode": "REGR",
    //    "Employeecode": 1014,
    //    "Employeeemail": "bond007@gmail.com",
    //    "Employeename": "Bond",
    //    "Role": "departmentemployee"
    //  },
    //  {
    //    "Del": 0,
    //    "Deptcode": "REGR",
    //    "Employeecode": 1015,
    //    "Employeeemail": "edward682279@gmail.com",
    //    "Employeename": "Edward",
    //    "Role": "departmentemployee"
    //  },
    //  {
    //    "Del": 0,
    //    "Deptcode": "REGR",
    //    "Employeecode": 1023,
    //    "Employeeemail": "david730@gmail.com",
    //    "Employeename": "David",
    //    "Role": "departmentemployee"
    //  }
    //]

    [OperationContract]
    [WebInvoke(UriTemplate = "/employee/setrepresentative", Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
    void setRepresentative(WCFEmployee employee);
    //JSON example:
    //      {
    //  "Del": 0,
    //  "Deptcode": "REGR",
    //  "Employeecode": 1014,
    //  "Employeeemail": "bond007@gmail.com",
    //  "Employeename": "Bond",
    //  "Role": "departmentemployee"
    //}

    [OperationContract]
    [WebInvoke(UriTemplate = "/employee/updatecollectionpoint", Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
    void updateCollectionPoint(string[] cpointandhecode);
    //JSON example:["UHC","1004"]

    [OperationContract]
    [WebGet(UriTemplate = "/employee/currentcollectionpoint/{headcode}", ResponseFormat = WebMessageFormat.Json)]
    string[] findCurrentCollectionPoint(string headcode);
    //JSON example: [
    //  "Utown"
    //]
}
[DataContract]
public class WCFDepartment
{
    string deptcode;
    string deptname;
    string contactname;
    string phoneno;
    string faxno;
    string collectionpoint;
    int delegatecode;
    DateTime startdate;
    DateTime enddate;
    int del;
    public static WCFDepartment Make(string deptcode, string deptname, string contactname,
        string phoneno, string faxno, string collectionpoint, int delegatecode, DateTime startdate, DateTime enddate, int del)
    {
        WCFDepartment dept = new WCFDepartment();
        dept.Deptcode = deptcode;
        dept.Deptname = deptname;
        dept.Contactname = contactname;
        dept.Phoneno = phoneno;
        dept.Faxno = faxno;
        dept.Collectionpoint = collectionpoint;
        dept.Delegatecode = delegatecode;
        dept.Startdate = startdate;
        dept.Enddate = enddate;
        dept.Del = del;
        return dept;
    }

    [DataMember]
    public string Deptcode
    {
        get
        {
            return deptcode;
        }

        set
        {
            deptcode = value;
        }
    }
    [DataMember]
    public string Deptname
    {
        get
        {
            return deptname;
        }

        set
        {
            deptname = value;
        }
    }
    [DataMember]
    public string Contactname
    {
        get
        {
            return contactname;
        }

        set
        {
            contactname = value;
        }
    }
    [DataMember]
    public string Phoneno
    {
        get
        {
            return phoneno;
        }

        set
        {
            phoneno = value;
        }
    }
    [DataMember]
    public string Faxno
    {
        get
        {
            return faxno;
        }

        set
        {
            faxno = value;
        }
    }
    [DataMember]
    public string Collectionpoint
    {
        get
        {
            return collectionpoint;
        }

        set
        {
            collectionpoint = value;
        }
    }
    [DataMember]
    public int Delegatecode
    {
        get
        {
            return delegatecode;
        }

        set
        {
            delegatecode = value;
        }
    }
    [DataMember]
    public DateTime Startdate
    {
        get
        {
            return startdate;
        }

        set
        {
            startdate = value;
        }
    }
    [DataMember]
    public DateTime Enddate
    {
        get
        {
            return enddate;
        }

        set
        {
            enddate = value;
        }
    }
    [DataMember]
    public int Del
    {
        get
        {
            return del;
        }

        set
        {
            del = value;
        }
    }
}
[DataContract]
public class WCFDisbursement
{
    int disbursementid;
    string deptcode;
    int representativecode;
    DateTime? collectiondate;


    public static WCFDisbursement Make(int disbursementid, string deptcode, int representativecode, DateTime? collectiondate)
    {
        WCFDisbursement disburse = new WCFDisbursement();
        disburse.disbursementid = disbursementid;
        disburse.deptcode = deptcode;
        disburse.representativecode = representativecode;
        disburse.collectiondate = collectiondate;

        return disburse;
    }
    [DataMember]
    public int Disbursementid
    {
        get
        {
            return disbursementid;
        }

        set
        {
            disbursementid = value;
        }
    }
    [DataMember]
    public string Deptcode
    {
        get
        {
            return deptcode;
        }

        set
        {
            deptcode = value;
        }
    }
    [DataMember]
    public int Representativecode
    {
        get
        {
            return representativecode;
        }

        set
        {
            representativecode = value;
        }
    }
    [DataMember]
    public DateTime? Collectiondate
    {
        get
        {
            return collectiondate;
        }

        set
        {
            collectiondate = value;
        }
    }
}

[DataContract]
public class WCFDisbursementItem
{
    int disbursementid;
    string itemcode;
    int allocatedquantity;
    int? actualquantity;

    public static WCFDisbursementItem Make(int disbursementid, string itemcode, int allocatedquantity, int? actualquantity)
    {
        WCFDisbursementItem ditem = new WCFDisbursementItem();
        ditem.disbursementid = disbursementid;
        ditem.itemcode = itemcode;
        ditem.allocatedquantity = allocatedquantity;
        ditem.actualquantity = actualquantity;
        return ditem;
    }

    [DataMember]
    public int Disbursementid
    {
        get
        {
            return disbursementid;
        }

        set
        {
            disbursementid = value;
        }
    }
    [DataMember]
    public string Itemcode
    {
        get
        {
            return itemcode;
        }

        set
        {
            itemcode = value;
        }
    }
    [DataMember]
    public int Allocatedquantity
    {
        get
        {
            return allocatedquantity;
        }

        set
        {
            allocatedquantity = value;
        }
    }
    [DataMember]
    public int? Actualquantity
    {
        get
        {
            return actualquantity;
        }

        set
        {
            actualquantity = value;
        }
    }
}

[DataContract]
public class WCFItem
{
    string itemcode;
    string category;
    string itemdescription;
    string bin;
    int quantityonhand;
    int reorderlevel;
    int reorderquantity;
    string unitofmeasure;
    string supplier1;
    string supplier2;
    string supplier3;
    int del;

    public static WCFItem Make(string itemcode, string category, string itemdescription, string bin, int quantityonhand,
        int reorderlevel, int reorderquantity, string unitofmeasure, string supplier1, string supplier2, string supplier3, int del)
    {
        WCFItem item = new WCFItem();
        item.itemcode = itemcode;
        item.category = category;
        item.itemdescription = itemdescription;
        item.bin = bin;
        item.quantityonhand = quantityonhand;
        item.reorderlevel = reorderlevel;
        item.reorderquantity = reorderquantity;
        item.unitofmeasure = unitofmeasure;
        item.supplier1 = supplier1;
        item.supplier2 = supplier2;
        item.supplier3 = supplier3;
        item.del = del;

        return item;
    }

    [DataMember]
    public string Itemcode
    {
        get
        {
            return itemcode;
        }

        set
        {
            itemcode = value;
        }
    }

    [DataMember]
    public string Category
    {
        get
        {
            return category;
        }

        set
        {
            category = value;
        }
    }

    [DataMember]
    public string Itemdescription
    {
        get
        {
            return itemdescription;
        }

        set
        {
            itemdescription = value;
        }
    }

    [DataMember]
    public string Bin
    {
        get
        {
            return bin;
        }

        set
        {
            bin = value;
        }
    }

    [DataMember]
    public int Quantityonhand
    {
        get
        {
            return quantityonhand;
        }

        set
        {
            quantityonhand = value;
        }
    }

    [DataMember]
    public int Reorderlevel
    {
        get
        {
            return reorderlevel;
        }

        set
        {
            reorderlevel = value;
        }
    }

    [DataMember]
    public int Reorderquantity
    {
        get
        {
            return reorderquantity;
        }

        set
        {
            reorderquantity = value;
        }
    }

    [DataMember]
    public string Unitofmeasure
    {
        get
        {
            return unitofmeasure;
        }

        set
        {
            unitofmeasure = value;
        }
    }

    [DataMember]
    public string Supplier1
    {
        get
        {
            return supplier1;
        }

        set
        {
            supplier1 = value;
        }
    }

    [DataMember]
    public string Supplier2
    {
        get
        {
            return supplier2;
        }

        set
        {
            supplier2 = value;
        }
    }

    [DataMember]
    public string Supplier3
    {
        get
        {
            return supplier3;
        }

        set
        {
            supplier3 = value;
        }
    }

    [DataMember]
    public int Del
    {
        get
        {
            return del;
        }

        set
        {
            del = value;
        }
    }
}

[DataContract]
public class WCFAdjustmentItem
{

    string itemcode;
    int quantity;
    string reason;
    string suppliercode;

    public static WCFAdjustmentItem Make(string itemcode, int quantity, string reason, string suppliercode)
    {
        WCFAdjustmentItem item = new WCFAdjustmentItem();

        item.itemcode = itemcode;
        item.quantity = quantity;
        item.reason = reason;
        item.Suppliercode = suppliercode;
        return item;
    }


    [DataMember]
    public string Itemcode
    {
        get
        {
            return itemcode;
        }

        set
        {
            itemcode = value;
        }
    }
    [DataMember]
    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }
    [DataMember]
    public string Reason
    {
        get
        {
            return reason;
        }

        set
        {
            reason = value;
        }
    }
    [DataMember]
    public string Suppliercode
    {
        get
        {
            return suppliercode;
        }

        set
        {
            suppliercode = value;
        }
    }
}
[DataContract]
public class WCFRequisitionItem
{
    int requisitionid;
    string itemcode;
    int quantity;
    int status;

    public static WCFRequisitionItem Make(int requisitionid, string itemcode, int quantity, int status)
    {
        WCFRequisitionItem item = new WCFRequisitionItem();
        item.requisitionid = requisitionid;
        item.itemcode = itemcode;
        item.quantity = quantity;
        item.status = status;
        return item;
    }
    [DataMember]
    public int Requisitionid
    {
        get
        {
            return requisitionid;
        }

        set
        {
            requisitionid = value;
        }
    }
    [DataMember]
    public string Itemcode
    {
        get
        {
            return itemcode;
        }

        set
        {
            itemcode = value;
        }
    }
    [DataMember]
    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }
    [DataMember]
    public int Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
        }
    }
}
[DataContract]
public class WCFEmployee
{
    int employeecode;
    string employeename;
    string employeeemail;
    string deptcode;
    string role;
    int del;
    public static WCFEmployee Make(int employeecode, string employeename, string employeeemail, string deptcode, string role, int del)
    {
        WCFEmployee item = new WCFEmployee();
        item.employeecode = employeecode;
        item.employeename = employeename;
        item.employeeemail = employeeemail;
        item.deptcode = deptcode;
        item.role = role;
        item.del = del;
        return item;
    }
    [DataMember]
    public int Employeecode
    {
        get
        {
            return employeecode;
        }

        set
        {
            employeecode = value;
        }
    }
    [DataMember]
    public string Employeename
    {
        get
        {
            return employeename;
        }

        set
        {
            employeename = value;
        }
    }
    [DataMember]
    public string Employeeemail
    {
        get
        {
            return employeeemail;
        }

        set
        {
            employeeemail = value;
        }
    }
    [DataMember]
    public string Deptcode
    {
        get
        {
            return deptcode;
        }

        set
        {
            deptcode = value;
        }
    }
    [DataMember]
    public string Role
    {
        get
        {
            return role;
        }

        set
        {
            role = value;
        }
    }
    [DataMember]
    public int Del
    {
        get
        {
            return del;
        }

        set
        {
            del = value;
        }
    }
}



