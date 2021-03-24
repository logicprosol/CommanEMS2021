<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"  CodeBehind="AdminEditCollege.aspx.cs" Inherits="CMS.Forms.Admin.AdminEditCollege" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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

    <style type="text/css">
        .auto-style1 {
            width: 250px;
            height: 41px;
        }
        .auto-style2 {
            height: 41px;
        }
        .auto-style3 {
            width: 250px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height:1050px; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Update College/School </li>
                        </ul>
                    </th>
                </tr>
            </table>
            <table border="0" width="80%" align="center" cellspacing="2px">
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:Label ID="Label1" runat="server" Text=" Organization ID :" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text=" Org Code :" Width="100px"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=" Org Name :"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TxtOrgName" ErrorMessage="Please Enter Organization Name" ForeColor="red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TxtOrgID" runat="server" Height="18px" ReadOnly="true" size="50px" ToolTip="College ID" Width="166px"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="TxtOrgCode" runat="server" Height="16px" ReadOnly="true" size="50px" ToolTip="College Code" Width="165px"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="TxtOrgName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Trust Name :"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtTrustName" ErrorMessage="Please Enter Trust Name" ForeColor="red" TargetControlID="TxtTrustName" Type="Integer">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="lblOrganization" runat="server" Font-Bold="True" Text="Organization Type :"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rbl_OrganizationType" ErrorMessage="Please Select Organization Type" ForeColor="red" TargetControlID="rbl_OrganizationType">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblOrganization0" runat="server" Font-Bold="True" Text="University/Board Name: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="DDL_University" ErrorMessage="Please Select University Name" ForeColor="red" TargetControlID="DDL_University">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:TextBox ID="TxtTrustName" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:RadioButtonList ID="rbl_OrganizationType" runat="server" CssClass="radio" RepeatDirection="Horizontal" Width="180">
                            <asp:ListItem Text="College" Value="0"></asp:ListItem>
                            <asp:ListItem Text="School" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_University" runat="server" AutoPostBack="True" Height="28px" Width="174px">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="University Of Pune" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Bharati Vidyapeeth University" Value="2"></asp:ListItem>
                            <asp:ListItem Text="University of Mumbai"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Phone No :"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtPhoneNo" ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="TxtPhoneNo" Type="Integer" ValidationExpression="^\d+$">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Fax No : "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFax" ErrorMessage="Please Fax Number" ForeColor="red" TargetControlID="TxtFax" Type="Integer" ValidationExpression="^\d+$">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Email-ID :"></asp:Label>
                        <asp:RegularExpressionValidator ID="expEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:TextBox ID="TxtPhoneNo" runat="server" MaxLength="12"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style3">
                    <%--    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TxtOrgName"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>--%>
                        <asp:TextBox ID="TxtFax" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        &nbsp;<asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Website :"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txtwebsite" ErrorMessage="Enter valid Internet URL!" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Address : "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAddress" ErrorMessage="Please Enter Address" ForeColor="red" TargetControlID="TxtAddress">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Country : "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DDL_Country" ErrorMessage="Please Select Country" ForeColor="red" InitialValue="Select" TargetControlID="DDL_Country">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:TextBox ID="Txtwebsite" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtFax"
                            FilterType="Numbers" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                        <asp:TextBox ID="TxtAddress" runat="server" TextMode="MultiLine" Style="resize:none"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_Country" runat="server" AutoPostBack="True" Height="34px" OnSelectedIndexChanged="DDL_Country_SelectedIndexChanged" Width="183px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <!-- new--->
                <tr>
                    <td class="auto-style3" align="left">
                        &nbsp;<asp:Label ID="Label11" runat="server" Font-Bold="True" Text="State : "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DDL_State" ErrorMessage="Please Select State" ForeColor="red" InitialValue="Select" TargetControlID="DDL_State">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Pin Code : "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtPincode" ErrorMessage="*" ForeColor="red" TargetControlID="TxtPincode"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_pincode" runat="server" ControlToValidate="TxtPincode" ErrorMessage="Please Enter  6 Digit Pin code" ForeColor="red" TargetControlID="TxtPincode" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left">
                        &nbsp;<asp:Label ID="Label13" runat="server" Font-Bold="True" Text="City :"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DDL_City" ErrorMessage="Please Select City" ForeColor="red" InitialValue="Select" TargetControlID="DDL_City">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:DropDownList ID="DDL_State" runat="server" AutoPostBack="True" Height="27px" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged" Width="182px">
                        </asp:DropDownList>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:TextBox ID="TxtPincode" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_City" runat="server" Height="30px" OnSelectedIndexChanged="DDL_City_SelectedIndexChanged" Width="175px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="University Code : "></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="MSBTE Code :"></asp:Label>
                    </td>
                    <td align="left">
                        &nbsp;<asp:Label ID="Label16" runat="server" Font-Bold="True" Text="AICTE Code :"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:TextBox ID="TxtUniversityCode" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:TextBox ID="TxtMSBTEcode" runat="server"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtAICTECode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="DTE Code :"></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Organization Label: "></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtOrgLabel" ErrorMessage="Please Enter Collage Short Name" ForeColor="red" TargetControlID="TxtOrgLabel">*</asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        <asp:TextBox ID="TxtDTEcode" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:TextBox ID="TxtOrgLabel" runat="server"></asp:TextBox>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="auto-style3">
                        &nbsp;</td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Upload Logo :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileLogoImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        &nbsp;</td>
                    <td align="left" class="auto-style3">
                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Upload Letter Head : "></asp:Label>
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="FileLetterHeadImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" align="left">
                        &nbsp;</td>
                    <td align="left" class="auto-style3">
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="TxtPincode"
                            FilterType="Numbers" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="BtnUpdate" runat="server" class="btn btn-primary" OnClick="BtnUpdate_Click"  Text=" Update " CausesValidation="False" OnClientClick="ConfirmUpdate()"/><%----%>
                        <asp:Button ID="BtnClear" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="BtnClear_Click" Text=" Clear" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </asp:Panel>
    </div> <ucMsgBox:MsgBox ID="msgBox" runat="server" />
  
   
  
</asp:Content>