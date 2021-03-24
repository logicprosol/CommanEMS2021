<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="CMS.Forms.Library.AddBook" enableEventValidation ="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 48px;
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 900px;">
                <asp:Panel ID="Panel1" runat="server" Visible="true" Style="height: 900px;
                    width: 920px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="left" cellspacing="2px">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Book</li>
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
                                <div style="border: 3px solid #0099FF; width: 800px">
                                <table width="80%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBookName" runat="server" Text="Book Name :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPayBookName" runat="server" ControlToValidate="txtBookName" ErrorMessage="Please Enter Book Name" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPublishYear" runat="server" Text="Publish Year :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublishYear" runat="server" MaxLength="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPublishYear" runat="server" ControlToValidate="txtPublishYear" ErrorMessage="Please Enter Publish Year" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtPublishYear" ErrorMessage="Please Enter Publish Year !!!" ForeColor="Red" ValidationGroup="GeneralDetails">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Label ID="lblGroupName" runat="server" Text="Group Name :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlGroupName" runat="server" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged" Height="29px" Width="182px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="ddlGroupName" ErrorMessage="Please Select Group" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lblEdition" runat="server" Text="Edition :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="txtEdition" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvEdition" runat="server" ControlToValidate="txtEdition" ErrorMessage="Please Enter Edition" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAuthor" runat="server" Text="Author :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor" ErrorMessage="Please Enter Author Name" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter Author Name"
                            ForeColor="red" ControlToValidate="txtAuthor" TargetControlID="txtAuthor"></asp:RequiredFieldValidator>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtAuthor"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                                        <td>
                                            <asp:Label ID="lblPrice" runat="server" Text="Price :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Please Enter Price" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPublisher" runat="server" Text="Publisher :" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPublisher" runat="server" ControlToValidate="txtPublisher" ErrorMessage="Please Enter Publisher" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                       <td>
                                            <asp:Label ID="Label1" runat="server" Text="Book No" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBarcode" runat="server"  OnTextChanged="txtBarcode_TextChanged"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtBarcode" ErrorMessage="Please Enter BarCode" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>

                                        </td>
                                    </tr>




                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Quantity :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtquntity" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtquntity" ErrorMessage="Please Enter Quantity" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            </td>
                                        <td>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            &nbsp;
                                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" onclick="btnNew_Click" Text="New" />
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" onclick="btnSave_Click" Text="Save" ValidationGroup="grpSave" Height="28px" />
                                            <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" onclick="btnUpdate_Click" OnClientClick="ConfirmUpdate()" Text="Update" ValidationGroup="grpSave" />
                                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" onclick="btnDelete_Click" OnClientClick="ConfirmDelete()" Text="Delete" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" onclick="btnCancel_Click" Text="Cancel" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                </table>
</div>
                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Height="400px">
                                <table width="90%"><tr><td>

 <asp:GridView ID="GrdBook" runat="server" AutoGenerateColumns="False" 
                                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                                                CellPadding="4" 
                                                DataKeyNames="BookId,BookCode,BookName,GroupId,GroupName,Publisher,Author,PublishingYear,Edition,Price,barcode,qty" 
                                                PageSize="5" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
                                                <Columns>
                                                    <%--<asp:TemplateField HeaderText="Book Code">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBookCode" runat="server" CausesValidation="false" 
                                                                Text='<%#Eval("BookCode") %>' OnClick="lnkBookCode_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBarodeGerator" runat="server" CausesValidation="false" 
                                                                Text="Generate Barcode" OnClick="lnkBarodeGerator_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="barcode" HeaderText="Book No" />
                                                    <asp:TemplateField HeaderText="BookName">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBookName" runat="server" CausesValidation="false" 
                                                                Text='<%#Eval("BookName") %>' OnClick="lnkBookName_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   <%-- <asp:BoundField DataField="BookName" HeaderText="Book Name" />--%>
                                                    <asp:BoundField DataField="GroupName" HeaderText="Group" />
                                                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                                                    <asp:BoundField DataField="Author" HeaderText="Author" />
                                                    <asp:BoundField DataField="PublishingYear" HeaderText="Publish Year" />
                                                    <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                                           <asp:BoundField DataField="qty" HeaderText="qty" />
                                                   <%-- --%>

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
                                           
                                    
                                           </td></tr></table>
                                    </asp:Panel>
                                <br />
                                <br/>
                                <asp:Button ID="btnPrint" runat="server" class="btn btn-primary"  Text="Print"  Height="28px" CausesValidation="False" OnClick="btnPrint_Click" Visible="False" />

                               
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
