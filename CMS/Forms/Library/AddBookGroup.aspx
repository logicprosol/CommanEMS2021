<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true"
    CodeBehind="AddBookGroup.aspx.cs" Inherits="CMS.Forms.Library.AddBookGroup" %>

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

        function ConfirmUpdate() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }    </script>

    <style type="text/css">
        .auto-style1 {
            width: 336px
        }
        .auto-style2 {
            margin-top: 11px;
        }
        .auto-style3 {
            width: 321px
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 900px;">
                <asp:Panel ID="Panel_BasicPaySettings" runat="server" Visible="true" Style="height: 900px;
                    width: 920px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="left" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Book Group</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td class="style1">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div style="border: 3px solid #0099FF; width: 800px;">
                                <table width="90%" align="center">
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style3">
                                            <asp:Label ID="lblGroupName" runat="server" Font-Bold="True" Text="Book Type :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvPayGroupName" runat="server" ControlToValidate="txtGroupName" ErrorMessage="Please Enter Group Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            &nbsp;
                                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnNew_Click" Text="New" />
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
                                            <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" OnClientClick="ConfirmUpdate()" Text="Update" />
                                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" OnClientClick="ConfirmDelete()" Text="Delete" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
</div>
                                <table width="90%" align="center" class="auto-style2">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="GrdGroupName" runat="server" AutoGenerateColumns="False" 
                                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                                                CellPadding="4" DataKeyNames="GroupId,GroupCode,GroupName" PageSize="5" 
                                                Width="80%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Group Code">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkGroupCode" runat="server" Text='<%#Eval("GroupCode") %>' CausesValidation="false" OnClick="lnkGroupCode_Click"/>
                                                        </ItemTemplate>  
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name" />
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
