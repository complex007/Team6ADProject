<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCupdateTenderInformation.aspx.cs" Inherits="SCupdateTenderInformation" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Update Tender Information
        
         
        </h1></center>
    <table style="width: 51%; z-index: 1; height: 64px; position: absolute; top: 96px; left: 78px; margin-top: 0px;">
        <tr>
            <td><label>Name of Supplier</label></td>
            
            <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
          
        </tr>
        <tr>
            <td><label>Address of Supplier</label></td>
            <td><asp:Label ID="Label" runat="server" Text="Label"></asp:Label></td>      
        </tr>
       
    </table>

<asp:GridView ID="GridView1" runat="server" style="z-index: 1; width: 578px; height: 255px; position: absolute; top: 211px; left: 87px" AutoGenerateColumns="False"
    OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="itemdesc" HeaderText="ItemDescription" SortExpression="itemdesc" ControlStyle-BorderWidth="350px" />
        <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" ControlStyle-BorderWidth="353px" />
    </Columns>
</asp:GridView>




    <table style="width: 41%; z-index: 1; height: 166px; position: absolute; top: 506px; left: 780px;">
       <tr>
            <td style="width: 256px">
               <asp:Label ID="Label3" runat="server" style="z-index: 1;  top: 114px; left: 128px; width: 22px;" Text="ItemCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; position: absolute; top: 19px; left: 266px; width: 241px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td style="width: 256px">
                <asp:Label ID="Label1" runat="server" style="z-index: 1;  top: 40px; left: 94px" Text="ItemDescription"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; position: absolute; top: 73px; left: 265px; width: 239px"></asp:TextBox>
            </td>
           
        </tr>
        <tr>
            <td style="width: 256px">
               <asp:Label ID="Label2" runat="server" style="z-index: 1;  top: 114px; left: 128px; width: 22px;" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; position: absolute; top: 128px; left: 264px; width: 241px; margin-top: 0;"></asp:TextBox>
            </td>
           
        </tr>
    </table>
    <asp:Button ID="Save" runat="server" style="z-index: 1; position: absolute; top: 782px; left: 1054px" Text="Save" OnClick="Save_Click" />
</asp:Content>

