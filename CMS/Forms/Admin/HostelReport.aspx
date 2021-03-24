<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="HostelReport.aspx.cs" Inherits="CMS.Forms.Admin.HostelReport" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script>

        function forceNumeric() {
            var $input = $(this);
            $input.val($input.val().replace(/[^\d]+/g, ''));
        }
        $('body').on('propertychange input', 'input[type="number"]', forceNumeric);
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents1.ClientID %>");
             var printWindow = window.open('', '', '');
             printWindow.document.write('<html><head><title>Hostel Report</title>');
             printWindow.document.write('</head><body align="center" >');
             printWindow.document.write(panel.innerHTML);  
             printWindow.document.write('</body></html>');
             
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Scheme" runat="server" align="center" UpdateMode="Conditional">
        <ContentTemplate>
      
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel_Scheme" runat="server" Visible="true" Style="height: 895px;
                    width: 930px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Hostel</li>
                        </ul>
                    </th>
                </tr>
            </table>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblHostel" runat="server" Text="Select Hostel Name :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHostel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHostel_SelectedIndexChanged" Height="27px" Width="146px" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          <%--  <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlScheme" runat="server" ControlToValidate="ddlHostel"
                                    InitialValue="Select" ErrorMessage="Please select Hostel" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>
                         <tr>
                            <td>
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
             

            </table>
                       
                        <div style="overflow: scroll; height: 600px">
                     <table>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlContents1" runat="server" ScrollBars="Auto" Height="400px" HorizontalAlign="Center" Visible="False" >
                                    <asp:Label ID="lblOrgName" runat="server" Text="Label" Font-Bold="True" Font-Size="Large"></asp:Label><br />
                                    <asp:Label ID="lblHostelName" runat="server" Text="Label" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    <br /><br />
                                <asp:GridView ID="gvhostelInfo" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="700px">
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                    </asp:Panel>
                            </td>
         
                        </tr>
                         <tr>
                             <td align="center"><br /><asp:Button ID="btnPrint" runat="server" Text="Print" Visible="false" class=" btn btn-info" OnClientClick="return PrintPanel();"  /></td>
                         </tr>
                    </table>
</div>

                   
                    <br />

                
                
                </asp:Panel>
              
            </div>
   <%--           <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
