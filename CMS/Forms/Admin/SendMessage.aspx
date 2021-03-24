<%@ Page Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="~/Forms/Admin/SendMessage.aspx.cs" Inherits="CMS.Forms.Admin.SendMessage" %>

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

        function CheckAllParent(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdParent.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function CheckAllEmployee(oCheckbox) {

            var GridView2 = document.getElementById("<%=GrdEmployee.ClientID %>");
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
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div style="height:auto; width: 920px;">
        <asp:Panel ID="Panel_SendMessage" runat="server" Visible="true" Style="height:1030px;
            width: 100%; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Send Message</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SendMessage" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>

                <!-- Select Sender Type  -->

                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="4">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:RadioButtonList ID="rbtlSendMessage" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                    Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rbtlSendMessage_SelectedIndexChanged">
                                    <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                    <%--<asp:ListItem Text="Parents" Value="Parents"></asp:ListItem>--%>
                                    <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>


                    <!-- Student /Parent Comman Panel -->

                    <asp:Panel ID="Panel_Student" runat="server" Visible="true" Style="height:500px; width: 80%" class="well well-large">
                        <table style="width: 100%" align="center">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                          <%--  <tr>
                                <td>
                                    <asp:Label ID="lblCourse" Text="Course :" runat="server"></asp:Label>
                                    <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" Text="Branch :" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCourse"
                                        ErrorMessage="Please Select Course" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlClass"
                                        ErrorMessage="Please Select Class" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Class : "></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="margin-left: 40px">
                                    <asp:DropDownList ID="ddlClass" runat="server" Width="220px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblDiv" runat="server" Text="Division : "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDivision" runat="server" Width="220px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ErrorMessage="Please Select Class !!!"
                                        ControlToValidate="ddlClass" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select Division !!!"
                                        ControlToValidate="ddlDivision" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                             <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Course : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Branch : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Class : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Division : " Visible="False"></asp:Label>
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
                                                AutoPostBack="true" Visible="False">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                   
                        </table>
                   
                   <!-- Student Panel -->

                        <asp:Panel ID="Panel_StudentSub" runat="server" Visible="false" Style="height: auto; width: 100%">
                            <table style="width: 100%" align="center">
                                <tr>
                                    <td colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                         <div style="overflow: scroll; height:200px ">
                                        <asp:GridView ID="GrdStudent" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            DataKeyNames="StudentId,StudentName,Mobile" Width="100%" BorderColor="#3366CC" BorderStyle="None"
                                            AllowPaging="False" BackColor="White" BorderWidth="1px">
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
                                                <asp:BoundField HeaderText="Student Code" DataField="StudentId" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="StudentName" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mobile" DataField="Mobile" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
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
                            </table>
                        </asp:Panel>
                   
                    <!-- Parent Panel  -->

                        <asp:Panel ID="Panel_Parent" runat="server" Visible="false" Style="height:300px; width: 100%">
                           <table style="width: 100%" align="center">
                                <tr>
                                    <td colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                         <div style="overflow: scroll; height:200px ">
                                        <asp:GridView ID="GrdParent" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="4" DataKeyNames="UserCode,FullName,FatherName,Mobile"
                                            Width="100%" BorderColor="#3366CC" BorderStyle="None" AllowPaging="false" EmptyDataText="No Records Found"
                                            BackColor="White" BorderWidth="1px" OnPageIndexChanging="GrdParent_PageIndexChanging" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllParent(this)"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="checkbox" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Student Code" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Student Name" DataField="FullName" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Parent Name" DataField="FatherName" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mobile No" DataField="Mobile" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
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
                                             </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                        
                    </asp:Panel>


                    <!-- Employee Panel -->

                    <asp:Panel ID="Panel_Employee" runat="server" Visible="false" Style="height:500px; width:80%" class="well well-large">
                        <table style="width:100%;">
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblDepartment" Text="Select Department :" runat="server"></asp:Label>
                                       <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"> 
                                    </asp:DropDownList>
                                </td>
                                <td  align="left">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please Select Deparment"
                                                ControlToValidate="ddlDepartment" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDesignationType" runat="server" Text="Designation Type  : "></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:RadioButtonList ID="rbtlDesType" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                                Width="190px" AutoPostBack="true" OnSelectedIndexChanged="rbtlDesType_SelectedIndexChanged">
                                                <asp:ListItem Text="Teaching" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Non Teaching" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                         
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvrbtlDesType" runat="server" ForeColor="Red" ErrorMessage="Please Select Designation type"
                                                ControlToValidate="rbtlDesType"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                             
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Select Designation : "></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                                OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDesignation" runat="server" ForeColor="Red"
                                                ErrorMessage="Please Select Designation" ControlToValidate="ddlDesignation"></asp:RequiredFieldValidator>
                                           
                                        </td>
                                    </tr>

                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                     <div style="overflow: scroll; height:200px ">
                                    <asp:GridView ID="GrdEmployee" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataKeyNames="UserCode,FullName,DesignationName,Mobile" 
                                        Width="100%" BorderColor="#3366CC" BorderStyle="None" AllowPaging="false" 
                                        BackColor="White" BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllEmployee(this)"
                                                        Text="Select All" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkbox" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Employee Code" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Employee Name" DataField="FullName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Designation" DataField="DesignationName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Mobile No" DataField="Mobile" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
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
                                         </div>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                    <!-- Message Panel -->

                    <asp:Panel ID="Panel_Message" runat="server" Visible="false" Style="height: auto; width:80%" class="well well-large">
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblMessage" Text="Message :" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="100px" MaxLength="160" Width="65%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnSend" Text="Send" runat="server" class="btn btn-primary" CausesValidation="false"
                                        OnClick="btnSend_Click " />

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
