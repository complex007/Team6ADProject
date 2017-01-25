<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHassignRepresentative.aspx.cs" Inherits="DHassignRepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    Current Representative :&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text=""> </asp:Label>
   &nbsp;
    <br />
    <br />
   Select Representative :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True"></asp:DropDownList>

  
  

  
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1"  />
    <br />
    <br />



  
</asp:Content>

