<%@ Page Title="AcademicYear" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" Culture="en-IN"
    AutoEventWireup="true" CodeBehind="AcademicYear.aspx.cs" Inherits="CMS.Forms.Admin.AcademicYear" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>

    <script type = "text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmUpdate() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" UpdateMode="Conditional">
            <ContentTemplate>  
                <asp:Panel ID="Panel_AcademicYear" runat="server" Visible="true" Style="height: 897px;
                    width: 920px; border: medium double#0C7BFA;">  
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Academic Year</li>
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
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAcademicYear" runat="server" Text=" AcademicYear :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAcademicYear" runat="server" MaxLength="9"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvAcademicYear" runat="server" ErrorMessage="Please enter academic year"
                                    ForeColor="red" ControlToValidate="txtAcademicYear"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeAcademicYear" runat="server" TargetControlID="txtAcademicYear"
                                    FilterType="Custom, Numbers" ValidChars="-">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="txtStartDate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="Please enter start date"
                                    ForeColor="red" ControlToValidate="txtStartDate"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeStartDate" runat="server" TargetControlID="txtStartDate"
                                    FilterType="Custom, Numbers" ValidChars="/">
                                </asp:FilteredTextBoxExtender>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEndDate" runat="server" Text="End Date :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="EndDateCalendarExtender" runat="server" TargetControlID="txtEndDate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="Please enter end date"
                                    ForeColor="red" ControlToValidate="txtEndDate"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpvDate" runat="server" ControlToCompare="txtStartDate"
                                    ControlToValidate="txtEndDate" ErrorMessage="End date must be greater than start date"
                                    ForeColor="Red" Operator="GreaterThan" Type="Date" Display="Dynamic"></asp:CompareValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeEndDate" runat="server" TargetControlID="txtEndDate"
                                    FilterType="Custom, Numbers" ValidChars="/">
                                </asp:FilteredTextBoxExtender>
                                  <asp:CompareValidator ID="txtCmpDate" runat="server" ErrorMessage=" Please Enter From Date Less Than To Date !!!"
                                   ControlToCompare="txtStartDate" SetFocusOnError="true" ControlToValidate="txtEndDate" CultureInvariantValues="True"
                                   Operator="GreaterThanEqual" Type="Date" Display="None" Text="*" ></asp:CompareValidator>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCode" runat="server" Text=" Code :"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server" MaxLength="5"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="Please enter code"
                                    ForeColor="red" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeCode" runat="server" TargetControlID="txtCode"
                                    FilterType="Custom, Numbers" ValidChars="-">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCurrentYear" runat="server" Text="Current Year :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkboxCurrentYear" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxCurrentYear_CheckedChanged" />
                            </td>
                            <td>
                            </td>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <asp:GridView ID="GrdAcademicYear" runat="server" CellPadding="4" DataKeyNames="AcademicYearId,AcademicYear,StartDate,EndDate,Code,IsCurrentYear"
                                    Width="80%" OnPageIndexChanging="GrdAcademicYear_PageIndexChanging" AutoGenerateColumns="False"
                                    AllowPaging="True" PageSize="5" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Academic Year" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnAcademicYear" runat="server" Text='<%#Eval("AcademicYear") %>'
                                                    OnClick="lnkBtnAcademicYear_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Start Date" DataField="StartDate" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="End Date" DataField="EndDate" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Code" DataField="Code" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Current Year" DataField="IsCurrentYear" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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
                    </table>
                </asp:Panel>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>