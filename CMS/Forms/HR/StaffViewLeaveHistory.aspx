<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="StaffViewLeaveHistory.aspx.cs" Inherits="CMS.Forms.HR.StaffViewLeaveHistory" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 920px;">
                <asp:Panel ID="Panel_UploadDocument" runat="server" align="center" Visible="true"
                    Style="height: 897px; width: 915px; border: medium double#0C7BFA;">
                    <div style="width: 100%; height: auto;">
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>Staff Leave History</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                        
                       <table border="0" width="90%" align="center" cellspacing="2px">
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Select Department"></asp:Label>
                            <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Department" runat="server"  width="180" AutoPostBack="True" OnSelectedIndexChanged="DDL_Department_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td><!-- OnSelectedIndexChanged="DDL_Department_SelectedIndexChanged"-->
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="-1"
                                ControlToValidate="DDL_Department" ErrorMessage="Please Select Department !"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFacultyType" runat="server" Text="Faculty Type : "></asp:Label>
                            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbtnFacultyType" runat="server" RepeatDirection="Horizontal"
                                class="radio" Width="220px" OnSelectedIndexChanged="rbtnFacultyType_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Text="Teaching" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NonTeaching" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="rfvrbtnFacultyType" runat="server" ErrorMessage="Please Select Designation type!!!"
                                ControlToValidate="rbtnFacultyType" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Select Designation"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Designation" runat="server" OnSelectedIndexChanged="DDL_Designation_SelectedIndexChanged"
                                AutoPostBack="True"  width="180">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="-1"
                                ControlToValidate="DDL_Designation" ErrorMessage="Please Select Designation !"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Select Employee"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_EmoloyeeName" runat="server" OnSelectedIndexChanged="DDL_EmoloyeeName_SelectedIndexChanged"
                                AutoPostBack="True"  width="180">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="-1"
                                ControlToValidate="DDL_EmoloyeeName" ErrorMessage="Please Select employee !"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                           <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table> 

                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" height="600px">


                            <asp:GridView ID="grdStaffLeave" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="100%" EmptyDataText="No record found">
                                <Columns>
                                    <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" />
                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" />
                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" />
                                    <asp:BoundField DataField="TotalLeave" HeaderText="Total Day" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                    <asp:BoundField DataField="LeaveStatus" HeaderText="Status" />
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>


                        </asp:Panel>

                    </div>
                </asp:Panel>
            </div>
             <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
