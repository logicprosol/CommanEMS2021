<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInstallment.aspx.cs" Inherits="CMS.Forms.Admin.AddInstallment" MasterPageFile="~/Forms/Admin/Admin.Master" %>


<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <script type = "text/javascript">
        function ConfirmDelete() {
            confirm_value.value = "Yes";
            document.forms[0].removeChild(confirm_value);
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    $(function () {
        $("#<%=ddlCourse.ClientID%>").select2();
    })
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 930px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 895px;
            width: 930px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Installments</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
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
                                <asp:Label ID="lblCourse" runat="server" Text="Class :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td width="220px">
                                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" ValidationGroup="validaiton" Width="205">
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse"
                                    InitialValue="Select" ErrorMessage="Please select Course" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                      
                        <tr>
                            <td>
                                <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" ValidationGroup="validaiton"
                                     Width="205px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlAcademicYear" runat="server" ControlToValidate="ddlAcademicYear"
                                    InitialValue="0" ErrorMessage="Please select Academic Year" ForeColor="Red"
                                    ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        
                        <tr>
                           <td>
                                 <asp:Label ID="Label2" runat="server" Text="Installment No :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                           </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtinstallmentno" Width="200px"></asp:TextBox>
                            </td>
                             
                        </tr>


                         <tr>
                           <td>
                                 <asp:Label ID="Label4" runat="server" Text="Installment Amount :"></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                           </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtInstallmentAmt" Width="200px"></asp:TextBox>
                            </td>
                             
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="From Remainder Date:"></asp:Label>
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtFromdate" runat="server"  Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="StartDateCalendarExtender" runat="server" TargetControlID="txtFromdate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="To Remainder Date:"></asp:Label>
                                <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="TxtToDate" runat="server"  Width="200px" OnTextChanged="TxtToDate_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtToDate"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                 <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" onclick="btnNew_Click"/>
                                 <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" OnClick="btnsave_Click"/>
                                </td>
                            <td>
                                 <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" OnClick="btnUpdate_Click"/>
                                 <asp:Button ID="Btndelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" OnClick="Btndelete_Click"/> 
                            </td>
                           
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table style="width: 80%">
                        <tr>
                            <td>
                            <asp:Panel ID="Panel1" runat="server" Height="350px" HorizontalAlign="Center"  Width="100%" ScrollBars="Auto">
                                    <asp:GridView ID="GRDinstallments" runat="server" 
                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                        DataKeyNames="InstallmentId,InstallmentNo,class,AcademicYear,InstallmentAmt,FromDate,ToDate,ClassId,AcademicYearId" PageSize="20" 
                                        Width="80%">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Number" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAmount" runat="server" CausesValidation="false" 
                                                      OnClick="lnkAmount_Click" Text='<%#Eval("InstallmentNo") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="class" HeaderText="Class" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                              <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="InstallmentAmt" HeaderText="Amount" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="FromDate" HeaderText="From Date" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ToDate" HeaderText="To Date" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                        </Columns>
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" 
                                            HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" 
                                            ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                        </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>