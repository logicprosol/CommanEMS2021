<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="ApplyPayScale.aspx.cs" Inherits="CMS.Forms.HR.ApplyPayScale" %>

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
   <div style="height: 900px; width: 929px; margin-left: auto; margin-right: auto;">
        <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style="height: 897px;
            width: 922px; border: medium double#0C7BFA;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Apply Pay Scale</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="width: 90%; height: auto; margin-top: 10px; margin-left: 110px;" align="center">
                        <asp:Panel runat="server" ID="PanelApplypayscale" align="left" Visible="true"
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
                                            <asp:Label ID="lblSelectPayGroup" runat="server" Text="Select Pay Group : "></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDL_PayGroup" runat="server" AutoPostBack="true" 
                                                Style="margin-top: 5px;" 
                                                onselectedindexchanged="DDL_PayGroup_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlPayGroup" runat="server" ErrorMessage="Please Select Pay Group"
                                                ForeColor="red" ControlToValidate="DDL_PayGroup" InitialValue="-1" TargetControlID="DDL_PayGroup"
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
                                            <asp:Label ID="lblAlreadyAssign" runat="server" Text="Already Assigned : " style="font-size:15px; color:Green; font-weight:bold;"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlContents" runat="server" HorizontalAlign="Center" Visible="true" Height="250px"                                                 class="well well-large">
                                                <br />
                                                <asp:GridView ID="GrdAssinedPayGroup" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName,PayGrpID,PayGrpName" Width="600px"  AllowPaging="True" PageSize="7"
                                                    BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdAssinedPayGroup_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Assigned Pay Group" DataField="PayGrpName">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PayGrpID" HeaderText="PayGrpID" Visible="false" />
                                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px" 
                                                                HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgBtnRemove" runat="server" CausesValidation="false" Height="14"  OnClick="ImgBtnRemove_Click"
                                                                        ImageUrl="~/images/removebtn.png" Width="20px" OnClientClick = "ConfirmDelete()" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="10px" />
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
                                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Visible="true" class="well well-large" Height="250px">
                                                <asp:GridView ID="GrdNotAssined" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC"
                                                    BorderStyle="None" CellPadding="4" DataKeyNames="UserCode,FullName,PayGrpID,PayGrpName" Width="600px" BackColor="White" PageSize="7" BorderWidth="1px" AllowPaging="True" OnPageIndexChanging="GrdNotAssined_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Assigned Pay Group" DataField="PayGrpName">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                          <asp:BoundField DataField="PayGrpID" HeaderText="PayGrpID" Visible="false" />
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="Action" runat="server" Text="Action" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnAssign" Text="Assign" runat="server"  OnClick="lnkbtnAssign_Click" />
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
