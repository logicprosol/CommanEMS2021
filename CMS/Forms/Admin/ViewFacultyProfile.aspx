<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFacultyProfile.aspx.cs"
    Inherits="CMS.ViewFacultyProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>
</head>
<body>
  <%--  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 1200px; width: 920px;">
        <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height: 895px; width: 920px;
            border: medium double#0C7BFA;">
            <table style="width: 90%;">
                <tr>
                    <td rowspan="5">
                        <asp:Image ID="imgStaff" runat="server" Height="90px" Style="margin-top: 0px" Width="90px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="Name:" class="bg-primary"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStaffName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Emp-Code"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmpCode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Department :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Designation:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label24" runat="server" Text="Course :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCourse" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="MotherName:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="DOB:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDBO" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="BloodGroup:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBloodGroup" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="MaritalStatus:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label33" runat="server" Text="Present Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPresentAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label34" runat="server" Text="Present Country:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPresentCountry" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label35" runat="server" Text="Present State:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPresentState" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label37" runat="server" Text="Present City:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPresentCity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label39" runat="server" Text="Present PinCode:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPresentPinCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label41" runat="server" Text="PermanentAddress:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label43" runat="server" Text="Permanent Country:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentCountry" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label45" runat="server" Text="Permanent State:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentState" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label47" runat="server" Text="Permanent City:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentCity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label49" runat="server" Text="Permanent PinCode:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPermanentPinCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label51" runat="server" Text="Phone Number:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label36" runat="server" Text="Mobile:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMobile" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label40" runat="server" Text="Fax:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label44" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label48" runat="server" Text="Caste Category:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCasteCategory" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label52" runat="server" Text="Nationality:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNationality" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label74" runat="server" Text="WebsiteBlog:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWebsiteBlog" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label76" runat="server" Text="Pan Card No:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPanCardNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label78" runat="server" Text="Date Of Joining:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDateOfJoining" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label80" runat="server" Text="UG Degree:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUGDegree" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label82" runat="server" Text="PG Degree:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPGDegree" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label84" runat="server" Text="Doctorate Degree:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDoctorateDegree" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label86" runat="server" Text="Other Qualification:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOtherQualification" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label38" runat="server" Text="Specialization:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSpecialization" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label46" runat="server" Text="Teaching Experience:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTeachingExperience" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label73" runat="server" Text="Industrial Experience:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblIndustrialExperience" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label77" runat="server" Text="Research Experience:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblResearchExperience" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label81" runat="server" Text="National Publication:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNationalPublication" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label85" runat="server" Text="International Publication:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblInternationalPublication" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label89" runat="server" Text="Book Published:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBookPublished" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label91" runat="server" Text="Patents:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPatents" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label93" runat="server" Text="PFNumber:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPFNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label95" runat="server" Text="Bank Account Number:"></asp:Label>
                    </td>
                    <td>
                        <a href="../../CMSHome.aspx">../../CMSHome.aspx</a>
                        <asp:Label ID="lblBankAccountNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label97" runat="server" Text="Bank Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBankName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label99" runat="server" Text="lblBankBranchName:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBankBranchName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label101" runat="server" Text="Bank IFSC Code:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBankIFSCCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;<asp:Button ID="btnCancelEmployer" class="btn btn-danger" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
    </form>
