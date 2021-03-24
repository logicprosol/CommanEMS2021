<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Trustee/Trustee.Master" AutoEventWireup="true" CodeBehind="InventoryGraphs.aspx.cs" Inherits="CMS.Forms.Trustee.InventoryGraphs" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>   
    <style type="text/css">
        .auto-style2 {
            width: 130px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div style="width: 800px;height: 900px; border: medium double#0C7BFA;"><%-- --%>
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center">
            <div style="height:800px; width: 800px;"><%----%>
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Inventory Report</li>
                            </ul>
                        </th>
                    </tr>
                </table>

           <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style=" border: medium double#0C7BFA;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnDownload" />
                </Triggers>
                <ContentTemplate>
                  
     

                    <table width="400px">
                        <tr>
                            <td colspan="3" >
                                <asp:RequiredFieldValidator ID="rfvSearchStudent0" runat="server" ControlToValidate="ddlCountries" ErrorMessage="Please Select Organization !!!" ForeColor="red" InitialValue="Select" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Select Organization"></asp:Label>
                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" OnClick="btnDownload_Click" Text="DownLoad" ValidationGroup="GeneralDetails" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                     <asp:Panel ID="PanelStudent" runat="server" HorizontalAlign="Center"  ScrollBars="Auto" >
                        <h2>Inventory Report</h2>
                         <center>
        <asp:GridView ID="GridView1" runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataTemplate>
                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="No record present!"></asp:Label>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                         </asp:GridView>
</center>
                     </asp:Panel>
                    <br />
    </div>
      </ContentTemplate></asp:UpdatePanel>

           </asp:Panel>
                </div></asp:Panel></div>
     <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
