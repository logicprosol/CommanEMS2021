<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="StudentPlacementReg.aspx.cs" Inherits="CMS.Forms.Student.StudentPlacementReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style13 {
            width: 700px;
            margin-top: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 900px;" align="center">
                <asp:Panel ID="Panel1" runat="server" Visible="true" Style="height: 900px; width: 920px;
                    border: medium double#0C7BFA;">
                   <center>
                    <table class="auto-style13">
                        <tr>
                            <td bgcolor="#1885BB" colspan="4" height="25px" align="center">
                                <asp:Label ID="lblUserCode0" runat="server" ForeColor="White" Text="Placement registration form" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblUserCode" runat="server" Text="UserCode:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtUserCode" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStudentName" runat="server" Font-Bold="True" Text="Student Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtStudentName" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCourseName" runat="server" Font-Bold="True" Text="Course Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtCourseName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStudentName0" runat="server" Font-Bold="True" Text="Branch Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtBranchName" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStudentName1" runat="server" Font-Bold="True" Text="Address"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtAddress" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile" runat="server" Font-Bold="True" Text="Mobile :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtMobile" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="Email :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtEmail" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile0" runat="server" Font-Bold="True" Text="Company Name"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcompanyName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="170px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblMobile1" runat="server" Font-Bold="True" Text="Company Address"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyAddress" runat="server" Enabled="false" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcompanyName" ErrorMessage="Select Company Name" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyAddress" ErrorMessage="Enter Company Address" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile3" runat="server" Font-Bold="True" Text="Website"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebsite" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblMobile4" runat="server" Font-Bold="True" Text="E-mail"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyEmail" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile5" runat="server" Font-Bold="True" Text="Mobile"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyMobile" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblMobile6" runat="server" Font-Bold="True" Text="Contact Person"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPerson" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMobile2" runat="server" Font-Bold="True" Text="Criteria :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCriteria" runat="server" Width="170px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtposition" ErrorMessage="Enter Position" ValidationGroup="grpSave"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2" align="right">
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="grpSave" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <%--<asp:GridView ID="GrdBook" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IssueId,IssueDate,DueDate,BookId,BookName,GroupId,GroupName,StudentId,StdName" PageSize="5" Width="700px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Book Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBookName" runat="server" CausesValidation="false" Text='<%#Eval("BookName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GroupName" HeaderText="Group" />
                                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
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
                                </asp:GridView>--%>
                            </td>
                        </tr>
                    </table>
                            </center>                      
                    <br />
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


