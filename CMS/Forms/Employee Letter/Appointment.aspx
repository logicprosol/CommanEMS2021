<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="CMS.Forms.Employee_Letter.Appointment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', '');
            printWindow.document.write('<html><head><title>Appointment Letter</title>');
            printWindow.document.write('<style type="text/css">@page{size: auto;margin-top:20mm;margin-bottom:20mm;}</style>');
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

    
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
        .auto-style2 {
            height: 62px;
        }
        .auto-style3 {
            width: 232px;
        }
    </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
       
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th colspan="4" style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li>Appointment Letter</li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>

                <div align="center" style="width:100%" >

                    <asp:Panel ID="panSelect" runat="server">
                                <asp:Panel ID="Panel2" runat="server" Width="95%" HorizontalAlign="Center" Height="40px"
                                    class="well well-large" align="center">
                                    <table border="0" width="40%">
                                        <tr>
                                            <td ><asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Small" Text="Student Id:"></asp:Label></td>
                                                <td ><asp:TextBox ID="txtStudentId" runat="server" AutoPostBack="true"></asp:TextBox></td>
                                                <td ><asp:Button ID="btnGo" runat="server" Class="btn btn-primary" OnClick="btnGo_Click"
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
                                                    Text="Sr. No. :"></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtReaseon1" runat="server" ValidationGroup="VG" Height="20px"  ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblStudentName" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Staff Name : "></asp:Label>
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
                                                    ErrorMessage="Please Enter Sr. No." ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtStudentName"
                                                    ErrorMessage="Please Enter Staff Name !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label22" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Address : "></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="VG" Height="20px"  ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label25" runat="server" CssClass="formlable" Font-Bold="True"
                                                    Text="Mobile No. : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="VG" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodayDate"
                                                    ErrorMessage="Please Enter Address !!!" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStudentName"
                                                    ErrorMessage="Please Enter  Mobile Number !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblDateOfAdmission0" runat="server" CssClass="formlable" Font-Bold="True" Text="Confirmation Date : " ></asp:Label>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:TextBox ID="txtDateOfConfirmation" runat="server" ></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDesignation" runat="server" CssClass="formlable" Font-Bold="True" Text="Designation : "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlDesignation" runat="server" Width="180px">
                                                    <asp:ListItem Enabled="true" Text="Select" Value="Select"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="center" style="text-align: left">
                                                <asp:RequiredFieldValidator ID="rfvDateOfAdmission0" runat="server" ControlToValidate="txtDateOfAdmission0" ErrorMessage="Please Enter Date of Confirmation !!!" ForeColor="red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="center">
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="rfvBehaviour0" runat="server" ControlToValidate="ddlBehaviour0" ErrorMessage="Please Select Designation !!!" ForeColor="red" InitialValue="Select" ValidationGroup="VG"></asp:RequiredFieldValidator>
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
                                                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Print" ValidationGroup="VG"
                                                    OnClick="btnPrint_Click" Enabled="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:Panel>





                    <asp:Panel ID="pnlContents" runat="server" HorizontalAlign="Left" width="80%" >
                        <div style="margin-left:8%;">
                    <table width="100%" align="center">
                        <tr align="center">
                            <td class="auto-style1"><asp:Label ID="label1" runat="server" text="SHRI SANT GOROBA SHIKSHAN SANSTHA" Font-Bold="True" Font-Size="22px"></asp:Label></td>
                        </tr>
                        <tr align="center">
                            <td><asp:Label ID="label2" runat="server" text="VIMAN NAGAR DIST.PUNE-410014" Font-Bold="True" Font-Size="18px"></asp:Label></td>
                        </tr>
                        <%--<tr align="center">
                            <td>&nbsp;&nbsp;</td>
                        </tr>--%>
                    </table>
                    
                    
                    <table width="90%" style="margin-top:10px;font-size:14px;">
                        <tr>
                            <td><asp:Label ID="label4" runat="server" text="REF.NO. :SESS/" Font-Bold="True" ></asp:Label>
                                <asp:Label ID="TxtAYear" runat="server" Font-Bold="True" text="2017-18"></asp:Label>
                                <asp:Label ID="label93" runat="server" Font-Bold="True" text="/"></asp:Label>
                                <asp:Label ID="TxtASrno" runat="server" Font-Bold="True" text="1"></asp:Label>
                            </td>
                        
                            <td align="right" style=""><asp:Label ID="label5" runat="server" text="DATE : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="TxtAdate" runat="server" Font-Bold="True" text="25 /03/2017"></asp:Label>
                            </td>
                        </tr>
                    </table>
                     
                    <table width="100%" style="margin-top:4px;font-size:14px;">
                        <tr>
                            <td align="center"><asp:Label ID="label7" runat="server" text="// ORDER OF APPOINTMENT  //" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>

                    <div align="left">
                    <table width="30%"  style="margin-top:4px;font-size:14px;">
                        <tr>
                            <td class="auto-style3" ><asp:Label ID="label6" runat="server" text="To," Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><asp:Label ID="TxtAname" runat="server" text="Mr  _______________________" Font-Bold="True" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><asp:Label ID="TxtAaddress" runat="server" text="__________________________" Font-Bold="True" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><asp:Label ID="label10" runat="server" text="Mob :  " Font-Bold="True"></asp:Label>
                                <asp:Label ID="TxtAmno" runat="server" Font-Bold="True" text="9876543210"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </div>

                    <table width="100%" style="margin-top:10px;font-size:14px;">
                        <tr>
                            <td><asp:Label ID="label11" runat="server" text="Dear Sir/ Madam"></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%" >
                        <tr>
                            <td style="font-size:14px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;With reference to your application &subsequent interview the management is pleased to appoint you as
                                     <b>“ <asp:Label ID="TxtADesg" runat="server" Font-Bold="True" text="TGT"></asp:Label>.”</b> In <b>Shri Shri Ravishankar Vidya Mandir, Sangamner Kd Tal.Sangamner Dist. Ahmednagar.</b> on the 
                                     following terms & conditions with effect from <asp:Label ID="TxtAJoinDate" runat="server" text="01/06/2017"></asp:Label>.</td>
                        </tr>
                    </table>

                    <table width="100%" style="font-size:14px;">
                        <tr>
                            <td width="7%" valign="top" valign="top"><asp:Label ID="label15" runat="server" text="01"></asp:Label></td>
                            <td><asp:Label ID="label19" runat="server" text="You will be paid an initial basic pay of Rs.9,300/- per month in the scale of Rs 9300-34800 + GP 4200 with admissible allowances as per applicable to Govt. schools."></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%" style="font-size:14px;">
                        <tr>
                            <td width="7%" valign="top"><asp:Label ID="label16" runat="server" text="02"></asp:Label></td>
                            <td><asp:Label ID="label18" runat="server" text="The appointment shall be one year probation for the academic year "></asp:Label>
                                <asp:Label ID="TxtAYear1" runat="server" text="2017-18 "></asp:Label>
                                <asp:Label ID="label13" runat="server" text="on expiry of the said academic year appointment will be confirmed subject to satisfactory performance."></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <table width="100%" style="font-size:14px;">
                        <tr>
                            <td width="7%" valign="top"><asp:Label ID="label23" runat="server" text="03"></asp:Label></td>
                            <td style=""><asp:Label ID="label24" runat="server" text="Employees services will be governed by the existing or changing service rules and regulations of the society as well as CBSE"></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label27" runat="server" text="04"></asp:Label></td>
                            <td><asp:Label ID="label28" runat="server" text="If either during probation period or extended period of probation, performance work and  conduct of the employee is found unsatisfactory your services are liable to be  terminated without any notice or notice pay in lieu of notice."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label33" runat="server" text="05"></asp:Label></td>
                            <td><asp:Label ID="label34" runat="server" text="It is expected that while in service, no decision(s) or action(s) either directly or indirectly will be taken by employee, which in the opinion of the management is/are prejudicial to the interest of the school and the Society."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label39" runat="server" text="06"></asp:Label></td>
                            <td><asp:Label ID="label40" runat="server" text="If required, you will have to go outstation for work, without claiming any extra allowance or remuneration; you will be paid T.A. & D.A. as per rules framed by the society."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label43" runat="server" text="07"></asp:Label></td>
                            <td><asp:Label ID="label44" runat="server" text="Your services are transferable to any college/school of the society, if so required."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label45" runat="server" text="08"></asp:Label></td>
                            <td><asp:Label ID="label46" runat="server" text="If you are found absent continuously for more than fifteen days without permission your services shall stand terminated without any written intimation to you."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label17" runat="server" text="09"></asp:Label></td>
                            <td><asp:Label ID="label21" runat="server" text="Please note that the decision of the Management/ Director /Secretary in judging your efficiency performance  and also the interpretation of this agreement will be absolute and final and will be binding upon you"></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label31" runat="server" text="10"></asp:Label></td>
                            <td><asp:Label ID="label35" runat="server" text="The continuation in the employment will be subject to your remaining physically and mentally fit.  The management shall have every right to get you examined at any time by any expert appointed by the Society, whose finding will be final and binding on both."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top" class="auto-style2"><asp:Label ID="label47" runat="server" text="11"></asp:Label></td>
                            <td class="auto-style2"><asp:Label ID="label49" runat="server" text="You will exercise the powers conferred upon you and perform your  duties in strict accordance with the Articles of Memorandum of Society and Rules & Regulations made or deemed to have been made under it."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label52" runat="server" text="12"></asp:Label></td>
                            <td><asp:Label ID="label53" runat="server" text="You will maintain absolute integrity and devotion to duty and you shall devote  your whole time and attention to the duties of this office and shall not engage, directly or indirectly, in any trade, business, private coaching class(es) or occupation involving financial or other personal gain or interest, and shall resign from any such trade, business or occupation in which you may be engaged immediately upon acceptance of this office as above. You will also not accept, without the previous permission in writing of the management of Society/concerned Institute any work which is not of a purely academic or literary character."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label29" runat="server" text="13"></asp:Label></td>
                            <td><asp:Label ID="label32" runat="server" text="You will not, at any time during the period of your employment or thereafter, divulge any information of a confidential nature relating to the Society/concerned Institute to any person not entitled by virtue of this office to demand or receive it."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label41" runat="server" text="14"></asp:Label></td>
                            <td><asp:Label ID="label51" runat="server" text="You will not, at any time, during the period of his employment or, make any statement in public or express opinions cruising any policy or action of Society/concerned Institute through newspapers, radio, television or any other medium of communication."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label56" runat="server" text="15"></asp:Label></td>
                            <td><asp:Label ID="label57" runat="server" text="Your services are liable to be terminated without any notice or notice pay, if it is found that you have misrepresented or concealed or given wrong information at the time of appointment or thereafter."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label59" runat="server" text="16"></asp:Label></td>
                            <td><asp:Label ID="label60" runat="server" text="You will be liable for action for acts committed inside or outside the premises of the establishment if such acts are likely to effect the discipline and working of the establishment."></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%"  style="font-size:14px;">
                        <tr>
                            <td width="7%" valign="top"><asp:Label ID="label62" runat="server" text="17"></asp:Label></td>
                            <td><asp:Label ID="label63" runat="server" text="You are required to give to the correct mailing address as soon as you join the duties and any change in the address given earlier should be communicated to the Management/Director/Secretary.it will be presumed that any letter sent on the address given to the Director by R.A.D. shall be deem to be a good service."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label65" runat="server" text="18"></asp:Label></td>
                            <td><asp:Label ID="label66" runat="server" text="Your appointment is subject to completion of  CTET / TET. within one year."></asp:Label></td>
                        </tr>

                        <tr>
                            <td valign="top"><asp:Label ID="label67" runat="server" text="19"></asp:Label></td>
                            <td><asp:Label ID="label68" runat="server" text="You will have to sign and return the accompanying declaration before/at the time of joining of the services as proof of having accepted this order. If this declaration is not received within stipulated period it shall be presumed that you are not interested in the employment."></asp:Label></td>
                        </tr>
                    </table>

                    <table width="87%" cellspacing="8"  style="margin-top:35px;font-size:16px;">
                        <tr>
                            <td align="right"><asp:Label ID="label71" runat="server" text="(  Sameer Shah )"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right"><asp:Label ID="label70" runat="server" text="PRESIDENT " Font-Bold="True"></asp:Label> &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="font-size:14px;"><asp:Label ID="label75" runat="server" text="C.C.to :"></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%"  style="font-size:16px;">
                        <tr>
                            <td width="7%" valign="top"><asp:Label ID="label72" runat="server" text="1"></asp:Label></td>
                            <td><asp:Label ID="label73" runat="server" text="The Principal, Shri Shri Ravishankar Vidya Mandir, Sangamner Kd"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"><asp:Label ID="label77" runat="server" text="2"></asp:Label></td>
                            <td><asp:Label ID="label74" runat="server" text="The Manager, Account Section,"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td><asp:Label ID="label76" runat="server" text="Sumeru Education Society, Sangamner Kd Tal. Sangamner Dist. Ahmednaga"></asp:Label></td>
                        </tr>
                        <tr  style="margin-top:12px;">
                            <td valign="top"><asp:Label ID="label78" runat="server" text="3"></asp:Label></td>
                            <td><asp:Label ID="label79" runat="server" text="Office copy."></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%"  style="margin-top:10px;">
                        <tr>
                            <td align="center"><asp:Label ID="label81" runat="server" text="ACCEPTANCE & DECLARATION" Font-Underline="True" Font-Bold="True" Font-Size="16px"></asp:Label></td>
                        </tr>
                    </table>

                    <table width="100%"  style="margin-top:4px;font-size:15px;text-align-last:justify;" >
                        <tr>
                            <td><asp:Label ID="label80" runat="server" text="I, "></asp:Label>
                            <asp:Label ID="TxtAname1" runat="server" text="_______________________________________________ "></asp:Label>
                            <asp:Label ID="label8" runat="server" text="accept as a "></asp:Label>
                            <asp:Label ID="TxtAdesg1" runat="server" text="_______ "></asp:Label>
                            <asp:Label ID="label12" runat="server" text="to the Shri Shri "></asp:Label></td>
                        </tr>
                        <tr>
                            <td ><asp:Label ID="label82" runat="server" text="Ravishankar Vidya Mandir, Sangamner Kd the terms and conditions specified here in above and that "></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="label83" runat="server" text="I shall begin my duties on"></asp:Label>
                            <asp:Label ID="TxtAJoindate1" runat="server" text=" _________________"></asp:Label>
                            <asp:Label ID="label9" runat="server" text=". I also declare that all the information furnished by me"></asp:Label></td>
                        </tr>
                        <tr>
                            <td ><asp:Label ID="label84" runat="server" text="in my application for the post of"></asp:Label>
                            <asp:Label ID="TxtAdesg2" runat="server" text=" ______________________"></asp:Label>
                            <asp:Label ID="label20" runat="server" text=" is true and correct. I also undertake that,"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style1" ><asp:Label ID="label85" runat="server" text="no matter relating to the affairs of the society and it’s management shall be disclosed or published in"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align-last:left;"><asp:Label ID="label86" runat="server" text="any form by me"></asp:Label></td>
                        </tr>
                    </table>

                    <table width="87%"  style="margin-top:35px;font-size:15px;">
                        <tr>
                            <td><asp:Label ID="label87" runat="server" text="PLACE :" Font-Bold="True"></asp:Label></td>
                            <td align="right"><asp:Label ID="label88" runat="server" text="SIGNATURE : ………………………………….." Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>

                    <table width="87%"  style="margin-top:4px;font-size:15px;">
                        <tr>
                            <td><asp:Label ID="label14" runat="server" text="DATE   :" Font-Bold="True"></asp:Label></td>
                            <td align="right"><asp:Label ID="label91" runat="server" text="FULL NAME : ………………………………….." Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>

                            </div>
                        </asp:Panel>

                    <br /><br />
                    <asp:Button ID="btnPrint" runat="server" Text="Print" class=" btn btn-info" OnClientClick="return PrintPanel();"  />
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</asp:Content>
