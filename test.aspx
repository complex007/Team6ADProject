﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="employeecode" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="employeecode" HeaderText="Employee Code" />
                <asp:BoundField DataField="employeename" HeaderText="Employee Name" />
                <asp:BoundField DataField="employeeemail" HeaderText="Email" />
                <asp:BoundField DataField="deptcode" HeaderText="Department" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:ButtonField CommandName="Add" HeaderText="Add" ShowHeader="True" Text="Add" />
            </Columns>
        </asp:GridView>
    
    </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
