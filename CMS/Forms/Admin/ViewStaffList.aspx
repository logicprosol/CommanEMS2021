<%@ Page Title="ViewStaff" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="ViewStaffList.aspx.cs" Inherits="CMS.Forms.Admin.ViewStaff" %>

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
            width: 80px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
       
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Staff List</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblDepartment" runat="server" Text="Select Course"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="203px" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="350px" BorderStyle="None">
                                    <asp:GridView ID="GrdStaff" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="EmpId,UserCode,StaffName,DOB,Email,Mobile,DateOfJoining" Width="100%" EmptyDataText="Record Not Found!">
                                        <Columns>
                                            <asp:BoundField DataField="UserCode" HeaderText="Staff Id" />
                                            <asp:BoundField DataField="StaffName" HeaderText="Staff Name" />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Dept." />
                                            <asp:BoundField DataField="DesignationType" HeaderText="Desig Type" />
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                                              <asp:BoundField DataField="Mobile" HeaderText="Mobile No." />
                                            <asp:BoundField DataField="Email" HeaderText="Email Id" />
                                            <asp:BoundField DataField="DOB" HeaderText="Birth Date" />
                                          
                                            
                                        </Columns>
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
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" Text="Download" OnClick="btnDownload_Click" Visible="False"  />
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
    
        </div>

</asp:Content>
