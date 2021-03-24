<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="BatchAllotment.aspx.cs" Inherits="CMS.Forms.Admin.BatchAllotment" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckAllStudent(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdBatchAllotment.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[2].checked = oCheckbox.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
                <table border="0" width="100%" align="center">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Batch Allotment</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Width="920px">
                    <table border="0" width="90%" align="center">
                        <tr>
                            <td colspan="6" style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourses" runat="server" Text=" Select Course:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourses" runat="server" Width="150px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text=" Select Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranches" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblClasses" runat="server" Text=" Select Class:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                  <%--  <asp:ListItem Text="Default" Value="Default"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    InitialValue="Select" ControlToValidate="ddlCourses" ErrorMessage="Please Select Course"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlBranches" ErrorMessage="Please Select Branch"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlClasses" ErrorMessage="Please Select Class"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Panel ID="Panel2" runat="server" Width="90%" Height="500px" class=" well well-large">
                                    <asp:GridView ID="grdBatchAllotment" runat="server" AutoGenerateColumns="False" Width="99%"
                                        AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="4" EditRowStyle-Font-Names="Rows" DataKeyNames="UserCode,StudentName">
                                        <Columns>
                                            <asp:BoundField HeaderText="Student Id" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Student Name" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllStudent(this)"
                                                        Text="Select All" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkbox" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle Font-Names="Rows" />
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
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="lblDivision" runat="server" Text=" Set Division:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" Width="150px">
                                  <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                              
                            </td>
                             <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="rfvddlDivision" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlDivision" ErrorMessage="Please Select Division"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click1" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Class="btn btn-primary" OnClick="btnUpdate_Click"  />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>