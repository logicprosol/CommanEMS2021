<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Library/Library.Master" AutoEventWireup="true"
    CodeBehind="Library_Home.aspx.cs" Inherits="CMS.Forms.Library.Library_Home" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;">
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>WelCome To College Management Systems </li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Width="800px" Height="860px">
            <table border="0" width="100%"  cellspacing="2px">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                     <td align="center">
                        <img src="../../images/Library.jpg" alt="Add Book Groups" height="150px"
                            width="150px" />
                    </td>
                    <td align="center" style="height: 150px">
                        <img src="../../images/BankBook.jpg" alt="Add Books" />
                    </td>
                   
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAddBookGroup" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnAddBookGroup_Click">Add Book Group</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnAddBooks" runat="server" class=" btn btn-primary" style="background: linear-gradient( #82191D, #221E1B );" 
                            ForeColor="White" onclick="lbtnAddBooks_Click"
                          >Add Books</asp:LinkButton>
                    </td>
                    
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/Program Excutive.jpg" alt="Issue Books" height="150px"
                            width="150px" />
                    </td>
                    <td style="" align="center">
                        <img src="../../images/return-book.png" alt="Issue Books" height="70px"
                            width="150px" />
                    </td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnIssueBooks" runat="server" class=" btn btn-primary" ForeColor="White" onclick="lbtnIssueBooks_Click" style="background: linear-gradient( #82191D, #221E1B );">Issue Books</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnIssueBooks0" runat="server" class=" btn btn-primary" ForeColor="White" onclick="lbtnIssueBooks0_Click" style="background: linear-gradient( #82191D, #221E1B );">Return Books</asp:LinkButton>
                    </td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
      <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
