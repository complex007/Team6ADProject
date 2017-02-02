using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for DEserviceManager
/// </summary>

public class DEserviceManager
{
    public DEserviceManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Item> PopulateCatDropDownList(string category)
    {
        return DepartmentDAO.PopulateCatDropDownList(category);
    }

    public string getUnit(string itemcode)
    {
        return DepartmentDAO.getUnit(itemcode);
    }

    public void submitRequisitionItemList(List<String> qty, List<String> itemcode, int empcode)
    {
        DepartmentDAO.submitRequisitionItemList(qty, itemcode, empcode);
    }

    public List<dynamic> retreiveRequistionsItems(int empcode)
    {
        return DepartmentDAO.retreiveRequistionsItems(empcode);
    }

    public void updateRequistionsItems(string itemcode, string qty, string reqid, string orgqty)
    {
        DepartmentDAO.updateRequistionsItems(itemcode, qty, reqid, orgqty);
    }

    public void deleteRequistionsItems(string itemcode, string qty, string reqid, int empcode)
    {
        DepartmentDAO.deleteRequistionsItems(itemcode, qty, reqid, empcode);
    }
    public static void sendEmail(string message)
    {
        SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
        MailMessage mail = new MailMessage();
        // string reason = TextBox1.Text;
        try
        {
            mail.Body = message;

            //Setting From , To and CC
            mail.From = new MailAddress("zhuliana@gmail.com");
            mail.To.Add(new MailAddress("zhuliana@gmail.com"));

            smtpClient.Send(mail);
        }
        catch (SmtpException se)
        {
            System.Diagnostics.Debug.WriteLine(se.Message);
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }

    }
}
