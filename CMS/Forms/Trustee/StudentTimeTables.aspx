<%@ Page Language="C#" MasterPageFile="~/Forms/Trustee/Trustee.Master" AutoEventWireup="true" CodeBehind="StudentTimeTables.aspx.cs" Inherits="CMS.Forms.Trustee.StudentTimeTables" %>

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
        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px;
            width: 911px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>TIME TABLE </li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SetCourseClass" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto;">
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select Course !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Select Branch !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvddlSubject" runat="server" ControlToValidate="txtDate" ErrorMessage="Please Select Date !!!" ForeColor="Red" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse0" Text="Select Organization :" runat="server" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlorganization" runat="server" >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlorganization" ErrorMessage="Select Organization" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse" runat="server" Text="Select Course :" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" runat="server" Text="Select Branch :" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server" Font-Bold="True" ></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblSubject" Text="Select Date : " runat="server" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" TextMode="Date" width="180"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click" style="height: 28px" Text="Go" ValidationGroup="grpSave" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <%--<asp:Panel ID="Panel1" runat="server" Height="292px" HorizontalAlign="Center"  Width="100%" ScrollBars="Auto">--%>
                                        <asp:GridView ID="grdTimeTable" runat="server" BackColor="White" BorderColor="#3366CC" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="800px" AutoGenerateColumns="False" EmptyDataText="No record present" >

                                            <Columns>
                                                <asp:BoundField DataField="Period" HeaderText="Period" />
                                                <asp:BoundField DataField="Mon" HeaderText="Mon" />
                                                <asp:BoundField DataField="Tue" HeaderText="Tue" />
                                                <asp:BoundField DataField="Wed" HeaderText="Wed" />
                                                <asp:BoundField DataField="Thu" HeaderText="Thu" />
                                                <asp:BoundField DataField="Fri" HeaderText="Fri" />
                                                <asp:BoundField DataField="Sat" HeaderText="Sat" />
                                            </Columns>

                                            <EditRowStyle BorderStyle="None" />
                                            <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" HorizontalAlign="Center" />
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" 
                                                HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" 
                                                ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>
                                    
                                        <%--</asp:Panel>--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
