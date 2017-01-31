<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateSupplierInformation.aspx.cs" Inherits="SCupdateSupplierInformation" EnableEventValidation = "false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Update Supplier Information</h1></center>


    <asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 796px; height: 188px; position: absolute; top: 123px; left: 144px; right: 383px;"
        AutoGenerateColumns="False" DataKeyNames="suppliercode" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand" AutoPostBack="true">
         <Columns>
            <asp:BoundField DataField="suppliercode" HeaderText="SupplierCode"  SortExpression="suppliercode" />
            <asp:BoundField DataField="suppliername" HeaderText="SupplierNamee" SortExpression="suppliernamee" />
            <asp:BoundField DataField="contactname" HeaderText="ContactName" SortExpression="contactname" />
            <asp:BoundField DataField="phonenumber" HeaderText="PhoneNumber" SortExpression="phonenumber" />
            <asp:BoundField DataField="faxnumber" HeaderText="FaxNumber" SortExpression="faxnumber" />
            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
            <asp:BoundField DataField="gstregistrationno" HeaderText="GstRegistrationNo" SortExpression="gstregistrationno" />

        </Columns>
    </asp:GridView>


    <asp:Button ID="Delete" runat="server" style="z-index: 1; position: absolute; top: 546px; left: 316px; height: 26px;" Text="Delete" OnClick="Delete_Click" />
    <asp:Button ID="Modify" runat="server" style="z-index: 1; position: absolute; top: 546px; left: 492px; width: 61px;" Text="Modify" OnClick="Modify_Click" />
    <asp:Button ID="Create" runat="server" style="z-index: 1; position: absolute; top: 546px; left: 631px; height: 23px;" Text="Create" OnClick="Create_Click" />
    
    
    
    <table style="width: 60%; z-index: 1; height: 246px; position: absolute; top: 598px; left: 161px; margin-top: 0px;">
        <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Supplier Code</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>         
        </tr>
         <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Supplier Name</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Contact Name</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Phone Number</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Fax Number</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>Address</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>         
        </tr>
           <tr>
            <td style="width: 381px" class="modal-sm">&nbsp;<label>GST Registration No</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>         
        </tr>
    </table>



<asp:Button ID="Cancel" runat="server" style="z-index: 1; position: absolute; top: 935px; left: 378px" Text="Cancel" OnClick="Cancel_Click" />
<asp:Button ID="Save" runat="server" style="z-index: 1; position: absolute; top: 935px; left: 553px" Text="Save" OnClick="Save_Click" />




</asp:Content>

