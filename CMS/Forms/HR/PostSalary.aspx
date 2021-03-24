<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"
    CodeBehind="PostSalary.aspx.cs" Inherits="CMS.Forms.HR.PostSalary" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style7 {
            width: 22%;
        }
        .auto-style8 {
            width: 21%;
        }
        .auto-style9 {
            border-bottom-style: solid;
        }
        .auto-style10 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 920px;"><%----%>
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
                        <td colspan="4">
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMonth" ErrorMessage="Please Select Month !" InitialValue="-1" ValidationGroup="go"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDL_Department" ErrorMessage="Please Select Department !" InitialValue="-1" ValidationGroup="go"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvrbtnFacultyType" runat="server" ControlToValidate="rbtnFacultyType" ErrorMessage="Please Select Designation type!!!" ForeColor="Red" ValidationGroup="go"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDL_Designation" ErrorMessage="Please Select Designation !" InitialValue="-1" ValidationGroup="go"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDL_EmoloyeeName" ErrorMessage="Please Select employee !" InitialValue="-1" ValidationGroup="go"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Select Month"></asp:Label>
                            <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMonth" runat="server"  placeholder="select Month"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMonth"
                                Format="MMM/yyyy">                                
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Select Department"></asp:Label>
                            <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Department" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Department_SelectedIndexChanged" width="180">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFacultyType" runat="server" Text="Faculty Type : "></asp:Label>
                            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbtnFacultyType" runat="server" AutoPostBack="true" class="radio" OnSelectedIndexChanged="rbtnFacultyType_SelectedIndexChanged" RepeatDirection="Horizontal" Width="220px">
                                <asp:ListItem Text="Teaching" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NonTeaching" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Select Designation"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDL_Designation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Designation_SelectedIndexChanged" width="180">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Select Employee"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_EmoloyeeName" runat="server" width="180">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="DDL_EmoloyeeName_SelectedIndexChanged" Text="Go" ValidationGroup="go" Visible="true" />
                        </td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="go" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                    <div >
                    <asp:Panel ID="PanelSalary" runat="server" Width="100%" BorderStyle="Solid">
                                <div style="margin-top:15px;margin-left:15px;margin-bottom:15px;margin-right:15px;">

                                    <center><asp:Label runat="server" Text="Employee" Font-Bold="True" Font-Size="22px" ForeColor="#0099FF"></asp:Label>&nbsp;<asp:Label runat="server" Text="Pay slip" Font-Bold="True" Font-Size="22px"></asp:Label>&nbsp;<asp:Label runat="server" Text="Record" Font-Bold="True" Font-Size="22px" ForeColor="#0099FF"></asp:Label>  </center><br />
                                    <table style="width : 100%;">
                                        <tr>
                                            <td style=" color: #0099FF" >
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
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                    <table style="width : 100%;" >
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Employee Details :" Font-Size="14px" ForeColor="#0099FF" Font-Bold="True" ></asp:Label>
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
                                                <asp:Label ID="lblName" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:17%;">
                                                <asp:Label ID="Label15" runat="server" Text="Designation :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td style="width:33%;">
                                                <asp:Label ID="lblDesignation" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblGross" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label17" runat="server" Text="Net salary :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNet" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblWorkday" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label19" runat="server" Text="Absence :" Font-Size="14px"></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="lblAbsence" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                            <asp:Label ID="Label20" runat="server" Text="Scale of Payment :" Font-Size="14px" ForeColor="#0099FF" Font-Bold="True" ></asp:Label>
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
                                        <HeaderStyle BackColor="#0099FF" Font-Bold="True" ForeColor="#CCCCFF" />
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
                                            <asp:Label ID="Label21" runat="server" Text="Bank Details :" Font-Size="14px" ForeColor="#0099FF" Font-Bold="True" ></asp:Label>
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
                                                <asp:Label ID="lblPaymentDate" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblBankName" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblHolderName" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblAccountNumber" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
                                                <asp:Label ID="lblBankBranch" runat="server" Text="ABCDEF" Font-Size="14px"></asp:Label>
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
</div>
 </asp:Panel>
              
                       <asp:Panel ID="Panel3" runat="server" Width="700px"  Visible="False" >
                                <div style="margin-left:15px;margin-bottom:15px;margin-right:15px;" class="auto-style10" runat="server" id="tbldata">

                                                            <table width="100%"  >
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        &nbsp;</td>
                                                                    <td class="auto-style9" align="center" colspan="2" style="border-color: #000000; border-bottom-style: solid; border-bottom-width: 2px">
                                                                        <asp:Label runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="#0099FF" Text="Employee PaySlip Record"></asp:Label>
                                                                    </td>
                                                                    <td style="width:33%;">
                                                                        <asp:Label ID="lbl_CollegeAddress1" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2"><b>
                                                                        <asp:Label ID="lbl_CollegeName1" runat="server" Font-Size="12pt" Text="LOGICPRO SOLUTIONS "></asp:Label>
                                                                        </b></td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td style="width:33%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#0099FF" Text="Employee Details :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td style="width:33%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label13" runat="server" Font-Bold="True"  Text="Employee Name :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="lblName1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="Label27" runat="server" Font-Bold="True"  Text="Designation :"></asp:Label>
                                                                    </td>
                                                                    <td style="width:33%;">
                                                                        <asp:Label ID="lblDesignation1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label29" runat="server" Font-Bold="True"  Text="Gross Salary :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="lblGross1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="Label31" runat="server" Font-Bold="True"  Text="Net salary :"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblNet1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label33" runat="server" Font-Bold="True"  Text="Work Days :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="lblWorkday1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">
                                                                        <asp:Label ID="Label35" runat="server" Font-Bold="True"  Text="Absence :"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAbsence1" runat="server"  Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label37" runat="server" Font-Bold="True" ForeColor="#0099FF" Text="Scale of Payment :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" CellPadding="1" Width="100%">
                                                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                            <HeaderStyle BackColor="#0099FF" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                            <RowStyle BackColor="White" ForeColor="Black" />
                                                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style7">
                                                                        <asp:Label ID="Label38" runat="server" Font-Bold="True" ForeColor="#0099FF" Text="Bank Details :"></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td class="auto-style8">&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="auto-style7">
                                                                        <asp:Label ID="Label39" runat="server" Font-Bold="True" Text="Payment Date :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <asp:Label ID="lblPaymentDate1" runat="server" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Bank Name :"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblBankName1" runat="server" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="auto-style7">
                                                                        <asp:Label ID="Label43" runat="server" Font-Bold="True" Text="Holder Name :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <asp:Label ID="lblHolderName1" runat="server" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">&nbsp;</td>
                                                                    <td align="left">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="auto-style7">
                                                                        <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Account Number :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <asp:Label ID="lblAccountNumber1" runat="server" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                    <td align="left" class="auto-style8">
                                                                        <asp:Label ID="Label47" runat="server" Font-Bold="True" Text="Branch :"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblBankBranch1" runat="server" Text="ABCDEF"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                               
                                                            </table>
                                                    

                                </div>
                            </asp:Panel> 
                <br />
                <center><asp:Button ID="btnPostSalary" runat="server" Text="Post Salary" 
                                class="btn btn-primary" onclick="btnPostSalary_Click" Visible="False" />
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
