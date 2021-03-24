<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="HRViewProfile.aspx.cs" Inherits="CMS.Forms.HR.AddViewProfile" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="MainBody">
            <div class="frmwidth" align="center">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">PersonalInformation</font>
                    </a></li>
                    <li><a href="#sp2" data-toggle="tab"><font color="blue">ContactGeneralInfo</font></a>
                    </li>
                    <li><a href="#sp3" data-toggle="tab"><font color="blue">EducationalQualification</font>
                    </a></li>
                </ul>
                <%--<asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                --%>
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
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="StaffId :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStaffId" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td rowspan="3">
                                        <asp:Image ID="ImgStaff" runat="server" ImageUrl="~/images/userphoto.gif" Width="70px"
                                            Height="70px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Department :"></asp:Label>
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
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="First Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Middle Name:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMiddleName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Last Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Mother Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMotherName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Gender :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Birth Date :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblBirthDate" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Blood Group :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Marital Status :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMaritalStatus" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div id="sp2" class="tab-pane" align="center">
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
                                        <asp:Label ID="Label17" runat="server" Text="Present Address :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentAddress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Present Country :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentCountry" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Present State :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Text="Present City :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPresentCity" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="present Pin Code :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPinCode" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Permanent Address :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermanentAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Permanent Country :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermamentCountry" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label47" runat="server" Text="PermanentState "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermanentState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label48" runat="server" Text="PermanentCity"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermanentCity" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label49" runat="server" Text="PermanentPincode"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermanentPincode" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Phone No :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPhoneNo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Text="Mobile :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Text="Fax :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" Text="Email :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Text="Caste Category :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCasteCategory" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label33" runat="server" Text="Nationality :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNationality" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label28" runat="server" Text="Website Blog :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblWebsiteBlog" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Text="PanCard No :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPanCardNo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div id="sp3" class="tab-pane" align="center">
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
                                    <td>
                                        <asp:Label ID="Label34" runat="server" Text="Date Of Joining :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDateOfJoining" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label30" runat="server" Text="UGDegree :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUGDegree" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" Text="PGDegree :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPGDegree" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label38" runat="server" Text="Doctorate Degree :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDoctorateDegree" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label40" runat="server" Text="Other Qualification :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOtherQualification" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label35" runat="server" Text="Specialization :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSpecialization" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label39" runat="server" Text="Teaching Experience :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTeachingExperience" runat="server" Text=""></asp:Label>
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
                            </table>
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
                            </table>
                        </asp:Panel>
                    </div>
                </div>
                <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
