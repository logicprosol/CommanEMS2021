<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="ViewSalarySlip.aspx.cs" Inherits="CMS.Forms.Faculty.ViewSalarySlip" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px;width: 920px;"><%-- --%>
        <asp:Panel ID="Panel_BasicPaySettings" runat="server" Visible="true" ScrollBars="Auto" Style="height: 897px;
            width: 920px; border: medium double#0C7BFA;"><%----%>
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Post Salary</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" align="center" >
                <table border="0" width="90%" align="center" cellspacing="2px">
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Select Month"></asp:Label>
                            <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMonth" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMonth"
                                Format="MMM/yyyy">                                
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtMonth" ErrorMessage="Please Select Month !"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="btnShow" runat="server" CssClass="btn-primary"  Text="Show" OnClick="btnShow_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel2" runat="server" class="well well-large" Width="90%" Height="100%" Visible="False">
                    <%--<table border="0" width="99%" align="center" cellpadding="2px" cellspacing="2px">
                        <tr>
                            <td align="center" style="font-size: large; background-color: ActiveCaption;">
                                <asp:Label ID="Label4" runat="server" Text="Earning Heads"></asp:Label>
                            </td>
                            <td align="center" style="font-size: large; background-color: ActiveCaption;">
                                <asp:Label ID="Label5" runat="server" Text="Deduction Heads"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdEarning" runat="server" AutoGenerateColumns="False" Width="400px"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" DataKeyNames="CategoryName,ContentValue,ContentAction"
                                    CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Earning Heads" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Value In RS" DataField="ContentValue" />
                                    </Columns>
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
                            </td>
                            <td colspan="2">
                                <asp:GridView ID="grdDeduction" runat="server" AutoGenerateColumns="False" BackColor="White" DataKeyNames="CategoryName,ContentValue,ContentAction"
                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="400px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Deduction Heads" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Value In RS" DataField="ContentValue" />
                                    </Columns>
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
                            </td>
                        </tr>
                    </table>--%>

                    <asp:Panel ID="PanelSalary" runat="server" Width="100%" BorderStyle="Solid" >
                                <div style="margin-top:15px;margin-left:15px;margin-bottom:15px;margin-right:15px;">

                                    <center><asp:Label runat="server" Text="Pay Slip" Font-Bold="True" Font-Size="22px"></asp:Label> </center><br />
                                    <center><asp:Label ID="lblmonthyear" runat="server" Text="March 2019"  Font-Size="22px"></asp:Label> </center><br />

                                    <table style="width : 100%;">
                                        <tr>
                                            <td style="font-size: 14px; color:#33ccff /*#0099FF*/" >
                                                <b>
                                                <asp:Label ID="lbl_CollegeName" runat="server" Text="LOGICPRO SOLUTIONS " ></asp:Label></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >
                                                    <asp:Label ID="lbl_CollegeAddress" runat="server" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >
                                                    <asp:Label ID="lbl_Number" runat="server" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >
                                                    <asp:Label ID="lbl_website" runat="server" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                    <table style="width : 100%;" >
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Employee Details :" Font-Size="14px" ForeColor="#33ccff" Font-Bold="True" ></asp:Label>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td >
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <table width="100%">
                                        
                                        <tr>
                                            <td style="width:17%;">
                                                <asp:Label ID="Label5" runat="server" Text="Employee Name :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:33%;">
                                                <asp:Label ID="lblName" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                            </td>
                                            <td style="width:17%;">
                                                <asp:Label ID="Label15" runat="server" Text="Designation :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:33%;">
                                                <asp:Label ID="lblDesignation" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="Gross Salary :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblGross" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label17" runat="server" Text="Net salary :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNet" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="Work Days :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblWorkday" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label19" runat="server" Text="Absence :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblAbsence" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="80%"></asp:Label>
                                                <%--<asp:TextBox ID="txtAbsent" runat="server" Text="ABCDEF" Font-Size="14px" Enabled="false" BorderStyle="None" style="border-bottom:solid 1px;" Width="80%"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>


                                    <table style="width : 100%;" >
                                    <tr>
                                        
                                        <td >
                                            <asp:Label ID="Label20" runat="server" Text="Scale of Payment :" Font-Size="14px" ForeColor="#33ccff" Font-Bold="True" ></asp:Label>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td >
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:GridView ID="GridView1" runat="server" Font-Size="14px" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#33ccff" Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>

                                    <br />
                                    
                                    <table style="width : 100%;" >
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Text="Bank Details :" Font-Size="14px" ForeColor="#33ccff" Font-Bold="True" ></asp:Label>
                                        </td>
                                    </tr>
                                    </table>

                                    <table width="100%">
                                        
                                        <tr>
                                            <td colspan="4" >
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:18%;">
                                                <asp:Label ID="Label22" runat="server" Text="Payment Date :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblPaymentDate" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="40%"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text="Bank Name :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblBankName" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="40%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Label ID="Label24" runat="server" Text="Holder Name :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHolderName" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="40%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Label ID="Label25" runat="server" Text="Account Number :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAccountNumber" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="40%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Label ID="Label26" runat="server" Text="Branch :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBankBranch" runat="server" Text="ABCDEF" Font-Size="14px" style="border-bottom:solid 1px;" Width="40%"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>


                </asp:Panel>
                <br />
                <asp:Panel ID="Panel3" runat="server" Width="700px"  Visible="False" >
                                <div style="margin-left:15px;margin-bottom:15px;margin-right:15px;" class="auto-style10" runat="server" id="tbldata">
 
                                                            <table width="100%"  >
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        &nbsp;</td>
                                                                    <td align="center" colspan="2">
                                                                        <asp:Label runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="12pt" ForeColor="Black" Text="PaySlip"></asp:Label>
                                                                        <asp:Label ID="lblmonthyear1" runat="server" Font-Names="Times New Roman" Font-Size="12pt" ForeColor="Black" Text="March 2019"></asp:Label>
                                                                    </td>
                                                                    <td style="width:33%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="lbl_CollegeName1" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="11pt" ForeColor="#33CCFF" Text="LOGICPRO SOLUTIONS "></asp:Label>
                                                                        <asp:Label ID="lbl_CollegeAddress1" runat="server" Font-Names="Times New Roman" Font-Underline="True"></asp:Label>
                                                                        <asp:Label ID="lbl_Number1" runat="server" Font-Names="Times New Roman" Font-Underline="True"></asp:Label>
                                                                        <asp:Label ID="lbl_website1" runat="server" Font-Names="Times New Roman" Font-Underline="True"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td style="width:33%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="11pt" ForeColor="#33CCFF" Text="Employee Details "></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td style="width:33%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label13" runat="server" Font-Bold="False"  Text="Employee Name :" Font-Names="Times New Roman"></asp:Label>
                                                                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Gross Salary :"></asp:Label>
                                                                        <asp:Label ID="Label33" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Work Days :"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="lblName1" runat="server" Text="ABCDEF" Font-Names="Times New Roman" Font-Underline="False"></asp:Label>
                                                                        <asp:Label ID="lblGross1" runat="server" Text="ABCDEF" Font-Names="Times New Roman" Font-Underline="False"></asp:Label>
                                                                        <asp:Label ID="lblWorkday1" runat="server" Text="ABCDEF" Font-Names="Times New Roman" Font-Underline="False"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label27" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Designation :"></asp:Label>
                                                                        <asp:Label ID="Label31" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Net salary :"></asp:Label>
                                                                        <asp:Label ID="Label35" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Absence :"></asp:Label>
                                                                    </td>
                                                                    <td style="width:33%;">
                                                                        <asp:Label ID="lblDesignation1" runat="server" Text="ABCDEF" Font-Names="Times New Roman"></asp:Label>
                                                                        <asp:Label ID="lblNet1" runat="server" Text="ABCDEF" Font-Names="Times New Roman"></asp:Label>
                                                                        <asp:Label ID="lblAbsence1" runat="server" Text="ABCDEF" Font-Names="Times New Roman"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label37" runat="server" Font-Bold="True" ForeColor="#33CCFF" Text="Scale of Payment " Font-Names="Times New Roman" Font-Size="11pt"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" CellPadding="1" Width="100%">
                                                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                            <HeaderStyle BackColor="#33CCFF" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman" VerticalAlign="Middle" />
                                                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                            <RowStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Font-Names="Times New Roman" VerticalAlign="Middle" />
                                                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label38" runat="server" Font-Bold="True" ForeColor="#33CCFF" Text="Bank Details " Font-Names="Times New Roman" Font-Size="11pt"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td class="input-medium">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="Label39" runat="server" Font-Bold="False" Text="Payment Date :" Font-Names="Times New Roman"></asp:Label>
                                                                   
                                                                        <asp:Label ID="Label41" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Bank Name :"></asp:Label>
                                                                        <asp:Label ID="Label43" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Holder Name :"></asp:Label>
                                                                        <asp:Label ID="Label45" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Account Number :"></asp:Label>
                                                                        <asp:Label ID="Label47" runat="server" Font-Bold="False" Font-Names="Times New Roman" Text="Branch :"></asp:Label>
                                                                   
                                                                        </td>
                                                                    <td class="input-medium">
                                                                        <asp:Label ID="lblPaymentDate1" runat="server" Font-Names="Times New Roman" Text="ABCDEF"></asp:Label>
                                                                        <asp:Label ID="lblBankName1" runat="server" Font-Names="Times New Roman" Text="ABCDEF"></asp:Label>
                                                                        <asp:Label ID="lblHolderName1" runat="server" Font-Names="Times New Roman" Text="ABCDEF"></asp:Label>
                                                                        <asp:Label ID="lblAccountNumber1" runat="server" Font-Names="Times New Roman" Text="ABCDEF"></asp:Label>
                                                                        <asp:Label ID="lblBankBranch1" runat="server" Font-Names="Times New Roman" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td class="input-medium">
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                               
                                                                <tr>
                                                                    <td align="left" class="input-medium">
                                                                        &nbsp;</td>
                                                                    <td align="left" class="input-medium">
                                                                        &nbsp;</td>
                                                                    <td align="left" class="input-medium">&nbsp;</td>
                                                                    <td align="left">&nbsp;</td>
                                                                </tr>
                                                               
                                                            </table>
                                                    

                                </div>
                            </asp:Panel>
                <center><%--<asp:Button ID="btnPostSalary" runat="server" Text="Post Salary" 
                                class="btn btn-primary" onclick="btnPostSalary_Click" Visible="False" />--%>
                                <asp:Button ID="btnPrintSalarySlip" runat="server" Text="Print Salary Slip"
                                class="btn btn-primary" onclick="btnPrintSalarySlip_Click" Visible="false"/>

                </center>


                <%--<asp:Panel ID="Panel3" runat="server" class="well well-large" Width="90%" Height="100px">
                    <table border="0" width="99%" align="center" cellpadding="2px" cellspacing="2px">
                        
                        
                         <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Basic Salary : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBasicSalary" runat="server" Enabled="false" Text="0"></asp:TextBox>
                              
                            </td>
                            <td>
                               
                            </td>
                            <td>
                             
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Gross Salary : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrossSalary" runat="server" Text="0" Enabled="false"></asp:TextBox>
                              
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Total Deductions : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeductions" runat="server" Text="0" Enabled="false"></asp:TextBox>
                              
                            </td>
                        </tr>

                         <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Leave Deductions : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalLeave" runat="server"  Text="0" Enabled="false"></asp:TextBox>
                              
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Net Salary : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNetSalary" runat="server" Text="0" Enabled="false"></asp:TextBox>
                              
                            </td>
                        </tr>
                        <tr>
                        <td> </td>
                           
                        <td align="right"><asp:Button ID="btnPostSalary" runat="server" Text="Post Salary" 
                                class="btn btn-primary" onclick="btnPostSalary_Click" />
                                <asp:Button ID="btnPrintSalarySlip" runat="server" Text="Print Salary Slip"
                                class="btn btn-primary" onclick="btnPrintSalarySlip_Click" Visible="false"/>
                                </td>
                        </tr>
                    </table>
                    <br /><br />
                </asp:Panel>--%>
            </asp:Panel>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </asp:Panel>
    </div>
    

</asp:Content>
