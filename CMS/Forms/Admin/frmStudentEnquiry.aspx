<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmStudentEnquiry.aspx.cs" Inherits="CMS.Forms.Admin.frmStudentEnquiry" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
<link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
<link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../../css/styles.css" rel="stylesheet" type="text/css" />
<link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../js/bootstrap.js" type="text/javascript"></script>
<!-- ==============================================JavaScript below!-->
<!--  For Tab Navigation Use This jQuery  -->
<script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
<script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
<!-- Bootstrap JS: compiled and minified -->
<script src="../../js/bootstrap.min.js" type="text/javascript"></script>
<head id="Head1" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
            width: 324px;
        }

        .auto-style2 {
            height: 22px;
            width: 163px;
        }

        .auto-style3 {
            width: 163px;
        }

        .auto-style4 {
            height: 22px;
            width: 172px;
        }

        .auto-style6 {
            width: 324px;
        }

        .auto-style7 {
            width: 172px;
        }

        .auto-style9 {
            width: 201px;
        }

        .auto-style10 {
            width: 200px;
        }

        .auto-style11 {
            border-top-style: solid;
        }

        .auto-style12 {
            width: 201px;
            border-top-style: solid;
        }

        .auto-style13 {
            width: 150px;
            border-top-style: solid;
        }

        .auto-style14 {
            width: 200px;
            border-top-style: solid;
        }

        .auto-style15 {
            width: 158px;
        }

        .auto-style16 {
            width: 158px;
            border-top-style: solid;
        }

        .auto-style17 {
            width: 182px;
        }

        .auto-style18 {
            width: 182px;
            border-top-style: solid;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div style="">
                        <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true">
                            <table border="0" width="100%" align="center" cellspacing="2px">
                                <tr>
                                    <th style="background-color: #0C7BFA; color: White">

                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Enquiry Form</li>

                                        </ul>
                                    </th>
                                </tr>
                            </table>
                            <table border="0" width="100%" align="center" cellspacing="2px" style="border: medium solid #0099FF; width: 90%; background-color: antiquewhite;">
                                <tr>
                                    <td>
                                        <div class="MainBody">
                                            <div class="frmwidth" align="center">
                                                <ul class="nav nav-tabs">
                                                    <li class="active">
                                                        <a href="#sp1" data-toggle="tab">
                                                            <asp:Label runat="server" Text="Enquiry" Font-Bold="True" Font-Size="Medium" ForeColor="#0066FF"></asp:Label>
                                                        </a></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton2" runat="server"> <b> Enquiry Record</b></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CMSHome.aspx"> <b> Home</b></asp:LinkButton>
                                                    </li>
                                                </ul>
                                                <div class="tab-content">
                                                    <div id="sp1" class="tab-pane active" align="center">

                                                        <table align="center" border="0" cellspacing="2px" width="80%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table align="center" width="900px">
                                                                        <tr>
                                                                            <td class="auto-style15" align="left">
                                                                                <asp:Label ID="lblchildname" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#272727" Text="Child Name:"></asp:Label>
                                                                           <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                                 </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtFirstName" runat="server" placeholder="First Name" Width="156px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtMiddleName" runat="server" placeholder="Middle Name" Width="156px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtLastName" runat="server" placeholder="Last Name" Width="156px"></asp:TextBox>
                                                                            </td>
                                                                              <br />
                                                                              <br />
                                                                        </tr>
                                                                        <tr>  <br />
                                                                            <td class="auto-style17" align="left">
                                                                                <asp:Label ID="LblDOB" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#272727" Text="DOB:"></asp:Label>
                                                                           <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                                 </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtDOB" runat="server" placeholder="Date Of birth" ValidationGroup="vg" Width="150px"></asp:TextBox>
                                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="TxtDOB">
                                                                                </asp:CalendarExtender>
                                                                            </td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style17" align="left">
                                                                                <asp:Label ID="lblstandard" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#272727" Text="Standard"></asp:Label>
                                                                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                            </td>
                                                                                <td class="auto-style15">
                                                                                    <asp:TextBox ID="TxtStandard" runat="server" placeholder="Standard" Width="156px"></asp:TextBox>
                                                                                </td>
                                                                             <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>

                                                                            <td  class="auto-style17" align="left">
                                                                                <asp:Label ID="LblFatherName" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#272727" Text="Admission Date"></asp:Label>
                                                                                <asp:Label ID="Label22" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtAdmissionDate" runat="server" placeholder="Admission Date" ValidationGroup="vg" Width="150px"></asp:TextBox>
                                                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="TxtAdmissionDate">
                                                                                </asp:CalendarExtender>
                                                                            </td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style17" align="left">
                                                                                <asp:Label ID="lblEmail" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#272727" Text="Email"></asp:Label>
                                                                            
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" Width="156px" MaxLength="12"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style17" align="left">
                                                                                <asp:Label ID="lblMobileNo" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#272727" Text="WhatsUp Number:"></asp:Label>
                                                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                <asp:TextBox ID="TxtWhatsupNumber" runat="server" placeholder="WhatsUpNumber" Width="156px"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style17" align="left">
                                                                                <asp:Label ID="lblAddress" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="#272727" Text="Address:"></asp:Label>
                                                                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                 <asp:TextBox ID="TxtAddress" runat="server" placeholder="Address" Width="156px"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                </td>
                                                            </tr>

                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" Text="New form" OnClick="btnNew_Click" />
                                        <asp:Button ID="Button1" runat="server" CausesValidation="false" class="btn btn-primary" Text="Print" Visible="false" />
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" ValidationGroup="vg" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>
                                </table>

                                                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />

                                </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
