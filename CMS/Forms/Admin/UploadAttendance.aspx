<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="UploadAttendance.aspx.cs" Inherits="CMS.Forms.Admin.UploadAttendance" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <%--<script type="text/javascript" language="javascript">
         function validate() {
             var uploadcontrol = document.getElementById('<%=AttFileUpload.ClientID%>').value;
             //Regular Expression for fileupload control.
             var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.mdb|.MDB)$/;
             if (uploadcontrol.length > 0) {
                 //Checks with the control value.
                 if (reg.test(uploadcontrol)) {
                     return true;
                 }
                 else {
                     //If the condition not satisfied shows error message.
                     alert("Only .mdb,.accdb files are allowed!");
                     return false;
                 }
             }
         } //End of function validate.
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_Semester" runat="server" Visible="true" Style="height: 900px;
            width: 900px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Upload Daily Attendance</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <table border="0" width="90%" align="center" cellspacing="2px">
                <tr>
                    <td colspan="3">
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblDataUpload" runat="server" Text="Choose MS-Access File"></asp:Label>
                        <asp:FileUpload ID="AttFileUpload" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="AttFileUpload"
                            Display="Dynamic" ErrorMessage="Please Upload a File!">
                        </asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator
                    id="revDataUpload" runat="server"
                    ErrorMessage="Only MS-Access Database(.mbd) files are allowed!"
                    ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.mdb|..accdb|.MDB|.ACCDB)$/"
                    ControlToValidate="AttFileUpload" CssClass="text-red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                        <%--OnClientClick="return validate();"--%>
                        <asp:Button ID="btnImportData" runat="server" class="btn btn-success" Text="Import"
                            OnClientClick="return validate();" OnClick="btnImportData_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdAttendanceReport" runat="server" CellPadding="4" ForeColor="#333333"
                            DataKeyNames="EmployeeId" Width="100%" OnPageIndexChanging="GrdAttendanceReport_PageIndexChanging"
                            AutoGenerateColumns="False" GridLines="None" AllowPaging="True" PageSize="15"
                            BorderColor="#0066FF" BorderStyle="Solid">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="Emp Code" DataField="EmployeeId" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="EmpName" HeaderText="Emp Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>--%>
                                <asp:BoundField DataField="AttendanceDate" HeaderText="Attendance Date" />
                                <asp:BoundField DataField="InTime" HeaderText="In Time" />
                                <asp:BoundField DataField="OutTime" HeaderText="Out Time" />
                                <asp:BoundField DataField="PunchRecords" HeaderText="Punching Records" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                            <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                            <EmptyDataRowStyle BorderStyle="None" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSave" Visible="false" runat="server" Text="Save" CausesValidation="false"
                            class="btn btn-primary" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>