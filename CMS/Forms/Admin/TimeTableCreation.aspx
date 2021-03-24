<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TimeTableCreation.aspx.cs" Inherits="CMS.Forms.Admin.TimeTableCreation" %>


<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

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
        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px;
            width: 911px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>CREATE TIME TABLE </li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SetCourseClass" runat="server" align="center" UpdateMode="Conditional">
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
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" Text="Select Branch :" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ForeColor="Red" ErrorMessage="Please Select Course !!!"
                                        ControlToValidate="ddlCourse" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ForeColor="Red" ErrorMessage="Please Select Branch !!!"
                                        ControlToValidate="ddlBranch" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblSubject" Text="Select Subject : " runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" width="180"
                                        onselectedindexchanged="ddlSubject_SelectedIndexChanged" >
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ForeColor="Red" ErrorMessage="Please Select Class !!!"
                                        ControlToValidate="ddlClass" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlSubject" runat="server" ForeColor="Red" ErrorMessage="Please Select Subject !!!"
                                        ControlToValidate="ddlSubject" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay" runat="server" Text="Select Day :"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDay" runat="server" width="180">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblTimeSlot" runat="server" Text="Select Time Slot :"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTimeSlot" runat="server" width="180">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RequiredFieldValidator ID="rfvddlDay" runat="server" 
                                        ControlToValidate="ddlDay" ErrorMessage="Please Select Day !!!" ForeColor="Red" 
                                        ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlTimeSlot" runat="server" 
                                        ControlToValidate="ddlTimeSlot" ErrorMessage="Please Select Time Slot !!!" 
                                        ForeColor="Red" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmployee" runat="server" Text="Select Employee :"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Lecture No :"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txtlectureno" runat="server" Width="180px" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlEmployee" runat="server" 
                                        ControlToValidate="ddlEmployee" ErrorMessage="Please Select Employee !!!" 
                                        ForeColor="Red" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                        </table>
                               </td>
                                <td>

                                </td>
                                
                            </tr>
                            <tr>
                                <td colspan="1">
                                   <asp:Button ID="btnPayFeeForgetAdmission" runat="server" Style="border-radius: 10px;" class="btn btn-primary" OnClick="btnPayFeeForgetAdmission_Click" Text="Create TimeSlot"/>

                               </td>
                                <td>
                                   <label style="color:red;">*Note: If You Want To create time Slot Click on this Button.</label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="2">
                                    <asp:Button ID="btnNew" runat="server" CausesValidation="false" 
                                        class="btn btn-primary" Text="New" onclick="btnNew_Click" />
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" 
                                        Text="Save" onclick="btnSave_Click" ValidationGroup="grpSave" />
                                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" onclick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" onclick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" 
                                        class="btn btn-primary" Text="Cancel" onclick="btnCancel_Click" />
                                            
                                      
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server" Height="350px" HorizontalAlign="Center"  Width="100%" ScrollBars="Auto">
                                    <asp:GridView ID="GrdTimeTable" runat="server" 
                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                        DataKeyNames="TimeTableId,SubjectId,SubjectName,DayId,Day,EmpId,EmpName,SlotId,TimeSlot,LectureNo" PageSize="20" 
                                        Width="80%">
                                        <Columns>
                                            <asp:BoundField DataField="LectureNo" HeaderText="Lecture No" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Time Slot" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkTimeSlot" runat="server" CausesValidation="false" 
                                                      OnClick="lnkTimeSlot_Click" Text='<%#Eval("TimeSlot") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubjectName" HeaderText="Subject" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Day" HeaderText="Day" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EmpName" HeaderText="Employee" 
                                                ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BorderStyle="None" />
                                        <EmptyDataRowStyle BorderStyle="None" />
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" 
                                            HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" 
                                            ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                        </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        

                        <div style="background-color: #000000; width:250px; height:100px" id="PopupDiv"><%--display: none--%>
                        <table >
                        <tr><td align="center">
                            <asp:Label ID="lblReceiptNo2" runat="server" ForeColor="White" Text="Subject Overlap! Are you sure you wants to Subject Overlap?"></asp:Label>
                            </td></tr>
                        <tr><td>
                        
                   </td> </tr>
                         <tr><td align="center">
                             <asp:Button ID="btnClose" runat="server" class="btn btn-danger" Text="No" />
                             <asp:Button ID="btnoverlapsubject" runat="server" class="btn btn-success" Text="Yes" OnClick="btnoverlapsubject_Click" />
                             </td></tr>
                    </table> 


                     </div>
                        <asp:ModalPopupExtender ID="MessagePopUp" runat="server" TargetControlID="Label8"
                                        CancelControlID="btnClose" PopupControlID="PopupDiv" DropShadow="True">
                                    </asp:ModalPopupExtender>
                    <br />

                        <div style="background-color: #000000; width:250px; height:100px" id="PopupDiv1"><%--display: none--%>
                        <table >
                        <tr><td align="center">
                            <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Employee Overlap! Are you sure you wants to Employee Overlap?"></asp:Label>
                            </td></tr>
                        <tr><td>
                        
                   </td> </tr>
                         <tr><td align="center">
                             <asp:Button ID="btnClose1" runat="server" class="btn btn-danger" Text="No" />
                             <asp:Button ID="btnoverlapEmployee" runat="server" class="btn btn-success" Text="Yes" OnClick="btnoverlapEmployee_Click" />
                             </td></tr>
                    </table> 


                     </div>
                        <asp:ModalPopupExtender ID="MessagePopUp1" runat="server" TargetControlID="Label5"
                                        CancelControlID="btnClose1" PopupControlID="PopupDiv1" DropShadow="True">
                                    </asp:ModalPopupExtender>
                    <br />

                    </div>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>

            


        </asp:Panel>
    </div>
</asp:Content>
