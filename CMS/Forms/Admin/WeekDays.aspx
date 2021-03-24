<%@ Page Title="WeekDays" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="WeekDays.aspx.cs" Inherits="CMS.Forms.Admin.WeekDays" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdDay.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[1].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 800px;
            width: 800px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Week Days</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="4">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="lblweekDay" runat="server" Text="Select Day" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GrdDay" runat="server" AutoGenerateColumns="False" BorderColor="#0066FF"
                                    BorderStyle="Solid" CellPadding="3" DataKeyNames="DayId,Day,IsActive" ForeColor="#333333"
                                    GridLines="None" Width="600px" OnDataBound="OnDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Day" HeaderText="Day" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAll(this)" Text="Select All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkbox" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" BorderStyle="None" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnSetWeekDay" runat="server" Text="Set" CssClass="btn btn-primary"
                                    OnClick="btnSetWeekDay_Click" />
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>