 <%@ Page Title="" Language="C#" MasterPageFile="~/CMS_Home.Master" AutoEventWireup="true" CodeBehind="CMSHome.aspx.cs" Inherits="CMS.Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />

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

   <%--   <script src="https://www.google.com/jsapi" type="text/javascript">
    </script>
    <script language="javascript" type="text/javascript">
        google.load("elements", "1", { packages: "transliteration" });

        function onLoad() {
            var options = {
                //Source for  Language
                sourceLanguage: google.elements.transliteration.LanguageCode.ENGLISH,
                // Destination language to Transliterate
                destinationLanguage: [google.elements.transliteration.LanguageCode.HINDI],
                shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            var control = new google.elements.transliteration.TransliterationControl(options);
            //control.makeTransliteratable(['abc']); // for .aspx page
            control.makeTransliteratable(['<%=abc.ClientID%>']); //for Master page use

        }
        google.setOnLoadCallback(onLoad);
</script>--%>






     <style type="text/css">
         .auto-style2 {
             height: 461px;
             width: 250px;
         }
     </style>






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="width: 100%; background-repeat: repeat; height: 262px; margin-left: 0px;">
            <tr>
                <td>
                    <div style="margin-left: 10px; margin-top: 15px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:Timer ID="Timer1" runat="server" Interval="1200" OnTick="Timer1_Tick">
                                    </asp:Timer>
                                    <asp:Image ID="ImageSlider" runat="server" Width="740px" Height="300px" />
                                    <asp:DropShadowExtender ID="ImageSlider_DropShadowExtender" runat="server" Enabled="True"
                                        TargetControlID="ImageSlider">
                                    </asp:DropShadowExtender>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>



<%--                <asp:TextBox ID="abc" runat="server"></asp:TextBox> --%>
                <td>
                  <asp:Panel ID="P1" runat="server" DefaultButton="BtnSubmit">
                    <div style="background: rgba(15, 12, 41,0.8); background-repeat: repeat; ;
                        margin-top: 15px; background-image: url('images/SelectCollegeBack.jpg');"><%--background-image: url('Images/SelectCollegeBack.jpg')--%>
                      
                        <table style="width: 300px; height: 300px">
                            <tr>
                                <td style="font-size: 22px; font-style: normal; color: #FFFFFF;" align="center">
                                    Select College/School</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DropDownList ID="DDL_SelectCollege" runat="server" Width="180px" class="form"
                                        placeholder="Select College">
                                        <asp:ListItem Text="Select College" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                </td>
                            </tr>
                           <%-- <tr>
                                        <td align="center">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
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
                                    </tr>--%>
                                    <tr>
                                         <td align="center">
                                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" PostBackUrl="Forms/Admin/frmStudentEnquiry.aspx">Click Here for Enquiry Form</asp:LinkButton>
                                            <br />
                                            <asp:TextBox ID="TextBox1" runat="server" placeholder="User Name" Visible="False"></asp:TextBox>
                                        </td>
                                      
                                    </tr>
                            <tr>
                                  <td align="center">
                                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" ForeColor="Blue" PostBackUrl="~/AdmissionProcessForm.aspx">Click Here for Admission Form</asp:LinkButton>
                                            <br />
                                            <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" Visible="False"></asp:TextBox>
                                        </td>
                            </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                             <p> <%--<a href="../Forms/recoverpasword.aspx" style="color:white"> Forget Password --%>
                                             </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        
                                            <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary" Text="Sign in" OnClick="BtnLogin_Click" Visible="False" />
                                           
                                        </td>
                                    </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblError" runat="server" Text="Please Select Your College" ForeColor="Red"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_Error" runat="server" ForeColor="Red" Text="Check credentials" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />

                                </td>
                            </tr>
                        </table>
                        </div>
                         </asp:Panel>
                    <%--<ucmsgbox:msgbox ID="msgBox" runat="server" />--%>
                </td>
            </tr>
        </table>
        <!--   Future contents-->
        <br />
        <br /><div style="font-family: verdana; font-weight: bold; color: #FF4000; font-size: large;"
                                        align="center">
                <marquee direction="right"> Pocket School App Installation Steps:</marquee></div>
        <br />
      <div id="futute_contents" style="margin: 15px;">
           
            <table>
                <tr>
                    <td valign="middle">
                        <div style="background-image: url('Images/welcome1.jpg'); background-repeat: no-repeat;
                            height: 461px; width: 250px;">
                            <table style="border: medium double #8A084B">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="images/Screenshot_2019-02-08-15-01-33.png" alt="Admission" style="height: 400px; width: 220px" />
                                  
                                        <%--<div style="font-family: verdana; color: #FFFFFF; font-size: large; 
                                            background-color: #173566; height: 201px; width: 220px;">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>NEW ADMISSIONS OPEN </b>
                                                <br />
                                                <br />
                                               
                                            </p>
                                        </div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <div style="background-image: url('images/back1.jpg'); background-repeat: no-repeat;
                            " class="auto-style2">
                            <table style="border: medium double#00CC99">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="images/Screenshot_2019-02-08-18-00-27.png" alt="News" style="height: 400px; width: 220px" />
                                
                                       <%-- <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(~/images/H1.png);
                                            background-color: #8e5419 ; height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>NEWS AND EVENTS</b>
                                                <br />
                                                <br />
                                                Click Here to Read More
                                            </p>
                                        </div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%-- <td>
                        <div style="background-image: url('images/back1.jpg'); background-repeat: no-repeat;
                            " class="auto-style2">
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
                                                <a href="../Forms/Admin/AdmissionForm3.aspx">Click Here for Online Admission </a>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>--%>
                    <td style="width:400px">
                        <div style="background-image: url('Images/welcome1.jpg'); background-repeat: no-repeat;
                            height: 461px; width: 400px;">
                            <table>
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #FF4000; font-size: large;"
                                        align="center">
                                        <%--<marquee direction="right"> Pocket School App Installation Steps:</marquee>--%>
                                       
                                       
                                        <p style="color:black; font-size:small;text-align:justify;font-weight:bold">
                                        No special instruction are required for the installation. Very easy three step roll out process.
                                            </p>
                                        <p style="color:black; font-size:small;text-align:justify; font-weight: normal">
                                            <%--<marquee direction="alternate" behavior="alternate" scrollamount="1">--%>
                                            All the parents or teachers have to do is:
                                            <br /><br />
                                           <b>1.</b>Install the Pocket School on Android mobile/tablet via the official Play Store.<br /><br />
                                           <b>2.</b><%--Select Student-Login / Faculty-Login.<br /><br />--%>
                                           <%--<b>3.</b>--%>Enter <span style="font-weight:bold">UserId</span> and <span style="font-weight:bold"> Password </span>Received on your Registered Mail at School or 
                                            provided by school.<br /><br />
                                            ...and done! This is a one-time process if you checked the option Remember Me.<br />

                                           <%-- </marquee>--%>
                                        </p>

                                      <%--  <img src="images/campustour_top_2.png" alt="campustour" style="height: 200px; width: 220px" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                       <%-- <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(~/images/H3.png);
                                            background-color: #44c9ce; height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>CAMPUS TOUR</b>
                                                <br />
                                                <br />
                                                <a href="">Click Here to Read More</a>
                                            </p>
                                        </div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                 <%--   <td valign="middle">
                        <div style="background-repeat: no-repeat; height: 450px; width: 312px;">
                            <table style="border: medium double #8A084B">
                                <tr>
                                    <td style="font-family: verdana; font-weight: bold; color: #F7FE2E; font-size: large;"
                                        align="center">
                                        <img src="images/photogallery_top_2.png" alt="Photogalary" style="height: 200px;
                                            width: 220px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div style="font-family: verdana; color: #FFFFFF; font-size: large; background-image: url(~/images/H4.png);
                                            background-color: #a178bc ; height: 200px; width: 220px">
                                            <p style="color: White; font-size: 12px">
                                                <br />
                                                <br />
                                                <b>PHOTO GALLERY</b>
                                                <br />
                                                <br />
                                                <a href="">Click Here to Read More</a>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>--%>
                </tr>
            </table>
        </div>
         
    </div>
     <asp:Label ID="lblOTP" runat="server" Text="Label" Visible="False"></asp:Label>
                                        <asp:Label ID="lblOTPNumber" runat="server" Text="Label" Visible="False"></asp:Label>
    
</asp:Content>