<%@ Page Title="" Language="C#" MasterPageFile="~/CMS_Home.Master" AutoEventWireup="true"
    CodeBehind="ErrorPage.aspx.cs" Inherits="CMS.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="width: 985px; background-repeat: repeat; height: auto; margin-left: 0px;">
            <tr>
                <td style="height: 100%;">
                    <table width="100%" style="border: medium double #33CCFF; height: 450px;">
                        <tr>
                            <td colspan="2" style="height: 10%">
                                <center>
                                        <asp:Label ID="lblHeader" runat="server" Text="Error On Page" Font-Size="X-Large"></asp:Label>
                                    </center>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 70%">
                                <center>
                                        <div>
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Error.png" height="250px" Width="250px" />
                                        </div>
                                    </center>
                            </td>
                            <td>
                                <center>
                                        Something Wrong Happen With Website. Please try again...
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="lbtnHome" runat="server" onclick="lbtnHome_Click">Goto Home Page...</asp:LinkButton>
                                    </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 30%">
                                <center>
                                        <br />
                                        <br />
                                    </center>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>