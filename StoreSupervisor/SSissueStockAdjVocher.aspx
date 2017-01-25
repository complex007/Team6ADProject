<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="SSissueStockAdjVocher.aspx.cs" Inherits="SS.SSissueStockAdjVocher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>StockAdjustVoucherForm</h3>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="vouchernumber" Width="867px"  OnRowCommand="GridView2_RowCommand">
            <Columns>
                <asp:BoundField DataField="vouchernumber" HeaderText="Voucher Number" ReadOnly="true" SortExpression="vouchernumber" />
                <asp:BoundField DataField="Issuedate" HeaderText="IssueDate" ReadOnly="true" SortExpression="vouchernumber" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="employee.employeename" HeaderText="ClerkName" ReadOnly="true" SortExpression="clerkname" />
                <asp:BoundField DataField="cost" HeaderText="Cost" ReadOnly="true" SortExpression="cost" />
                 <asp:ButtonField CommandName="Details" HeaderText="Details" ShowHeader="True" Text="Details" />
                <asp:ButtonField CommandName="Approve" HeaderText="Approve" ShowHeader="True" Text="Approve" />
                <asp:ButtonField CommandName="Reject" HeaderText="Reject" ShowHeader="True" Text="Reject" />
              
            </Columns>
        </asp:GridView>
  <table style="width: 917px; height: 188px">
            <tr>
                <td class="modal-lg" style="width: 1707px; height: 30px;">
                    <asp:Label ID="Label1" runat="server" Style="z-index: 1; position: relative"></asp:Label>
                </td>
                <td style="width: 684px; height: 30px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Approve All</asp:LinkButton>
                </td>
                <td style="width: 124px; height: 30px;">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Reject All</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 1707px; height: 26px;">
                    &nbsp;</td>
                <td style="width: 684px; height: 26px;">&nbsp;</td>

                <td style="width: 124px; height: 26px;">

                    <asp:Label ID="Label2" runat="server" Text="Reject Reason : "></asp:Label></td>
            </tr>
            <tr>
                <td class="modal-lg" style="width: 1707px">


    
                </td>
                <td style="width: 684px"></td>
                <td style="width: 124px">
                    <asp:TextBox ID="TextBox1" runat="server" Height="70px" Width="271px" Style="margin-top: 29" ></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>


    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>

    <br />
    <br />
     </asp:Content>
