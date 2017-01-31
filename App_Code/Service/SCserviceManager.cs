using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for SCserviceManager
/// </summary>
public class SCserviceManager
{
    team6adprojectdbEntities sce = new team6adprojectdbEntities();
    public SCserviceManager()
    {
        
    }
    //Update catalogue
    public Item getItem(string itcode)
    {
        Item it = sce.Items.Where(x => x.itemcode == itcode).FirstOrDefault();
        return it;
    }
    public List<Item> getCatalogue()
    {
        List<Item> catalogue = new List<Item>();
        catalogue = sce.Items.Where(x=>x.del==0).Select(y => y).ToList();
        //catalogue = sce.Items.Select(y => y).ToList();
        return catalogue;
    }

    public void deleteItem(string itcode)
    {
        Item it = getItem(itcode);
        //sce.Items.Remove(it);

        it.del = 1;
        sce.SaveChanges();
    }

    public void updateCatalogue(Item i)
    {
        var req = (from item in sce.Items
                  where item.itemcode == i.itemcode
                  select item).FirstOrDefault();

        req.itemdescription = i.itemdescription;
        req.category = i.category;
        req.reorderlevel = i.reorderlevel;
        req.reorderquantity = i.reorderquantity;
        req.unitofmeasure = i.unitofmeasure;
        req.bin = i.bin;

        sce.SaveChanges();
    }

    public void saveCatalogue(Item i)
    {
        sce.Items.Add(i);
        sce.SaveChanges();
    }

    //Update stock supplier
    public List<string> getItemcode()
    {
        List<string> list = sce.Items.Select(x => x.itemcode).ToList();
        return list;
    }

    public List<string> getSuppliercode()
    {
        List<string> list = sce.Suppliers.Select(x => x.suppliercode).ToList();
        return list;
    }

    public void updateItem(Item i)
    {
        var req = (from item in sce.Items
                   where item.itemcode == i.itemcode
                   select item).FirstOrDefault();
        req.supplier1 = i.supplier1;
        req.supplier2 = i.supplier2;
        req.supplier3 = i.supplier3;

        //Item it = getItem(i.itemcode);
        //it.supplier1 = i.supplier1;
        //it.supplier2 = i.supplier2;
        //it.supplier3 = i.supplier3;
        sce.SaveChanges();
    }

    //Updata supplier information
    public List<Supplier> getSupplier()
    {
        List<Supplier> slist = sce.Suppliers.Where(x=>x.del==0).Select(x => x).ToList();
        //List<Supplier> slist=sce.Suppliers.Select(x => x).ToList();
        return slist;
    }

    public Supplier getSupplier(string suppliercode)
    {
        return sce.Suppliers.Find(suppliercode);       
    }

    public void updateSupplier(Supplier s)
    {
        var req = (from supplier in sce.Suppliers
                   where supplier.suppliercode == s.suppliercode
                   select supplier).FirstOrDefault();

        req.suppliername = s.suppliername;
        req.contactname = s.contactname;
        req.phonenumber = s.phonenumber;
        req.faxnumber = s.faxnumber;
        req.address = s.address;
        req.gstregistrationno = s.gstregistrationno;

        sce.SaveChanges();
    }

    public void saveSupplier(Supplier s)
    {
        sce.Suppliers.Add(s);
        sce.SaveChanges();
    }

    public void deleteSupplier(Supplier s)
    {
        s.del = 1;
        //sce.Suppliers.Remove(s);
        sce.SaveChanges();
    }

    //Update tender information
    public List<string> getSuppliername()
    {
        List<string> list = sce.Suppliers.Select(x => x.suppliername).ToList();
        return list;
    }

    public Supplier getSupplierByName(string suppliername)
    {
        Supplier s = sce.Suppliers.Where(x => x.suppliername == suppliername).Select(y => y).FirstOrDefault();
        return s;
    }

    public IEnumerable<dynamic> getTenderQuotation(string suppliercode)
    {
        var req = from tender in sce.TenderQuotations
                  join item in sce.Items on tender.itemcode equals item.itemcode
                  where tender.suppliercode == suppliercode
                  select new { itemdesc = item.itemdescription, price = tender.price };
                      
        //var req = sce.TenderQuotations.Where(x => x.itemcode == getItemcode(scode) && x.suppliercode == scode)

        return req;
    }

