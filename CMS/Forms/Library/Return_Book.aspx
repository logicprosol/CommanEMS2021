<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true" CodeBehind="Return_Book.aspx.cs" Inherits="CMS.Forms.Library.Return_Book" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style6 {
            width: 116px;
        }
        .auto-style7 {
            margin-top: 11px;
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
                                    <li><i class="icon-book"></i> Return Book </li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:HiddenField ID="hdnbarcode" runat="server" />
                                <asp:HiddenField ID="hdnfirstname" runat="server" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div style="border: 3px solid #0099FF; width: 800px">
                                <table width="80%">
                                    <tr>
                                         <td class="auto-style6">
                                             &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                         <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            <asp:Label ID="lblBarcode" runat="server" Text="Book No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBarcode" runat="server" AutoPostBack="true" OnTextChanged="txtBarcode_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;
                                            <asp:Label ID="lblIssueId" runat="server" Text="IssueId" Visible="False"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                         <td class="auto-style6">
                                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGroupName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIssue" runat="server" Text="Issue To :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueTo" runat="server" AutoPostBack="True" Enabled="false" OnTextChanged="txtIssueTo_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            <asp:Label ID="lblBookName" runat="server" Text="Book Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBookName" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                             <asp:Label ID="Label1" runat="server" Text="Student Name :"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtIssueName" runat="server" Enabled="false" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            <asp:Label ID="lblAuthor" runat="server" Text="Author :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuthor" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueDate" runat="server" Enabled="false"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Format="MM/dd/yyyy" TargetControlID="txtIssueDate">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:Label ID="Label8" runat="server" Text="Due Date :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDueDate" runat="server" Enabled="false"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDueDate_CalendarExtender" runat="server" Format="MM/dd/yyyy" TargetControlID="txtDueDate">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                            <center>
                                                <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" Text="Return Book" ValidationGroup="grpSave" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                                                &nbsp;
                                                <asp:HiddenField ID="searchdata" runat="server" />
                                            </center>
                                        </td>
                                        </center>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            &nbsp;
                                        </td>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <div>
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

                                    <tr>
                                        <td colspan="4" align="center">
                                           
                        
                                         
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT        tblLibAddBook.BookName, tblStudent.FirstName + ' ' + tblStudent.MiddleName + ' ' + tblStudent.LastName AS Name, tblLibIssueBook.IssueDate, 
                          tblLibIssueBook.DueDate, tblLibIssueBook.barcode, 
                         tblLibIssueBook.StudentId
FROM            tblLibIssueBook INNER JOIN
                         tblLibAddBook ON tblLibIssueBook.BookId = tblLibAddBook.BookId INNER JOIN
                         tblStudent ON tblLibIssueBook.StudentId = tblStudent.StudentId
WHERE        (tblLibIssueBook.barcode = @barcode)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="hdnbarcode" DefaultValue="0" Name="barcode" PropertyName="Value" />
                                                </SelectParameters>
                                                 </asp:SqlDataSource>
<%--                                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMSDBConnectionString %>" SelectCommand="SELECT [IssueDate], [DueDate],e] FROM [tblLibIssueBook]"></asp:SqlDataSource>--%>

                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
</div>
                                <div style="overflow: scroll; height: 400px">
<asp:GridView ID="gvbook" runat="server"  
                            PageSize="7" Width="800px" HeaderStyle-ForeColor="White" BackColor="#ECF0F1" HeaderStyle-BackColor="#5DADE2" ForeColor="Black" AutoGenerateColumns="False" IDataSourceID="gvbook" DataSourceID="SqlDataSource1" OnRowDataBound="gvbook_RowDataBound" CssClass="auto-style7">

                            <Columns>
                                <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink2" runat="server" 
                                        NavigateUrl='<%# "Return_Book.aspx?Id="+Eval("IssueId")%>'>select</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>



                                <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" SortExpression="IssueDate" />
                                <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
                             
                                <asp:BoundField DataField="barcode" HeaderText="BookNo" SortExpression="barcode" />
                             
                                  <asp:BoundField DataField="StudentId" HeaderText="StudentId" SortExpression="StudentId" />
                             
                            </Columns>

                            <HeaderStyle BackColor="#5DADE2" ForeColor="White" />
                        </asp:GridView></div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
