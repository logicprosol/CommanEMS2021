<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="AddTest.aspx.cs" Inherits="CMS.Forms.Faculty.AddTest" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style2 {
             width: 100%;
         }
         .auto-style14 {
             width: 45px;
         }
         .auto-style15 {
             width: 159px;
         }
         .auto-style16 {
             width: 45px;
             height: 7px;
         }
         .auto-style17 {
             width: 159px;
             height: 7px;
         }
         .auto-style18 {
             height: 7px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Start here-->
   
    <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
        <asp:Panel ID="Panel1" runat="server" Width="920px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="2" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Add Test</li>
                        </ul>
                    </th>
                </tr>
            </table>
        </asp:Panel>
         <asp:UpdatePanel runat="server" >
        <ContentTemplate>

       
        <table>
               <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Width="920px" Height="800px" ScrollBars="Auto">
                        <center>
                            <%-- Panel 2--%>
                            <asp:Panel ID="Panel2" runat="server" Width="900px">
                                <!--Add table here-->
                             <%--   <table border="1" width="90%" align="center" cellspacing="2px">
                                    <tr>
                                        <th style="background-color: #0C7BFA; color: White">
                                            <ul class="nav nav-list">
                                                <li><i class="icon-book"></i>Personal Information</li>
                                            </ul>
                                        </th>
                                    </tr>
                                </table>--%>
                                <table class="auto-style2" style="border: 3px solid #0099FF; margin: 3px;">
                                    
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">&nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="lblMiddleName" runat="server" CssClass="formlable" Font-Bold="True" Text="Test Name : "></asp:Label>
                                            <asp:Label ID="lblMiddleName0" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ddlUnitType" runat="server" Width="183px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMiddleName" runat="server" ControlToValidate="ddlUnitType" ErrorMessage="Please Enter Test Name !!!" ForeColor="red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Test Date: "></asp:Label>
                                            <asp:Label ID="lblMiddleName3" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:DropDownList ID="ddlUnitType" runat="server" Height="27px" Width="196px">
                                                <asp:ListItem>Select Unit Test</asp:ListItem>
                                                <asp:ListItem>Unit I</asp:ListItem>
                                                <asp:ListItem>Unit II</asp:ListItem>
                                                <asp:ListItem>Unit III</asp:ListItem>
                                                <asp:ListItem>Unit IV</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            <asp:TextBox ID="txt_Date" runat="server" placeholder="mm/dd/yyyy" ValidationGroup="PersonalInfo" Width="183px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txt_Date_CalendarExtender" runat="server" DaysModeTitleFormat="MM/dd/yyyy" Format="MM/dd/yyyy" TargetControlID="txt_Date">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="Label7" runat="server" CssClass="formlable" Text="Select Course: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName1" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="195px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Select Course Name !!!" ForeColor="red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" CssClass="formlable" Text="Select Branch: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName4" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="195px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Select Branch Name !!!" ForeColor="red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="Label5" runat="server" CssClass="formlable" Text="Select Class: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName2" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="195px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlClass" ErrorMessage="Select Class Name !!!" ForeColor="red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="formlable" Text="Select Subject: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName5" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSubject" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged" Width="195px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlClass" ErrorMessage="Select subject name" ForeColor="red" InitialValue="0" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style14">&nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="Label10" runat="server" CssClass="formlable" Font-Bold="True" Text="Passing marks"></asp:Label>
                                            <asp:Label ID="lblMiddleName11" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmarks" runat="server" placeholder="Passing marks" ValidationGroup="PersonalInfo" Width="183px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtmarks" ErrorMessage="Enter passing marks" ForeColor="red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFirstName0" runat="server" CssClass="formlable" Font-Bold="True" Text="Per Question Mark : "></asp:Label>
                                            <asp:Label ID="lblMiddleName12" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPerQmark" runat="server" placeholder="Per Question marks" ValidationGroup="PersonalInfo" Width="183px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPerQmark" ForeColor="red" ValidationGroup="vg" ErrorMessage="Enter per question mark">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td class="auto-style16"></td>
                                        <td class="auto-style17"></td>
                                        <td class="auto-style18"></td>
                                        <td class="auto-style18">
                                            <asp:Label ID="lblFirstName" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Pattern : " Visible="False"></asp:Label>
                                        </td>
                                        <td class="auto-style18">
                                            <asp:DropDownList ID="ddlPattern" runat="server" Height="38px" Visible="False" Width="200px">
                                                <asp:ListItem>Select Pattern</asp:ListItem>
                                                <asp:ListItem>A</asp:ListItem>
                                                <asp:ListItem>B</asp:ListItem>
                                                <asp:ListItem>C</asp:ListItem>
                                                <asp:ListItem>D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    </table>
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn-primary" OnClick="Button2_Click" Text="New Test" />
                                <asp:Button ID="Button1" runat="server" CssClass="btn-primary" OnClick="Button1_Click" Text="Save" ValidationGroup="vg" />
                                <br />
                                <br />
                                <div style="overflow: scroll; height: 650px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
                                    BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="TestId,CourseId,BranchId,ClassId,SubjectId" DataSourceID="SqlDataSource1" 
                                    Width="900px" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound" 
                                    OnRowUpdating="GridView1_RowUpdating" EmptyDataText="No record present">
                                    <Columns>
                                        <asp:TemplateField>
        <ItemTemplate>
           <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" CausesValidation="False" />                 
        </ItemTemplate>
        <EditItemTemplate>
           <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" ValidationGroup="grid" />
           <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="False" />               
        </EditItemTemplate>             
        </asp:TemplateField> 
                                        <asp:BoundField DataField="TestId" HeaderText="TestId" InsertVisible="False" ReadOnly="True" SortExpression="TestId" Visible="False" />
                                        
                                   <%--     <asp:TemplateField HeaderText="CourseId" SortExpression="CourseId">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="CourseId" runat="server" Text='<%# Eval("CourseId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label14yy" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="BranchId" SortExpression="BranchId">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="BranchId" runat="server" Text='<%# Bind("BranchId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Labelt4" runat="server" Text='<%# Bind("BranchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="ClassId" SortExpression="ClassId">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="ClassId" runat="server" Text='<%# Bind("ClassId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label42" runat="server" Text='<%# Bind("ClassId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Test Name" SortExpression="TestName">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TestName" runat="server" Text='<%# Eval("TestName") %>' Width="80px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TestName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Test Date" SortExpression="TestDate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TestDate" runat="server" Text='<%# Eval("TestDate", "{0:dd/MM/yyyy}") %>'  placeholder="dd/MM/yyyy" Width="80px" ></asp:TextBox>
                                                <br />
                                                
                                                <asp:CalendarExtender ID="TestDate_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" TargetControlID="TestDate">
                                                </asp:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("TestDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlCourseId" Width="120px" runat="server" AutoPostBack="True" DataSourceID="SqlCourseGrid" DataTextField="CourseName" DataValueField="CourseId" Height="29px" OnSelectedIndexChanged="ddlCourseGrid_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCourseId" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red" ValidationGroup="grid">*</asp:RequiredFieldValidator>
                                                <asp:SqlDataSource ID="SqlCourseGrid" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [CourseId], [CourseName] FROM [tblCourse] WHERE ([OrgId] = @OrgId)">
                                                    <SelectParameters>
                                                        <asp:SessionParameter DefaultValue="1" Name="OrgId" SessionField="OrgId" Type="Decimal" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" SortExpression="BranchName">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlBranchGrid" Width="120px" runat ="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranchGrid_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ControlToValidate="ddlBranchGrid" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red" ValidationGroup="grid">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Class Name" SortExpression="ClassName">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlclassGrid" Width="120px" runat="server" OnSelectedIndexChanged="ddlclassGrid_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ControlToValidate="ddlclassGrid" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red" ValidationGroup="grid">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Subject Name" SortExpression="SubjectName">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlsubjectGrid" Width="120px" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ControlToValidate="ddlsubjectGrid" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red" ValidationGroup="grid">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3p" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pass Marks" SortExpression="PassMarks">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="PassMarks" Width="50px" runat="server" Text='<%# Eval("PassMarks") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ControlToValidate="PassMarks" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red" ValidationGroup="grid">*</asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("PassMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%-- <asp:BoundField DataField="CourseId" HeaderText="CourseId" SortExpression="CourseId" Visible="true"  />
                                        <asp:BoundField DataField="BranchId" HeaderText="BranchId" SortExpression="BranchId" Visible="False" />
                                        <asp:BoundField DataField="ClassId" HeaderText="ClassId" SortExpression="ClassId" Visible="False" />--%>
                                        
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
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
                                </div>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
                                    DeleteCommand="DELETE FROM [tblTest] WHERE [TestId] = @TestId" 
                                    SelectCommand="SELECT tblTest.TestId, tblTest.TestName, tblTest.PassMarks, tblTest.TestDate, tblTest.IsActive, tblCourse.CourseName, tblBranch.BranchName, tblClass.ClassName, tblTest.CourseId, tblTest.BranchId, tblTest.ClassId, tblTest.SubjectId, tblSubject.SubjectName FROM tblTest INNER JOIN tblCourse ON tblTest.CourseId = tblCourse.CourseId AND tblTest.OrgId = tblCourse.OrgId INNER JOIN tblBranch ON tblTest.BranchId = tblBranch.BranchId AND tblTest.CourseId = tblBranch.CourseId INNER JOIN tblClass ON tblTest.BranchId = tblClass.BranchId AND tblTest.ClassId = tblClass.ClassId INNER JOIN tblSubject ON tblTest.SubjectId = tblSubject.SubjectId AND tblTest.OrgId = tblSubject.OrgId
 WHERE (tblTest.OrgId = @OrgId)" 
                                    
                                    InsertCommand="INSERT INTO [tblTest] ([TestName], [CourseId], [BranchId], [ClassId], [PassMarks], [TestDate]) 
                                                    VALUES (@TestName, @CourseId, @BranchId, @ClassId, @PassMarks, @TestDate)">
                                  <%--UpdateCommand="UPDATE [tblTest] SET [TestName] = @TestName, [CourseId] = @CourseId, [BranchId] = @BranchId, [ClassId] = @ClassId, 
                                                    [PassMarks] = @PassMarks, [TestDate] = @TestDate,SubjectId=@SubjectId  WHERE [TestId] = @TestId" --%>
                                    <DeleteParameters>
                                        <asp:Parameter Name="TestId" Type="Int32" />
                                    </DeleteParameters>
                                   
                                    <InsertParameters>
                                        <asp:Parameter Name="TestName" Type="String" />
                                        <asp:Parameter Name="CourseId" Type="Int16" />
                                        <asp:Parameter Name="BranchId" Type="Int16" />
                                        <asp:Parameter Name="ClassId" Type="Int16" />
                                        <asp:Parameter Name="PassMarks" Type="Int32" />
                                        <asp:Parameter DbType="Date" Name="TestDate" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter Name="OrgId" SessionField="OrgId" Type="Int32" />
                                    </SelectParameters>
                                   <%-- <UpdateParameters>
                                        <asp:Parameter Name="TestName" Type="String" />
                                        <asp:Parameter Name="CourseId" Type="Int16" />
                                        <asp:Parameter Name="BranchId" Type="Int16" />
                                        <asp:Parameter Name="ClassId" Type="Int16" />
                                        <asp:Parameter Name="PassMarks" Type="Int32" />
                                        <asp:Parameter DbType="Date" Name="TestDate" />
                                        <asp:Parameter Name="TestId" Type="Int32" />
                                    </UpdateParameters>--%>
                                    <UpdateParameters>
                                        <asp:Parameter Name="TestName" />
                                        <asp:Parameter Name="CourseId" />
                                        <asp:Parameter Name="BranchId" />
                                        <asp:Parameter Name="ClassId" />
                                        <asp:Parameter Name="PassMarks" />
                                        <asp:Parameter Name="TestDate" />
                                         <asp:Parameter Name="SubjectId" />
                                        <asp:Parameter Name="TestId" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vg" ShowMessageBox="True" />
                                </asp:Panel>
                            
                                </center>
                                </asp:Panel>
                    </td></tr></table>
 </ContentTemplate>
    </asp:UpdatePanel>

         <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
