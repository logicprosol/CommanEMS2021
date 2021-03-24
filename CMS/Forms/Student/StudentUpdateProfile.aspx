<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentUpdateProfile.aspx.cs"
    Inherits="CMS.Forms.Student.StudentUpdateProfile" MasterPageFile="~/Forms/Student/Student_Home.Master" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
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
    <!-- Example plugin: Prettify -->
    <!-- Initialize Scripts -->
    <script type="">
        // Activate Google Prettify in this page
        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {
            // Add prettyprint class to pre elements
            $('pre').addClass('prettyprint');
        }); // end document.ready
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 170px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 1000px; height:1000px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel_ViewProfile" runat="server" align="center">
            <div style="height: 1000px; width: 1000px;">
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Update Profile</li>
                            </ul>
                        </th>
                    </tr>
                </table>
               
                <div class="MainBody" style="width: 930px;">
                    <div class="frmwidth" align="center">
                        <%--<ul class="nav nav-tabs">
                            <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Student Information</font></a></li>
                          <li style="display:none"><a href="#sp2" data-toggle="tab"><font color="blue">Address Details</font></a></li>
                           <li style="display:none"><a href="#sp3" data-toggle="tab"><font color="blue">Education Details</font></a></li>
                          <%--  <li style="display:none"><a href="#sp4" data-toggle="tab"><font color="blue">Other Details</font></a></li>
                           <%-- <li ><a href="#sp5" data-toggle="tab"><font color="blue">Change Photo</font></a></li>
                        </ul>--%>
                        <div class="tab-content">
                            <div id="sp1" class="tab-pane active" align="center">
                                <asp:Panel ID="Panel_Personal" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">
                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" width="900px" >
                                    <ContentTemplate>--%>
                                    <table border="0" width="90%" align="center" cellspacing="2px">
                                        <tr>
                                            <td align="left" class="auto-style5">
                                                <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Student Id :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style5">
                                                
                                            </td>
                                            <td align="left" class="auto-style5">
                                               
                                            </td>
                                            <td align="left" class="auto-style6">
                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="G.R.No. :"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style7">
                                                <asp:TextBox ID="txtStudentId" runat="server" Width="130px" ReadOnly="True"></asp:TextBox>
                                                 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtStudentId" ErrorMessage="Enter Student Id" Visible="False"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" class="auto-style7">
                                               
                                            </td>
                                            <td align="left" class="auto-style7">
                                               
                                            </td>
                                            <td align="left" class="auto-style8">
                                                <asp:TextBox ID="txtGRNO" runat="server" Width="130px" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtGRNO" ErrorMessage="Enter G.R.No." Visible="False"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Student Name :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtFirstName" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtMiddleName" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtLastName" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Course :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Branch :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Class :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="Academic Year :"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtCourse" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtBranch1" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtClass" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAcademicYear" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label51" runat="server" Font-Bold="true" Text="Birth Date :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Gender :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label29" runat="server" Font-Bold="true" Text="Birth Place :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Handicap:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtBirthDate" runat="server" Width="130px"></asp:TextBox>
                                                 <asp:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" Format="MM/dd/yyyy" TargetControlID="txtBirthDate">
                                                                            </asp:CalendarExtender>
                                            </td>
                                            <td align="right" class="auto-style1">
                                               
                                                <asp:RadioButtonList ID="rbtGender" runat="server" CssClass="radio" RepeatDirection="Horizontal" Width="150px">
                                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtBirthPlace" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtHandicaped" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Mobile No :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label32" runat="server" Font-Bold="true" Text="Email :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label57" runat="server" Font-Bold="true" Text="Blood Group :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label27" runat="server" Font-Bold="true" Text="AdharNo :" Visible="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtMobileNo" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:TextBox ID="txtStudentEmail" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:DropDownList ID="txtBloodGroup" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select BloodGroup</asp:ListItem>
                                                                                <asp:ListItem>A+ </asp:ListItem>
                                                                                <asp:ListItem>A-</asp:ListItem>
                                                                                <asp:ListItem>B+</asp:ListItem>
                                                                                <asp:ListItem>B-</asp:ListItem>
                                                                                <asp:ListItem>AB+</asp:ListItem>
                                                                                <asp:ListItem>AB-</asp:ListItem>
                                                                                <asp:ListItem>O+</asp:ListItem>
                                                                                <asp:ListItem>O-</asp:ListItem>
                                                                                <asp:ListItem>NA</asp:ListItem>
                                                                            </asp:DropDownList>
                                                <%--<asp:TextBox ID="txtBloodGroup" runat="server" Width="130px"></asp:TextBox>--%>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAdharNo" runat="server" Visible="true" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label59" runat="server" Font-Bold="true" Text="Religion :"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label60" runat="server" Font-Bold="true" Text="Caste Category:"></asp:Label>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Fees Category :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label39" runat="server" Font-Bold="True" Text="Sub Caste :"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="auto-style1">
                                                <asp:DropDownList ID="ddlReligion" runat="server" Width="140px">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Hindu</asp:ListItem>
                                                    <asp:ListItem>Muslim</asp:ListItem>
                                                    <asp:ListItem>Sikh</asp:ListItem>
                                                    <asp:ListItem>Christion</asp:ListItem>
                                                    <asp:ListItem>Bouddh</asp:ListItem>
                                                    <asp:ListItem>Jain</asp:ListItem>
                                                    <asp:ListItem>Marwadi</asp:ListItem>
                                                    <asp:ListItem>Islam</asp:ListItem>
                                                    <asp:ListItem>Mala</asp:ListItem>
                                                    <asp:ListItem>Attar</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:DropDownList ID="ddlCasteCategory" runat="server" Width="140px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" class="auto-style1">
                                                <asp:DropDownList ID="ddlFeesCategory" runat="server" Width="140px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSubCaste" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label28" runat="server" Font-Bold="true" Text="Nationality :"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label22" runat="server" Font-Bold="true" Text="Country :"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label23" runat="server" Font-Bold="true" Text="State :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="District :"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:TextBox ID="txtNationality" runat="server" ReadOnly="true" Width="130px"></asp:TextBox>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:DropDownList ID="ddlStudentCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudentCountry_SelectedIndexChanged" Width="140px">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:DropDownList ID="ddlStudentState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudentState_SelectedIndexChanged" Width="140px">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlStudentDistrict" runat="server" Width="140px">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Taluka :"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="City/Village :"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Address :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:TextBox ID="txtStudentTaluka" runat="server" Width="130px"></asp:TextBox>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:TextBox ID="txtStudentCity" runat="server" Width="130px"></asp:TextBox>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="StudentCode :" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="PRN :" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Marrital Status :" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Division :" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style1">
                                                    <asp:TextBox ID="txtRollNo" runat="server" ReadOnly="true" Visible="False" Width="130px"></asp:TextBox>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:TextBox ID="txtPRN" runat="server" ReadOnly="true" Visible="False" Width="130px"></asp:TextBox>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <asp:RadioButtonList ID="rbtMarriedStatus" runat="server" CssClass="radio" RepeatDirection="Horizontal" Visible="false" Width="150px">
                                                        <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                        <asp:ListItem Text="Unmarried" Value="Unmarried"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDivision" runat="server" ReadOnly="true" Visible="False" Width="130px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    Note:-<asp:Label ID="lblFileuploadError" runat="server" Enabled="false" Font-Size="Small" ForeColor="Red" Text="* Please upload only JPG,JPEG format image only with maximum size of 1MB"></asp:Label><%--minimum size of 5KB or --%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Image ID="img_StudentImage" runat="server" Height="125px" ImageUrl="~/images/userphoto.gif" Width="155px" />
                                                   <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                    <asp:FileUpload ID="fileupload_StudentPhoto" runat="server" Height="29px" Width="228px" />
                                                                                    </ContentTemplate></asp:UpdatePanel>
                                                    <br />
                                                    <asp:Button ID="btnUploadPhoto" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnUploadPhoto_Click" Text="Upload" Visible="False" />
                                                    <br />
                                                    <asp:Label ID="Label156" runat="server" Text="Upload Photo(.jpg)"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <asp:Button ID="btnUpdatePhoto" runat="server" class="btn btn-primary" OnClick="btnUpdatePhoto_Click" Text="Update" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <%--<td align="center" colspan="4">
                                                    <asp:Button ID="btnUpdatePersonalDetails" runat="server" class="btn btn-primary"
                                                        OnClick="btnUpdatePersonalDetails_Click" Text="Update" />
                                                </td>--%>
                                            </tr>
                                        </tr>
                                    </table>
                                    <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </asp:Panel>
                            </div>
                          <%--  <div id="sp2" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_Parents" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" width="900px">
                                    <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" Text="Name :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentName" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" Text="Mother Name :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMotherName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label46" runat="server" Text="Address :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentAddress" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="Country :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlParentCountry" runat="server" OnSelectedIndexChanged="ddlParentCountry_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label35" runat="server" Text="State :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlParentState" runat="server" OnSelectedIndexChanged="ddlParentState_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" Text="District :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlParentDistrict" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label37" runat="server" Text="Taluka :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentTaluka" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label38" runat="server" Text="City :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentCity" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label40" runat="server" Text="PinCode :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentPinCode" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label49" runat="server" Text="Mobile No :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParentMobileNo" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label42" runat="server" Text="E-Mail :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtParentEmail" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btnUpdateParentDetails" runat="server" Text="Update" class="btn btn-primary"
                                                  OnClick="btnUpdateParentDetails_Click1"/>
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>--%>
                           <%-- <div id="sp3" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_Education" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" width="900px">
                                    <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="Last Class :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastClass" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Last Institute :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastInstitute" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="Qualified Exam :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQualifiedExam" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text="Seat No. :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSeatNo" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text="Passing Month :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassingMonth" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label31" runat="server" Text="Passing Year :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassingYear" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label33" runat="server" Text="Percentage :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPercentage" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label43" runat="server" Text="Result :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtResult" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="GrdEducation" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" DataKeyNames="ApplicationId,Exam,Board,Month,Year,Grade,ObtMarks,MaxMarks,Percentage"
                                                    Width="100%" GridLines="None" BorderColor="#0066FF" BorderStyle="Solid">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Qualified Exam" DataField="Exam" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Board/University" DataField="Board" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Passing Month" DataField="Month" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Passing Year" DataField="Year" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Grade" DataField="Grade" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Obt. Marks" DataField="ObtMarks" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Max. Marks" DataField="MaxMarks" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Percentage" DataField="Percentage" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btnUpdateEducationDetails" runat="server" Text="Update" class="btn btn-primary"
                                                    OnClick="btnUpdateEducationDetails_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>--%>
                            <%--<div id="sp4" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_OtherDetails" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" width="900px">
                                     <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td colspan="2">
                                                <asp:Label ID="Label50" runat="server" Text="Bank Name :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2" align="justify">
                                                <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td>
                                                <asp:Label ID="Label54" runat="server" Text="AccountNo :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label52" runat="server" Text="Branch :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                        <td>
                                                <asp:Label ID="Label53" runat="server" Text="IFSCCode :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIFSCCode" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label55" runat="server" Text="TC No :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTcNo" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label58" runat="server" Text="Sport :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSport" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label61" runat="server" Text="Level Played :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLevelPlayed" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btnUpdateOtherDetails" runat="server" Text="Update" class="btn btn-primary"
                                                    OnClick="btnUpdateOtherDetails_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>--%>
                            
                        </div>
                    </div>
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
