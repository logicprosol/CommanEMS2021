<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="HRCreateAnnouncement.aspx.cs" Inherits="CMS.Forms.HR.HRCreateAnnouncement" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">


        function CheckAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdSender.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
        function CheckAllStaff(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdFacultySender.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function TestCheckBox() {

            if (Page_ClientValidate()) {
                var TargetBaseControl = document.getElementById('<%= GrdSender.ClientID %>');

                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    //get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");

                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                            return true;
                    alert("Select at least one Student!!!", "Warning");
                    return false;
                }

                TargetBaseControl = document.getElementById('<%= GrdFacultySender.ClientID %>');

                //get target child control.

                var TargetChildControl = "chkbox";

                //get all the control of the type INPUT in the base control.
                var Inputs = TargetBaseControl.getElementsByTagName("input");

                for (var n = 0; n < Inputs.length; ++n)
                    if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                        return true;

                alert("Select at least one Faculty!!!", "Warning");

                return false;
            }


        }
    </script>
    <script type="text/vbscript">
      Function MyVbAlert(msg,title)
        MsgBox(msg,title)
      End Function
    </script>
    <style type="text/css">
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            margin-bottom: 0px;
        }
        .auto-style4 {
            overflow: scroll;
            height: 450px;
        }
        .auto-style5 {
            height: 12px;
        }
        .auto-style6 {
            width: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSend"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
             <div style=" width: 920px; margin-top: 0px; border: medium double#0C7BFA;"><%--height: 900px;--%>
                <div id="div1" align="center">
                    <asp:Panel ID="Panel3" runat="server"  Width="920"><%--Height="900"--%>
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>Create Announcement</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                        <div id="div2" align="center">
                            <table border="0" width="800px" align="center" cellspacing="2px">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblSendTo" runat="server" Text="Send To : "></asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rbtnSender" runat="server" RepeatDirection="Horizontal"
                                            CssClass="radio" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rbtnSender_SelectedIndexChanged">
                                            <asp:ListItem Text="Student" Selected="True" Value="Student"> </asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Panel ID="Panel1" runat="server" Width="800px" Height="510px" Visible="true"
                                class="well well-large">
                                <table border="0" width="800px" align="center" cellspacing="2px">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblCourse" runat="server" Text="Course : "></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select Course !!!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranch" runat="server" Text="Branch : "></asp:Label>
                                            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Select Branch !!!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="margin-left: 40px">
                                            <asp:Label ID="lblClass" runat="server" Text="Class : "></asp:Label>
                                            <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class !!!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="220px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="220px">
                                                <asp:ListItem Text="Select" Value="Select">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="margin-left: 40px">
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="220px">
                                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">
                                        </td>
                                        <td class="auto-style5">
                                        </td>
                                        <td class="auto-style5">
                                        </td>
                                        <td class="auto-style5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                              <div class="auto-style4">
                                            <asp:GridView ID="GrdSender" runat="server" CellPadding="4" DataKeyNames="UserCode,StudentName"
                                                Width="750px" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                BackColor="White" BorderWidth="1px" AllowPaging="false" PageSize="4" OnPageIndexChanging="GrdSender_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="StudentName" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All" onclick=" CheckAll(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" ForeColor="red"/>
                                              <%--  <EmptyDataTemplate>NO DATA FOUND.</EmptyDataTemplate> --%>
                                               <EmptyDataRowStyle BorderStyle="None" />
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
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
                        </div>
                        <div>
                            <asp:Panel ID="Panel2" runat="server" Width="800px" Height="500px" Visible="false"
                                class="well well-large">
                                <table border="0" align="left" width="100%">
                                    <tr>
                                        <td class="auto-style6">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department : "></asp:Label>
                                            <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please Select Department !!!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblFacultyType" runat="server" Text="Faculty Type : "></asp:Label>
                                            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvddlDesignation" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please Select Designation!!!" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation : "></asp:Label>
                                            <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvrbtnFacultyType" runat="server" ControlToValidate="rbtnFacultyType" ErrorMessage="Please Select Designation type!!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" Width="220px">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="rbtnFacultyType" runat="server" AutoPostBack="true" class="radio" OnSelectedIndexChanged="rbtnFacultyType_SelectedIndexChanged" RepeatDirection="Horizontal" Width="220px">
                                                <asp:ListItem Text="Teaching" Value="1">Teaching</asp:ListItem>
                                                <asp:ListItem Text="NonTeaching" Value="2">Non Teaching</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" Width="220px">
                                                <asp:ListItem Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">
                                            &nbsp;</td>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                              <div style="overflow: scroll; height:400px ">
                                                  <asp:GridView ID="GrdFacultySender" runat="server" AllowPaging="false" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="UserCode,FullName" OnPageIndexChanging="GrdFacultySender_PageIndexChanging" OnSelectedIndexChanged="GrdFacultySender_SelectedIndexChanged" PageSize="4" Width="750px" EmptyDataText="No record present">
                                                      <Columns>
                                                          <asp:BoundField DataField="UserCode" HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                          <ItemStyle HorizontalAlign="Center" />
                                                          </asp:BoundField>
                                                          <asp:BoundField DataField="FullName" HeaderText="FullName" ItemStyle-HorizontalAlign="Center">
                                                          <ItemStyle HorizontalAlign="Center" />
                                                          </asp:BoundField>
                                                          <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                              <HeaderTemplate>
                                                                  <asp:CheckBox ID="chkboxSelectAllStaff" runat="server" onclick=" CheckAllStaff(this)" Text="Select All" />
                                                              </HeaderTemplate>
                                                              <ItemTemplate>
                                                                  <asp:CheckBox ID="chkbox" runat="server" />
                                                              </ItemTemplate>
                                                              <ItemStyle HorizontalAlign="Center" />
                                                          </asp:TemplateField>
                                                      </Columns>
                                                      <EditRowStyle BorderStyle="None" />
                                                      <EmptyDataRowStyle BorderStyle="None" ForeColor="Red" HorizontalAlign="Center" />
                                                      <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                      <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                      <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Center" />
                                                      <RowStyle BackColor="White" ForeColor="#003399" />
                                                      <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
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
                        </div>
                        <div>
                            <table width="700px" align="center">
                                <tr>
                                    <td colspan="3">
                                        <table width="700px">
                                            <tr>
                                                <td align="left" width="60px" class="auto-style2">
                                                    <asp:Label ID="lblSubject" runat="server" Text="Subject : "></asp:Label>
                                                    <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style2">
                                                    <asp:TextBox ID="txtSubject" runat="server" Width="100%" CssClass="auto-style3"></asp:TextBox>
                                                    <%--  <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server" ValidationGroup="Save" ErrorMessage="Please Enter the Subject" ControlToValidate="txtSubject" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" width="60px">
                                                    <asp:Label ID="lblMessage" runat="server" Text="Message : "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Please Enter the Subject" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="left">
                                        <asp:TextBox ID="txtMessage" runat="server" Rows="4" Columns="100" TextMode="MultiLine" style = "resize:none"
                                            Width="100%" Height="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="200px">
                                        <asp:Button ID="btnSend" runat="server" CausesValidation="true" class="btn btn-primary" OnClick="btnSend_Click" OnClientClick="javascript:return TestCheckBox();" Text="Send" ValidationGroup="Save" />
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="200px">
                                        &nbsp;</td>
                                    <td align="left" width="50px">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" onselectedindexchanged="ddlDivision_SelectedIndexChanged" Visible="False" Width="220px">
                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>