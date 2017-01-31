<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCselectStockSupplier.aspx.cs" Inherits="SCselectStockSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Select Stock Card</h1></center>
    <table style="width: 41%; z-index: 1; height: 60px; position: absolute; top: 141px; left: 201px;">
        <tr>
            <td>&nbsp;<label>Item Code</label></td>      
            <td>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>         
        </tr>
         <tr>
            <td>&nbsp;<label>Supplier 1</label></td>      
            <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>         
        </tr>
         <tr>
            <td>&nbsp;<label>Supplier 2</label></td>      
            <td>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>         
        </tr>
         <tr>
            <td>&nbsp;<label>Supplier 3</label></td>      
            <td>&nbsp;<asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
             </td>         
        </tr>
      
    </table>
    <asp:Button ID="Update" runat="server" style="z-index: 1; position: absolute; top: 257px; left: 469px" Text="Update" OnClick="Update_Click" />
</asp:Content>

