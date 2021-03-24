<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="OnlineResult.aspx.cs" Inherits="CMS.Forms.Student.OnlineResult" %>
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
             margin-top: 10px;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li>Online Result</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
        <table>
               <tr>
                <td width="700px">
                    <asp:Panel ID="Panel3" runat="server"  Height="800px"  HorizontalAlign="Center">
                       
                          
                            <div  style="overflow: scroll; height: 800px">
                             <center>
                                <br />
                                <asp:GridView ID="GridView2" runat="server"  Font-Size="Small" Width="900px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="No record present">
                                    
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                     <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    
                                </asp:GridView>
                              </center>
                                </div><br />
                     
                                </asp:Panel>
                    <br />
                    
                    
                    </td></tr></table>
           <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
