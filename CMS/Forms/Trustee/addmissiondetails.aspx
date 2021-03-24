<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Trustee/Trustee.Master" AutoEventWireup="true" CodeBehind="addmissiondetails.aspx.cs" Inherits="CMS.Forms.Trustee.addmissiondetails" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<center> <div style="margin-top:-445px;margin-left:50px; ">
     
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:DropDownList ID="ddlCountries" runat="server" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged"
    AutoPostBack="true">
</asp:DropDownList>
 
       <br />
 
<AjaxControlToolkit:BarChart ID="BarChart1" runat="server" ChartHeight="300" ChartWidth = "450" ChartTitleColor="#82191D" 
    Visible = "False" CssClass="auto-style1" style="margin-top: 6px" Height="308px" >
   
</AjaxControlToolkit:BarChart>
    </div>
</center>
      <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>






    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div style="height: 900px; width: 900px;">
                        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px; width: 911px; border: medium double#0C7BFA;">
                            <table border="0" width="100%" align="center" cellspacing="2px">
                                <tr>
                                    <th style="background-color: #0C7BFA; color: White">
                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Student Admission Report </li>
                                        </ul>
                                    </th>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="UpdatePanel_SetCourseClass" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="border: 3px solid #0099FF; width: 700px; height: auto; margin-left: auto; margin-right: auto;">
                                        <table border="0" width="700px" align="center" cellspacing="2px">
                                            <tr>
                                                <td colspan="2">
                                                    <%--<asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select Course !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>--%>
                                                    <asp:RequiredFieldValidator ID="rfvddlAcademicYear" runat="server" ControlToValidate="ddlAcademicYear" ErrorMessage="Please Select AcademicYear !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                                    <%--<asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Select Branch !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>--%>
                                                    <asp:RequiredFieldValidator ID="rffvddlOrgnization" runat="server" ControlToValidate="ddlOrgnization" ErrorMessage="Select Organization" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Select Organization :" Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:DropDownList ID="ddlOrgnization" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrgnization_SelectedIndexChanged" Width="300px" height="28px" >
                                                   <asp:ListItem Text="Select" Value="0"></asp:ListItem> 
                                                   </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Text="Select AcademicYear : "></asp:Label>
                                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" height="28px" Width="180">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click" Style="height: 28px ;width:80px" Text="Show" ValidationGroup="grpSave" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div >
                                                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Visible="False" Height="500px" ScrollBars="Auto">
            
                                                        <h2>Student Admission Report</h2>
                                                        <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No record present">
                                                            <EmptyDataRowStyle ForeColor="#FF3300" HorizontalAlign="Center" />
                                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                                        </asp:GridView>
            
                                                    </asp:Panel>
                                                        
                                                        </div>
                                                    <br /><center>
                                                        <asp:Button ID="btnExport" runat="server" class="btn btn-primary" Text="Export" Visible="False" OnClick="btnExport_Click" Height="28px" />
                                                        </center><br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </asp:Panel>
                    </div>



 </asp:Content>
    