<%@ Page Title="DepartmentDesignation" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="DepartmentDesignation.aspx.cs" Inherits="CMS.Forms.Admin.DepartmentDesignation" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->
    <!--  For Tab Navigation Use This jQuery  -->
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS: compiled and minified -->
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Example plugin: Prettify -->
    <!-- Initialize Scripts -->
    <script type="">
        // Activate Google Prettify in this page
        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {
            // Add prettyprint class to pre elements
            $('pre').addClass('prettyprint');
        }); // end document.ready
    </script>

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
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" align="center" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true" Style="height: 897px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>DEPARTMENT DESIGNATION</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
                <div class="frmwidth" align="center">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Department</font>
                        </a></li>
                        <li><a href="#sp2"  data-toggle="tab"><font color="blue">Designation</font></a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="sp1" class="tab-pane active" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Department" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDepartmentName" runat="server" Text="Department Name:"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDepartmentName" runat="server" ValidationGroup="ValidateDepartment"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" ErrorMessage="Please Enter Department Name"
                                                    ForeColor="red" ControlToValidate="txtDepartmentName" TargetControlID="txtDepartmentName"
                                                    ValidationGroup="ValidateDepartment"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbtStatus" runat="server" CssClass="radio" RepeatDirection="Horizontal" ValidationGroup="ValidateDepartment" Width="200px">
                                                    <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                    <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="rbtStatus" ErrorMessage="Please Select Status" ValidationGroup="ValidateDepartment"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDepartmentCode" runat="server" Text="Department Code:" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDepartmentCode" runat="server" ValidationGroup="ValidateDepartment" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNew" runat="server" Text=" Add New" class="btn btn-primary" ValidationGroup="ValidateDepartment"
                                                    OnClick="btnNew_Click" CausesValidation="false" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDepartment"
                                                    OnClick="btnSave_Click" />
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDepartment" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDepartment" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto">
                                                <asp:GridView ID="GrdDepartment" runat="server" CellPadding="4" DataKeyNames="DepartmentId,DepartmentName,DepartmentCode,IsActive"
                                                    Width="80%" OnPageIndexChanging="GrdDepartment_PageIndexChanging" AutoGenerateColumns="False" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                    BorderWidth="1px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Department Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnDepartmentName" runat="server" Text='<%#Eval("DepartmentName") %>'
                                                                    OnClick="lnkBtnDepartmentName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Department Code" DataField="DepartmentCode" ItemStyle-HorizontalAlign="Center">
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
                                                    </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp2" class="tab-pane " align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Designation" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDepartment" runat="server" Text="Department :"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="ValidateDesignation" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ErrorMessage="Please select department."
                                                    ControlToValidate="ddlDepartment" InitialValue="Select" ValidationGroup="ValidateDesignation"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDesgType" runat="server" Text="Designation Type:"></asp:Label>
                                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDesignationType" runat="server" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDesignationType" runat="server" ControlToValidate="ddlDesignationType" ErrorMessage="Please select designation type." ForeColor="Red" InitialValue="Select" ValidationGroup="ValidateDesignation"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDesigName" runat="server" Text="Designation Name:"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesignationName" runat="server" ValidationGroup="ValidateDesignation"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDesignationName" runat="server" ControlToValidate="txtDesignationName" Display="Dynamic" ErrorMessage="Please Enter Designation Name." ForeColor="red" TargetControlID="txtDesignationName" ValidationGroup="ValidateDesignation"></asp:RequiredFieldValidator>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDesigCode" runat="server" Text="Designation Code:" Visible="false"></asp:Label>
                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesignationCode" runat="server" ValidationGroup="ValidateDesignation"  Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                              
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewD" runat="server" Text="Add New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                    OnClick="btnNewD_Click" CausesValidation="false" />
                                                <asp:Button ID="btnSaveD" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                    OnClick="btnSaveD_Click" />
                                                <asp:Button ID="btnUpdateD" runat="server" Text="Update" class="btn btn-primary"
                                                    ValidationGroup="ValidateDesignation" OnClick="btnUpdateD_Click" />
                                                <asp:Button ID="btnDeleteD" runat="server" Text="Delete" class="btn btn-primary"
                                                    ValidationGroup="ValidateDesignation" OnClick="btnDeleteD_Click" />
                                                <asp:Button ID="btnCancelD" runat="server" Text="Cancel" class="btn btn-primary"
                                                    CausesValidation="false" OnClick="btnCancelD_Click" />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdDesignation" runat="server" CellPadding="4" ForeColor="#333333"
                                                    DataKeyNames="DesignationId,DesignationCode,DesignationName,DesignationTypeId,DesignationType"
                                                    Width="80%" OnPageIndexChanging="GrdDesignation_PageIndexChanging" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                    BorderWidth="1px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Designation Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnDesignationName" runat="server" Text='<%#Eval("DesignationName") %>'
                                                                    OnClick="lnkBtnDesignationName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Designation Code" DataField="DesignationCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Designation Type" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_DesType" HeaderText="Designation Type" runat="server" Text='<%# Bind("DesignationType") %>'></asp:Label>
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
   
</asp:Content>
