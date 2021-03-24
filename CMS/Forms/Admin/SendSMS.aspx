<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="CMS.Forms.Admin.SendSMS" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
     <script type="text/javascript">
        function CheckAllStudent(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdStudent.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
</script>
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
    <div style="height: 900px; width: 900px">
        <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">       
            <ContentTemplate>
                <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
                    <table width="95%">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Send SMS</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Course : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Branch : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Class : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Division : "></asp:Label>
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
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="180px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDivision" runat="server" Width="180px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCasteCategory" runat="server" Text="CasteCategory : " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblStudName" runat="server" Text="Student Name : " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year : " CssClass="formlable"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCasteCategory" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlCasteCategory_SelectedIndexChanged"
                                                Width="85%">
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtStudName" runat="server" Width="90%" OnTextChanged="txtStudName_TextChanged"
                                                AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged"
                                                Width="86%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>                        
                        <tr>
                            <td>
                                <div style="max-height: 500px; overflow: auto;">
                                    <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="AdmissionID,StudentName,ParentMobile"
                                        Width="98%" AutoGenerateColumns="False" BorderColor="#3366CC"
                                        BorderStyle="None" BackColor="White" BorderWidth="1px">
                                        <Columns>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllStudent(this)"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="checkbox" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            <asp:BoundField HeaderText="Code" ItemStyle-HorizontalAlign="Center" DataField="UserCode" />
                                            <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                                        OnClick="lnkBtnStudentName_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <%--  <asp:BoundField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" DataField="Mobile" />--%>
                                            <asp:BoundField HeaderText="Parent" ItemStyle-HorizontalAlign="Center" DataField="ParentName" />
                                            <asp:BoundField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" DataField="ParentMobile" />
                                        </Columns>
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" />
                                        <EmptyDataTemplate>
                                            No Data Found.
                                        </EmptyDataTemplate>
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                        <td><br /></td>
                        </tr>
                        <tr>
                            <td>
                                  <asp:Label ID="lblMessage" Text="Message :" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="100px" MaxLength="160" Width="65%"></asp:TextBox>
                                     
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSend" Text="Send" runat="server" class="btn btn-primary" CausesValidation="false"
                                        OnClick="btnSend_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
