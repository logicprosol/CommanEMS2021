<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Role.aspx.cs" Inherits="CMS.Forms.Admin.Role" %>

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
        /*Hover Menu*/.popupMenu
        {
            position: absolute;
            visibility: hidden;
            background-color: #F5F7F8;
            opacity: .9;
            filter: alpha(opacity=90);
        }
        .popupHover
        {
            background-image: url(images/header-opened.png);
            background-repeat: repeat-x;
            background-position: bottom;
            background-color: #F5F7F8;
        }
    </style>
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
    <div style="height: 900px; width: 930px; margin-left: auto; margin-right: auto;">
        <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style="height: 897px;
            width: 930px; border: medium double#0C7BFA;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>ROLE</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="width: 90%; height: auto; margin-top: 10px; margin-left: 110px;" align="center">
                        <asp:Panel runat="server" ID="PanelApplypayscale" align="left" Visible="true" Style="height: auto;
                            width: 90%;">
                            <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                                <table width="100%" align="center">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblSelectRole" runat="server" Text="Select Role : "></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_Role" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="DDL_Role_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="HR" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Staff" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Inventor" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Librarian" Value="5"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvRole" runat="server" ErrorMessage="Please Select Role"
                                                ForeColor="red" ControlToValidate="DDL_Role" InitialValue="-1" TargetControlID="DDL_Role"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="left">
                                            <asp:Label ID="lblAlreadyAssign" runat="server" Text="Already Assigned : " Style="font-size: 15px;
                                                color: Green; font-weight: bold;"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlContents" runat="server" HorizontalAlign="Center" Visible="true"
                                                Height="250px" class="well well-large">
                                                <br />
                                                <asp:GridView ID="GrdAssinedRole" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="User Code" Width="600px" AllowPaging="True"
                                                    BackColor="White" BorderWidth="1px" PageSize="5" OnPageIndexChanging="GrdAssinedRole_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="User Code" HeaderText="User Code" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Full Name" HeaderText="Full Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="User Type" DataField="User Type">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px" HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnRemove" runat="server" OnClick="ImgBtnRemove_OnClick"
                                                                    CausesValidation="false" Height="14" ImageUrl="~/images/removebtn.png" Width="20px" OnClientClick = "ConfirmDelete()" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                                    <EmptyDataTemplate>
                                                        No Data Found.
                                                    </EmptyDataTemplate>
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
                                            <asp:Label ID="lblAssignNew" runat="server" Text="Assign New : " Style="font-size: 15px;
                                                color: Red; font-weight: bold;"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Visible="true" class="well well-large"
                                                Height="250px">
                                                <asp:GridView ID="GrdEmployee" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="User Code" Width="600px" BackColor="White"
                                                    BorderWidth="1px" AllowPaging="True" PageSize="5" OnPageIndexChanging="GrdEmployee_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="User Code" HeaderText="User Code" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Full Name" HeaderText="Full Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="User Type" DataField="User Type">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Action" runat="server" Text="Action" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnAssign" Text="Assign" runat="server" />
                                                                <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                                                                    <div style="border: 1px outset white; padding: 2px;">
                                                                        <div>
                                                                            <asp:LinkButton ID="lbtnAdmin" runat="server" OnClick="lbtnAdmin_OnClick" Text="Admin" /></div>
                                                                        <div>
                                                                            <asp:LinkButton ID="lbtnHR" runat="server" OnClick="lbtnAdmin_OnClick" Text="HR" /></div>
                                                                        <div>
                                                                            <asp:LinkButton ID="lbtnStaff" runat="server" OnClick="lbtnAdmin_OnClick" Text="Staff" /></div>
                                                                        <div>
                                                                            <asp:LinkButton ID="lbtnInventor" runat="server" OnClick="lbtnAdmin_OnClick" Text="Inventor" /></div>
                                                                        <div>
                                                                            <asp:LinkButton ID="lbtnLibrarian" runat="server" OnClick="lbtnAdmin_OnClick" Text="Librarian" /></div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:HoverMenuExtender ID="hme2" runat="Server" HoverCssClass="popupHover" PopupControlID="PopupMenu"
                                                                    PopupPosition="Right" TargetControlID="lnkbtnAssign" PopDelay="25" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" />
                                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                                    <EmptyDataTemplate>
                                                        No Data Found.
                                                    </EmptyDataTemplate>
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