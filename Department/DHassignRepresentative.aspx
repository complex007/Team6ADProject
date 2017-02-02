<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHassignRepresentative.aspx.cs" Inherits="DHassignRepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center><h1 style="color:darkblue;font-weight:bold;">Assign Representative</h1></center>
    <asp:Label ID="Label2" CssClass="labels" runat="server" style="z-index: 1; position: relative;" Text="Current Representative: "></asp:Label>&nbsp;<asp:Label ID="Label1" CssClass="labels" runat="server" Text=""> </asp:Label>
   &nbsp;
    <br />
    <br />
   <asp:Label ID="Label4" CssClass="labels" runat="server" style="z-index: 1; position: relative;" Text="Select Representative: "></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Height="25px" Width="100px"></asp:DropDownList>

  
  

  
    <br />
    <br />
    <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Assign" OnClick="Button1_Click"  />
    <br />
    <br />



  
</asp:Content>

