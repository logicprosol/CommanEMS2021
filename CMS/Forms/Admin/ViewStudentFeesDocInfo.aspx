<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewStudentFeesDocInfo.aspx.cs" Inherits="CMS.Forms.Admin.ViewStudentFeesDocInfo" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .style2
            {
                width: 234px;
            }
            .style3
            {
                width: 110px;
            }
            .auto-style4 {
                width: 14px;
            }
            .auto-style5 {
                font-size: 11.844px;
                font-weight: bold;
                line-height: 14px;
                color: #fff;
                text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
                white-space: nowrap;
                vertical-align: baseline;
                -webkit-border-radius: 9px;
                -moz-border-radius: 9px;
                border-radius: 9px;
                width: 607px;
                padding-left: 9px;
                padding-right: 9px;
                padding-top: 1px;
                padding-bottom: 2px;
                background-color: #999;
            }
            .auto-style8 {
                width: 181px;
            }
            .auto-style9 {
                width: 98px
            }
            .auto-style10 {
                width: 182px;
            }
            .auto-style12 {
                width: 13px;
            }
            .auto-style13 {
                width: 410px;
                margin-top: 56px;
            }
        </style>


    <script type = "text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you wants to Delete Fees Receipt?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmUpdate() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }    </script>

     <script type="text/javascript">
                    function printpage() {

               var getpanel = document.getElementById("<%= pnlContents.ClientID%>");
                var MainWindow = window.open('', '', 'height=500,width=800');
                MainWindow.document.write('<html><head><title>Print Page</title>');
                MainWindow.document.write('</head><body>');
                MainWindow.document.write(getpanel.innerHTML);
                MainWindow.document.write('</body></html>');
                MainWindow.document.close();
                setTimeout(function () {
                    MainWindow.print();
                    MessagePopUp.close();
                }, 500);
                return false;

            }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
     
     
           <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height:1050px; width: 920px;">
                <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height:1050px; width: 920px;
                    border: medium double#0C7BFA;">
                    <table align="center" style="height: 30px; width: 100%;">
                        <tr style="background-color: #0C7BFA; color: White" align="center">
                            <td></td>
                            <td >
                                <ul class="nav nav-list">
                                    <li>Student Fees Document Information</li>
                                </ul>
                            </td>
                            <td></td>
                        </tr>
                        <tr align="center" >
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td>&nbsp;</td>
                            <td>
                                <table class="auto-style5">
                                    <tr>
                                        <td align="right" class="auto-style4">
                                            &nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td class="auto-style8">
                                            &nbsp;</td>
                                        <td align="left" class="auto-style9">
                                            &nbsp;</td>
                                        <td class="auto-style10">
                                            &nbsp;</td>
                                        <td class="auto-style12">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">&nbsp;</td>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" Text="Student Code"></asp:Label>
                                        </td>
                                        <td valign="middle">
                                            <asp:TextBox ID="txtStudentId" runat="server" Width="170px"></asp:TextBox>
                                        </td>
                                        <td align="left" class="auto-style9" valign="top">
                                            <asp:Button ID="btnGO" runat="server" class="btn btn-primary" onclick="btnGO_Click" Text="GO" ValidationGroup="Go" />
                                        </td>
                                        <td class="auto-style10">
                                            <asp:RequiredFieldValidator ID="rfvCountryId" runat="server" ControlToValidate="txtStudentId" Display="Dynamic" ErrorMessage="Please Enter Student Code" ForeColor="red" TargetControlID="txtCountryId" ValidationGroup="Go"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style12">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">
                                            &nbsp;</td>
                                        <td align="right">
                                            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:TextBox ID="txtName" runat="server" Enabled="False" ></asp:TextBox>
                                        </td>
                                        <td align="right" class="auto-style9">
                                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="txtAddress" runat="server" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="auto-style12">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">
                                            &nbsp;</td>
                                        <td align="right">
                                            <asp:Label ID="lblParrentNo" runat="server" Text="Parent No. "></asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:TextBox ID="txtParrentNo" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" class="auto-style9">
                                            <asp:Label ID="lblAdmissionDate" runat="server" Text="Admission Date"></asp:Label>
                                        </td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="txtAdmissionDate" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td class="auto-style12">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style4">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td align="right" class="auto-style9">&nbsp;</td>
                                        <td class="auto-style10">&nbsp;</td>
                                        <td class="auto-style12">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table align="center" width="750px">
                        <tr>
                            <td colspan="2">
                                Fees Details</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel_GridView" runat="server" Width="750px" class="well well-large">
                                    <%--<asp:GridView ID="grdFees" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        ShowHeaderWhenEmpty="True" CellPadding="4" Width="750px" 
                                        AllowPaging="True" PageSize="15"
                                        BorderColor="#3366CC" BorderStyle="None" BackColor="White" 
                                        BorderWidth="1px">
                                        <Columns>
                                            <asp:BoundField DataField="TransDate" HeaderText="Fees Date" />
                                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                            <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />
                                            <asp:BoundField DataField="PendingAmount" HeaderText="Pending Amount" />
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>--%>
                                   <asp:GridView ID="grdFees" runat="server" CellPadding="4"
                                        DataKeyNames="ReceiptNo,FeesID,TransDate" Width="100%" BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px" 
                                       OnPageIndexChanging="GrdFeesPaidDetails_PageIndexChanging" PageSize="8" AutoGenerateColumns="False">
                                        
                                        <Columns>
                                               <asp:BoundField DataField="StudentCode" HeaderText="Student Code"/>
                                               <asp:BoundField DataField="FeesType" HeaderText="FeesType"/>
                                             <asp:BoundField DataField="class" HeaderText="Class"/>
                                            <asp:BoundField DataField="TransDate" HeaderText="Trans Date"/>
                                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amt"/>
                                            <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amt"/>
                                            <asp:BoundField DataField="PendingAmount" HeaderText="Pending Amt"/>
                                                <asp:BoundField DataField="ReceiptNo" HeaderText="ReceiptNo"/>
                                            <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text="Print"
                                                        OnClick="lnkBtnStudentName_Click" CausesValidation="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                            </asp:TemplateField>
                                        <%--    <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" Text="Delete"
                                                        OnClick="lnkBtnDelete_Click" OnClientClick="ConfirmDelete()" CausesValidation="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399"
                                            HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True"
                                            ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Document Detail</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel1" runat="server" Width="750px" class="well well-large">
                                    <asp:GridView ID="grdDoc" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        ShowHeaderWhenEmpty="True" CellPadding="4" Width="750px" 
                                        AllowPaging="True" PageSize="15"
                                        BorderColor="#3366CC" BorderStyle="None" BackColor="White" 
                                        BorderWidth="1px">
                                        <Columns>
                                            <asp:BoundField DataField="DocumentName" HeaderText="Document" />
                                            <asp:BoundField DataField="DocStatus" HeaderText="Status" />
                                        </Columns>
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>   
                <div  style="display: none"><%----%>
                      <asp:Panel ID="pnlContents" runat="server" Height="1000px">
                            <center>
                                <div  style=" height:auto" >
                                    
                                    <div style="text-align: left;" > <%--border: groove">--%>
                                        <div style="text-align:right;margin-right:0px;">
                                        <asp:Label ID="Label7"  Font-Bold="True" runat="server" Font-Size="14px" Text="( Student Copy )"></asp:Label>
                                        </div>
                                        <div  style=" height:auto;border: groove" >
                                        
                                        <div style="/*margin-left: 20px;*/">
                                          
                                            <div style="text-align:center;font-size:large;font-weight:500;height:80px">
                                                <asp:Image ID="ImgTrust"   height="80px" Width="80px" runat="server"/>
                                                <asp:Label ID="lblTrustName" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text=""></asp:Label>
                                                <%--<img src="../../Sign/School bord.png"   Width="100%" height="80px" />--%>
                                            </div>
                                            <center>
                                                <div style="text-align:center;border:1px solid;width:60%;Font-Size:16px;margin-top:4px;">
                                                    <asp:Label ID="lblCourse" runat="server" Font-Bold="True" Text="lblCourse"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblTypefees" runat="server" Text="Fee" Font-Bold="True" ></asp:Label>
                                                    &nbsp;<asp:Label ID="lblReceipt" runat="server" Text="Receipt" Font-Bold="True" ></asp:Label>
                                                    &nbsp;<asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Text="lblAcademicYear"></asp:Label>
                                                </div>
                                            </center>
                                            
                                            
                                           <%-- <div style="border-bottom: groove; margin-right: 15px;">
                                               
                                            </div>--%>
                                           
                                            <%--<asp:Label ID="lblTypefeesAmount" runat="server" Text="Receipt No  :- " Visible="False"></asp:Label>--%>
                                            <center style="margin-top:8px;">
                                                <table align="left" style="text-align:left; width: 100%;Font-Size:14px;"
                                                     <%--class="auto-style13"--%> >
                                                     
                                                    <%--<caption>--%>
                                                        <tr>
                                                            <td style="width:15%;"><%--class="auto-style25">--%>
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Receipt No  :- " ></asp:Label>
                                                            </td>
                                                            <td style="width:25%;">
                                                                <asp:Label ID="lblReceiptNo" runat="server" Text="lblReceiptNo1"></asp:Label>
                                                            </td>

                                                            <td style="width:8%;"></td>
                                                            <td style="width:23%;"></td>

                                                            <td style="width:12%;">
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                                </td>
                                                            <td >
                                                                <asp:Label ID="lblDate" runat="server" Text="lblDate1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Name :- "></asp:Label>
                                                                &nbsp; </td>
                                                            <td  colspan="5">
                                                                <asp:Label ID="Label1" runat="server" Text="lblName1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--<caption>--%>
                                                            <tr>
                                                                <td >
                                                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Std :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td >
                                                                    <asp:Label ID="lblStd" runat="server" Text="lblStd1"></asp:Label>
                                                                </td>
                                                                <td style="width:8%;">
                                                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Div :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td >
                                                                    <asp:Label ID="lblDiv" runat="server" Text="lblDiv1"></asp:Label>
                                                                </td>
                                                                <td >
                                                                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="GR No :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td>
                                                                    <asp:Label ID="lblGRNo" runat="server" Text="lblGRNo1"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <%--<caption>--%>
                                                                <%--<tr>
                                                                    <td>
                                                                        <asp:Label ID="TotalAmt" runat="server" Font-Bold="True" Text="Total Fees"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td>
                                                                        <asp:Label ID="TotalAmt1" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>--%>
                                                                <%--<caption>
                                                                </caption>
                                                            </caption>
                                                        </caption>
                                                    </caption>--%>
                                                   
                                                </table>
                                                <%--<table align="right" style="margin-right: 15px;text-align:left;" >
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="PaidAmt" runat="server" Font-Bold="True" Text="Paid Fees"></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="PaidAmt1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblTodaysDate" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                   <caption>
                                                        
                                                        
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="PendingAmt" runat="server" Font-Bold="True" Text="Pending Fees"></asp:Label>
                                                                &nbsp; </td>
                                                            <td>
                                                                <asp:Label ID="PendingAmt1" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>--%>
                                            </center>
                                            <br />
                                            <br />
                                            <br />
                                            <div style="border-bottom:groove;margin-top:5px;">
                                            </div>
                                            <%--<div style="text-align: center; font-size: large; font-weight: 500">
                                                FEES History
                                            </div>--%>
                                            <center>
                                                <div style="border-bottom:groove;Height:200px;">
                                                <table width="100%">
                                                   <tr>
                                                       <td colspan="4">

                                                      
                                                    <asp:GridView ID="gridHistory" Font-Size="12px" width="100%" runat="server" OnDataBound="gridHistory_DataBound" Visible="true">
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <tr style="color: #0099FF; font-weight: bold;font-size:14px;">
                                                        <td >&nbsp;</td>
                                                        <td  align="center"><%--Total Fees :--%>
                                                            <asp:Label ID="lblTotalFees_Footer" runat="server" Font-Bold="True" Text="lblTotalFees_Footer" Visible="False"></asp:Label>
                                                        </td>
                                                        <td width="48%" >&nbsp;</td>
                                                        <td  align="center" ><%--Pending Fees :--%><asp:Label ID="lblPendingFees_Footer" runat="server" Font-Bold="True" Text="lblPendingFees_Footer" Visible="False"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                                </div>
                                                <div style="text-align:left;font-size:10px;">
                                                <label > Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                    <br /><br /><br />
                                                    <div style="width:100%;text-align:right;font-size:14px;">
                                                        <asp:Label ID="Auth_sign" runat="server" Text="Authorized Signatory : " Font-Bold="True"></asp:Label>
                                                <%--<label Font-Size="18px" > Authorized Signatory :  </label>--%>
                                                <asp:TextBox ID="TextBox1" runat="server" style="border-bottom:Solid;margin-right:25px;" BorderStyle="None"></asp:TextBox>
                                                    </div>
                                                
                                                    <br />
                                                    </div>
                                            
                                            </center>
                                            </div>

                                        </div>
                                            
                                            <br />
                                            <center>
                                             <div style="border-bottom: Dotted;">
                                            </div>
                                           </center>


                                            
                                            <center>
                                          <div style="text-align:right;margin-right:0px;margin-top:2px;">
                                            <asp:Label ID="Label6"  Font-Bold="True" runat="server" Font-Size="14px" Text="( Office Copy )"></asp:Label>
                                            </div>
                                          <div  style=" height:auto;border: groove" >
                                        
                                        <div style="/*margin-left: 20px;*/">
                                          
                                           <div style="text-align:center;font-size:large;font-weight:500;height:80px">
                                               <asp:Image ID="ImgTrust1"   height="80px" Width="80px" runat="server"/>
                                                <asp:Label ID="lblTrustName1" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text="School Name" ></asp:Label>
                                               <%--<img src="../../Sign/School bord.png"  height="80px" Width="100%" />--%>
                                            </div>
                                            <center>
                                                <div style="text-align:center;border:1px solid;width:60%;Font-Size:16px;margin-top:4px;">
                                                <asp:Label ID="lblCourse1" runat="server" Font-Bold="True" Text="lblCourse1" ></asp:Label>
                                                &nbsp;<asp:Label ID="Label11" runat="server" Text="Fee" Font-Bold="True" ></asp:Label>
                                                &nbsp;<asp:Label ID="Label13" runat="server" Text="Receipt" Font-Bold="True" ></asp:Label>
                                                    &nbsp;<asp:Label ID="lblAcademicYear1" runat="server" Font-Bold="True" Text="lblAcademicYear1"></asp:Label>
                                                </div>
                                            </center>
                                            
                                            
                                           <%-- <div style="border-bottom: groove; margin-right: 15px;">
                                               
                                            </div>--%>
                                           
                                            <%--<asp:Label ID="lblTypefeesAmount" runat="server" Text="Receipt No  :- " Visible="False"></asp:Label>--%>
                                            <center style="margin-top:8px;">
                                                <table align="left" style="text-align:left; width: 100%;Font-Size:14px;"
                                                     <%--class="auto-style13"--%> >
                                                     
                                                    <%--<caption>--%>
                                                        <tr>
                                                            <td style="width:15%;"><%--class="auto-style25">--%>
                                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Receipt No  :- " ></asp:Label>
                                                            </td>
                                                            <td style="width:25%;">
                                                                <asp:Label ID="lblReceiptNo1" runat="server" Text="lblReceiptNo1"></asp:Label>
                                                            </td>

                                                            <td style="width:8%;"></td>
                                                            <td style="width:23%;"></td>

                                                            <td style="width:12%;">
                                                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                                </td>
                                                            <td >
                                                                <asp:Label ID="lblDate1" runat="server" Text="lblDate1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td >
                                                                <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Name :- "></asp:Label>
                                                                &nbsp; </td>
                                                            <td  colspan="5">
                                                                <asp:Label ID="lblName1" runat="server" Text="lblName1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--<caption>--%>
                                                            <tr>
                                                                <td >
                                                                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Std :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td >
                                                                    <asp:Label ID="lblStd1" runat="server" Text="lblStd1"></asp:Label>
                                                                </td>
                                                                <td style="width:8%;">
                                                                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Div :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td >
                                                                    <asp:Label ID="lblDiv1" runat="server" Text="lblDiv1"></asp:Label>
                                                                </td>
                                                                <td >
                                                                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="GR No :- "></asp:Label>
                                                                    &nbsp; </td>
                                                                <td>
                                                                    <asp:Label ID="lblGRNo1" runat="server" Text="lblGRNo1"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <%--<caption>--%>
                                                                <%--<tr>
                                                                    <td>
                                                                        <asp:Label ID="TotalAmt" runat="server" Font-Bold="True" Text="Total Fees"></asp:Label>
                                                                        &nbsp; </td>
                                                                    <td>
                                                                        <asp:Label ID="TotalAmt1" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>--%>
                                                                <%--<caption>
                                                                </caption>
                                                            </caption>
                                                        </caption>
                                                    </caption>--%>
                                                   
                                                </table>
                                                <%--<table align="right" style="margin-right: 15px;text-align:left;" >
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="PaidAmt" runat="server" Font-Bold="True" Text="Paid Fees"></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="PaidAmt1" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblTodaysDate" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                   <caption>
                                                        
                                                        
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="PendingAmt" runat="server" Font-Bold="True" Text="Pending Fees"></asp:Label>
                                                                &nbsp; </td>
                                                            <td>
                                                                <asp:Label ID="PendingAmt1" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>--%>
                                            </center>
                                            <br />
                                            <br />
                                            <br />
                                            <div style="border-bottom:groove;margin-top:5px;">
                                            </div>
                                            <%--<div style="text-align: center; font-size: large; font-weight: 500">
                                                FEES History
                                            </div>--%>
                                            <center>
                                                <div style="border-bottom:groove;Height:200px;">
                                                <table width="100%">
                                                   <tr>
                                                       <td colspan="4">

                                                      
                                                    <asp:GridView ID="gridHistory1" Font-Size="12px" width="100%" runat="server" OnDataBound="gridHistory_DataBound" Visible="true">
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <tr style="color: #0099FF; font-weight: bold; font-size:14px;">
                                                        <td >&nbsp;</td>
                                                        <td  align="center"><%--Total Fees :--%>
                                                            <asp:Label ID="lblTotalFees_Footer1" runat="server" Font-Bold="True" Text="lblTotalFees_Footer1" Visible="False"></asp:Label>
                                                        </td>
                                                        <td width="48%">&nbsp;</td>
                                                        <td align="center" ><%--Pending Fees :--%>
                                                            <asp:Label ID="lblPendingFees_Footer1" runat="server" Font-Bold="True" Text="lblPendingFees_Footer1" Visible="False"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                                </div>
                                                <div style="text-align:left;font-size:10px;">
                                                <label > Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                   
                                                       <br /><br /><br />
                                                    <div style="width:100%;text-align:right;font-size:14px;">
                                                        <asp:Label ID="Label10" runat="server" Text="Authorized Signatory : " Font-Bold="True"></asp:Label>
                                                <%--<label Font-Size="18px" > Authorized Signatory :  </label>--%>
                                                <asp:TextBox ID="TextBox2" runat="server" style="border-bottom:Solid;margin-right:25px;" BorderStyle="None"></asp:TextBox>
                                                    </div>
                                                
                                                    <br />
                                                    </div> 
                                                
                                            </center>
                                            </div>

                                        </div>

                            </center>

                                 </div>
                                    </div>
                               
                            </center>
                        </asp:Panel> 
                    </div>
                     <div style="background-color: #000000; width:250px; height:100px" id="PopupDiv"><%--display: none--%>
                        <table >
                        <tr><td align="center">
                            <asp:Label ID="lblReceiptNo2" runat="server" ForeColor="White" Text="Are you sure you wants to print Fees Receipt Again?"></asp:Label>
                            </td></tr>
                        <tr><td>
                        
                   </td> </tr>
                         <tr><td align="center">
                             <asp:Button ID="btnClose" runat="server" class="btn btn-danger" Text="Cancel" />
                             <asp:Button ID="btnPrint" runat="server" class="btn btn-success" Text="Print" OnClientClick="return printpage();"/>
                             </td></tr>
                    </table> 


                     </div>
                        <asp:ModalPopupExtender ID="MessagePopUp" runat="server" TargetControlID="Label14"
                                        CancelControlID="btnPrint" PopupControlID="PopupDiv" DropShadow="True">
                                    </asp:ModalPopupExtender>
                    <br />
                        
                
            </div>
             <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
     
          
     
     
</asp:Content>
