<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DHsetCollectionPoint.aspx.cs" Inherits="DHsetCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:darkblue;font-weight:bold;">Collection Point</h1></center>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" style="z-index: 1; width: 187px; height: 133px; position: absolute; top: 159px; left: 470px" >
        <asp:ListItem>UHC</asp:ListItem>
        <asp:ListItem>UTown</asp:ListItem>
        <asp:ListItem>Museum</asp:ListItem>
        <asp:ListItem>Biz</asp:ListItem>
        <asp:ListItem>Deck</asp:ListItem>
        <asp:ListItem>Kent Ridge</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label1" CssClass="labels" runat="server" style="z-index: 1; position: absolute; top: 101px; left: 217px" Text="Current Collection Point :"></asp:Label>
    <asp:Label ID="Label2" CssClass="labels" runat="server" style="z-index: 1; position: absolute; top: 151px; left: 217px" Text="Select Prefered Location :"></asp:Label>
    <asp:Label ID="Label3" runat="server" style="z-index: 1; position: absolute; top: 104px; left: 470px; width: 166px"></asp:Label>


<asp:Button ID="Button1" class="btn btn-success" runat="server" style="z-index: 1; position: absolute; top: 319px; left: 466px; height: 33px; width: 99px;" Text="Submit" OnClick="Button1_Click"  />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Please Select Prefered Location" style="z-index: 1;color:Red; position: absolute; top: 155px; left: 673px"></asp:RequiredFieldValidator>

</asp:Content>

