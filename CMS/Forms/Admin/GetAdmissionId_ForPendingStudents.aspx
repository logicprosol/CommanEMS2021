<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" Culture="en-US" CodeBehind="GetAdmissionId_ForPendingStudents.aspx.cs" Inherits="CMS.Forms.Admin.GetAdmissionId_ForPendingStudents" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdPendingAdmission.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
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
                            Inputs[n].checked)
                            return true;
                    alert("Select at least one Student!!!", "Warning");
                    return false;
                }
                else {
                    alert("No record present!!!", "Warning");
                    return false;
                }

               <%-- TargetBaseControl = document.getElementById('<%= grdPendingAdmission.ClientID %>');

                //get target child control.

                var TargetChildControl = "chkbox";

                //get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");

                for (var n = 0; n < Inputs.length; ++n)
                    if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                        return true;

                alert("Select at least one Student!!!", "Warning");

                return false;--%>
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
                        } else {
                            confirm_value.value = "No";
                        }
                        document.forms[0].appendChild(confirm_value);
                        return true;
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
                                <asp:Label ID="Label1" runat="server" Text="Branch :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Branch" runat="server" Width="180px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Class :"></asp:Label>
                                &nbsp;&nbsp;
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
                            <td colspan="1">
                                <asp:TextBox ID="txtToDate" runat="server" Width="170px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnGO" runat="server" class="btn btn-primary" Text="GO" OnClick="btnGO_Click" />
                           
                            </td>
                        </tr>
                        <tr>
                            
                            
                            
                        </tr>
                    </table>
                    <table align="center" width="750px">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td width="60%">
                                            <asp:Label ID="Label6" Width="500px" runat="server" ForeColor="Red" Text="Note: For complet admission copy AdmissionId & click on Get Admission & Pay Fees Button"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnPayFeeForgetAdmission" runat="server" Style="border-radius: 10px;" class="btn btn-primary" Text="Get Admission & Pay fee" OnClick="btnPayFeeForgetAdmission_Click" />
                                        </td>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;
                                            <asp:Button runat="server" Style="border-radius: 10px;" ID="AddFees" CssClass="btn btn-primary" Text="Add Fees" OnClick="AddFees_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                         <%--<td>

                                            <asp:Label ID="Label5" Width="500px" runat="server" ForeColor="Red" Text="Note:   'Add Fees' status can't be completed.  Please add fees for Fees category and academic year"></asp:Label>
                                        </td>
                                        
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_GridView" runat="server" Width="750px" class="well well-large"
                                    Height="800px">
                                    <div style="max-height: 800px; overflow: auto;">
                                        <asp:GridView ID="grdPendingAdmission" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            ShowHeaderWhenEmpty="True" CellPadding="4" Width="720px"
                                            BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SR.NO">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AdmissionID" HeaderText="Admission ID" />
                                                <%-- <asp:BoundField DataField="AdmissionType" HeaderText="Admission Type" />--%>
                                                <asp:BoundField DataField="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="class" HeaderText="Class" />
                                                <asp:BoundField DataField="Category" HeaderText="Fees Category" />
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="40px">


                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>


                                                <%--      <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All" onclick=" CheckAll(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>--%>


                                                <%--  <asp:TemplateField ItemStyle-Width="40px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server" Width="100px" Text="Select All"
                                                        onclick="CheckAll(this)" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbox" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
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
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
