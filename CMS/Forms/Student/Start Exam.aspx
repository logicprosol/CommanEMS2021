<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="Start Exam.aspx.cs" Inherits="CMS.Forms.Student.Start_Exam" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style1 {
             height: 39px;
         }
         .auto-style3 {
             height: 24px;
         }
         .auto-style14 {
             width: 100%;
         }
         .auto-style15 {
             margin-bottom: 0px;
         }
         .auto-style16 {
             width: 87px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Start here-->
    <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li>Online Exam</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
        <table>
               <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Width="920px" Height="800px" ScrollBars="Auto">
                        <center>
                            <%-- Panel 2--%>
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
                                <table class="auto-style14" style="border: 3px solid #0099FF">
                                    <tr>
                                        <td class="auto-style16">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpSubject" ErrorMessage="Select Subject Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Subject: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSubject" runat="server" AutoPostBack="True" CssClass="auto-style15" Height="29px" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                            <%--OnSelectedIndexChanged="ddlUnitTest_SelectedIndexChanged"--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Test"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnitTest" runat="server" CssClass="auto-style15" OnSelectedIndexChanged="ddlUnitTest_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="formlable" Font-Bold="True" Text="Class"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblclass1" runat="server" Font-Bold="True" Text="Class"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="formlable" Font-Bold="True" Text="Total Questions"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LBLpATTERN" runat="server" Font-Bold="True" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="auto-style16">
                                            &nbsp;</td>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btnStartExam" runat="server" CssClass="btn-primary" OnClick="btnStartExam_Click" Text="Start Exam" />
                                        </td>
                                    </tr>
                                </table>
                                <%--<table border="0" width="90%" align="center" cellspacing="2px" style="border: 3px solid #0099FF">


                                     <tr>
                                        <td align="center" class="auto-style8">
                                        </td>
                                        <td align="center" class="auto-style12" colspan="2" >
                                          
                                            &nbsp;</td>
                                        <td align="center" class="auto-style12">
                                        </td>
                                    </tr>
                                     <tr>
                                         <td align="center" class="auto-style13">
                                             &nbsp;</td>
                                         <td align="center" class="auto-style13" >
                                             <br />
                                         </td>
                                         <td align="center" class="auto-style13" >
                                             &nbsp;</td>
                                         <td align="center" class="auto-style13" >
                                             <br />
                                         </td>
                                     </tr>
                                    <tr>
                                            <td align="center" class="auto-style7">
                                                &nbsp;</td>
                                            <td align="center" class="auto-style6">
                                                &nbsp;</td>

                                            
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                            <br />
                                        </td>
                                        </tr>
                                

                                     <tr>
                                         <td align="center" colspan="4">&nbsp;</td>
                                     </tr>


                                    <%-- <tr>
                                        <td align="center">
                                            <asp:Label ID="lblClass" runat="server" Text="Class" CssClass="formlable"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblclass1" runat="server" Text="Class" Font-Bold="True"  ></asp:Label>
                                            <br />
                                        </td>
                                       
                                    </tr>
                               
                                    </table>--%>
                               <%-- <asp:DetailsView ID="FormView1" runat="server" class="table table-striped" width="90%"
                                    AllowPaging="True" AutoGenerateRows="False" OnPageIndexChanging="FormView1_PageIndexChanging">
                                    <Fields>
                                        <asp:BoundField datafield="QuestionId" HeaderText="QuestionId"/>
                                        <asp:BoundField datafield="Question" HeaderText="Question"/>
                                         <asp:BoundField datafield="optA" HeaderText="Option A"/>
                                         <asp:BoundField datafield="optB" HeaderText="Option B"/>
                                         <asp:BoundField datafield="optC" HeaderText="Option C"/>
                                         <asp:BoundField datafield="optD" HeaderText="Option D"/>
                                    </Fields>
                                </asp:DetailsView>--%>
                                <asp:Panel ID="pnlShow" runat="server">
                                <table align="center" border="1" cellspacing="2px" class="table table-striped" width="90%">
                                    <tr>
                                        <td align="center" class="auto-style3">
                                            <asp:Label ID="lblQuesid" runat="server" CssClass="formlable" Text="Question Id : " Visible="false"></asp:Label>
                                        </td>
                                        <td align="center" class="auto-style3">
                                            <asp:Label ID="lblQuesid1" runat="server"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="auto-style1">
                                            <asp:Label ID="lblFirstName" runat="server" CssClass="formlable" Font-Bold="True" Font-Size="Medium" Text="Question"></asp:Label>
                                        </td>
                                        <td align="center" class="auto-style1">
                                            <asp:Image ID="Image1" runat="server" Height="200px" Width="700px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="auto-style1">
                                            <center>
                                            </center>
                                        </td>
                                        <td align="center" class="auto-style1">
                                            <asp:Label ID="lblquestion" runat="server" Font-Bold="True" Font-Size="Medium" Text="Question"></asp:Label>
                                        </td>
                                        <%--<td align="center" class="auto-style1">
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="ddlPattern" ErrorMessage="Please Enter Pattern Name !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <center>
                                                <asp:RadioButton ID="rdoA" runat="server" CssClass="radio-inline" Font-Bold="True" GroupName="OPTION" OnCheckedChanged="rdoA_CheckedChanged" Text="Option A" />
                                            </center>
                                        </td>
                                        <td align="center"><%--                                                <asp:TextBox ID="txtAnswer" runat="server" Columns="4" Rows="4" TextMode="MultiLine" Width="206px" ></asp:TextBox>--%>
                                            <asp:Label ID="lblA" runat="server" Font-Size="Medium" Text="Label"></asp:Label>
                                        </td>
                                        <%--  <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtAnswer" ErrorMessage="Please Enter Answer !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <center>
                                                <asp:RadioButton ID="rdoB" runat="server" Font-Bold="True" GroupName="OPTION" Text="Option B" />
                                            </center>
                                        </td>
                                        <td align="center"><%--                                                <asp:TextBox ID="txtAnswer" runat="server" Columns="4" Rows="4" TextMode="MultiLine" Width="206px" ></asp:TextBox>--%>
                                            <asp:Label ID="lblB" runat="server" Font-Size="Medium" Text="Label"></asp:Label>
                                        </td>
                                        <%--  <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtAnswer" ErrorMessage="Please Enter Answer !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <center>
                                                <asp:RadioButton ID="rdoC" runat="server" Font-Bold="True" GroupName="OPTION" Text="Option C" />
                                            </center>
                                        </td>
                                        <td align="center"><%--                                                <asp:TextBox ID="txtAnswer" runat="server" Columns="4" Rows="4" TextMode="MultiLine" Width="206px" ></asp:TextBox>--%>
                                            <asp:Label ID="lblC" runat="server" Font-Size="Medium" Text="Label"></asp:Label>
                                        </td>
                                        <%--  <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtAnswer" ErrorMessage="Please Enter Answer !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <center>
                                                <asp:RadioButton ID="rdoD" runat="server" Font-Bold="True" GroupName="OPTION" Text="Option D" />
                                            </center>
                                        </td>
                                        <td align="center"><%--                                                <asp:TextBox ID="txtAnswer" runat="server" Columns="4" Rows="4" TextMode="MultiLine" Width="206px" ></asp:TextBox>--%>
                                            <asp:Label ID="lblD" runat="server" Font-Size="Medium" Text="Label"></asp:Label>
                                        </td>
                                        <%--  <td align="center">
                                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtAnswer" ErrorMessage="Please Enter Answer !!!" ForeColor="red" ValidationGroup="StaffInfo"></asp:RequiredFieldValidator>
                                            </td>--%>
                                    </tr>
                                    <tr>
                                        <td align="center"></td>
                                        <td align="center">
                                            <br /><asp:Button ID="btnPrvious" runat="server" CssClass="btn-primary" Height="35px" OnClick="btnPrevious_Click" Text="  Previous  " Width="100px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnNext" runat="server" CssClass="btn-primary" Height="35px" OnClick="btnNext_Click" Text="  Next  " Width="100px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn-primary" Height="35px" OnClick="btnCancel_Click" Text="Submit" Width="100px" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <caption>
                                        <br />
                                    </caption>
                                </table>
                                    </asp:Panel>
                                </asp:Panel>
                                </center>
                                </asp:Panel>
                    </td></tr></table>
           <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