</body>--%>


 <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div style="height: 1000px; width: 640px;">
            <br />
            <asp:Panel ID="Panel_ViewFacultyProfile" runat="server" class="well well-large" Height="970px"
                Width="520px">
                <table border="1" width="100%">
                    <tr>
                        <td>
                            <table align="center" border="0" style="width: 100%;">
                                <tr>
                                    <td bgcolor="#0066FF" colspan="3" style="text-align: left">
                                        &nbsp;<asp:Label ID="Label107" runat="server" Font-Bold="True" ForeColor="White"
                                            Text="Employee Information :"></asp:Label>
                                    </td>
                                </tr>
                                
                                <tr>
                                
                                    <td rowspan="5">
                                        
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        
                                        <asp:Image ID="imgStaff" runat="server" BorderWidth="1px" Height="90px" Style="margin-top: 0px"
                                            Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                
                                    <td style="text-align: left">
                                        <asp:Label ID="Label23" runat="server" class="bg-primary" Text="Name:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStaffName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label11" runat="server" Text="Emp-Code" Font-Bold="True"></asp:Label>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmpCode" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label6" runat="server" Text="Department :" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label7" runat="server" Text="Designation:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label102" runat="server" Text="MotherName:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label103" runat="server" Text="Gender:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label104" runat="server" Text="DOB:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDBO" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label105" runat="server" Text="BloodGroup:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblBloodGroup" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label106" runat="server" Text="MaritalStatus:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#0066FF" colspan="3" style="text-align: left">
                                        <asp:Label ID="Label108" runat="server" Font-Bold="True" ForeColor="White" Text="Contact Information :"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label111" runat="server" Text="Present Address:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPresentAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label112" runat="server" Text="Present Country:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPresentCountry" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label113" runat="server" Text="Present State:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPresentState" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label114" runat="server" Text="Present City:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPresentCity" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label115" runat="server" Text="Present Pin Code:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPresentPinCode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label116" runat="server" Text="Permanent Address:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPermanentAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label117" runat="server" Text="Permanent Country:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPermanentCountry" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label118" runat="server" Text="Permanent State:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPermanentState" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label119" runat="server" Text="Permanent City:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPermanentCity" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label120" runat="server" Text="Permanent Pin Code:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPermanentPinCode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label121" runat="server" Text="Phone Number:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label122" runat="server" Text="Mobile:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label123" runat="server" Text="Fax:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label124" runat="server" Text="Email:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label125" runat="server" Text="Caste Category:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblCasteCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label126" runat="server" Text="Nationality:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblNationality" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label127" runat="server" Text="Website Blog:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblWebsiteBlog" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label128" runat="server" Text="Pan Card No:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPanCardNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label129" runat="server" Text="Date Of Joining:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblDateOfJoining" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#0066FF" colspan="3" style="text-align: left">
                                        &nbsp;<asp:Label ID="Label109" runat="server" Font-Bold="True" ForeColor="White"
                                            Text="Education Information :"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label130" runat="server" Text="UG Degree:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblUGDegree" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label131" runat="server" Text="PG Degree:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPGDegree" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label132" runat="server" Text="Doctorate Degree:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblDoctorateDegree" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label133" runat="server" Text="Other Qualification:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblOtherQualification" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label134" runat="server" Text="Specialization:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblSpecialization" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label135" runat="server" Text="Teaching Experience:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblTeachingExperience" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label136" runat="server" Text="Industrial Experience:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblIndustrialExperience" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label137" runat="server" Text="Research Experience:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblResearchExperience" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label138" runat="server" Text="National Publication:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblNationalPublication" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label139" runat="server" Text="International Publication:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblInternationalPublication" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label140" runat="server" Text="Book Published:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBookPublished" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label141" runat="server" Text="Patents:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPatents" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td bgcolor="#0066FF" colspan="3" style="text-align: left">
                                        &nbsp;<asp:Label ID="Label110" runat="server" Font-Bold="True" ForeColor="White"
                                            Text="Other Information :"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label93" runat="server" Text="PFNumber:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblPFNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label95" runat="server" Text="Bank Account Number:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBankAccountNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label97" runat="server" Text="Bank Name:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBankName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label99" runat="server" Text="Bank Branch Name:" 
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBankBranchName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label101" runat="server" Text="Bank IFSC Code:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblBankIFSCCode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                                        <%--<asp:Button ID="btnCancelEmployer" class="btn btn-danger" runat="server" Text="Close" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </center>
    </form>
</body>
</html>