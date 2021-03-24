<%@ Page Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true"
    CodeBehind="ViewProfile.aspx.cs" Inherits="General_Information.ViewProfile" %>

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
        .auto-style2 {
            width: 170px;
        }
        .auto-style3 {
            width: 170px;
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 1000px; height:900px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel_ViewProfile" runat="server" align="center">
            <div style="height:900px; width:1000px;">
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>View Profile</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <br />
                <br />
                <div class="MainBody" style="width: 930px;">
                    <div class="frmwidth" align="center">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Personal</font></a></li>
                            <li style="display:none"><a href="#sp2" data-toggle="tab"><font color="blue">Parents</font></a></li>
                            <li style="display:none"><a href="#sp3" data-toggle="tab"><font color="blue">Education</font></a></li>
                            <li style="display:none"><a href="#sp4" data-toggle="tab"><font color="blue">Other Details</font></a></li>
                            
                        </ul>
                        <div class="tab-content">
                            <div id="sp1" class="tab-pane active " align="center">
                                <asp:Panel ID="Panel_Personal" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">                                   
                                    <table border="0" width="90%" align="center" cellspacing="2px">
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label1" runat="server" Text="Name :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblStudentName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2" rowspan="6" align="justify">
                                                <asp:Image ID="img_StudentImage" runat="server" Height="125px" ImageUrl="~/images/userphoto.gif"
                                                    Width="155px" />
                                                <br />
                                                <br />
                                                <asp:Image ID="img_StudentSign" runat="server" Height="25px" ImageUrl="../../images/Sign.jpg"
                                                    Width="155px" Visible="false" />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label10" runat="server" Text="Roll No :" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                               <asp:Label ID="lblRollNo" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>

                                            <td class="auto-style3">
                                                <asp:Label ID="Label15" runat="server" Text="G. R. NO :" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td class="auto-style3">
                                                 <asp:Label ID="lblGRNO" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label5" runat="server" Text="Course :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblCourse" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label13" runat="server" Text="Branch :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblBranch" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label6" runat="server" Text="Class :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblClass" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                            <%--<td>
                                                <asp:Label ID="Label8" runat="server" Text="Division :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblDivision" runat="server" Font-Bold="true"></asp:Label>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label11" runat="server" Text="Academic Year :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label2" runat="server" Text="Gender :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label51" runat="server" Text="Birth Date :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lblBirthDate" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label29" runat="server" Text="Birth Place :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBirthPlace" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label7" runat="server" Text="Mobile No :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblMobileNo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label32" runat="server" Text="Email :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblStudentEmail" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label57" runat="server" Text="Blood Group :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblBloodGroup" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label45" runat="server" Text="Handicaped:" Font-Bold="true" Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblHandicaped" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label3" runat="server" Text="Adhar No" Font-Bold="True" Visible="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                 <asp:Label ID="lblAdharNo" runat="server" Font-Bold="true" Visible="true"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label28" runat="server" Text="Nationality :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblNationality" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label59" runat="server" Text="Religion :" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                     <asp:Label ID="lblReligion" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label60" runat="server" Text="Caste Category:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblCasteCategory" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Caste :"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                     <asp:Label ID="lblCaste" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label39" runat="server" Font-Bold="true" Text="Sub Caste :" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblSubCaste" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="4">
                                                    <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Underline="true" ForeColor="Blue"
                                                        Text="Address Details :"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Address :"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                     <asp:Label ID="lblAddress" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label22" runat="server" Font-Bold="true" Text="Country :"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblStudentCountry" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label23" runat="server" Font-Bold="true" Text="State :"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                     <asp:Label ID="lblStudentState" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="District :"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblStudentDistrict" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Taluka :"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                     <asp:Label ID="lblStudentTaluka" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label26" runat="server" Font-Bold="true" Text="City :"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblStudentCity" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right" >
                                                    <asp:Label ID="Label27" runat="server" Font-Bold="true" Text="PinCode :" Visible="false"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left">
                                                     <asp:Label ID="lblStudentPinCode" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <br />
                                                </td>
                                            
                                            
                                        </tr>
                                    </table>
                                    
                                </asp:Panel>
                            </div>
                            <div id="sp2" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_Parents" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">
                                    
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
                                            <asp:Label ID="lblParentName" runat="server" Font-Bold="true"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" Text="Mother Name :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label46" runat="server" Text="Address :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentAddress" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" Text="Country :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblParentCountry" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label35" runat="server" Text="State :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentState" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" Text="District :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentDistrict" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label37" runat="server" Text="Taluka :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentTaluka" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label38" runat="server" Text="City :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentCity" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label40" runat="server" Text="PinCode :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentPinCode" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label49" runat="server" Text="Mobile No :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:Label ID="lblParentMobileNo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <asp:Label ID="Label42" runat="server" Text="E-Mail :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2" align="left">
                                                 <asp:Label ID="lblParentEmail" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        
                                    </table>
                                    
                                </asp:Panel>
                            </div>
                            <div id="sp3" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_Education" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">                                    
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
                                                <asp:Label ID="lblLastClass" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Last Institute :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                               <asp:Label ID="lblLastInstitute" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="Qualified Exam :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                               <asp:Label ID="lblQualifiedExam" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text="Seat No. :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSeatNo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text="Passing Month :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPassingMonth" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label31" runat="server" Text="Passing Year :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPassingYear" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label33" runat="server" Text="Percentage :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPercentage" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label43" runat="server" Text="Result :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResult" runat="server" Font-Bold="true"></asp:Label>
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
                                        
                                    </table>                                    
                                </asp:Panel>
                            </div>
                            <div id="sp4" class="tab-pane" align="center">
                                <asp:Panel ID="Panel_OtherDetails" runat="server" align="center" CssClass="well well-large"
                                    Width="80%">                                    
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
                                                <asp:Label ID="lblBankName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                                <asp:Label ID="Label54" runat="server" Text="AccountNo :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAccountNo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label52" runat="server" Text="Branch :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBranchName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                         <td>
                                                <asp:Label ID="Label53" runat="server" Text="IFSCCode :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIFSCCode" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label55" runat="server" Text="TC No :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTcNo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label58" runat="server" Text="Sport :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSport" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label61" runat="server" Text="Level Played :" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLevelPlayed" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        
                                    </table>                                    
                                </asp:Panel>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
