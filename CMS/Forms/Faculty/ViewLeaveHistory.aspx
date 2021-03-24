<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="ViewLeaveHistory.aspx.cs" Inherits="CMS.Forms.Faculty.ViewLeaveHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->

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
                                        <li><i class="icon-book"></i>Leave History</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 90%; height: 700px; margin-top: 10px; overflow: scroll;" align="center">
                        
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" height="600px">


                            <asp:GridView ID="grdStaffLeave" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="100%" EmptyDataText="No record present">
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
                                <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" Font-Size="Medium" />
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
