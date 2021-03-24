<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddRoom1.aspx.cs" Inherits="CMS.Forms.Admin.AddRoom1" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>


    <style type="text/css">
        .auto-style1
        {
            height: 39px;
        }
    </style>

    <script type = "text/javascript">
         function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
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
    <asp:UpdatePanel ID="UpdatePanel_Scheme" runat="server" align="center" UpdateMode="Conditional">
        <ContentTemplate>
      
            <div style="height: 900px; width: 930px;">
                <asp:Panel ID="Panel_Scheme" runat="server" Visible="true" Style="height: 895px;
                    width: 930px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Hostel</li>
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblHostel" runat="server" Text="Select Hostel Name :"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHostel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHostel_SelectedIndexChanged"  width="180"
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          <%--  <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlScheme" runat="server" ControlToValidate="ddlHostel"
                                    InitialValue="Select" ErrorMessage="Please select Hostel" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>
                         <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label6" runat="server" Text="Hostel Type :"></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="auto-style1" >
                               <%-- <asp:DropDownList ID="drpHostelType" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtHostelType" runat="server" Enabled="false"></asp:TextBox>
                                
                            </td>
                        </tr>

                         <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text=" Add Room :"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td >
                          
                                <asp:TextBox ID="txtRoom" runat="server" ValidationGroup="TimeSlot"></asp:TextBox>


                            </td>
                              <td align="left">

                                  <asp:RequiredFieldValidator ID="re1" runat="server" ControlToValidate="txtRoom" ErrorMessage="Please Enter Name " ForeColor="Red" ValidationGroup="TimeSlot"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoom"
                                     ErrorMessage="Please Enter Name " ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>


                         <tr>
                             <td>
                                 <asp:Label ID="Label10" runat="server" Text="Room Capacity :"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="txtStudentCount" runat="server" ValidationGroup="TimeSlot"  onkeypress="return isNumberKey(event)"></asp:TextBox>
                             </td>
                             <td align="left">
                                 <asp:RequiredFieldValidator ID="re2" runat="server" ControlToValidate="txtStudentCount" ErrorMessage="Please Enter no of students allowed in room" ForeColor="Red" ValidationGroup="TimeSlot"></asp:RequiredFieldValidator>
                             </td>
                        </tr>


                         <tr>
                            <td>
                                &nbsp;</td>
                            <td >
                              <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"> 
                                    
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                            </td>
                        <%--    <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlScheme"
                                    InitialValue="Select" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>

                    <tr>
                      <td colspan="2" align="center">
                      <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary"  OnClick="btnSave_Click1"  
                               ValidationGroup="TimeSlot"/>
                      <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnUpdate_Click" OnClientClick = "ConfirmUpdate()" />
                      <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                      <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="ValidateDocument" 
                                    CausesValidation="false" OnClick="btnCancel_Click" />
                            </td>
                        <td>
                                 
                                 <a href="HostelAdmission.aspx" style="color:blue;font-family:Cambria;font-size:large;text-decoration:underline;">Get Hostel Admission</a>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                 
                    </table>

                         
                        <%--    <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlScheme"
                                    InitialValue="Select" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>--%>
                       

<%--                     <table>
                        <tr>
                            <td>
                        <asp:GridView ID="gvhostelInfo" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="750px" AllowPaging="True" PageSize="100">
                          
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                          
                        </asp:GridView>
         
                    <br />

                    <asp:HiddenField ID="hdbId" runat="server" />
                    <br />
                </div>
                            </td>
                        </tr>
                    </table>--%>


                    <table style="width: 80%">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="90%" AutoGenerateColumns="False" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl='<%# "AddRoom1.aspx?RoomId="+Eval("RoomId") %>'>select</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                           <%-- <asp:BoundField DataField="Hostel_id" HeaderText="Hostel_id" InsertVisible="False" ReadOnly="True" SortExpression="Hostel_id" />
                                <asp:BoundField DataField="Hostel_name" HeaderText="Hostel_name" SortExpression="Hostel_name" />
                                <asp:BoundField DataField="Hostel_Types" HeaderText="Hostel_Types" SortExpression="Hostel_Types" />
                                <asp:BoundField DataField="Host_room" HeaderText="Host_room" SortExpression="Host_room" />
                                               <asp:BoundField DataField="OrgId" HeaderText="OrgId" SortExpression="OrgId" />
                                               <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />--%>
                                        <asp:BoundField DataField="Hostel_name" HeaderText="Hostel Name" />
                                        <asp:BoundField DataField="Hostel_Types" HeaderText="Hostel Type" />
                                        <asp:BoundField DataField="RoomName" HeaderText="Room" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:BoundField DataField="StudentCount" HeaderText="Room Capacity" />
                                    </Columns>
                                </asp:GridView>
                            
                             
                                  <asp:HiddenField ID="hdbId" runat="server" />
                             
                                
                            </td>
                        </tr>
                        <tr>
                            <asp:HiddenField id="hdnid" runat="server" />
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />

                
                
                </asp:Panel>
              
            </div>
   <%--           <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
