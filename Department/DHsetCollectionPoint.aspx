<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHsetCollectionPoint.aspx.cs" Inherits="DHsetCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" style="z-index: 1; width: 116px; height: 20px; position: absolute; top: 91px; left: 40px" >
        <asp:ListItem>UHC</asp:ListItem>
        <asp:ListItem>UTown</asp:ListItem>
        <asp:ListItem>Museum</asp:ListItem>
        <asp:ListItem>Biz</asp:ListItem>
        <asp:ListItem>Deck</asp:ListItem>
        <asp:ListItem>Kent Ridge</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label1" runat="server" Text="Label"> Current Collection Point :</asp:Label>
    <asp:Label ID="Label2" runat="server" style="z-index: 1; position: absolute; top: 42px; left: 13px" Text="Select Prefered Location :"></asp:Label>
    <asp:Label ID="Label3" runat="server"></asp:Label>


<asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 279px; left: 106px; height: 24px;" Text="Submit" OnClick="Button1_Click"  />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Please Select Prefered Location" style="z-index: 1;color:Red; position: absolute; top: 142px; left: 213px"></asp:RequiredFieldValidator>

</asp:Content>

