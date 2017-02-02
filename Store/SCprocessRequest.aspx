<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SCprocessRequest.aspx.cs" Inherits="SCprocessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    //Stop Form Submission of Enter Key Press
    function stopRKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
    }
    document.onkeypress = stopRKey;
</script>
    <link href="StyleSheet.css" rel="stylesheet" />
    <center><h1>
        Process Request</h1></center>
 
    <asp:GridView CssClass="grid" ID="GridView1" runat="server" style="z-index: 1; width: 969px; height: 127px; position: absolute; top: 158px; left: 17px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="false">
           <Columns>  
         <asp:BoundField HeaderText="BIN" DataField="BIN" />
        <asp:BoundField HeaderText="Description" DataField="Description" />
        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                <asp:BoundField HeaderText="Actualqty" DataField="Actualqty" />
               <asp:BoundField HeaderText="RequisitionID" DataField="RequisitionID" /> 
        <asp:BoundField HeaderText="DepartmentName" DataField="DepartmentName" />
                <asp:BoundField HeaderText="deptneeded" DataField="deptneeded" />
                 <asp:TemplateField HeaderText="Allocated">
                <ItemTemplate>
                    <asp:TextBox ID="Textfrom" runat="server" CssClass="txtBoxNormalmedium" Text=''></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator" runat="server" 
    ErrorMessage='<%#"Min-0 Max-"+ Eval("deptneeded") %>' ControlToValidate="Textfrom" 
    MaximumValue='<%# Eval("deptneeded") %>' MinimumValue="0" ForeColor="Red"
    Display="Dynamic" ClientIDMode="Predictable" Type="Double" ValidationGroup="vg"/>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="Textfrom" ErrorMessage="Value Required" ValidationGroup="vg"></asp:RequiredFieldValidator>
          <%--             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="z-index: 1; width: 289px; height: 45px; position: absolute; top: 70px; left: 681px" ValidationGroup="vg" />
    <br />--%>
                </ItemTemplate>
                      

                       </asp:TemplateField>

               
         
                 <asp:BoundField HeaderText="Itemcode" DataField="Itemcode" /> 
                  </Columns>
        
</asp:GridView>
    <asp:ScriptManager ID="scriptmanager" runat="server">

    </asp:ScriptManager>
    <asp:UpdateProgress ID="updateprogress" runat="server" AssociatedUpdatePanelID="updatepanel">
        <ProgressTemplate>
            <div class="div1" style="margin-left:160px">
                <asp:Image ID="image" ImageUrl="~/Images/Loading_icon.gif" AlternateText="processing" runat="server" />
                </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" style="z-index: 1; position: absolute; top: 64px; left: 1006px" Text="Submit" OnClick="Button1_Click" ValidationGroup="vg" s/>
            <asp:BulletedList ID="BulletedList1" runat="server" Font-Bold="True" ForeColor="Red" style="z-index: 1; width: 246px; height: 93px; position: absolute; top: 65px; left: 294px; margin-right: 113px">
    </asp:BulletedList>
        </ContentTemplate>
    </asp:UpdatePanel>
    
             
<center><h3><asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 70px; left: 28px; width: 206px; height: 37px;" Text="Label"></asp:Label></h3>
    
    </center>
</asp:Content>

