<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DRsetCollectionPoint.aspx.cs" Inherits="setcollectionpointrep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" style="z-index: 1; width: 116px; height: 20px; position: absolute; top: 91px; left: 40px" >
        <asp:ListItem>UHC</asp:ListItem>
        <asp:ListItem>UTown</asp:ListItem>
        <asp:ListItem>Museum</asp:ListItem>
        <asp:ListItem>Biz</asp:ListItem>
        <asp:ListItem>Deck</asp:ListItem>
        <asp:ListItem>Kent Ridge</asp:ListItem>
    </asp:RadioButtonList>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; position: absolute; top: 0px; left: 241px; width: 166px"  readonly="true">Kent Ridge</asp:TextBox>
&nbsp;<br />
    <br />
<br />
    <asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 2px; left: 20px; width: 163px;" Text="Current Collection Point :"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Please Select Prefered Location" style="z-index: 1;color:Red; position: absolute; top: 132px; left: 195px"></asp:RequiredFieldValidator>
<br />
<br />
<br />
    <asp:Label ID="Label2" runat="server" style="z-index: 1; position: absolute; top: 42px; left: 22px" Text="Select Prefered Location Point  :"></asp:Label>

<asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 265px; left: 56px" Text="Submit" OnClick="Button1_Click" />

</asp:Content>

