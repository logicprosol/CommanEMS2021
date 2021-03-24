<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="CasteCategorySA.aspx.cs" Inherits="CMS.Forms.SuperAdmin.CasteCategorySA" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />


    <script type = "text/javascript">
        function ConfirmDelete() {
            confirm_value.value = "Yes";
            document.forms[0].removeChild(confirm_value);
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
        }    
        function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
    </script>

    <style type="text/css">
        .auto-style7 {
            width: 127px
        }
        .auto-style9 {
            width: 156px
        }
        .auto-style10 {
            width: 143px
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_CasteCategory" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 800px;
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
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10">
                                <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" ControlToValidate="txtCasteCategoryName" ErrorMessage="Please Enter Category Name" ForeColor="red" TargetControlID="txtCasteCategoryName" ValidationGroup="ValidateCasteCategory"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCasteCategoryCode" runat="server" ControlToValidate="txtCasteCategoryCode" ErrorMessage="Please Enter Category Code" ForeColor="red" TargetControlID="txtCasteCategoryCode" ValidationGroup="ValidateCasteCategory"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style10">
                                <asp:Label ID="lblFirstName3" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Organization"></asp:Label>
                                <br />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" ValidationGroup="General" Width="180px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>O+ve</asp:ListItem>
                                    <asp:ListItem>O-ve</asp:ListItem>
                                    <asp:ListItem>A+ve</asp:ListItem>
                                    <asp:ListItem>A-ve</asp:ListItem>
                                    <asp:ListItem>B+ve</asp:ListItem>
                                    <asp:ListItem>B-ve</asp:ListItem>
                                    <asp:ListItem>AB+ve</asp:ListItem>
                                    <asp:ListItem>AB-ve</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10">
                                <asp:Label ID="lblCasteCategoryName" runat="server" Text="Caste Category Name :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCasteCategoryName" runat="server" ValidationGroup="ValidateCasteCategoryName"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10">
                                <asp:Label ID="lblcastecategorycode" runat="server" Text="Caste Category Code :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCasteCategoryCode" runat="server" onkeypress="return isNumberKey(event)" ValidationGroup="ValidateCasteCategoryCode"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="auto-style9">
                                &nbsp;</td>
                            <td align="left" colspan="2">
                                <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnNew_Click" Text="New" ValidationGroup="ValidateCasteCategory" />
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="ValidateCasteCategory" />
                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" OnClientClick="return ConfirmUpdate()" Text="Update" ValidationGroup="ValidateCasteCategory" />
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" OnClientClick="return ConfirmDelete()" Text="Delete" ValidationGroup="ValidateCasteCategory" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" ValidationGroup="ValidateCasteCategory" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                &nbsp;</td>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%;margin-left:80px">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 600px;width:auto">
                                <asp:GridView ID="GrdCasteCategory" runat="server" CellPadding="4" ForeColor="#333333"
                                    DataKeyNames="CasteCategoryId,CasteCategoryName,Code" Width="80%" OnPageIndexChanging="GrdCasteCategory_PageIndexChanging"
                                    AutoGenerateColumns="False" PageSize="7" BorderColor="#3366CC"
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
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                 <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
