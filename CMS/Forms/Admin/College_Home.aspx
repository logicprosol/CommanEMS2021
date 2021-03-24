<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/College_Home.Master"
    AutoEventWireup="true" CodeBehind="College_Home.aspx.cs" Inherits="CMS.Forms.Admin.College_Home" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link src="../../js/bootstrap-tab.js" type="text/javascript"/>

   
    <!--Start of Tawk.to Script-->
<script type="text/javascript">
    var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
    (function () {
        var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
        s1.async = true;
        //s1.src = 'https://embed.tawk.to/5ae031b45f7cdf4f0533978e/1cbtvpt7e';
          s1.src='https://embed.tawk.to/5c287cd582491369ba9fec5b/default';
        s1.charset = 'UTF-8';
        s1.setAttribute('crossorigin', '*');
        s0.parentNode.insertBefore(s1, s0);
    })();
    </script>
       
<!--End of Tawk.to Script-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="width: 100%; background-repeat: repeat; height: 262px; margin-left: 0px;">
            <tr>
                <td>
                    <div style="margin-left: 10px; margin-top: 15px">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:Timer ID="Timer1" runat="server" Interval="1200" OnTick="Timer1_Tick">
                                    </asp:Timer>
 <asp:Label ID="lblOTP" runat="server" Text="Label" Visible="False"></asp:Label>
                                        <asp:Label ID="lblOTPNumber" runat="server" Text="Label" Visible="False"></asp:Label>
                                       
                                    <asp:Image ID="ImageSlider" runat="server" Width="740px" Height="300px" />
                                    <asp:DropShadowExtender ID="ImageSlider_DropShadowExtender" runat="server" Enabled="True"
                                        TargetControlID="ImageSlider">
                                    </asp:DropShadowExtender>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                    <td >
                        <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/images/Blurred-Background_11.jpg" DefaultButton="BtnLogin">
                            <div style="background: rgba(0,0,0,0.3); background-repeat: repeat; background-image: url('../../images/SelectCollegeBack.jpg');"><%--width: 350px;--%>
                                <table width="350px" style="height: 300px">
                                    <tr>
                                        <td style="font-size: 30px; font-style: normal; color: #FFFFFF;" align="center">
                                            Login
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDL_SelectAuthority" runat="server" Height="26px" Width="180px">
                                                        <asp:ListItem Text="Login As" Value="0"></asp:ListItem>                                                       
                                                        <asp:ListItem Text="Trustee" Value="trustee"></asp:ListItem>
                                                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                                        <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                                        <asp:ListItem Text="HR" Value="HR"></asp:ListItem>
                                                        <asp:ListItem Text="Inventor" Value="Inventor"></asp:ListItem>
                                                        <asp:ListItem Text="Librarian" Value="Librarian"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                          <%-- <asp:CheckBox ID="chkbox" OnCheckedChanged="chkboxSelectAll_CheckedChanged" AutoPostBack="true" runat="server"/>--%>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                             <p> <a href="../recoverpasword.aspx"/ style="color:white"> Forgot Password </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lbl_Error" runat="server" Visible="false" ForeColor="Red" Text="Please Enter Correct User Name Password"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        
                                            <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary" Text="Sign in" OnClick="BtnLogin_Click" />
                                           
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:DropShadowExtender ID="DropShadowExtender1" runat="server" Enabled="True" TargetControlID="Panel2">
                            </asp:DropShadowExtender>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <!--   Future contents-->
        <div id="futute_contents" style="margin: 15px; margin-left: 100px">
            <table>
                <tr>
                    <td valign="middle">
                        <div style="background-image: url('Images/welcome1.jpg'); background-repeat: no-repeat;
                            height: 450px; width: 250px;">
                            <table style="border: medium double #8A084B">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="../../images/Admission_Open_2.png" alt="Admission" style="height: 200px;
                                            width: 220px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(../../images/H2.png);
                                            height: 200px; width: 220px;">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>NEW ADMISSIONS</b>
                                                <br />
                                                <br />
                                                <a href="../../AdmissionProcessForm.aspx">Click Here for Online Admission </a>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <div style="background-image: url('images/back1.jpg'); background-repeat: no-repeat;
                            height: 450px; width: 250px;">
                            <table style="border: medium double#00CC99">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="../../images/Newsevents_top_2.png" alt="News" style="height: 200px; width: 220px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(../../images/H1.png);
                                            height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>NEWS AND EVENTS</b>
                                                <br />
                                                <br />
                                                Click Here To Read More
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <div style="background-image: url('Images/welcome1.jpg'); background-repeat: no-repeat;
                            height: 450px; width: 250px;">
                            <table style="border: medium double #FF4000">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #FF4000; font-size: large;"
                                        align="center">
                                        <img src="../../images/campustour_top_2.png" alt="campustour" style="height: 200px;
                                            width: 220px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(../../images/H3.png);
                                            height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>CAMPUS TOUR</b>
                                                <br />
                                                <br />
                                                <a href="">Click Here To Read More</a>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td valign="middle">
                        <div style="background-repeat: no-repeat; height: 450px; width: 312px;">
                            <table style="border: medium double #8A084B">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="../../images/photogallery_top_2.png" alt="Photogalary" style="height: 200px;
                                            width: 220px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(../../images/H4.png);
                                            height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>PHOTO GALARY</b>
                                                <br />
                                                <br />
                                                <a href="">Click Here To Read More</a>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </div>
    </div>
</asp:Content>