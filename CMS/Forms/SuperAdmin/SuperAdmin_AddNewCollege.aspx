<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master"
    AutoEventWireup="true" CodeBehind="SuperAdmin_AddNewCollege.aspx.cs" Inherits="CMS.Forms.SuperAdmin.SuperAdmin_AddNewCollege" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
            </Triggers>
            <ContentTemplate>
                <div style="height: 900px; width: 930px;">
                    <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height: 895px; width: 930px;
                        border: medium double#0C7BFA;">
                        <table border="0" width="100%" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>College/School Registration Form</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="Label1" runat="server" Text=" Organization ID :" size="50px" CssClass="formlable"> </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOrgID" runat="server" ToolTip="College Code" Enabled="false"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Width="120px" Text=" Organization Code :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOrgCode" runat="server" ReadOnly="true"></asp:TextBox>
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
                                <td align="left" class="style1">
                                    <asp:Label ID="LblOrgName" runat="server" Text="Organization Name:"></asp:Label><asp:Label
                                        ID="Label3" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOrgName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Organization Label :"></asp:Label>
                                    <asp:Label ID="Label4" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtOrgLabel" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="txtOrgNameValidator" runat="server" ErrorMessage="Please Enter Organization Name"
                                        ForeColor="red" ControlToValidate="TxtOrgName" TargetControlID="TxtOrgName"></asp:RequiredFieldValidator>
                                   <%-- <asp:FilteredTextBoxExtender ID="txtOrgNameValidator1" runat="server" TargetControlID="TxtOrgName"
                                        FilterType="Custom,Lowercas" ValidChars=" " >
                                    </asp:FilteredTextBoxExtender>--%>
                                </td>
                                <td>
                                </td>
                                <td>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Organization Short Name"
                                        ForeColor="red" ControlToValidate="TxtOrgLabel" TargetControlID="TxtOrgLabel"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtOrgLabel"
                                        FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style1">
                                    <asp:Label ID="lblOrganization" runat="server" Text="Organization Type :"></asp:Label><asp:Label
                                        ID="Label6" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:RadioButtonList ID="rbl_OrganizationType" runat="server" RepeatDirection="Horizontal"
                                        CssClass="radio" Width="180">
                                        <asp:ListItem Text="College" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="School" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="University/Board Name :"></asp:Label><asp:Label
                                        ID="Label8" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_University" runat="server" AutoPostBack="True" Height="27px" Width="172px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Select Organization Type"
                                        ForeColor="red" ControlToValidate="rbl_OrganizationType" TargetControlID="rbl_OrganizationType"></asp:RequiredFieldValidator>
                                  <%--  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TxtOrgName"
                                        FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>--%>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Please Select University Name"
                                        ForeColor="red" ControlToValidate="DDL_University" InitialValue="Select" TargetControlID="DDL_University"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="Label9" runat="server" Text=" Phone No :"></asp:Label><asp:Label ID="Label10"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
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
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtPhoneNo"
                                        FilterType="Numbers" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtPhoneNo"
                                        ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="TxtPhoneNo"
                                        Type="Integer" ValidationExpression="^\d+$"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TxtFax"
                                        FilterType="Numbers" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>
                                    
                                </td>
                            </tr>
                            <!-- new--->
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Email-ID :"></asp:Label><asp:Label ID="Label12"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
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
                                <td>
                                </td>
                                <td>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email-Id"
                                        ForeColor="red" ControlToValidate="TxtEmail" TargetControlID="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="expEmail" runat="server" ControlToValidate="TxtEmail"
                                        ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="  Address :"></asp:Label><asp:Label
                                        ID="Label14" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Country :"></asp:Label><asp:Label ID="Label16"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="DDL_Country" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Country_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" Height="28px" Width="184px">
                                 
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Address"
                                        ForeColor="red" ControlToValidate="TxtAddress" TargetControlID="TxtAddress"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select Country"
                                        ForeColor="red" ControlToValidate="ddlcountry" TargetControlID="ddlcountry"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="State :"></asp:Label><asp:Label ID="Label18"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                   <%-- <asp:DropDownList ID="DDL_State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_State_SelectedIndexChanged"
                                        OnTextChanged="DDL_State_TextChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" Height="31px" Width="185px">
           
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="District :"></asp:Label><asp:Label ID="Label20"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlcity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged" Height="25px" Width="175px">
                                  
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Select State"
                                        ForeColor="red" ControlToValidate="ddlstate" TargetControlID="ddlstate" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Select City"
                                        ForeColor="red" ControlToValidate="ddlcity" TargetControlID="ddlcity" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="Pin Code :"></asp:Label><asp:Label ID="Label22"
                                        ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPincode" runat="server" MaxLength="6"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text=" University Code :"></asp:Label>
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
                                    <asp:Label ID="Label24" runat="server" Text=" Trust Name :"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTrustName" runat="server"></asp:TextBox>
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
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="Upload Logo :"></asp:Label><asp:Label
                                        ID="Label27" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileLogoImage" runat="server" />
                                </td>
                                <td>
                                    Upload Letter Head :</asp:Label><asp:Label
                                        ID="Label28" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileLetterHeadImage" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select  Logo "
                                        ForeColor="red" ControlToValidate="FileLogoImage" TargetControlID="FileLogoImage"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Letter Head image"
                                        ForeColor="red" ControlToValidate="FileLetterHeadImage" TargetControlID="FileLetterHeadImage"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnSave" runat="server" Text=" Save " class="btn btn-primary" OnClick="BtnSave_Click" />
                                    &nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary" CausesValidation="false"
                                        OnClick="btnReset_Click" />
                                </td>
                                <td>
                                </td>
                        </table>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>