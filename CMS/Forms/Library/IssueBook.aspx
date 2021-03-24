<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true"
    CodeBehind="IssueBook.aspx.cs" Inherits="CMS.Forms.Library.IssueBook" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script type = "text/javascript">
        function ConfirmDelete() {
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
         </script>

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
                                    <li><i class="icon-book"></i>Issue Book</li>
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
                                <table width="90%">
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPublishYear" runat="server" Text="Publish Year :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublishYear" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="ddlGroupName"
                                                ErrorMessage="Please Select Group" ForeColor="Red" ValidationGroup="grpSave"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblBookName" runat="server" Text="Book Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEdition" runat="server" Text="Edition :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEdition" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvPayBookName" runat="server" ControlToValidate="ddlBookName"
                                                ErrorMessage="Please Select Book Name" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblAuthor" runat="server" Text="Author :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPrice" runat="server" Text="Price :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblPublisher" runat="server" Text="Publisher :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
                                        </td>
                                       
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Stock :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblstock" runat="server" Text="Current Stock "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Issue Book Details</li>
                                            </ul>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblIssue" runat="server" Text="Issue To :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueTo" runat="server" AutoPostBack="True" 
                                                ontextchanged="txtIssueTo_TextChanged"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueDate" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Format="dd/MM/yyyy"  
                                                TargetControlID="txtIssueDate">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueName" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Due Date :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDueDate" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd/MM/yyyy"  
                                                TargetControlID="txtDueDate">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="3">
                                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary"
                                                Text="New" OnClick="btnNew_Click" />
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" ValidationGroup="grpSave"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary"
                                                Text="Cancel" OnClick="btnCancel_Click" />
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="3">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:GridView ID="GrdBook" runat="server" AutoGenerateColumns="False" BackColor="White" 
                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IssueId,IssueDate,DueDate,BookId,BookName,GroupId,GroupName,StudentId,StdName"
                                                PageSize="5" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
                                                  
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
                                  <%--               <EmptyDataTemplate>No Record Available</EmptyDataTemplate>--%>
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
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
