<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="backdatedlc.aspx.cs" Inherits="CMS.Forms.Admin.backdatedlc" %>
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
            printWindow.document.write('<html><head><title>Leaving Certificate</title>');
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                <table width="95%" align="center">
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="Label1" runat="server" Text="Leaving Certificate" Font-Bold="True"
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
                                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Small" Text="Enter Student User Code"></asp:Label>
                                                <asp:TextBox ID="txtStudentId" runat="server" AutoPostBack="true" OnTextChanged="txtStudentId_TextChanged" ></asp:TextBox>
                                                <asp:Button ID="btnGo" runat="server" Class="btn btn-primary" 
                                                    Text="Go"  OnClick="btnGo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              <%--  <asp:Panel ID="panDetails" runat="server" Width="95%" HorizontalAlign="Center" Height="500px"
                                    class="well well-large" align="center" >--%>
                                    <!--Table For Student Data -->
                                    <table border="0" width="100%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Label ID="lblIssuedDate" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:CheckBox ID="chkDuplicateCopy" TextAlign="Right" Width="150px" runat="server"
                                                    AutoPostBack="true" class="radio" Text="Duplicate Copy" />
                                            </td>
                                        </tr>










                                           <tr>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Application Date : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtusercode" runat="server" Width="203px" ValidationGroup="VG" ReadOnly="true"></asp:TextBox>
                                             
                                            </td>
                                              
                                            
                                        </tr>



                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblApplicationDate" runat="server" CssClass="formlable" Font-Bold="True" 
                                                    Text="Application Date : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtTodayDate" runat="server" Width="203px" ValidationGroup="VG"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtTodayDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtTodayDate">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblStudentName" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Student Name: "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtStudentName" runat="server" ValidationGroup="VG" ></asp:TextBox>
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
                                                <asp:Label ID="lblStudentCaste" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Student Caste: "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtStudentCaste" runat="server" ValidationGroup="VG" 
                                                    ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblNationality" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Nationality : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNationality" runat="server" ValidationGroup="VG" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvStudentCaste" runat="server" ControlToValidate="txtStudentCaste"
                                                    ErrorMessage="Please Enter Student Caste !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="txtNationality"
                                                    ErrorMessage="Please Enter Nationality !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblBirthPlace" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Birth Place : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtBirthPlace" runat="server" ValidationGroup="VG" ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDOB" runat="server" CssClass="formlable" Font-Bold="True" Text="Date of Birth : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDOB" runat="server" ValidationGroup="VG" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvBirthPlace" runat="server" ControlToValidate="txtBirthPlace"
                                                    ErrorMessage="Please Enter Birth Place !!!" ForeColor="red" ValidationGroup="StudentInfo"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                                                    ErrorMessage="*" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rvcDOB" runat="server" ControlToValidate="txtDOB"
                                                    ValidationGroup="VG" ErrorMessage="Please Enter Date of Birth in dd/MM/yyyy!!!"
                                                    ForeColor="Red" ValidationExpression="\d{2}[/-]\d{2}[/-]\d{4}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblLastSchoolAttended" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Last School Attended : " ValidationGroup="VG"></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtLastSchoolAttended" runat="server" ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDateOfAdmission" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Date of Admission : " ValidationGroup="VG"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDateOfAdmission" runat="server" ValidationGroup="VG" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvLastSchoolAttended" runat="server" ControlToValidate="txtLastSchoolAttended"
                                                    ErrorMessage="Please Enter Last School Attended !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvDateOfAdmission" runat="server" ControlToValidate="txtDateOfAdmission"
                                                    ErrorMessage="Please Enter Date of Admission !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblProgress" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Progress : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:DropDownList ID="ddlProgress" runat="server" ValidationGroup="VG" Width="222px">
                                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"></asp:ListItem>
                                                    <asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
                                                    <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                                                    <asp:ListItem Text="Fair" Value="Fair"></asp:ListItem>
                                                    <asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblBehaviour" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Behaviour : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlBehaviour" runat="server" ValidationGroup="VG" Width="222px">
                                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"> </asp:ListItem>
                                                    <asp:ListItem Text="Good" Value="Good"> </asp:ListItem>
                                                    <asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvProgress" runat="server" ControlToValidate="ddlProgress"
                                                    InitialValue="Select" ErrorMessage="Please Select Progress !!!" ForeColor="red"
                                                    ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvBehaviour" runat="server" ControlToValidate="ddlBehaviour"
                                                    InitialValue="Select" ErrorMessage="Please Select Behaviour !!!" ForeColor="red"
                                                    ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblDateOfLeaving" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Date of Leaving : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtDateOfLeaving" runat="server" ></asp:TextBox>
                                                <asp:CalendarExtender ID="txtDateOfLeaving_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtDateOfLeaving">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblYearOfStudying" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Year of Studying : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtYearOfStudying" runat="server" ValidationGroup="VG" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvDateOfLeaving" runat="server" ControlToValidate="txtDateOfLeaving"
                                                    ErrorMessage="Please Enter Date of Leaving !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator" runat="server" ControlToCompare="txtDateOfLeaving"
                                                    ValidationGroup="VG" ControlToValidate="txtYearOfStudying" ErrorMessage="Enter Valid Date !!!"
                                                    ForeColor="Red" Operator="LessThan" Type="Date"></asp:CompareValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvYearOfStudying" runat="server" ControlToValidate="txtYearOfStudying"
                                                    ErrorMessage="Please Enter Year of Studying !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblReason" runat="server" CssClass="formlable" Font-Bold="True" Text="Reason : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtReaseon" runat="server" Height="20px" ValidationGroup="VG"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblRemarks" runat="server" CssClass="formlable" Font-Bold="True" Text="Remarks : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRemarks" runat="server" Height="20px" ValidationGroup="VG"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvReaseon" runat="server" ControlToValidate="txtReaseon"
                                                    ErrorMessage="Please Enter Reason !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks"
                                                    ErrorMessage="Please Enter Remarks !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" 
                                                    ValidationGroup="VG" OnClick="btnSave_Click"  />
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" 
                                                    Enabled="False"  />
                                                <asp:Button ID="btnClear" runat="server"  Text="Clear" class="btn btn-primary"
                                                    Enabled="False" />
                                                <asp:Button ID="btnPrint" runat="server" class="btn btn-primary" Text="Print" ValidationGroup="VG"
                                                   Enabled="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                           <%-- </asp:Panel>--%>
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
                                                                    Text="Leaving Certificate"></asp:Label>
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
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text="No Change in any entry is this certificate shall be made expect by the authority issuing it and"></asp:Label>
                                                                <asp:Label ID="Label9" runat="server" Text="any infrigement of this requirement is liable of involve the imposition"></asp:Label>
                                                                <asp:Label ID="Label11" runat="server" Text="of penalty such as that of rustification."></asp:Label>
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
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label12" runat="server" Text="1.Student Name: "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblStudnetNameLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="formlable" Text="2.Caste:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblStudentCasteLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label17" runat="server" Text="3.Nationality:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblNationalityLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="formlable" Text="4.Birth Place : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblBirthPlaceLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label15" runat="server" CssClass="formlable" Text="5.Date of Birth : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblDOBLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label16" runat="server" CssClass="formlable" Text="6.Last School Attended : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblLastSchoolLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td style="text-align: left" width="200px">
                                                                <asp:Label ID="Label19" runat="server" CssClass="formlable" Text="7.Date of Admission : "></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblDateofAdmissionLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label21" runat="server" CssClass="formlable" Text="8.Progress : "></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblProgressLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label23" runat="server" CssClass="formlable" Text="9.Behaviour : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblBehaviourLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label25" runat="server" CssClass="formlable" Text="10.Date of Leaving : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblDateOFLeavingLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label27" runat="server" CssClass="formlable" Text="11.Year of Studying : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblYearOfStudyingLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label29" runat="server" CssClass="formlable" Text="12.Reason : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblReaseonLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label31" runat="server" CssClass="formlable" Text="13.Remarks : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblRemarksLC" runat="server"></asp:Label>
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
                                                    <table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label33" runat="server" Text="Certified that above information is accordance with the School."></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                            <asp:Button ID="btnPrintLC" runat="server" Text="Print LC" class="btn btn-primary"
                                OnClientClick="return PrintPanel();" />
                        </td>
                    </tr>
                </table>

                 <asp:TextBox ID="TextBox1" runat="server" Width="203px" ValidationGroup="VG" ReadOnly="true"></asp:TextBox>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
