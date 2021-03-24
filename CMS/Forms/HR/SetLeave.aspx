<%@ Page Title="CMS" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"   CodeBehind="SetLeave.aspx.cs" Inherits="CMS.Forms.HR.SetLeave" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="ApplyPayScale.aspx.cs" Inherits="CMS.Forms.HR.ApplyPayScale" %>--%>


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
        function CheckAllEmployee(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdAllEmployee.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }          
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 930px; width: 900px;">
 <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 896px;
            width: 911px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Set Leave</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SetLeave" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" width="80%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="4">
                            <br />
                            </td>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:Label ID="Label1" Text="Set Leave For :" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtFor" runat="server" CssClass="radio" RepeatDirection="Horizontal"
                                    Width="150px" AutoPostBack="true" 
                                    onselectedindexchanged="rbtFor_SelectedIndexChanged">
                                    <%--<asp:ListItem Text="Individual" Value="Individual" Enabled="false">                                  
                                    </asp:ListItem>--%>
                                    <asp:ListItem Text="All" Value="All">                                    
                                    </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel_Individual" runat="server" Visible="false">
                        <table border="0" width="80%" align="center" cellspacing="2px">
                            <tr>
                                
                                <td>
                                    <asp:Label ID="Label4" Text="Enter Employee Name :" runat="server"></asp:Label>
                                    <asp:Label ID="Label2" Text="*" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                                </td>
                                <td align="right">
                                <asp:Button ID="btnDetails" Text="View Details" runat="server" 
                                        CssClass="btn btn-success" onclick="btnDetails_Click" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Label ID="Label6" Text="Details :" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="4">


                                    <asp:Panel ID="Panel1" runat="server" class = "well well-large" Width="800px" Height="260px">
                                    
                                    <asp:GridView ID="GrdEmployee" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="UserCode,FullName,DepartmentName,DesignationName"
                                        ShowHeaderWhenEmpty="True" Width="80%" BorderColor="#3366CC"
                                        BorderStyle="None" EmptyDataText="No Record Found !" EmptyDataRowStyle-HorizontalAlign="Center"
                                        EmptyDataRowStyle-Font-Bold="true" BackColor="White" BorderWidth="1px" AllowPaging="True" OnPageIndexChanging="GrdEmployee_PageIndexChanging" PageSize="15">
                                        <Columns>
                                            <asp:BoundField HeaderText="Employee Code" DataField="UserCode" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Employee Name" DataField="FullName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Department" DataField="DepartmentName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Designation" DataField="DesignationName" ItemStyle-HorizontalAlign="Center">
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

                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                          
                            <tr>
                                <td colspan="4">
                                <asp:Panel ID="Panel2" runat="server" class = "well well-large" Width="800px" Height="260px">
                                    <asp:GridView ID="grdLeaveType" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" Width="80%" DataKeyNames="LeaveId,LeaveCode,LeaveName"
                                        BorderColor="#3366CC" BorderStyle="None" BackColor="White" 
                                        BorderWidth="1px" AllowPaging="True" OnPageIndexChanging="grdLeaveType_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>.
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>                                            
                                            <asp:BoundField HeaderText="Leave Code" DataField="LeaveCode" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Leave Type" DataField="LeaveName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Total Leave" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTotalLeave" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
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
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" 
                                        onclick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        
                    </asp:Panel>

                    <asp:Panel ID="Panel_All" runat="server" Visible="false">
                        <table border="0" width="80%" align="center" cellspacing="2px">
                            
                           
                            
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:Label ID="Label8" Text="Employee List :" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="4">

                                  <asp:Panel ID="Panel3" runat="server" class = "well well-large" Width="800px" Height="270px">
                                    <asp:GridView ID="GrdAllEmployee" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="UserCode,FullName,DepartmentName,DesignationName"
                                        ShowHeaderWhenEmpty="True" Width="80%" BorderColor="#3366CC"
                                        BorderStyle="None" EmptyDataText="No Record Found !" EmptyDataRowStyle-HorizontalAlign="Center"
                                        EmptyDataRowStyle-Font-Bold="true" 
                                         AllowPaging="True" PageSize="7" 
                                        OnPageIndexChanging="GrdAllEmployee_PageIndexChanging" BackColor="White" 
                                        BorderWidth="1px">
                                        <Columns>
                                        <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server" Text="Select All"
                                                    onclick=" CheckAllEmployee(this)" />
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
                                           <asp:BoundField HeaderText="Department" DataField="DepartmentName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>                                            
                                            <asp:BoundField HeaderText="Designation" DataField="DesignationName" ItemStyle-HorizontalAlign="Center">
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
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                           
                                      
                            <tr>
                                <td colspan="4">
                                  <asp:Panel ID="Panel4" runat="server" class = "well well-large" Width="800px" Height="260px">
                                    <asp:GridView ID="GrdLeaveTypeForAll" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" Width="80%" DataKeyNames="LeaveId,LeaveCode,LeaveName"
                                        BorderColor="#3366CC" BorderStyle="None" BackColor="White" 
                                        BorderWidth="1px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>.
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>                                            
                                            <asp:BoundField HeaderText="Leave Code" DataField="LeaveCode" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Leave Type" DataField="LeaveName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Total Leave" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTotalLeave" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
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
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="BtnSaveForAll" runat="server" Text="SET LEAVE" 
                                        class="btn btn-primary" onclick="BtnSaveForAll_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />                    
                                     
                      </asp:Panel>
                    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
