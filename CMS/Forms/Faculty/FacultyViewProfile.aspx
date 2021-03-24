<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="FacultyViewProfile.aspx.cs" Inherits="CMS.Forms.Faculty.FacultyViewProfile" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <script type="">

        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {

            $('pre').addClass('prettyprint');
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 191px;
        }
        .auto-style2 {
            width: 183px;
        }
        .auto-style4 {
            width: 166px;
        }
        .auto-style5 {
            width: 179px;
        }
        .auto-style9 {
            width: 209px;
        }
        .auto-style11 {
            width: 228px;
        }
        .auto-style12 {
            width: 211px;
        }
        .auto-style13 {
            width: 216px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="MainBody">
            <div class="frmwidth" align="center">
                <%--<ul class="nav nav-tabs">
                    <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">PersonalInformation</font>
                    </a></li>
                    <li><a href="#sp2" data-toggle="tab"><font color="blue">ContactGeneralInfo</font></a>
                    </li>
                    <li><a href="#sp3" data-toggle="tab"><font color="blue">EducationalQualification</font>
                    </a></li>
                </ul>--%>
              
                <div class="tab-content">
                    <div id="sp1" class="tab-pane active" align="center">
                        <asp:Panel ID="Panel_PersonalInfo" runat="server">
                            <table border="0" width="100%" align="center" cellspacing="2px">
                                <tr>
                                    <td class="fomrsubheader" align="center">
                                        <ul class="nav nav-list">
                                            <li class="active"><a href="#"><i class="icon-home icon-white"></i>Personal Information</a></li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" width="90%" align="center" cellspacing="2px">
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label1" runat="server" Text="UserCode :" Font-Bold="False" Visible="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        &nbsp;</td>
                                    <td class="auto-style5">&nbsp;</td>
                                    <td class="auto-style4">&nbsp;</td>
                                    <td align="center" rowspan="6">
                                        <asp:Image ID="ImgStaff" runat="server" Height="70px" ImageUrl="~/images/userphoto.gif" Width="70px" />
                                        <asp:Label ID="lblStaffId" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Department :" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Faculty Type:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFacultyType" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Designation :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Class :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label6" runat="server" Text="First Name :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblFirstName" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Middle Name:" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblMiddleName" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label8" runat="server" Text="Last Name :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblLastName" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Mother Name :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblMotherName" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label10" runat="server" Font-Bold="False" Text="Gender :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblGender" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label11" runat="server" Font-Bold="False" Text="Birth Date :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Convert.ToDateTime(Eval("DOB")).ToShortDateString() %>' Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Blood Group :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblBloodGroup" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label13" runat="server" Font-Bold="False" Text="Marital Status :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblMaritalStatus" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        &nbsp;</td>
                                    <td class="auto-style2">
                                        &nbsp;</td>
                                    <td class="auto-style5">&nbsp;</td>
                                    <td class="auto-style4">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div id="sp2" class="tab-pane active" align="center">
                        <asp:Panel ID="Panel_ContactGeneralInfo" runat="server">
                            <table width="100%" border="0" align="center">
                                <tr>
                                    <td class="fomrsubheader" align="center">
                                        <ul class="nav nav-list">
                                            <li class="active"><a href="#"><i class="icon-home icon-white"></i>Address Details</a></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" width="90%" align="center" cellspacing="2px">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Present Address :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblPresentAddress" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Present Country :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentCountry" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Font-Bold="False" Text="Present State :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentState" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Present City :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentCity" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Font-Bold="False" Text="present Pin Code :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPinCode" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Font-Bold="False" Text="Phone No :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPhoneNo" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Mobile :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMobile" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Font-Bold="False" Text="Email :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Font-Bold="False" Text="Caste Category :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCasteCategory" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Font-Bold="False" Text="Nationality :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNationality" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Font-Bold="False" Text="PanCard No :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPanCardNo" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div id="sp3" class="tab-pane active" align="center">
                        <asp:Panel ID="Panel_QualificationBankingDetails" runat="server">
                            <table width="100%" border="0" align="center">
                                <tr>
                                    <td class="fomrsubheader" align="center">
                                        <ul class="nav nav-list">
                                            <li class="active"><a href="#"><i class="icon-home icon-white"></i>Qualification Details</a></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" width="90%" align="center" cellspacing="2px">
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="Label34" runat="server" Text="Date Of Joining :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:Label ID="lblDateOfJoining" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style13">
                                        <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="UGDegree :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUGDegree" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="Label36" runat="server" Text="PGDegree :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:Label ID="lblPGDegree" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style13">
                                        <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="Other Qualification :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOtherQualification" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style9">
                                        <asp:Label ID="Label35" runat="server" Text="Specialization :" Font-Bold="False" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:Label ID="lblSpecialization" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                    <td class="auto-style13">
                                        <asp:Label ID="Label39" runat="server" Font-Bold="False" Text="Teaching Experience :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTeachingExperience" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                                <!-- <tr>
                        <td>
                            <asp:Label ID="Label42" runat="server" Text="Industrial Experience :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblIndustrialExperience" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label44" runat="server" Text="Reaserch Experience :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReaserchExperience" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label37" runat="server" Text="National Publication :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNationalPublication" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label43" runat="server" Text="International Publication :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInternationalPublication" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label46" runat="server" Text="BookPublished :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBookPublished" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label41" runat="server" Text="Patents :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPatents" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>-->
                           <%-- </table>
                            <table width="100%" border="0" align="center">
                                <tr>
                                    <td class="fomrsubheader" align="center">
                                        <ul class="nav nav-list">
                                            <li class="active"><a href="#"><i class="icon-home icon-white"></i>Banking Details</a></li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>--%>
                        </asp:Panel>
                    </div>
                </div>
    
            </div>
        </div>
      <%--   <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
    </div>
   
</asp:Content>
