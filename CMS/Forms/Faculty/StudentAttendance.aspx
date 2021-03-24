<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="StudentAttendance.aspx.cs" Inherits="CMS.Forms.Faculty.StudentAttendance" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function CheckAllStatus(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdAttendance.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
                
            }
        }

    </script>
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
                                <li><i class="icon-book"></i>StudentAttendanceRegister</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Width="920px">
                    <table border="0" width="90%" align="center">
                        <tr>
                            <td colspan="6" style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourses" runat="server" Text=" Select Course:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourses" runat="server" Width="150px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text=" Select Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranches" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblClasses" runat="server" Text=" Select Class:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Default" Value="Default"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    InitialValue="0" ControlToValidate="ddlCourses" ErrorMessage="Please Select Course"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlBranches" ErrorMessage="Please Select Branch"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlClasses" ErrorMessage="Please Select Class"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSelectSubject" runat="server" Text="Select Subject:" Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSelectSubject" runat="server" AutoPostBack="true" DataTextField="SubjectName" DataValueField="SubjectId" OnSelectedIndexChanged="ddlSelectSubject_SelectedIndexChanged" Width="150px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblTime" runat="server" Text="Time:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTime" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblSelectDate0" runat="server" Text="Select Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSelectDate" runat="server" Width="150px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtSelectDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtSelectDate"  >
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSelectSubject" ErrorMessage="Please Select Subject" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:maskededitvalidator ID="MaskedEditValidator6" runat="server" controlextender="MaskedEditExtender1" controltovalidate="txtTime" display="Dynamic" emptyvalueblurredtext="Please Insert Time" emptyvaluemessage="Time is required" invalidvalueblurredmessage="Invalid Time" invalidvaluemessage="time is invalid" isvalidempty="False" tooltipmessage="Input time" />
                                <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click" Text="Go" Width="100px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtSelectDate" ErrorMessage="Please Select Date"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDivision" runat="server" Text=" Select Division:" Visible="False"></asp:Label>
                            </td>
                            <td>
<%--                                <asp:DropDownList ID="ddlTime" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
                                <asp:DropDownList ID="ddlDivision" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" Visible="False" Width="150px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                              <td>
                                <asp:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txtTime"
                                    mask="99:99" messagevalidatortip="true" onfocuscssclass="MaskedEditFocus" oninvalidcssclass="MaskedEditError"
                                    masktype="Time" acceptampm="True" errortooltipenabled="True" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div style="overflow: scroll; height:550px ">
                                    <asp:Label ID="Note" Text="Note :  " runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                    <asp:Label ID="Note0" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#003399" Text="Select Present Students"></asp:Label>
                                    <br />
                                <asp:Panel ID="Panel2" runat="server" class=" well well-large" Width="95%" Height="550px"  >
                                    
                                    <asp:GridView ID="grdAttendance" runat="server" AutoGenerateColumns="False" Width="99%" PageSize="7" BackColor="White" BorderColor="#3366CC" BorderStyle="None" OnPageIndexChanging="grdAttendance_PageIndexChanging"
                                        BorderWidth="1px" CellPadding="4" EditRowStyle-Font-Names="Rows">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Status" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All" onclick=" CheckAllStatus(this)" />
                                                        </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rbtnlStatus" runat="server" RepeatDirection="Horizontal"
                                                        CssClass="radio" Width="150px" AutoPostBack="true" align="center" Visible="False">
                                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:CheckBox ID="chkboxStatus" runat="server" />
                                                </ItemTemplate>
                                                 <HeaderStyle Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Roll No" DataField="RollNo" ItemStyle-HorizontalAlign="Center" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Student Name" DataField="FullName" ItemStyle-HorizontalAlign="Center" >
                                               <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                               <asp:BoundField HeaderText="Mobile" DataField="Mobile" ItemStyle-HorizontalAlign="Center" >

                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                           
                                            
                                             <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                        </Columns>
                                        <EditRowStyle Font-Names="Rows" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20px" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Class="btn btn-primary" Visible="false"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Class="btn btn-primary" Visible="false"
                                    OnClick="btnUpdate_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>