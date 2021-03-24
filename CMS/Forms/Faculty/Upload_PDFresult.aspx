<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="Upload_PDFresult.aspx.cs" Inherits="CMS.Forms.Faculty.Upload_PDFresult" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Image ID="PleaseWaitImage" ImageUrl="~/images/please_wait.gif" AlternateText="Processing"
                runat="server" Height="42px" Width="121px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height:900px; width: 920px;">
        <asp:Panel ID="Panel_SendMessage" runat="server" Visible="true" Style="height:900px;
            width: 100%; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Upload Result</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SendMessage" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>

                    <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto;">
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse" Text="Select Course :" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select Course !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" Text="Select Branch :" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Select Branch !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server" ></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlClass0" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lblSemester" runat="server" Text="Select Semester :"></asp:Label>--%>
                                    <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%>
                                    <asp:Label ID="Label11" runat="server" Text="Academic Year :"></asp:Label>
                                    <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlAcademicyear" runat="server" width="180" AutoPostBack="True" OnSelectedIndexChanged="ddlAcademicyear_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch0" runat="server" ControlToValidate="ddlAcademicyear" ErrorMessage="Please Select Academic Year !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label3" Text="Test Name :" runat="server" ></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTestName" runat="server" width="180"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName" ErrorMessage="Please Enter Test Name !!!" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Choose File :"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" accept=".pdf"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1" 
                                        ErrorMessage="Please Choose PDF File !!!" ForeColor="Red" ValidationGroup="grpSave">*</asp:RequiredFieldValidator>
                                   
                                    <asp:RegularExpressionValidator
                    id="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Only PDF files are allowed!"
                    ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                    ControlToValidate="FileUpload1" CssClass="text-red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>


                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn-primary form-control" OnClick="btnUpload_Click" Text="Upload" ValidationGroup="grpSave" />
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style10" style="color:red" colspan="4">Upload pdf only with maximum size of 1MB </td>
                            </tr>

                        </table>
                    </div>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Height="650px" HorizontalAlign="Center"  Width="100%"  >
                             <center>      
                                 <div style="overflow: scroll; height:650px ">
                        <asp:GridView ID="grdResults" runat="server" CellPadding="4" DataKeyNames="TestId,TestName,AcademicYear,FileName,OrgId,UploadDate"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px" EmptyDataText="No record found">
                                    <Columns>
                                        <asp:BoundField DataField="TestName" HeaderText="Test Name" />
                                        <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                        <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year" />
                                        <asp:BoundField DataField="UploadDate" HeaderText="Upload Date" />
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" Text="Delete"
                                                    OnClick="lnkBtnDelete_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>

                                 </div>
                       </center> </asp:Panel>
                        
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grpSave" ShowMessageBox="True" />
                        <br />
                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>

        </asp:Panel>
    </div>

</asp:Content>
