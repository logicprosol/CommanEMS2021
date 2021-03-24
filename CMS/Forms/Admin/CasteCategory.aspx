<%@ Page Title="CasteCategory" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="CasteCategory.aspx.cs" Inherits="CMS.Forms.Admin.CasteCategory" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_CasteCategory" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Caste Category</li>
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
                                <asp:Label ID="lblCasteCategoryName" runat="server" Text="Caste Category Name :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCasteCategoryName" runat="server" ValidationGroup="ValidateCasteCategoryName"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" ErrorMessage="Please Enter Category Name"
                                    ForeColor="red" ControlToValidate="txtCasteCategoryName" TargetControlID="txtCasteCategoryName"
                                    ValidationGroup="ValidateCasteCategory"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcastecategorycode" runat="server" Text="Caste Category Code :"></asp:Label>


                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCasteCategoryCode" runat="server" ValidationGroup="ValidateCasteCategoryCode"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCasteCategoryCode" runat="server" ErrorMessage="Please Enter Category Code"
                                    ForeColor="red" ControlToValidate="txtCasteCategoryCode" TargetControlID="txtCasteCategoryCode"
                                    ValidationGroup="ValidateCasteCategory"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
    ControlToValidate="txtCasteCategoryCode" runat="server"
    ErrorMessage="Only Numbers allowed"
    ValidationExpression="\d+">
</asp:RegularExpressionValidator>
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
                            <td colspan="2" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateCasteCategory"
                                    CausesValidation="false" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateCasteCategory"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateCasteCategory" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateCasteCategory" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="ValidateCasteCategory"
                                    CausesValidation="false" OnClick="btnCancel_Click" />
                            </td>
                            <td>
                                <a href="Documents.aspx" style="color:blue;font-family:Cambria;font-size:large;text-decoration:underline;">Set Document List</a>
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
                                <asp:GridView ID="GrdCasteCategory" runat="server" CellPadding="4" ForeColor="#333333"
                                    DataKeyNames="CasteCategoryId,CasteCategoryName,Code" Width="80%" OnPageIndexChanging="GrdCasteCategory_PageIndexChanging"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CasteCategory Name " ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnCasteCategoryName" runat="server" Text='<%#Eval("CasteCategoryName") %>'
                                                    OnClick="lnkBtnCasteCategoryName_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="CasteCategory Code" DataField="Code" ItemStyle-HorizontalAlign="Center">
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