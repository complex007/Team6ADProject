<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateCatalog.aspx.cs" Inherits="SCupdateCatalog" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Update Catalog</h1></center>
    

    <asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 787px; height: 283px; position: absolute; top: 116px; left: 175px" 
         AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="itemcode" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="itemcode" HeaderText="ItemCode" ReadOnly="True" SortExpression="itemcode" />
            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
            <asp:BoundField DataField="itemdescription" HeaderText="ItemDescription" SortExpression="itemdescription" />
            <asp:BoundField DataField="reorderlevel" HeaderText="ReorderLevel" SortExpression="reorderlevel" />
            <asp:BoundField DataField="reorderquantity" HeaderText="ReorderQuantity" SortExpression="reorderquantity" />
            <asp:BoundField DataField="unitofmeasure" HeaderText="UnitOfMeasure" SortExpression="unitofmeasure" />
        </Columns>
    </asp:GridView>



    <asp:Button ID="Submit" runat="server" style="z-index: 1; position: absolute; top: 1041px; left: 498px; margin-top: 0;" Text="Submit" OnClick="Submit_Click" />
    <asp:Button ID="Delete" runat="server" style="z-index: 1; position: absolute; top: 529px; left: 395px; margin-top: 0;" Text="Delete" OnClick="Delete_Click" />
    <asp:Button ID="Modify" runat="server" style="z-index: 1; position: absolute; top: 527px; left: 588px" Text="Modify" OnClick="Modify_Click" />
    


    <table style="width: 57%; z-index: 1; height: 334px; position: absolute; top: 612px; left: 180px;">
        <tr>
            <td style="height: 47px; width: 138px;">&nbsp;<label>Item Code</label></td>
            <td style="height: 47px">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="183px"></asp:TextBox></td>
            
        </tr>
       <tr>
            <td style="width: 138px; height: 47px;">&nbsp;<label>Category</label></td>
            <td style="height: 47px">
                <asp:TextBox ID="TextBox6" runat="server" Width="243px" style="margin-left: 26" ></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td style="width: 138px; height: 48px;">&nbsp;<label>Description</label></td>
            <td style="height: 48px">&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="636px" Height="27px" style="margin-left: 11"></asp:TextBox></td>           
        </tr>
        <tr>
            <td style="width: 138px; height: 48px;">&nbsp;<label>Record Level</label></td>
            <td style="height: 48px">&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>           
        </tr>
           <tr>
            <td style="width: 138px; height: 48px;">&nbsp;<label>Record Quantity</label></td>
            <td style="height: 48px">&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>           
        </tr>
         <tr>
            <td style="width: 138px; height: 48px;">&nbsp;<label>Unit of Measure</label></td>
            <td style="height: 48px">
                <asp:TextBox ID="TextBox7" runat="server" Width="242px" ></asp:TextBox>
             </td>        
        </tr>
          <tr>
            <td style="width: 138px; height: 48px;">&nbsp;<label>Bin Number</label></td>
            <td style="height: 48px">&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>           
        </tr>
    </table>
    <asp:Button ID="Create" runat="server" OnClick="Create_Click" style="z-index: 1; position: absolute; top: 527px; left: 765px" Text="Create" />
</asp:Content>

