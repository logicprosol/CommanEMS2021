<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="ComposeMessage.aspx.cs" Inherits="CMS.Forms.Faculty.ComposeMessage" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function CheckAllParent(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdParent.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
        function CheckAllStudent(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdStudent.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }

        }
        function CheckAllEmployee(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdEmployee.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function TestCheckBox() {
            if (Page_ClientValidate()) {
                var TargetBaseControl = document.getElementById('<%= GrdStudent.ClientID %>');
                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    var cell = TargetBaseControl.rows[1].cells;
                    var HTML = cell[0].innerHTML;
                    if (HTML.localeCompare("No Records Found")) {
                        //get all the control of the type INPUT in the base control.
                        var Inputs = TargetBaseControl.getElementsByTagName("input");

                        for (var n = 0; n < Inputs.length; ++n)
                            if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked)
                                return true;
                    }
                    else {
                        alert('No record found!');
                        return false;
                    }
                    alert('Select at least one student!');
                    return false;

                }

                TargetBaseControl = document.getElementById('<%= GrdParent.ClientID %>');
                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    var cell = TargetBaseControl.rows[1].cells;
                    var HTML = cell[0].innerHTML;
                    if (HTML.localeCompare("No Records Found")) {

                        //get all the control of the type INPUT in the base control.
                        var Inputs = TargetBaseControl.getElementsByTagName("input");

                        for (var n = 0; n < Inputs.length; ++n)
                            if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked)
                                return true;

                    }
                    else {
                        alert('No record found!');
                        return false;
                    }
                    alert('Select at least one Parent!');
                    return false;

                }

                TargetBaseControl = document.getElementById('<%= GrdEmployee.ClientID %>');
                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    // var data = TargetBaseControl.Rows[0].cells[0].innerText;//.toString();
                    // var data =  TargetBaseControl.rows[0].cells[0].textcontent.toString();

                    var cell = TargetBaseControl.rows[1].cells;
                    var HTML = cell[0].innerHTML;
                    if (HTML.localeCompare("No Records Found")) {
                        //get all the control of the type INPUT in the base control.
                        var Inputs = TargetBaseControl.getElementsByTagName("input");

                        for (var n = 0; n < Inputs.length; ++n)
                            if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked)
                                return true;
                    }
                    else {
                        alert('No record found!');
                        return false;
                    }
                    alert('Select at least one employee!');
                    return false;

                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 920px;">
                <asp:Panel ID="Panel_ComposeMessage" runat="server" align="center" Visible="true"
                    Style="height: 897px; width: 920px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>TEXT MESSAGE</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="width: 90%; height: 85px; margin-top: 10px;" align="center">
                        <table width="57%" align="center">
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblSender" runat="server" Text="Select Sender : "></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSender" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                        OnSelectedIndexChanged="ddlSender_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Employee" Value="Employee"></asp:ListItem>
                                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                        <asp:ListItem Text="Parent" Value="Parent"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlSender" runat="server" ErrorMessage="Please Select Sender"
                                        ForeColor="red" ControlToValidate="ddlSender" InitialValue="Select" TargetControlID="ddlSender"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel runat="server" ID="PanelSender" align="center" Visible="true" Style="height: 480px;
                        width: 80%;" class="well well-large">
                        <asp:Panel runat="server" ID="PanelParent" Visible="false">
                            <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                                <table width="70%" align="center">
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblParentCourse" runat="server" Text="Select Course : "></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlParentCourse" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlParentCourse_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlParentCourse" runat="server" ErrorMessage="Please Select Course"
                                                ForeColor="red" ControlToValidate="ddlParentCourse" InitialValue="-1" TargetControlID="ddlParentCourse"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblBranch" runat="server" Text="Select Branch : "></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlParentBranch" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlParentBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlParentBranch" runat="server" ErrorMessage="Please Select Branch"
                                                ForeColor="red" ControlToValidate="ddlParentBranch" InitialValue="-1" TargetControlID="ddlParentBranch"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblParentClass" runat="server" Text="Select Class : "></asp:Label>
                                            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlParentClass" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlParentClass_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlParentClass" runat="server" ErrorMessage="Please Select Class"
                                                ForeColor="red" ControlToValidate="ddlParentClass" InitialValue="-1" TargetControlID="ddlParentClass"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblParentDivision" runat="server" Text="Select Division : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlParentDivision" runat="server" AutoPostBack="true" Style="margin-top: 5px;">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <%-- <asp:RequiredFieldValidator ID="rfvddlParentDivision" runat="server" ErrorMessage="Please Select Division"
                                                    ForeColor="red" ControlToValidate="ddlParentDivision" InitialValue="-1" TargetControlID="ddlParentDivision"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 90%; height: 300px; margin-top: 10px;" align="center">
                                <table width="100%" align="left">
                                    <tr>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblParent" Text="Parent Details "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="GrdParent" runat="server" CellPadding="4" DataKeyNames="StudentName,ParentName,ParentMobile"
                                                Width="99%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdParent_PageIndexChanging"
                                                PageSize="2" AllowPaging="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Student Name" DataField="StudentName" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Parent Name" DataField="ParentName" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mobile No" DataField="ParentMobile" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAllParent" runat="server" Text="Select All" onclick="CheckAllParent(this)"
                                                                TextAlign="Left" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" />
                                                <EmptyDataRowStyle BorderStyle="None" />
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PanelStudent" Visible="false">
                            <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                                <table width="70%" align="center">
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblStudentCourse" runat="server" Text="Select Course : "></asp:Label>
                                            <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlStudentCourse" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlStudentCourse_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlStudentCourse" runat="server" ErrorMessage="Please Select Course"
                                                ForeColor="red" ControlToValidate="ddlStudentCourse" InitialValue="-1" TargetControlID="ddlStudentCourse"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblStudentBranch" runat="server" Text="Select Branch : "></asp:Label>
                                            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlStudentBranch" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlStudentBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlStudentBranch" runat="server" ErrorMessage="Please Select Branch"
                                                ForeColor="red" ControlToValidate="ddlStudentBranch" InitialValue="-1" TargetControlID="ddlStudentBranch"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblStudentClass" runat="server" Text="Select Class : "></asp:Label>
                                            <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlStudentClass" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlStudentClass_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlStudentClass" runat="server" ErrorMessage="Please Select Class"
                                                ForeColor="red" ControlToValidate="ddlStudentClass" InitialValue="-1" TargetControlID="ddlStudentClass"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblStudentDivision" runat="server" Text="Select Division : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlStudentDivision" runat="server" AutoPostBack="true" Style="margin-top: 5px;">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <%--<asp:RequiredFieldValidator ID="rfvddlStudentDivision" runat="server" ErrorMessage="Please Select Division"
                                                    ForeColor="red" ControlToValidate="ddlStudentDivision" InitialValue="Select"
                                                    TargetControlID="ddlStudentDivision" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 90%; height: 300px; margin-top: 10px;" align="center">
                                <table width="100%" align="left">
                                    <tr>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblStudent" Text="Student Details "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="StudentId,StudentName,Mobile"
                                                Width="100%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdStudent_PageIndexChanging"
                                                PageSize="2" AllowPaging="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Student ID" DataField="StudentId" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Student Name" DataField="StudentName" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Student Mobile" DataField="Mobile" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAllStudent" runat="server" Text="Select All" onclick="CheckAllStudent(this)"
                                                                TextAlign="Left" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" />
                                                <EmptyDataRowStyle BorderStyle="None" />
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PanelEmployee" Visible="false">
                            <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                                <table width="70%" align="center">
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department : "></asp:Label>
                                            <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ErrorMessage="Please Select Department"
                                                ForeColor="red" ControlToValidate="ddlDepartment" InitialValue="-1" TargetControlID="ddlDepartment"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100px">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation : "></asp:Label>
                                            <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDesignation" runat="server" ErrorMessage="Please Select Designation"
                                                ForeColor="red" ControlToValidate="ddlDesignation" InitialValue="Select" TargetControlID="ddlDesignation"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 90%; height: 300px; margin-top: 10px;" align="center">
                                <table width="100%" align="left">
                                    <tr>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblEmployee" Text="Employee Details "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="GrdEmployee" runat="server" CellPadding="4" DataKeyNames="EmployeeId,EmployeeName,Mobile"
                                                Width="100%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdEmployee_PageIndexChanging"
                                                PageSize="2" AllowPaging="true">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Employee ID" DataField="EmployeeId" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Employee Mobile" DataField="Mobile" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkboxSelectAllEmployee" runat="server" Text="Select All" onclick="CheckAllEmployee(this)"
                                                                    TextAlign="Left" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkbox" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAllEmployee" runat="server" Text="Select All" onclick="CheckAllEmployee(this)"
                                                                TextAlign="Left" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" />
                                                <EmptyDataRowStyle BorderStyle="None" />
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PanelMessage" align="center" Visible="true" Style="height: 200px;
                        width: 90%;">
                        <div style="width: 90%; height: 200px; margin-top: 10px;" align="center">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblMessage" Text="Message "></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                            <td align="left">
                                                <br />
                                            </td>
                                        </tr>--%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtMessage" runat="server" Rows="4" Columns="100" TextMode="MultiLine"
                                            Width="99%" Height="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSend" runat="server" class="btn btn-primary" Text="Send" OnClick="btnSend_Click"
                                            OnClientClick="javascript:return TestCheckBox();" CausesValidation="true" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
             <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>