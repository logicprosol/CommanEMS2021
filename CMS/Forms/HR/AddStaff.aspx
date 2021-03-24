<%@ Page Title="AddStaff" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"
    CodeBehind="AddStaff.aspx.cs" Inherits="CMS.Forms.HR.AddStaff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function CheckDate(sender, args) {
            var dt = new Date();
            if (sender._selectedDate > dt) {
                sender
            ._textbox
            .set_Value(dt.format(sender._format));
                //alert the user what we just did and why
                alert("Warning! - Please Enetr Valid Date");
            }
        }
    </script>
    <div style="height: 895px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" ChildrenAsTriggers="true">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnContinue"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnAddressPanel"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnPre1"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnPre2"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
            </Triggers>
            <ContentTemplate>
                <asp:Panel ID="Panel_PersonalInfo" runat="server" Visible="true" Style="height: 890px;
                    width: 900px; border: double #0C7BFA">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <td class="fomrsubheader" align="center">
                                <ul class="nav nav-list">
                                    <li class="active"><a href="#"><i class="icon-home icon-white"></i>Personal Information</a></li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table border="0" width="90%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStaff" runat="server" Text="Emp Code : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEmpCode" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesignationType" runat="server" Text="Designation Type : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnDesignationType" runat="server" RepeatDirection="Horizontal"
                                    CssClass="radio" Width="200px" OnSelectedIndexChanged="rbtnDesignationType_SelectedIndexChanged"
                                    AutoPostBack="true" ValidationGroup="PersonalInfo">
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvDesignationType" runat="server" ForeColor="red"
                                    ErrorMessage="Please Select Designation Type !!!" ControlToValidate="rbtnDesignationType"
                                    ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td>
                                <asp:Label ID="lblDesignationName" runat="server" Text="Designation: " CssClass="formlable"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDesignationName" runat="server" Width="220px" ValidationGroup="PersonalInfo">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvDesignationName" runat="server" ForeColor="red"
                                    ErrorMessage="Please Select Designation !!!" ControlToValidate="ddlDesignationName"
                                    ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <%-- <tr>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" Text="Course : " CssClass="formlable"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="220px" ValidationGroup="PersonalInfo">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvdllCourse" runat="server" ForeColor="red" ErrorMessage="Please Select Course !!!"
                                    ControlToValidate="ddlCourse" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ForeColor="red" ErrorMessage="Please Enter First Name !!!"
                                    ControlToValidate="txtFirstName" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMiddleName" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ForeColor="red" ErrorMessage="Please Enter Middle Name !!!"
                                    ControlToValidate="txtMiddleName" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ForeColor="red" ErrorMessage="Please Enter Last Name !!!"
                                    ControlToValidate="txtLastName" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMotherName" runat="server" Text="Mother Name : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMotherName" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ForeColor="red" ErrorMessage="Please Enter Mother Name !!!"
                                    ControlToValidate="txtMotherName" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGender" runat="server" Text="Gender : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal"
                                    CssClass="radio" Width="200px" ValidationGroup="PersonalInfo">
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ForeColor="red" ErrorMessage="Please Choose Gender !!!"
                                    ControlToValidate="rbtnGender" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BirthDate" runat="server" ValidationGroup="PersonalInfo"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BirthDate_CalendarExtender" runat="server" TargetControlID="txt_BirthDate"
                                    OnClientDateSelectionChanged="CheckDate" Format="MM/dd/yyyy" DaysModeTitleFormat="MM/dd/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ForeColor="red" ErrorMessage="Select Birth Date !!!"
                                    ControlToValidate="txt_BirthDate" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="ftbeEndDate" runat="server" TargetControlID="txt_BirthDate"
                                    FilterType="Custom, Numbers" ValidChars="/,-">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBloodGroup" runat="server" Text="Blood Group : " CssClass="formlable"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBloodGroup" runat="server" ValidationGroup="PersonalInfo">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>O+ve</asp:ListItem>
                                    <asp:ListItem>O-ve</asp:ListItem>
                                    <asp:ListItem>A+ve</asp:ListItem>
                                    <asp:ListItem>A-ve</asp:ListItem>
                                    <asp:ListItem>B+ve</asp:ListItem>
                                    <asp:ListItem>B-ve</asp:ListItem>
                                    <asp:ListItem>AB+ve</asp:ListItem>
                                    <asp:ListItem>AB-ve</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <%--<asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ForeColor="red" ErrorMessage="Select Blood Group !!!"
                                    ControlToValidate="ddlBloodGroup" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status : " CssClass="formlable"></asp:Label>
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnMaritalStatus" runat="server" RepeatDirection="Horizontal"
                                    CssClass="radio" Width="200px" ValidationGroup="PersonalInfo">
                                    <asp:ListItem Text="Unmarried" Value="UnMarried"></asp:ListItem>
                                    <asp:ListItem Text="Married" Selected="False" Value="Married"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                     
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvMaritalStatus" runat="server" ForeColor="red"
                                    ErrorMessage="Please Choose Marital Status !!!" ControlToValidate="rbtnMaritalStatus"
                                    ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>

                           <tr>
                        <td>
                                <asp:Label ID="lblHandicaped" runat="server" Text="Handicap"></asp:Label>
                                <asp:Label ID="Label67" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Handicap" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Blind</asp:ListItem>
                                    <asp:ListItem>Deaf</asp:ListItem>
                                    <asp:ListItem>Dump</asp:ListItem>
                                    <asp:ListItem>L.D.</asp:ListItem>
                                    <asp:ListItem>Spastic</asp:ListItem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="rfvdllHandicap" runat="server" ForeColor="red" ErrorMessage="Please Select Value !!!"
                                    ControlToValidate="ddl_Handicap" InitialValue="Select" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td>
                                <asp:Label ID="lblHandicapPercentage" runat="server" Text="Handicap Percentage"></asp:Label>
                                <%--<asp:Label ID="Label40" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtHandicapPercentage" Text="0" runat="server" ValidationGroup="PersonalInfo" MaxLength="3"></asp:TextBox>
                                <%--   <asp:RequiredFieldValidator ID="rfvHandicapPercentage" runat="server" ForeColor="red" ErrorMessage="Please Enter Handicap Percentage !!!"
                                    ControlToValidate="txtHandicapPercentage" ValidationGroup="PersonalInfo"></asp:RequiredFieldValidator>--%>
                                  <asp:RegularExpressionValidator ID="rveHandicapPer" runat="server" ErrorMessage="Enter valid Percentage"
                                      ValidationGroup="PersonalInfo" ControlToValidate="txtHandicapPercentage" ForeColor="Red"
                                      ValidationExpression="^(100([\.][0]{1,})?$|[0-9]{1,2}([\.][0-9]{1,})?)$">
                                  </asp:RegularExpressionValidator>
                                <asp:FilteredTextBoxExtender ID="fteHandicapPercentage" runat="server" TargetControlID="txtHandicapPercentage"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnContinue" runat="server" class="btn btn-primary" Text="Next" OnClick="btnContinue_Click"
                                    ValidationGroup="PersonalInfo" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel_ContactGeneralInfo" runat="server" Visible="false">
                    <div id="Div_ContactGeneralInfo" Style="height: 890px; width: 900px; border: double #0C7BFA"
                        visible="false">
                        <table width="100%" border="0" align="center">
                            <tr>
                                <td class="fomrsubheader" align="center">
                                    <ul class="nav nav-list">
                                        <li class="active"><a href="#"><i class="icon-home icon-white"></i>Present Address</a></li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPresentAddress" runat="server" Text="Present Address : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPresentAddress" TextMode="MultiLine" runat="server" Rows="1"
                                        ValidationGroup="GeneralDetails" Width="180px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvPresentAddress" runat="server" ErrorMessage="Please Enter Present Address !!!"
                                        ControlToValidate="txtPresentAddress" ForeColor="Red" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPresentCountry" runat="server" Text="Country : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPresentCountry" runat="server" Width="200px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPresentCountry_SelectedIndexChanged" ValidationGroup="GeneralDetails">
                                            <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPresentCountry" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select Country !!!" ControlToValidate="ddlPresentCountry"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPresentState" runat="server" Text="State : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPresentState" runat="server" Width="200px" OnSelectedIndexChanged="ddlPresentState_SelectedIndexChanged"
                                        AutoPostBack="true" ValidationGroup="GeneralDetails">
                                            <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPresentState" runat="server" ForeColor="red" ErrorMessage="Please Select State !!!"
                                        ControlToValidate="ddlPresentState" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPresentCity" runat="server" Text="City : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPresentCity" runat="server" Width="200px" ValidationGroup="GeneralDetails">
                                            <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPresentCity" runat="server" ForeColor="red" ErrorMessage="Please Select City !!!"
                                        ControlToValidate="ddlPresentCity" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPresentPinCode" runat="server" Text="Pin Code : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPresentPinCode" runat="server" MaxLength="6" Width="180px" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPresentPinCode" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Pin Code !!!" ControlToValidate="txtPresentPinCode"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="rtbPresentPinCode" runat="server" TargetControlID="txtPresentPinCode"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center">
                            <%-- <tr>
                                <td class="fomrsubheader" align="center">
                                    <ul class="nav nav-list">
                                        <li class="active"><a href="#"><i class="icon-home icon-white"></i>Permanent Address</a></li>
                                   </ul>
                                </td>
                                </tr>--%>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkSameasAbove" runat="server" class="radio" AutoPostBack="true"
                                        Text="Same As Above" OnCheckedChanged="chkSameAsAbove_CheckedChanged" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td style="width: 10%">
                                    <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label15" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPermanentAddress" TextMode="MultiLine" runat="server" Rows="1"
                                        ValidationGroup="GeneralDetails" Width="180px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvPermanentAddress" runat="server" ErrorMessage="Please Enter Permanent Address !!!"
                                        ControlToValidate="txtPermanentAddress" ForeColor="Red" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPermanentCountry" runat="server" Text="Country : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentCountry" runat="server" Width="200px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPermanentCountry_SelectedIndexChanged" ValidationGroup="GeneralDetails">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPermanentCountry" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select Country !!!" ControlToValidate="ddlPermanentCountry"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPermanentState" runat="server" Text="State : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label17" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentState" runat="server" Width="200px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPermanentState_SelectedIndexChanged" ValidationGroup="GeneralDetails">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPermanentState" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select State !!!" ControlToValidate="ddlPermanentState"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPermanentCity" runat="server" Text="City : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label18" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentCity" runat="server" Width="200px" ValidationGroup="GeneralDetails">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPermanentCity" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select City !!!" ControlToValidate="ddlPermanentCity" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPermanentPinCode" runat="server" Text="Pin Code: " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label19" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPermanentPinCode" runat="server" MaxLength="6" Width="180px"
                                        ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPermanentPinCode" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Pin Code !!!" ControlToValidate="txtPermanentPinCode"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="ftbPermanentPinCode" runat="server" TargetControlID="txtPermanentPinCode"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center">
                            <tr>
                                <td class="fomrsubheader" align="center">
                                    <ul class="nav nav-list">
                                        <li class="active"><a href="#"><i class="icon-home icon-white"></i>General Details</a></li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhoneNumber" runat="server" Width="200px" MaxLength="15" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ForeColor="Red" ErrorMessage="Please Enter Phone Number !!!"
                                        ControlToValidate="txtPhoneNumber" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="ftbePhoneNo" runat="server" TargetControlID="txtPhoneNumber"
                                        FilterType="Custom,Numbers" ValidChars="+, ">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label21" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="10" Width="200px" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile Number !!!"
                                        ControlToValidate="txtMobileNumber" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="ftbeMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFaxNumber" runat="server" Text="Fax : " CssClass="formlable"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtFaxNumber" runat="server" Width="200px" MaxLength="15" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- <asp:RequiredFieldValidator ID="rfvFaxNumber" runat="server" ForeColor="Red" ErrorMessage="Please Enter Fax Number !!!"
                                        ControlToValidate="txtFaxNumber" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>--%>
                                    <asp:FilteredTextBoxExtender ID="ftbeFaxNo" runat="server" TargetControlID="txtFaxNumber"
                                        FilterType="Custom,Numbers" ValidChars="+, ">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text="Email : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label22" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ForeColor="Red" ErrorMessage="Please Enter Email !!!"
                                        ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ForeColor="Red" ErrorMessage="Please Enter Valid Email !!!"
                                        ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="GeneralDetails"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCasteCategory" runat="server" Text="CasteCategory : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label23" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlCasteCategory" runat="server" ValidationGroup="GeneralDetails">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvCasteCategory" runat="server" ForeColor="Red"
                                        ErrorMessage="Please Enter CasteCategory !!!" ControlToValidate="ddlCasteCategory"
                                        ValidationGroup="GeneralDetails" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNationality" runat="server" Text="Nationality : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label24" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtNationality" runat="server" Width="200px" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ForeColor="Red" ErrorMessage="Please Nationality !!!"
                                        ControlToValidate="txtNationality" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="ftbeNationality" runat="server" TargetControlID="txtNationality"
                                        FilterType="UppercaseLetters, LowercaseLetters">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPanCardNo" runat="server" Text="Pan Card No : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label25" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtPanCardNo" runat="server" Width="200px" MaxLength="10" ValidationGroup="GeneralDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPanCardNo" runat="server" ForeColor="Red" ErrorMessage="Please Enter Pan Card No !!!"
                                        ControlToValidate="txtPanCardNo" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblJoiningDate" runat="server" Text="Date of Joining : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label26" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtJoiningDate" runat="server" ValidationGroup="GeneralDetails"></asp:TextBox>
                                    <asp:CalendarExtender ID="JoiningDate_CalendarExtender" runat="server" TargetControlID="txtJoiningDate"
                                        Format="MM/dd/yyyy" OnClientDateSelectionChanged="CheckDate" DaysModeTitleFormat="MM/dd/yyyy" TodaysDateFormat="MM/dd/yyyy">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvJoiningDate" runat="server" ForeColor="red" ErrorMessage="Please Choose Joinging Date !!!"
                                        ControlToValidate="txtJoiningDate" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender ID="ftbeJoiningDate" runat="server" TargetControlID="txtJoiningDate"
                                        FilterType="Custom, Numbers" ValidChars="/,-">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnPre1" runat="server" Text="Previous" class="btn btn-primary" OnClick="btnPre1_Click1"
                                        CausesValidation="false" />
                                    <asp:Button ID="btnAddressPanel" runat="server" Text="Next" class="btn btn-primary"
                                        OnClick="btnAddressPanel_Click1" ValidationGroup="GeneralDetails" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel_QualificationBankingDetails" runat="server" Visible="false">
                    <div id="Div_Panel_QualificationBankingDetails" Style="height: 890px; width: 900px; 
                        border: double #0C7BFA" visible="false">
                        <table width="100%" border="0" align="center">
                            <tr>
                                <td class="fomrsubheader" align="center">
                                    <ul class="nav nav-list">
                                        <li class="active"><a href="#"><i class="icon-home icon-white"></i>Qualification Details</a></li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblUGDegree" runat="server" Text="UGDegree : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label27" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUGDegree" runat="server" Width="180px" ValidationGroup="QualificationBankingDetails">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="BA">BA</asp:ListItem>
                                        <asp:ListItem Value="BCOM">BCOM</asp:ListItem>
                                        <asp:ListItem Value="BSc">BSC</asp:ListItem>
                                        <asp:ListItem Value="BBA">BBA</asp:ListItem>
                                        <asp:ListItem Value="BCA">BCA</asp:ListItem>
                                        <asp:ListItem Value="BLM">BCM</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvUGDegree" runat="server" ForeColor="red" ErrorMessage="Please Select UGDegree !!!"
                                        ControlToValidate="ddlUGDegree" InitialValue="Select" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPGDegree" runat="server" Text="PGDegree : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label30" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="ddlPGDegree" runat="server" Width="220px" ValidationGroup="QualificationBankingDetails">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="MA">MA</asp:ListItem>
                                        <asp:ListItem Value="MCOM">MCOM</asp:ListItem>
                                        <asp:ListItem Value="MSc">MSC</asp:ListItem>
                                        <asp:ListItem Value="MBA">MBA</asp:ListItem>
                                        <asp:ListItem Value="MCA">MCA</asp:ListItem>
                                        <asp:ListItem Value="MCA">MCM</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPGDegree" runat="server" ForeColor="red" ErrorMessage="Please Select UGDegree !!!"
                                        ControlToValidate="ddlPGDegree" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDoctorateDegree" runat="server" Text="Doctorate Degree : " CssClass="formlable"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtDocterateDegree" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfvDoctorateDegree" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select UGDegree !!!" ControlToValidate="ddlPGDegree" ValidationGroup="QualificationBankingDetails">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                                <td>
                                    <asp:Label ID="lblOtherQualification" runat="server" Text="Other Qualification : "
                                        CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label28" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtOtherQualification" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvOtherQualification" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Other Qualification !!!" ControlToValidate="txtOtherQualification"
                                        ValidationGroup="QualificationBankingDetails">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSpecialization" runat="server" Text="Specialization : " CssClass="formlable"></asp:Label>
                                 <%--   <asp:Label ID="Label31" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtSpecialization" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSpecialization" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Specialization !!!" ControlToValidate="txtSpecialization"
                                        ValidationGroup="QualificationBankingDetails">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblTeachingExperience" runat="server" Text="Teaching Experience : "
                                        CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label32" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtTeachingExperience" runat="server" ValidationGroup="QualificationBankingDetails"
                                        MaxLength="5"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvTeachingExperience" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Teaching Experience !!!" ControlToValidate="txtTeachingExperience"
                                        ValidationGroup="QualificationBankingDetails">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblWesiteBlog" runat="server" Text="Website/Blog : " CssClass="formlable"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWebsiteBlog" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfvWesiteBlog" runat="server" ForeColor="Red" ErrorMessage="Please WesiteBlog !!!"
                                        ControlToValidate="txtWebsiteBlog" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <!-- <tr>
                        <td>
                            <asp:Label ID="lblIndustrialExperience" runat="server" Text="Industrial Experience : "
                                CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIndustrialExperience" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvIndustrialExperience" runat="server" ForeColor="red"
                                ErrorMessage="Please Enter Industrial Experience !!!" ControlToValidate="txtTeachingExperience"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblResearchExperience" runat="server" Text="Research Experience: "
                                CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtResearchExperience" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvResearchExperience" runat="server" ForeColor="red"
                                ErrorMessage="Please Enter Research Experience !!!" ControlToValidate="txtResearchExperience"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNationalPublication" runat="server" Text="National Publication: "
                                CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txNationalPublication" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvNationalPublication" runat="server" ForeColor="red"
                                ErrorMessage="Please Enter  National Publication!!!" ControlToValidate="txNationalPublication"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblInterNationalPublication" runat="server" Text="InterNational Publication: "
                                CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInterNationalPublication" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvInterNationalPublication" runat="server" ForeColor="red"
                                ErrorMessage="Please Enter  InterNational Publication !!!" ControlToValidate="txNationalPublication"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblBookPublished" runat="server" Text="Book Published : " CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBookPublished" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvBookPublished" runat="server" ForeColor="red"
                                ErrorMessage="Please Enter Book Published !!!" ControlToValidate="txtBookPublished"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPatents" runat="server" Text="Patents : " CssClass="formlable"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPatents" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPatents" runat="server" ForeColor="red" ErrorMessage="Please Enter Patents !!!"
                                ControlToValidate="txtPatents"></asp:RequiredFieldValidator>
                        </td>
                    </tr>-->
                        </table>
                        <table width="100%" border="0" align="center">
                            <tr>
                                <td class="fomrsubheader" align="center">
                                    <ul class="nav nav-list">
                                        <li class="active"><a href="#"><i class="icon-home icon-white"></i>Banking Details</a></li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPreviousPackage" runat="server" Text="Previous Package : " CssClass="formlable"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPreviousPackage" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfvPreviousPackage" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter PreviousPackage !!!" ControlToValidate="txtPreviousPackage"
                                        ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPayScale" runat="server" Text="Pay Scale : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label33" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtPayScale" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:FilteredTextBoxExtender ID="ftbePayScale" runat="server" TargetControlID="txtPayScale"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                    <%--<asp:RequiredFieldValidator ID="rfvPayScale" runat="server" ForeColor="red" ErrorMessage="Please Enter PayScale !!!"
                                        ControlToValidate="txtPayScale" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSalaryMode" runat="server" Text="Salary Mode : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label34" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalaryMode" runat="server" Width="220px" ValidationGroup="QualificationBankingDetails">
                                        <asp:ListItem Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                        <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                        <asp:ListItem Value="DD">DD</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSalaryMode" runat="server" ForeColor="red" ErrorMessage="Please Select Salary Mode !!!"
                                        ControlToValidate="ddlSalaryMode" InitialValue="Select" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPFNumber" runat="server" Text="PF Number : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label35" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPFNumber" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPFNumber" runat="server" ForeColor="red" ErrorMessage="Please Enter PFNumber !!!"
                                        ControlToValidate="txtPFNumber" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBankName" runat="server" Text="Bank : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label29" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ForeColor="red" ErrorMessage="Please Enter Bank Name !!!"
                                        ControlToValidate="txtBankName" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBranchName" runat="server" Text="Bank Branch : " CssClass="formlable"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBranchName" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Branch Name !!!" ControlToValidate="txtBranchName"
                                        ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblIFSCCode" runat="server" Text="Bank IFSC Code : " CssClass="formlable"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIFSCCode" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ForeColor="red" ErrorMessage="Please Enter IFSC Code !!!"
                                        ControlToValidate="txtIFSCCode" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label36" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccountNumber" runat="server" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Account Number !!!" ControlToValidate="txtAccountNumber"
                                        ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                        <asp:FilteredTextBoxExtender ID="ftbAccountNo" runat="server" TargetControlID="txtPayScale"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUserName" runat="server" Text="UserName : "></asp:Label>
                                    <asp:Label ID="Label37" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server" Enabled="false" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ForeColor="red" ErrorMessage="Please Enter UserName !!!"
                                        ControlToValidate="txtUserName" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                                    <asp:Label ID="Label38" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfdPassword" runat="server" ForeColor="red" ErrorMessage="Please Enter Password !!!"
                                        ControlToValidate="txtPassword" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" ValidationGroup="QualificationBankingDetails"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ForeColor="red"
                                        ErrorMessage="Please Enter Confirm Password !!!" ControlToValidate="txtConfirmPassword"
                                        Display="Dynamic" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvPasswordConfirmPassword" runat="server" ErrorMessage="Passowrd should be Match"
                                        ForeColor="red" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                                        Display="Dynamic" ValidationGroup="QualificationBankingDetails"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhotoUpload" runat="server" Text="Upload Photo : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="PhotoUpload" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvPhotoUpload" runat="server" ForeColor="red" ErrorMessage="Please Upload Photo !!!"
                                        ControlToValidate="PhotoUpload" ValidationGroup="QualificationBankingDetails"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btnPre2" runat="server" Text="Previous" class="btn btn-primary" OnClick="btnPre2_Click"
                                        CausesValidation="false" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="QualificationBankingDetails"
                                        OnClick="btnSave_Click1" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" CauseValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>