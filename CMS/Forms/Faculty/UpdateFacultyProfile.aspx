<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="UpdateFacultyProfile.aspx.cs" Inherits="CMS.Forms.Faculty.UpdateFaculty" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Add Scriptmanager here-->
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
 
    <!-- Start here-->
    <div style="height: 1000px; width:auto; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th
                         colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Update Profile</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
        <table width="920px" style="height: 1000px">
            <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Width="920px" Height="1000px" ScrollBars="Auto">
                        <center>
                            <%-- Panel 2--%>
                           
<asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                               
                            <asp:Panel ID="Panel2" runat="server" Width="900px">
                                <!--Add table here-->
                             <%--   <table border="1" width="90%" align="center" cellspacing="2px">
                                    <tr>
                                        <th style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Personal Information</li>
                                            </ul>
                                        </th>
                                    </tr>
                                </table>--%>
                                <table border="0" width="90%" align="center" cellspacing="2px">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                  <%--  <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department: " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtDepartment" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            &nbsp;</td>
                                    </tr>--%>
                                    <%--<tr>
                                            <td align="center">
                                                <asp:Label ID="lblFacultyType" runat="server" Text="Faculty Type : " CssClass="formlable"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtFacultyType" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvFacultyType" runat="server" ControlToValidate="txtFacultyType"
                                                    ErrorMessage="Please Enter Faculty Type !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                 <%--   <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDesignationName" runat="server" Text="Designation: " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtDesignation" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            &nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblFirstName" runat="server" CssClass="formlable" Text="First Name : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMiddleName" runat="server" CssClass="formlable" Text="Middle Name : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLastName" runat="server" CssClass="formlable" Text="Last Name : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMotherName" runat="server" CssClass="formlable" Font-Bold="True" Text="Mother Name : "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="StaffInfo"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMiddleName" runat="server" ValidationGroup="StaffInfo"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvMiddleName0" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="Please Enter Middle Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="StaffInfo"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMotherName" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtMotherName" ErrorMessage="Please Enter Mother Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblBloodGroup" runat="server" CssClass="formlable" Font-Bold="True" Text="Blood Group : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblGender" runat="server" CssClass="formlable" Text="Gender : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblBirthDate" runat="server" CssClass="formlable" Text="Birth Date : " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMaritalStatus" runat="server" CssClass="formlable" Font-Bold="True" Text="Marital Status : "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlbloodgroup" runat="server" Height="34px" Width="176px">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>O+ve</asp:ListItem>
                                                <asp:ListItem>O-ve</asp:ListItem>
                                                <asp:ListItem>A+ve</asp:ListItem>
                                                <asp:ListItem>A-ve</asp:ListItem>
                                                <asp:ListItem>B+ve</asp:ListItem>
                                                <asp:ListItem>B-ve</asp:ListItem>
                                                <asp:ListItem>AB+ve</asp:ListItem>
                                                <asp:ListItem>AB-ve</asp:ListItem>
                                                <asp:ListItem>NA</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ControlToValidate="ddlbloodgroup" ErrorMessage="Please Enter Blood Group !!!" ForeColor="red" InitialValue="Select" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="txtGender" ErrorMessage="Please Enter Gender !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBirthDate" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtBirthDate" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Please Enter Birth Date !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMaritalStatus" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvMaritalStatus" runat="server" ControlToValidate="txtMaritalStatus" ErrorMessage="Please Enter Marital Status !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel> 

                               
                            <%-- Panel 5--%>
                            <asp:Panel ID="Panel5" runat="server" Width="920px">
                                <!--Add table here-->
                                <table border="1" width="100%" align="center" cellspacing="2px">
                                    <tr>
                                        <th style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Contact Information</li>
                                            </ul>
                                        </th>
                                    </tr>
                                </table>
                                <table border="0" width="90%" align="center" cellspacing="2px">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label26" runat="server" Text="Present Address:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label28" runat="server" Text="Present Country:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label30" runat="server" Text="Present State:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Present City:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtPresentAddress" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPresentAddress" runat="server" ControlToValidate="txtPresentAddress" ErrorMessage="Please Enter Present Address !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPresentCountry" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlPresentCountry_SelectedIndexChanged" Width="176px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPresentCountry" runat="server" ControlToValidate="ddlPresentCountry" ErrorMessage="Please Enter Present Country !!!" ForeColor="red" InitialValue="0" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPresentStATE" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlPresentStATE_SelectedIndexChanged" Width="176px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPresentState" runat="server" ControlToValidate="ddlPresentStATE" ErrorMessage="Please Enter Present State !!!" ForeColor="red" InitialValue="0" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPresentCity" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlPresentCity_SelectedIndexChanged" Width="176px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPresentCity" runat="server" ControlToValidate="ddlPresentCity" ErrorMessage="Please Enter Present State !!!" ForeColor="red" InitialValue="0" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
