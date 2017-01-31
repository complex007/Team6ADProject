<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCretrieveStockCard.aspx.cs" Inherits="SCretrieveStockCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center><h1>Retrieve Stock Card</h1></center>
    <br />
    <br />
    <table style="width: 66%; z-index: 1; height: 280px; position: absolute; top: 151px; left: 132px; margin-bottom: 54px;">
        <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>Item Description </label></td>
            <td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
            
        </tr>
        <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>Bin# </label></td>
            <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
            
        </tr>
        <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>UOM </label></td>
            <td>&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>1st Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>2nd Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
           
        </tr>
         <tr>
            <td class="modal-sm" style="width: 119px">&nbsp;<label>3rd Supplier </label></td>
            <td>&nbsp;<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
           
        </tr>
    </table>
    <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; position: absolute; top: 84px; left: 260px; width: 251px; height: 45px; " OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="itemcode" DataValueField="itemcode" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [itemcode] FROM [Item]"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" style="z-index: 1; position: absolute; top: 86px; left: 133px; width: 84px" Text="Item Code "></asp:Label>
<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 921px; height: 127px; position: absolute; top: 460px; left: 130px">
</asp:GridView>
</asp:Content>

