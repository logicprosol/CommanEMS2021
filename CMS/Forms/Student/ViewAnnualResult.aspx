<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="ViewAnnualResult.aspx.cs" Inherits="CMS.Forms.Student.ViewAnnualResult" enableEventValidation ="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 24px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div style="width: 930px; height: 930px; border: medium double#0C7BFA; margin-top:-76px">
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center">
            <div style="height: 798px; width: 930px;">
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Annual Result</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <br />
                <br />
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
           
                        <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto;">
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSemester1" Text="Select Semester :" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblTest" Text="Select Test :" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="auto-style2">
                                    <br />
                                </td>
                            </tr>
                         </table> 
                            <br /><br />
                            
                            <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
                            <asp:Panel ID="Panel1" runat="server" Width="80%" BorderStyle="Solid" >
                                <div style="margin-top:15px;margin-left:15px;margin-bottom:15px;margin-right:15px;">


                                    <table width="100%" >
                                    <tr>
                                        
                                           
                                        <td align="left">
                                           <%-- <asp:ImageButton ID="ImageButton_logo" runat="server" Height="100px" Width="125px"
                                                ImageUrl="~/Images/Deiontech_Logo.png" PostBackUrl="~/Forms/Trustee/TrusteeHome.aspx"
                                                CausesValidation="false" />--%>
                                             <asp:ImageButton ID="ImageButton_logo" runat="server" Height="100px" Width="125px"
                                            ImageUrl="~/Images/ctbora_logo_20130504082803.jpg" PostBackUrl="~/Forms/Trustee/TrusteeHome.aspx"
                                            CausesValidation="false" />
                                        </td>
                                        <td width="50px"></td>
                                        <td width="500px">
                                            <table>
                                                <tr>
                                                    <td style="font-size: 17px; color: #82191D" >
                                                        <b>
                                                            <%--<asp:Label ID="Lbl_TrustName" runat="server" Text="LOGICPRO SOLUTIONS "></asp:Label>--%></b>
                                                        <asp:Label ID="lbl_CollegeName" runat="server" Text="LOGICPRO SOLUTIONS "></asp:Label></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="color: Olive" width="500px">
                                                        <b>
                                                            <asp:Label ID="lbl_CollegeAddress" runat="server" Text=""></asp:Label>
                                                            <%--<asp:Label ID="lbl_CollegeName" runat="server" Text="INNOVATION THROUGH EXELLENCE"></asp:Label>--%></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <%--<asp:Label ID="lbl_CollegeAddress" runat="server" Text=""></asp:Label>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>



                                    <table width="100%">
                                        <tr>
                                            <td style="width:10%;">
                                                <asp:Label ID="Label2" runat="server" Text="Name :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td colspan="3" style="width:90%;">
                                                <asp:Label ID="lblName" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;">
                                                <asp:Label ID="Label3" runat="server" Text="Course :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblCourse" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:10%;">
                                                <asp:Label ID="Label4" runat="server" Text="Branch :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblBranch" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="auto-style1">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%;">
                                                <asp:Label ID="Label6" runat="server" Text="Class :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblClass" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:10%;">
                                                <asp:Label ID="Label8" runat="server" Text="Semester :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblSemester" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:GridView ID="GridView1" runat="server" Font-Size="14px" Width="100%">
                                    </asp:GridView>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="4">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="auto-style1">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:12%;">
                                                <asp:Label ID="Label10" runat="server" Text="Persentage :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblPersentage" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:12%;">
                                                <asp:Label ID="Label12" runat="server" Text="Result :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:40%;">
                                                <asp:Label ID="lblResult" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:12%;">
                                                <asp:Label ID="Label14" runat="server" Text="Remark" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:60%;">
                                                
                                            </td>
                                            <td style="width:20%;">
                                                <asp:Label ID="Label16" runat="server" Text="Principal Sign" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                                <br />
                                  <center>                                  
                            <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" 
                                        Text="Download" style="height: 28px" OnClick="btnDownload_Click" />
                                </center>
                            </asp:Panel>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                   <%-- </ContentTemplate>
               </asp:UpdatePanel>--%>
                </div> 
           </asp:Panel>
       </div>
</asp:Content>
