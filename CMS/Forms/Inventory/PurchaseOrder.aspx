<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master"
    AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="CMS.Forms.Inventory.PurchaseOrder" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <%-- <script type="text/javascript">
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintPO.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
</script>--%>


       <script type = "text/javascript">
           function CheckAll(oCheckbox) {
            var GrdItem = document.getElementById("<%=GrdItem.ClientID %>");
            for (i = 1; i < GrdItem.rows.length; i++) {
                GrdItem.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
           function PrintPanel() {
               var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
           }
           function isNumber(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
            return false;

        return true;
    }    
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 800px;
            margin-top: 10px;
        }
        .auto-style3 {
            margin-top: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_PurchaseOrder" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_PurchaseOrder" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Purchase Order</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="border: 3px solid #0099FF" class="auto-style2">
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPODate" runat="server" Text="PO Date :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPODate" runat="server" placeholder="Select Date" ValidationGroup="ValidatePurchaseOrder"></asp:TextBox>
                                <asp:CalendarExtender ID="POCalendarExtender" runat="server" TargetControlID="txtPODate"
                                    Format="MM/dd/yyyy" TodaysDateFormat="MM/dd/yyyy" DaysModeTitleFormat="MM/dd/yyyy">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvPurchaseOrderName" runat="server" ControlToValidate="txtPODate" ErrorMessage="Please Enter Purchase Order Date" ForeColor="red" TargetControlID="txtPODate" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:FilteredTextBoxExtender ID="ftbePOtDate" runat="server" TargetControlID="txtPODate"
                                    FilterType="Custom, Numbers" ValidChars="/">
                                </asp:FilteredTextBoxExtender>
                                <asp:Label ID="lblDeliveryMode" runat="server" Font-Bold="True" Text="Select Delivery Mode :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDeliveryMode" runat="server" ValidationGroup="ValidatePurchaseOrder" width="180">
                                    <asp:ListItem Selected="true" Text="Select" Value="0" />
                                    <asp:ListItem Text="By Hand" Value="1" />
                                    <asp:ListItem Text="By Train" Value="2" />
                                    <asp:ListItem Text="By Bus" Value="3" />
                                    <asp:ListItem Text="By Truck" Value="4" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDeliveryMode" runat="server" ControlToValidate="ddlDeliveryMode" ErrorMessage="Please Select Delivery Mode" ForeColor="red" InitialValue="Select" TargetControlID="ddlDeliveryMode" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPOCode" runat="server" Text="PO Code :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOCode" runat="server" Enabled="False" ValidationGroup="ValidatePurchaseOrder"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPOCode" runat="server" ControlToValidate="txtPOCode" ErrorMessage="Please Enter Purchase Order Code" ForeColor="red" TargetControlID="txtPOCode" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblPaymentMode" runat="server" Font-Bold="True" Text="Select Payment Mode :"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPaymentMode" runat="server" ValidationGroup="ValidatePurchaseOrder" width="180">
                                    <asp:ListItem Text="Select" Value="0" />
                                    <asp:ListItem Text="Cash" Value="1" />
                                    <asp:ListItem Text="DD" Value="2" />
                                    <asp:ListItem Text="Cheque" Value="3" />
                                    <asp:ListItem Text="Online Transfer" Value="4" />
                                    <asp:ListItem Text="Credit Card" Value="5" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlPaymentMode" runat="server" ControlToValidate="ddlPaymentMode" ErrorMessage="Please Select PaymentMode" ForeColor="red" InitialValue="Select" TargetControlID="ddlPaymentMode" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSupplier" runat="server" Text="Select Supplier :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"
                                    ValidationGroup="ValidatePurchaseOrder"  width="180">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSupplier" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="Please Select Supplier" ForeColor="red" InitialValue="Select" TargetControlID="ddlSupplier" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblRemark" runat="server" Font-Bold="True" Text="Remark :"></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" Rows="2" TextMode="MultiLine" ValidationGroup="ValidatePurchaseOrder"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark" ErrorMessage="Please Enter Remark" ForeColor="red" ValidationGroup="ValidatePurchaseOrder">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:GridView ID="GrdItem" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ItemId,ItemName"
                                    Width="700px" OnRowCreated="gvCheckboxes_RowCreated" OnPageIndexChanging="GrdItem_PageIndexChanging"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="5" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBxSelect" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                            <HeaderTemplate>
                                            <asp:CheckBox ID="chkBxHeader" onclick="CheckAll(this)" runat="server" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                          <asp:BoundField DataField="ItemId" HeaderText="Item ID" ItemStyle-HorizontalAlign="Center"
                                                            Visible="false" />
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Unit" DataField="UnitName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty"  runat="server" Width="55px" Style="text-align: right;" MaxLength="8"  
                                                    Text='<%#Eval("Qty") %>' AutoPostBack="True" OnTextChanged="txtQuantity_OnTextChanged" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtQty"
                                                    FilterType="Numbers,Custom" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRate" runat="server" Width="75px" Style="text-align: right;" 
                                                    MaxLength="9" Text='<%#Eval("Rate") %>' AutoPostBack="True" OnTextChanged="txtRate_OnTextChanged" onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRate"
                                                    FilterType="Numbers,Custom" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                            <asp:Label ID="lblGrandTotalAmt" runat="server" Text="Grand Total" Style="text-align: right; font-size:medium;"/>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalAmount" runat="server" Width="75px" Style="text-align: right; font-size:medium;"></asp:Label>
                                              
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lblGrandTotal" runat="server" Width="75px"  Text="" Style="text-align: right; font-size:medium;"/>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidatePurchaseOrder"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" CausesValidation="false"
                                   OnClientClick="PrintPanel(); "  />
                                <%--  <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidatePurchaseOrder"
                                    OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidatePurchaseOrder"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnCancel_Click" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                    </div>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 400px">
                                <asp:GridView ID="GrdPurchaseOrder" runat="server" CellPadding="4" ForeColor="#333333"
                                    DataKeyNames="POId" Width="700px" OnPageIndexChanging="GrdPurchaseOrder_PageIndexChanging"
                                    AutoGenerateColumns="False" PageSize="3" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px" DataSourceID="SqlDataSource1" CssClass="auto-style3">
                                    <Columns>
                                        <asp:BoundField DataField="PODate" HeaderText="PODate" SortExpression="PODate" />
                                        <asp:BoundField DataField="POCode" HeaderText="POCode" SortExpression="POCode" />
                                        <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
                                        <asp:BoundField DataField="GrandTotal" HeaderText="GrandTotal" SortExpression="GrandTotal" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        <asp:TemplateField HeaderText="Details" InsertVisible="False" SortExpression="POId">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("POId") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl123" runat="server" Text='<%# Bind("POId") %>' Visible="False"></asp:Label>
                                                <br />
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                                    <Columns>
                                                        <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName" />
                                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                                        <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                                                        <asp:BoundField DataField="TotalAmt" HeaderText="TotalAmt" SortExpression="TotalAmt" />
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT dbo.tblItem.ItemName, dbo.tblPurchaseOrderDetails.Quantity, dbo.tblPurchaseOrderDetails.Rate, dbo.tblPurchaseOrderDetails.TotalAmt FROM dbo.tblItem INNER JOIN dbo.tblPurchaseOrderDetails ON dbo.tblItem.ItemId = dbo.tblPurchaseOrderDetails.ItemId
where dbo.tblPurchaseOrderDetails.POId=@POId">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="lbl123" Name="POId" PropertyName="Text" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
</div>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                    SelectCommand="SELECT convert(varchar(20), dbo.tblPurchaseOrder.PODate,105)PODate, dbo.tblPurchaseOrder.POCode, dbo.tblSupplier.SupplierName, dbo.tblPurchaseOrder.GrandTotal, dbo.tblPurchaseOrder.Remarks, dbo.tblPurchaseOrder.POId FROM dbo.tblPurchaseOrder INNER JOIN dbo.tblSupplier ON dbo.tblPurchaseOrder.SupplierId = dbo.tblSupplier.SupplierId WHERE (dbo.tblPurchaseOrder.OrgId = @OrgId)">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="OrgId" SessionField="OrgId" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                 
                </asp:Panel>

                  <div style="width:450px;display:none"><%----%>
                            <asp:Panel ID="pnlContents" runat="server"> 
                                <center>
                                    <div >                                      
                                       <table width="500px" style="border:groove" align="center">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Image ID="imgClgLogo" runat="server" Height="50px" Width="108px" />
                                    </td>
                                  
                                    <td style="text-align:start">
                                        
                                    <asp:Label ID="lblTrustName" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F"  Font-Size="Larger"  Font-Italic="True"></asp:Label>
                                  
                                             </td>
                                    </tr>
                                    </table>
                                        <br />
                                        <div style="text-align:left;">
                                            <br />
                                            <div style="margin-left:20px;">
                                            
                                         <div style="text-align:center;font-size:large;font-weight:500">INVENTORY RECEIPT</div>    <br />
<div >
    <table style="width:400px;">
        <%-- <tr>
                                                    <td>
                                            <asp:Label ID="lblStudentCode" runat="server" Text=" Student Code" ></asp:Label>
                                          &nbsp;
                                                    </td>
                                                    <td>
                                           <asp:Label ID="lblStudentCode1" runat="server" Text="Label"></asp:Label> 
                                                    </td>
                                                 </tr>--%>
        
           <tr>
                <td >
                    <asp:Label ID="Suppliername" runat="server" Font-Bold="True" Text="Supplier Name"></asp:Label>
                    &nbsp; </td>
                <td>
                    <asp:Label ID="Suppliername1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ItemName" runat="server" Font-Bold="True" Text="PO Date"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ItemName1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            
                <tr>
                    <td >
                        &nbsp; 
                        <asp:Label ID="Tamt" runat="server" Font-Bold="True" Text="Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Tamt1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Category" runat="server" Font-Bold="True" Text="Category" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Category1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                </tr>
                
                    <tr>
                        <td >
                            &nbsp; 
                            <asp:Label ID="qty" runat="server" Font-Bold="True" Text="Quantity" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="qty1" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Rate" runat="server" Font-Bold="True" Text="Rate" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Rate1" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    
                       
                           
    </table>
                                                </div>
                                             
                                   
                                                  
                                            
                                            <center>
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ItemName" HeaderText="ItemName" />
                                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                                    <asp:BoundField DataField="TotalAmt" HeaderText="TotalAmt" />
                                                                </Columns>
                                                            </asp:GridView></td>
                                                    </tr>
                                                </table>
                                            </center>
                                                 <br/>
                                                 

                                            <div style="text-align:right">      
                                            (Authorised Signature)
                                            </div> 
                                              <br /> 
                                              <br /> 
                                              <br />
                                            </div> 
                                            </div>
                                             </div>
                                        <hr />
                                        <br />
                                                                                                   
                                </center>
                            </asp:Panel>
                </div>


                   <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
