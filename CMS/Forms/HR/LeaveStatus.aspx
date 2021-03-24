<%@ Page Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"
    Culture="en-IN" CodeBehind="LeaveStatus.aspx.cs" Inherits="CMS.Forms.HR.LeaveStatus" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        
         function TestCompleteAdmission() {
            
            
            {
                var TargetBaseControl = document.getElementById('<%= GrdLeaveDetails.ClientID %>');

                if (TargetBaseControl != null)
                {
                    var TargetChildControl = "chkbox";

                    //get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                
                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
                            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                            Inputs[n].checked) {
                           
                            return true;
                        }
                        
                            alert("Select at least one Leave!!!", "Warning");
                            return false;
                        
                }
                else
                {
                     alert("No record present!!!", "Warning");
                    return false;
                }

            
            }
        }
    </script>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 800px;
            width: 900px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Leave Status</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_LeaveApplication" runat="server" align="center"
                UpdateMode="Conditional">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave" />
                </Triggers>
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="Label2" runat="server" Text="Leave Application ID : " Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblLeaveApplicationId" runat="server" Font-Bold="true" Text="1" Visible="false"></asp:Label>
                            </td>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label1" runat="server" Text="Application Date : " Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblApplicationDate" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="Label3" runat="server" Text="Pending Leaves For
Approval" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" >
                                   <div ><%-- overflow-y: scroll;">--%>
                                       <asp:Panel ID="Panel1" runat="server" Width="100%" Height="500px" ScrollBars="Auto">
                                <asp:GridView ID="GrdLeaveDetails" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" 
                                    BorderStyle="None" CellPadding="4" EmptyDataText="No Records Found !" EmptyDataRowStyle-HorizontalAlign="Center"
                                   
                                    BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdLeaveDetails_PageIndexChanging" OnRowDataBound="GrdLeaveDetails_RowDataBound" Width="780px" DataKeyNames="Id,User Code,From Date,To Date">
                                    <Columns>
                                       <asp:TemplateField ItemStyle-Width="40px">
                                               
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbox" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Id" DataField="LeaveId"
                                            Visible="false" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Application Date"
                                            DataField="Application Date" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Name" DataField="Name" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="From Date" DataField="From Date" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="To Date" DataField="To Date" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Total Leave Days" DataField="Total Leave Days" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Reason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ItemStyle-Wrap="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Leave Status" DataField="Leave Status" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="User Code" DataField="User Code" Visible="False"  >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Org Id" DataField="Org Id"
                                            Visible="false" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" Width="15px" />
                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                           </asp:Panel>
                                       </div>
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="2" align="center">
                                <asp:Label ID="Label4" runat="server" Text="From : " Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txtFrom" runat="server" OnTextChanged="txtFrom_TextChanged" AutoPostBack="true"
                                    Width="120px" ValidationGroup="VG"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrom"
                                    Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <br />
                                <asp:RequiredFieldValidator ID="rfvTxtFrom" runat="server" Display="Dynamic" ErrorMessage="Select From Date"
                                    ControlToValidate="txtFrom" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label6" runat="server" Text="To :" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txtTo" runat="server" OnTextChanged="txtTo_TextChanged" AutoPostBack="true"
                                    Width="120px" ValidationGroup="VG"></asp:TextBox>
                                <br />
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                    Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvTxtTo" Display="Dynamic" runat="server" ErrorMessage="Select To Date"
                                    ControlToValidate="txtTo" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comDate" Display="Dynamic" runat="server" ErrorMessage=" Please Enter From Date Less Than To Date !!!"
                                    ControlToCompare="txtFrom" ControlToValidate="txtTo" CultureInvariantValues="True"
                                    Operator="GreaterThanEqual" Type="Date" ValidationGroup="VG"></asp:CompareValidator>
                                     
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div >
                                    <%--<asp:Panel ID="Panel2" runat="server" Width="100%" Height="200px" ScrollBars="Auto">
                                <asp:GridView ID="GrdLeaveApplication" runat="server" BorderColor="#3366CC" BorderStyle="None"
                                    CellPadding="4" AutoGenerateColumns="false" EmptyDataText="Please Select From And To Dates !"
                                    EmptyDataRowStyle-HorizontalAlign="Center" Width="95%" BackColor="White" BorderWidth="1px"
                                    OnRowDataBound="GrdLeaveApplication_RowDataBound" OnPageIndexChanging="GrdLeaveApplication_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" Text='<%# Eval("Date") %>' runat="server" Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Full / Half" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rbtFullHalf" runat="server" RepeatDirection="Horizontal"
                                                    Font-Size="10px" SelectedValue='<%# Bind("Full_Half")%>' OnTextChanged="rbtnFullHalf_SelectedIndexChanged"
                                                    AutoPostBack="true" Height="16px" Width="114px" CssClass="radio">
                                                    <asp:ListItem Value="1" Text="Full" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Half"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                        </asp:Panel>--%>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="Label7" runat="server" Text="Select Status : " Font-Bold="True"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                    <asp:ListItem Value="0">--Select Status--</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approve</asp:ListItem>
                                    <asp:ListItem Value="Rejected">Reject</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Select Leave Status..!" InitialValue="0" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblReason" runat="server" Text="Reason : " Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="txtReason" runat="server" TextMode="SingleLine" Width="70%" Height="70px"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="rfvReason" runat="server" ErrorMessage="Enter Reason !!!"
                                    ControlToValidate="txtReason" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click"
                                    ValidationGroup="VG" OnClientClick="javascript:return TestCompleteAdmission()" />
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>