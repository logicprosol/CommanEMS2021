<%@ Page Title="Add Scheme Form" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddScheme.aspx.cs" Inherits="CMS.Forms.Admin.AddScheme" %>

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
            confirm_value.value = "Yes";
            document.forms[0].removeChild(confirm_value);
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
    <asp:UpdatePanel ID="UpdatePanel_Scheme" runat="server" align="center" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel_Scheme" runat="server" Visible="true" Style="height: 895px;
                    width: 930px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Schemes</li>
                        </ul>
                    </th>
                </tr>
            </table>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSchemes" runat="server" Text="Schemes :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td width="200px">
                                <asp:DropDownList ID="ddlScheme" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlScheme_SelectedIndexChanged"
                                    ValidationGroup="validaiton" Height="28px" Width="183px">
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlScheme" runat="server" ControlToValidate="ddlScheme"
                                    InitialValue="Select" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGrantedAmount" runat="server" Text="Granted Amount :"></asp:Label>
                            </td>
                            <td width="200px">
                                <asp:TextBox ID="txtGrantedAmount" runat="server" ValidationGroup="validaiton" 
                                    Enabled="False" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                
                                <asp:GridView ID="GrdScheme" runat="server" CellPadding="4" DataKeyNames="SchemeDetailsId,SchemeId"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                    ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowEditing="GrdScheme_RowEditing"
                                    OnRowCommand="GrdScheme_RowCommand" OnRowDeleting="GrdScheme_RowDeleting" OnRowUpdating="GrdScheme_RowUpdating"
                                    OnRowCancelingEdit="GrdScheme_RowCancelingEdit" BackColor="White" 
                                    BorderWidth="1px" onrowdatabound="GrdScheme_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Details Id" SortExpression="SchemeDetailsId"
                                            Visible="false" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchemeDetailsId" runat="server" Text='<%#Eval("SchemeDetailsId") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Id" SortExpression="SchemeId" Visible="false"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchemeId" runat="server" Text='<%#Eval("SchemeId") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fund Name" SortExpression="FundName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFundName" runat="server" Text='<%#Eval("FundName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFundName" runat="server" Text='<%#Eval("FundName") %>' Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFundName" runat="server" ForeColor="Red" ControlToValidate="txtFundName"
                                                    Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Total Amount :" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="txtFooterFundName" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterFundName" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterFundName" Text="*" ValidationGroup="validaiton" Display="Dynamic" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Distributed Amount" SortExpression="DistributedAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistributedAmount" runat="server" Text='<%#Eval("DistributedAmount") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDistributedAmount" runat="server" Text='<%#Eval("DistributedAmount") %>'
                                                    Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDistributedAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtDistributedAmount" Text="*" ValidationGroup="validaiton1"
                                                    Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtDistributedAmount" runat="server" TargetControlID="txtDistributedAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblSummary" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="txtFooterDistributedAmount" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterDistributedAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterDistributedAmount" Text="*" ValidationGroup="validaiton"
                                                    Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtFooterDistributedAmount" runat="server" TargetControlID="txtFooterDistributedAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/images/update.jpg"
                                                    ToolTip="Update" Height="20px" Width="20px" ValidationGroup="validaiton1" />
                                                <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/images/Cancel.jpg"
                                                    ToolTip="Cancel" Height="20px" Width="20px" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/images/Edit.jpg"
                                                    ToolTip="Edit" Height="20px" Width="20px" />
                                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" OnClientClick = "ConfirmDelete()" />
                                            </ItemTemplate>                                            
                                            <FooterTemplate>
                                                <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/images/AddNewitem.jpg"
                                                    CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new particular"
                                                    ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <%--  <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="Add" />--%>
                </asp:Panel>
              
            </div>
              <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>