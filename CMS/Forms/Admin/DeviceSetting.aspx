<%@ Page Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="DeviceSetting.aspx.cs" Inherits="CMS.Forms.Admin.DeviceSetting" %>

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
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_DeviceSetting" runat="server" Visible="true" Style="height: 885px;
            width: 900px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Device Setting</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_DeviceSetting" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDeviceName" Text="Device Name :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeviceName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIP" Text="IP :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RegularExpressionValidator ID="revIP" runat="server" ErrorMessage="Please Enter Valid IP Address!"
                                    ControlToValidate="txtIp" ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$"
                                    ForeColor="Red">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPortNo" Text="Port No :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPortNo" runat="server" MaxLength="4"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RegularExpressionValidator ID="revPortNo" ControlToValidate="txtPortNo" runat="server"
                                    ErrorMessage="Enter Only 4 Digits!" SetFocusOnError="True" ValidationExpression="^\d{4}$"
                                    ForeColor="Red">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMachineId" Text="Machine Id :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMachineId" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescription" Text="Description :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnNew" Text="New" runat="server" class="btn btn-primary" OnClick="btnNew_Click"
                                    CausesValidation="false" />
                                <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-primary" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Text="Update" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" Text="Delete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" class="btn btn-primary" OnClick="btnCancel_Click"
                                    CausesValidation="false" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%" align="center">
                        <tr>
                            <td>
                                <asp:GridView ID="GrdDevice" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    ForeColor="#333333" DataKeyNames="DeviceSettingId,DeviceName,IP,PortNo,MachineId,Description"
                                    Width="80%" GridLines="None" BorderColor="#0066FF" BorderStyle="Solid" AllowPaging="true"
                                    OnPageIndexChanging="GrdDevice_PageIndexChanging" PageSize="10">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Device Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnDeviceName" runat="server" Text='<%#Eval("DeviceName") %>'
                                                    OnClick="lnkBtnDeviceName_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="IP" DataField="IP" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Port No" DataField="PortNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Machine ID" DataField="MachineId" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Description" DataField="Description" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>