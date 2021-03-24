<%@ Page Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    Culture="en-IN" CodeBehind="LeaveApplication.aspx.cs" Inherits="CMS.Forms.Faculty.LeaveApplication" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            margin-top: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 890px; width: 910px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Leave Application</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_LeaveApplication" runat="server" align="center"
                UpdateMode="Conditional">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                </Triggers>
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="Leave Application ID : " Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblLeaveApplicationId" runat="server" Font-Bold="true" Text="1" Visible="false"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Application Date : " Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblApplicationDate" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label3" runat="server" Text="Balance Leave" Font-Bold="True" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:GridView ID="GrdLeaveType" runat="server" AutoGenerateColumns="false" BorderColor="#3366CC"
                                    BorderStyle="None" CellPadding="4" EmptyDataText="No Records Found !" EmptyDataRowStyle-HorizontalAlign="Center"
                                    Width="60%" BackColor="White" BorderWidth="1px" Visible="False">
                                    <Columns>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Leave Id" DataField="LeaveId"
                                            Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Leave Code" DataField="LeaveCode">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Leave Name" DataField="LeaveName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Balance Leave" DataField="BalanceLeave">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label4" runat="server" Text="From : " Font-Bold="true"></asp:Label>
                                            <asp:TextBox ID="txtFrom" runat="server" OnTextChanged="txtFrom_TextChanged" AutoPostBack="true"
                                                Width="120px" ValidationGroup="VG"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrom"
                                                Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvTxtFrom" runat="server" Display="Dynamic" ErrorMessage="Select From Date"
                                                ControlToValidate="txtFrom" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label6" runat="server" Text="To :" Font-Bold="true"></asp:Label>
                                            <asp:TextBox ID="txtTo" runat="server" OnTextChanged="txtTo_TextChanged" AutoPostBack="true"
                                                Width="120px" ValidationGroup="VG"></asp:TextBox>
                                            <br />
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvTxtTo" Display="Dynamic" runat="server" ErrorMessage="Select To Date"
                                                ControlToValidate="txtTo" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="comDate" Display="Dynamic" runat="server" ErrorMessage=" Please Enter From Date Less Than To Date !!!"
                                                ControlToCompare="txtTo" ControlToValidate="txtFrom" CultureInvariantValues="True"
                                                Operator="LessThanEqual" Type="Date" ValidationGroup="VG"></asp:CompareValidator>
                                        </td>

                                        <td align="center">
                                            <asp:Label ID="lblReason0" runat="server" Text="Leave Type : " Font-Bold="true"></asp:Label>
                                            <asp:DropDownList runat="server" ID="drpLeaveType">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>Sick Leave</asp:ListItem>
                                                <asp:ListItem>Casual Leave</asp:ListItem>
                                                <asp:ListItem>Privilege Leave</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:TextBox ID="txtleaveType" runat="server" placeholder="eg. Sick Leave"></asp:TextBox>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblReason" runat="server" Text="Reason : " Font-Bold="true"></asp:Label>
                                <asp:Label ID="lbl1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="70%" Height="70px"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="rfvReason" runat="server" ErrorMessage="Enter Reason !!!"
                                    ControlToValidate="txtReason" ValidationGroup="VG" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                              <td align="center">
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="VG" />
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="overflow: scroll; height: 400px">
                                    <asp:GridView ID="GrdLeaveApplication" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style1" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="Please Select From And To Dates !" OnPageIndexChanging="GrdLeaveApplication_PageIndexChanging" OnRowDataBound="GrdLeaveApplication_RowDataBound" OnSelectedIndexChanged="GrdLeaveApplication_SelectedIndexChanged" PageSize="12" Width="95%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' Width="80px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Full / Half" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rbtFullHalf" runat="server" AutoPostBack="true" CssClass="radio" Font-Size="10px" Height="16px" OnTextChanged="rbtnFullHalf_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedValue='<%# Bind("Full_Half")%>' Width="114px">
                                                        <asp:ListItem Selected="True" Text="Full" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Half" Value="2"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Leave Type" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlLeaveType" runat="server" Font-Size="10px" ValidationGroup="VG"
                                                    Width="100px" Height="25px">
                                                   
                                                    <asp:ListItem>Casual Leave</asp:ListItem>
                                                    <asp:ListItem Value="PrivilegeLeave">Privilege Leave</asp:ListItem>
                                                    <asp:ListItem Value="SickLeave">Sick Leave</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                            
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                        </Columns>
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                        <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label10" runat="server" Text="Total Leave : "></asp:Label>
                                <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                          
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
