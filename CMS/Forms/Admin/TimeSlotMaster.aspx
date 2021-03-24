<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Admin/Admin.Master"
    CodeBehind="TimeSlotMaster.aspx.cs" Inherits="CMS.Forms.TimeTable.TimeSlotMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>

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
    <div style="height: 900px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_TimeSlot" runat="server" Visible="true" Style="height: 897px;
                    width: 920px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Time Slot</li>
                                </ul>
                            </th>
                        </tr>
                    </table>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFrom" runat="server" Text="From Time :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromTime" runat="server" MaxLength="9"></asp:TextBox>
                            </td>
                            <td>
                                <asp:maskededitextender id="MaskedEditExtender1" runat="server" targetcontrolid="txtFromTime"
                                    mask="99:99" messagevalidatortip="true" onfocuscssclass="MaskedEditFocus" oninvalidcssclass="MaskedEditError"
                                    masktype="Time" acceptampm="True" errortooltipenabled="True" />
                                <asp:maskededitvalidator id="MaskedEditValidator6" runat="server" controlextender="MaskedEditExtender1"
                                    controltovalidate="txtFromTime" isvalidempty="False" emptyvaluemessage="Time is required"
                                    invalidvaluemessage="time is invalid" display="Dynamic" tooltipmessage="Input time"
                                    emptyvalueblurredtext="Please Insert Time" invalidvalueblurredmessage="Invalid Time" validationgroup="grpSave" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTo" runat="server" Text="To Time :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToTime" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:maskededitextender id="MaskedEditExtender2" runat="server" targetcontrolid="txtToTime"
                                    mask="99:99" messagevalidatortip="true" onfocuscssclass="MaskedEditFocus" oninvalidcssclass="MaskedEditError"
                                    masktype="Time" acceptampm="True" errortooltipenabled="True" />
                                <asp:maskededitvalidator id="MaskedEditValidator1" runat="server" controlextender="MaskedEditExtender2"
                                    controltovalidate="txtToTime" isvalidempty="False" emptyvaluemessage="Time is required"
                                    invalidvaluemessage="time is invalid" display="Dynamic" tooltipmessage="Input time"
                                    emptyvalueblurredtext="Please Insert Time" invalidvalueblurredmessage="Invalid Time" validationgroup="grpSave" />
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblType" runat="server" Text="Type :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSlotType" runat="server" width="180">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">General</asp:ListItem>
                                    <asp:ListItem Value="2">Break</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvType" runat="server" 
                                    ControlToValidate="ddlSlotType" Erroressage="Please Select Type" 
                                    ForeColor="red" InitialValue="0"></asp:RequiredFieldValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="1">
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" 
                                    CausesValidation="false" onclick="btnNew_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" 
                                    onclick="btnSave_Click"  />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" onclick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()"  />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" onclick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" 
                                    CausesValidation="false" onclick="btnCancel_Click" />
                                 <br />
                                <br />
                            </td>
                            <td>
                                 <label style="color:red;">Note:For Create TimeTable Click Here..</label>
                                 <a href="TimeTableCreation.aspx" style="color:blue;font-family:Cambria;font-size:large;text-decoration:underline;">Create TimeTable</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="Auto" Height="350px">
                                    <asp:GridView ID="GrdTimeSlot" runat="server" CellPadding="4" DataKeyNames="SlotId,TimeSlot,SlotFrom,SlotTo,SlotType"
                                        Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="False" PageSize="10" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                        BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Time Slot" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkTimeSlot" runat="server" Text='<%#Eval("TimeSlot") %>' OnClick="lnkTimeSlot_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Type" DataField="SlotTypeStr" ItemStyle-HorizontalAlign="Center">
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
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
