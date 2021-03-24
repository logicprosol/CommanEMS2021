<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master"
    AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="CMS.Forms.Inventory.Supplier" %>

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
            overflow: auto;
            margin-top: 10px;
        }
        .auto-style2 {
            width: 800px;
            margin-top: 6px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.GrdItem.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.GrdItem.ClientID %>');
            var TargetChildControl = "chkBxSelect";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target base & child control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter;            
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
    </script>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_AddItem" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_AddSupplier" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Supplier</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <div style="border: 3px solid #0099FF; width: 800px;">
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
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSupplierName" runat="server" Placeholder="Supplier Name" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ControlToValidate="txtSupplierName" ErrorMessage="Please Enter Supplier Name" ForeColor="red" TargetControlID="txtSupplierName" ValidationGroup="ValidateSupplier">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblMobileNo" runat="server" Font-Bold="True" Text="Mobile No :"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="15" Placeholder="Mobile No" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please Enter Mobile No" ForeColor="red" ValidationGroup="ValidateSupplier">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhoneNo" runat="server" Placeholder="Phone No" MaxLength="20" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="Please Enter Phone No" ForeColor="red" ValidationGroup="ValidateSupplier">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:FilteredTextBoxExtender ID="ftbePhoneNo" runat="server" TargetControlID="txtPhoneNo"
                                    FilterType="Custom, Numbers" ValidChars="+ ">
                                </asp:FilteredTextBoxExtender>
                                <asp:Label ID="lblFaxNo" runat="server" Font-Bold="True" Text="Fax No :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFaxNo" runat="server"  MaxLength="30" Placeholder="Fax No" ValidationGroup="ValidateSupplier"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text="Email Id :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailId" Placeholder="Email" runat="server" MaxLength="30" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Please Enter Email Id" ForeColor="red" ValidationGroup="ValidateSupplier">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Please Enter Valid Email !!!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GeneralDetails">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblWebSite" runat="server" Font-Bold="True" Text="Website :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebsite" runat="server" Placeholder="Website" MaxLength="30" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revWebsite" runat="server" ControlToValidate="txtWebsite" Text="*" ValidationExpression="(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&amp;?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Address :" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress"  runat="server" Rows="1" Placeholder="Address" ValidationGroup="ValidateSupplier"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" ForeColor="red" ValidationGroup="ValidateSupplier">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            <div style="max-height: 200px; overflow: auto;" align="center">
                                <asp:GridView ID="GrdItem" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ItemId,ItemName,UnitId,CategoryId"
                                    Width="80%" OnRowCreated="gvCheckboxes_RowCreated" AutoGenerateColumns="False" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px" OnRowDataBound="GrdItem_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkBxSelect" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Name" DataField="ItemName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Unit" DataField="UnitName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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
                              </div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="border: 2px solid #0099FF">
                                <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnNew_Click" Text="New" />
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="ValidateSupplier" />
                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" OnClientClick="ConfirmUpdate()" Text="Update" ValidationGroup="ValidateSupplier" />
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" OnClientClick="ConfirmDelete()" Text="Delete" ValidationGroup="ValidateSupplier" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                    </div>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                 <div style="max-height: 400px; " align="center" class="auto-style1">
                                <asp:GridView ID="GrdSupplier" runat="server" CellPadding="4" ForeColor="#333333"
                                    DataKeyNames="SupplierId,SupplierName,CategoryId,
                                MobileNo,PhoneNo,FaxNo,EmailId,Website,Address" Width="80%" 
                                    AutoGenerateColumns="False" AllowPaging="True"  BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Supplier Name " ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnSupplierName" runat="server" Text='<%#Eval("SupplierName") %>'
                                                    OnClick="lnkBtnSupplierName_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                       <%-- <asp:BoundField HeaderText="Category" DataField="CategoryName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Phone No" DataField="PhoneNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Email" DataField="EmailId" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Website" DataField="Website" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Fax No" DataField="FaxNo" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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
                                     </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
