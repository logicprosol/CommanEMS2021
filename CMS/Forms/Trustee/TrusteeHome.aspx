<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Trustee/Trustee.Master" AutoEventWireup="true" CodeBehind="TrusteeHome.aspx.cs" Inherits="CMS.Forms.Trustee.TrusteeHome" %>
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
                    <td align="center" style="height: 150px">
                        <img src="../../images/graph.png" alt="View Profile" />
                    </td>
                    <td align="center">
                        &nbsp;<img src="../../images/Admin_Settings.jpg" alt="View Salary Details" height="100px"
                            width="150px" /></td>
                   <%-- <td align="center">
                        <img src="../../images/announcement.png" alt="Create Announcement" height="150px"
                            width="150px" />
                    </td>--%>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAddCollege" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                             Width="120px" OnClick="lbtnAddCollege_Click">Admission Reports</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnSettings0" runat="server" class=" btn btn-primary" ForeColor="White"  style="background: linear-gradient( #82191D, #221E1B );" Width="120px" OnClick="lbtnSettings0_Click">Reset Password</asp:LinkButton>
                    </td>
                    <%--<td align="center">
                        <asp:LinkButton ID="lbtnAnnouncements" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnAnnouncements_Click" Width="120px">Announcements</asp:LinkButton>
                    </td>--%>
                </tr>


                 <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/gr1.png" alt="View Profile" height="100px"
                            width="150px" /></td>
                    </td>
                    <td align="center">
                        &nbsp;<img src="../../images/inventory.jpg" alt="View Salary Details" height="100px"
                            width="150px" /></td>
                   <%-- <td align="center">
                        <img src="../../images/announcement.png" alt="Create Announcement" height="150px"
                            width="150px" />
                    </td>--%>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lblPlacement" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                             Width="140px" OnClick="lblPlacement_Click">Placements Reports</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lblINVENTORY" runat="server" class=" btn btn-primary" ForeColor="White"  style="background: linear-gradient( #82191D, #221E1B );" Width="120px" OnClick="lblINVENTORY_Click">Inventory Reports</asp:LinkButton>
                    </td>
                    <%--<td align="center">
                        <asp:LinkButton ID="lbtnAnnouncements" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnAnnouncements_Click" Width="120px">Announcements</asp:LinkButton>
                    </td>--%>
                </tr>











                <tr>
                    <td>
                        <br />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <%--<td align="center" style="height: 150px">
                        <%--<img src="../../images/Admin_HumanResouces.jpg" alt="Apply For Leave" height="150px"
                            width="150px" />
                    </td>--%>
                    <td style="" align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <%--<td align="center">
                        <asp:LinkButton ID="lbtnManageUser" runat="server" class=" btn btn-primary" ForeColor="White" style="background: linear-gradient( #82191D, #221E1B );" 
                            OnClick="lbtnManageUser_Click" Width="120px">Manage User</asp:LinkButton>
                    </td>--%>
                    <td align="center">
                        &nbsp;</td>
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
                        &nbsp;
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