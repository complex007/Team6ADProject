<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SSrequisitionTrendAnalysis.aspx.cs" Inherits="SS.SSrequisitionTrendAnalysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row"> 
        <div class="col-sm-3">
            <table>
            <thead>
                <td>Category:</td>
            </thead>
                <tbody>
                    <tr>
                        <td>
                              <asp:ListBox ID="ListBox5" runat="server" Height="118px" Width="98px">
                                      <asp:ListItem>Clip</asp:ListItem>
                                     <asp:ListItem>Envelope</asp:ListItem>
                                     <asp:ListItem>Eraser</asp:ListItem>
                                     <asp:ListItem>Exercise</asp:ListItem>
                                   <asp:ListItem>File</asp:ListItem>
                                     <asp:ListItem>Ruler</asp:ListItem>
                                     <asp:ListItem>Pad</asp:ListItem>
                                     <asp:ListItem>Paper</asp:ListItem>
                                     <asp:ListItem>Pen</asp:ListItem>
                                     <asp:ListItem>Puncher</asp:ListItem>
                                     <asp:ListItem>Ruler</asp:ListItem>
                                     <asp:ListItem>Scissors</asp:ListItem>
                                     <asp:ListItem>Tape</asp:ListItem>
                                     <asp:ListItem>Sharpener</asp:ListItem>
                                     <asp:ListItem>Shorthand</asp:ListItem>
                                     <asp:ListItem>Stapler</asp:ListItem>
                                     <asp:ListItem>Tacks</asp:ListItem>
                                     <asp:ListItem>Tparency</asp:ListItem>
                                     <asp:ListItem>Tray</asp:ListItem>
                             </asp:ListBox>
                                 <asp:Button ID="Button1" runat="server" Text="Select Category"  OnClick="Button1_Click"/>
                              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </tbody>
        </table>
       

    </div>

    <div class="col-sm-3">
        
        <asp:Label ID="Lbsupplier" runat="server" Text="Department:"></asp:Label> 
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
        <asp:ListItem>ENGL</asp:ListItem>
        <asp:ListItem>CPSC</asp:ListItem>
        <asp:ListItem>COMM</asp:ListItem>
        <asp:ListItem>REGR</asp:ListItem>
        <asp:ListItem>ZOOL</asp:ListItem>
       
    </asp:CheckBoxList>

  </div>
  
    <div class="col-sm-3">
        <asp:Label ID="Label2" runat="server" Text="Month(yyyy-MM):"></asp:Label>

            <asp:Button ID="Btnmonth1" runat="server" style="z-index: 1; position: absolute; top: 25px; left: 171px; height: 25px; margin-top: 0;" Text="Select Month1" OnClick="Btnmonth1_Click" />
            <asp:Calendar ID="Calendar1" runat="server" style="z-index: 1; width: 231px; height: 129px; position: absolute; top: 13px; left: 350px" ></asp:Calendar>
            <asp:Label ID="Lbmonth1" runat="server" style="z-index: 1; position: absolute; top: 25px; left: 22px; width: 121px; height: 26px;" Text=""></asp:Label>
             <asp:Button ID="Btnmonth2" runat="server" style="z-index: 1; position: absolute; top: 54px; left: 172px; width: 134px" Text="Select Month2" OnClick="Btnmonth2_Click" />
             <asp:Label ID="Lbmonth2" runat="server" style="z-index: 1; position: absolute; top: 55px; left: 21px; width: 121px" Text=""></asp:Label>
             <asp:Label ID="Lbmonth3" runat="server" style="z-index: 1; position: absolute; top: 92px; left: 20px; width: 121px; height: 21px;" Text=""></asp:Label>
            <asp:Button ID="Btnmonth3" runat="server" style="z-index: 1; position: absolute; top: 85px; left: 174px; width: 133px;" Text="Select Month3" OnClick="Btnmonth3_Click" />                           
    </div>
   <div class="col-sm-3">
  <asp:Button ID="Btngenerate" runat="server" Text="Generate Report" onClick="Btngenerate_Click" Width="690px"/>
      
   </div>
   </div>
   <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
