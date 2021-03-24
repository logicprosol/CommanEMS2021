<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    Culture="en-IN" CodeBehind="LeavingCertificate.aspx.cs" Inherits="CMS.Forms.Admin.LeavingCertificate" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 900px; border: medium double#0C7BFA;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
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
                                                <asp:TextBox ID="txtStudentId" runat="server" AutoPostBack="true" OnTextChanged="txtStudentId_TextChanged"></asp:TextBox>
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
                                                <asp:CheckBox ID="chkDuplicateCopy" TextAlign="Right" Width="150px" runat="server"
                                                    AutoPostBack="true" class="radio" Text="Duplicate Copy" OnCheckedChanged="chkDuplicateCopy_CheckedChanged" />
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
                                                <asp:Label ID="lblStudentCaste" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Student Caste: "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtStudentCaste" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblNationality" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Nationality : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNationality" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
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
                                                <asp:TextBox ID="txtBirthPlace" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDOB" runat="server" CssClass="formlable" Font-Bold="True" Text="Date of Birth : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDOB" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
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
                                                <asp:TextBox ID="txtLastSchoolAttended" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDateOfAdmission" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Date of Admission : " ValidationGroup="VG"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDateOfAdmission" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
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
                                                <asp:TextBox ID="txtYearOfStudying" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
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
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click"
                                                    ValidationGroup="VG" Enabled="False" />
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" OnClick="btnUpdate_Click"
                                                    Enabled="False" OnClientClick = "ConfirmUpdate()" />
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
                                        Width="95%" Visible="false">
                                        <div align="right" style="width:95%;margin-top:5px;margin-bottom:5px;">
                                            <asp:Label ID="Label2" runat="server" Text="ORIGINAL/DUPLICATE" Width="200px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                        </div>
                                        <table width="95%" align="center" style="border: 1px solid black">
                                            <tr>
                                                <td>
                                                    <table width="99%" align="center">
                                                        
                                                        <tr>
                                                            <td rowspan="4" align="right" width="50px">
                                                                <asp:Image ID="imgClgLogo" runat="server" Height="60px" Width="70px" />
                                                            </td>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="lblTrustName" runat="server"  Style="font-size: 14px;
                                                                    color: #292A0A;text-align: justify;"  ForeColor="White"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="lblCollageFullName" runat="server" Font-Size="X-Large" Font-Bold="true" Style="color: #084B8A;
                                                                    text-align: justify; " ForeColor="White"></asp:Label>
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Label ID="lblAddress" runat="server" Font-Size="12px" Style="text-align: justify;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td  align="left">
                                                                <asp:Label ID="lblGRNO" runat="server" Text="G.R. No.: " Width="160px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;margin-left:15px;"></asp:Label>
                                                                <%--<asp:Label ID="lblGRNO" runat="server"  Width="75px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>--%>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblNo" runat="server" Text="L.C. No.: " Width="160px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;margin-right:15px;"></asp:Label>
                                                                <%--<asp:Label ID="lblNo" runat="server"  Width="75px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;margin-right:15px;"></asp:Label>--%>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                    
                                                    <table border="0" width="100%" cellpadding="5" align="center" style="margin-top:10px;border: 1px solid black" >
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Style="color: #084B8A;"
                                                                    Text="LEAVING CERTIFICATE"></asp:Label>
                                                            </td> <%--Leaving Certificate--%>
                                                        </tr>
                                                    </table>
                                                    

                                                    <div style="margin-left:10px;margin-right:10px;">

                                                    <table width="100%" align="center" style="margin-top:10px;">
                                                        <tr>
                                                            <td align="left" width="17%">
                                                                <asp:Label ID="Label7" runat="server" Text="Student ID" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="lblstudId" runat="server"></asp:Label>--%>

                                                                <asp:Label ID="lblstudId1" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId2" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId3" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId4" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId5" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId6" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblstudId7" runat="server"  Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:5px;">
                                                        <tr>
                                                            <td align="left" width="20%">
                                                                <asp:Label ID="Label9" runat="server" Text="Aadhar Card No."></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="lblaadharno" runat="server"></asp:Label>--%>

                                                                <asp:Label ID="lblaadharno1" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno2" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno3" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno4" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblaadharno5" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno6" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno7" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno8" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblaadharno9" runat="server" Width="25px"  BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno10" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno11" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblaadharno12" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="22%">
                                                                <asp:Label ID="Label12" runat="server" Text="Student Full Name: "></asp:Label>
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <%--<asp:Label ID="lblStudnetNameLC" runat="server" Text="sdcfbkasdbck" style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>--%>
                                                                <asp:Label ID="lblStudnetName_Fname" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <asp:Label ID="lblStudnetName_Mname" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <asp:Label ID="lblStudnetName_Lname" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" >
                                                        <tr>
                                                            <td align="left" width="22%">
                                                                
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <asp:Label ID="Label10" runat="server" Font-Size="X-Small" Text="(Name)" Width="100%" ></asp:Label>
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <asp:Label ID="Label11" runat="server" Font-Size="X-Small" Text="(Father's Name)" Width="100%" ></asp:Label>
                                                            </td>
                                                            <td align="center" width="26%">
                                                                <asp:Label ID="Label18" runat="server" Font-Size="X-Small" Text="(Surname)" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="17%">
                                                                <asp:Label ID="Label8" runat="server" Text="Mother's Name:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblMoname" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="13%">
                                                                <asp:Label ID="Label22" runat="server" Text="Nationality:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="35%">
                                                                <asp:Label ID="lblNationalityLC" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="19%">
                                                                <asp:Label ID="Label24" runat="server" Text="Mother Tongue:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblMoTongue" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="9%">
                                                                <asp:Label ID="Label28" runat="server" Text="Religion:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="22%">
                                                                <asp:Label ID="lblReligion" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="7%">
                                                                <asp:Label ID="Label32" runat="server" Text="Caste:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="22%">
                                                                <asp:Label ID="lblStudentCasteLC" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="14%">
                                                                <asp:Label ID="Label13" runat="server" Text="Sub Caste:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblSubCaste" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="16%">
                                                                <asp:Label ID="Label17" runat="server" Text="Place of Birth"></asp:Label>
                                                            </td>
                                                            <td align="left" width="38%">
                                                                <asp:Label ID="lblBirthPlaceLC" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="8%">
                                                                <asp:Label ID="Label30" runat="server" Text="Taluka:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblTaluka" runat="server" style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="8%">
                                                                <asp:Label ID="Label14" runat="server" Text="Dist.:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="24%">
                                                                <asp:Label ID="lblDist" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="7%">
                                                                <asp:Label ID="Label34" runat="server" Text="State:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="24%">
                                                                <asp:Label ID="lblState" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="10%">
                                                                <asp:Label ID="Label37" runat="server" Text="Country:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblCountry" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label26" runat="server" Text="Date Of Birth (in Figures):"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="lblDOBLC" runat="server"></asp:Label>--%>

                                                                <asp:Label ID="lblDOB_D1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDOB_D2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDOB_M1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDOB_M2" runat="server"  Width="25px" Font-Bold="True" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDOB_Y1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDOB_Y2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDOB_Y3" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDOB_Y4" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="13%">
                                                                <asp:Label ID="Label15" runat="server" Text="(in Words)"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblDOBinWords" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="26%">
                                                                <asp:Label ID="Label36" runat="server" Text="Last School Attended:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblLastSchoolLC" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="26%">
                                                                <asp:Label ID="Label16" runat="server" Text="Date of Admission:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="50%">
                                                                <%--<asp:Label ID="lblDateofAdmissionLC" runat="server"></asp:Label>--%>

                                                                <asp:Label ID="lblDateofAdmission_D1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateofAdmission_D2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDateofAdmission_M1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateofAdmission_M2" runat="server"  Width="25px" Font-Bold="True" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDateofAdmission_Y1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateofAdmission_Y2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateofAdmission_Y3" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateofAdmission_Y4" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                            </td>
                                                            <td align="left" width="7%">
                                                                <%--<asp:Label ID="Label38" runat="server" Text="Std.:"></asp:Label>--%>
                                                            </td>
                                                            <td align="left" >
                                                                <%--<asp:Label ID="lblstd" runat="server" Text="dsv" style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="10%">
                                                                <asp:Label ID="Label19" runat="server" Text="Progress:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="40%">
                                                                <asp:Label ID="lblProgressLC" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="95%" ></asp:Label>
                                                            </td>
                                                            <td align="left" width="10%">
                                                                <asp:Label ID="Label40" runat="server" Text="Conduct:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblConductLC" runat="server"  style="border-bottom:solid 1px black;text-align:center;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="20%">
                                                                <asp:Label ID="Label21" runat="server" Text="Date Of Leaving:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <%--<asp:Label ID="lblDateOFLeavingLC" runat="server"></asp:Label>--%>

                                                                <asp:Label ID="lblDateOFLeaving_D1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateOFLeaving_D2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDateOFLeaving_M1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateOFLeaving_M2" runat="server"  Width="25px" Font-Bold="True" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:Label ID="lblDateOFLeaving_Y1" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateOFLeaving_Y2" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateOFLeaving_Y3" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                                <asp:Label ID="lblDateOFLeaving_Y4" runat="server"  Width="25px" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" style="text-align: center;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="45%">
                                                                <asp:Label ID="Label23" runat="server" Text="Standard in which studing and since when:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblstd_since" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                   
                                                    <%--<table width="99%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left" width="200px">
                                                                <asp:Label ID="Label27" runat="server" CssClass="formlable" Text="11.Year of Studying : "></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblYearOfStudyingLC" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>--%>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="32%">
                                                                <asp:Label ID="Label25" runat="server" Text="Reason for leaving the school:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblReaseonLC" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table width="100%" align="center" style="margin-top:8px;">
                                                        <tr>
                                                            <td align="left" width="10%">
                                                                <asp:Label ID="Label27" runat="server" Text="Remarks:"></asp:Label>
                                                            </td>
                                                            <td align="left" >
                                                                <asp:Label ID="lblRemarksLC" runat="server"  style="border-bottom:solid 1px black;" Width="100%" ></asp:Label>
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

                                                    <table width="100%" align="center" style="border: 1px solid black">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label33" runat="server" Text="Certified that above information is accordance with the School."></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table border="0" width="100%" align="center">
                                                        <tr>
                                                            <td align="left">
                                                                <br />
                                                                <asp:Label ID="Label29" runat="server" Text="Place :" Font-Bold="true"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="Label31" runat="server" Text="Date :" Font-Bold="true"></asp:Label>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table border="0" width="100%" align="center">
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

                                                        </div>
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
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>