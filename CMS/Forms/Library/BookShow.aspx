<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true" CodeBehind="BookShow.aspx.cs" Inherits="CMS.Forms.Library.BookShow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 800px;
            margin-top: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 900px;" align="center">
                <asp:Panel ID="Panel1" runat="server" Visible="true" Style="height: 900px; width: 920px;
                    border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="left" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"> </i> Issue Book</li>
                                </ul>
                            </th>
                        </tr>
                       
                        <tr>
                            <td align="center">
                                <div class="auto-style1" style="border: 3px solid #0099FF;">
                                <table width="80%">
                                    <tr>
                                         <td align="left">
                                             &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                         <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblBarcode" runat="server" Font-Bold="True" Text="Book No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBarcode" runat="server" placeholder="Enter Book No" AutoPostBack="true" OnTextChanged="txtBarcode_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>&nbsp; </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                         <td align="left">
                                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGroupName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPublishYear" runat="server" Text="Publish Year " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublishYear" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblBookName" runat="server" Text="Book Name " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBookName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEdition" runat="server" Text="Edition " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEdition" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblAuthor" runat="server" Text="Author " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuthor" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPrice" runat="server" Text="Price " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrice" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblPublisher" runat="server" Text="Publisher " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublisher" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                           <asp:Label ID="Label1" runat="server" Text="Stock " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="lblstock" runat="server" placeholder="Current Stock" Enabled="False"></asp:TextBox>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblIssue" runat="server" Text="Student Code" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueTo" runat="server" AutoPostBack="True" placeholder="Enter Student Code"
                                                OnTextChanged="txtIssueTo_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueDate" runat="server" ReadOnly="True" Enabled="False" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtIssueDate" >
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblIssue0" runat="server" Font-Bold="True" Text="Student Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Due Date " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDueDate" runat="server" placeholder="Select Date"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtDueDate">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            &nbsp;
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="grpSave" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                            <td>&nbsp; </td>
                                             <td colspan="3">
                                            &nbsp;
                                        </td>
                            </tr>

                                   
                                </table>
</div>
<asp:GridView ID="GrdBook" runat="server" AllowPaging="True" CellPadding="4" OnPageIndexChanging="GrdBook_PageIndexChanging" PageSize="9" Width="60%" OnRowDataBound="GrdBook_RowDataBound" ForeColor="#333333" GridLines="None">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
