<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"
    CodeBehind="HR_Home.aspx.cs" Inherits="CMS.Forms.HR.HR_Home" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
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
                   <%-- <td align="center" style="height: 150px">
                        <img src="../../images/Admin_HumanResouces.jpg" alt="Add Employee" />
                    </td>--%>
                    <td align="center">
                        <img src="../../images/Library.jpg" alt="Assign Subjects" height="150px" width="150px" />
                    </td>
                    <td align="center">
                        <img src="../../images/announcement.png" alt="Create Announcement" height="150px"
                            width="150px" />
                    </td>
                </tr>
                <tr>
                  <%--  <td align="center">
                        <asp:LinkButton ID="lbtnEmpInfo" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnEmpInfo_Click" Width="120px">Add Employee</asp:LinkButton>
                    </td>--%>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAssignSubjects" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnAssignSubjects_Click" Width="120px">Assign Subjects</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAnnouncements" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnAnnouncements_Click" Width="150px">Create Announcements</asp:LinkButton>
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
                        <img src="../../images/Finance.jpg" alt="Pay Setting" height="150px" width="150px" />
                    </td>
                    <td style="" align="center">
                        &nbsp;<img src="../../images/Admin_Settings.jpg" alt="Setting" height="150px"
                            width="150px" /></td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnPaySettings" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnPaySettings_Click" Width="120px">Pay Settings</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnSetting" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnSetting_Click" Width="120px">Settings</asp:LinkButton>
                    </td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        &nbsp;
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>