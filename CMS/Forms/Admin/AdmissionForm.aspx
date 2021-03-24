<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/College_Home.Master"
    AutoEventWireup="true" CodeBehind="AdmissionForm.aspx.cs" Inherits="CMS.Forms.Admin.AdmissionForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>


    <script type="text/javascript">
        function CheckDate(sender, args) {
            var dt = new Date();
            if (sender._selectedDate > dt) {
                sender
            ._textbox
            .set_Value(dt.format(sender._format));
                //alert the user what we just did and why
                alert("Warning! - Date Cannot be in the future");
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnProceed"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btn_Save"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnUploadSign"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnUploadPhoto"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btn_ParentContinue"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <div class="main" style="height: auto; width: 900px; margin-left: 50px; margin-right: 50px">
                <div style="height: auto; width: 900px; margin-top: 10px; margin-bottom: 20px;" align="center">
                    <asp:Panel ID="Panel_PriviousInformation" runat="server" Height="400px" align="Center"
                        Style="border: medium double#0C7BFA;" Visible="true">
                        <table align="center" style="height: 30px; width: 895px;">
                            <tr>
                                <td style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>Admission Process</li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 50%">
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPrive" runat="server" Text="Do you have previous year Registration ID & Password?"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbtnYesNo" runat="server" class="radio" Width="100px" AutoPostBack="true"
                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnYesNo_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel_PriveousUserNamePassword" runat="server" Visible="false">
                                        <table cellspacing="5" cellpadding="5">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text="Registration ID"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRegistrationID" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="Please Enter Registration ID "
                                                        ControlToValidate="txtRegistrationID"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text="Password"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ErrorMessage="Please Enter Correct Password "
                                                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="BtnContinueAdmission" runat="server" class="btn btn-primary" Text="Continue"
                                        OnClick="BtnContinueAdmission_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <%--    </asp:Panel>--%>
                </div>
                <asp:Panel ID="General_Info" runat="server" Style="border: medium double#0C7BFA;"
                    Visible="false">
                    <table align="center" style="height: 30px; width: 900px">
                        <tr>
                            <td style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>General Information</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table align="center" width="800px">
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label" runat="server" Text="Application Id"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_ApplicationId" runat="server"></asp:Label>
                            </td>
                            <td align="right" colspan="2" style="width: 400px">
                                <asp:Label ID="Label7" runat="server" Text="Admission Date/Time :"></asp:Label>
                                <asp:Label ID="lblAdmissionDate" runat="server" Text="Date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Admission Type "></asp:Label>
                                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_AdmissionType" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Confirm</asp:ListItem>
                                    <asp:ListItem>Provisional</asp:ListItem>
                                    <asp:ListItem>Management</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfv_AdmissionType" runat="server" InitialValue="Select"
                                    ControlToValidate="ddl_AdmissionType" ErrorMessage="Please Select Admission Type!"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Select Course "></asp:Label>
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Course" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_Course"
                                    InitialValue="Select" ErrorMessage="Please Select Course!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Select Branch"></asp:Label>
                                <asp:Label ID="Label16" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Branch" runat="server" OnSelectedIndexChanged="ddl_Branch_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddl_Branch"
                                    InitialValue="Select" ErrorMessage="Please Select Branch!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Select Class"></asp:Label>
                                <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Class" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="ddl_Class"
                                    InitialValue="Select" ErrorMessage="Please Select Class!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Previous Class Roll No."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_PreviousRollNo" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Fees Category"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_FeesCategory" runat="server">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="EBC" Value="EBC"></asp:ListItem>
                                    <asp:ListItem Text="PAYING" Value="PAYING"></asp:ListItem>
                                    <asp:ListItem Text="EFG" Value="EFG"></asp:ListItem>
                                    <asp:ListItem Text="MGT.OBC" Value="MGT.OBC"></asp:ListItem>
                                    <asp:ListItem Text="MGT NT/SC/ST" Value="MGT NT/SC/ST"></asp:ListItem>
                                    <asp:ListItem Text="STW" Value="STW"></asp:ListItem>
                                    <asp:ListItem Text="BCS" Value="BCS"></asp:ListItem>
                                    <asp:ListItem Text="Phy. Handicap" Value="PHY.Handicap"></asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_FeesCategory"
                                    InitialValue="Select" ErrorMessage="Please Select Fees Category!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Fees Category"></asp:Label>
                                <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_CasteCategory" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_CasteCategory"
                                    ErrorMessage="Please Select Caste Category!" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="right">
                                <asp:Button ID="btnProceed" runat="server" class="btn btn-primary" OnClick="btnProceed_Click"
                                    Text="Proceed" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:DropShadowExtender ID="General_Info_DropShadowExtender" runat="server" Enabled="True"
                    TargetControlID="General_Info">
                </asp:DropShadowExtender>
                <br />
                <asp:Panel ID="Student_Info" runat="server" Style="border: medium double#0C7BFA;
                    margin-top: 20px" Visible="false">
                    <table align="center" style="height: 30px; width: 895px">
                        <tr>
                            <td style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li>Studnet Personal Information</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table align="center" width="800px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Student's First Name"></asp:Label>
                                <asp:Label ID="Label44" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_FirstName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label207" runat="server" Text="Student's Middle Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_MiddleName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" Display="Dynamic"
                                    runat="server" ErrorMessage="Enter Only Chracter!" ControlToValidate="txt_FirstName"
                                    ValidationExpression="[a-z/A-Z]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_FirstName"
                                    ErrorMessage="Please Enter First Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_MiddleName"
                                    Display="Dynamic" ErrorMessage="Enter Only Chracter!" ValidationExpression="[a-z/A-Z]+$"
                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_MiddleName"
                                    Display="Dynamic" ErrorMessage="Please Enter Middle Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label208" runat="server" Text="Student's Last name"></asp:Label>
                                <asp:Label ID="Label45" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="txt_LastName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label206" runat="server" Text="Gender"></asp:Label>
                                <asp:Label ID="Label168" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbt_Gender" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                    Width="150px">
                                    <asp:ListItem Text="Male" Value="Male">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female">
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                              
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_LastName"
                                    ErrorMessage="Please Enter Last Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="rbt_Gender"
                                    ErrorMessage="Please Select Gender!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label209" runat="server" Text="Birth Date"></asp:Label>
                                <asp:Label ID="Label46" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BirthDate" runat="server"></asp:TextBox>
                                   <asp:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" 
                                                                            TargetControlID="txt_BirthDate" Format="dd/MM/yyyy" ></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="Label169" runat="server" Text="Birth Place"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_BirthPlace" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt_BirthDate"
                                    ErrorMessage="Please Select Birth Date!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Address Line 1"></asp:Label>
                                <asp:Label ID="Label48" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="txt_Address1" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label32" runat="server" Text="Address Line 2"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Address2" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txt_Address1"
                                    ErrorMessage="Please Enter Address Line1!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label171" runat="server" Text="Country"></asp:Label>
                                <asp:Label ID="Label210" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddl_Country" runat="server" AutoPostBack="True" InitialValue="Select"
                                    OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label174" runat="server" Text="State"></asp:Label>
                                <asp:Label ID="Label175" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddl_Country"
                                    InitialValue="Select" ErrorMessage="Please Select Country!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddl_State"
                                    InitialValue="Select" ErrorMessage="Please Select State!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label176" runat="server" Text="District"></asp:Label>
                                <asp:Label ID="Label211" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddl_District" runat="server">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label33" runat="server" Text="Taluka"></asp:Label>
                                <asp:Label ID="Label212" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtTaluka" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddl_District"
                                    ErrorMessage="Please Select District!" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TxtTaluka"
                                    ErrorMessage="Please Select Taluka!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label177" runat="server" Text="City/Village"></asp:Label>
                                <asp:Label ID="Label213" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="TxtCity" runat="server"></asp:TextBox>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label178" runat="server" Text="Pin Code"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Pincode" runat="server" MaxLength="6"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_Pincode"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="TxtCity"
                                    ErrorMessage="Please Select City!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_Pincode"
                                    ErrorMessage="Please Enter Only Number!" ForeColor="Red" ValidationExpression="^[0-9]{6}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="Personal Mobile"></asp:Label>
                                <asp:Label ID="Label55" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="txt_PersonalMobile" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_PersonalMobile"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td>
                                <asp:Label ID="Label37" runat="server" Text="E-Mail"></asp:Label>
                                <asp:Label ID="Label56" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_PersonalMobile"
                                    ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="txt_PersonalMobile"
                                    Type="Integer" ValidationExpression="^[0-9]{10}"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="expEmail" runat="server" ControlToValidate="txt_Email"
                                    ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" Text="Nationality"></asp:Label>
                                <asp:Label ID="Label58" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="DDL_Nationality" runat="server">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Married status"></asp:Label>
                                <asp:Label ID="Label243" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbt_MarriedStatus" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                    Width="200px">
                                    <asp:ListItem Text="Married" Value="Married">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Unmarried" Value="Unmarried">
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="DDL_Nationality"
                                    ErrorMessage="Please Enter Nationality!" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="rbt_MarriedStatus"
                                    ErrorMessage="Please Select Married Status!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Blood Group"></asp:Label>
                                <asp:Label ID="Label62" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddl_BloodGroup" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem> A+ </asp:ListItem>
                                    <asp:ListItem> A-</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label41" runat="server" Text="Handicap"></asp:Label>
                                <asp:Label ID="Label67" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Handicap" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Blind</asp:ListItem>
                                    <asp:ListItem>Deep</asp:ListItem>
                                    <asp:ListItem>Dump</asp:ListItem>
                                    <asp:ListItem>L.D.</asp:ListItem>
                                    <asp:ListItem>Spastic</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddl_BloodGroup"
                                    InitialValue="Select" ErrorMessage="Please Select Blood Group!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="ddl_Handicap"
                                    InitialValue="Select" ErrorMessage="Please Select Physical Status!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                  
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Select Sports"></asp:Label>
                                <asp:Label ID="Label18" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="DDL_Sports" runat="server">
                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="Level Played"></asp:Label>
                              
                            </td>
                            <td>
                                <asp:DropDownList ID="DDL_SportLevel" runat="server">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                      <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                                    <asp:ListItem Text="Inter School/College" Value="Inter School"></asp:ListItem>
                                    <asp:ListItem Text="Tahsil" Value="Tahsil"></asp:ListItem>
                                    <asp:ListItem Text="District" Value="District"></asp:ListItem>
                                    <asp:ListItem Text="National" Value="National"></asp:ListItem>
                                    <asp:ListItem Text="Inter National" Value="Inter National"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="DDL_Sports"
                                    InitialValue="-1" ErrorMessage="Please Select Sport " ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>

                              <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="Conveyance Use"></asp:Label>
                                <asp:Label ID="Label63" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddl_ConveyanceUse" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>By Bus</asp:ListItem>
                                    <asp:ListItem>Bycicle</asp:ListItem>
                                    <asp:ListItem>Bike</asp:ListItem>
                                    <asp:ListItem>By Walk</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label42" runat="server" Text="Religion"></asp:Label>
                                <asp:Label ID="Label66" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Religion" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Hindu</asp:ListItem>
                                    <asp:ListItem>Muslim</asp:ListItem>
                                    <asp:ListItem>Shikh</asp:ListItem>
                                    <asp:ListItem>Christion</asp:ListItem>
                                    <asp:ListItem>Bouddh</asp:ListItem>
                                    <asp:ListItem>Jain</asp:ListItem>
                                    <asp:ListItem>Marwadi</asp:ListItem>
                                    <asp:ListItem>Islam</asp:ListItem>
                                    <asp:ListItem>Mala</asp:ListItem>
                                    <asp:ListItem>Attar</asp:ListItem>
                                     <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="ddl_ConveyanceUse"
                                    InitialValue="Select" ErrorMessage="Please Select Conveyance Used !" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="ddl_Religion"
                                    InitialValue="Select" ErrorMessage="Please Select Religion !" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="Caste"></asp:Label>
                                <asp:Label ID="Label64" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddl_Caste" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label43" runat="server" Text="Sub Caste"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubcast" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="ddl_Caste"
                                    ErrorMessage="Please Select  Caste!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <br />
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="bntStudentInfoBack" runat="server" class="btn btn-primary" Text="Back"
                                    CausesValidation="false" OnClick="bntStudentInfoBack_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnContinue" runat="server" class="btn btn-primary" Text="Save And Continue"
                                    OnClick="btnContinue_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </asp:Panel>
                <asp:DropShadowExtender ID="Student_Info_DropShadowExtender" runat="server" Enabled="true"
                    TargetControlID="Student_Info">
                </asp:DropShadowExtender>
                <br />
                <asp:Panel ID="Guardian_info" runat="server" Style="border: medium double#0C7BFA;"
                    Visible="false">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" width="900px">
                        <ContentTemplate>
                            <table align="center" style="height: 30px; width: 900px">
                                <tr>
                                    <td style="background-color: #0C7BFA; color: White">
                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Guardian Information</li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                            <table align="center" width="800px">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label90" runat="server" Text="Guardian Name"></asp:Label>
                                        <asp:Label ID="Label91" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label92" runat="server" Text="Relation with Guardian"></asp:Label>
                                        <asp:Label ID="Label93" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Relation" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Father</asp:ListItem>
                                            <asp:ListItem>Mother</asp:ListItem>
                                            <asp:ListItem>Husband</asp:ListItem>
                                            <asp:ListItem>Uncle</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txt_GuardianName"
                                            ErrorMessage="Please Enter Guardian Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txt_GuardianName"
                            ErrorMessage="Enter Only Characters!" ForeColor="Red" ValidationExpression="[a-z/A-Z]+$"></asp:RegularExpressionValidator>--%>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_Relation"
                                            ErrorMessage="Please Select  Relation!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label94" runat="server" Text="Guardian Address Line1"></asp:Label>
                                        <asp:Label ID="Label95" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianAddress1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label96" runat="server" Text="Guardian Address Line2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianAddress2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_GuardianAddress1"
                                            ErrorMessage="Please Enter Address Line1!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label98" runat="server" Text="Guardian Country"></asp:Label>
                                        <asp:Label ID="Label99" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_GuardianCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_GuardianCountry_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label180" runat="server" Text="Guardian State"></asp:Label>
                                        <asp:Label ID="Label181" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_GuardianState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_GuardianState_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddl_GuardianCountry"
                                            ErrorMessage="Please Select Country!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddl_GuardianState"
                                            ErrorMessage="Please Select State!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label184" runat="server" Text="Guardian District"></asp:Label>
                                        <asp:Label ID="Label222" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_GuardianDistrict" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label102" runat="server" Text="Guardian Taluka"></asp:Label>
                                        <asp:Label ID="Label223" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGuardianTaluka" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddl_GuardianDistrict"
                                            ErrorMessage="Please Select District!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtGuardianTaluka"
                                            ErrorMessage="Please Select Taluka!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label185" runat="server" Text="Guardian City/Village"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGuardianCity" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label182" runat="server" Text="Guardian Pincode"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianPincode" runat="server" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtGuardianCity"
                                            ErrorMessage="Please Select City!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label188" runat="server" Text="Guardian Personal Mobile"></asp:Label>
                                        <asp:Label ID="Label189" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianMobile" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label190" runat="server" Text="Guardian E-Mail"></asp:Label>
                                        <asp:Label ID="Label191" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_GuardianEmail" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_GuardianMobile"
                                            ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="txt_PersonalMobile"
                                            Type="Integer" ValidationExpression="^[0-9]{10}"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_GuardianEmail"
                                            ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                            <table align="center" width="900px">
                                <tr>
                                    <td colspan="4" style="background-color: #0C7BFA; color: White" width="300px">
                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Parent/Father/Husband Information</li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="btnSameAsAbove" runat="server" class="btn btn-primary" OnClick="btnSameAsAbove_Click"
                                            CausesValidation="false" Text="Same As Above" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <table align="center" width="800px">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label69" runat="server" Text="Father/Husband Name"></asp:Label>
                                        <asp:Label ID="Label70" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label71" runat="server" Text="Mother Name"></asp:Label>
                                        <asp:Label ID="Label72" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_MotherName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ParentName"
                                            Display="Dynamic" ErrorMessage="Please Enter Guardian Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_MotherName"
                                            Display="Dynamic" ErrorMessage="Please Enter Mother Name!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label73" runat="server" Text="Parent Address Line1"></asp:Label>
                                        <asp:Label ID="Label74" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentAddress1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label75" runat="server" Text="Parent Address Line2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentAddress2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txt_ParentAddress1"
                                            ErrorMessage="Please Enter Address Line1!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label77" runat="server" Text="Parent Country"></asp:Label>
                                        <asp:Label ID="Label78" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ParentCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ParentCountry_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label192" runat="server" Text="Parent State"></asp:Label>
                                        <asp:Label ID="Label214" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ParentState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ParentState_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddl_ParentCountry"
                                            ErrorMessage="Please Select Country!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="ddl_Parentstate"
                                            ErrorMessage="Please Select State!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label194" runat="server" Text="Parent District"></asp:Label>
                                        <asp:Label ID="Label215" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlParentDistrict" runat="server" AutoPostBack="True">
                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label81" runat="server" Text="Parent Taluka"></asp:Label>
                                        <asp:Label ID="Label216" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtParentTaluka" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="ddlParentDistrict"
                                            ErrorMessage="Please Select District!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="TxtParentTaluka"
                                            ErrorMessage="Please Select Taluka!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label195" runat="server" Text="Parent City"></asp:Label>
                                        <asp:Label ID="Label217" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentCity" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label196" runat="server" Text="Parent Pincode"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentPincode" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txt_ParentCity"
                                            ErrorMessage="Please Select City!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                            ControlToValidate="txt_ParentPincode" ErrorMessage="Please Enter Only Numbers!"
                                            ForeColor="Red" ValidationExpression="[0-9]+$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label200" runat="server" Text="Parent Personal Mobile"></asp:Label>
                                        <asp:Label ID="Label201" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentPersonalMobile" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label202" runat="server" Text="Parent E-Mail"></asp:Label>
                                        <asp:Label ID="Label89" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_ParentEmail" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txt_ParentPersonalMobile"
                                            ErrorMessage="Please Enter Phone Number" ForeColor="red" TargetControlID="txt_ParentPersonalMobile"
                                            Type="Integer" ValidationExpression="^[0-9]{10}"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_ParentEmail"
                                            ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="btn_Back" runat="server" class="btn btn-primary" CausesValidation="false"
                                            Text="Back" OnClick="btn_Back_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnParentDetailsSkip" runat="server" class="btn btn-primary" CauseValidation="false"
                                            Text="Skip" OnClick="btnParentDetailsSkip_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btn_ParentContinue" runat="server" class="btn btn-primary" Text="Continue"
                                            OnClick="btn_ParentContinue_Click" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:DropShadowExtender ID="Guardian_info_DropShadowExtender" runat="server" Enabled="True"
                    TargetControlID="Guardian_info">
                </asp:DropShadowExtender>
                <br />
                <asp:Panel ID="Previous_Institute_Info" runat="server" Style="border: medium double#0C7BFA;"
                    Visible="false">
                    <table align="center" style="height: 30px; width: 900px">
                        <tr>
                            <td style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Previous Institute Information</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <table align="center" width="800px">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label117" runat="server" Text="Last Attended Class"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_LastAttendedClass" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label119" runat="server" Text="Resident Type"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_ResidentType" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Text="Hostel" Value="Hostel"></asp:ListItem>
                                    <asp:ListItem Text="Home" Value="Home"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label121" runat="server" Text="Last Attended Institute Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_InstituteName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label244" runat="server" Text="Last Exam Seat No."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_LastExamSeatNo0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label232" runat="server" Text="Last Exam Passing Month"></asp:Label>
                                
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_LastExamPassingMonth" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Text="January"></asp:ListItem>
                                    <asp:ListItem Text="February"></asp:ListItem>
                                    <asp:ListItem Text="March"></asp:ListItem>
                                    <asp:ListItem Text="April"></asp:ListItem>
                                    <asp:ListItem Text="May"></asp:ListItem>
                                    <asp:ListItem Text="June"></asp:ListItem>
                                    <asp:ListItem Text="July"></asp:ListItem>
                                    <asp:ListItem Text="August"></asp:ListItem>
                                    <asp:ListItem Text="September"></asp:ListItem>
                                    <asp:ListItem Text="October"></asp:ListItem>
                                    <asp:ListItem Text="November"></asp:ListItem>
                                    <asp:ListItem Text="December"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label235" runat="server" Text="Last Exam Passing Year"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_LastExamPassingYear" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>2007</asp:ListItem>
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label228" runat="server" Text="Last Exam Result"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Result" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label234" runat="server" Text="Last Exam Percentage(%)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Percentage" runat="server"></asp:TextBox>
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
                                <asp:RangeValidator ID="RangeValidator1" runat="server"  MaximumValue="100"  Type="Integer" MinimumValue="1" ControlToValidate="txt_Percentage"
                                    ErrorMessage="Please Enter Value Between 1 to 100"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label236" runat="server" Text="Gap"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Gap" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>1 Year</asp:ListItem>
                                    <asp:ListItem>2 Year</asp:ListItem>
                                    <asp:ListItem>3 Year</asp:ListItem>
                                    <asp:ListItem>4 Year</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label239" runat="server" Text="T.C./L.C. No."></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_TcNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Concession" runat="server">
                        <table align="center" style="height: 30px; width: 900px">
                            <tr>
                                <td style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>Bank Details</li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center" width="800px">
                      
                            <tr>
                                <td>
                                    <asp:Label ID="Label149" runat="server" Text="Bank Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label150" runat="server" Text="Bank Account No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AccountNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label151" runat="server" Text="Branch Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_BranchName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label152" runat="server" Text="IFSC Code of that Bank"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_IFSCCode" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                          
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnPreIntituteBack" runat="server" class="btn btn-primary" Text="Back" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPreIntituteContinue" runat="server" class="btn btn-primary" OnClick="btnPreIntituteContinue_Click"
                                        Text="Continue" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                </asp:Panel>
                <asp:DropShadowExtender ID="Previous_Institute_Info_DropShadowExtender" runat="server"
                    Enabled="True" TargetControlID="Previous_Institute_Info">
                </asp:DropShadowExtender>
                <br />
                <%--  Education Qualification Panel--%>
                <asp:Panel ID="Education_Qualification" runat="server" Style="border: medium double#0C7BFA;"
                    Visible="false">
                    <table align="center" style="height: 30px; width: 900px">
                        <tr>
                            <td style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Education Qualification Details</li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" ShowFooter="true"
                            Width="900px">
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Sr.No." />
                                <asp:TemplateField HeaderText="Qualified Exam">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtQualifiedExam" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Board/University">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUniversity" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Month">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMonth" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtYear" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGrade" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Obt. Marks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtobtMarks" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max Marks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMaxMarks" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Per">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPer" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="AddNewRowToGrid" runat="server" Text="Add New Row" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                </asp:Panel>
                <br />
                <asp:Panel ID="UploadPhoto" runat="server" Style="border: medium double#0C7BFA;"
                    Visible="false">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn_Save"></asp:PostBackTrigger>
                        </Triggers>
                        <ContentTemplate>
                            <table align="center" style="height: 30px; width: 900px">
                                <tr>
                                    <td style="background-color: #0C7BFA; color: White">
                                        <ul class="nav nav-list">
                                            <li><i class="icon-book"></i>Upload Image</li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                            <table align="center" style="width: 800px">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table width="800px" align="center">
                                <tr>
                                    <td class="style2" colspan="2">
                                        Note:-<asp:Label ID="lblFileuploadError" runat="server" Font-Size="Small" Enabled="false"
                                            ForeColor="Red" Text="* Please upload only JPG,JPEG format image only with minimum size of 5KB or maximum size of 1MB"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="500px">
                                        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label156" runat="server" Text="Upload Photo(.jpg)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:FileUpload ID="fileupload_StudentPhoto" runat="server" Height="29px" Width="228px" />
                                                <asp:Button ID="btnUploadPhoto" runat="server" class="btn btn-primary" Text="Upload"
                                                    CausesValidation="false" OnClick="btnUploadPhoto_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label158" runat="server" Text="Upload Signature   (.jpg)"></asp:Label>
                                                <asp:Label ID="Label159" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                <asp:FileUpload ID="fileupload_StudentSign" runat="server" />
                                                <asp:Button ID="btnUploadSign" runat="server" class="btn btn-primary" Text="Upload"
                                                    CausesValidation="false" OnClick="btnUploadSign_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td align="justify">
                                        <asp:Image ID="img_StudentImage" runat="server" Height="125px" ImageUrl="~/images/userphoto.gif"
                                            Width="155px" />
                                        <br />
                                        <br />
                                        <asp:Image ID="img_StudentSign" runat="server" Height="25px" ImageUrl="../../images/Sign.jpg"
                                            Width="155px" />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Panel ID="Login_Details" runat="server">
                                <table align="center" style="height: 30px; width: 900px">
                                    <tr>
                                        <td style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Login Details Details</li>
                                            </ul>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" style="width: 800px">
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label160" runat="server" Text="User Name"></asp:Label>
                                            <asp:Label ID="Label163" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_UserName" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txt_UserName"
                                                ErrorMessage="Please Enter Username!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label161" runat="server" Text="Password"></asp:Label>
                                            <asp:Label ID="Label164" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txt_Password"
                                                ErrorMessage="Please Enter Password!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label162" runat="server" Text="Confirm Password"></asp:Label>
                                            <asp:Label ID="Label165" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_ConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txt_ConfirmPassword"
                                                ErrorMessage="Please Re-Enter Password!" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_Password"
                                                ControlToValidate="txt_ConfirmPassword" ErrorMessage="Password Dosen't Match!"
                                                ForeColor="Red"></asp:CompareValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_Back3" runat="server" class="btn btn-primary" Text="Back" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btn_Save" runat="server" class="btn btn-primary" OnClick="btn_Save_Click"
                                                Text="Save Information" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
             
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
       <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
