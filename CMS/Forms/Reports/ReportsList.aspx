<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ReportsList.aspx.cs" Inherits="CMS.Forms.Reports.ReportsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <div style="height: 900px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Reports" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_AcademicYear" runat="server" Visible="true" Style="height: 897px;
                    width: 920px; border: medium double#0C7BFA;">
                           <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Reports</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                           <table>
                           <tr>
                           <td>
                           <br />
                           </td>
                           </tr>
                    <tr>
                            <td>
                                <asp:ImageButton ID="Image1" runat="server" Height="60px" Width="60px" ImageUrl="~/images/Report.PNG"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptHandicapEmpList" />
                            </td>
                        <td style="border-bottom-style: dotted; border-bottom-width: 2px; border-bottom-color: #822084">
                                <asp:LinkButton ID="LinkButton2" runat="server" Text="Handicap Employee List :" Font-Bold="True"
                                    Font-Names="Constantia" Font-Underline="True" ForeColor="#1F072C" Font-Size="Large"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptHandicapEmpList"></asp:LinkButton>
                                <br />
                               
                            </td>
                             <td>
                                <asp:ImageButton ID="Image2" runat="server" Height="60px" Width="60px" ImageUrl="~/images/Report.PNG"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptHandicapStudList" />
                            </td>
                        <td style="border-bottom-style: dotted; border-bottom-width: 2px; border-bottom-color: #822084">
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Handicap Student List :" Font-Bold="True"
                                    Font-Names="Constantia" Font-Underline="True" ForeColor="#1F072C" Font-Size="Large"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptHandicapStudList"></asp:LinkButton>
                                <br />
                               
                            </td>
                              <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="60px" Width="60px" ImageUrl="~/images/Report.PNG"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptSportsStudList" />
                            </td>
                        <td style="border-bottom-style: dotted; border-bottom-width: 2px; border-bottom-color: #822084">
                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Sports Student List :" Font-Bold="True"
                                    Font-Names="Constantia" Font-Underline="True" ForeColor="#1F072C" Font-Size="Large"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptSportsStudList"></asp:LinkButton>
                                <br />
                               
                            </td>
                            </tr>
                            <tr>
                               <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="60px" Width="60px" ImageUrl="~/images/Report.PNG"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptGovernmentSchemes" />
                            </td>
                        <td style="border-bottom-style: dotted; border-bottom-width: 2px; border-bottom-color: #822084">
                                <asp:LinkButton ID="LinkButton4" runat="server" Text="Government Scheme List :" Font-Bold="True"
                                    Font-Names="Constantia" Font-Underline="True" ForeColor="#1F072C" Font-Size="Large"
                                    PostBackUrl="ReportsMaster.aspx?ReportName=rptGovernmentSchemes"></asp:LinkButton>
                                <br />
                               
                            </td>
                            </tr>
                            <tr>
                           <td>
                           <br />
                           </td>
                            </tr>
                     
                            </table>
                            </asp:Panel>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            </div>
</asp:Content>
