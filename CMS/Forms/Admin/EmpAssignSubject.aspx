<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EmpAssignSubject.aspx.cs" Inherits="CMS.Forms.Admin.EmpAssignSubject" %>


<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

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
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px;
            width: 911px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>ASSIGN SUBJECT</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SetCourseClass" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto;">
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse" Text="Select Course :" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" Text="Select Branch :" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ForeColor="Red" ErrorMessage="Please Select Course !!!"
                                        ControlToValidate="ddlCourse"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ForeColor="Red" ErrorMessage="Please Select Branch !!!"
                                        ControlToValidate="ddlBranch"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblSubject" Text="Select Subject : " runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ForeColor="Red" ErrorMessage="Please Select Class !!!"
                                        ControlToValidate="ddlClass"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlSubject" runat="server" ForeColor="Red" ErrorMessage="Please Select Subject !!!"
                                        ControlToValidate="ddlSubject"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="Panel_Save" runat="server" Visible="true" align="center" Style="height: auto;
                        width: 700px;" class="well well-large">
                        <div style="width: 800px; height: auto;">
                            <table border="0" width="90%" align="center" cellspacing="2px">
                                <tr>
                                    <td colspan="4" align="left">
                                        <asp:Label ID="lblAlreadyAssign" runat="server" Text="Already Assigned : " style="font-size:15px; color:Green; font-weight:bold;"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="left">
                                        <asp:GridView ID="GrdViewEmployee" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                            BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName" Width="600px"  AllowPaging="true" PageSize="10" 
                                            BackColor="White" BorderWidth="1px" OnRowDataBound="GrdViewEmployee_RowDataBound" >
                                            <Columns>
                                                <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AssignedSubject" HeaderText="AssignedSubject" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnDelete" Text="Delete" runat="server" OnClick="lnkbtn_Click" OnClientClick = "ConfirmDelete()" />
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
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 800px; height: auto;">
                            <table border="0" width="90%" align="center" cellspacing="2px">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="left">
                                        <asp:Label ID="lblAssignNew" runat="server" Text="Assign New : " style="font-size:15px; color:Red; font-weight:bold;"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" >

                                           <div style="max-height: 400px; overflow : scroll; width: 650px;">
                                        <asp:GridView ID="GrdEmployee" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                            BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName" Width="600px"
                                            BackColor="White"     BorderWidth="1px"  ><%--OnRowDataBound="GrdEmployee_RowDataBound"--%>
                                            <Columns>
                                                <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AssignedSubject" HeaderText="AssignedSubject" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Action" runat="server" Text="Action" />
                                                    </HeaderTemplate>
                                                    <%--<ItemTemplate>
                                                    <asp:CheckBox ID="checkbox" runat="server" />
                                                </ItemTemplate>
                                                    --%>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnAssign" Text="Assign" runat="server" OnClick="lnkbtnAssign_Click" />
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
                                               </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <%-- <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                                        --%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>