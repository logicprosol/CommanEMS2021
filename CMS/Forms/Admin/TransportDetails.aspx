<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="TransportDetails.aspx.cs" Inherits="CMS.Forms.Admin.TransportDetails" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->
    <!--  For Tab Navigation Use This jQuery  -->
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS: compiled and minified -->
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Example plugin: Prettify -->
    <!-- Initialize Scripts -->
    <script type="">
        // Activate Google Prettify in this page
        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {
            // Add prettyprint class to pre elements
            $('pre').addClass('prettyprint');
        }); // end document.ready
    </script>


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
        }


        function CheckAllParent(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdAllotRoute.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

        function CheckAllParent1(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdAssignRout.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 950px; width: 920px;">
        <asp:Panel ID="Panel_TRANSPORT" runat="server" align="center" Visible="true" Style="height: 950px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Transport Details</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
                <div class="frmwidth" align="center">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#sp1" data-toggle="tab"><font color="blue">Routes Info</font>
                        </a></li>
                        <li><a href="#sp2" data-toggle="tab"><font color="blue">Board Info</font></a></li>
                        <li><a href="#sp3" data-toggle="tab"><font color="blue">Vehical Info</font></a></li>
                        <li><a href="#sp4" data-toggle="tab"><font color="blue">Driver Info</font></a></li>
                        <li><a href="#sp5" data-toggle="tab"><font color="blue">Allot Driver</font></a></li>
                        <li><a href="#sp6" data-toggle="tab"><font color="blue">Allot Route </font></a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="sp1" class="tab-pane active" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Routs" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRoute" runat="server" Text="Route :"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRoute" runat="server" ToolTip="Route" ValidationGroup="ValidateRouts"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvRoute" runat="server" ErrorMessage="Please Enter Route Name !!!"
                                                    ControlToValidate="txtRoute" ForeColor="red" ValidationGroup="ValidateRouts"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRouteTitle" runat="server" Text=" Route Title:"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRouteTitle" runat="server" ToolTip="RouteTitle" ValidationGroup="ValidateRouts"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvRouteTitle" runat="server" ErrorMessage="Please Enter Route Title"
                                                    ForeColor="red" ControlToValidate="txtRouteTitle" ValidationGroup="ValidateRouts"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAmount" runat="server" Text=" Amount :"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAmount" runat="server" ToolTip="Amount" ValidationGroup="ValidateRouts"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ErrorMessage="Please Enter Amount"
                                                    ForeColor="red" ControlToValidate="txtAmount" ValidationGroup="ValidateRouts"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender ID="ftbeAcademicYear" runat="server" TargetControlID="txtAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewR" runat="server" Text=" Add New" class="btn btn-primary" CausesValidation="false"
                                                    OnClick="btnNewR_Click" ValidationGroup="ValidateRouts" />
                                                <asp:Button ID="btnSaveR" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveR_Click"
                                                    ValidationGroup="ValidateRouts" />
                                                <asp:Button ID="btnUpdateR" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdateR_Click" ValidationGroup="ValidateRouts" OnClientClick = "ConfirmUpdate()" />
                                                <asp:Button ID="btnDeleteR" runat="server" Text="Delete" class="btn btn-primary" OnClick="btnDeleteR_Click" ValidationGroup="ValidateRouts" OnClientClick = "ConfirmDelete()" />
                                                <asp:Button ID="btnCancelR" runat="server" Text="Cancel" class="btn btn-primary"
                                                    OnClick="btnCancelR_Click" CausesValidation="false" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" width="90%" align="center">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdRoute" runat="server" CellPadding="4" DataKeyNames="RouteId,Route,RouteTitle,Amount"
                                                    Width="80%" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" BorderColor="#3366CC"
                                                    BorderStyle="None" OnSelectedIndexChanged="GrdRoute_SelectedIndexChanged" BackColor="White"
                                                    BorderWidth="1px" EnableSortingAndPagingCallbacks="True" OnPageIndexChanging="GrdRoute_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Route" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnRoute" runat="server" OnClick="lnkBtnRoute_Click" Text='<%#Eval("Route") %>'
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Route Title" DataField="RouteTitle" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp2" class="tab-pane " align="center">
                            <asp:UpdatePanel ID="UpdatePanelBoard" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRouteB" runat="server" Text="Select Route :"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged"
                                                    ValidationGroup="ValidateBoard" Width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlRoute" runat="server" ErrorMessage="Please Select Route Name"
                                                    ForeColor="red" ControlToValidate="ddlRoute" InitialValue="Select" TargetControlID="ddlRoute"
                                                    ValidationGroup="ValidateBoard"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBoardTitle" runat="server" Text=" Board Title:"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBoardTitle" runat="server" ToolTip="BoardTitle" ValidationGroup="ValidateBoard"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvBoardTitle" runat="server" ErrorMessage="Please Enter Board Title"
                                                    ForeColor="red" ControlToValidate="txtBoardTitle" ValidationGroup="ValidateBoard"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewB" runat="server" Text=" Add New" class="btn btn-primary" CausesValidation="false"
                                                    OnClick="btnNewB_Click" />
                                                <asp:Button ID="btnSaveB" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveB_Click"
                                                    ValidationGroup="ValidateBoard" />
                                                <asp:Button ID="btnUpdateB" runat="server" Text="Update" class="btn btn-primary"
                                                    OnClick="btnUpdateB_Click" ValidationGroup="ValidateBoard" />
                                                <asp:Button ID="btnDeleteB" runat="server" Text="Delete" class="btn btn-primary"
                                                    OnClick="btnDeleteB_Click" ValidationGroup="ValidateBoard" />
                                                <asp:Button ID="btnCancelB" runat="server" Text="Cancel" class="btn btn-primary"
                                                    OnClick="btnCancelB_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" width="90%" align="center">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdBoard" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="BoardId,RouteId,BoardTitle"
                                                    Width="80%" OnPageIndexChanging="GrdBoard_PageIndexChanging" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="7" OnSelectedIndexChanged="GrdBoard_SelectedIndexChanged"
                                                    BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Board Title" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnBoard" runat="server" Text='<%#Eval("BoardTitle") %>' OnClick="lnkBtnBoard_Click"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp3" class="tab-pane" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Vehicle" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSelectBoard" runat="server" Text="Select Board :"></asp:Label>
                                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="true" ValidationGroup="ValidateVehicle" width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvddlBoard" runat="server" ErrorMessage="Please Select Board Name"
                                                    ForeColor="red" ControlToValidate="ddlBoard" InitialValue="Select" ValidationGroup="ValidateVehicle"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblVehicleType" runat="server" Text="Vehicle Type :"></asp:Label>
                                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVehicleType" runat="server" ToolTip="VehicleType" ValidationGroup="ValidateVehicle"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvVehicleType" runat="server" ErrorMessage="Please Enter Vehicle Type Name !!!"
                                                    ControlToValidate="txtVehicleType" ForeColor="red" ValidationGroup="ValidateVehicle"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblVehicleNumber" runat="server" Text=" Vehicle Number:"></asp:Label>
                                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVehicleNumber" runat="server" ToolTip="VehicleNumber" ValidationGroup="ValidateVehicle"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvVehicleNumber" runat="server" ErrorMessage="Please Enter Vehicle Number"
                                                    ForeColor="red" ControlToValidate="txtVehicleNumber" ValidationGroup="ValidateVehicle"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblVehicleModel" runat="server" Text="Vehicle Model :"></asp:Label>
                                                <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVehicleModel" runat="server" ToolTip="VehicleModel" ValidationGroup="ValidateVehicle"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvVehicleModel" runat="server" ErrorMessage="Please Enter Vehicle Model"
                                                    ForeColor="red" ControlToValidate="txtVehicleModel" ValidationGroup="ValidateVehicle"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblVehicleCapacity" runat="server" Text="Vehicle Capacity:"></asp:Label>
                                                <asp:Label ID="Label18" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVehicleCapacity" runat="server" ToolTip="VehicleCapacity" ValidationGroup="ValidateVehicle"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvVehicleCapacity" runat="server" ErrorMessage="Please Enter Vehicle Capacity"
                                                    ForeColor="red" ControlToValidate="txtVehicleCapacity" ValidationGroup="ValidateVehicle"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnAddV" runat="server" Text="Add New" class="btn btn-primary" CausesValidation="false"
                                                    OnClick="btnAddV_Click" ValidationGroup="ValidateVehicle" />
                                                <asp:Button ID="btnSaveV" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveV_Click"
                                                    ValidationGroup="ValidateVehicle" />
                                                <asp:Button ID="btnUpdateV" runat="server" Text="Update" class="btn btn-primary"
                                                    OnClick="btnUpdateV_Click" ValidationGroup="ValidateVehicle" />
                                                <asp:Button ID="btnDeleteV" runat="server" Text="Delete" class="btn btn-primary"
                                                    OnClick="btnDeleteV_Click" ValidationGroup="ValidateVehicle" />
                                                <asp:Button ID="btnCancelV" runat="server" Text="Cancel" class="btn btn-primary"
                                                    OnClick="btnCancelV_Click" CausesValidation="false" ValidationGroup="ValidateVehicle" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" width="80%" align="center">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdVehicle" runat="server" CellPadding="4" DataKeyNames="VehicleId,VehicleType,VehicleNumber,VehicleModel,VehicleCapacity,BoardId"
                                                    Width="80%" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                                    BorderStyle="None" BackColor="White" BorderWidth="1px"  OnPageIndexChanging="GrdVehicle_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Vehicle Type" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnVehicleType" runat="server" Text='<%#Eval("VehicleType") %>'
                                                                    OnClick="lnkBtnVehicleType_Click" CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Vehicle Number" DataField="VehicleNumber" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Vehicle Model" DataField="VehicleModel" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Vehicle Capacity" DataField="VehicleCapacity" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp4" class="tab-pane" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_Driver" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                                                <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" ToolTip="Name" ValidationGroup="ValidateDriver"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Name !!!"
                                                    ControlToValidate="txtName" ForeColor="red" ValidationGroup="ValidateDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAddress" runat="server" Text=" Address:"></asp:Label>
                                                <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddress" runat="server" ToolTip="Address" ValidationGroup="ValidateDriver"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Address"
                                                    ForeColor="red" ControlToValidate="txtAddress" ValidationGroup="ValidateDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No :"></asp:Label>
                                                <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhoneNo" runat="server" ToolTip="PhoneNo" ValidationGroup="ValidateDriver" MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Phone No"
                                                    ForeColor="red" ControlToValidate="txtPhoneNo" ValidationGroup="ValidateDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLicenseId" runat="server" Text=" License Id:"></asp:Label>
                                                <asp:Label ID="Label14" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLicenseId" runat="server" ToolTip="LicenseId" ValidationGroup="ValidateDriver"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter License Id"
                                                    ForeColor="red" ControlToValidate="txtLicenseId" ValidationGroup="ValidateDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLicenseType" runat="server" Text=" License Type:"></asp:Label>
                                                <asp:Label ID="Label15" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLicenseType" runat="server" ToolTip="LicenseType" ValidationGroup="ValidateDriver"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter License Type"
                                                    ForeColor="red" ControlToValidate="txtLicenseType" ValidationGroup="ValidateDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                           <%-- <td>
                                                <asp:Label ID="lblUploadImage" runat="server" Text=" Upload Image:"></asp:Label>
                                                <asp:Label ID="Label16" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="flpUploadImage" runat="server" Width="205px" />
                                            </td>
                                            <td>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Upload Image"
                                ForeColor="red" ControlToValidate="flpUploadImage"></asp:RequiredFieldValidator>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewD" runat="server" Text="Add New" class="btn btn-primary" CausesValidation="false"
                                                    OnClick="btnNewD_Click" ValidationGroup="ValidateDriver" />
                                                <asp:Button ID="btnSaveD" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveD_Click"
                                                    ValidationGroup="ValidateDriver" />
                                                <asp:Button ID="btnUpdateD" runat="server" Text="Update" class="btn btn-primary"
                                                    OnClick="btnUpdateD_Click" ValidationGroup="ValidateDriver" />
                                                <asp:Button ID="btnDeleteD" runat="server" Text="Delete" class="btn btn-primary"
                                                    OnClick="btnDeleteD_Click" ValidationGroup="ValidateDriver" />
                                                <asp:Button ID="btnCancelD" runat="server" Text="Cancel" class="btn btn-primary"
                                                    CausesValidation="false" OnClick="btnCancelD_Click" ValidationGroup="ValidateDriver" />
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" width="90%" align="center">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdDriverInfo" runat="server" CellPadding="4" DataKeyNames="DriverId,Name,Address,PhoneNo,LicenseId,LicenseType,UploadImage"
                                                    Width="80%" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" BorderColor="#3366CC"
                                                    BorderStyle="None" OnSelectedIndexChanged="GrdDriverInfo_SelectedIndexChanged"
                                                    BackColor="White" BorderWidth="1px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnName" runat="server" Text='<%#Eval("Name") %>' OnClick="lnkBtnName_Click"
                                                                    CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Phone No" DataField="PhoneNo" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="License Id" DataField="LicenseId" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="License Type" DataField="LicenseType" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                
                                                     
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
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp5" class="tab-pane" align="center">
                            <asp:UpdatePanel ID="UpdatePanel_AllotDriver" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDriver" runat="server" Text="Select Driver :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDriver" runat="server" AutoPostBack="true" width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDriver" runat="server" ErrorMessage="Please Select Driver Name !!!"
                                                    ControlToValidate="ddlDriver" InitialValue="Select" ForeColor="red" ValidationGroup="ValidateAllotDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblVehicleNumber1" runat="server" Text="Select Vehicle Number :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVehicle" runat="server" AutoPostBack="true" width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvVehicleNumber1" runat="server" ErrorMessage="Please Select Vehicle Number"
                                                    ForeColor="red" ControlToValidate="ddlVehicle" InitialValue="Select" TargetControlID="ddlVehicle"
                                                    ValidationGroup="ValidateAllotDriver"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnNewAD" runat="server" Text="Add New" class="btn btn-primary" OnClick="btnNewAD_Click"
                                                    CausesValidation="false" Visible="false" />
                                                <asp:Button ID="btnSaveAD" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveAD_Click"
                                                ValidationGroup="ValidateAllotDriver" />
                                                <asp:Button ID="btnUpdateAD" runat="server" Text="Update" class="btn btn-primary"
                                                    ValidationGroup="ValidateAllotDriver" visible="false"/>
                                                <asp:Button ID="btnDeleteAD" runat="server" Text="Delete" class="btn btn-primary"
                                                    ValidationGroup="ValidateAllotDriver" visible="false" />
                                                <asp:Button ID="btnCancelAD" runat="server" Text="Cancel" class="btn btn-primary"
                                                    CausesValidation="false" visible="false"/>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" width="90%" align="center">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GrdAllotDriver" runat="server" CellPadding="4" ForeColor="#333333"
                                                    DataKeyNames="AllotDriverId" Width="80%" AutoGenerateColumns="False"
                                                    GridLines="None" AllowPaging="True" PageSize="7" BorderColor="#0066FF" BorderStyle="Solid">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Driver Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnDriver" runat="server" Text='<%#Eval("Name") %>' CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Vehicle Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnVehicle" runat="server" Text='<%#Eval("VehicleNumber") %>' CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="sp6" class="tab-pane " align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table border="0" width="80%" align="center" cellspacing="2px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Select Course :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Course !!!"
                                                    ControlToValidate="ddlCourse" InitialValue="Select" ForeColor="red" ValidationGroup="ValidateAllotRoute"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Select Branch :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select Branch !!!"
                                                    ControlToValidate="ddlBranch" InitialValue="Select" ForeColor="red" ValidationGroup="ValidateAllotRoute"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="Select Class :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select Class !!!"
                                                    ControlToValidate="ddlClass" InitialValue="Select" ForeColor="red" ValidationGroup="ValidateAllotRoute"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text="Select Academic Year :"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="DDLAcademicYear" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Select Academic Year !!!"
                                                    ControlToValidate="DDLAcademicYear" InitialValue="Select" ForeColor="red" ValidationGroup="ValidateAllotRoute"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="Select Route :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlstudRoute" runat="server" AutoPostBack="false" width="180">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Route !!!"
                                                    ForeColor="red" ControlToValidate="ddlstudRoute" InitialValue="Select" 
                                                    ValidationGroup="ValidateAllotRoute"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:Panel ID="RouteassignPanal1" runat="server">
                                        <table border="0" width="90%" align="center" style="margin-top:10px;">          
                                          <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblAlreadyAssign" runat="server" Text="Already Assigned : " Style="font-size: 15px;
                                                        color: Green; font-weight: bold;"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                    <asp:Panel ID="RouteassignPanal" runat="server" HorizontalAlign="Center" Height="250px" Width="90%" ScrollBars="Auto" BorderStyle="Inset">
                                        
                                        <asp:Label ID="NoData" runat="server" Text="No Record Found !!!" Style="font-size: 12px;
                                                        color: red; font-weight: bold;"></asp:Label>
                                           
                                                <asp:GridView ID="grdAssignRout" runat="server" CellPadding="4" ForeColor="#333333"
                                                    DataKeyNames="UserCode,RouteId,StudentRouteId" Width="100%" AutoGenerateColumns="False"
                                                    GridLines="None" AllowPaging="false"  BorderColor="#0066FF" BorderStyle="Solid">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Student Name" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <%--<asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>' CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>--%>
                                                        <asp:BoundField HeaderText="Route" DataField="Route" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                      <%--<asp:BoundField HeaderText="License Type" DataField="LicenseType" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllParent1(this)"
                                                                    Text="Select All" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkbox" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>

                                        
                                    </asp:Panel>


                                    <table border="0" width="90%" align="center" style="margin-top:10px;">
                                      <tr>
                                            <td  align="center">
                                                <asp:Button ID="btnUpdateAR" runat="server" Text="Update" class="btn btn-primary"
                                                    ValidationGroup="ValidateAllotRoute" visible="false"  OnClick="btnUpdateAR_Click"/>
                                                <asp:Button ID="btnDeleteAR" runat="server" Text="Delete" class="btn btn-primary" OnClick="btnDeleteAR_Click" CausesValidation="false"
                                                    ValidationGroup="ValidateAllotRoute" visible="false" />
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:Panel ID="grdpanal1" runat="server">
                                    <table border="0" width="90%" align="center" style="margin-top:10px;">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblAssignNew" runat="server" Text="Assign New : " Style="font-size: 15px;
                                                    color: Red; font-weight: bold;"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>

                                    <asp:Panel ID="grdpanal" runat="server" HorizontalAlign="Center" Height="250px" Width="90%" ScrollBars="Auto" BorderStyle="Inset">
                                                 
                                        <asp:Label ID="NoData1" runat="server" Text="No Record Found !!!" Style="font-size: 12px;
                                                        color: red; font-weight: bold;"></asp:Label>
                                        
                                                <asp:GridView ID="grdAllotRoute" runat="server" CellPadding="4" ForeColor="#333333"
                                                    DataKeyNames="UserCode" Width="100%" AutoGenerateColumns="False"
                                                    GridLines="None" AllowPaging="false"  BorderColor="#0066FF" BorderStyle="Solid">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="UserCode" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Student Name" DataField="StudentName" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <%--<asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>' CausesValidation="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>--%>
                                                      <%--<asp:BoundField HeaderText="License Type" DataField="LicenseType" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>--%>
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
                                                    </Columns>
                                                    <EditRowStyle BorderStyle="None" BackColor="#2461BF" />
                                                    <EmptyDataRowStyle BorderStyle="None" />
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BorderStyle="None" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BorderStyle="None" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>

                                    </asp:Panel>

                                    <table border="0" width="90%" align="center" style="margin-top:10px;">
                                      <tr>
                                            <td  align="center">
                                                <asp:Button ID="btnNewAR" runat="server" Text="New" class="btn btn-primary" OnClick="btnNewAR_Click"
                                                    CausesValidation="false" Visible="false" />
                                                <asp:Button ID="btnSaveAR" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSaveAR_Click"
                                                ValidationGroup="ValidateAllotRoute" />
                                                <asp:Button ID="btnUpdateAR1" runat="server" Text="Update" class="btn btn-primary"
                                                    ValidationGroup="ValidateAllotRoute" visible="false"/>
                                                <asp:Button ID="btnDeleteAR1" runat="server" Text="Delete" class="btn btn-primary"
                                                    ValidationGroup="ValidateAllotRoute" visible="false" />
                                                <asp:Button ID="btnCancelAR" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancelAR_Click"
                                                    CausesValidation="false" visible="false"/>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
        </asp:Panel>
    </div>
</asp:Content>