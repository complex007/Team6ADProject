<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCsendOrdertoSupplier.aspx.cs" Inherits="SCsendOrdertoSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>
       Send Order to Supplier</h1></center>
     <asp:Button ID="Button3" runat="server" style="z-index: 1; position: absolute; top: 323px; left: 271px" Text="Add Item" OnClick="Button3_Click" ValidationGroup="vg" />
     <asp:RadioButton ID="RadioButton1" GroupName="GROUP1" Checked="true" runat="server" style="z-index: 1; position: absolute; top: 154px; left: 269px" /><asp:Label ID="Label4" runat="server" style="z-index: 1; position: absolute; top: 159px; left: 348px; right: 368px;" Text="Label"></asp:Label>
        <asp:RadioButton ID="RadioButton2" GroupName="GROUP1" runat="server" style="z-index: 1; position: absolute; top: 186px; left: 269px" /><asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 191px; left: 347px; right: 305px;" Text="Label"></asp:Label>
        <asp:RadioButton ID="RadioButton3" GroupName="GROUP1" runat="server" style="z-index: 1; position: absolute; top: 218px; left: 268px" /><asp:Label ID="Label5" runat="server" style="z-index: 1; position: absolute; top: 219px; left: 347px; right: 312px;" Text="Label"></asp:Label>

    <asp:Label ID="Label2" runat="server" style="z-index: 1; position: absolute; top: 103px; left: 160px" Text="Item Code"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [suppliernamee], [suppliercode] FROM [Supplier]"></asp:SqlDataSource>
<asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 1; position: absolute; top: 103px; left: 272px" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="itemdescription" DataValueField="itemcode" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
</asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString2 %>" SelectCommand="SELECT [itemcode], [itemdescription] FROM [Item]"></asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Quantity in the Text Box" style="z-index: 1; position: absolute; top: 272px; left: 345px" ValidationGroup="vg">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TextBox1"  ErrorMessage="Please Enter Only Numbers" style="z-index: 1; position: absolute; top: 272px; left: 369px" ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [itemcode] FROM [Item]"></asp:SqlDataSource>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="z-index: 1; position: absolute; top: 315px; left: 828px" Text="Delete" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="z-index: 1; width: 371px; height: 53px; position: absolute; top: 268px; left: 427px" ValidationGroup="vg" />
    <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" ControlToValidate="TextBox1" ErrorMessage="Range~Min-0 Max-400" MinimumValue="0" MaximumValue="400" style="z-index: 1; position: absolute; top: 272px; left: 358px; height: 23px;" ForeColor="Red" ValidationGroup="vg">*</asp:RangeValidator>
    <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; position: absolute; top: 269px; left: 268px"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" style="z-index: 1; position: absolute; top: 270px; left: 160px" Text="Quantity"></asp:Label>
<asp:Label ID="Label3" runat="server" style="z-index: 1; position: absolute; top: 152px; left: 160px" Text="Supplier"></asp:Label>
    

<%--<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 734px; height: 127px; position: absolute; top: 386px; left: 161px"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
    <Columns> 
        <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>
       <asp:BoundField HeaderText="Item Number" DataField="item.itemcode" />
        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
        <asp:BoundField HeaderText="AllocatedQuantity" DataField="AllocatedQuantity" />
    </Columns>
</asp:GridView>--%>

<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 734px; height: 127px; position: absolute; top: 386px; left: 161px"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="false">
    <Columns>
        <%--<asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:BoundField HeaderText="S.NO" DataField="S.no" />
             <asp:BoundField HeaderText="Item Number" DataField="Item Number" />
        <asp:BoundField HeaderText="Description" DataField="Description" />
        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
          <asp:BoundField HeaderText="Price" DataField="Price" />
        <asp:BoundField HeaderText="Amount" DataField="Amount" />
              <asp:BoundField HeaderText="Supplier" DataField="Supplier" />
<asp:TemplateField HeaderText="Select">
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />
</ItemTemplate>
</asp:TemplateField>
    
    
    </Columns>
     </asp:GridView>
<asp:Button ID="Button2" runat="server" style="z-index: 1;  position:  absolute; top: 313px; left: 917px; height: 26px;" Text="Submit" OnClick="Button2_Click" />
    
    
        
   

        
</asp:Content>

