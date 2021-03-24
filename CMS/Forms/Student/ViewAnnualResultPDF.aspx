<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="ViewAnnualResultPDF.aspx.cs" Inherits="CMS.Forms.Student.ViewAnnualResultPDF" %>

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
      <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li>Annual exam Result</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
        <table>
               <tr>
                <td width="900px">
                  
                       
                          
                            <div  style="overflow: scroll; height: 700px; width: 900px;">
                             <center>
                                <br />
                        <asp:GridView ID="grdResults" runat="server" CellPadding="4" DataKeyNames="TestId,TestName,AcademicYear,FileName,ContentType,OrgId,UploadDate"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px" EmptyDataText="No record present">
                                    <Columns>
                                        <asp:BoundField DataField="TestName" HeaderText="Test Name" />
                                        <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                        <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year" />
                                        <asp:BoundField DataField="UploadDate" HeaderText="Upload Date" DataFormatString="{0:dd-M-yyyy}" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnDownload" runat="server" Text="Download"
                                                    OnClick="lnkBtnDownload_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label6" runat="server" Text="No record present!"></asp:Label>
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>

                                </center>
                                </div><br />
                     <asp:Label ID="lblNodata" runat="server" Text="Recode Not Found...!" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
                                
                    <br />
                    
                    
                    </td></tr></table>
                               
                               <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>

