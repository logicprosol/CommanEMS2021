<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recoverpasword.aspx.cs" Inherits="Forms.recoverpasword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<!DOCTYPE HTML>
<html>
<head>
<title>College Management System</title>
<link href="resetstyle.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
<meta name="keywords" content="Reset Password Form Responsive, Login form web template, Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<!--google fonts-->
        <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href='http://localhost:7308/fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900' rel='stylesheet' type='text/css'>
</head>
<body>
    <div class="elelment">
	    <h2>sword Form</h2>
	<div class="element-main">
		<h1>Forgot Password</h1>
		<p>.</p>
		
	
      
		
		<form id="newform" runat="server">
            	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
           <center>
            <asp:DropDownList ID="ddlorg" runat="server" AutoPostBack="true"  ></asp:DropDownList>
            <br />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Organization..!" ControlToValidate="ddlorg" InitialValue="Select Organisation"></asp:RequiredFieldValidator>

            <br />
            <br />
                 <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true" >
                           <asp:ListItem Text="Select Role " Value="0"></asp:ListItem>
                             <asp:ListItem Text="Trustee" Value="Trustee"></asp:ListItem>
                           <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                           <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                           <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                           <asp:ListItem Text="HR" Value="HR"></asp:ListItem>
                           <asp:ListItem Text="Inventor" Value="Inventor"></asp:ListItem>
                           <asp:ListItem Text="Librarian" Value="Librarian"></asp:ListItem>
                 </asp:DropDownList>
               <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Role...!" ControlToValidate="DropDownList1" InitialValue="0"></asp:RequiredFieldValidator>

               <br />
               <br />

            <asp:TextBox ID="txtusername" Width="200px" runat="server" ForeColor="Black" placeholder="Enter Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Username...!" ControlToValidate="txtusername"></asp:RequiredFieldValidator>


		 <br />
            
            <br />
            <asp:Button ID="Button1" runat="server" CssClass="btn-danger" Text="Send" OnClick="Button1_Click" />
            &nbsp;
                           <asp:Button ID="Button2" runat="server" CssClass="btn-danger" Text="Cancel" OnClick="Button2_Click" CausesValidation="False" />
            
            </center>
                        </ContentTemplate>
                </asp:UpdatePanel>
               <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            		</form>
	</div>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <a href="http://www.logicprosol.com" style="color:red">All Rights Reserved 2017 @ LogicPro Solutions
<!--element end here-->
</div>
</body>
</html>
