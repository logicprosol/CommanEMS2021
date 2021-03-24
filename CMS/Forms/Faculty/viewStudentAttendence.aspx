<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="viewStudentAttendence.aspx.cs" Inherits="CMS.Forms.Faculty.viewStudentAttendence" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
                <table border="0" width="100%" align="center">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>ViewStudentAttendanceRegister</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Width="920px">
                    <table border="0" width="90%" align="center">
                        <tr>
                            <td colspan="6" style="height: 20px"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourses" runat="server" Text=" Select Course:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourses" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text=" Select Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranches" runat="server" AutoPostBack="True"
                                    Width="150px" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged1">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblClasses" runat="server" Text=" Select Class:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True"
                                    Width="150px" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged1">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Default" Value="Default"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    InitialValue="0" ControlToValidate="ddlCourses" ErrorMessage="Please Select Course"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlBranches" ErrorMessage="Please Select Branch"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlClasses" ErrorMessage="Please Select Class"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSelectSubject" runat="server" Text="Select Subject:" Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSelectSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectSubject_SelectedIndexChanged" Width="150px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" colspan="2">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="150px">
                                    <asp:ListItem>Present</asp:ListItem>
                                    <asp:ListItem Selected="True">Absent</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="lblSelectDate0" runat="server" Text="Select Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSelectDate" runat="server" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtSelectDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtSelectDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSelectSubject" ErrorMessage="Please Select Subject" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center" class="auto-style1">
                                &nbsp;</td>
                            <td colspan="2" align="center" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtSelectDate" ErrorMessage="Please Select Date"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDivision" runat="server" Text=" Select Division:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDivision" runat="server" Visible="False" Width="150px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>



                            </td>
                            <td>
                                <asp:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txtTime"
                                    mask="99:99" messagevalidatortip="true" onfocuscssclass="MaskedEditFocus" oninvalidcssclass="MaskedEditError"
                                    masktype="Time" acceptampm="True" errortooltipenabled="True" />
                            
                            </td>
                            <td>
                                <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click" Text="Go" Width="100px" />
                            </td>

                            <td>
                                <asp:Label ID="lblTime" runat="server" Text="Time:" Visible="False"></asp:Label>
                            </td>
                            <td>&nbsp;
                                <asp:TextBox ID="txtTime" runat="server" Visible="False" Width="150px"></asp:TextBox>
                            </td>
                            <td></td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6"></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Panel ID="Panel2" runat="server" class=" well well-large" Width="95%" Height="650px">
                                            <div style="overflow: scroll; height: 650px;" >
                                    <asp:GridView ID="grdAttendance" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" EmptyDataText="Record not found" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Student Name" DataField="Studentname" ItemStyle-HorizontalAlign="Center" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Time" DataField="AttendanceTime" ItemStyle-HorizontalAlign="Center" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                        </Columns>
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" Font-Size="Medium" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                                </div>
                                    <%--<asp:GridView ID="grdAttendance" runat="server" AutoGenerateColumns="False" Width="99%"
                                        AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="4" EditRowStyle-Font-Names="Rows">
                                        <Columns>
                                            <asp:BoundField HeaderText="Student Id" DataField="UserCode" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Student Name" DataField="FullName" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Status" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rbtnlStatus" runat="server" RepeatDirection="Horizontal"
                                                        CssClass="radio" Width="150px" AutoPostBack="true" align="center">
                                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                                <ItemStyle Width="200px" />
                                            </asp:TemplateField>
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
                                    </asp:GridView>--%>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20px" colspan="6"></td>
                        </tr>
                      <%--  <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-primary" Visible="false"
                                     />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Class="btn btn-primary" Visible="false"
                                     />
                            </td>
                        </tr>--%>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
