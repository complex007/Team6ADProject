<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHdeligateAuthority.aspx.cs" Inherits="DHdeligateAuthority" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    
    
    <table style="width: 771px; margin-right: 9px;">
  <tr>
    <td style="height: 20px;" colspan="2">
         <asp:CompareValidator id="cvtxtStartDate" runat="server" 
     ControlToCompare="TextBox1" cultureinvariantvalues="true" 
     display="Dynamic" EnableClientScript ="false"  
     ControlToValidate="TextBox2" 
     ErrorMessage="Start date must be earlier than end date"
     type="Date" setfocusonerror="true" Operator="GreaterThanEqual" 
     text="Start date must be earlier than finish date" ForeColor="Red"></asp:CompareValidator></td>
    <td style="width: 160px; height: 20px;">&nbsp;</td>
    <td style="width: 67px; height: 20px;">&nbsp;</td>
    <td style="width: 51px; height: 20px;">&nbsp;</td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
    ControlToValidate="TextBox1" ErrorMessage="Date is required"
    ForeColor="Red" EnableClientScript ="false" validationgroup="datevalidate">Date is required</asp:RequiredFieldValidator>
      </td>
    <td style="width: 342px; height: 20px;">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
    ControlToValidate="TextBox2" ErrorMessage="Date is required"
    ForeColor="Red" EnableClientScript ="false" validationgroup="datevalidate">Date is required</asp:RequiredFieldValidator>
      </td>
    <td style="width: 160px; height: 20px;"></td>
    <td style="width: 67px; height: 20px;"></td>
    <td style="width: 51px; height: 20px;">&nbsp;</td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;"><asp:Label ID="Label2" runat="server"  Text="From :"></asp:Label> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" style="width: 34px; height: 22px;" ImageUrl="~/Images/calendar-128.png" OnClick="ImageButton1_Click" /></td>
    <td style="width: 342px; height: 20px;"><asp:Label ID="Label4" runat="server" Text="To :"></asp:Label>

   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
 

    <asp:ImageButton ID="ImageButton3" runat="server" style="width: 31px; height: 24px;" ImageUrl="~/Images/calendar-128.png" OnClick="ImageButton3_Click" />
      </td>
    <td style="width: 160px; height: 20px;"><asp:Label ID="Label3" runat="server" Text="Select Employee :"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" style=" width: 97px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList></td>
    <td style="width: 67px; height: 20px;"><asp:Button ID="Button1" runat="server" validationgroup="datevalidate"
 Text="Submit" causesvalidation="true" OnClick="Button1_Click" />
      </td>
    <td style="width: 51px; height: 20px;"></td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;"></asp:Label><asp:Calendar ID="Calendar1" runat="server" style="width: 223px; height: 162px;" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar></td>
 
    <td style="width: 342px; height: 20px;"><asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged" style="width: 223px; height: 162px;"></asp:Calendar></td>
    <td style="width: 160px; height: 20px;"></td>
    <td style="width: 67px; height: 20px;"></td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;">&nbsp;</td>
    <td style="width: 342px; height: 20px;">&nbsp;</td>
    <td style="width: 160px; height: 20px;">&nbsp;</td>
    <td style="width: 67px; height: 20px;">&nbsp;</td>
    <td style="width: 51px; height: 20px;">&nbsp;</td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;"></td>
    <td style="width: 342px; height: 20px;"></td>
    <td style="width: 160px; height: 20px;"></td>
    <td style="width: 67px; height: 20px;"></td>
    <td style="width: 51px; height: 20px;"></td>
  </tr>
  <tr>
    <td style="width: 349px; height: 20px;">&nbsp;</td>
    <td style="width: 342px; height: 20px;">&nbsp;</td>
    <td style="width: 160px; height: 20px;">&nbsp;</td>
    <td style="width: 67px; height: 20px;">&nbsp;</td>
    <td style="width: 51px; height: 20px;">&nbsp;</td>
  </tr>
  <tr>
    <td  style="width: 349px; height: 20px;">&nbsp;</td>
    <td style="width: 342px; height: 20px;">&nbsp;</td>
    <td style="width: 160px; height: 20px;">&nbsp;</td>
    <td style="width: 67px; height: 20px;">&nbsp;</td>
    <td style="width: 51px; height: 20px;">&nbsp;</td>
  </tr>
  <tr>
    
    
    
   
    
    
    <br />
    <br />
    <br />
    </asp:Content>

