<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Admin_Home.aspx.cs" Inherits="CMS.Forms.Admin.Admin_Home1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />

   <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
        <!--Start of Tawk.to Script-->
<script type="text/javascript">
    var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
    (function () {
        var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
        s1.async = true;
        //s1.src = 'https://embed.tawk.to/5ae031b45f7cdf4f0533978e/1cbtvpt7e';
          s1.src='https://embed.tawk.to/5c287cd582491369ba9fec5b/default';

        s1.charset = 'UTF-8';
        s1.setAttribute('crossorigin', '*');
        s0.parentNode.insertBefore(s1, s0);
    })();
</script>
<!--End of Tawk.to Script-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"   >
       
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th style="background-color: #08c; color: White">
                    <ul class="nav nav-list">
                        <li style="color:white"><i class="icon-book"></i>WelCome To Education Management Systems </li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Width="800px" Height="860px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/Admin_Admission.jpg" alt="Admissions" />
                    </td>
                    <td align="center">
                        <img src="../../images/Admin_StudentDetails.jpg" alt="View Student Details" height="150px"
                            width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/Admin_ManageUser.jpg" alt="Manage User" height="150px"
                            width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnStudentAdmission" runat="server" 
                            class=" btn btn-default" ForeColor="White"  style="background: linear-gradient( #82191D, #221E1B );" 
                            onclick="lbtnStudentAdmission_Click" Width="120px">Admission Status</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnViewStudentDetails" runat="server" class=" btn btn-primary"  style="background: linear-gradient( #82191D, #221E1B );"
                            ForeColor="White" onclick="lbtnViewStudentDetails_Click" Width="120px"> View Students</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnManageUser" runat="server" class=" btn btn-primary"  style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnManageUser_Click" Width="120px">Manage User</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/Admin_Timetable.jpg" alt="Time Table" height="150px" width="150px" />
                    </td>
                    <td style="" align="center">
                        <img src="../../images/Admin_Attendance.jpg" alt="View Attendance" height="150px" width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/Admin_Settings.jpg" alt="Settings" height="150px"
                            width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnTimeTable" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnTimeTable_Click" Width="120px">Time Table</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtViewAttendance" runat="server" class=" btn btn-primary" 
                       style="background: linear-gradient( #82191D, #221E1B );"  ForeColor="White" onclick="lbtViewAttendance_Click" Width="120px"
                            >ProgramExecutive</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnSettings" runat="server" class=" btn btn-primary" 
                      style="background: linear-gradient( #82191D, #221E1B );"  ForeColor="White" onclick="lbtnSettings_Click" Width="120px">Settings</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/Admin_HumanResouces.jpg" alt="Human Resources" height="150px" width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/addfees3.png" alt="Add Fees" height="140px" width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/Admin_ManageNews.jpg" alt="Manage News" height="150px" width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnHumanResources" runat="server" class=" btn btn-primary" 
                        style="background: linear-gradient( #82191D, #221E1B );"  ForeColor="White" backcolor="#82191D"  onclick="lbtnHumanResources_Click" Width="120px">View Employee</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnExaminations" runat="server" class=" btn btn-primary" 
                            ForeColor="White"  style="background: linear-gradient( #82191D, #221E1B );" onclick="lbtnExaminations_Click" Width="120px">Add Fees</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnManageNews" runat="server" class=" btn btn-primary" 
                            ForeColor="White"  style="background: linear-gradient( #82191D, #221E1B );"  onclick="lbtnManageNews_Click" Width="120px">Announcement</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>



    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>