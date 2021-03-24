<%@ Page Title="SportMaster" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SportMaster.aspx.cs" Inherits="CMS.Forms.SuperAdmin.SportMaster" %>

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
                                    <li><i class="icon-book"></i>Sport Master</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div class="MainBody">
                        <div class="frmwidth" align="center">
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
                                                        <asp:Label ID="lblSportName" runat="server" Text="Sport Name:"></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSportName" runat="server" ValidationGroup="ValidateSport"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvSportName" runat="server" ErrorMessage="Please Enter Sport Name"
                                                            ForeColor="red" ControlToValidate="txtSportName" TargetControlID="txtSportName"
                                                            ValidationGroup="ValidateSport"></asp:RequiredFieldValidator>
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
                                                        <asp:RadioButtonList ID="rbtStatus" runat="server" RepeatDirection="Horizontal" CssClass="radio"
                                                            Width="200px" ValidationGroup="ValidateSport">
                                                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="rbtStatus"
                                                            ValidationGroup="ValidateSport" ErrorMessage="Please Select Status"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateSport"
                                                            OnClick="btnNew_Click" CausesValidation="false" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateSport"
                                                            OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateSport" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateSport" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
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
                                                        <asp:GridView ID="GrdSport" runat="server" CellPadding="4" DataKeyNames="SportId,SportName,IsActive"
                                                            Width="80%" OnPageIndexChanging="GrdSport_PageIndexChanging" AutoGenerateColumns="False"
                                                            AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                            BorderWidth="1px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sport Name" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkBtnSportName" runat="server" Text='<%#Eval("SportName") %>'
                                                                            OnClick="lnkBtnSportName_Click" CausesValidation="false"></asp:LinkButton>
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
                                                    </td>
                                                </tr>
                                            </table>
                                               <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
       
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
