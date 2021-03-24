<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" Culture="en-US" CodeBehind="ViewStudentAdmission.aspx.cs" Inherits="CMS.Forms.Admin.ViewStudentAdmission" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdPendingAdmission.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                //GridView2.rows[i].cells[4].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
        function CheckAllStaff(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdPendingAdmission.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function TestCheckBox() {

            //if (Page_ClientValidate())
            {
                var TargetBaseControl = document.getElementById('<%= grdPendingAdmission.ClientID %>');

                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    //get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");

                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
                            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                            Inputs[n].checked) {
                            ConfirmCancelAdmissions();
                            //return true;
                        }
                        else {
                            alert("Select at least one Student!!!", "Warning");
                            return false;
                        }
                }
                else {
                    alert("No record present!!!", "Warning");
                    return false;
                }


            }
        }
        function TestCompleteAdmission() {


            {
                var TargetBaseControl = document.getElementById('<%= grdPendingAdmission.ClientID %>');

            if (TargetBaseControl != null) {
                var TargetChildControl = "chkbox";

                //get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");

                for (var n = 0; n < Inputs.length; ++n)
                    if (Inputs[n].type == 'checkbox' &&
                        Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                        Inputs[n].checked) {

                        return true;
                    }

                alert("Select at least one Student!!!", "Warning");
                return false;

            }
            else {
                alert("No record present!!!", "Warning");
                return false;
            }


        }
    }

    function ConfirmCancelAdmissions() {
        var TargetBaseControl = document.getElementById('<%= grdPendingAdmission.ClientID %>');

            if (TargetBaseControl != null) {
                var TargetChildControl = "chkbox";

                //get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");

                for (var n = 0; n < Inputs.length; ++n)
                    if (Inputs[n].type == 'checkbox' &&
                        Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                        Inputs[n].checked) {
                        var confirm_value = document.createElement("INPUT");
                        confirm_value.type = "hidden";
                        confirm_value.name = "confirm_value";
                        if (confirm("Do you want to Cancel Admissions?")) {
                            confirm_value.value = "Yes";
                            document.forms[0].appendChild(confirm_value);
                            return true;
                        }
                        else {
                            confirm_value.value = "No";
                            document.forms[0].appendChild(confirm_value);
                            return false;
                        }

                        //return true;
                    }

                alert("Select at least one Student!!!", "Warning");
                return false;
            }
            else {
                alert("No record present!!!", "Warning");
                return false;
            }
            //TestCheckBox();


            //var confirm_value = document.createElement("INPUT");
            //confirm_value.type = "hidden";
            //confirm_value.name = "confirm_value";
            //if (confirm("Do you want to Cancel Admissions?")) {
            //    confirm_value.value = "Yes";
            //} else {
            //    confirm_value.value = "No";
            //}
            //document.forms[0].appendChild(confirm_value);

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        //
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                var postBackElement = args.get_postBackElement();
                postBackElement.disabled = true;
                if (postBackElement.defaultValue == 'Delete' || postBackElement.defaultValue == 'Save' || postBackElement.defaultValue == 'Update' || postBackElement.defaultValue == 'Submit') {

                    popup.show();
                }
                postBackElement.disabled = false;
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Image ID="PleaseWaitImage" ImageUrl="~/images/please_wait.gif" AlternateText="Processing"
                runat="server" Height="42px" Width="121px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 1050px; width: 920px;">
                <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height: 1050px; width: 920px; border: medium double#0C7BFA;">
                    <table align="center" style="height: 30px; width: 100%;">
                        <tr>
                            <td style="background-color: #0C7BFA; color: White" align="center">
                                <ul class="nav nav-list">
                                    <li>Pending Admissions</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table align="center" width="750px">
                        <tr>
                            <td></td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" Text="Course"></asp:Label>
                                &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Course" runat="server" Width="180px" OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Branch"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Branch" runat="server" Width="180px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Class"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Class" runat="server" Width="180px" AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td></td>
                            <td>&nbsp;</td>
                            <td></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="170px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" Width="170px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Academic Year"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAcademicYearId" runat="server" Width="180px" DataSourceID="SqlDataSource2" DataTextField="AcademicYear" DataValueField="AcademicYearId">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCourse0" runat="server" ControlToValidate="ddlAcademicYearId" ErrorMessage="Please Select Academic Year!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <%--    <td>
                                <asp:Label ID="lbl1" runat="server" Text="FilterCriteria: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFilterCriteria" runat="server" Width="180px" AutoPostBack="true">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Admission ID" Value="AdmissionId"></asp:ListItem>
                                    <asp:ListItem Text="Student Name" Value="StudentName"></asp:ListItem>
                                    <asp:ListItem Text="Class" Value="Class"></asp:ListItem>
                                    <asp:ListItem Text="Fees Category" Value="Fees Category"></asp:ListItem>
                                      <asp:ListItem Text="Mobile" Value="Mobile"></asp:ListItem>
                                </asp:DropDownList>
                            </td>--%>
                            <%--<td>    <asp:Label ID="Label7" runat="server" Text="Value: "></asp:Label></td>
                            <td>

                                <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtFromDate"
                                    ControlToValidate="txtToDate" ErrorMessage="To Date Must Br greater than From Date"
                                    ForeColor="Red" Operator="GreaterThan" Type="Date"></asp:CompareValidator>
                                 <asp:TextBox ID="TxtCriteria" runat="server" Width="170px"></asp:TextBox>
                            </td>--%>
                            <td>

                            </td>
                            <td colspan="2"></td>
                            <td style="text-align:center">
                                 <asp:Button ID="btnGO" runat="server" class="btn btn-primary" OnClick="btnGO_Click" Text="GO" ValidationGroup="vg" />
                                <br />
                                &nbsp;&nbsp;&nbsp;</td>
                            <td>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT 0 [AcademicYearId], 'Select' [AcademicYear] union SELECT [AcademicYearId], [AcademicYear] FROM [tblAcademicYear] WHERE ([OrgId] = @OrgId)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="OrgId" SessionField="OrgId" Type="Decimal" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                    <table align="center" width="750px">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" Width="600px" runat="server" Font-Bold="true" ForeColor="Red" Text="Note:    List containing 'Add Fees' status can't be completed. Please add fees for Fees category and academic year"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Style="border-radius: 10px;" ID="AddFees" CssClass="btn-success" Text="Add Fees" OnClick="AddFees_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel_GridView" runat="server" Width="750px" class="well well-large"
                                    Height="500px">
                                    <div style="max-height: 480px; overflow: auto;">
                                        <asp:GridView ID="grdPendingAdmission" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            ShowHeaderWhenEmpty="True" CellPadding="4" Width="750px"
                                            BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px">
                                            <Columns>

                                                <asp:TemplateField ItemStyle-Width="40px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" Width="100px" Text="Select All"
                                                            onclick="CheckAll(this)" />
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbox" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AdmissionID" HeaderText="Admission ID" />
                                                <%-- <asp:BoundField DataField="AdmissionType" HeaderText="Admission Type" />--%>
                                                <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="Class" HeaderText="Class" />
                                                <asp:BoundField DataField="Category" HeaderText=" Fees Category" />
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                <asp:BoundField DataField="EMail" HeaderText="Email" Visible="false" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" />

                                                <%--      <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All" onclick=" CheckAll(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="No record present!"></asp:Label>
                                            </EmptyDataTemplate>
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
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>


                                        <td></td>
                                        <td align="center" style="margin-left: 150px;">
                                            <asp:Button ID="BtnApprove" runat="server" Visible="true" class="btn btn-success" OnClientClick="javascript:return TestCompleteAdmission()"
                                                Text="Complete Admissions" OnClick="BtnApprove_Click" ValidationGroup="vg" Style="margin-left: 150px;" />
                                            &nbsp;&nbsp;
                                <asp:Button ID="BtnDeny" runat="server" class="btn btn-danger" Visible="true" Text="Cancel Admissions" OnClick="BtnDeny_Click"
                                    OnClientClick="javascript:return ConfirmCancelAdmissions()" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td align="center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>















</asp:Content>
