<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Trustee/Trustee.Master" AutoEventWireup="true" CodeBehind="PlacementsGraph.aspx.cs" Inherits="CMS.Forms.Trustee.PlacementsGraph" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>   
    <style type="text/css">
        .auto-style3 {
            width: 136px
        }
        .auto-style4 {
            width: 147px
        }
        .auto-style5 {
            width: 132px
        }
        .auto-style6 {
            width: 152px
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div style="width: 930px;height: 900px; border: medium double#0C7BFA;"><%-- --%>
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center">
            <div style="height: 798px; width: 800px;"><%----%>
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>View Announcement</li>
                            </ul>
                        </th>
                    </tr>
                </table>
               
        <table  width="700px">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style14"> &nbsp;</td>
                <td class="auto-style3"> &nbsp;</td>
                <td class="auto-style15"> &nbsp;</td>
                <td class="auto-style6"> &nbsp;</td>
                <td> &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style5"><div class="card-action" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Placed Students:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                                           
                            </div></td>
                <td class="auto-style14"> <asp:Label ID="lblplaced" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td class="auto-style3"> 
                    
                     <asp:Label ID="Label2" runat="server" Text="Offered Students:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style15"> <asp:Label ID="LblOffered" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td class="auto-style6">  
                     <asp:Label ID="Label3" runat="server" Text="Unplaced Students:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                   

                </td>
                <td> <asp:Label ID="lblUnplaced" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
            </tr>
            </table>


    
    
  


    
   
        <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style=" border: medium double#0C7BFA;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnDownload" />
                </Triggers>
                <ContentTemplate>
                  

                    
                    <table border="0" align="center" cellspacing="2px">
                            
                            <tr>
                                <td class="auto-style9" colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvSearchStudent1" runat="server" ControlToValidate="ddlOrganization" ErrorMessage="Please Select Organization !!!" ForeColor="red" InitialValue="Select" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSearchStudent" runat="server" ControlToValidate="ddlSearchStudent" ErrorMessage="Please Select student !!!" ForeColor="red" InitialValue="Select" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td class="auto-style16">
                                    &nbsp;</td>
                                
                                <td>&nbsp;</td>
                                
                            </tr>
                           
                            <tr>
                                <td class="auto-style9">
                                    <asp:Label ID="lblSearchStudent0" runat="server" CssClass="formlable" Font-Bold="False" Font-Size="10pt" Text="Select Organization"></asp:Label>
                                </td>
                                <td class="auto-style9">
                                    <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblSearchStudent" runat="server" CssClass="formlable" Font-Bold="False" Font-Size="10pt" Text="Search Student : "></asp:Label>
                                    <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSearchStudent" runat="server" AutoPostBack="true" Height="30px" OnSelectedIndexChanged="ddlSearchStudent_SelectedIndexChanged" SelectedIndexChanged="ddlSearchStudent_SelectedIndexChanged" ValidationGroup="GeneralDetails" Width="200px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="Offered &amp; Joined">Placed Student</asp:ListItem>
                                        <asp:ListItem Value="Offered">Offered Student</asp:ListItem>
                                        <asp:ListItem Value="UnPlaced">Unplaced Student</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" OnClick="btnDownload_Click" Text="DownLoad" ValidationGroup="GeneralDetails" />
                                </td>
                            </tr>
                           
                        </table>
                    <asp:Panel ID="PanelStudent" runat="server" HorizontalAlign="Center"  ScrollBars="Auto" >
                        <h2>Student Placement Report</h2>
                        <asp:GridView ID="grdStudent" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
                            <EmptyDataTemplate>
                                <asp:Label ID="lblSearchStudent" runat="server" CssClass="formlable" ForeColor="#FF3300" Text="No record present!"></asp:Label>
                            </EmptyDataTemplate>
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

                    </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
                </div>
           </asp:Panel>
        </div>
</asp:Content>

