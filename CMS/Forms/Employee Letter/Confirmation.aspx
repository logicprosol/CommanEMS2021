<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="CMS.Forms.Employee_Letter.Confirmation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', '');
            printWindow.document.write('<html><head><title>Confirmation Letter</title>');
            printWindow.document.write('<style type="text/css">@page{size: auto;margin-top:20mm;margin-bottom:20mm;}</style>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
       
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th colspan="4" style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li>Confirmation Letter</li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel_Staff" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>

                <div align="center" style="width:100%" >
                    <asp:Panel ID="pnlContents" runat="server" HorizontalAlign="Left" width="80%" >
                        <div style="margin-left:8%;margin-right:5%;font-family:Arial;">

                            <table width="100%">
                                <tr align="center">
                                    <td><asp:Label ID="label1" runat="server" text="SHRI SANT GOROBA SHIKSHAN SANSTHA" Font-Bold="True" Font-Size="16px"></asp:Label></td>
                                </tr>
                                <tr align="center">
                                    <td><asp:Label ID="label2" runat="server" text="VIMAN NAGAR DIST.PUNE-410014" Font-Bold="True" Font-Size="12px"></asp:Label></td>
                                </tr>
                            </table>

                            <table width="85%" style="margin-top:15px; font-size:12px;">
                                <tr>
                                    <td><asp:Label ID="label3" runat="server" text="REF.NO. : SSGSS/ADM/" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="TxtCYear" runat="server" Font-Bold="True" text="2015-2016"></asp:Label>
                                        <asp:Label ID="label21" runat="server" Font-Bold="True" text="/"></asp:Label>
                                        <asp:Label ID="TxtCSrno" runat="server" Font-Bold="True" text="1"></asp:Label>
                                    </td>
                                
                                    <td align="right"><asp:Label ID="label4" runat="server" text="DATE : " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="TxtCDate" runat="server" Font-Bold="True" text="28 /05/2016"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                            <table width="100%" style="margin-top:25px; font-size:12px;">
                                <tr>
                                    <td><asp:Label ID="label5" runat="server" text="To," Font-Bold="True"></asp:Label></td>
                                </tr>
                            </table>

                            <div align="left">
                            <table width="35%" style="margin-top:25px;font-size:13px;">
                                <tr>
                                    <td><asp:Label ID="TxtCName" runat="server" text="Mrs Mamta Upendra Yadav" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="TxtCAddress" runat="server" text="Survey No 36, Yashwant Nagar," Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="TxtCAddress1" runat="server" text="Kharadi-Chandannagar." Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="TxtCAddress2" runat="server" text="Pune -410014" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="label10" runat="server" text="Mob : " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="TxtCmn" runat="server" Font-Bold="True" text="9156882698"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            </div>

                            <table width="100%" style="margin-top:30px;">
                                <tr align="center">
                                    <td><asp:Label ID="label11" runat="server" text="CONFIRMATION OF APPOINTMENT" Font-Bold="True" Font-Size="17px" Font-Underline="True" Font-Italic="True"></asp:Label></td>
                                </tr>
                            </table>

                            <table width="100%" style="font-size:15px;margin-top:25px;">
                                <tr>
                                    <td><asp:Label ID="label16" runat="server" text="Dear Madam ," Font-Bold="True"></asp:Label></td>
                                </tr>
                            </table>

                            <table width="100%" style="font-size:15px;margin-top:12px;">
                                <tr>
                                    <td ><p style="line-height:30px;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Consequent to completion of your probation period of one year , your appointment as ‘
                                        <asp:Label ID="TxtCDesg" runat="server" Font-Bold="True" text="TGT"></asp:Label>
                                        &nbsp;’ is hereby confirmed as on
                                        <asp:Label ID="TxtCJoinDate" runat="server" Font-Bold="True" text="31/05/2016"></asp:Label>
                                        &nbsp;</b></p></td>
                                </tr>
                            </table>
                            
                            <table width="85%" style="font-size:16px;margin-top:100px;">
                                <tr>
                                    <td align="right"><asp:Label ID="label15" runat="server" text="SECRETARY" Font-Bold="True"></asp:Label></td>
                                </tr>
                            </table>
                            
                            <table width="100%" style="font-size:14px;margin-top:15px;">
                                <tr>
                                    <td><asp:Label ID="label12" runat="server" text="C.C. to" Font-Bold="True" Font-Underline="True"></asp:Label></td>
                                </tr>
                            </table>

                            <table width="100%" style="font-size:14px;margin-top:8px;">
                                <tr>
                                    <td><asp:Label ID="label13" runat="server" text="The Principal," Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="label14" runat="server" text="Hind English Medium School, Gurukool" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="label19" runat="server" text="Viman Nagar, Pune" Font-Bold="True"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>

                    <br /><br />
                    <asp:Button ID="btnPrint" runat="server" Text="Print" class=" btn btn-info" OnClientClick="return PrintPanel();"  />
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    </form>

</asp:Content>
