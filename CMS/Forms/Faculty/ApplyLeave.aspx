<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"  CodeBehind="ApplyLeave.aspx.cs" Inherits="CMS.ApplyLeave" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" align="center">
            <tr>
                <th style="background-color: #0C7BFA; color: White; width: 900px">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>Apply For Leave</li>
                    </ul>
                </th>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Width="700px" align="center" class="well well-large">
                        <table align="center" width="650px">
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="Label8" runat="server" Text="Application ID :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApplicationID" runat="server" Text="0000" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblDate" runat="server" Text="Application Date :" Style="font-weight: 700"></asp:Label>
                                    <asp:Label ID="lblCurrentDate" runat="server" Text="12/12/2012"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="100px">
                                    <asp:Label ID="Label1" runat="server" Text="Select Leave Type :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLSelectLeaveType" runat="server">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="CL" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="ML" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Leave Type"
                                        InitialValue="0" ForeColor="Red" ControlToValidate="DDLSelectLeaveType"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Balance :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBalance" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Half/Full Day :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnHalfDay" runat="server" RepeatDirection="Horizontal"
                                        Width="210px" class="radio" align="center">
                                        <asp:ListItem Text="Half Day" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Full Day" Value="1" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Subject :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Subject"
                                        ForeColor="Red" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="From Date :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select  Date"
                                        ForeColor="Red" ControlToValidate="txtFromDate"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="To Date :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                        Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtToDate"
                                        Display="Dynamic" ErrorMessage="Please Select To Date Less Than From Date" ForeColor="Red"
                                        ControlToCompare="txtFromDate" Operator="GreaterThan">
                                    </asp:CompareValidator>
                                    <%--                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtEndDate" Type="Date" Display="Dynamic" ErrorMessage="Dates out of range" ForeColor="Red"  EnableClientScript="False"></asp:RangeValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Total Leaves :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDays" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Reason :" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Leave Reason"
                                        ForeColor="Red" ControlToValidate="txtReason"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit0" runat="server" class="btn btn-primary" Text="Submit"
                                        OnClick="btnSubmit0_Click" />
                                    &nbsp; &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <%--     style=" background-color:Background; border: medium double#0C7BFA; color:White; font-size:20px; width:900px";--%>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>