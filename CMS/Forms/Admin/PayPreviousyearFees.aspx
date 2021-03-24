<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Admin/Admin.Master" CodeBehind="PayPreviousyearFees.aspx.cs" Inherits="CMS.Forms.Admin.PayPreviousyearFees" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript">
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintFeesReceipt.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=1000,width=800');
            printWindow.document.write('<html><head><title></title>');
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

    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }

        .auto-style2 {
            margin-left: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 1000px; width: 920px;">
        <asp:Panel ID="Panel_Semester" runat="server" Visible="true" Style="height: auto; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Pay Fees Installments(Previous Year)</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_PayFees" runat="server" align="center" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnGetDetails" />--%>
                </Triggers>
                <ContentTemplate>
                    <table border="0" width="50%" align="center" cellspacing="2px">
                        <br />
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCourseDRP" runat="server" Text="Course : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranchDRP" runat="server" Text="Branch : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClassDRP" runat="server" Text="Class : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAcademicYearDRP" Width="150px" runat="server" Text="Academic Year : "></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" Width="180px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="180px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">

                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: left">

                                            <asp:DropDownList ID="DDLAcademicYear" Width="150px" runat="server" ValidationGroup="GeneralDetails" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>


                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblStudentName" Text="Student Name " runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStudentname" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlStudentname_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStudentNameId0" runat="server" Text="Receipt Date" ToolTip="If you want to change fees receipt date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReceiptDate" runat="server" placeholder="Receipt Date" ValidationGroup="vg" Width="150px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtAppDate_CalendarExtender" runat="server" Format="MMM/dd/yyyy" TargetControlID="txtReceiptDate">
                                            </asp:CalendarExtender>

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" CssClass="btn btn-primary" OnClick="btnGetDetails_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false" />
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblStudentCode" runat="server" Visible="False"></asp:Label>
                                <br />
                            </td>
                            <td>
                                <asp:Label ID="lblStudentNameId" Text="Student Code " Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentNameId" Visible="false" runat="server" class="autosuggest" AutoPostBack="true"></asp:TextBox>
                                <%--          <input type="text" id="txtStudentNameId" name="_name" class="autosuggest" />--%>

                            </td>


                        </tr>
                        <tr>

                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Text="Student Fees Details" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_StudentFeesPaidDetails" runat="server" class="well well-large" ScrollBars="Auto" Height="300px">

                                    <asp:GridView ID="GrdFeesPaidDetails" runat="server" CellPadding="4"
                                        DataKeyNames="FeesId" Width="100%" OnRowDataBound="GrdFeesPaidDetails_RowDataBound"
                                        AutoGenerateColumns="false" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px" PageSize="8">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" " ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtFeesID" runat="server" Text='<%# Bind("FeesID") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeesID" runat="server" Text='<%# Bind("FeesID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Class" ItemStyle-Width="220px" ItemStyle-HorizontalAlign="Center" DataField="Class">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" DataField="CurrentDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <%--    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtDate" runat="server" Text='<%# Eval("CurrentDate","{0:dd, MMM yyyy}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CurrentDate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Total Amt" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TxtTotalAmt" runat="server" Text='<%# Bind("TotalAmount", "{0:n}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTotalAmt" runat="server" Text='<%# Bind("TotalAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paid Amt" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPAidAmnt" runat="server" Text='<%# Bind("PaidAmount", "{0:n}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPaidAmt" runat="server" Text='<%# Bind("PaidAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--     <asp:TemplateField HeaderText="Pay Amt" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtpendingAmt" runat="server" Text='<%# Bind("PayAmount", "{0:n}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayAmt" runat="server" Text='<%# Bind("PayAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Pending Amt" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("pendingAmount", "{0:n}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPendingAmt" runat="server" Text='<%# Bind("pendingAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>


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
                            <td align="center">
                                <asp:Label ID="Label4" runat="server" Text="Pay Pending Fees" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="PanelPayfees" runat="server" class="well well-large" ScrollBars="Auto" Height="300px">

                                    <div id="div1" runat="server" style="height: 220px; margin-top: 40px; border: solid;">

                                        <table style="margin-left: auto; margin-right: auto;">

                                            <tr>
                                                <br />
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="lblStudentNamee" Text="Student Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="lblStudentNameevalue"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="lblTotalAmount" Text="Total Amount  :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="blue" ID="lblTotalAmountvalue" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="lblPaidAmount" Text="Paid Amount  :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Green" ID="lblPaidAmountValue" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="Label2" Text="Pending Amount :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Red" ID="LblPendingAmtvalue" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <br />
                                                <td>
                                                    <asp:Label runat="server" Font-Size="Medium" ForeColor="Black" ID="Label5" Text="Pay Amount   :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" Font-Size="Medium" ID="TxtPayAmt"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:Button ID="btnsave" runat="server" Text="Pay Fee" CssClass="btn-primary" OnClick="btnsave_Click" />
                                                    <asp:Button ID="btncancel" runat="server" Text="Clear" CssClass="btn-primary" OnClick="btncancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:Button ID="btnGenerateReceipt" runat="server" class="btn btn-primary" OnClientClick="return PrintPanel(); " Text="Generate Receipt" Visible="false" />
                                </asp:Panel>
                            </td>
                        </tr>

                    </table>
                    <div style="display: none;">
                        <%----%>
                    </div>
                    <div style="display: none;">
                        <%----%>
                        <asp:Panel ID="Panel1" runat="server" Height="1000px">
                            <center>
                                  <div style="height: auto">
                            <div style="width: 80%; height: auto">
                                <div style="text-align: right; margin-right: 0px;">
                                    <asp:Label ID="Label7" Font-Bold="True" runat="server" Font-Size="14px" Text="( Student Copy )"></asp:Label>
                                </div>
                                <div style="text-align: center; font-size: large; font-weight: 500; height: 80px">
                                    <asp:Image ID="ImgTrust" Height="80px" Width="80px" runat="server" />
                                    <asp:Label ID="lblTrustName" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text=""></asp:Label>

                                </div>
                                <center>
                                                        <div style="text-align: center; border: 1px solid; width: 60%; font-size: 16px; margin-top: 4px;">
                                                            <asp:Label ID="lblCourse" runat="server" Font-Bold="True" Text="lblCourse1"></asp:Label>
                                                            &nbsp;<asp:Label ID="Label29" runat="server" Text="Fee" Font-Bold="True"></asp:Label>
                                                            &nbsp;<asp:Label ID="Label30" runat="server" Text="Receipt" Font-Bold="True"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblAcademicYear1" runat="server" Font-Bold="True" Text="lblAcademicYear1"></asp:Label>
                                                        </div>
                                                    </center>
                                <table style="width:auto; height:auto" border="1">
                                    <tr>
                                        <td style="width: 60%;">
                                            <div style="margin: 0px; margin-left: 5px; margin-right: 5px; margin-top: 0px;">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 15%;"><%--class="auto-style25">--%>
                                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Student NAme  :- "></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;">
                                                            <asp:Label ID="lblReceiptNo1" runat="server" Text="lblReceiptNo1"></asp:Label>
                                                        </td>

                                                        <td style="width: 8%;"></td>
                                                        <td style="width: 23%;"></td>

                                                        <td style="width: 12%;">
                                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDate1" runat="server" Text="lblDate1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Std :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="lblStd1" runat="server" Text="lblStd1"></asp:Label>
                                                        </td>
                                                        <td style="width: 8%;">
                                                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Div :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="lblDiv1" runat="server" Text="lblDiv1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="GR No :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="lblGRNo1" runat="server" Text="lblGRNo1"></asp:Label>
                                                        </td>
                                                    </tr>


                                                </table>

                                                <div>
                                                    <table style="width: 100%; height: 100%; font-size: 12px;" border="1">
                                                        <tr>
                                                            <th style="width: 70%;">Particulars</th>
                                                            <th>Rs.</th>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 70%;">1.Previous Year fee</td>
                                                            <td>
                                                                <asp:Label ID="lblPrevious1" runat="server" Text="0"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label99" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="txtdate1" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 55%;">
                                                            <asp:Label ID="Label101" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%-- <asp:Label ID="Label29" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>

                                    </table>
                                <div style="text-align: left; font-size: 10px;">
                                                        <label>Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <div style="width: 100%; text-align: right; font-size: 14px;">
                                                            <asp:Label ID="Label31" runat="server" Text="Authorized Signatory : " Font-Bold="True"></asp:Label>
                                                            <%--<label Font-Size="18px" > Authorized Signatory :  </label>--%>
                                                            <asp:TextBox ID="TextBox2" runat="server" Style="border-bottom: Solid; margin-right: 25px;" BorderStyle="None"></asp:TextBox>
                                                        </div>

                                                        <br />
                                                    </div>
                                </div>
                                        <br />
                                        <center>
                                            <div style="border-bottom: Dotted;">
                                            </div>
                                        </center>

                            <div style="width: 80%; height:auto;">
                                        <div style="text-align: right; margin-right: 0px;">
                                            <asp:Label ID="Label27" Font-Bold="True" runat="server" Font-Size="14px" Text="( Office Copy )"></asp:Label>
                                        </div>
                                        <div style="text-align: center; font-size: large; font-weight: 500; height: 80px">
                                            <asp:Image ID="ImgTrust1" Height="80px" Width="80px" runat="server" />
                                            <asp:Label ID="lblTrustNamegg" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text=""></asp:Label>

                                        </div>
                                   <center>
                                                        <div style="text-align: center; border: 1px solid; width: 60%; font-size: 16px; margin-top: 4px;">
                                                            <asp:Label ID="lblCourse1" runat="server" Font-Bold="True" Text="lblCourse1"></asp:Label>
                                                            &nbsp;<asp:Label ID="Label32" runat="server" Text="Fee" Font-Bold="True"></asp:Label>
                                                            &nbsp;<asp:Label ID="Label33" runat="server" Text="Receipt" Font-Bold="True"></asp:Label>
                                                            &nbsp;<asp:Label ID="Label34" runat="server" Font-Bold="True" Text="lblAcademicYear1"></asp:Label>
                                                        </div>
                                                    </center>
                                 <table style="width:auto; height:auto" border="1">
                                     <tr>
                                        <td style="width: 50%;">
                                            <div style="margin: 0px; margin-left: 5px; margin-right: 5px; margin-top: 0px;">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 15%;"><%--class="auto-style25">--%>
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Student NAme  :- "></asp:Label>
                                                        </td>
                                                        <td style="width: 25%;">
                                                            <asp:Label ID="Label8" runat="server" Text="lblReceiptNo1"></asp:Label>
                                                        </td>

                                                        <td style="width: 8%;"></td>
                                                        <td style="width: 23%;"></td>

                                                        <td style="width: 12%;">
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Date:-"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server" Text="lblDate1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Std :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="Label12" runat="server" Text="lblStd1"></asp:Label>
                                                        </td>
                                                        <td style="width: 8%;">
                                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Div :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" Text="lblDiv1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="GR No :- "></asp:Label>
                                                            &nbsp; </td>
                                                        <td>
                                                            <asp:Label ID="Label17" runat="server" Text="lblGRNo1"></asp:Label>
                                                        </td>
                                                    </tr>


                                                </table>

                                                <div>
                                                    <table style="width: 100%; height: 100%; font-size: 12px;" border="1">
                                                        <tr>
                                                            <th style="width: 70%;">Particulars</th>
                                                            <th>Rs.</th>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 70%;">1.Previous Year fee</td>
                                                            <td>
                                                                <asp:Label ID="lblPrevious111" runat="server" Text="0"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>

                                              
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label22" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="Label23" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 55%;">
                                                            <asp:Label ID="Label25" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%-- <asp:Label ID="Label29" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                 <center>
                                                    <div style="border-bottom: groove; height: 200px;">
                                                     
                                                        <div style="text-align: left; font-size: 10px;">
                                                        <label>Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <div style="width: 100%; text-align: right; font-size: 14px;">
                                                            <asp:Label ID="Auth_sign" runat="server" Text="Authorized Signatory : " Font-Bold="True"></asp:Label>
                                                            <%--<label Font-Size="18px" > Authorized Signatory :  </label>--%>
                                                            <asp:TextBox ID="TextBox1" runat="server" Style="border-bottom: Solid; margin-right: 25px;" BorderStyle="None"></asp:TextBox>
                                                        </div>

                                                        <br />
                                                    </div>
                                                    </div>
                                                    

                                                </center>
                            </div>
                                      </div>
                                </center>
                        </asp:Panel>
                    </div>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
