<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master"
    AutoEventWireup="true" CodeBehind="QualityControl.aspx.cs" Inherits="CMS.Forms.Inventory.QualirtControl" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_QualityControl" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_QualityControl" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Quality Control</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
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
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblQCDate" runat="server" Text="QC Date :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQCDate" runat="server" ValidationGroup="ValidateQualityControl"></asp:TextBox>
                                <asp:CalendarExtender ID="POCalendarExtender" runat="server" TargetControlID="txtQCDate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPurchaseOrderDate" runat="server" ErrorMessage="Please Enter Quality Control Date"
                                    ForeColor="red" ControlToValidate="txtQCDate" TargetControlID="txtQCDate" ValidationGroup="ValidateQualityControl"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeQCtDate" runat="server" TargetControlID="txtQCDate"
                                    FilterType="Custom, Numbers" ValidChars="/">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPOCode" runat="server" Text="PO Code :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPOCode" runat="server" AutoPostBack="true" OnTextChanged="txtPOCode_TextChanged"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txtPOCode_AutoCompltExtender" runat="server" 
                                    ServiceMethod="GetPOCodes" MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1"
                                    TargetControlID="txtPOCode" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                    CompletionListItemCssClass="listItem">
                                </asp:AutoCompleteExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPOCode" runat="server" ErrorMessage="Please Enter Purchase Order Code"
                                    ForeColor="red" ControlToValidate="txtPOCode" TargetControlID="txtPOCode" ValidationGroup="ValidateQualityControl"></asp:RequiredFieldValidator>
                                <%--          <asp:RequiredFieldValidator ID="ReqPOCode" runat="server" 
                                                ControlToValidate="txtPOCode" Display="None" 
                                                ErrorMessage="Please Enter Purchase Order Code !!!" ForeColor="Red" Text="*" 
                                                ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                                                TargetControlID="ReqPOCode">
                                            </asp:ValidatorCalloutExtender>--%>
                            </td>
                        </tr>
                        <caption>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSupplier" runat="server" Text="Select Supplier :"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"
                                        ValidationGroup="ValidateQualityControl">
                                    </asp:DropDownList>
                                    <%--  <asp:TextBox ID="txtSupplier" runat="server" Enabled="False" ValidationGroup="ValidateQualityControl"></asp:TextBox>--%>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSupplier" runat="server" ControlToValidate="ddlSupplier"
                                        ErrorMessage="Please Select Supplier" ForeColor="red" InitialValue="Select" TargetControlID="ddlSupplier"
                                        ValidationGroup="ValidateQualityControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </caption>
                        </tr>
                      <%--  <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                               
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="1" ValidationGroup="ValidateQualityControl"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvTxtAddress" runat="server" ErrorMessage="Please enetr Address"
                                    ForeColor="red" ControlToValidate="ddlSupplier" InitialValue="Select" TargetControlID="ddlSupplier"
                                    ValidationGroup="ValidateQualityControl"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="3">
                                <div>
                                    <asp:GridView ID="GrdItems" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId,ItemName,UnitName,Quantity">
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkBxSelect" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                                <HeaderTemplate>
                                                   
                                                </HeaderTemplate>
                                            </asp:TemplateField>--%>
                                            <%--  <asp:BoundField DataField="ItemCode" HeaderText="Item Code" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>--%>
                                            <asp:BoundField DataField="ItemName" HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                              <asp:BoundField DataField="CategoryName" HeaderText="Category" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                          
                                             <asp:BoundField DataField="UnitName" HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Quantity" HeaderText="Total Qty" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PendingQty" HeaderText="Pending Qty" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Accepted Qty" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAcceptedQty" runat="server" OnTextChanged="txtAcceptedQty_TextChanged"
                                                        AutoPostBack="true" Width="75px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAcceptedQty"
                                                        ValidChars="." FilterType="Numbers,Custom">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="ReqAcceptedQty" runat="server" ControlToValidate="txtAcceptedQty"
                                                        ErrorMessage="Please Enter Accepted Quantity !!!" Display="Dynamic" Text="*"
                                                        ValidationGroup="grpSave" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="ReqAcceptedQty">
                                                    </asp:ValidatorCalloutExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rejected Qty" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRejectedQty" runat="server" Width="75px" OnTextChanged="txtRejectedQty_TextChanged"
                                                        AutoPostBack="true" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRejectedQty"
                                                        ValidChars="." FilterType="Numbers,Custom">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="ReqRejectedQty" runat="server" ControlToValidate="txtRejectedQty"
                                                        ErrorMessage="Please Enter Rejected Quantity !!!" Display="Dynamic" Text="*"
                                                        ValidationGroup="grpSave" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="ReqRejectedQty">
                                                    </asp:ValidatorCalloutExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRemark" runat="server" Text="Remark :"></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" Rows="2" ValidationGroup="ValidateQualityControl"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ErrorMessage="Please Enter Remark"
                                    ForeColor="red" ControlToValidate="txtRemark" ValidationGroup="ValidateQualityControl"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateQualityControl"
                                    OnClick="btnSave_Click" />
                                <%--<asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-primary" OnClick="btnPrint_Click"
                                    ValidationGroup="ValidateQualityControl" />
                                 <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateQualityControl"
                                    OnClick="btnUpdate_Click" />
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnCancel_Click" />--%>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
