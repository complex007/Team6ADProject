<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCreportStockDiscrepancy.aspx.cs" Inherits="SCreportStockDiscrepancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Report Stock Discrepancy</h1></center>
    
    <table style="width: 50%; z-index: 1; height: 247px; position: absolute; top: 409px; left: 287px;">
         <tr>
            <td style="width: 182px">&nbsp;<label>Supplier Code</label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">&nbsp;<label>Item Code</label></td>
            <td>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Calendar ID="Calendar1" runat="server" style="z-index: 1; width: 223px; height: 162px; position: absolute; top: -204px; left: 186px" OnSelectionChanged="DateSelectedChanged"></asp:Calendar>
            </td>
       
        </tr>
        <tr>
            <td style="width: 182px">&nbsp;<label>Item Category</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="23px" ReadOnly="True" Width="218px"></asp:TextBox></td>
        </tr>
       <tr>
            <td style="width: 182px">&nbsp;<label>Item Description</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="287px"></asp:TextBox>
                <asp:Label ID="Date" runat="server" style="z-index: 1; position: absolute; top: -206px; left: 2px; width: 96px; height: 18px" Text="Date issued :"></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width: 182px">&nbsp;<label>quantity</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" Width="215px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width: 182px">&nbsp;<label>Adjust</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="214px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width: 182px">&nbsp;<label>Reason</label></td>
            <td>&nbsp;<asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>
      
    
    <asp:Button ID="Add" runat="server" style="z-index: 1; position: absolute; top: 711px; left: 451px; width: 65px; height: 26px;" Text="Add" OnClick="Add_Click" />
      <asp:Button ID="Report" runat="server" style="z-index: 1; position: absolute; top: 712px; left: 675px; height: 25px;" Text="Report" OnClick="Report_Click" />
    <asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 187px; height: 127px; position: absolute; top: 802px; left: 468px" AutoGenerateColumns="False" >
        <Columns>
           <asp:BoundField DataField = "itemcode" HeaderText = "itemcode" SortExpression="itemcode" />
           <asp:BoundField DataField = "quantity" HeaderText = "quantity" SortExpression="quantity" />
           <asp:BoundField DataField = "reason" HeaderText = "reason" SortExpression="reason" />
     
       </Columns>
    </asp:GridView>
   
</asp:Content>


