<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master"
    AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="CMS.Forms.Inventory.AddItem" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Src="~/UserControls/PagePopup.ascx" TagName="PgPopup" TagPrefix="ucPgPopup" %>
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
        .auto-style1 {
            width: 800px;
            margin-top: 10px;
        }
        .auto-style2 {
            width: 80%;
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
        <asp:UpdatePanel ID="UpdatePanel_AddItem" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
            <script type="text/javascript">
            function fnPopup() {
                document.getElementById('<%= btnHidden.ClientID %>').click();
            }
          </script>
                <asp:Panel ID="Panel_AddItem" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Item</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="border: 3px solid #0099FF; " class="auto-style1">
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
                                <asp:Label ID="lblItemName" runat="server" Text="Item Name :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemName" runat="server" placeholder="Item Name" ValidationGroup="ValidateItem"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName" ErrorMessage="Please Enter Item Name" ForeColor="red" TargetControlID="txtItemName" ValidationGroup="ValidateItem">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblItemCode" runat="server" Font-Bold="True" Text="Item Code:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemCode" Placeholder="Item Code" runat="server" ValidationGroup="ValidateItem"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCategory" runat="server" Text="Category :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ValidationGroup="ValidateItem"  width="180" >
                                </asp:DropDownList>
                              <%--  <asp:LinkButton ID="lnkCategory" runat="server" Text="..." CausesValidation="false" OnClick="lnkCategory_Click"></asp:LinkButton>--%>
                                <asp:RequiredFieldValidator ID="rfvddlCategory" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Please Select Item Category" ForeColor="red" InitialValue="Select" TargetControlID="ddlCategory" ValidationGroup="ValidateItem">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                    <asp:Label ID="lblUnit" runat="server" Font-Bold="True" Text="Unit :"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" ValidationGroup="ValidateItem" width="180">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvUnit" runat="server" ControlToValidate="ddlUnit" ErrorMessage="Please Select Unit" ForeColor="Red" InitialValue="Select" ValidationGroup="ValidateItem">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStock" runat="server" Text="Current Stock :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStock" runat="server" Placeholder="Stock"  ValidationGroup="ValidateItem"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtStock" runat="server" ControlToValidate="txtStock" ErrorMessage="Please Enter Item Stock" ForeColor="red" ValidationGroup="ValidateItem">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                    <asp:FilteredTextBoxExtender ID="ftbeStock" runat="server" TargetControlID="txtStock" FilterType="Numbers" >
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateItem"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateItem" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateItem" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                                <asp:Button ID="btnHidden" runat="server" CausesValidation="false" OnClick="btnHidden_Click" Style="display: none" />
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
                            <td align="center">
                                <asp:GridView ID="GrdItem" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ItemId,ItemName,ItemCode,CategoryId,UnitId,Stock"
                                    Width="80%" OnPageIndexChanging="GrdItem_PageIndexChanging" AutoGenerateColumns="False"
                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px" CssClass="auto-style3">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Item Name " ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnItemName" runat="server" Text='<%#Eval("ItemName") %>'
                                                    OnClick="lnkBtnItemName_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Code" DataField="ItemCode" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryId" ItemStyle-HorizontalAlign="Center" Visible="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Unit" DataField="UnitId" ItemStyle-HorizontalAlign="Center" Visible="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="Unit" DataField="UnitName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText=" Current Stock" DataField="Stock" ItemStyle-HorizontalAlign="Center">
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
                <ucPgPopup:PgPopup ID="PagePoup" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
