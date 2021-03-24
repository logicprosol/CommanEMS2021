<%@ Page Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AssignDeptDes.aspx.cs" Inherits="CMS.Forms.Admin.AssignDeptDes" %>

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
    <div style="height: 1100px; width: 930px; margin-left: auto; margin-right: auto;">
        <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style="height: 1100px;
            width: 930px; border: medium double#0C7BFA;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>ASSIGN DEPARTMENT & DESIGNATION</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="width: 90%; height: auto; margin-top: 10px; margin-left: 110px;" align="center">
                        <asp:Panel runat="server" ID="PanelDepartmentDesignation" align="left" Visible="true"
                            Style="height: auto; width: 90%;">
                            <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                                <table width="100%" align="center">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDepartment" runat="server" Text="Select Department : "></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ErrorMessage="Please Select Department"
                                                ForeColor="red" ControlToValidate="ddlDepartment" InitialValue="-1" TargetControlID="ddlDepartment"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDesignationType" runat="server" Text="Designation Type  : "></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:RadioButtonList ID="rbtlDesType" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                                Width="190px" AutoPostBack="true" OnSelectedIndexChanged="rbtlDesType_SelectedIndexChanged">
                                                <asp:ListItem Text="Teaching" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Non Teaching" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<asp:DropDownList ID="ddlParentClass" runat="server" AutoPostBack="true"
                                                    Style="margin-top: 5px;"
                                                    onselectedindexchanged="ddlParentClass_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>--%>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvrbtlDesType" runat="server" ForeColor="Red" ErrorMessage="Please Select Designation type"
                                                ControlToValidate="rbtlDesType"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Select Designation : "></asp:Label>
                                            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDesignation" runat="server" ForeColor="Red"
                                                ErrorMessage="Please Select Designation" ControlToValidate="ddlDesignation"></asp:RequiredFieldValidator>
                                            <%-- <asp:RequiredFieldValidator ID="rfvddlParentDivision" runat="server" ErrorMessage="Please Select Division"
                                                    ForeColor="red" ControlToValidate="ddlParentDivision" InitialValue="-1" TargetControlID="ddlParentDivision"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblAlreadyAssign" runat="server" Text="Already Assigned : " style="font-size:15px; color:Green; font-weight:bold;"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlContents" runat="server" HorizontalAlign="Center" Visible="true"
                                                class="well well-large" Height="350px" ScrollBars="Auto">
                                                <asp:GridView ID="GrdViewEmployee" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName" Width="600px"
                                                    OnRowDataBound="GrdViewEmployee_RowDataBound" AllowPaging="True"
                                                    BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdViewEmployee_PageIndexChanging" EmptyDataText="Employees not assigned to this department ">
                                                    <Columns>
                                                        <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Assigned Department">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnDelete" Text="Delete" runat="server" OnClick="lnkbtn_Click" OnClientClick = "ConfirmDelete()" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" HorizontalAlign="Center" />
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="center" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblAssignNew" runat="server" Text="Assign New : " style="font-size:15px; color:Red; font-weight:bold;"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Visible="true" class="well well-large" Height="350px" ScrollBars="Auto">
                                                <asp:GridView ID="GrdEmployee" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName" Width="600px"
                                                    OnRowDataBound="GrdEmployee_RowDataBound" OnSelectedIndexChanged="GrdEmployee_SelectedIndexChanged"
                                                    BackColor="White" BorderWidth="1px" AllowPaging="True" PageSize="10" OnPageIndexChanging="GrdEmployee_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Assigned Department">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Action" runat="server" Text="Action" />
                                                            </HeaderTemplate>
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
                                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="center" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                      <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
          
        </asp:Panel>
    </div>
</asp:Content>