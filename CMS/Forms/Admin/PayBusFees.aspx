<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PayBusFees.aspx.cs" Inherits="CMS.Forms.Admin.PayBusFees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: auto; width: 920px;">
        <asp:Panel ID="Panel_Semester" runat="server" Visible="true" Style="height: auto; width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Pay Fees Installments</li>
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
                    <table style="width: 80%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Text="Student Fees Details" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_StudentFeesPaidDetails" runat="server" class="well well-large" Height="350px" ScrollBars="Vertical">
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
                                <asp:Label ID="Label4" runat="server" Text="Pay Fees Installment" Font-Size="Large"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel_FessPayment" runat="server" class="well well-large">
                                    <%--<asp:GridView ID="GrdFeesDetails" runat="server" CellPadding="4"
                                        DataKeyNames="TotalAmount,TotalPendingAmount" Width="100%"
                                        AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px">
                                        <Columns>
                                         

                                            <asp:TemplateField HeaderText="Pending Fees" ItemStyle-HorizontalAlign="Center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalPendingAmount" runat="server"  Width="100px" Text='<%#Eval("TotalPendingAmount", "{0:n}") %>'></asp:Label>
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





                                          <asp:TemplateField HeaderText="Remark" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                             <asp:DropDownList ID="ddlremark" runat="server" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Particular" DataValueField="feesDetailsId" AutoPostBack="True" OnSelectedIndexChanged="ddlremark_SelectedIndexChanged" > 
                                                        
                                                        
                                                    </asp:DropDownList>
                                                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
      SelectCommand="select 'All Fees' Particular,'0' feesDetailsId
UNION ALL
      select Particular,feesDetailsId from tblFeesDetails inner join tblFees
on tblFeesDetails.FeesId=tblFees.FeesId
inner join tblstudent on tblstudent.Courseid=tblFees.CourseId and  
tblstudent.branchid=tblFees.branchid and tblstudent.classid=tblFees.classid and
tblstudent.FeesCategory=tblFees.castecategoryid and  tblstudent.orgid=tblFees.orgid and
tblstudent.academicyearid=tblFees.academicyearid where tblstudent.usercode=@UserCode
      order by feesDetailsId">
  
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="txtStudentNameId" Name="UserCode" PropertyName="Text" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>




                                            <asp:TemplateField HeaderText="Total Fees" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount", "{0:n}") %>'></asp:Label>
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
                                    </asp:GridView>--%>
                                    <asp:GridView ID="GrdFeesDetails" runat="server" CellPadding="4"
                                        DataKeyNames="Amount,PendingAmount,FeesDetailsId" Width="100%"
                                        AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                        ShowFooter="false" BackColor="White" BorderWidth="1px" OnRowDataBound="GrdFeesDetails_RowDataBound">
                                        <Columns>
                                          <asp:TemplateField HeaderText="Remark" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                            <%-- <asp:DropDownList ID="ddlremark" runat="server" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Particular" DataValueField="feesDetailsId" AutoPostBack="True" OnSelectedIndexChanged="ddlremark_SelectedIndexChanged" > 
                                                        
                                                        
                                                    </asp:DropDownList>
                                                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
      SelectCommand="select 'All Fees' Particular,'0' feesDetailsId
UNION ALL
      select Particular,feesDetailsId from tblFeesDetails inner join tblFees
on tblFeesDetails.FeesId=tblFees.FeesId
inner join tblstudent on tblstudent.Courseid=tblFees.CourseId and  
tblstudent.branchid=tblFees.branchid and tblstudent.classid=tblFees.classid and
tblstudent.FeesCategory=tblFees.castecategoryid and  tblstudent.orgid=tblFees.orgid and
tblstudent.academicyearid=tblFees.academicyearid where tblstudent.usercode=@UserCode
      order by feesDetailsId">
  
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="txtStudentNameId" Name="UserCode" PropertyName="Text" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>--%>
                                                     <asp:CheckBox ID="chkFees" runat="server" AutoPostBack="false" Text='<%#Eval("Particular") %>'   Width="120px" CssClass="checkbox inline"/>
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



                                    
                    <%--         <tr>
                            <td>
                                <asp:Label ID="Label8" Text="Payment Mode  " runat="server"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                       
                            <td>
                                <asp:DropDownList ID="drppaymentmode2" runat="server">
                                         <asp:ListItem Text="Select" Value="Cash"></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                    <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                </asp:DropDownList>


                            </td>


</tr>--%>
                                </asp:Panel>
                            </td>
                        </tr>

                   





