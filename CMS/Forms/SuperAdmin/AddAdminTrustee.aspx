<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="AddAdminTrustee.aspx.cs" Inherits="CMS.Forms.SuperAdmin.AddAdminTrustee" %>

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
        .auto-style1 {
            width: 200px;
        }
        .auto-style3 {
            width: 200px;
            height: 35px;
        }
        .auto-style4 {
            margin-bottom: 1px;
        }
        .auto-style14 {
            margin-bottom: 0px;
        }
        .auto-style35 {
            width: 200px;
            height: 24px;
        }
        .auto-style100 {
            width: 230px;
        }
        .auto-style101 {
            width: 230px;
            height: 24px;
        }
        .auto-style102 {
            width: 230px;
            height: 35px;
        }
        .auto-style107 {
            width: 40px;
        }
        .auto-style108 {
            width: 40px;
            height: 24px;
        }
        .auto-style109 {
            width: 40px;
            height: 35px;
        }
        
        </style>
    <script>
        function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    
    <div style="width: 900px; height: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" ChildrenAsTriggers="true">
           <Triggers>
              <%--   <asp:c ControlID="btnContinue"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnAddressPanel"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnPre1"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnPre2"></asp:PostBackTrigger>--%>
                <asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
            </Triggers>
            <ContentTemplate>
                <asp:Panel ID="Panel_PersonalInfo" runat="server" Visible="true" Style="
                    width: 900px; border: double #0C7BFA">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <td class="fomrsubheader" align="center">
                                <ul class="nav nav-list">
                                    <li class="active"><a href="#"><i class="icon-home icon-white"></i>Add Employee</a></li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table border="0" width="730px" align="center">
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="lblFirstName3" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Organization"></asp:Label>
                            </td>
                            <td class="auto-style100">
                                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" ValidationGroup="General" Width="180px">
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
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="lblFirstName0" runat="server" CssClass="formlable" Text="First Name:" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style100">
                                <asp:Label ID="lblFirstName1" runat="server" CssClass="formlable" Text="Middle Name:" Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="Please Enter Middle Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">
                                <asp:Label ID="lblFirstName2" runat="server" CssClass="formlable" Text="Last Name:" Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style100">
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="auto-style14" placeholder="Middle Name" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="auto-style14" placeholder="Last Name" ValidationGroup="General"></asp:TextBox>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td>
                                <asp:Label ID="lblDesignationName" runat="server" Text="Designation: " CssClass="formlable"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDesignationName" runat="server" Width="220px" ValidationGroup="General">
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
                                    ValidationGroup="General"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <%-- <tr>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" Text="Course : " CssClass="formlable"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="220px" ValidationGroup="General">
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
                                    ControlToValidate="ddlCourse" ValidationGroup="General"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                         <tr>
                            <td class="auto-style101">
                                <asp:Label ID="lblBirthDate" runat="server" CssClass="formlable" Text="Birth Date : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txt_BirthDate" ErrorMessage="Select Birth Date !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                             </td>
                            <td class="auto-style101">
                                <asp:Label ID="lblBloodGroup" runat="server" CssClass="formlable" Text="Blood Group : " Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentCountry0" runat="server" ControlToValidate="ddlBloodGroup" ErrorMessage="Please Select BllodGroup !!!" ForeColor="red" ValidationGroup="General" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style108">
                                &nbsp;</td>
                             <td class="auto-style35" width="230px">
                                 <asp:Label ID="lblCasteCategory" runat="server" CssClass="formlable" Text="CasteCategory : " Font-Bold="True"></asp:Label>
                                 <asp:Label ID="Label23" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                 <asp:RequiredFieldValidator ID="rfvCasteCategory" runat="server" ControlToValidate="ddlCasteCategory" ErrorMessage="Please Enter CasteCategory !!!" ForeColor="Red" InitialValue="0" ValidationGroup="General">*</asp:RequiredFieldValidator>
                             </td>
                        </tr>
                        <tr>
                            <td class="auto-style101">
                                <asp:TextBox ID="txt_BirthDate" runat="server" placeholder="dd/mm/yyyy" ValidationGroup="General"></asp:TextBox>
                                <asp:CalendarExtender ID="txt_BirthDate_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txt_BirthDate"  TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td class="auto-style101">
                                <asp:DropDownList ID="ddlBloodGroup" runat="server" ValidationGroup="General" Width="180px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
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
                            <td class="auto-style108">
                                &nbsp;</td>
                            <td class="auto-style35" width="230px">
                                <asp:DropDownList ID="ddlCasteCategory" runat="server" ValidationGroup="General" Width="180px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                     
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="lblGender" runat="server" CssClass="formlable" Text="Gender : "></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rbtnGender" ErrorMessage="Please Choose Gender !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style100">
                                <asp:Label ID="lblMaritalStatus" runat="server" CssClass="formlable" Text="Marital Status : "></asp:Label>
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvMaritalStatus" runat="server" ControlToValidate="rbtnMaritalStatus" ErrorMessage="Please Choose Marital Status !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">&nbsp;</td>
                        </tr>
                     
                        <tr>
                            <td class="auto-style100" align="center">
                                <asp:RadioButtonList ID="rbtnGender" runat="server" CssClass="radio" RepeatDirection="Horizontal" ValidationGroup="General" Width="200px">
                                    <asp:ListItem Selected="True" Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="center" class="auto-style100">
                                <asp:RadioButtonList ID="rbtnMaritalStatus" runat="server" CssClass="radio" RepeatDirection="Horizontal" ValidationGroup="General" Width="160px">
                                    <asp:ListItem Selected="True" Text="Married" Value="Married"></asp:ListItem>
                                    <asp:ListItem Selected="False" Text="Unmarried" Value="UnMarried"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style107">&nbsp;</td>
                            <td class="auto-style1" width="230px">&nbsp;</td>
                        </tr>
                     
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="lblPhoneNumber" runat="server" CssClass="formlable" Text="Phone Number : " Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style100">
                                <asp:Label ID="lblMobileNumber" runat="server" CssClass="formlable" Text="Mobile : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label21" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Please Enter Mobile Number !!!" ForeColor="Red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">
                                <asp:Label ID="lblEmail" runat="server" CssClass="formlable" Text="Email : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label22" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter Email !!!" ForeColor="Red"
                                    ValidationGroup="General">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Please Enter Valid Email !!!" 
                                    ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="General">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                     
                        <tr>
                            <td class="auto-style100">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" onkeypress="return isNumberKey(event)" placeholder="Phone number" MaxLength="12" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style100">
                                <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="Mobile" onkeypress="return isNumberKey(event)" MaxLength="10" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="email@abc.com" ValidationGroup="General"></asp:TextBox>
                            </td>
                        </tr>
                     
                        <tr>
                            <td class="auto-style102">
                                <asp:Label ID="lblPanCardNo" runat="server" CssClass="formlable" Text="Pan Card No : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label25" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPanCardNo" runat="server" ControlToValidate="txtPanCardNo" ErrorMessage="Please Enter Pan Card No !!!" ForeColor="Red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style102">
                                <asp:Label ID="lblMotherName" runat="server" CssClass="formlable" Text="Mother Name : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ControlToValidate="txtMotherName" ErrorMessage="Please Enter Mother Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style109">
                                &nbsp;</td>
                            <td class="auto-style3" width="230px">
                                <asp:Label ID="lblJoiningDate" runat="server" CssClass="formlable" Text="Date of Joining : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label26" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvJoiningDate" runat="server" ControlToValidate="txtJoiningDate" ErrorMessage="Please Choose Joinging Date !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style102">
                                <asp:TextBox ID="txtPanCardNo" runat="server" placeholder="Pan Card No" MaxLength="10" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style102">
                                <asp:TextBox ID="txtMotherName" runat="server" placeholder="Mother's Name" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style109">
                                &nbsp;</td>
                            <td class="auto-style3" width="230px">
                                <asp:TextBox ID="txtJoiningDate" runat="server" placeholder="dd/mm/yyyy" ValidationGroup="General"></asp:TextBox>
                                <asp:CalendarExtender ID="JoiningDate_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="txtJoiningDate" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style100" >
                                <asp:Label ID="lblPresentAddress" runat="server" CssClass="formlable" Text=" Address : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentAddress" runat="server" ControlToValidate="txtPresentAddress" ErrorMessage="Please Enter Present Address !!!" ForeColor="Red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style100" >
                                <asp:Label ID="lblNationality" runat="server" CssClass="formlable" Text="Nationality : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label24" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="txtNationality" ErrorMessage="Please Nationality !!!" ForeColor="Red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:Label ID="lblPresentPinCode" runat="server" CssClass="formlable" Text="Pin Code : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentPinCode" runat="server" ControlToValidate="txtPresentPinCode" ErrorMessage="Please Enter Pin Code !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:TextBox ID="txtPresentAddress" runat="server" Rows="1" Style="resize:none;" TextMode="MultiLine" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style100" >
                                <asp:TextBox ID="txtNationality" runat="server" placeholder="Nationality" CssClass="auto-style4" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:TextBox ID="txtPresentPinCode" runat="server" MaxLength="6" placeholder="PinCode" ValidationGroup="General"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="rtbPresentPinCode" runat="server" FilterType="Numbers" TargetControlID="txtPresentPinCode">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="lblPresentCountry" runat="server" CssClass="formlable" Text="Country : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentCountry" runat="server" ControlToValidate="ddlPresentCity" ErrorMessage="Please Select Country !!!" ForeColor="red" ValidationGroup="General" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style100">
                                <asp:Label ID="lblPresentCountry0" runat="server" CssClass="formlable" Text="State : " Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentState" runat="server" ControlToValidate="ddlPresentState" ErrorMessage="Please Select State !!!" ForeColor="red" ValidationGroup="General" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:Label ID="lblPresentCountry1" runat="server" CssClass="formlable" Text="District : " Font-Bold="True"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvPresentCity" runat="server" ControlToValidate="ddlPresentCity" ErrorMessage="Please Select City !!!" ForeColor="red" ValidationGroup="General" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:DropDownList ID="ddlPresentCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPresentCountry_SelectedIndexChanged" ValidationGroup="General" Width="180px">
                                    <asp:ListItem Value="0">Select
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style100">
                                <asp:DropDownList ID="ddlPresentState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPresentState_SelectedIndexChanged" ValidationGroup="General" Width="180px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:DropDownList ID="ddlPresentCity" runat="server" ValidationGroup="General" Width="180px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100">
                                <asp:Label ID="Label3" runat="server" CssClass="formlable" Text="Role : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="DDL_Role" ErrorMessage="Please Select Role" ForeColor="red" InitialValue="Select" TargetControlID="DDL_Role" ValidationGroup="General">*</asp:RequiredFieldValidator>
                                
                            </td>
                            <td class="auto-style100">
                                <asp:Label ID="lblDesignationType" runat="server" CssClass="formlable" Text="Faculty Type : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label73" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvDesignationType" runat="server" ControlToValidate="rbtnDesignationType" ErrorMessage="Please Select Designation Type !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td class="auto-style1" width="230px">
                                <asp:Label ID="lblSpecialization" runat="server" CssClass="formlable" Text="Specialization : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label70" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvSpecialization" runat="server" ControlToValidate="txtSpecialization" ErrorMessage="Please Enter Specialization !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                            <tr>
                                <td class="auto-style100">
                                    <asp:DropDownList ID="DDL_Role" runat="server" Style="margin-top: 5px;" Width="180px" OnSelectedIndexChanged="DDL_Role_SelectedIndexChanged" ValidationGroup="General">
                                        <%--OnSelectedIndexChanged="DDL_Role_SelectedIndexChanged"--%>
                                        <asp:ListItem  Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="trustee" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style100">
                                    <asp:RadioButtonList ID="rbtnDesignationType" runat="server" AutoPostBack="True" CssClass="radio" RepeatDirection="Horizontal" ValidationGroup="General" Width="190px" OnSelectedIndexChanged="rbtnDesignationType_SelectedIndexChanged" Enabled="False">
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style107">&nbsp;</td>
                                <td class="auto-style1" width="230px">
                                    <asp:TextBox ID="txtSpecialization" runat="server" placeholder="Specialization" ValidationGroup="General"></asp:TextBox>
                                </td>
                        </tr>
                            <tr>
                                <td class="auto-style100">
                                    <asp:Label ID="lblDepartment" runat="server" Text="Department " Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style100">
                                    <asp:Label ID="lblDepartment0" runat="server" Text="Designation" Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style107">
                                    &nbsp;</td>
                                <td class="auto-style1" width="230px">
                                    <asp:Label ID="lblTeachingExperience" runat="server" CssClass="formlable" Text="Teaching Experience : " Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label32" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvTeachingExperience" runat="server" ControlToValidate="txtTeachingExperience" ErrorMessage="Please Enter Teaching Experience In Number !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                                </td>
                        </tr>
                            <tr>
                                <td class="auto-style100">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" Style="margin-top: 5px;" Width="180px" ValidationGroup="General">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style100">
                                    <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="false" Style="margin-top: 5px;" Width="180px" ValidationGroup="General">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style107">
                                    &nbsp;</td>
                                <td class="auto-style1" width="230px">
                                    <asp:TextBox ID="txtTeachingExperience" placeholder="Teaching exp." runat="server" MaxLength="5" TextMode="Number" ValidationGroup="General"></asp:TextBox>
                                </td>
                        </tr>
                            <tr>
                            <td class="auto-style100" >
                                <asp:Label ID="lblUGDegree" runat="server" CssClass="formlable" Text="UGDegree : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label27" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvUGDegree" runat="server" ControlToValidate="txtUGDegree" ErrorMessage="Please Select UGDegree !!!" ForeColor="red" InitialValue="Select" ValidationGroup="General">*</asp:RequiredFieldValidator>
                                </td>
                            <td class="auto-style100" >
                                <asp:Label ID="lblPGDegree" runat="server" CssClass="formlable" Text="PGDegree : " Font-Bold="True"></asp:Label>
                                </td>
                                <td class="auto-style107">
                                    &nbsp;</td>
                                <td width="230px">
                                    <asp:Label ID="lblOtherQualification" runat="server" CssClass="formlable" Text="Other Qualification : " Font-Bold="True"></asp:Label>
                                    <asp:Label ID="Label28" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvOtherQualification" runat="server" ControlToValidate="txtOtherQualification" ErrorMessage="Please Enter Other Qualification !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style100" >
                                <asp:TextBox ID="txtUGDegree" placeholder="UG Degree" runat="server" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style100" >
                                <asp:TextBox ID="txtPGDegree" placeholder="PG Degree" runat="server" ValidationGroup="General"></asp:TextBox>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:TextBox ID="txtOtherQualification" runat="server" placeholder="Other Qualification" ValidationGroup="General"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style100" >
                                <asp:Label ID="lblBankName" runat="server" CssClass="formlable" Text="Bank : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label29" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" ErrorMessage="Please Enter Bank Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style100" >
                                <asp:Label ID="lblBranchName" runat="server" CssClass="formlable" Text="Bank Branch : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label71" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBranchName" ErrorMessage="Please Enter Branch Name !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style107">
                                &nbsp;</td>
                            <td width="230px">
                                <asp:Label ID="lblAccountNumber" runat="server" CssClass="formlable" Text="Account Number : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label36" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" ErrorMessage="Please Enter Account Number !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                            </td>
                            <tr>
                                <td class="auto-style100" >
                                    <asp:TextBox ID="txtBankName" runat="server" placeholder="Bank Name" ValidationGroup="General"></asp:TextBox>
                                </td>
                                <td class="auto-style100" >
                                    <asp:TextBox ID="txtBranchName" placeholder="Branch Name" runat="server" ValidationGroup="General"></asp:TextBox>
                                </td>
                                <td class="auto-style107">
                                    &nbsp;</td>
                                <td width="230px">
                                    <asp:TextBox ID="txtAccountNumber" runat="server" placeholder="A/c Number" ValidationGroup="General"></asp:TextBox>
                                </td>
                                <tr>
                                    <td class="auto-style100">
                                        <asp:Label ID="lblPhotoUpload" runat="server" Text="Upload Photo : " Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="auto-style100">
                                        <asp:Label ID="lblPassword" runat="server" Text="Password : " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="Label38" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" CssClass="ValidationError" ErrorMessage="« (Required)" ToolTip="Compare Password is a REQUIRED field">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfdPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password !!!" ForeColor="red" ValidationGroup="General">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td class="auto-style107">&nbsp;</td>
                                    <td class="auto-style1" width="230px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style100">
                                         <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                        <asp:FileUpload ID="PhotoUpload" runat="server" /></ContentTemplate></asp:UpdatePanel>
                                    </td>
                                    <td class="auto-style100">
                                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" ValidationGroup="General"></asp:TextBox>
                                    </td>
                                    <td class="auto-style107">&nbsp;</td>
                                    <td class="auto-style1" width="230px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style100">
                                        <asp:Label ID="Label69" runat="server" ForeColor="#FF3300" Text="Image max size: 1MB  (png, jpeg, gif)"></asp:Label>
                                    </td>
                                    <td class="auto-style100">&nbsp;</td>
                                    <td class="auto-style107">&nbsp;</td>
                                    <td class="auto-style1" width="230px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style100">&nbsp;</td>
                                    <td class="auto-style100">
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" style="height: 28px" Text="Save" ValidationGroup="General" />
                                        <asp:Button ID="btnCancel" runat="server" CauseValidation="false" class="btn btn-primary" Text="Cancel" />
                                    </td>
                                    <td class="auto-style107">&nbsp;</td>
                                    <td class="auto-style1" width="230px">&nbsp;</td>
                                </tr>
                            </tr>
                        </tr>
                    </table>
                </asp:Panel>
                <div>

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="General" ShowMessageBox="True" ShowSummary="False" />

                </div>
                
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
