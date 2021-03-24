<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminCreateAnnouncement.aspx.cs" Inherits="CMS.Forms.Admin.AdminCreateAnnouncement" %>

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

            if (Page_ClientValidate()) 
            {
                var TargetBaseControl = document.getElementById('<%= GrdSender.ClientID %>');

                if (TargetBaseControl != null) 
                {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSend"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <div style="height: 900px; width: 920px; margin-top: 0px; border: medium double#0C7BFA;">
                <div id="div1" align="center">
                    <asp:Panel ID="Panel3" runat="server" Height="900" Width="920">
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
                            <table border="0" width="700px" align="center" cellspacing="2px">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblSendTo" runat="server" Text="Send To : " Font-Bold="True"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:RadioButtonList ID="rbtnSender" runat="server" RepeatDirection="Horizontal"
                                            CssClass="radio" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rbtnSender_SelectedIndexChanged">
                                            <asp:ListItem Text="Student" Selected="True" Value="Student"> </asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Panel ID="Panel1" runat="server" Width="700px" Height="400px" Visible="true"
                                class="well well-large">
                                <table border="0" width="700px" align="center" cellspacing="2px">
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCourse" runat="server" Text="Course : " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" Width="220px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranch" runat="server" Text="Branch : " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td style="margin-left: 40px">
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="220px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="Select">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ErrorMessage="Please Select Course !!!"
                                                ControlToValidate="ddlCourse" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ErrorMessage="Please Select Branch !!!"
                                                ControlToValidate="ddlBranch" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblClass" runat="server" Text="Class :" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td style="margin-left: 40px">
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="220px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDiv" runat="server" Text="Division : " Visible="False" Font-Bold="True" ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDivision" runat="server" Width="220px" 
                                                onselectedindexchanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true" Visible="False" >
                                                    <asp:ListItem Text="Select" Value="Select" ></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ErrorMessage="Please Select Class !!!"
                                                ControlToValidate="ddlClass" ForeColor="Red" InitialValue="Select" Visible="false"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>

                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="overflow: scroll; height:200px ">
                                            <asp:GridView ID="GrdSender" runat="server" CellPadding="4" DataKeyNames="UserCode,StudentName"
                                                Width="600px" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                BackColor="White" BorderWidth="1px" AllowPaging="false" PageSize="6" OnPageIndexChanging="GrdSender_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="StudentName" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All" onclick=" CheckAll(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" />
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
                            <asp:Panel ID="Panel2" runat="server" Width="700px" Height="400px" Visible="false"
                                class="well well-large">
                                <table border="0" align="left" width="100%">
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department : " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ErrorMessage="Please Select Department !!!"
                                                ControlToValidate="ddlDepartment" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFacultyType" runat="server" Text="Faculty Type : " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="rbtnFacultyType" runat="server" RepeatDirection="Horizontal"
                                                class="radio" Width="220px" OnSelectedIndexChanged="rbtnFacultyType_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Teaching" Value="1">Teaching</asp:ListItem>
                                                <asp:ListItem Text="NonTeaching" Value="2">Non Teaching</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvrbtnFacultyType" runat="server" ErrorMessage="Please Select Designation type!!!"
                                                ControlToValidate="rbtnFacultyType" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDesignation" runat="server" Text="Designation : " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                                <asp:ListItem Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="rfvddlDesignation" runat="server" ErrorMessage="Please Select Designation!!!"
                                                ControlToValidate="ddlDesignation" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                              <div style="overflow: scroll; height:200px ">
                                            <asp:GridView ID="GrdFacultySender" runat="server" CellPadding="4" DataKeyNames="UserCode,FullName"
                                                Width="600px" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                                OnSelectedIndexChanged="GrdFacultySender_SelectedIndexChanged" BackColor="White"
                                                BorderWidth="1px" AllowPaging="false" PageSize="6" OnPageIndexChanging="GrdFacultySender_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="FullName" DataField="FullName" ItemStyle-HorizontalAlign="Center">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkboxSelectAllStaff" runat="server" Text="Select All" onclick=" CheckAllStaff(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkbox" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BorderStyle="None" />
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
                            <table width="700px" align="center">
                                <tr>
                                    <td colspan="3">
                                        <table width="700px">
                                            <tr>
                                                <td align="left" width="60px">
                                                    <asp:Label ID="lblSubject" runat="server" Text="Subject : " Font-Bold="True"></asp:Label>
                                                    <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSubject" runat="server" Width="102%"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <%--  <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server" ValidationGroup="Save" ErrorMessage="Please Enter the Subject" ControlToValidate="txtSubject" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="2" align="left">
                                                    <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server" ValidationGroup="Save"
                                                        ErrorMessage="Please Enter the Subject" ControlToValidate="txtSubject" ForeColor="Red"
                                                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblMessage" runat="server" Text="Message : " Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="left">
                                        <asp:TextBox ID="txtMessage" runat="server" Rows="4" Columns="100" TextMode="MultiLine"
                                            Width="100%" Height="100px"></asp:TextBox>
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
                                        <asp:Button ID="btnSend" runat="server" Text="Send" class="btn btn-primary" OnClick="btnSend_Click"
                                            OnClientClick="javascript:return TestCheckBox();" ValidationGroup="Save" CausesValidation="true" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>
             <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>