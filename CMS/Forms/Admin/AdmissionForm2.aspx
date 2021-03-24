<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/College_Home.Master"
    AutoEventWireup="true" CodeBehind="AdmissionForm2.aspx.cs" Inherits="CMS.Forms.Admin.AdmissionForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->
    <!--  For Tab Navigation Use This jQuery  -->
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS: compiled and minified -->
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
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
    <div style="">
        <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true" Style="border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>STUDENT ADMISSION</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <td>
                        <div class="MainBody">
                            <div class="frmwidth" align="center">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Personal Info</font>
                                    </a></li>
                                    <li><a href="#sp2" data-toggle="tab"><font color="blue">Guardian Details</font></a>
                                    </li>
                                    <li><a href="#sp3" data-toggle="tab"><font color="blue">Parent/Husband Information</font>
                                    </a></li>
                                    <li><a href="#sp4" data-toggle="tab"><font color="blue">Previous Institute Information</font>
                                    </a></li>
                                    <li><a href="#sp5" data-toggle="tab"><font color="blue">Bank Details</font></a></li>
                                    <li><a href="#sp6" data-toggle="tab"><font color="blue">Education Qualification</font>
                                    </a></li>
                                    <li><a href="#sp7" data-toggle="tab"><font color="blue">Upload Image</font></a></li>
                                    <li><a href="#sp8" data-toggle="tab"><font color="blue">no</font></a></li>
                                </ul>
                                <div class="tab-content">
                                    <div id="sp1" class="tab-pane active" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel_Department" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt_LastName"

                            ErrorMessage="Enter Only Chracter!" ValidationExpression="[a-z/A-Z]+$" ForeColor="Red"></asp:RegularExpressionValidator>--%>
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
                                                                        <%--<asp:CalendarExtender ID="txt_BirthDate_CalendarExtender" runat="server" OnClientDateSelectionChanged="CheckDate"
                                                                            TargetControlID="txt_BirthDate">
                                                                        </asp:CalendarExtender>--%>
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
                                                                        <asp:DropDownList ID="ddl_Country" runat="server" AutoPostBack="True" InitialValue="Select">
                                                                            <%--OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged"--%>
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label174" runat="server" Text="State"></asp:Label>
                                                                        <asp:Label ID="Label175" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--OnSelectedIndexChanged="ddl_State_SelectedIndexChanged"--%>
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
                                                                    <td class="style4">
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
                                                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
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
                                                                            InitialValue="Select" ErrorMessage="Please Select Sport " ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                                        <%--<asp:Button ID="bntStudentInfoBack" runat="server" class="btn btn-primary" Text="Back"
                                                                            CausesValidation="false" OnClick="bntStudentInfoBack_Click" />--%>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <%--<asp:Button ID="btnContinue" runat="server" class="btn btn-primary" Text="Save And Continue"
                                                                            OnClick="btnContinue_Click" />--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDepartment"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDepartment" />
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDepartment" />
                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDepartment" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp2" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel_Designation" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                                        <asp:DropDownList ID="ddl_GuardianCountry" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--OnSelectedIndexChanged="ddl_GuardianCountry_SelectedIndexChanged"--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label180" runat="server" Text="Guardian State"></asp:Label>
                                                                        <asp:Label ID="Label181" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddl_GuardianState" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--OnSelectedIndexChanged="ddl_GuardianState_SelectedIndexChanged"--%>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnNewD" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="btnSaveD" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="btnUpdateD" runat="server" Text="Update" class="btn btn-primary"
                                                                ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="btnDeleteD" runat="server" Text="Delete" class="btn btn-primary"
                                                                ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="btnCancelD" runat="server" Text="Cancel" class="btn btn-primary"
                                                                CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp3" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                                        <asp:DropDownList ID="ddl_ParentCountry" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--OnSelectedIndexChanged="ddl_ParentCountry_SelectedIndexChanged"--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label192" runat="server" Text="Parent State"></asp:Label>
                                                                        <asp:Label ID="Label214" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddl_ParentState" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%--OnSelectedIndexChanged="ddl_ParentState_SelectedIndexChanged"--%>
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button3" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button4" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button5" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp4" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" MaximumValue="100" Type="Integer"
                                                                            MinimumValue="1" ControlToValidate="txt_Percentage" ErrorMessage="Please Enter Value Between 1 to 100"></asp:RangeValidator>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button6" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button7" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button8" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button9" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button10" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp5" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button11" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button12" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button13" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button14" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button15" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp6" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button16" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button17" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button18" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button19" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button20" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp7" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
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
                                                                                    CausesValidation="false" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <br />
                                                                        <asp:UpdatePanel ID="updatePanel9" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <asp:Label ID="Label158" runat="server" Text="Upload Signature   (.jpg)"></asp:Label>
                                                                                <asp:Label ID="Label159" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                                                                <asp:FileUpload ID="fileupload_StudentSign" runat="server" />
                                                                                <asp:Button ID="btnUploadSign" runat="server" class="btn btn-primary" Text="Upload"
                                                                                    CausesValidation="false" />
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button21" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button22" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button23" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button24" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button25" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="sp8" class="tab-pane" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" align="center" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table border="0" width="80%" align="center" cellspacing="2px">
                                                    <tr>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="Button31" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDesignation"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="Button32" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button33" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button34" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDesignation" />
                                                            <asp:Button ID="Button35" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false" />
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
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>