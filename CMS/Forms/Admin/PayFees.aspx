<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="PayFees.aspx.cs" Inherits="CMS.Forms.Admin.PayFees" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    SearchText();
        //});
        //function SearchText() {
        //    $(".autosuggest").autocomplete({
        //        source: function (request, response) {
        //            $.ajax({
        //                type: "POST",
        //                contentType: "application/json; charset=utf-8",
        //                url: "PayFees.aspx/GetAutoCompleteData",
        //                data: "{'StudentNameId':'" + document.getElementById('txtStudentNameId').value + "'}",
        //                dataType: "json",
        //                success: function (data) {
        //                    // alert("Success");
        //                    response(data.d);
        //                },
        //                error: function (result) {
        //                    alert("Error");
        //                }
        //            });
        //        }
        //    });
        //}
    </script>
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
                        
                            alert("Select at least one Checkbox..!!!", "Warning");
                            return false;
                        
                }
                else
                {
                     alert("No record present!!!", "Warning");
                    return false;
                }

            
            }
        }
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintFeesReceipt.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
        }
    
         function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents.ClientID %>");
                  var printWindow = window.open('', '', 'height=400,width=800');
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
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     


      

     


      


     


      

     


       <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Image ID="PleaseWaitImage" ImageUrl="~/images/please_wait.gif" AlternateText="Processing"
                runat="server" Height="42px" Width="121px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />--%>



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_Semester" runat="server" Visible="true" Style="height: 895px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Pay Fees</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_PayFees" runat="server" align="center" UpdateMode="Conditional"
                ChildrenAsTriggers="true">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGetDetails" />
                </Triggers>
                <ContentTemplate>
            <center>
                    <table border="0" width="500px" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="3">
                                <div style="display:none">
                                <asp:Label ID="lblAdmissionId" runat="server" ></asp:Label></div>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="input-small">
                                <asp:Label ID="lblStudentNameId" runat="server" Text="Admission Id :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td valign="middle">




                           <%--     <asp:TextBox ID="txtStudentNameId" runat="server" class="autosuggest"></asp:TextBox>--%>
                                <asp:TextBox  ID="txtStudentNameId"   runat="server" ></asp:TextBox>

                                <asp:DropDownList ID="ddlAcademicYearId" runat="server" DataSourceID="SqlDataSource2" DataTextField="AcademicYear" DataValueField="AcademicYearId">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCourse0" runat="server" ControlToValidate="ddlAcademicYearId" ErrorMessage="Please Select Academic Year!" ForeColor="Red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                    SelectCommand="SELECT 0 [AcademicYearId], 'Select' [AcademicYear] union SELECT [AcademicYearId], [AcademicYear] FROM [tblAcademicYear] WHERE ([OrgId] = @OrgId)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="OrgId" SessionField="OrgId" Type="Decimal" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="input-small">&nbsp;</td>
                            <td valign="middle">
                                <asp:Button ID="btnNew" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnNew_Click" Text="New" />
                                &nbsp;<asp:Button ID="btnGetDetails" runat="server" CssClass="btn btn-primary" OnClick="btnGetDetails_Click" Text="Get Details" ValidationGroup="vg" />
                            </td>
                            <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="input-small">&nbsp;</td>
                            <td valign="middle">&nbsp;</td>
                            <td valign="top">&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td>
                                <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="AdmissionID,StudentName,CourseName,BranchName,ClassName,FeesId"
                                    Width="80%" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                    BorderStyle="None" BackColor="White" BorderWidth="1px" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                                    OnClick="lnkBtnStudentName_Click" CausesValidation="false"></asp:LinkButton>
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
                                        <asp:TemplateField HeaderText="CasteCategory" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("CasteCategoryName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Fees Category" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFeesCategory" runat="server" Text='<%#Eval("FeesCategoryName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Admission Status" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 80%">
                        <tr>
                            <td>
                               
                                <asp:Panel ID="Panel_FessPayment" runat="server" class="well well-large" ScrollBars="Auto" Height="400px">
                                 <asp:GridView ID="GrdFeesDetails" runat="server" CellPadding="4" DataKeyNames="TotalAmount,feesDetailsId"
                                    Width="80%"  AutoGenerateColumns="False"
                                    BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px">
                                    <Columns>
                                       
                                        <%--<asp:TemplateField HeaderText="Remark" >
                                            <ItemTemplate>
                                              
                                                 <asp:CheckBox ID="chkFees" runat="server" AutoPostBack="True" Text='<%#Eval("Particular") %>'   Width="120px" CssClass="checkbox inline"/>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

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

                                         
                                        <asp:TemplateField HeaderText="Total Fees" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalAmount" Text='<%#Eval("TotalAmount") %>' runat="server" ></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="150px" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pay Fees" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPayamount" runat="server"  onkeypress="return isNumberKey(event)" AutoPostBack="True" OnTextChanged="txtPaidAmount_OnTextChanged" Text="0" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPayAmount" runat="server" ControlToValidate="txtPayamount"
                                                    ErrorMessage="*" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                               
                                            </ItemTemplate>
                                            
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending Fees" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalPendingAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"  Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fees Detail Id" Visible="false" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblFeesDetailId" Text='<%#Eval("feesDetailsId") %>' runat="server" ></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="150px" Wrap="False" />
                                        </asp:TemplateField>
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
                        <tr >
                            <td style="Width:80%;">
                                <asp:Label ID="Label8" runat="server" Text="Total Paid : " Font-Bold="True" Font-Size="Medium"></asp:Label>
                                <asp:Label ID="lbltotalpay" runat="server" Text="0" Font-Size="Medium"></asp:Label>
                                   <asp:Label ID="ShwMsg" runat="server" Visible="false" Font-Bold="true" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" Visible="true" OnClientClick = "javascript:return TestCompleteAdmission()"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnGenerateReceipt" runat="server" Text="Generate Receipt" class="btn btn-primary"
                                    Visible="false"  OnClick="btnGenerateReceipt_Click1"   />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg" />
                            </td>
                        </tr>
                    </table>
            </center>
                     <div style="display:none"><%----%>
                            
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
                                                                <asp:Label ID="lblName" runat="server" Text="lblName1"></asp:Label>
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

                                                      
                                                    <asp:GridView ID="gridHistory" Font-Size="12px" width="100%" runat="server"  Visible="true"><%--OnDataBound="gridHistory_DataBound"--%>
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <%--<tr style="color: #0099FF; font-weight: bold;font-size:14px;">
                                                        <td >&nbsp;</td>
                                                        <td  align="center">Total Fees :
                                                            <asp:Label ID="lblTotalFees_Footer" runat="server" Font-Bold="True" Text="lblTotalFees_Footer"></asp:Label>
                                                        </td>
                                                        <td width="48%" >&nbsp;</td>
                                                        <td  align="center" >Pending Fees :
                                                            <asp:Label ID="lblPendingFees_Footer" runat="server" Font-Bold="True" Text="lblPendingFees_Footer"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>--%>
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

                                                      
                                                    <asp:GridView ID="gridHistory1" Font-Size="12px" width="100%" runat="server"  Visible="true"><%--OnDataBound="gridHistory_DataBound"--%>
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <%--<tr style="color: #0099FF; font-weight: bold; font-size:14px;">
                                                        <td >&nbsp;</td>
                                                        <td  align="center">Total Fees :
                                                            <asp:Label ID="lblTotalFees_Footer1" runat="server" Font-Bold="True" Text="lblTotalFees_Footer1"></asp:Label>
                                                        </td>
                                                        <td width="48%">&nbsp;</td>
                                                        <td align="center" >Pending Fees :
                                                            <asp:Label ID="lblPendingFees_Footer1" runat="server" Font-Bold="True" Text="lblPendingFees_Footer1"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>--%>
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
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>

          
    </div>
  
   
       
  
   
       
  
   
</asp:Content>