<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCdeliverOrders.aspx.cs" Inherits="SCDeliverOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">
        
        Deliver Order</h1></center>
    <asp:DropDownList ID="DropDownList3" runat="server" Style="z-index: 1; position: absolute; top: 94px; left: 309px" DataSourceID="SqlDataSource2" DataTextField="collectionpoint" DataValueField="collectionpoint" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT [collectionpoint] FROM [Department] WHERE ([collectionpoint] IS NOT NULL)"></asp:SqlDataSource>
    <asp:Label ID="Label3" runat="server" Style="z-index: 1; position: absolute; top: 195px; left: 333px; width: 280px;" Text="Label" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="#333399"></asp:Label>
    <asp:RadioButtonList CssClass="labels" ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Style="z-index: 1; width: 265px; height: 21px; position: absolute; top: 154px; left: 304px; margin-top: 0px">
    </asp:RadioButtonList>
    <asp:Label CssClass="labels" ID="Label1" runat="server" Style="z-index: 1; position: absolute; top: 91px; left: 90px; width: 173px" Text="Collection Point"></asp:Label>
    <asp:Label CssClass="labels" ID="Label2" runat="server" Style="z-index: 1; position: absolute; top: 152px; left: 92px; width: 124px" Text="Department"></asp:Label>
    <table style="position: absolute; top: 255px; left: 90px">
        <tr>
            <td>
                <asp:GridView ID="GridView1" CssClass="grid" runat="server" Style="z-index: 1; width: 737px; height: 151px; position: relative;" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="OnRowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">

                    <AlternatingRowStyle BackColor="#CCCCCC" />

                    <Columns>
                        <asp:BoundField HeaderText="Itemcode" DataField="Itemcode" />
                        <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
                        <asp:BoundField HeaderText="AllocatedQuantity" DataField="AllocatedQuantity" />
                        <asp:TemplateField HeaderText="ActualQuantity">
                            <ItemTemplate>

                                <asp:TextBox ID="Textfrom" runat="server" Style="width: 60px" CssClass="txtBoxNormalmedium" Text='<%# Bind("allocatedquantity") %>'></asp:TextBox>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField HeaderText="disbursementid" DataField="disbursementid" />
                        <asp:TemplateField HeaderText="Adjustment Suppliers">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="MyDD" Style="width: 80px" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td> </td>
        </tr>
        <tr>
            <td align="right">
                <br />
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Style="z-index: 1; position: relative;" Text="Approve" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

