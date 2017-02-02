<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DErequestItem.aspx.cs" Inherits="DErequestItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:Label ID="Label2" runat="server" CssClass="labels" Style="z-index: 1; position: absolute; top: 0px; left: 21px" Text="Item Category:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 170px; width: 148px; height: 25px" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="category" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:team6adprojectdbConnectionString %>" SelectCommand="SELECT DISTINCT [category] FROM [Item]"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" CssClass="labels" Style="z-index: 1; position: absolute; top: 39px; left: 19px; height: 27px;" Text="Item Code:"></asp:Label>

        <asp:DropDownList ID="DropDownList7" runat="server" Style="z-index: 1; position: absolute; top: 40px; left: 170px; width: 148px; height: 25px" AutoPostBack="True">
            <asp:ListItem>--select--</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" class="btn btn-warning" Style="z-index: 1; position: absolute; top: 80px; left: 170px" Text="Add To Cart" OnClick="Button1_Click" AutoPostBack="true" />
    </p>
    <p>


        <table style="width: 65%; height: 188px">
            <tr>
                <td>
                    <table id="tab1" style="width: 65%; z-index: 1; height: 186px; position: relative;">
                        <tr>
                            <th class="modal-sm" style="width: 182px; height: 20px;"></th>
                            <th style="width: 133px; height: 20px;"></th>
                            <th style="width: 130px; height: 20px;"></th>
                            <th style="width: 51px; height: 20px;"></th>
                            <th style="width: 51px; height: 20px;">&nbsp;</th>
                        </tr>
                        <tr>
                            <td class="modal-sm" style="width: 182px">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </td>
                            <td style="width: 133px">
                                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                            </td>
                            <td style="width: 130px">
                                <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                            </td>
                            <td style="width: 51px">
                                <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                            </td>
                            <td style="width: 51px">
                                <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
            <tr><td></td></tr>
            <tr>
                
                <td align="right">
                    <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" class="btn btn-success" Style="z-index: 1; position: relative;" Text="Submit" /></td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Style="z-index: 1; position: absolute; top: 115px; left: 23px"></asp:Label>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>


    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
         
</asp:Content>
