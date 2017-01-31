<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCreceiveOrderfromSupplier.aspx.cs" Inherits="SCreceiveOrderfromSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Receive Order from Supplier</h1></center>
    <asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 80px; left: 176px" Text="Supplier"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 1; position: absolute; top: 79px; left: 270px" DataSourceID="SqlDataSource1" DataTextField="suppliercode" DataValueField="suppliercode" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString2 %>" SelectCommand="SELECT [suppliercode] FROM [Supplier]"></asp:SqlDataSource>
    <asp:Label ID="Label3" runat="server" style="z-index: 1; position: absolute; top: 174px; left: 335px" Text="Label"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Key in Delivery Order Number" ForeColor="Red" style="z-index: 1; position: absolute; top: 134px; left: 446px" ValidationGroup="vg"></asp:RequiredFieldValidator>
    <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; position: absolute; top: 132px; left: 268px" ValidationGroup="vg"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" style="z-index: 1; position: absolute; top: 134px; left: 176px" Text="DeliveryNO"></asp:Label>
<%--    <table style="width: 21%; z-index: 1; height: 60px; position: absolute; top: 118px; left: 170px;">
        <tr>
            <td style="width: 140px">&nbsp;<label>Delivery Order No</label></td>
            <td>&nbsp;<label id="delivery"></label></td>
        
        </tr>
        <tr>
            <td style="width: 140px">&nbsp;<label>Reference no</label></td>
            <td>&nbsp;<label id="ref"></label></td>
          
        </tr>
       
    </table>--%>
<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 882px; height: 247px; position: absolute; top: 186px; left: 52px" AutoGenerateColumns="false">
    <Columns>
          <asp:BoundField HeaderText="Purchaseid" DataField="purchaseid"/>
        <asp:BoundField HeaderText="ItemCode" DataField="ItemCode"/>
        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription"/>
        <asp:BoundField HeaderText="Quantity" DataField="Quantity"/>
   
         <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                        <asp:TextBox ID="TextRemarks" runat="server" CssClass="txtBoxNormalmedium" Text=''></asp:TextBox>
            </ItemTemplate>

        </asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 132px; left: 714px; height: 22px;" Text="Submit" OnClick="Button1_Click" ValidationGroup="vg" />
</asp:Content>

