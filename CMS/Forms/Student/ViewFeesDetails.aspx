<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="ViewFeesDetails.aspx.cs" Inherits="CMS.Forms.Student.ViewFeesDetails" %>
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
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div style="width: 930px; height: 800px; border: medium double#0C7BFA; margin-top:-76px">
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center">
            <div style="height: 798px; width: 930px;">
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Student Paid Fees Details</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <br />
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
   <table style="width: 80%;">
                        <tr>
                            <td valign="top">
                                <div style=" overflow: scroll; height: 700px;">
                                <asp:GridView ID="GrdFeesPaidDetails" runat="server" CellPadding="4"
                                    DataKeyNames="ReceiptNo" Width="100%"
                                    AutoGenerateColumns="True" BorderColor="#3366CC" BorderStyle="None"
                                    ShowFooter="True" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399"
                                        HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True"
                                        ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <br /><br />
                        </td>
                        </tr>
                        </table>
                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        </asp:Panel>
                        </div>
</asp:Content>
