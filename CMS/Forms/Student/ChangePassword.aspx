<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="CMS.Forms.Student.ChangePassword" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
<link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
</asp:content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true" Style="height: 897px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li>CHANGE PASSWORD</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
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
                            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOldPassword" runat="server" 
                                ValidationGroup="ValidatePassword" TextMode="Password"></asp:TextBox>
                            <br />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword"
                                ErrorMessage="Please Enter Old Password" ForeColor="red" TargetControlID="txtDepartmentName"
                                ValidationGroup="ValidatePassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server" 
                                ValidationGroup="ValidatePassword" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDepartmentCode" runat="server" ControlToValidate="txtNewPassword"
                                ErrorMessage="Please Enter New Password" ForeColor="red" TargetControlID="txtDepartmentCode"
                                ValidationGroup="ValidatePassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" 
                                ValidationGroup="ValidatePassword" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword"
                                ControlToValidate="txtNewPassword" ErrorMessage="Confirm Pasword And New Password Mismatch."
                                ValidationGroup="ValidatePassword"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnChange" runat="server" Text="Change Password" class="btn btn-primary"
                                ValidationGroup="ValidatePassword" CausesValidation="true" OnClick="btnChange_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </asp:Panel>
    </div>
</asp:Content>