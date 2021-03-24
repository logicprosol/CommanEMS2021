<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="Bonafied.aspx.cs" Inherits="CMS.Forms.HR.Bonafied" %>

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
            printWindow.document.write('<html><head><title>Bonafide Certificate</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 900px; border: medium double#0C7BFA;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="95%" align="center">
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="Label1" runat="server" Text="Bonafide Certificate" Font-Bold="True"
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
                                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Small" Text="Student Id:"></asp:Label>
                                                <asp:TextBox ID="txtStudentId" runat="server" AutoPostBack="true"></asp:TextBox>
                                                <asp:Button ID="btnGo" runat="server" Class="btn btn-primary" OnClick="btnGo_Click"
                                                    Text="Go" aupostback="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="panDetails" runat="server" Width="95%" HorizontalAlign="Center" Height="500px"
                                    class="well well-large" align="center">
                                    <!--Table For Student Data -->
                                    <table border="0" width="100%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Label ID="lblIssuedDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Application Date : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtTodayDate" runat="server" Width="180px" ValidationGroup="VG"  ></asp:TextBox>
                                                <asp:CalendarExtender ID="txtTodayDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtTodayDate">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblStudentName" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Student Name: "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtStudentName" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
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
                                                <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtStudentName"
                                                    ErrorMessage="Please Enter Student Name !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblDateOfAdmission0" runat="server" CssClass="formlable" Font-Bold="True" Text="Date of Admission : " ></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtDateOfAdmission0" runat="server" ReadOnly="True" ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblBehaviour0" runat="server" CssClass="formlable" Font-Bold="True" Text="Behaviour : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlBehaviour0" runat="server" Width="180px">
                                                    <asp:ListItem Enabled="true" Text="Select" Value="Select"> </asp:ListItem>
                                                    <asp:ListItem Text="Good" Value="Good"> </asp:ListItem>
                                                    <asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvDateOfAdmission0" runat="server" ControlToValidate="txtDateOfAdmission0" ErrorMessage="Please Enter Date of Admission !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvBehaviour0" runat="server" ControlToValidate="ddlBehaviour0" ErrorMessage="Please Select Behaviour !!!" ForeColor="red" InitialValue="Select" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblReason0" runat="server" CssClass="formlable" Font-Bold="True" Text="Reason : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtReaseon0" runat="server" Height="20px" ValidationGroup="VG"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvReaseon0" runat="server" ControlToValidate="txtReaseon0" ErrorMessage="Please Enter Reaseon !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click"
                                                    ValidationGroup="VG" Enabled="False" />
                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" class="btn btn-primary"
                                                    Enabled="False" />
                                                <asp:Button ID="btnPrint" runat="server" class="btn btn-primary" Text="Print" ValidationGroup="VG"
                                                    OnClick="btnPrint_Click" Enabled="False" />
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
                                                                    Text="Bonafide Certificate"></asp:Label>
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
                                                            <td style="text-align:left">
                                                                This is to certify that <asp:Label ID="lblname" runat="server" Text="Label" Font-Bold="True"></asp:Label> &nbsp He/She learning from <asp:Label ID="lblAdmissionDate" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                                &nbsp; is bonafide student of our&nbsp;<asp:Label ID="lblorganisation" runat="server" Text="Label" Font-Bold="True"></asp:Label>  &nbsp;School/College <br />
                                                            </td>
                                                        </tr>
                                                    </table>                                               
                                                  
                                                    <table align="center" border="0" width="99%">
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
                                                    <table align="center" border="0" width="99%">
                                                        <tr>
                                                            <td width="190px">&nbsp;</td>
                                                            <td width="190px"></td>
                                                            <td align="center">
                                                                <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Medium" Text="Principal,"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td align="center">
                                                                <asp:Label ID="lblCollageName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td></td>
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
                            <asp:Button ID="btnPrintLC" runat="server" Text="Print" class="btn btn-primary"  OnClientClick="return PrintPanel();"
                                OnClick="btnPrintLC_Click" />
                        </td>
                    </tr>
                </table>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
 