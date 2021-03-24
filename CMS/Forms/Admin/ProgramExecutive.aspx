<%@ Page Title="ProgramExecutive" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="ProgramExecutive.aspx.cs" Inherits="CMS.Forms.Admin.ProgramExecutive" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->
    <!--  For Tab Navigation Use This jQuery  -->
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS: compiled and minified -->
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Example plugin: Prettify -->
    <!-- Initialize Scripts -->
    <script type="">
        // Activate Google Prettify in this page
        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {
            // Add prettyprint class to pre elements
            $('pre').addClass('prettyprint');
        }); // end document.ready
    </script>

    <script type="text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmUpdate() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_ProgramExecutive" runat="server" align="center" Visible="true"
            Style="height: 897px; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>PROGRAM EXECUTIVE</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
                <div class="frmwidth" align="center">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Course</font>
                        </a></li>
                        <li><a href="#sp2" data-toggle="tab"><font color="blue">Branch</font></a></li>
                        <li><a href="#sp3" data-toggle="tab"><font color="blue">Class</font></a></li>
                        <li><%--<a href="#sp4" data-toggle="tab"><font color="blue">Division</font></a>--%></li>
                    </ul>
                    <div class="tab-content">
                        <div id="sp1" class="tab-pane active" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Course" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseName" runat="server" Text="  Course Name :"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCourseName" runat="server" ValidationGroup="ValidateCourse"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ErrorMessage="Please Enter Course Name"
                                                    ForeColor="red" ControlToValidate="TxtCourseName" TargetControlID="TxtCourseName"
                                                    ValidationGroup="ValidateCourse" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <%-- <asp:RegularExpressionValidator ID="revtxtCourseName" runat="server" ErrorMessage="Only character allowed" ControlToValidate="txtCourseName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[A-Za-z]+$" ValidationGroup="ValidateCourse"></asp:RegularExpressionValidator>
                                                --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseCode" runat="server" Text=" Course Code :" Visible="False"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCourseCode" runat="server" ValidationGroup="ValidateCourse" Visible="False"></asp:TextBox>
                                            </td>
                                            <td align="left">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNew" runat="server" Text="Add New" class="btn btn-primary" OnClick="btnNew_Click"
                                                    ValidationGroup="ValidateCourse" CausesValidation="false" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click"
                                                    ValidationGroup="ValidateCourse" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click" ValidationGroup="ValidateCourse" OnClientClick="ConfirmUpdate()" />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateCourse" OnClick="btnDelete_Click" OnClientClick="ConfirmDelete()" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                                    CausesValidation="false" OnClick="btnCancel_Click" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdCourse" runat="server" CellPadding="4" DataKeyNames="CourseId,CourseCode,CourseName"
                                                    Width="80%" OnPageIndexChanging="GrdCourse_PageIndexChanging" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                    BorderWidth="1px">
                                                    <Columns>
                                                        <%-- <asp:BoundField HeaderText="Course Id" DataField="CourseId" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="SR.NO">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnCourseName" runat="server" Text='<%#Eval("CourseName") %>'
                                                                    OnClick="lnkBtnCourseName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Course Code" DataField="CourseCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp2" class="tab-pane " align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Branch" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseB" runat="server" Text="Select Course :"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourseB" runat="server" OnSelectedIndexChanged="ddlCourseB_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="BranchValidation" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlCourseB" runat="server" ErrorMessage="Please select Course"
                                                    ControlToValidate="ddlCourseB" InitialValue="Select" ValidationGroup="BranchValidation"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBranchName" runat="server" Text="Branch Name :"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBranchName" runat="server" ValidationGroup="BranchValidation"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvBranchName" runat="server" ErrorMessage="Please Enter Branch Name"
                                                    ForeColor="red" ControlToValidate="TxtBranchName" TargetControlID="TxtBranchName"
                                                    ValidationGroup="BranchValidation" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <%--  <asp:RegularExpressionValidator ID="rfvtxtBranchName" runat="server" ErrorMessage="Only alphabet allowed" ControlToValidate="txtBranchName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[A-Za-z]+$" ValidationGroup="BranchValidation"></asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBranchCode" runat="server" Text="Branch Code :" Visible="False"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBranchCode" runat="server" ValidationGroup="BranchValidation" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewB" runat="server" Text="Add New" class="btn btn-primary" OnClick="btnNewB_Click"
                                                    ValidationGroup="BranchValidation" CausesValidation="false" />
                                                <asp:Button ID="btnSaveB" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="BranchValidation"
                                                    OnClick="btnSaveB_Click" />
                                                <asp:Button ID="btnUpdateB" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="BranchValidation" OnClick="btnUpdateB_Click" OnClientClick="ConfirmUpdate()" />
                                                <asp:Button ID="btnDeleteB" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="BranchValidation" OnClick="btnDeleteB_Click" OnClientClick="ConfirmDelete()" />
                                                <asp:Button ID="btnCancelB" runat="server" Text="Cancel" OnClick="btnCancelB_Click"
                                                    class="btn btn-primary" CausesValidation="false" ValidationGroup="BranchValidation" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdBranch" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="BranchId,BranchName,BranchCode"
                                                    Width="80%" OnPageIndexChanging="GrdBranch_PageIndexChanging" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                    BorderWidth="1px">
                                                    <Columns>
                                                         <asp:TemplateField HeaderText="SR.NO">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnBranchName" runat="server" Text='<%#Eval("BranchName") %>'
                                                                    OnClick="lnkBtnBranchName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Branch Code" DataField="BranchCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp3" class="tab-pane" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Class" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourse" runat="server" Text="Select Course :"></asp:Label>
                                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="ClassValidation" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ErrorMessage="Please select Course"
                                                    ControlToValidate="ddlCourse" ForeColor="Red" ValidationGroup="ClassValidation"
                                                    InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBranchC" runat="server" Text="Select Branch :"></asp:Label>
                                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranchC" runat="server" OnSelectedIndexChanged="ddlBranchC_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="ClassValidation" Width="180">
                                                    <asp:ListItem Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlBranchC" runat="server" ErrorMessage="Please select Branch"
                                                    ControlToValidate="ddlBranchC" ForeColor="Red" ValidationGroup="ClassValidation"
                                                    InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClassName" runat="server" Text="  ClassName :"></asp:Label>
                                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClassName" runat="server" ValidationGroup="ClassValidation"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvClassName" runat="server" ErrorMessage="Please Enter Class Name"
                                                    ForeColor="red" ControlToValidate="txtClassName" TargetControlID="txtClassName"
                                                    ValidationGroup="ClassValidation" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <%--<asp:RegularExpressionValidator ID="rfvtxtClassName" runat="server" ErrorMessage="Only alphabet allowed" ControlToValidate="txtClassName" ForeColor="Red" Display="Dynamic" ValidationExpression="^[A-Za-z]+$" ValidationGroup="ClassValidation"></asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClassCode" runat="server" Text=" Class Code :" Visible="False"></asp:Label>
                                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClassCode" runat="server" ValidationGroup="ClassValidation" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewC" runat="server" Text="Add New" class="btn btn-primary" OnClick="btnNewC_Click"
                                                    ValidationGroup="ClassValidation" CausesValidation="false" />
                                                <asp:Button ID="btnSaveC" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ClassValidation"
                                                    OnClick="btnSaveC_Click" />
                                                <asp:Button ID="btnUpdateC" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ClassValidation" OnClick="btnUpdateC_Click" OnClientClick="ConfirmUpdate()" />
                                                <asp:Button ID="btnDeleteC" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ClassValidation" OnClick="btnDeleteC_Click" OnClientClick="ConfirmDelete()" />
                                                <asp:Button ID="btnCancelC" runat="server" Text="Cancel" class="btn btn-primary"
                                                    ValidationGroup="ClassValidation" OnClick="btnCancelC_Click" CausesValidation="false" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdClass" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ClassId,ClassCode,ClassName"
                                                    Width="80%" OnPageIndexChanging="GrdClass_PageIndexChanging" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                    BorderWidth="1px">
                                                    <Columns>
                                                         <asp:TemplateField HeaderText="SR.NO">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Class Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnClassName" runat="server" Text='<%#Eval("ClassName") %>'
                                                                    OnClick="lnkBtnClassName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Class Code" DataField="ClassCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%-- <div id="sp4" class="tab-pane" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Division" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCourseD" runat="server" Text="Select Course :"></asp:Label>
                                                <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourseD" runat="server" OnSelectedIndexChanged="ddlCourseD_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="DivisionValidation" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlCourseD" runat="server" ErrorMessage="Please Select Course"
                                                    ForeColor="red" ValidationGroup="DivisionValidation" ControlToValidate="ddlCourseD"
                                                    TargetControlID="ddlCourseD" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBranchD" runat="server" Text="Select Branch :"></asp:Label>
                                                <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranchD" runat="server" OnSelectedIndexChanged="ddlBranchD_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="DivisionValidation" Width="180">
                                                    <asp:ListItem Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlBranchD" runat="server" ErrorMessage="Please Select Branch"
                                                    ForeColor="red" ControlToValidate="ddlBranchD" InitialValue="Select" TargetControlID="ddlBranchD"
                                                    ValidationGroup="DivisionValidation"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClassD" runat="server" Text="Select Class :"></asp:Label>
                                                <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlClassD" runat="server" OnSelectedIndexChanged="ddlClassD_SelectedIndexChanged"
                                                    AutoPostBack="true" ValidationGroup="DivisionValidation" Width="180">
                                                    <asp:ListItem Text="Select"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlClassD" runat="server" ErrorMessage="Please Select Class"
                                                    ForeColor="red" ControlToValidate="ddlClassD" ValidationGroup="DivisionValidation"
                                                    TargetControlID="ddlClassD" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDivisionName" runat="server" Text="DivisioName :" ValidationGroup="DivisionValidation"></asp:Label>
                                                <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDivisionName" runat="server" ValidationGroup="DivisionValidation"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDivision" runat="server" ErrorMessage="Please Enter Division Name"
                                                    ForeColor="red" ControlToValidate="txtDivisionName" TargetControlID="txtDivisionName"
                                                    Display="Dynamic" ValidationGroup="DivisionValidation"></asp:RequiredFieldValidator>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDivisionCode" runat="server" Text=" Division Code :"></asp:Label>
                                                <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDivisionCode" runat="server" ValidationGroup="DivisionValidation"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvtxtDivisionCode" runat="server" ErrorMessage="Please Enter Division Code"
                                                    ForeColor="red" ControlToValidate="txtDivisionCode" TargetControlID="txtDivisionCode"
                                                    ValidationGroup="DivisionValidation"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewD" runat="server" Text="New" class="btn btn-primary" OnClick="btnNewD_Click"
                                                    ValidationGroup="DivisionValidation" CausesValidation="false" />
                                                <asp:Button ID="btnSaveD" runat="server" Text="Save" class=" btn btn-primary" ValidationGroup="DivisionValidation"
                                                    OnClick="btnSaveD_Click" />
                                                <asp:Button ID="btnUpdateD" runat="server" Text="Update" class="btn btn-primary"
                                                    ValidationGroup="DivisionValidation" OnClick="btnUpdateD_Click" />
                                                <asp:Button ID="btnDeleteD" runat="server" Text="Delete" class="btn btn-primary"
                                                    ValidationGroup="DivisionValidation" OnClick="btnDeleteD_Click" />
                                                <asp:Button ID="btnCancelD" runat="server" Text="Cancel" class="btn btn-primary"
                                                    ValidationGroup="DivisionValidation" OnClick="btnCancelD_Click" CausesValidation="false" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 80%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdDivision" runat="server" CellPadding="4" ForeColor="#333333"
                                                    DataKeyNames="DivisionId,DivisionCode,DivisionName" Width="80%" OnPageIndexChanging="GrdDivision_PageIndexChanging"
                                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                                    BorderStyle="None" BackColor="White" BorderWidth="1px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Division Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnDivisionName" runat="server" Text='<%#Eval("DivisionName") %>'
                                                                    OnClick="lnkBtnDivisionName_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Division Code" DataField="DivisionCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>--%>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
