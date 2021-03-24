<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BackUpAndRestore.aspx.cs" Inherits="CMS.Forms.Admin.BackUpAndRestore" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 <div style="height: 900px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Backup" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_Backup" runat="server" Visible="true" Style="height: 897px;
                    width: 920px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Database Backup</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
          <table border="0" width="80%" align="center" cellspacing="2px">
                <center>
                    <table width="80%">
                        <tr>
                            <td align="center" class="tableClass" style="padding: 2%;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Database Action"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDLDBAction" runat="server">
                                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                <asp:ListItem Value="1">BackUp</asp:ListItem>
                                                <asp:ListItem Value="2">Restore</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="tableClass" style="padding: 1%;" align="center">
                                <asp:GridView ID="GrdBackupList" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                    PageSize="10" OnPageIndexChanging="gridResult_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Backup List" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnBackupList" runat="server" Text='<%#Eval("ExFileName") %>'
                                                    OnClick="lnkBtnBackupList_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="tableClass" style="padding: 1%;" align="center">
                                <asp:Button ID="BtnOk" runat="server" Text="Ok" OnClick="BtnOk_Click" />
                                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                            </td>
                        </tr>
                    </table>
                </center>
            </table>
            </asp:Panel>
            <ucMsgBox:MsgBox ID="MsgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    </div>
</asp:Content>
