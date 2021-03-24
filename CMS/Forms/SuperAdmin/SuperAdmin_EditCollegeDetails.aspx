<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master"
    AutoEventWireup="true" CodeBehind="SuperAdmin_EditCollegeDetails.aspx.cs" Inherits="CMS.Forms.SuperAdmin.SuperAdmin_EditCollegeDetails" %>

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
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height: 895px; width: 920px;
            border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Update College/School </li>
                        </ul>
                    </th>
                </tr>
            </table>
            <table border="0" width="95%" align="center" cellspacing="2px">
                <tr>
                    <td colspan="2" align="right">
                        <br />
                        Select Organization Name :&nbsp;
                        <br />
                    </td>
                    <td colspan="2">
                        <br />
                        <asp:DropDownList ID="DDL_SelectCollege" runat="server" OnSelectedIndexChanged="DDL_SelectCollege_SelectedIndexChanged"
                            AutoPostBack="True" Height="32px" Width="154px">
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <br />
                        <br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label1" runat="server" Text=" Organization ID :"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOrgID" runat="server" ToolTip="College ID" ReadOnly="true" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=" Org Code :" Width="100px"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOrgCode" runat="server" ToolTip="College Code" ReadOnly="true"
                           ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <br />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" Text=" Org Name :" Width="100px"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOrgName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Width="120px" Text="Trust Name :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtTrustName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    
                
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lblOrganization" runat="server" Text="Organization Type :"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:RadioButtonList ID="rbl_OrganizationType" runat="server" RepeatDirection="Horizontal"
                            CssClass="radio" Width="180">
                            <asp:ListItem Text="College" Value="0"></asp:ListItem>
                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        University/Board Name:
                    </td>
                    <td>
                        <asp:DropDownList ID="DDL_University" runat="server" AutoPostBack="True" Height="26px" Width="174px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Please Select Organization Type"
                            ForeColor="red" ControlToValidate="rbl_OrganizationType" TargetControlID="rbl_OrganizationType"></asp:RequiredFieldValidator>
                     <%--   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TxtOrgName"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Please Select University Name"
                            ForeColor="red" ControlToValidate="DDL_University" TargetControlID="DDL_University"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Phone No :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPhoneNo" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                        Fax No :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtFax" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtFax"
                            FilterType="Numbers" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtPhoneNo"
                            ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="TxtPhoneNo" 
                            Type="Integer" ValidationExpression="^\d+$"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TxtPhoneNo"
                            FilterType="Numbers" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                       
                    </td>
                </tr>
                <!-- new--->
                <tr>
                    <td class="style1">
                        Email-ID :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Website :
                    </td>
                    <td>
                        <asp:TextBox ID="Txtwebsite" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                     <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email"
                            ForeColor="red" ControlToValidate="TxtEmail" TargetControlID="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="expEmail" runat="server" ControlToValidate="TxtEmail"
                            ErrorMessage="Please Enter Valid E-mail address" Display="Dynamic" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$"></asp:RegularExpressionValidator>

                    </td>
                    <td>
                    </td>
                    <td>
                       
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Address :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtAddress" runat="server" TextMode="MultiLine" Height="27px" Width="161px"></asp:TextBox>
                    </td>
                    
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Address"
                            ForeColor="red" ControlToValidate="TxtAddress" TargetControlID="TxtAddress"></asp:RequiredFieldValidator>
                    </td>                   
                   
                </tr>
                <tr>
                     <td>
                        Country :
                    </td>
                    <td>
                       
                        <asp:DropDownList ID="ddlcountry" runat="server"  OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Height="29px" Width="190px">
                                                     </asp:DropDownList>
                    </td>

                 
                   <%-- <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select Country"
                            ForeColor="red" ControlToValidate="ddlcountry" TargetControlID="ddlcountry"
                            InitialValue="Select"></asp:RequiredFieldValidator>
                    </td>--%>

                      <td class="style1">
                        State :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Height="31px" Width="171px">
                            
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                  
                    <td>
                        District :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcity" runat="server" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" Height="24px" Width="185px">
                       
                        </asp:DropDownList>
                    </td>
                </tr>
               
                <tr>
                    <td class="style1">
                        Pin Code :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPincode" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                    <td>
                        University Code :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtUniversityCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Pin code"
                            ForeColor="red" ControlToValidate="TxtPincode" TargetControlID="TxtPincode" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="TxtPincode"
                            FilterType="Numbers" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_pincode" runat="server"
                            ForeColor="red" ErrorMessage="Please Enter  6 Digit Pin code" ValidationExpression="^[0-9]{6}$"
                            ControlToValidate="TxtPincode" TargetControlID="TxtPincode" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        MSBTE Code :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtMSBTEcode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        AICTE Code :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtAICTECode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        DTE Code :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDTEcode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Organization Label:
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOrgLabel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Organization Label"
                            ForeColor="red" ControlToValidate="TxtOrgLabel" TargetControlID="TxtOrgLabel"></asp:RequiredFieldValidator>
                        <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtOrgLabel"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>--%>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Upload Logo :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileLogoImage" runat="server" />
                    </td>
                    <td>
                        Upload Letter Head :
                    </td>
                    <td>
                        <asp:FileUpload ID="FileLetterHeadImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                    </td>
                   <%-- <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Letter Head image"
                            ForeColor="red" ControlToValidate="FileLetterHeadImage" TargetControlID="FileLetterHeadImage"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr>
                <tr>
                    <td class="style1">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td align="right">
                        <asp:Button ID="BtnUpdate" runat="server" class="btn btn-primary" Text=" Update "
                            OnClick="BtnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                        &nbsp;&nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="BtnCancel" runat="server" class="btn btn-primary" 
                            CausesValidation="false" Text=" Cancel " onclick="BtnCancel_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </asp:Panel>
        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>