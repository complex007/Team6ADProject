<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="SSissueStockAdjVocher.aspx.cs" Inherits="SSissueStockAdjVocher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h3>StockAdjustVoucherForm</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="vouchernumber" Width="867px">
            <Columns>
                <asp:BoundField DataField="vouchernumber" HeaderText="Voucher Number" ReadOnly="true" SortExpression="vouchernumber" />
                <asp:BoundField DataField="Issuedate" HeaderText="IssueDate" ReadOnly="true" SortExpression="vouchernumber" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="employee.employeename" HeaderText="ClerkName" ReadOnly="true" SortExpression="clerkname"  />
                 <asp:BoundField DataField="cost" HeaderText="Cost" ReadOnly="true" SortExpression="cost"  />
                     <asp:TemplateField>
                    <ItemTemplate>
                         <a href='SSissueStockAdjVocher.aspx?id=<%# Eval("vouchernumber") %>&action=Details'>Details</a>
                    </ItemTemplate>
                       </asp:TemplateField>
                   <asp:TemplateField>
                    <ItemTemplate>
                         <a href='SSissueStockAdjVocher.aspx?id=<%# Eval("vouchernumber") %>&action=Approve'>Approve</a>
                    </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField>
                       <ItemTemplate>
                         <a href='SSissueStockAdjVocher.aspx?id=<%# Eval("vouchernumber") %>&action=Reject'>Reject</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <table style="width: 864px; height: 188px">
        <tr>
            <td class="modal-lg" style="width: 1267px; height: 32px;">
                 <asp:Label ID="Label1" runat="server" ></asp:Label>
            </td>
           <td style="width: 684px; height: 32px;"><asp:LinkButton runat="server" ID="approveall"><a href='SSissueStockAdjVocher.aspx?action=ApproveAll'>Approve All</a> </asp:LinkButton></td>
             <td style="height: 32px">
                <asp:LinkButton runat="server" ID="rejectall"><a href='SSissueStockAdjVocher.aspx?action=RejectAll'>Reject All</a></asp:LinkButton>                  
             </td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1267px"></td>
             <td style="width: 684px"></td>
             <td> <asp:Label ID="Label3" runat="server" Text="Reject Reason : "></asp:Label></td>
        </tr>
        <tr>
            <td class="modal-lg" style="width: 1267px"></td>
             <td style="width: 684px">
                
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="70px" Width="271px" style="margin-top: 29"></asp:TextBox>
              

            </td>
            <td>
                  
       
        

            </td>
        </tr>
    </table>
   
    
     </p>
     <p>
         <asp:GridView ID="GridView2" runat="server">
         </asp:GridView>
     </p>

     <br />
     <br />
     </asp:Content>
