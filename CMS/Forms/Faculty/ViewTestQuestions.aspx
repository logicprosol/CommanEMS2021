<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Faculty/Faculty.Master" CodeBehind="ViewTestQuestions.aspx.cs" Inherits="CMS.ViewTestQuestions" %>

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

        .auto-style3 {
            margin-bottom: 0px;
        }

        .auto-style12 {
            width: 325px;
        }

        .auto-style13 {
            width: 125px;
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

        .auto-style19 {
            width: 46px;
        }

        .auto-style20 {
            width: 920px;
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="updatepnl" runat="server" UpdateMode="Conditional">
      
        <ContentTemplate>
            <!-- Start here-->
            <div style="border: medium double#0C7BFA; vertical-align: top;" class="auto-style20">
                <asp:Panel ID="Panel1" runat="server" Width="920px">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="2" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>View Questions</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                </asp:Panel>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Width="920px" Height="900px" ScrollBars="Auto">
                                <%----%>
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
                                                <td class="auto-style14">&nbsp;</td>
                                                <td class="auto-style15">&nbsp;</td>
                                                <td>&nbsp;</td>

                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td class="auto-style14">&nbsp;</td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="lblMiddleName" runat="server" CssClass="formlable" Font-Bold="True" Text="Test Name : " Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ddlUnitType" runat="server" Width="183px" Visible="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Test Date: " Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <%--<asp:DropDownList ID="ddlUnitType" runat="server" Height="27px" Width="196px">
                                                <asp:ListItem>Select Unit Test</asp:ListItem>
                                                <asp:ListItem>Unit I</asp:ListItem>
                                                <asp:ListItem>Unit II</asp:ListItem>
                                                <asp:ListItem>Unit III</asp:ListItem>
                                                <asp:ListItem>Unit IV</asp:ListItem>
                                            </asp:DropDownList>--%>
                                                    <asp:TextBox ID="txt_Date" runat="server" placeholder="mm/dd/yyyy" ValidationGroup="PersonalInfo" Width="183px" Visible="False"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txt_Date_CalendarExtender" runat="server" DaysModeTitleFormat="MM/dd/yyyy" Format="MM/dd/yyyy" TargetControlID="txt_Date">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style14">&nbsp;</td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="Label7" runat="server" CssClass="formlable" Text="Select Course: " Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="lblMiddleName1" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" CssClass="formlable" Text="Select Branch: " Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="lblMiddleName4" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="195px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Enter Branch Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style14">&nbsp;</td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="Label5" runat="server" CssClass="formlable" Text="Select Class: " Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="lblMiddleName2" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlClass" runat="server" Height="29px" Width="195px" AutoPostBack="True">
                                                    </asp:DropDownList><%--OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Enter Class Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" CssClass="formlable" Text="Select Subject: " Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="lblMiddleName5" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpSubject" runat="server" AutoPostBack="True" Height="29px" Width="195px" DataSourceID="SqlDataSource3" DataTextField="SubjectName" DataValueField="SubjectId">
                                                    </asp:DropDownList><%--OnSelectedIndexChanged="drpSubject_SelectedIndexChanged"--%>
                                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                        SelectCommand="SELECT        0 AS SubjectId, '--Select--' AS SubjectName
UNION
SELECT tblSubject.SubjectId, tblSubject.SubjectName
 FROM tblSubject INNER JOIN tblEmpAssignSubject ON tblSubject.SubjectId = tblEmpAssignSubject.SubjectId AND tblSubject.CourseId = tblEmpAssignSubject.CourseId AND tblSubject.BranchId = tblEmpAssignSubject.BranchId AND tblSubject.ClassId = tblEmpAssignSubject.ClassId AND tblSubject.OrgId = tblEmpAssignSubject.OrgId WHERE (tblSubject.CourseId = @CourseId) AND (tblSubject.BranchId = @BranchId) AND (tblSubject.ClassId = @ClassId) AND (tblSubject.OrgId = @OrgId) and  (tblEmpAssignSubject.UserCode=(
select usercode from tblUser where OrgId=@OrgId and UserName=@UserName))">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlCourse" Name="CourseId" PropertyName="SelectedValue" />
                                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchId" PropertyName="SelectedValue" />
                                                            <asp:ControlParameter ControlID="ddlClass" Name="ClassId" PropertyName="SelectedValue" />
                                                            <asp:SessionParameter Name="OrgId" SessionField="OrgId" />
                                                            <asp:SessionParameter Name="UserName" SessionField="UserName" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Enter Class Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style14">&nbsp;</td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="lblMiddleName12" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Test Name : "></asp:Label>
                                                    <asp:Label ID="lblMiddleName11" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTest" runat="server" DataSourceID="SqlDataSource1" DataTextField="TestName" DataValueField="TestId" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                                        SelectCommand="select 0 as [TestId],'--Select--' as [TestName] union SELECT [TestId], [TestName] FROM [tblTest] WHERE 
(
([OrgId] = @OrgId) AND ([CourseId] = @CourseId) AND ([BranchId] = @BranchId) AND ([ClassId] = @ClassId)
AND ([SubjectId] = @SubjectId)
)"
                                                        OnSelected="SqlDataSource1_Selected">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="OrgId" SessionField="OrgId" Type="Int32" />
                                                            <asp:ControlParameter ControlID="ddlCourse" Name="CourseId" PropertyName="SelectedValue" Type="Int16" />
                                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchId" PropertyName="SelectedValue" Type="Int16" />
                                                            <asp:ControlParameter ControlID="ddlClass" Name="ClassId" PropertyName="SelectedValue" Type="Int16" />
                                                            <asp:ControlParameter ControlID="drpSubject" Name="SubjectId" PropertyName="SelectedValue" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFirstName" runat="server" CssClass="formlable" Font-Bold="True" Text="Select Pattern : " Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPattern" runat="server" Height="38px" Visible="False" Width="200px">
                                                        <asp:ListItem>Select Pattern</asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style16"></td>
                                                <td class="auto-style17">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                            </tr>

                                        </table>
                                     <%--   <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn-primary" Text="View Questions" />--%>

                                          <table class="auto-style2" style="border: 3px solid #0099FF; margin: 3px;">
                                               <tr>
                            <th colspan="2" style="background-color:darkblue; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>All Test Questions...</li>
                                </ul>
                            </th>
                        </tr>
                                              <tr>         
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" AllowPaging="True"
                                            AutoGenerateColumns="False" DataKeyNames="Id,Answer" DataSourceID="SqlDataSource2" Width="800px"
                                            OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" CausesValidation="False" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" CausesValidation="False" />
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="False" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                                <asp:TemplateField HeaderText="Question" SortExpression="Question">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Question" runat="server" Text='<%# Eval("Question") %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Image Question">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image2" Width="30px" Height="30px" runat="server" />
                                                    </ItemTemplate>
                                                    <%-- <EditItemTemplate>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="90px"/>
                                                        </EditItemTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Option A" SortExpression="optA">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="optA" runat="server" Text='<%# Eval("optA") %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("optA") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Option B" SortExpression="optB">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="optB" runat="server" Text='<%# Eval("optB") %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("optB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Option C" SortExpression="optC">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="optC" runat="server" Text='<%# Eval("optC") %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("optC") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Option D" SortExpression="optD">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="optD" runat="server" Text='<%# Eval("optD") %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("optD") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Answer" SortExpression="Answer">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlAnswer" runat="server" Width="100px">
                                                            <asp:ListItem>Option A</asp:ListItem>
                                                            <asp:ListItem>Option B</asp:ListItem>
                                                            <asp:ListItem>Option C</asp:ListItem>
                                                            <asp:ListItem>Option D</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                        </asp:GridView></tr> 
                                              <tr>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                                            DeleteCommand="DELETE FROM [tblQuestion] WHERE [Id] = @Id"
                                            InsertCommand="INSERT INTO [tblQuestion] ([Question], [ImgQuestion], [optA], [optB], [optC], [optD], [Answer]) 
                                                VALUES (@Question, @ImgQuestion, @optA, @optB, @optC, @optD, @Answer)"
                                            SelectCommand="SELECT tblQuestion.Id, tblQuestion.Question, tblQuestion.ImgQuestion, tblQuestion.optA, tblQuestion.optB, tblQuestion.optC, tblQuestion.optD, tblQuestion.Answer FROM tblQuestion INNER JOIN tblTest ON tblQuestion.TestId = tblTest.TestId AND tblQuestion.OrgId = tblTest.OrgId WHERE (tblQuestion.OrgId = @OrgId) AND (tblTest.CourseId = @CourseId) AND (tblTest.BranchId = @BranchId) AND (tblTest.ClassId = @ClassId) AND (tblTest.SubjectId = @SubjectId) AND ( tblTest.TestId=@TestId)"
                                            UpdateCommand="UPDATE [tblQuestion] SET [Question] = @Question, [ImgQuestion] = @ImgQuestion, [optA] = @optA, [optB] = @optB,[optC] = @optC, [optD] = @optD, [Answer] = @Answer WHERE[Id] = @Id">
                                            <DeleteParameters>
                                                <asp:Parameter Name="Id" Type="Int32" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="Question" Type="String" />
                                                <asp:Parameter Name="ImgQuestion" Type="Object" />
                                                <asp:Parameter Name="optA" Type="String" />
                                                <asp:Parameter Name="optB" Type="String" />
                                                <asp:Parameter Name="optC" Type="String" />
                                                <asp:Parameter Name="optD" Type="String" />
                                                <asp:Parameter Name="Answer" Type="String" />
                                            </InsertParameters>
                                            <SelectParameters>

                                                <asp:SessionParameter Name="OrgId" SessionField="OrgId" Type="Int32" />
                                                <asp:ControlParameter ControlID="ddlCourse" Name="CourseId" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchId" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlClass" Name="ClassId" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="drpSubject" Name="SubjectId" PropertyName="SelectedValue" />
                                                <asp:ControlParameter ControlID="ddlTest" Name="TestId" PropertyName="SelectedValue" />
                                            </SelectParameters>

                                            <UpdateParameters>
                                                <asp:Parameter Name="Question" />
                                                <asp:Parameter Name="ImgQuestion" />
                                                <asp:Parameter Name="optA" />
                                                <asp:Parameter Name="optB" />
                                                <asp:Parameter Name="optC" />
                                                <asp:Parameter Name="optD" />
                                                <asp:Parameter Name="Answer" />
                                                <asp:Parameter Name="Id" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource></tr>
                                              <tr>
                                                <td class="auto-style16"></td>
                                                <td class="auto-style17">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                                <td class="auto-style18">&nbsp;</td>
                                            </tr>
                                              </table>
                                    </asp:Panel>
                                </center>

                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />

</asp:Content>
