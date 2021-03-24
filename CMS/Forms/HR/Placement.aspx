<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="Placement.aspx.cs" Inherits="CMS.Forms.HR.Placement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .auto-style2 {
            width: 69px;
        }
        .auto-style3 {
            width: 201px
        }
        .auto-style4 {
            width: 200px
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
                    <table border="0" width="100%" align="left" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li>Student Details</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td class="style1">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                <table width="700">
                                    <tr>
                                         <td class="input-medium" align="left">
                                            <asp:Label ID="lblUserCode" runat="server" Text="UserCode:" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="DDUserCode" runat="server" OnSelectedIndexChanged="DDUserCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                            <%--<asp:TextBox ID="txtUserCode" runat="server" OnTextChanged="txtUserCode_TextChanged" AutoPostBack="true"></asp:TextBox>--%>
                                        </td>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDUserCode" ErrorMessage="Please Select UserCode" InitialValue="0" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                         <td class="input-medium" align="left">
                                            <asp:Label ID="lblStudentName" runat="server" Text="Student Name :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtStudentName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td class="input-medium" align="left">
                                            <asp:Label ID="lblCourseName" runat="server" Text="Course Name :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style4">
                                            <asp:TextBox ID="txtCourseName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            <strong>Branch Name</strong></td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtBranchName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td class="input-medium" align="left">
                                            <strong>Address</strong></td>
                                        <td class="auto-style4">
                                            <asp:TextBox ID="txtAddress" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            <asp:Label ID="lblMobile" runat="server" Text="Mobile :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtMobile" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td class="input-medium" align="left">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style4">
                                            <asp:TextBox ID="txtEmail" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" bgcolor="#3399FF" style="color: #FFFFFF; font-weight: bold;"><center>
                                            <ul class="nav nav-list">
                                                <li style="color: #FFFFFF">Company Details</li>
                                            </ul></center>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            &nbsp;</td>
                                        <td class="auto-style3">
                                            &nbsp;</td>
                                        <td class="input-medium">
                                            &nbsp;</td>
                                        <td class="auto-style4">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left"><strong>Company
                                          
                                            Name</strong></td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtCompanyName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td class="input-medium" align="left"><strong>Company Address</strong></td>
                                        <td class="auto-style4">
                                            <asp:TextBox ID="txtCompanyAddress" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            &nbsp;
                                        </td>
                                        <td class="auto-style3">
                                            &nbsp;
                                        </td>
                                        <td class="input-medium" align="left">
                                            &nbsp;
                                        </td>
                                        <td class="auto-style4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            <strong>Position:</strong></td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtposition" runat="server" ></asp:TextBox>
                                           
                                        </td>
                                        <td class="input-medium" align="left">
                                            <strong>Package :</strong></td>
                                        <td class="auto-style4">
                                            <asp:TextBox ID="txtPackage" runat="server"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                            &nbsp;
                                        </td>
                                        <td class="auto-style3">
                                            &nbsp;
                                        </td>
                                        <td class="input-medium">
                                            &nbsp;
                                        </td>
                                        <td class="auto-style4">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPackage" ErrorMessage="Please Enter Package" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">
                                             <strong>Status :</strong><td class="auto-style3">
                                            <asp:RadioButtonList ID="rdoPlacementStatus" runat="server" RepeatDirection="Horizontal" Width="323px">
                                                <asp:ListItem>Offered</asp:ListItem>
                                                <asp:ListItem>Offered &amp; Joined</asp:ListItem>
                                            </asp:RadioButtonList>
                                                 </td>
                                             <td class="input-medium"></td>
                                             <td class="auto-style4"></td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium" align="left">&nbsp;</td>
                                        <td class="auto-style3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdoPlacementStatus" ErrorMessage="Please Select Status" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="input-medium"></td>
                                        <td class="auto-style4"></td>
                                    </tr>
                                    <tr>
                                        <td class="input-medium">
                                            &nbsp;
                                        </td>
                                        <td colspan="3" align="center" class="auto-style2">
                                           
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" ValidationGroup="abc" OnClick="btnSave_Click" 
                                                 />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary"
                                                Text="Cancel"  />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <div>
                                        <tr>
                                            <td colspan="4">
                                                <%--<asp:GridView ID="GrdBook" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IssueId,IssueDate,DueDate,BookId,BookName,GroupId,GroupName,StudentId,StdName" PageSize="5" Width="100%">
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
                                    <tr>
                                       <%-- <asp:GridView ID="GrdBook" runat="server" AutoGenerateColumns="False" DataKeyNames="IssueId" DataSourceID="SqlDataSource1">

                                            <Columns>
                                                 <asp:TemplateField HeaderText="Book Name">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBookName" runat="server" CausesValidation="false" Text='<%#Eval("BookName") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                <asp:BoundField DataField="IssueId" HeaderText="IssueId" InsertVisible="False" ReadOnly="True" SortExpression="IssueId" />
                                                <asp:BoundField DataField="GroupId" HeaderText="GroupId" SortExpression="GroupId" />
                                                <asp:BoundField DataField="BookId" HeaderText="BookId" SortExpression="BookId" />
                                                <asp:BoundField DataField="StudentId" HeaderText="StudentId" SortExpression="StudentId" />
                                                <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" SortExpression="IssueDate" />
                                                <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
                                                <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                                                <asp:BoundField DataField="TransDate" HeaderText="TransDate" SortExpression="TransDate" />
                                                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />
                                            </Columns>

                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSDBConnectionString %>" SelectCommand="SELECT [IssueId], [GroupId], [BookId], [StudentId], [IssueDate], [DueDate], [UserId], [TransDate], [IsActive] FROM [tblLibIssueBook]"></asp:SqlDataSource>
                                    </tr>
                                    </div>--%>

                                    </table>

                                    <br />

                                </center>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

