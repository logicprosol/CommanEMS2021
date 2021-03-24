<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master"
    AutoEventWireup="true" CodeBehind="Student_Home.aspx.cs" Inherits="CMS.Forms.Student.Student_Home1" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
  <div style="height: 900px; width: 1000px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>WelCome To College Management Systems </li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Width="950px" Height="860px">
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
                        <img src="../../images/View_Profile.png" alt="View Profile" />
                    </td>
                    <td align="center">
                        <img src="../../images/study2.png" alt="Study Material" height="150px"
                            width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/announcement.png" alt="Create Announcement" height="150px"
                            width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnProfile" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnProfile_Click" Width="120px">Profile</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnStudyMaterial" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnStudyMaterial_Click" Width="120px">Study Material</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAnnouncements" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnAnnouncements_Click" Width="120px">Announcements</asp:LinkButton>
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
                        <img src="../../images/View_Salary.png" alt="Fee" height="150px"
                            width="150px" />
                    </td>
                    <td style="" align="center">
                        &nbsp;<img src="../../images/Admin_Settings.jpg" alt="Settings" height="150px" width="150px" /></td>
                    <td align="center">
                        &nbsp;<img src="../../images/Assignment.png" alt="Assignments" height="120px" width="150px" /></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnFee" runat="server" class=" btn btn-primary"  style="background: linear-gradient( #82191D, #221E1B )"
                            ForeColor="White" OnClick="lbtnFee_Click" Width="120px" >Fee</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnExam" runat="server" class=" btn btn-primary" ForeColor="White" OnClick="lbtnExam_Click" style="background: linear-gradient( #82191D, #221E1B );" ValidationGroup="120">Settings</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAssignment" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" OnClick="lbtnAssignment_Click" Width="120px">Assignments</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>