    public Item getItemByItemdescription(string itemdescription)
    {
        Item i = sce.Items.Where(x => x.itemdescription == itemdescription).Select(y => y).FirstOrDefault();
        return i;
    }

   public void deleteTenderQuotation(TenderQuotation t)
    {    
        sce.TenderQuotations.Remove(t);
        sce.SaveChanges();
    }

    public TenderQuotation getTenderQuotationByKey(string suppliercode,string itemcode)
    {
        
        TenderQuotation tq = sce.TenderQuotations.Where(x => x.suppliercode == suppliercode && x.itemcode == itemcode).FirstOrDefault();
        //TenderQuotation tq = sce.TenderQuotations.Where(x => x.itemcoditemcode) == .FirstOrDefault(); 

        return tq;
    }

    public void updateTenderQuotation(TenderQuotation tq)
    {
        TenderQuotation tender = new TenderQuotation();
        tender = getTenderQuotationByKey(tq.suppliercode, tq.itemcode);
        tender.price = tq.price;

        sce.SaveChanges();
    }
    //public void updateTenderQuotation(Item i,TenderQuotation tq)
    //{

    //    Item item = new Item();
    //    item = getItem(i.itemcode);
    //    item.itemdescription = i.itemdescription;

    //    TenderQuotation tender = new TenderQuotation();
    //    tender = getTenderQuotationByKey(tq.suppliercode, tq.itemcode);
    //    tender.price = tq.price;

    //    sce.SaveChanges();     
    //}

    //public List<Item> getItemByListcode(List<string> list)
    //{
    //    List<Item> ilist = new List<Item>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        Item item = sce.Items.Where(x => x.itemcode == list[i]).Select(y => y).FirstOrDefault();
    //        ilist.Add(item);
    //    }
    //    return ilist;
    //}
    //public List<double> getPriceByListcode(List<string> list)
    //{
    //    List<double> plist = new List<double>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        double price = sce.TenderQuotations.Where(x => x.itemcode == list[i]).Select(y => y.price).FirstOrDefault();
    //        plist.Add(price);
    //    }
    //    return plist;
    //}

    //Report stock discrepancy
    public List<string> getItemCodeBySupplierCode(string suppliercode)
    {
        List<string> list = new List<string>();
        list = sce.TenderQuotations.Where(x => x.suppliercode == suppliercode).Select(y => y.itemcode).ToList();
        return list;
    }

   
    public void adjustItem(AdjustmentVoucher adjust)
    {

        //sce.AdjustmentItems.Add(adjust);

        //sce.SaveChanges();

        sce.AdjustmentVouchers.Add(adjust);
        sce.SaveChanges();


    }
    public string[] listDeliverCollectionPoint()
    {

        string[] cols = StoreDepartmentDAO.listDeliverCollectionPoint().ToArray<string>();
        return cols;
    }
    public List<Disbursement> findDeliverDisburseByCollectionPoint(string colpoint)
    {
        List<Disbursement> dlist = new List<Disbursement>();
        dlist = StoreDepartmentDAO.findDeliverDisburseByCollectionPoint(colpoint);
        return dlist;
    }
    public List<DisbursementItem> findDeliverDisburseItemByDisburseid(int id)
    {
        List<DisbursementItem> items = new List<DisbursementItem>();
        items = StoreDepartmentDAO.findDeliverDisburseItemByDisburseid(id);
        return items;
    }
    public void UpdateDisbursementItem(List<DisbursementItem> items)
    {
        StoreDepartmentDAO.UpdateDisbursementItem(items);
    }
    public DisbursementItem findDisbursementByDisburseAndItem(int disid, string itmid)
    {
        DisbursementItem item = new DisbursementItem();
        item = StoreDepartmentDAO.findDisbursementByDisburseAndItem(disid, itmid);
        return item;
    }
    public Item findItemByItemcode(string id)
    {
        Item it = new Item();
        it = StoreDepartmentDAO.findItemByItemcode(id);
        return it;
    }
    public double findPriceBySupplierAndItem(string suppliercode, string itemcode)
    {
        double price = StoreDepartmentDAO.findPriceBySupplierAndItem(suppliercode, itemcode);
        return price;
    }
    public void createAdjustmentVoucher(AdjustmentVoucher item)
    {
        StoreDepartmentDAO.createAdjustmentVoucher(item);

    }


}