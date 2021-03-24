<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ReportDashBord.aspx.cs" Inherits="CMS.Forms.Admin.ReportDashBord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 895px; width: 900px;">
        <asp:Panel ID="Panel1" runat="server" Style="height: 895px; width: 894px; border: double #0C7BFA">
            <%--<img src="../../images/AdminHome.jpg" alt="Admin Home" style="width: 800px; height: 600px" />--%>
            <table border="1" width="100%">
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large"
                            Font-Underline="True" Text="Reports"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image ID="Image9" runat="server" Height="77px" ImageUrl="~/images/LC.png" Width="107px" />
                    </td>
                    <td align="center">
                        <asp:Image ID="Image2" runat="server" Height="80px" ImageUrl="~/images/EL.png" Width="110px" />
                    </td>
                    <td align="center">
                        <asp:Image ID="Image7" runat="server" Height="80px" ImageUrl="~/images/EMP Experience Letter.png"
                            Width="110px" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style2">
                        <a href="LeavingCertificate.aspx">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Student Leaving Certificate"></asp:Label></a>
                    </td>
                    <td align="center">
                        <a href="ExperienceCertificate.aspx">
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" Text="Employee Experience Letter"></asp:Label></a>
                    </td>
                    <td align="center">
                        <a href="BonafiedCertificate.aspx">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" Text="Bonafied Certificate"></asp:Label></a>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image ID="Image4" runat="server" Height="77px" ImageUrl="~/images/300px-Image_student_card_jlo.png"
                            Width="107px" />
                        <br />
                    </td>
                    <td align="center">
                        <asp:Image ID="Image8" runat="server" Height="77px" ImageUrl="~/images/Emp I Card.png"
                            Width="107px" />
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <a href="StudentIcardGeneration.aspx">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                            Text="Student I-Card" Font-Size="Medium"></asp:Label></a>
                    </td>
                    <td align="center">
                        <a href="FacultyICardGeneration.aspx">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" Text="Employee I-Card"></asp:Label></a>
                    </td>
                    <td align="center">
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
