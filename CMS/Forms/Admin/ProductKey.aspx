<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/ProductKey.Master" AutoEventWireup="true" CodeBehind="ProductKey.aspx.cs" Inherits="CMS.Forms.Admin.ProductKey" %>
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

    <style type="text/css">
        .auto-style1
        {
            height: 39px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Scheme" runat="server" align="center" UpdateMode="Conditional">
        <ContentTemplate>
      
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel_Scheme" runat="server" Visible="true" Style="height: 895px;
                    width: 930px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Product Key</li>
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
                           <%-- <td>
                                <asp:Label ID="lblHostel" runat="server" Text="Select Hostel Name :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHostel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHostel_SelectedIndexChanged"
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>--%>
                          <%--  <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlScheme" runat="server" ControlToValidate="ddlHostel"
                                    InitialValue="Select" ErrorMessage="Please select Hostel" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>
                         <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label6" runat="server" Text="Enter Mail Product Key :"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="auto-style1" >
                               <%-- <asp:DropDownList ID="drpHostelType" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                                
                            </td>
                        </tr>

                         <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label1" runat="server" Text="Enter Mobile OTP :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="auto-style1" >
                               <%-- <asp:DropDownList ID="drpHostelType" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtOTPABC" runat="server"></asp:TextBox>
                                
                            </td>
                        </tr>

                         <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text=" Time Period:"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td >
                              <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtTimePeriod" runat="server"></asp:TextBox>
                               <asp:CalendarExtender ID="txtTimePeriod_CalendarExtender" runat="server" 
                               TargetControlID="txtTimePeriod" Format="yyyy/MM/dd" DaysModeTitleFormat="yyyy/MM/dd" TodaysDateFormat="yyyy/MM/dd">
                              </asp:CalendarExtender>
                            </td>
                        </tr>

                          <tr>
                               <td>
                                  <asp:Label ID="Label209" runat="server" Text="Organization Name"></asp:Label>
                                  <asp:Label ID="Label46" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                               </td>
                               <td>
                                   <asp:TextBox ID="txtCollege" runat="server" Enabled="false"></asp:TextBox>
                              </td>
                            </tr>

                         


                         <tr>
                            <td>
                                &nbsp;</td>
                            <td >
                              <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                            </td>
                        <%--    <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlScheme"
                                    InitialValue="Select" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                             <asp:HiddenField ID="hdbId" runat="server" />
                        </tr>

                    <tr>
                      <td colspan="2" align="center">
                      <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnSave_Click"  />
                        <%--   <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" ValidationGroup="ValidateDocument" OnClick="btnUpdate_Click" />
                                       <asp:Button ID="btnDelete" runat="server" class="btn btn-primary"  Text="Delete" ValidationGroup="ValidateDocument" OnClick="btnDelete_Click" />--%>
                                       <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" Text="Cancel" ValidationGroup="ValidateDocument" OnClick="btnCancel_Click" />
                      <%--<asp:Button ID="btnUpdate" runat="server" Text="Update Fees" class="btn btn-primary" ValidationGroup="ValidateDocument" 
                                     />--%>
                   <%--   <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnDelete_Click" 
                                    />
                      <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnCancel_Click"
                                    CausesValidation="false" />--%>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                 
                    </table>

                         
                        <%--    <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlScheme"
                                    InitialValue="Select" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                       

<%--                     <table>
                        <tr>
                            <td>
                        <asp:GridView ID="gvhostelInfo" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="750px" AllowPaging="True" PageSize="100">
                          
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
         
                    <br />

                    <asp:HiddenField ID="hdbId" runat="server" />
                    <br />
                </div>
                            </td>
                        </tr>
                    </table>--%>
                
                
                </asp:Panel>
              
            </div>
              <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
