<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DRrequestItem.aspx.cs" Inherits="DRrequestItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Item Category :
        <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; position: absolute; top: 0px; left: 157px; width: 148px; height: 25px">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Items&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:DropDownList ID="DropDownList7" runat="server" style="z-index: 1; position: absolute; top: 54px; left: 158px; width: 143px; height: 26px">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 108px; left: 233px" Text="Add To Cart" />
    </p>
    <p>
        &nbsp;</p>
     <p>
         &nbsp;</p>
     <p>
         &nbsp;</p>
   
   
   <table style="width: 536px">
  <tr>
    <th class="modal-sm" style="width: 182px">Item</th>
    <th style="width: 130px">Quantity</th>
    <th style="width: 51px"></th>
  </tr>
  <tr>
    <td class="modal-sm" style="width: 182px"></td>
    <td style="width: 130px"><input type="text"style="width: 62px" /></td>
    <td style="width: 51px"><input type="button" style="width: 62px" value ="Remove"/></td>
  </tr>
  
</table>
     <p>
         &nbsp;</p>
    <p>
   
   

       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<input type="button" style="width: 62px" value ="Submit"/></asp:Content>

