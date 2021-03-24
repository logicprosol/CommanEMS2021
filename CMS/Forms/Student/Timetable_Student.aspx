<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="Timetable_Student.aspx.cs" Inherits="CMS.Forms.Student.Timetable_Student" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style2 {
             width: 268px;
         }
         .auto-style3 {
             width: 20px
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   

 <%--   <asp:UpdatePanel ID="updatepnl" runat="server">  
<ContentTemplate> --%>
    <!-- Start here-->
    <div style="border: medium double#0C7BFA; vertical-align: top; height: 900px;" class="auto-style20" >
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Time Table</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
        <table>
               <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Width="920px" Height="900px" ScrollBars="Auto"><%----%>
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
                                <table class="auto-style2" style="border: 3px solid #0099FF; margin: 3px;" width="700px">
                                    
                                    <tr>
                                        <td class="auto-style3">
                                            &nbsp;</td>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td>
                                            &nbsp;</td>
                                        <td class="auto-style3">
                                            &nbsp;</td>
                                       
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="auto-style15" colspan="3">
                                            <asp:GridView ID="GridView1" runat="server"  CellPadding="4" 
                                                ForeColor="#333333" GridLines="None" Width="700px" EmptyDataText="No record found">
                                                <AlternatingRowStyle BackColor="White" />
                                               
                                                <EditRowStyle BackColor="#2461BF" />
                                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </td>
                                        <td class="auto-style3">
                                            <%--<asp:DropDownList ID="ddlUnitType" runat="server" Height="27px" Width="196px">
                                                <asp:ListItem>Select Unit Test</asp:ListItem>
                                                <asp:ListItem>Unit I</asp:ListItem>
                                                <asp:ListItem>Unit II</asp:ListItem>
                                                <asp:ListItem>Unit III</asp:ListItem>
                                                <asp:ListItem>Unit IV</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style17">&nbsp;</td>
                                        <td class="auto-style18">&nbsp;</td>
                                        <td class="auto-style18">
                                            &nbsp;</td>
                                        <td class="auto-style3">
                                            &nbsp;</td>
                                    </tr>

                                    </table>
                                </asp:Panel>
                                </center>

                                </asp:Panel>
                    </td></tr></table>
    </div> 
</asp:Content>