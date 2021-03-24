<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master" AutoEventWireup="true" CodeBehind="AddUnit.aspx.cs" Inherits="CMS.Forms.Inventory.AddUnit" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

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

    <style type="text/css">
        .auto-style3 {
            width: 80%;
            margin-top: 10px;
        }
        .auto-style4 {
            width: 800px;
            margin-top: 10px;
        }
        .auto-style5 {
            width: 305px;
        }
        .auto-style6 {
            width: 271px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_AddUnit" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_AddUnit" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Unit</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div class="auto-style4" style="border: 3px solid #0099FF;">
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td class="auto-style6">
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style6">
                                <asp:Label ID="lblUnitName" runat="server" Text="Unit Name :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUnitName" Placeholder="Unit Name" runat="server" MaxLength="20" ValidationGroup="ValidateUnitName"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvUnitName" runat="server" ControlToValidate="txtUnitName" ErrorMessage="Please Enter Unit Name" ForeColor="red" TargetControlID="txtUnitName" ValidationGroup="ValidateUnit"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateUnit"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateUnit" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateUnit" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <table class="auto-style3">
                        <tr>
                            <td>
                                <asp:GridView ID="GrdUnit" runat="server" CellPadding="4" ForeColor="#333333"
                                    DataKeyNames="UnitId,UnitName" Width="80%" OnPageIndexChanging="GrdUnit_PageIndexChanging"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Unit Name " ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnUnitName" runat="server" Text='<%#Eval("UnitName") %>'
                                                    OnClick="lnkBtnUnitName_Click" CausesValidation="false"></asp:LinkButton>
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
                  
                </asp:Panel>
                  <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
