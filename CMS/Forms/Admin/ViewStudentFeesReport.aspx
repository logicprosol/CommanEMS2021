<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewStudentFeesReport.aspx.cs" Inherits="CMS.Forms.Admin.ViewStudentFeesReport" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div style="height: 900px; width: 900px;">
                        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px; width: 911px; border: medium double#0C7BFA;">
                            <table border="0" width="100%" align="center" cellspacing="2px">
                                <tr>
                                    <th style="background-color: #0C7BFA; color: White">
                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Student Fees Report </li>
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
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCourse" Text="Select Course :" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="180" height="28px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBranch" Text="Select Branch :" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="180" height="28px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ForeColor="Red" ErrorMessage="Please Select Course !!!"
                                                        ControlToValidate="ddlCourse" ValidationGroup="grpSave" InitialValue="0" Enabled="False"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ForeColor="Red" ErrorMessage="Please Select Branch !!!"
                                                        ControlToValidate="ddlBranch" ValidationGroup="grpSave" InitialValue="0" Enabled="False"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" Width="180" height="28px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAcademicYear" Text="Select AcademicYear : " runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" Width="180" height="28px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ForeColor="Red" ErrorMessage="Please Select Class !!!"
                                                        ControlToValidate="ddlClass" ValidationGroup="grpSave" InitialValue="0" Enabled="False"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlAcademicYear" runat="server" ForeColor="Red" ErrorMessage="Please Select AcademicYear !!!"
                                                        ControlToValidate="ddlAcademicYear" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td>
                                                    <asp:Label ID="Label4" Text="Select Fees Category :" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFeesCategory" runat="server" AutoPostBack="true" Width="180" height="28px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>--%>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">

                                                    <asp:Button ID="btnGo" runat="server" class="btn btn-primary"
                                                        Text="Go" ValidationGroup="grpSave" OnClick="btnGo_Click" Style="height: 28px ;width:80px" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="max-height: 640px; overflow: auto;">
                                                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Visible="False">
            
                                                        <%--<h2>Student Fees Report</h2>--%>
                                                        <asp:Label ID="Label2" runat="server" Text="Student Fees Report" Font-Bold="True" Font-Size="20px"></asp:Label>
                                                     
                                                        <asp:Label ID="lblStatus" runat="server" Text="Label" Font-Size="18px" Font-Bold="true" ForeColor="#0000ff"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="GridView1" runat="server" Width="100%" EmptyDataText="No record present">
                                                            <EmptyDataRowStyle ForeColor="#FF3300" HorizontalAlign="Center" />
                                                        </asp:GridView>
            
                                                    </asp:Panel>
                                                        
                                                        </div>
                                                    <br /><center>
                                                        <asp:Button ID="btnExport" runat="server" Text="Download" Visible="False" Style="height: 28px ;width:80px" OnClick="btnExport_Click" />
                                                        </center><br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </asp:Panel>
                    </div>

</asp:Content>