<%--                                            <asp:TextBox ID="txtPresentState" runat="server"></asp:TextBox>--%>
                                            <asp:Label ID="Label37" runat="server" Font-Bold="True" Text="Nationality:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label25" runat="server" Text="Present Pin Code:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label42" runat="server" Text="Phone Number:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="Mobile:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
<%--                                            <asp:TextBox ID="txtPresentCity" runat="server"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="txtNationality" ErrorMessage="Please Enter Nationality !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPresentPinCode" runat="server" MaxLength="6"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPresentPinCode" runat="server" ControlToValidate="txtPresentPinCode" ErrorMessage="Please Enter Present Pin Code !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="12"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Please Enter Phone Number !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                           

                                        <td align="left">
                                            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Please Enter Mobile Nomber !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                           

                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Pan Card No:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label29" runat="server" Text="Email:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label48" runat="server" Font-Bold="True" Text="Date Of Joining:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Caste Category:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtPanCardNo" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPanCardNo" runat="server" ControlToValidate="txtPanCardNo" ErrorMessage="Please Enter Pan Card No !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter Email Address !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateOfJoining" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="JoiningDate_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtDateOfJoining" TodaysDateFormat="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvDateOfJoining" runat="server" ControlToValidate="txtDateOfJoining" ErrorMessage="Please Enter Date Of Joining !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCastCategory" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlCastCategory_SelectedIndexChanged" Width="176px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvCastCategory" runat="server" ControlToValidate="ddlCastCategory" ErrorMessage="Please Select Cast Category !!!" ForeColor="red" InitialValue="0" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <%--Panel 6--%>
                            <asp:Panel ID="Panel6" runat="server" Width="900px">
                                <!--Add table here-->
                                <table border="0" width="100%" align="center" cellspacing="2px">
                                    <tr>
                                        <th style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Educational & Other Information</li>
                                            </ul>
                                        </th>
                                    </tr>
                                </table>
                                <table border="0" width="90%" align="center" cellspacing="2px">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style11" align="left">
                                            <asp:Label ID="Label50" runat="server" Text="UGDegree:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label52" runat="server" Text="PGDegree:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label56" runat="server" Text="Other Qualification:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label58" runat="server" Font-Bold="True" Text="Specialization:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style11">
                                            <asp:TextBox ID="txtUGDegree" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvUGDegree" runat="server" ControlToValidate="txtUGDegree" ErrorMessage="Please Enter UGDegree !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPGDegree" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvPGDegree" runat="server" ControlToValidate="txtPGDegree" ErrorMessage="Please Enter PGDegree !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtOtherQualification" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvOtherQualification" runat="server" ControlToValidate="txtOtherQualification" ErrorMessage="Please Enter Other Qualification !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSpecialization" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvSpecialization" runat="server" ControlToValidate="txtSpecialization" ErrorMessage="Please Enter Specialization !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style11" align="left">
                                            <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="Teaching Experience:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label55" runat="server" Font-Bold="True" Text="Bank Account Number:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label63" runat="server" Font-Bold="True" Text="Bank Name:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label66" runat="server" Font-Bold="True" Text="Bank Branch Name:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style11" align="left">
                                            <asp:TextBox ID="txtTeachingExperience" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvTeachingExperience" runat="server" ControlToValidate="txtTeachingExperience" ErrorMessage="Please Enter Teaching Experience !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBankAccountNumber" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvBankAccountNumber" runat="server" ControlToValidate="txtBankAccountNumber" ErrorMessage="Please Enter Bank Account Number !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" ErrorMessage="Please Enter BankName !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBankBranchName" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvBankBranchName" runat="server" ControlToValidate="txtBankBranchName" ErrorMessage="Please Enter Bank Branch Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style11" align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                 <%--   <tr>
                                        <td class="style11" align="center">
                                            <asp:Label ID="Label43" runat="server" Text="Industrial Experience:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtIndustrialExperience" runat="server"></asp:TextBox>
                                        </td>
                                      <%--  <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvIndustrialExperience" runat="server" ControlToValidate="txtIndustrialExperience"
                                                ErrorMessage="Please Enter Industrial Experience !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                               <%--     <tr>
                                        <td class="style11" align="center">
                                            <asp:Label ID="Label49" runat="server" Text="Research Experience:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtResearchExperience" runat="server"></asp:TextBox>
                                        </td>
                                      <%--  <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvResearchExperience" runat="server" ControlToValidate="txtResearchExperience"
                                                ErrorMessage="Please Enter Research Experience !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                               <%--     <tr>
                                        <td class="style11" align="center">
                                            <asp:Label ID="Label53" runat="server" Text="National Publication:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtNationalPublication" runat="server"></asp:TextBox>
                                        </td>
                                       <%-- <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvNationalPublication" runat="server" ControlToValidate="txtNationalPublication"
                                                ErrorMessage="Please Enter National Publication !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                   <%-- <tr>
                                        <td class="style11" align="center">
                                            <asp:Label ID="Label39" runat="server" Text="International Publication:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtInternationalPublication" runat="server"></asp:TextBox>
                                        </td>
                                      <%--  <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvInternationalPublication" runat="server" ControlToValidate="txtInternationalPublication"
                                                ErrorMessage="Please Enter International Publication !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                 <%--   <tr>
                                        <td class="style11" align="center">
                                            <asp:Label ID="Label51" runat="server" Text="Book Published:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtBookPublished" runat="server"></asp:TextBox>
                                        </td>
                                      <%--  <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvBookPublished" runat="server" ControlToValidate="txtBookPublished"
                                                ErrorMessage="Please Enter Book Published !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                  <%--  <tr>
                                        <td class="style12" align="center">
                                            <asp:Label ID="Label57" runat="server" Text="Patents:"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtPatents" runat="server"></asp:TextBox>
                                        </td>
                                     <%--   <td align="center">
                                            <asp:RequiredFieldValidator ID="rfvPatents" runat="server" ControlToValidate="txtPatents"
                                                ErrorMessage="Please Enter Patents !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                </table>
                            </asp:Panel>
                            </ContentTemplate>
                            </asp:UpdatePanel>   
                            <%--Panel 7--%>
                            <asp:Panel ID="Panel7" runat="server" Width="800px" BorderColor="#0099FF" BorderStyle="Solid" BorderWidth="3px">
                                <!--Add table here-->
                               
                                <table border="0" width="80%" align="center" cellspacing="2px">
                                    <tr>
                                        <td colspan="2" align="center">
                                            Note:-<asp:Label ID="lblFileuploadError" runat="server" Enabled="false" Font-Size="Small" ForeColor="Red" Text="* Please upload only JPG,JPEG format image only with minimum size of 5KB or maximum size of 1MB"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="img_StudentImage" runat="server" Height="125px" ImageUrl="~/images/userphoto.gif" Width="155px" />
                                            <br />
                                            <asp:Label ID="lblStaffId" runat="server" Font-Bold="True"></asp:Label>
                                            <br />
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="fileupload1" runat="server" Height="29px" Width="228px" />
                                            <asp:Button ID="btnUploadPhoto" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnUploadPhoto_Click" Text="Upload" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                          
                                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="StaffInfo" />
                                            <asp:Button ID="Button2" runat="server" class="btn btn-primary" OnClick="btnClear_Click" Text="Clear" Visible="False" />
                                        </td>
                                    </tr>
                                    </table>

                            </asp:Panel>
                        </center>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <!--End here-->
      
</asp:Content>