<%--

                        <tr>
                             <td>
                                <asp:Label ID="Label6" Text="Cheque Date" runat="server"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                       
                            <td>
                              <asp:TextBox ID ="txtchkdate" runat="server"></asp:TextBox>


                            </td>
                            </tr>
                        <tr>
                             <td>
                                <asp:Label ID="Label10" Text="Cheque NO" runat="server"></asp:Label>
                                <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                       
                            <td>
                              <asp:TextBox ID ="txtchknumber" runat="server"></asp:TextBox>


                            </td>


                            </tr>--%>





                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" Visible="false" OnClientClick = "javascript:return TestCompleteAdmission()"/>
                                    <%-- OnClientClick="basicPopup("<%# Eval("UserCode") %>");return false;"   OnClick="btnGenerateReceipt_Click"--%>
                                    <asp:Button ID="btnGenerateReceipt" runat="server" class="btn btn-primary" OnClientClick="return PrintPanel(); " Text="Generate Receipt" Visible="false" />
                                </td>
                            </tr>
                        </tr>
                    </table>

                    <br />

                    <div style="display: none">
                        <asp:Panel ID="pnlContents" runat="server" Height="1000px">
                            <center>
                                <div  style=" height:auto" >
                                    
                                    <div style="text-align: left;" > <%--border: groove">--%>
                                        <div  style=" height:auto;border: groove" >
                                        <div style="text-align:right;margin-right:10px;">
                                        <asp:Label ID="Label7"  Font-Bold="True" runat="server" Font-Size="20px" Text="( Parents Copy )"></asp:Label>
                                        </div>
                                        <div style="/*margin-left: 20px;*/">
                                          
                                            <div style="text-align:center;font-size:large;font-weight:500">
                                                <asp:Label ID="lblTrustName" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text="Sau. M. U. Karodpati English Medium  School, Parola"></asp:Label>
                                               <br /> <center>
                                                <div style="text-align:center;border:1px solid;width:60%;Font-Size:24px;">
                                                <asp:Label ID="lblCourse" runat="server" Font-Bold="True" Text="lblCourse" Visible="False"></asp:Label>
                                                &nbsp;<asp:Label ID="lblTypefees" runat="server" Text="Fee" Font-Bold="True" ></asp:Label>
                                                &nbsp;<asp:Label ID="lblReceipt" runat="server" Text="Receipt" Font-Bold="True" ></asp:Label>
                                                    &nbsp;<asp:Label ID="lblAcademicYear" runat="server" Font-Bold="True" Text="lblAcademicYear"></asp:Label>
                                                    </div></center>
                                            </div>
                                            
                                          <center style="margin-top:8px;">
                                                <table align="left" style="text-align:left; width: 100%;Font-Size:18px;" >
                                                     <tr>
                                                            <td style="width:15%;"><%--class="auto-style25">--%>
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Receipt No  :- " ></asp:Label>
                                                            </td>
                                                            <td style="width:25%;">
                                                                <asp:Label ID="lblReceiptNo" runat="server" Text="lblReceiptNo1"></asp:Label>
                                                            </td>

                                                            <td style="width:8%;"></td>
                                                            <td style="width:25%;"></td>

                                                            <td style="width:10%;">
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
                                                      
                                                </table>
                                            </center>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <div style="border-bottom:groove;margin-right:15px;">
                                            </div>
                                            <center>
                                                <div style="border-bottom:groove;margin-right:5px;height:400px;">
                                                <table width="100%">
                                                   <tr>
                                                       <td colspan="4">

                                                      
                                                    <asp:GridView ID="gridHistory" Font-Size="18px" width="100%" runat="server" OnDataBound="gridHistory_DataBound" Visible="true">
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <tr style="color: #0099FF; font-weight: bold;">
                                                        <td class="auto-style24">&nbsp;</td>
                                                        <td class="auto-style38">Total Fees :
                                                            <asp:Label ID="lblTotalFees_Footer" runat="server" Font-Bold="True" Text="lblTotalFees_Footer"></asp:Label>
                                                        </td>
                                                        <td class="auto-style39">&nbsp;</td>
                                                        <td class="auto-style30">Pending Fees :
                                                            <asp:Label ID="lblPendingFees_Footer" runat="server" Font-Bold="True" Text="lblPendingFees_Footer"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                                </div>
                                                <div style="text-align:left;font-size:14px;">
                                                <label > Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                    <br /><br /><br />
                                                    <div style="width:100%;text-align:right;font-size:18px;">
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
                                            <br />
                                            <center>
                                             <div style="border-bottom: Dotted;">
                                            </div>
                                           </center>
                                        <%--</div>--%>
                                    
                                        
                                    <%----%>
                                            <br />
                                            <center>
                                          <div  style=" height:auto;border: groove" >
                                        <div style="text-align:right;margin-right:10px;">
                                        <asp:Label ID="Label6"  Font-Bold="True" runat="server" Font-Size="20px" Text="( Office Copy )"></asp:Label>
                                        </div>
                                        <div style="/*margin-left: 20px;*/">
                                          
                                            <div style="text-align:center;font-size:large;font-weight:500">
                                                <asp:Label ID="lblTrustName1" Font-Bold="True" runat="server" Height="20px" forcolor="#C13D1F" Font-Size="26px" Font-Italic="True" Text="Sau. M. U. Karodpati English Medium  School, Parola"></asp:Label>
                                               <br /> <center>
                                                <div style="text-align:center;border:1px solid;width:60%;Font-Size:24px;">
                                                <asp:Label ID="lblCourse1" runat="server" Font-Bold="True" Text="lblCourse1"></asp:Label>
                                                &nbsp;<asp:Label ID="Label11" runat="server" Text="Fee" Font-Bold="True" ></asp:Label>
                                                &nbsp;<asp:Label ID="Label13" runat="server" Text="Receipt" Font-Bold="True" ></asp:Label>
                                                    &nbsp;<asp:Label ID="lblAcademicYear1" runat="server" Font-Bold="True" Text="lblAcademicYear1"></asp:Label>
                                                    </div></center>
                                            </div>
                                            
                                           <%-- <div style="border-bottom: groove; margin-right: 15px;">
                                               
                                            </div>--%>
                                           
                                            <%--<asp:Label ID="lblTypefeesAmount" runat="server" Text="Receipt No  :- " Visible="False"></asp:Label>--%>
                                            <center style="margin-top:8px;">
                                                <table align="left" style="text-align:left; width: 100%;Font-Size:18px;"
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
                                                            <td style="width:25%;"></td>

                                                            <td style="width:10%;">
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
                                            <br />
                                            <div style="border-bottom:groove;margin-right:15px;">
                                            </div>
                                            <%--<div style="text-align: center; font-size: large; font-weight: 500">
                                                FEES History
                                            </div>--%>
                                            <center>
                                                <div style="border-bottom:groove;margin-right:5px;height:400px;">
                                                <table width="100%">
                                                   <tr>
                                                       <td colspan="4">

                                                      
                                                    <asp:GridView ID="gridHistory1" Font-Size="18px" width="100%" runat="server" OnDataBound="gridHistory_DataBound" Visible="true">
                                                    </asp:GridView>
 </td>
                                                   </tr> 
                                                    <tr style="color: #0099FF; font-weight: bold;">
                                                        <td class="auto-style24">&nbsp;</td>
                                                        <td class="auto-style38">Total Fees :
                                                            <asp:Label ID="lblTotalFees_Footer1" runat="server" Font-Bold="True" Text="lblTotalFees_Footer1"></asp:Label>
                                                        </td>
                                                        <td class="auto-style39">&nbsp;</td>
                                                        <td class="auto-style30">Pending Fees :
                                                            <asp:Label ID="lblPendingFees_Footer1" runat="server" Font-Bold="True" Text="lblPendingFees_Footer1"></asp:Label>
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                                </div>
                                                <div style="text-align:left;font-size:14px;">
                                                <label > Note:- Fees once paid will not be refunded in any case. Also fees should be paid in time. Late Fee may be charged. </label>
                                                   
                                                       <br /><br /><br />
                                                    <div style="width:100%;text-align:right;font-size:18px;">
                                                        <asp:Label ID="Label10" runat="server" Text="Authorized Signatory : " Font-Bold="True"></asp:Label>
                                                <%--<label Font-Size="18px" > Authorized Signatory :  </label>--%>
                                                <asp:TextBox ID="TextBox2" runat="server" style="border-bottom:Solid;margin-right:25px;" BorderStyle="None"></asp:TextBox>
                                                    </div>
                                                
                                                    <br />
                                                    </div> 
                                                
                                                </div>
                                            
                                            </center>
                                            </div>

                                        </div></center>

                            </center>
                        </asp:Panel>
                        
                     </div>  
                    <br />
                        
                </ContentTemplate>
            </asp:UpdatePanel><ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </asp:Panel>
    </div>

</asp:Content>
