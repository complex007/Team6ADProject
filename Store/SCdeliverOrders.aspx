<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCdeliverOrders.aspx.cs" Inherits="SCDeliverOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>
        
        Deliver Order</h1></center>
<asp:DropDownList ID="DropDownList3" runat="server" style="z-index: 1; position: absolute; top: 61px; left: 239px" DataSourceID="SqlDataSource2" DataTextField="collectionpoint" DataValueField="collectionpoint" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
</asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString2 %>" SelectCommand="SELECT [collectionpoint] FROM [Department]"></asp:SqlDataSource>
    <asp:Label ID="Label3" runat="server" style="z-index: 1; position: absolute; top: 166px; left: 424px" Text="Label"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [collectionpoint] FROM [Department]"></asp:SqlDataSource>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" style="z-index: 1; width: 265px; height: 21px; position: absolute; top: 114px; left: 234px; margin-top: 0px">
    </asp:RadioButtonList>
<asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 61px; left: 90px; width: 124px" Text="Collection Point"></asp:Label>
<asp:Label ID="Label2" runat="server" style="z-index: 1; position: absolute; top: 112px; left: 91px; width: 124px" Text="Department"></asp:Label>
<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 737px; height: 127px; position: absolute; top: 242px; left: 90px" AutoGenerateColumns="false"
    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="OnRowDataBound">

    <Columns>
        <asp:BoundField HeaderText="Itemcode" DataField="Itemcode" />
        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
        <asp:BoundField HeaderText="AllocatedQuantity" DataField="AllocatedQuantity" />
            <asp:TemplateField HeaderText="ActualQuantity">
                <ItemTemplate>

                    <asp:TextBox ID="Textfrom" runat="server" CssClass="txtBoxNormalmedium" Text='<%# Bind("allocatedquantity") %>'></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>
         <asp:BoundField HeaderText="disbursementid" DataField="disbursementid" />
        <asp:TemplateField HeaderText="Adjustment Suppliers">
  <ItemTemplate>
    <asp:DropDownList runat="server" ID="MyDD" AutoPostBack="true" />
  </ItemTemplate> 
</asp:TemplateField>
            </Columns>

</asp:GridView>
<asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 245px; left: 840px" Text="Approve" OnClick="Button1_Click" />
</asp:Content>

