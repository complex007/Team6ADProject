<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DErequestItem.aspx.cs" Inherits="DErequestItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Item Category :
        <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; position: absolute; top: 0px; left: 157px; width: 148px; height: 25px" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="category" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT DISTINCT [category] FROM [Item]"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Items&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:DropDownList ID="DropDownList7" runat="server" style="z-index: 1; position: absolute; top: 54px; left: 158px; width: 143px; height: 26px" AutoPostBack="True">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 80px; left: 370px" Text="Add To Cart" OnClick="Button1_Click" AutoPostBack="true" />
    </p>
    <p>
         <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" style="z-index: 1; position: absolute; top: 349px; left: 396px; width: 66px; height: 26px;" Text="Submit" />
   
   
   <table style="width: 536px; margin-right: 9px;">
  <tr>
    <th class="modal-sm" style="width: 182px; height: 20px;"></th>
    <th style="width: 133px; height: 20px;"></th>
    <th style="width: 130px; height: 20px;"></th>
    <th style="width: 51px; height: 20px;"></th>
    <th style="width: 51px; height: 20px;">&nbsp;</th>
  </tr>
  <tr>
    <td class="modal-sm" style="width: 182px">
         <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
      </td>
    <td style="width: 133px">
         <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
      </td>
    <td style="width: 130px">
         <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
      </td>
    <td style="width: 51px">
         <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
      </td>
    <td style="width: 51px">
         <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
      </td>
  </tr>
  
</table>
     </p>
     <p>
         <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
     <p>
         &nbsp;</p>
   
   
     <p>
         &nbsp;</p>
    <p>
   
   

       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
         
</asp:Content>