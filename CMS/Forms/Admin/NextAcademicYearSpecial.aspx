<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NextAcademicYearSpecial.aspx.cs"
  MasterPageFile="~/Forms/Admin/Admin.Master" Inherits="CMS.Forms.Admin.NextAcademicYearSpecial" %>



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


        function CheckAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdStudent.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function TestCheckBox() {

            //if (Page_ClientValidate())
            {
                var TargetBaseControl = document.getElementById('<%= GrdStudent.ClientID %>');

                if (TargetBaseControl != null) {
                    var TargetChildControl = "chkbox";

                    //get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");

                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
                            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
                            Inputs[n].checked) {
                            ConfirmUpgrade();// 
                            return true;
                        }

                    alert("Select at least one Student!!!", "Warning");
                    return false;
                }
            }
        }

        function printpage() {

            var getpanel = document.getElementById("<%= pnlContents.ClientID%>");
            var MainWindow = window.open('', '', 'height=500,width=800');
            MainWindow.document.write('<html><head><title>Print Page</title>');
            MainWindow.document.write('</head><body>');
            MainWindow.document.write(getpanel.innerHTML);
            MainWindow.document.write('</body></html>');
            MainWindow.document.close();
            setTimeout(function () {
                MainWindow.print();
            }, 500);
            return false;

        }


        function ConfirmUpgrade() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Upgrade data?")) {
                confirm_value.value = "Yes";

            } else {
                confirm_value.value = "No";

            }
            document.forms[0].appendChild(confirm_value);
        }    </script>


    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }

        .overlay {
            position: absolute;
            width: 50%;
            height: 50%;
            z-index: 10;
            background-color: rgba(0,0,0,0.5); /*dim the background*/
        }
    </style>
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: Arial;
        }

        .modal {
            z-index: 100;
            height: 900px;
            width: 1000px;
            right: 10px;
            left: 410px;
            top: 400px;
            background-color: snow;
            filter: alpha(opacity=60);
            opacity: 0.4;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 100px;
            background-color: White;
            border-radius: 10px;
            opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Document">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="../../images/load2.gif" />

                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div style="height: 900px; width: 900px">
        <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
                    <table width="95%">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Transfer  To Next Academic year</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #0000FF">
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
                                            <asp:Label ID="Label8" runat="server" Text="Academic Year : "></asp:Label>
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
                                        <td style="text-align: left">

                                            <asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged"
                                                Width="86%">
                                            </asp:DropDownList>


                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCasteCategory" runat="server" Text="CasteCategory : " CssClass="formlable" Visible="False"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblStudName" runat="server" Text="Student Name : " CssClass="formlable" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year : " CssClass="formlable" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCasteCategory" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlCasteCategory_SelectedIndexChanged"
                                                Width="85%" Visible="False">
                                                <asp:ListItem Value="1">Regular</asp:ListItem>
                                                <asp:ListItem Value="2">Exempted</asp:ListItem>
                                                <asp:ListItem Value="3">RTE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtStudName" runat="server" Width="90%" OnTextChanged="txtStudName_TextChanged"
                                                AutoPostBack="true" Visible="False"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left">
                                            <%--<asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged"
                                                Width="86%">
                                            </asp:DropDownList>--%>
                                            <%--<asp:Button ID="BtnUpgrade" runat="server" class="btn btn-primary" OnClick="BtnUpgrade_Click" OnClientClick="javascript:return TestCheckBox();" Text="Upgrade" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <div style="max-height: 660px; overflow: auto;">
                                    <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="AdmissionID,StudentName,CourseName,BranchName,ClassName"
                                        Width="98%" AutoGenerateColumns="False" BorderColor="#3366CC"
                                        BorderStyle="None" BackColor="White" BorderWidth="1px" PageSize="20">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SelectAll" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server"  AutoPostBack="true" Text="Select All" onclick=" CheckAll(this)" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="true" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Academic Year" ItemStyle-HorizontalAlign="Center">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>

                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="AdmissionID" ItemStyle-HorizontalAlign="Center">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtAdmissionID" runat="server" Text='<%# Bind("AdmissionID") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdmissionid" runat="server" Text='<%# Bind("AdmissionID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UserCode" ItemStyle-HorizontalAlign="Center">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtUserCode" runat="server" Text='<%# Bind("UserCode") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserCode" runat="server" Text='<%# Bind("UserCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>


                                             <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtBranch" runat="server" Text='<%# Bind("BranchId") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("BranchId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Class" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtClass" runat="server" Text='<%# Bind("ClassId") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" Text='<%# Bind("ClassId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="AcademicID" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtAcademicID" runat="server" Text='<%# Bind("AcademicYearId") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAcademicID" runat="server" Text='<%# Bind("AcademicYearId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>



                                            <asp:BoundField HeaderText="Course" ItemStyle-HorizontalAlign="Center" DataField="CourseName">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" DataField="BranchName">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="ClassName">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="Student Name " ItemStyle-HorizontalAlign="Center" DataField="StudentName">
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
                        <tr>
                            <td style="height: 20px;"></td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3" style="display: none;">
                    <asp:Panel ID="pnlContents" runat="server">
                        <center>
                            <h1>Student List</h1>
                            <br />
                            <br />
                            <asp:GridView ID="gvPrint" runat="server" BorderStyle="Groove" CellSpacing="5"
                                CssClass="" GridLines="None" Width="31%" Style="margin-left: -19px;" OnRowDataBound="gvPrint_RowDataBound">
                                <EmptyDataRowStyle BorderStyle="None" HorizontalAlign="Justify" Width="50px" />
                                <HeaderStyle BorderStyle="None" />
                            </asp:GridView>
                        </center>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="height: auto; width: 900px; border: medium double#0C7BFA;">
                    <table width="95%">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Transfer To Next Academic year</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #0000FF">
                                    <tr>
                                        <%--<td>
                                            <asp:Label ID="Label10" runat="server" Text="Orgnization : "></asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpcourse" Display="Dynamic" ErrorMessage="Select Class" ForeColor="red" InitialValue="0" TargetControlID="txtCountryId" ValidationGroup="ValidateCourse">*</asp:RequiredFieldValidator>
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Course : "></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvCountryId" runat="server" ControlToValidate="drpcourse" Display="Dynamic" ErrorMessage="Select Class" ForeColor="red" InitialValue="0" TargetControlID="txtCountryId" ValidationGroup="ValidateCourse">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Branch : "></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvCountryId1" runat="server" ControlToValidate="drpbranch" Display="Dynamic" ErrorMessage="Select Branch" ForeColor="red" InitialValue="0" TargetControlID="txtCountryId" ValidationGroup="ValidateCourse">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Class : "></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvCountryId2" runat="server" ControlToValidate="drpclass" Display="Dynamic" ErrorMessage="Select Class" ForeColor="red" InitialValue="0" TargetControlID="txtCountryId" ValidationGroup="ValidateCourse">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Academic Year : "></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvCountryId0" runat="server" ControlToValidate="DDLAcademicYear" Display="Dynamic" ErrorMessage="Select Academic year" ForeColor="red" InitialValue="0" TargetControlID="txtCountryId" ValidationGroup="ValidateCourse">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                       <%--  <td>
                                            <asp:DropDownList ID="ddlOrg" runat="server" Width="180px" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged"
                                                AutoPostBack="true"> <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td>
                                            <asp:DropDownList ID="drpcourse" runat="server" Width="180px" OnSelectedIndexChanged="drpcourse_SelectedIndexChanged1"
                                                AutoPostBack="true">  <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpbranch" runat="server" Width="180px" AutoPostBack="true"
                                                OnSelectedIndexChanged="drpbranch_SelectedIndexChanged1">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpclass" runat="server" Width="180px"
                                                OnSelectedIndexChanged="drpClass_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: left">

                                            <asp:DropDownList ID="drpacedemicyear1" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="drpacedemicyear1_SelectedIndexChanged"
                                                Width="86%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="2">
                                            <asp:Label ID="Shwmsg" runat="server" Font-Bold="true" Font-Size="Medium" Visible="false" ForeColor="Red"></asp:Label></td>
                               
                            <td style="text-align: left">
                                <%--<asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails"
                                                AutoPostBack="true" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged"
                                                Width="86%">
                                            </asp:DropDownList>--%>
                                <asp:Button ID="BtnAddFees" Visible="false" runat="server" class="btn btn-success" OnClick="BtnAddFees_Click" Text="Add Fees" />
                              
                                <asp:Button ID="Button1" runat="server" Visible="true" class="btn btn-primary" OnClick="BtnUpgrade_Click" Text="Promote" OnClientClick="javascript:return TestCheckBox();" ValidationGroup="ValidateCourse" />
                              

                            </td></tr>
                        
                    </table>
                    </td>
                        </tr>                        
                        <tr>
                            <td>
                                <br />

                            </td>
                        </tr>
                    </table>
                </div>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>



