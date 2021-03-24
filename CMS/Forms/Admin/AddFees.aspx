<%@ Page Title="AddFees" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="AddFees.aspx.cs" Inherits="CMS.Forms.Admin.AddFees" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">
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
    <div style="height: 900px; width: 930px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 895px; width: 930px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Fees</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" Text="Course :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td width="200px">
                                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                    ValidationGroup="validaiton" Width="180">
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse"
                                    InitialValue="Select" ErrorMessage="Please select Course" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text="Branch :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                                    ValidationGroup="validaiton" Width="180">
                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlBranch"
                                    InitialValue="Select" ErrorMessage="Please select Branch" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblClass" runat="server" Text="Class :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                                    ValidationGroup="validaiton" Width="180">
                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlClass"
                                    InitialValue="Select" ErrorMessage="Please select Class" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" ValidationGroup="validaiton"
                                    OnSelectedIndexChanged="ddlAcademicYear_SelectedIndexChanged" Width="180">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             <td>
                                 <asp:ImageButton ID="imgbtnAdd1" runat="server" ImageUrl="~/images/AddNewitem.jpg"
                                    Width="30px" Height="30px" ToolTip="Add Installments" OnClick="imgbtnAdd1_Click" />
                                 <lable style="color:blue">
                                     Add Installments 
                                 </lable>
                           </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlAcademicYear" runat="server" ControlToValidate="ddlAcademicYear"
                                    InitialValue="0" ErrorMessage="Please select Academic Year" ForeColor="Red"
                                    ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                          
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCategory" runat="server" Text="Fees Category :"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCastCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCastCategory_SelectedIndexChanged"
                                    ValidationGroup="validaiton" Width="180">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="1">Regular</asp:ListItem>
                                    <asp:ListItem Value="2">Exempted</asp:ListItem>
                                    <asp:ListItem Value="3">RTE</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             <td><a href="ViewFees.aspx" style="color: blue; font-family: Cambria; font-size: large; text-decoration: underline;">View Fees</a></td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlCasteCategory" runat="server" ControlToValidate="ddlCastCategory"
                                    InitialValue="0" ErrorMessage="Please select Class" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                           
                        </tr>
                        
                        <%--   <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" OnClick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    OnClick="btnDelete_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false" OnClick="btnCancel_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>

                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                <!--Gridview Starts here-->
                                <!--Add this gridview in .aspx page-->
                                <!--Add this gridview in .aspx page-->
                                <asp:GridView ID="GrdFees" runat="server" CellPadding="4" DataKeyNames="Particular,Amount,FeesDetailsId"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                    ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowEditing="GrdFees_RowEditing"
                                    OnRowCommand="GrdFees_RowCommand" OnRowDeleting="GrdFees_RowDeleting" OnRowUpdating="GrdFees_RowUpdating"
                                    OnRowCancelingEdit="GrdFees_RowCancelingEdit" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Particular" SortExpression="Perticular">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPerticular" runat="server" Text='<%#Eval("Particular") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPerticular" runat="server" Text='<%#Eval("Particular") %>'>
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPerticular" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtPerticular" Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterPerticular" runat="server">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterPerticular" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterPerticular" Text="*" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("Amount") %>' Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAmount" runat="server" ForeColor="Red" ControlToValidate="txtAmount"
                                                    Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtAmount" runat="server" TargetControlID="txtAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterAmount" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterAmount" Text="*" ValidationGroup="validaiton" Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtFooterAmount" runat="server" TargetControlID="txtFooterAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:CommandField ShowDeleteButton="True" />--%>
                                        <%--  <asp:CommandField HeaderText="Edit-Update" ShowEditButton="True" />
                                        <asp:TemplateField HeaderText="SrNo">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Particular" runat="server" Text='<%#Eval("Particular") %>' OnClick="lnkBtnFeesName_Click"
                                                    CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Perticulars">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPerticulars" runat="server" Width="25px" />
                                            </ItemTemplate>
                                            <ItemStyle Width="25px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />--%>
                                        <asp:TemplateField HeaderText="Edit"><%--/Delete--%>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/images/update.jpg"
                                                    ToolTip="Update" Height="20px" Width="20px" ValidationGroup="validaiton1" />
                                                <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/images/Cancel.jpg"
                                                    ToolTip="Cancel" Height="20px" Width="20px" Visible="False" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/images/Edit.jpg"
                                                    ToolTip="Edit" Height="20px" Width="20px" />
                                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" OnClientClick="ConfirmDelete()" Visible="False" />
                                            </ItemTemplate>
                                            <%--<EditItemTemplate>
                                                <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update" Text="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel" Text="Delete">
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="Delete">
                                                </asp:LinkButton>
                                            </ItemTemplate>--%>
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
                                <!--Gridview end here-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
