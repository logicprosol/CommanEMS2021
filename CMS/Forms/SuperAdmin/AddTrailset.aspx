<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="AddTrailset.aspx.cs" Inherits="CMS.Forms.SuperAdmin.AddTrailset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script type = "text/javascript">
        function ConfirmDelete() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmUpdate() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Update data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel_AddNewCollege" runat="server" Style="height: 895px; width: 930px;
                    border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Add Trailset</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel_Course" runat="server" align="center" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table border="0" width="80%" align="center" cellspacing="2px">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOrganization" runat="server" Text="Organization :"></asp:Label><asp:Label
                                            ID="Label3" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDL_Organization" runat="server"  ToolTip="Organization"
                                            ValidationGroup="ValidateUniversity" 
                                            Enabled="False" Height="33px" Width="181px">
                                     
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvddlOrganization" runat="server" ErrorMessage="Please Select Organization"
                                            InitialValue="0" ForeColor="red" ControlToValidate="DDL_Organization" ValidationGroup="ValidateUniversity">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblValidDate" runat="server" Text="Valid Date :"></asp:Label><asp:Label
                                            ID="Label6" ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValidDate" runat="server" Enabled="False" ToolTip="Valid Date" ValidationGroup="ValidateUniversity" ></asp:TextBox>
                                         <asp:CalendarExtender ID="txt_BirthDate_CalendarExtender" runat="server" DaysModeTitleFormat="MM/dd/yyyy" Format="MM/dd/yyyy" TargetControlID="txtValidDate">
                                </asp:CalendarExtender>
                                              
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvValidDate" runat="server" ControlToValidate="txtValidDate"
                                            ForeColor="red" ErrorMessage="Please Enter Valid Date !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSenderId" runat="server" Text="Sender Id :"></asp:Label><asp:Label ID="Label7"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSenderId" runat="server" Enabled="False" ToolTip="Sender Id" ValidationGroup="ValidateUniversity" ></asp:TextBox>
                                    </td>
                                    <td>
                                        <%--<asp:RequiredFieldValidator ID="ffSenderId" runat="server" ControlToValidate="txtSenderId"
                                            ForeColor="red" ErrorMessage="Please Enter Sender Id !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAppKey" runat="server" Text="App Key :"></asp:Label><asp:Label ID="Label2"
                                            ForeColor="Red" runat="server" Text="*"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAppKey" runat="server" Enabled="False" ToolTip="App Key" ValidationGroup="ValidateUniversity" ></asp:TextBox>
                                    </td>
                                    <td>
                                        <%--<asp:RequiredFieldValidator ID="ffAppKey" runat="server" ControlToValidate="txtAppKey"
                                            ForeColor="red" ErrorMessage="Please Enter App Key !!!" ValidationGroup="ValidateUniversity"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateUniversity"
                                            CausesValidation="false" OnClick="btnNew_Click" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ValidateUniversity"
                                            OnClick="btnSave_Click" Visible="False" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateUniversity" OnClientClick = "ConfirmUpdate()" OnClick="btnUpdate_Click" Visible="False" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateUniversity" OnClientClick = "ConfirmDelete()" CausesValidation="false" OnClick="btnDelete_Click" Visible="False" />
                                        <asp:Button ID="btnCancle" runat="server" Text="Cancel" class="btn btn-primary" CausesValidation="false"
                                            ValidationGroup="ValidateUniversity" OnClick="btnCancle_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="width: 80%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel1" runat="server" class=" well well-large" Width="95%" Height="250px" ScrollBars="Auto">
                                            <asp:GridView ID="GrdTrailset" runat="server" CellPadding="4" DataKeyNames="id,date,OrgId,OrgName,SenderId,AppKey"
                                                Width="100%"  AutoGenerateColumns="False" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                                BorderWidth="1px" >
                                                <Columns>
                                                    <asp:BoundField DataField="OrgId" HeaderText="Organization Id" />
                                                    <asp:TemplateField HeaderText="Organization Name" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="OrgName" runat="server" Text='<%#Eval("OrgName") %>'
                                                                OnClick="lnkBtnOrgName_Click" CausesValidation="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="date" HeaderText="Vadil Date" />
                                                    <asp:BoundField DataField="SenderId" HeaderText="Sender Id" />
                                                    <asp:BoundField DataField="AppKey" HeaderText="App Key" />
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
                            </table>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
