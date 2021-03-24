<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Experienced_Certificate.aspx.cs" Inherits="CMS.Forms.Admin.Experienced_Certificate" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=PnlStudentLeavingCertificate.ClientID %>");
            var printWindow = window.open('', '', 'height=500,width=900,left=170');
            printWindow.document.write('<html><head><title>Experience Certificate</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

    <script type = "text/javascript">
        
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

    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 900px; border: medium double#0C7BFA;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="95%" align="center">
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="Label1" runat="server" Text="Experience Certificate" Font-Bold="True"
                                Font-Size="Medium" Font-Underline="True"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <%-- <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="10px" class="pagination-right" colspan="5">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="panSelect" runat="server">
                                <asp:Panel ID="Panel2" runat="server" Width="95%" HorizontalAlign="Center" Height="40px"
                                    class="well well-large" align="center">
                                    <table border="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Small" Text="Employee Id:"></asp:Label>
                                                <asp:TextBox ID="txtEmployeeId" runat="server" AutoPostBack="true" OnTextChanged="txtEmployeeId_TextChanged"></asp:TextBox>
                                                <asp:Button ID="btnGo" runat="server" Class="btn btn-primary" OnClick="btnGo_Click"
                                                    Text="Go" aupostback="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="panDetails" runat="server" Width="95%" HorizontalAlign="Center" Height="500px"
                                    class="well well-large" align="center" Visible="false">
                                    <!--Table For Student Data -->
                                    <table border="0" width="100%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Label ID="lblIssuedDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkDuplicateCopy" TextAlign="Right" Width="150px" runat="server"
                                                    AutoPostBack="true" class="radio" Text="Duplicate Copy" OnCheckedChanged="chkDuplicateCopy_CheckedChanged" Visible="false"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Application Date : "></asp:Label>
                                                <asp:Label ID="lblReq1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtTodayDate" runat="server" Width="203px" ValidationGroup="VG"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtTodayDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtTodayDate">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblEmployeeName" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Employee Name: "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmployeeName" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvApplicationDate" runat="server" ControlToValidate="txtTodayDate"
                                                    ErrorMessage="Please Enter Date!!!" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtEmployeeId"
                                                    ErrorMessage="Please Enter Employee Name !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblProgress0" runat="server" CssClass="formlable" Font-Bold="True" Text="Designation : "></asp:Label>
                                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:DropDownList ID="ddlProgress0" runat="server" ValidationGroup="VG" Width="222px">
                                                    <asp:ListItem Enabled="true" Text="Select" Value="Select"></asp:ListItem>
                                                    <asp:ListItem Text="Faculty" Value="Faculty"></asp:ListItem>     
                                                    <asp:ListItem Text="Inventor" Value="Inventor"></asp:ListItem>
                                                    <asp:ListItem Text="Liabrarian" Value="Liabrarian"></asp:ListItem>
                                                    <asp:ListItem Text="Clerk/HR" Value="Clerk/HR"></asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDOB" runat="server" CssClass="formlable" Font-Bold="True" Text="Date of Joining : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDOB" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="center">
                                            </td>
                                         <%--   <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                                                    ErrorMessage="*" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rvcDOB" runat="server" ControlToValidate="txtDOB"
                                                    ValidationGroup="VG" ErrorMessage="Please Enter Date of Joining in dd/MM/yyyy!!!"
                                                    ForeColor="Red" ValidationExpression="\d{2}[/-]\d{2}[/-]\d{4}"></asp:RegularExpressionValidator>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                            </td>
                                            <td align="center" style="text-align: left" class="auto-style1">
                                                </td>
                                            <td align="center" class="auto-style1">
                                            </td>
                                            <td align="left" class="auto-style1">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click"
                                                    ValidationGroup="VG"  />
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" Visible="false" OnClientClick = "ConfirmUpdate()" />
                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" class="btn btn-primary"
                                                     />
                                                <asp:Button ID="btnPrint" runat="server" class="btn btn-primary" Text="Print" ValidationGroup="VG"
                                                    OnClick="btnPrint_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panPrint" Width="95%" HorizontalAlign="Center" runat="server" class="well well-large"
                                align="center">
                                <div>
                                    <asp:Panel ID="PnlStudentLeavingCertificate" HorizontalAlign="Center" runat="server"
                                        Width="90%" Visible="false">
                                        <table width="90%" align="center" style="border: 1px solid black">
                                            <tr>
                                                <td>
                                                    <table width="99%" align="center">
                                                        <tr>
                                                            <td rowspan="3" align="right" width="50px">
                                                                <asp:Image ID="imgClgLogo" runat="server" Height="60px" Width="70px" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblTrustName" runat="server" Height="16px" Style="font-size: 10px;
                                                                    color: #292A0A;" Width="150px" ForeColor="White"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblCollageFullName" runat="server" Style="color: #084B8A; font-size: 15px;
                                                                    text-align: justify;" ForeColor="White"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblAddress" runat="server" Font-Size="Smaller" Style="font-size: xx-small"></asp:Label>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                <%-- <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Style="text-decoration: underline"
                                                                    Text="Experience Certificate"></asp:Label>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblDuplicateCopy" runat="server" Font-Bold="True" Text="Duplicate Copy"
                                                                    Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label36" runat="server" BorderStyle="None" Text="No:"></asp:Label>
                                                                <asp:Label ID="lblNo" runat="server" BorderStyle="None"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="Label7" runat="server" Text="Date:"></asp:Label>
                                                                <asp:Label ID="lblTodayDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                   
                                                    <br />
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                <p style="text-align:justify">
                                                                    This is to certify that Mr\Ms. <asp:Label ID="lblname" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                                     working with <asp:Label ID="lblorganisation" runat="server" Text="Label" Font-Bold="True"></asp:Label> from <asp:Label ID="lblJoiningDate" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                                     To <asp:Label ID="lblApplDate" runat="server" Text="Label" Font-Bold="True"></asp:Label> as a <asp:Label ID="LblDesignation" runat="server" Text="Label" Font-Bold="True"></asp:Label>. He/She is leaving his/her job only on his/her own decision and for attempting opportunities with a better profile.</p>
                                                                <p style="text-align:justify">
                                                                    <br />
                                                                    We wish him/her all the best in his/her future endeavor.
                                                                </p>
                                                                <br />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                           
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                   
                                                                <div>
                                                                <asp:Label ID="Label33" runat="server" Text="Note :  Certified that above information is accordance with the School."></asp:Label>
                                                                </div>
                                              
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" width="99%" align="center">
                                                        <tr>
                                                            <td width="190px">
                                                            </td>
                                                            <td width="190px">
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Medium" Text="Principal,"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblCollageName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblCollageAddress" runat="server" Font-Size="Smaller" Style="font-size: xx-small"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnPrintLC" runat="server" Text="Print" class="btn btn-primary"
                                OnClientClick="return PrintPanel();" />
                        </td>
                    </tr>
                </table>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>