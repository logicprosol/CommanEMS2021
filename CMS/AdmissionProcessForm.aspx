<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmissionProcessForm.aspx.cs" Inherits="CMS.AdmissionProcessForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
   
         function printpage() {

             var getpanel = document.getElementById("<%= pnl.ClientID%>");
                var MainWindow = window.open('', '', 'height=500,width=800');
                MainWindow.document.write('<html><head><title>Print Page</title>');
                MainWindow.document.write('</head><body>');
                MainWindow.document.write(getpanel.innerHTML);
                MainWindow.document.write('</body></html>');
                MainWindow.document.close();
                setTimeout(function () {
                    MainWindow.print();
                }, 500);
                return false;

        }
          function isCharacterKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
             if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                 return true;
             return false;
        }

         function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
 </script>
<head id="Head1" runat="server">
    <%--<title ></title>--%>
    
     
    <style type="text/css">
        .auto-style1 {
            height: 22px;
            width: 324px;
        }
        .auto-style2 {
            height: 22px;
            width: 163px;
        }
        .auto-style3 {
            width: 163px;
        }
        .auto-style4 {
            height: 22px;
            width: 172px;
        }
        .auto-style6 {
            width: 324px;
        }
        .auto-style7 {
            width: 172px;
        }
        .auto-style9 {
            width: 201px;
        }
        .auto-style10 {
            width: 200px;
        }
        .auto-style11 {
            border-top-style: solid;
        }
        .auto-style12 {
            width: 201px;
            border-top-style: solid;
        }
        .auto-style13 {
            width: 150px;
            border-top-style: solid;
        }
        .auto-style14 {
            width: 200px;
            border-top-style: solid;
        }
        .auto-style15 {
            width: 158px;
        }
        .auto-style16 {
            width: 158px;
            border-top-style: solid;
        }
        .auto-style17 {
            width: 182px;
        }
        .auto-style18 {
            width: 182px;
            border-top-style: solid;
        }
        </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
      <%--  <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />--%>
        

        <div style="">
            <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true" Style="border: medium double#0C7BFA;">
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th style="background-color: #0C7BFA; color: White">
                            
                                         <ul class="nav nav-list">
                                <li><i class="icon-book"></i>STUDENT ADMISSION</li>

                            </ul>
                        </th>
                    </tr>
                </table>
                <table border="0" width="100%" align="center" cellspacing="2px" style="border: medium solid #0099FF; width: 90%">
                    <tr>
                        <td>
                            <div class="MainBody">
                                <div class="frmwidth" align="center">
                                    <ul class="nav nav-tabs">
                                        <li class="active">
                                            <a href="#sp1" data-toggle="tab" >
                                            <asp:Label  runat="server" Text="Student Information" Font-Bold="True" Font-Size="Medium" ForeColor="#0066FF" ></asp:Label>
                                         </a></li>
                                        <li>
                                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CMSHome.aspx"> <b> Home</b></asp:LinkButton>  
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div id="sp1" class="tab-pane active" align="center">
                                           
                                                    <table align="center" border="0" cellspacing="2px" width="80%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <table align="center" width="900px">
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="lblGrNo2" runat="server" Font-Bold="True" ForeColor="#272727" Text="Organization"></asp:Label>
                                                                            </td>
                                                                        <td class="auto-style17">
                                                                            <asp:DropDownList ID="DDL_SelectCollege" runat="server" AutoPostBack="True" class="form" OnSelectedIndexChanged="DDL_SelectCollege_SelectedIndexChanged" placeholder="Select College" Width="180px">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCourse1" runat="server" ControlToValidate="DDL_SelectCollege" ErrorMessage="Select Organization" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label216" runat="server" Font-Bold="True" ForeColor="#272727" Text="Language"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:RadioButtonList ID="rbtLanguage" runat="server" CssClass="radio" OnSelectedIndexChanged="rbtGender0_SelectedIndexChanged" RepeatDirection="Horizontal" ValidationGroup="vg" Width="200px">
                                                                                <asp:ListItem Selected="True" Text="English" Value="English">
                                                                            </asp:ListItem>
                                                                                <asp:ListItem Text="Other Lang." Value="Other">
                                                                            </asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label206" runat="server" Font-Bold="True" ForeColor="#272727" Text="Gender"></asp:Label>
                                                                            <asp:Label ID="Label35" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rbtGender" ErrorMessage="Please Select Gender!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="auto-style9"  >
                                                                            <asp:RadioButtonList ID="rbtGender" runat="server" CssClass="radio" RepeatDirection="Horizontal" ValidationGroup="vg" Width="150px">
                                                                                <asp:ListItem Text="Male" Value="Male">
                                                                            </asp:ListItem>
                                                                                <asp:ListItem Text="Female" Value="Female">
                                                                            </asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="lblGrNo" runat="server" Font-Bold="True" ForeColor="#272727" Text="G.R. No."></asp:Label>
                                                                            <%-- <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtGRNo" runat="server" placeholder="GR Number" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revFirstName1" runat="server" ControlToValidate="txtGRNo" Display="Dynamic" ErrorMessage="Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="vg">*</asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtGRNo" ErrorMessage="Enter GRNO" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">&nbsp;<asp:Label ID="lblAppDate" runat="server" Font-Bold="True" ForeColor="#272727" Text="Admission Date"></asp:Label>
                                                                            <asp:Label ID="Label22" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtAdmissionDate" runat="server" placeholder="Admission Date" ValidationGroup="vg" Width="150px"></asp:TextBox>
                                                                            <asp:CalendarExtender ID="txtAppDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtAdmissionDate">
                                                                            </asp:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdmissionDate" ErrorMessage="Please Select Application Date!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#272727" Text="Adhar No"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtAdhar" runat="server" onkeypress="return isNumberKey(event)" placeholder="Adhar No" ValidationGroup="vg" Width="156px" MaxLength="12"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#272727" Text="Student Id"></asp:Label>
                                                                        </td>
                                                                        <td >
                                                                            <asp:TextBox ID="txtsaralId" runat="server" onkeypress="return isNumberKey(event)" placeholder="Student Id" ValidationGroup="vg" Width="230px"></asp:TextBox>
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#272727" Text="Course/Branch/Class"></asp:Label>
                                                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" ValidationGroup="vg" Width="245px">
                                                                                <asp:ListItem Value="0">Select Course</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select Course!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" ValidationGroup="vg" Width="245px">
                                                                                <asp:ListItem Value="0">Select Branch</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCourse0" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Select Branch!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            <asp:DropDownList ID="ddlClass" runat="server" Height="34px" ValidationGroup="vg" Width="245px">
                                                                                <asp:ListItem Value="0">Select Class</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="lblFirstName" runat="server" Font-Bold="True" ForeColor="#272727" Text="Student Name"></asp:Label>
                                                                            <asp:Label ID="Label44" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" ValidationGroup="vg" Width="230px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            <%--<asp:RegularExpressionValidator ID="revFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Enter Only Chracter!" ForeColor="Red" ValidationExpression="[a-z/A-Z]+$" ValidationGroup="vg">*</asp:RegularExpressionValidator>--%>
                                                                            <asp:TextBox ID="txtMiddleName" runat="server"  placeholder="Middle Name" ValidationGroup="vg" Width="230px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="Please Enter Middle Name!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            <%--<asp:RegularExpressionValidator ID="revMiddleName" runat="server" ControlToValidate="txtMiddleName" Display="Dynamic" ErrorMessage="Enter Only Chracter!" ForeColor="Red" ValidationExpression="[a-z/A-Z]+$" ValidationGroup="vg">*</asp:RegularExpressionValidator>--%>
                                                                            <asp:TextBox ID="txtLastName" runat="server"  placeholder="Last Name" ValidationGroup="vg" Width="230px"></asp:TextBox>
                                                                             <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            <%--<asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Only Chracter!" ForeColor="Red" ValidationExpression="[a-z/A-Z]+$" ValidationGroup="vg">*</asp:RegularExpressionValidator>--%>
                                                                             </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#272727" Text="Country"></asp:Label>
                                                                            <asp:Label ID="Label26" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Please Select Country !" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="lblDist" runat="server" Font-Bold="True" ForeColor="#272727" Text="State"></asp:Label>
                                                                            <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" Height="34px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select State</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvDist" runat="server" ControlToValidate="ddlState" ErrorMessage="Please Select State !" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label24" runat="server" Font-Bold="True" ForeColor="#272727" Text="District"></asp:Label>
                                                                            <asp:Label ID="Label25" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" Height="34px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select District</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="Please Select District !" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label209" runat="server" Font-Bold="True" ForeColor="#272727" Text="Birth Date"></asp:Label>
                                                                            <asp:Label ID="Label46" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtBirthDate" runat="server" placeholder="dd/MM/yyyy" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                            <asp:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtBirthDate">
                                                                            </asp:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Please Select Birth Date!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#272727" Text="Birth Place"></asp:Label>
                                                                            <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtBirthPlace" runat="server" placeholder="Birth Place" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvBirthPlace" runat="server" ControlToValidate="txtBirthPlace" ErrorMessage="Please Enter Birth Place!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label214" runat="server" Font-Bold="True" ForeColor="#272727" Text="City"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtCity" onkeypress="return isCharacterKey(event)" runat="server" placeholder="City/Village" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#272727" Text="Blood Group"></asp:Label>
                                                                            <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:DropDownList ID="ddlBloodGroup" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select BloodGroup</asp:ListItem>
                                                                                <asp:ListItem>A+ </asp:ListItem>
                                                                                <asp:ListItem>A-</asp:ListItem>
                                                                                <asp:ListItem>B+</asp:ListItem>
                                                                                <asp:ListItem>B-</asp:ListItem>
                                                                                <asp:ListItem>AB+</asp:ListItem>
                                                                                <asp:ListItem>AB-</asp:ListItem>
                                                                                <asp:ListItem>O+</asp:ListItem>
                                                                                <asp:ListItem>O-</asp:ListItem>
                                                                                <asp:ListItem>NA</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ControlToValidate="ddlBloodGroup" ErrorMessage="Please Select Blood Group!" ForeColor="Red" ValidationGroup="vg" InitialValue="0">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#272727" Text="Mother Tongue"></asp:Label>
                                                                            <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td align="center" class="auto-style10">
                                                                            <asp:TextBox ID="txtMotherTongue" runat="server" placeholder="Mother Tounge" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMotherTongue" ErrorMessage="Please Enter Mother Tongue!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="#272727" Text="Taluka"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtTal" runat="server" onkeypress="return isCharacterKey(event)" placeholder="Taluka" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#272727" Text="Religion"></asp:Label>
                                                                            <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:DropDownList ID="ddlReligion" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select Religion</asp:ListItem>
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
                                                                            <asp:RequiredFieldValidator ID="rfvReligion" runat="server" ControlToValidate="ddlReligion" ErrorMessage="Please Select Religion !" ForeColor="Red" ValidationGroup="vg" InitialValue="0">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#272727" Text="Nationality"></asp:Label>
                                                                            <asp:Label ID="Label20" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:DropDownList ID="ddlNationality" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="ddlNationality" ErrorMessage="Please Select Nationality !" ForeColor="Red" ValidationGroup="vg" InitialValue="0">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label212" runat="server" Font-Bold="True" ForeColor="#272727" Text="Fee Category"></asp:Label>
                                                                            <asp:Label ID="Label23" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            
                                                                            <asp:DropDownList ID="ddlFeeCategory" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Regular</asp:ListItem>
                                                                                <asp:ListItem Value="2">Exempted</asp:ListItem>
                                                                                <asp:ListItem Value="3">RTE</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCast0" runat="server" ControlToValidate="ddlFeeCategory" ErrorMessage="Please Select Fee Category!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>


                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style11" colspan="6">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="lblLastSchool" runat="server" Font-Bold="True" ForeColor="#272727" Text="Last School"></asp:Label>
                                                                            <%--<asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtLastSchool" runat="server" placeholder="Last School" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <%--<asp:Label ID="Label168" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%>
                                                                            <asp:Label ID="lblEmail" runat="server" Font-Bold="True" ForeColor="#272727" Text="Email"></asp:Label>
                                                                            <asp:Label ID="Label27" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtFatherEmail" placeholder="Email" runat="server" ValidationGroup="vg" Width="160px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFatherEmail" ErrorMessage="Please Enter Valid E-mail address" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="vg">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="lblMobileNo" runat="server" Font-Bold="True" ForeColor="#272727" Text="Mobile No."></asp:Label>
                                                                            <asp:Label ID="Label33" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtFatherMobile" placeholder="Mobile No" runat="server" onkeypress="return isNumberKey(event)" MaxLength="10" ValidationGroup="vg" Width="156px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="revFirstName3" runat="server" ControlToValidate="txtFatherMobile" Display="Dynamic" ErrorMessage="Enter 10 Digit Mobile No.!" ForeColor="Red" ValidationExpression="\d{10}" ValidationGroup="vg">*</asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="rfvFatherMobile" runat="server" ControlToValidate="txtFatherMobile" ErrorMessage="Please Enter Mobile Number" ForeColor="red" TargetControlID="txtFatherMobile" Type="Integer" ValidationExpression="^[0-9]{10}" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="#272727" Text="Address Line 1"></asp:Label>
                                                                            <asp:Label ID="Label48" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtAddress1" runat="server" placeholder="Address1" TextMode="MultiLine" style = "resize:none" ValidationGroup="vg" Width="160px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtAddress1" ErrorMessage="Please Enter Address Line1!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="Label32" runat="server" Font-Bold="True" ForeColor="#272727" Text="Address Line 2"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtAddress2" runat="server" placeholder="Address2" style = "resize:none" TextMode="MultiLine" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" ForeColor="#272727" Text="Caste"></asp:Label>
                                                                            <asp:Label ID="Label213" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            
                                                                            <asp:DropDownList ID="ddlCaste" runat="server" Height="34px" ValidationGroup="vg" Width="170px">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="rfvCast" runat="server" ControlToValidate="ddlCaste" ErrorMessage="Please Select Caste Category!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Label ID="lblFather" runat="server" Font-Bold="True" ForeColor="#272727" Text="Father Name"></asp:Label>
                                                                            <asp:Label ID="Label29" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtFather"  runat="server" placeholder="Father Name" ValidationGroup="vg" Width="160px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvFather" runat="server" ControlToValidate="txtFather" ErrorMessage="Please mention Father Name!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" ForeColor="#272727" Text="Mother Name"></asp:Label>
                                                                            <asp:Label ID="Label34" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtMother"  runat="server" placeholder="Mother Name" ValidationGroup="vg" Width="160px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMother" ErrorMessage="Please mention Mother Name!" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        <td align="center" class="input-medium">
                                                                            <asp:Label ID="Label215" runat="server" Font-Bold="True" ForeColor="#272727" Text="SubCaste"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtSubcaste" runat="server" placeholder="Sub-Caste"  Width="160px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            &nbsp;</td>
                                                                        <td class="auto-style17">
                                                                            <asp:TextBox ID="txtFatherOccu" runat="server" Width="160px" Visible="False"></asp:TextBox>
                                                                        </td>
                                                                        <td class="input-medium">
                                                                            <asp:Label ID="lblAppNo" runat="server" Font-Bold="True" ForeColor="#272727" Text="Application No." Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style10">
                                                                            <asp:TextBox ID="txtFormNo" runat="server" ReadOnly="true" ValidationGroup="vg" Visible="False" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center" class="input-medium">&nbsp;</td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtMotherEdu" runat="server" Visible="False" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style16">&nbsp; </td>
                                                                        <td class="auto-style18">
                                                                            <asp:TextBox ID="txtMotherOccu" runat="server" Visible="False" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="auto-style13">&nbsp; </td>
                                                                        <td class="auto-style14">
                                                                            <asp:TextBox ID="txtMotherMobile" runat="server" MaxLength="10" ValidationGroup="vg" Visible="False" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center" class="auto-style13">&nbsp;</td>
                                                                        <td class="auto-style12">
                                                                            <asp:TextBox ID="txtMotherEmail" runat="server" ValidationGroup="vg" Visible="False" Width="160px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">&nbsp; 
                                                                            <asp:Label ID="Label156" runat="server" Font-Bold="True" ForeColor="#272727" Text="Upload Photo(.jpg)"></asp:Label>
                                                                            <asp:Label ID="Label36" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style17">
                                                                          <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                            <asp:FileUpload ID="fileupload_StudentPhoto" runat="server" Height="29px" />
                                                                                     <asp:Button ID="btnUploadPhoto" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnUploadPhoto_Click" Text="Upload" />
                                                                               </ContentTemplate></asp:UpdatePanel>     
                                                                        </td>
                                                                        <td colspan="3"  style="color:red">
                                                                            <br />
                                                                            Upload image only with <%--minimum size of 5KB or--%>maximum size of 1MB 
                                                                            <%--<asp:Label ID="lblFileuploadError" runat="server" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>--%>
                                                                            <%--<asp:TextBox ID="txtFatherEdu" runat="server" placeholder="Father Education" Visible="False" Width="160px"></asp:TextBox>--%>
                                                                        </td>
                                                                        <td class="auto-style9">
                                                                            <asp:TextBox ID="txtFatherEdu" runat="server" placeholder="Father Education" Visible="False" Width="160px"></asp:TextBox>
                                                                            
                                                                            <asp:Label ID="lblFileuploadError" runat="server" ForeColor="#FF3300" Text="*" Visible="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            
                                                                                   
                                                                               
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <br />
                                                                        </td>
                                                                        <td align="justify" class="auto-style10">
                                                                            <br />
                                                                        </td>
                                                                        <td align="center" class="input-medium">&nbsp;</td>
                                                                        <td align="justify" class="auto-style9">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15"></td>
                                                                        <td class="auto-style17">
                                                                            <asp:Label ID="Label1" runat="server" Text="Select Document"></asp:Label>
                                                                            <asp:Label ID="Label37" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                                        </td>
                                                                        <td class="input-medium"></td>
                                                                        <td class="auto-style10"></td>
                                                                        <td align="center" class="input-medium">&nbsp;</td>
                                                                        <td class="auto-style9">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style15">
                                                                            <asp:Image ID="img_StudentImage" runat="server" Height="100px" ImageUrl="~/images/userphoto.gif" Width="100px" />
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <div style="max-height: 500px; overflow: auto;">
                                                                                <asp:GridView ID="GrdDocumnet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="DocumentId" Width="98%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="checkbox" runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Document Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblDocumentId" runat="server" Text='<%#Eval("DocumentId")%>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="DocumentName" HeaderText="Document Name" ItemStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="DocumentType" HeaderText="Document Type" ItemStyle-HorizontalAlign="Center" />
                                                                                    </Columns>
                                                                                    <EditRowStyle BorderStyle="Groove" />
                                                                                    <EditRowStyle BorderStyle="None" />
                                                                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                                                                    <EmptyDataTemplate>
                                                                                        No Data Found.
                                                                                    </EmptyDataTemplate>
                                                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                                    <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                                                    <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                                                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                        <td align="center" class="input-medium">&nbsp;</td>
                                                                        <td>
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vg" ShowMessageBox="True" ShowSummary="False" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" onclick="btnNew_Click" Text="New form" />
                                                                <asp:Button ID="Button1" runat="server" CausesValidation="false" class="btn btn-primary" OnClientClick="return printpage()" Text="Print" Visible="false" />
                                                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="vg" />
                                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                   
                                                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                                                       
                                                    <div class="" style="display:none">
                                                        <asp:Panel ID="pnl" runat="server">
                                                            <table align="center" border="0" cellspacing="2px" width="80%">
                                                                <tr>
                                                                    <td>
                                                                        <table align="center" width="800px">
                                                                            <tr>
                                                                                <td class="auto-style2">
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style1">
                                                                                    <br />
                                                                                </td>
                                                                                <td class="auto-style4">
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <asp:Image ID="Image1" runat="server" align="right" Height="125px" ImageUrl="~/images/userphoto.gif" Width="155px" />
                                                                                <caption>
                                                                                    <br />
                                                                                </caption>
                                                                            </tr>
                                                                            <%--<tr>
                                                                                <td class="auto-style3"></td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label41" runat="server" Text="Application No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6" style="text-align:left">
                                                                                    <asp:Label ID="lblapplicationno" runat="server" Text="Application No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label43" runat="server" Text="Date"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7"></td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label52" runat="server" Text="G.R. No."></asp:Label>
                                                                                    <%-- <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblgrno1" runat="server" style="text-align: left; float: left" Text="G.R. No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label53" runat="server" Text="Adhar No"></asp:Label>
                                                                                    <%-- <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                                <td>
                                                                                    <asp:Label ID="lbladharno" runat="server" Text="Adhar No"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6"></td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label54" runat="server" Text="First Name"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblfirstname1" runat="server" Text="First Name"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label56" runat="server" Text="Middle Name"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblmiddlename1" runat="server" Text="Middle Name"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7"></td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label57" runat="server" Text="Last name"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbllastname1" runat="server" Text="Last name"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label59" runat="server" Text="Course Applied For"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblcourseappliedfor1" runat="server" Text="Course Applied For"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label61" runat="server" Text="Branch"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblbranch1" runat="server" Text="Branch"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7"></td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label63" runat="server" Text="Class"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblclass1" runat="server" Text="Class"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label65" runat="server" Text="Birth Date"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblbirthdate1" runat="server" Text="Birth Date"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label67" runat="server" Text="Birth Place"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblbirthplace1" runat="server" Text="Birth Place"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label69" runat="server" Text="Country"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblcountry1" runat="server" Text="Country"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label71" runat="server" Text="State"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblstate1" runat="server" Text="State"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label73" runat="server" Text="District"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbldistrict1" runat="server" Text="District"></asp:Label>
                                                                                </td>
                                                                                <%--</div>--%>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label75" runat="server" Text="Tal"></asp:Label>
                                                                                    <%--<asp:Label ID="Label22" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                                <td>
                                                                                    <asp:Label ID="lbltal1" runat="server" Text="Tal"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTal"
                                                                            ErrorMessage="Please Enter Tal!" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>--%></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label76" runat="server" Text="Last School"></asp:Label>
                                                                                    <%--<asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbllaschool1" runat="server" Text="Last School"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label77" runat="server" Text="Gender"></asp:Label>
                                                                                    <%--<asp:Label ID="Label168" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblgender1" runat="server" Text="Gender"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6"></td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label79" runat="server" Text="Blood Group"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblbloodgroup1" runat="server" Text="Blood Group"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label81" runat="server" Text="Religion"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblreligion1" runat="server" Text="Religion"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label83" runat="server" Text="Mother Tongue"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblmothertounge1" runat="server" Text="Mother Tongue"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label85" runat="server" Text="Nationality"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblnatioality1" runat="server" Text="Nationality"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label87" runat="server" Text="Address Line 1"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbladdressline11" runat="server" Text="Address Line 1"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label89" runat="server" Text="Address Line 2"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lbladdressline21" runat="server" Text="Address Line 2"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp; </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label90" runat="server" Text="Caste Category"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblcastecategory1" runat="server" Text="Caste Category"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label92" runat="server" Text="Fee Category"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblfeecategory1" runat="server" Text="Fee Category"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label94" runat="server" Text="Name Of Father"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblnameffather1" runat="server" Text="Name Of Father"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label96" runat="server" Text="Education"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lbleduction11" runat="server" Text="Education"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label97" runat="server" Text="Occupation"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbloccupation11" runat="server" Text="Occupation"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6"></td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label99" runat="server" Text="Mobile No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblmobileno11" runat="server" Text="Mobile No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label101" runat="server" Text="Email"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblemail11" runat="server" Text="Email"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label103" runat="server" Text="Name Of Mother"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblnameofmother1" runat="server" Text="Name Of Mother"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label105" runat="server" Text="Education"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lbleducation12" runat="server" Text="Education"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label106" runat="server" Text="Occupation"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lbloccupation12" runat="server" Text="Occupation"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6"></td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">
                                                                                    <asp:Label ID="Label108" runat="server" Text="Mobile No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblmobileno12" runat="server" Text="Mobile No."></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style7">
                                                                                    <asp:Label ID="Label110" runat="server" Text="Email"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblemail12" runat="server" Text="Email"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp;</td>
                                                                                <td class="auto-style7">&nbsp; </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3">&nbsp; </td>
                                                                                <td class="auto-style6">&nbsp; </td>
                                                                                <td class="auto-style7">&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style3"></td>
                                                                                <td class="auto-style6"></td>
                                                                                <td class="auto-style7"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </table>
                                                                  </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                 
                                        </div>
       
                                        <%-- <div class="" style="display:none ;">--%>
                                   </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUploadPhoto">
                                                    </asp:PostBackTrigger>
                                                     <asp:PostBackTrigger ControlID="DDL_SelectCollege">
                                                    </asp:PostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
