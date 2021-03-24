<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Admin/Admin.Master" CodeBehind="PreviousYearPendingFeeReport.aspx.cs" Inherits="CMS.Forms.Admin.PreviousYearPendingFeeReport" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript">
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintFeesReceipt.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>


    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }

        .auto-style2 {
            margin-left: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 1000px; width: 920px;">
        <asp:Panel ID="Panel_Semester" runat="server" Visible="true" Style="height: auto; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Previous Year Fees Report</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_PayFees" runat="server" align="center" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnGetDetails" />--%>
                </Triggers>
                <ContentTemplate>
                    <table border="0" width="50%" align="center" cellspacing="2px">
                        <br />
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCourseDRP" runat="server" Text="Course : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranchDRP" runat="server" Text="Branch : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClassDRP" runat="server" Text="Class : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAcademicYearDRP" Width="150px" runat="server" Text="Academic Year : "></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" Width="180px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="180px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="180px" AutoPostBack="true">

                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: left">

                                            <asp:DropDownList ID="DDLAcademicYear" Width="150px" runat="server" ValidationGroup="GeneralDetails" AutoPostBack="true">
                                            </asp:DropDownList>


                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" CssClass="btn btn-primary" OnClick="btnGetDetails_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false" OnClick="btnNew_Click" />
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Text="Student Previous Year Fees Report:" Font-Size="Large"></asp:Label>
                            <asp:Label ID="lblstatus" runat="server" ForeColor="blue" Font-Size="Large"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_StudentFeesPaidDetails" runat="server" class="well well-large" ScrollBars="Auto" Height="300px">

                                    <asp:GridView ID="GrdFeesPaidDetails" runat="server" CellPadding="4"
                                        DataKeyNames="Studentid" Width="100%" EmptyDataText="Record Not Found"
                                        AutoGenerateColumns="false" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px" PageSize="8">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR.NO" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="StudentID" ItemStyle-HorizontalAlign="Center" DataField="Studentid">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="Student Name" ItemStyle-Width="220px" ItemStyle-HorizontalAlign="Center" DataField="Student">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Class" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" DataField="Class">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                               <asp:BoundField HeaderText="Total Fees" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" DataField="TotalAmount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                               <asp:BoundField HeaderText="Paid Fees" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" DataField="paidAmount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                               <asp:BoundField HeaderText="Due Fees" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" DataField="pendingAmount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            
                                        </Columns>
                                         <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                         
                                          <EmptyDataRowStyle BorderStyle="None" />
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399"
                                            HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True"
                                            ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
