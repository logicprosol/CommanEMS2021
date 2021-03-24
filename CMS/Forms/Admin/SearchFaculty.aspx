<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="SearchFaculty.aspx.cs" Inherits="CMS.Forms.Admin.SearchFaculty1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript">
    </script>
    <script type="text/javascript">
        function openWindow(code) {
            window.open('ViewFacultyProfile.aspx?UserCode=' + code, 'open_window', ' width=640, height=480, left=200, top=100');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <%--Start Here--%>
        <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Search-Staff</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SearchFaculty" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Width="800px" align="Left">
                        <table width="80%" align="center">
                            <tr>
                                <td colspan="5">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Department:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" Width="200px"
                                        OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Designation:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Width="200px"
                                        OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td >
                                 
                                </td>
                            </tr>
                            <tr>
                                <%--<td>
                                    <asp:Label ID="lbl1" runat="server" Text=" select Filter Criteria: "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLFilterCriteria" runat="server" Width="200px"
                                                AutoPostBack="true" Visible="true">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Emp Code" Value="EmpCode"></asp:ListItem>
                                                   <asp:ListItem Text="Employee" Value="Employee"></asp:ListItem>
                                                   <asp:ListItem Text="Department" Value="Department"></asp:ListItem>
                                                  <asp:ListItem Text="IsActive" Value="IsActive"></asp:ListItem>
                                            </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbl2" runat="server" Text="Filter Value:"></asp:Label>
                                </td>
                                <td>
                                      <asp:TextBox ID="TxtFilterCriterai" runat="server" Width="200px"></asp:TextBox>
                                </td>--%>
                                <td>

                                </td>
                                <td></td>
                                <td>
                                       <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click"
                                        Text="Go" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="5"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table style="width: 800px;" align="center">

                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Panel ID="Panel_FacultyProfile" runat="server" class="well well-large" Height="450px"
                                    Width="90%" ScrollBars="Auto">
                                    <asp:GridView ID="grd" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" AutoGenerateColumns="False" DataKeyNames="UserCode,IsActive" HorizontalAlign="Center" OnRowDataBound="grd_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR.NO">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UserCode" HeaderText="Emp Code" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="FullName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                                            <asp:TemplateField HeaderText="View Profile" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnView" runat="server" Text="View"
                                                        OnClick="lnkBtnView_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Active/Deactive" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" Text="Delete"
                                                        OnClick="lnkBtnDelete_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 800px;" align="center">
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:GridView ID="grdSearchFaculty" runat="server" AutoGenerateColumns="False" Width="95%"
                                    CellPadding="4" AllowPaging="True" OnSelectedIndexChanged="grdSearchFaculty_SelectedIndexChanged1" ForeColor="#333333" GridLines="None">

                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                                </asp:GridView>





                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%--End Here--%>
    </div>



</asp:Content>
