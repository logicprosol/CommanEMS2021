<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master"
    AutoEventWireup="true" CodeBehind="University.aspx.cs" Inherits="CMS.Forms.SuperAdmin.University" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel2" runat="server" Style="height: 895px; width: 930px;
                    border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>UNIVERSITY MASTER</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" align="center" UpdateMode="Conditional">
                        <ContentTemplate>
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
                                        <asp:Label ID="lblUniversityName" runat="server" Text="University Name :"></asp:Label><asp:Label
                                            ID="Label1" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUniversityName" runat="server" ToolTip="University Name" ValidationGroup="ValidateUniversity"
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvUniversityName" runat="server" ErrorMessage="Please Enter University Name !!!"
                                            ControlToValidate="txtUniversityName" ForeColor="red" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text=" Address:"></asp:Label><asp:Label
                                            ID="Label4" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" Rows="4" runat="server" ToolTip="University Address"
                                            ValidationGroup="ValidateUniversity" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter University Address"
                                            ForeColor="red" ControlToValidate="txtAddress" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCountry" runat="server" Text="Country :"></asp:Label><asp:Label
                                            ID="Label5" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDL_Country" runat="server" AutoPostBack="True" ToolTip="Country"
                                            ValidationGroup="ValidateUniversity" OnSelectedIndexChanged="DDL_Country_SelectedIndexChanged"
                                            Enabled="False" Height="33px" Width="181px">
                                     
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvddlCountry" runat="server" ErrorMessage="Please Select country"
                                            InitialValue="Select" ForeColor="red" ControlToValidate="DDL_Country" ValidationGroup="ValidateUniversity">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblState" runat="server" Text=" State :"></asp:Label><asp:Label ID="Label8"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>


                                        <asp:DropDownList ID="DDL_State" runat="server" ToolTip=" State" AutoPostBack="true"
                                            ValidationGroup="ValidateUniversity" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged2"
                                            Enabled="False" Height="32px" Width="186px">
                                       
                                        </asp:DropDownList>
                                        
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvddlState" runat="server" ErrorMessage="Please Select state"
                                            InitialValue="Select" ForeColor="red" ControlToValidate="DDL_State" ValidationGroup="ValidateUniversity">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCity" runat="server" Text="District :"></asp:Label><asp:Label ID="Label9"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDL_City" runat="server" ToolTip="University City" ValidationGroup="ValidateUniversity"
                                            Enabled="False" OnSelectedIndexChanged="DDL_City_SelectedIndexChanged" Height="36px" Width="180px">
                                        
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvddlCity" runat="server" ErrorMessage="Please Select City"
                                            InitialValue="Select" ForeColor="red" ControlToValidate="DDL_City" ValidationGroup="ValidateUniversity">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPinCode" runat="server" Text="Pin Code :"></asp:Label><asp:Label
                                            ID="Label10" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPinCode" runat="server" ToolTip="University Pin Code" ValidationGroup="ValidateUniversity"
                                            Enabled="False" MaxLength="6"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="ftbePinCode" runat="server" TargetControlID="txtPinCode"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                            ForeColor="red" ErrorMessage="Please Enter PinCode !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text="Email :"></asp:Label><asp:Label ID="Label11"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" ToolTip="University Email" ValidationGroup="ValidateUniversity"
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="txtEmailid" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblContactNo" runat="server" Text="Contact No :"></asp:Label><asp:Label
                                            ID="Label12" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContactNo" runat="server" ToolTip="University Contact No" ValidationGroup="ValidateUniversity"
                                            Enabled="False" MaxLength="15"></asp:TextBox>
                                               <asp:FilteredTextBoxExtender ID="ftbeContactNo" runat="server" TargetControlID="txtContactNo"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo"
                                            ForeColor="red" ErrorMessage="Please Enter University Contact No !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFaxNo" runat="server" Text="Fax No :"></asp:Label><asp:Label ID="Label13"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFaxNo" runat="server" ToolTip="University Fax No" ValidationGroup="ValidateUniversity"
                                            Enabled="False" MaxLength="15"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFaxNo"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvFaxNo" runat="server" ControlToValidate="txtFaxNo"
                                            ForeColor="red" ErrorMessage="Please Enter University Fax No !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLogo" runat="server" Text="University Logo :" Visible="false"></asp:Label><asp:Label
                                            ID="Label14" ForeColor="Red" runat="server" Text="*" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="flpLogo" runat="server" ValidationGroup="ValidateUniversity"
                                            Enabled="False"  Visible="false"/>
                                    </td>
                                    <%--<td>
                                        <asp:RequiredFieldValidator ID="rfvLogo" runat="server" ControlToValidate="flpLogo"
                                            ForeColor="red" ErrorMessage="Please Upload University Logo !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateUniversity"
                                            CausesValidation="false" OnClick="btnNew_Click" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateUniversity"
                                            OnClick="btnSave_Click" Visible="False" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateUniversity" OnClientClick = "ConfirmUpdate()" OnClick="btnUpdate_Click" Visible="False" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateUniversity" OnClientClick = "ConfirmDelete()" CausesValidation="false" OnClick="btnDelete_Click" Visible="False" />
                                        <asp:Button ID="btnCancle" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                            ValidationGroup="ValidateUniversity" OnClick="btnCancle_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="width: 80%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel3" runat="server" class=" well well-large" Width="95%" Height="250px">
                                            <asp:GridView ID="GrdUniversity" runat="server" CellPadding="4" DataKeyNames="UniversityId,UniversityName,Address,Country,State,City,PinCode,Email,ContactNo1,FaxNo1"
                                                Width="83%" OnPageIndexChanging="GrdUniversity_PageIndexChanging" AutoGenerateColumns="False"
                                                AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                BorderWidth="1px" OnSelectedIndexChanged="GrdUniversity_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="University Name" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="UniversityName" runat="server" Text='<%#Eval("UniversityName") %>'
                                                                OnClick="lnkBtnUniversityName_Click" CausesValidation="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                  
                                                    <asp:BoundField HeaderText="PinCode" DataField="PinCode" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="ContactNo" DataField="ContactNo1" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                       <asp:BoundField HeaderText="Country" DataField="Country" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>


                                                       <asp:BoundField HeaderText="State" DataField="State" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                              <asp:BoundField HeaderText="District" DataField="City" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                   
                                                    <%--        <asp:BoundField HeaderText="FaxNo" DataField="FaxNo1" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>--%>
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
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>