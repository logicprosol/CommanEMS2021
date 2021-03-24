<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateChallan.aspx.cs" Inherits="CMS.Forms.Admin.CreateChallan" %>

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
         function TestCompleteAdmission() {
            
            
            {
                var TargetBaseControl = document.getElementById('<%= GrdFeesDetails.ClientID %>');

                if (TargetBaseControl != null)
                {
                    var TargetChildControl = "chkFees";

                    //get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");
                
                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
                            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                            Inputs[n].checked)
                        {
                           
                            return true;
                        }
                        
                            alert("Select at least one!!!", "Warning");
                            return false;
                        
                }
                else
                {
                     alert("No record present!!!", "Warning");
                    return false;
                }

            
            }
        }
          function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
        }

        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "PayInstallmentFees.aspx/GetAutoCompleteData",
                        data: "{'StudentNameId':'" + document.getElementById('txtStudentNameId').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            // alert("Success");
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>
    <script type="text/javascript">
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintFeesReceipt.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
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
    <script type="text/javascript">
        
        function CheckAllParent(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdFeesDetails.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
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
                            <li><i class="icon-book"></i>Create Challan</li>
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
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblStudentCode" runat="server" Visible="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStudentNameId" Text="Student Code " runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentNameId" runat="server" class="autosuggest" AutoPostBack="true"></asp:TextBox>
                                <%--          <input type="text" id="txtStudentNameId" name="_name" class="autosuggest" />--%>

                            </td>

                            <td>
                                <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" CssClass="btn btn-primary" OnClick="btnGetDetails_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false" OnClick="btnNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStudentNameId0" runat="server" Text="Receipt Date" ToolTip="If you want to change fees receipt date"></asp:Label>
                            </td>
                            <td><asp:TextBox ID="txtReceiptDate" runat="server" placeholder="Receipt Date" ValidationGroup="vg" Width="150px"></asp:TextBox>
                               <asp:CalendarExtender ID="txtAppDate_CalendarExtender" runat="server" Format="MMM/dd/yyyy" TargetControlID="txtReceiptDate">
                                </asp:CalendarExtender>
                                                                           
                                                                        </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                    <table style="width: 80%">
                        <tr>
                            <td class="auto-style1">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label2" runat="server" Text="Student Details" Font-Size="Large" Visible=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_StudentDetails" runat="server" class="well well-large">
                                    <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="UserCode,StudentName,CourseName,BranchName,ClassName,FeesId"
                                        Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                        BorderStyle="None" BackColor="White" BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                                        CausesValidation="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("ClassName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField HeaderText="CasteCategory" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("CasteCategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="AcademicYear" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblacademicyear" runat="server" Text='<%#Eval("academicyear") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admission Status" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%;">
                        <tr style="display:none;">
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Text="Student Fees Details" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr style="display:none;">
                            <td>
                                <asp:Panel ID="Panel_StudentFeesPaidDetails" runat="server" class="well well-large" ScrollBars="Auto" Height="300px" Visible="false">
                                    
                                    <asp:GridView ID="GrdFeesPaidDetails" runat="server" CellPadding="4"
                                        DataKeyNames="ReceiptNo" Width="100%"
                                        AutoGenerateColumns="True" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdFeesPaidDetails_PageIndexChanging" PageSize="8">
                                        <Columns>
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
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label4" runat="server" Text="Pay Fees Challan" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_FessPayment" runat="server" class="well well-large" ScrollBars="Auto" Height="300px">
                                    
                                    <asp:GridView ID="GrdFeesDetails" runat="server" CellPadding="4"
                                        DataKeyNames="Amount,PendingAmount,FeesDetailsId" Width="100%"
                                        AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px" OnRowDataBound="GrdFeesDetails_RowDataBound">
                                        <Columns>
                                          

                                            <asp:TemplateField HeaderText="Remark" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllParent(this)"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkFees" runat="server" AutoPostBack="false" Text='<%#Eval("Particular") %>'   Width="120px" CssClass="checkbox inline" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Total Fees" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Amount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaidAmount" runat="server" Text='<%#Eval("PaidAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Pay Fees" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPayamount" runat="server" Width="100px"  onkeypress="return isNumberKey(event)"  AutoPostBack="True" OnTextChanged="txtPaidAmount_OnTextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPayAmount" runat="server" ControlToValidate="txtPayamount" ErrorMessage="*" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>

                                                   
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pending Fees" ItemStyle-HorizontalAlign="Center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalPendingAmount" runat="server"  Width="100px" Text='<%#Eval("PendingAmount", "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                           






                                            <asp:TemplateField HeaderText="Payment mode" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                  
                                                    <asp:DropDownList ID="ddlpaymentmode" Width="100px" AutoPostBack="true"  runat="server">

                                                    
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Chaque" Value="Chaque"></asp:ListItem>
                                                        <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                                                        <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                    </asp:DropDownList>                                             

                                                    
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
 

                                    
                                    <br />



                               
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Total Paid : " Font-Bold="True" Font-Size="Medium"></asp:Label>
                                <asp:Label ID="lbltotalpay" runat="server" Text="0" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                   




                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" Visible="false" OnClientClick = "javascript:return TestCompleteAdmission()"/>
                                    <%-- OnClientClick="basicPopup("<%# Eval("UserCode") %>");return false;"   OnClick="btnGenerateReceipt_Click"--%>
                                    <asp:Button ID="btnGenerateReceipt" runat="server" class="btn btn-primary" OnClientClick="return PrintPanel(); " Text="Generate Challan" Visible="false" />
                                </td>
                            </tr>
                        </tr>
                    </table>

                    <br />





                    <div style="display:none;"><%----%>
                        <asp:Panel ID="pnlContents" runat="server" Height="1000px">
                           
                                <div  style=" height:auto" >
                                    
                                    <div style="width:100%;height:100%;">
                <table style="width:100%;height:100%;" border="1" >
                    <tr >
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label5" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label12" runat="server"  Text="(For the Bank)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label6" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label9" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td  style="width:50%;">
                                            <asp:Label ID="Label10" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td  align="Right" style="margin-right:10px;" >
                                            <asp:Label ID="txtRN1" runat="server" Text="001" style="margin-right:20px;"  Font-Size="12px" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label11" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label13" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label15" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="txtsumRS1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label16" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="txtsumRSword1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtsumRSword11" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td><asp:Label ID="txt11" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td><asp:Label ID="txt12" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. Development Fee</td>
                                            <td><asp:Label ID="txt13" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td><asp:Label ID="txt14" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td><asp:Label ID="txt15" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td><asp:Label ID="txt16" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td><asp:Label ID="txt17" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th><asp:Label ID="txttotal1" runat="server" Text="0" Font-Bold="true" ></asp:Label></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label18" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtstudentname1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtstudentname11" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label20" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtclass1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label21" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtrollno1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label23" runat="server" Text="during the Year " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtacademicyear1" runat="server" Text="2019-2020 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtcardno1" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label26" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label27" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtdate1" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label28" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label29" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label30" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label31" runat="server"  Text="(For the Student)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label32" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label33" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label34" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td  style="width:50%;">
                                            <asp:Label ID="Label17" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td  align="Right" style="margin-right:10px;" >
                                            <asp:Label ID="txtRN2" runat="server" Text="001" style="margin-right:20px;"  Font-Size="12px" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label36" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label37" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label39" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="txtsumRS2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label41" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="txtsumRSword2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtsumRSword12" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td><asp:Label ID="txt21" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td><asp:Label ID="txt22" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. Development Fee</td>
                                            <td><asp:Label ID="txt23" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td><asp:Label ID="txt24" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td><asp:Label ID="txt25" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td><asp:Label ID="txt26" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td><asp:Label ID="txt27" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th><asp:Label ID="txttotal2" runat="server" Text="0" Font-Bold="true" ></asp:Label></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label44" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtstudentname2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtstudentname12" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label47" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtclass2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label49" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtrollno2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label51" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label52" runat="server" Text="during the Year " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtacademicyear2" runat="server" Text="2019-2020 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label53" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtcardno2" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label116" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label117" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label118" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtdate2" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label119" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label120" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr >
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label54" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label55" runat="server"  Text="(For the Office)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label56" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label57" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label58" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td  style="width:50%;">
                                            <asp:Label ID="Label19" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td  align="Right" style="margin-right:10px;" >
                                            <asp:Label ID="txtRN3" runat="server" Text="001" style="margin-right:20px;"  Font-Size="12px" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label60" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label61" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label62" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label63" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="txtsumRS3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label65" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="txtsumRSword3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtsumRSword13" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td><asp:Label ID="txt31" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td><asp:Label ID="txt32" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. Development Fee</td>
                                            <td><asp:Label ID="txt33" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td><asp:Label ID="txt34" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td><asp:Label ID="txt35" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td><asp:Label ID="txt36" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td><asp:Label ID="txt37" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th><asp:Label ID="txttotal3" runat="server" Text="0" Font-Bold="true" ></asp:Label></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label68" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtstudentname3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtstudentname13" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label71" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtclass3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label73" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtrollno3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label75" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label76" runat="server" Text="during the Year " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtacademicyear3" runat="server" Text="2019-2020 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label77" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtcardno3" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label110" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label111" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label112" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtdate3" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label113" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label114" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label78" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label79" runat="server"  Text="(For the Office)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label80" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label81" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label82" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td  style="width:50%;">
                                            <asp:Label ID="Label35" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td  align="Right" style="margin-right:10px;" >
                                            <asp:Label ID="txtRN4" runat="server" Text="001" style="margin-right:20px;"  Font-Size="12px" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label84" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label85" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label86" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label87" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="txtsumRS4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label89" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="txtsumRSword4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtsumRSword14" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td><asp:Label ID="txt41" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td><asp:Label ID="txt42" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. Development Fee</td>
                                            <td><asp:Label ID="txt43" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td><asp:Label ID="txt44" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td><asp:Label ID="txt45" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td><asp:Label ID="txt46" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td><asp:Label ID="txt47" runat="server" Text="0"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th><asp:Label ID="txttotal4" runat="server" Text="0" Font-Bold="true" ></asp:Label></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label92" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtstudentname4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtstudentname14" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label95" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtclass4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label103" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="txtrollno4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label105" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label106" runat="server" Text="during the Year " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtacademicyear4" runat="server" Text="2019-2020 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label107" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtcardno4" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;text-align:center;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label121" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label122" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label123" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="txtdate4" runat="server" Text="1/1/2020" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label124" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label125" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

                                </div>
                               
                            </center>
                        </asp:Panel>
                        
                       
                    <br />
                        
                </ContentTemplate>
            </asp:UpdatePanel><ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </asp:Panel>
    </div>
   
  
   
  
</asp:Content>
