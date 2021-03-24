<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="AssignRollNo.aspx.cs" Inherits="CMS.Forms.Faculty.AssignRollNo" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style1 {
             margin-top: 10px;
         }
     </style>
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
            <div style="height: 900px; width: 920px; border: medium double#0C7BFA;">
                <table border="0" width="100%" align="center">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>Assign Roll No</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" Width="920px">
                    <table border="0" width="90%" align="center">
                        <tr>
                            <td colspan="6" style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourses" runat="server" Text=" Select Course:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourses" runat="server" Width="150px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text=" Select Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranches" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblClasses" runat="server" Text=" Select Class:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                    Width="150px">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Default" Value="Default"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    InitialValue="0" ControlToValidate="ddlCourses" ErrorMessage="Please Select Course"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlBranches" ErrorMessage="Please Select Branch"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2" align="center">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="Select" runat="server"
                                    ForeColor="Red" ControlToValidate="ddlClasses" ErrorMessage="Please Select Class"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                &nbsp;</td>
                            <td colspan="2" align="center">
                                &nbsp;</td>
                            <td colspan="2" align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div style="overflow: scroll; height:700px ">
                                    <asp:Label ID="Note" Text="Note :  " runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                                    <asp:Label ID="Note0" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#003399" Text="Enter Students Roll No."></asp:Label>
                                    <br />
                                <asp:Panel ID="Panel2" runat="server" class=" well well-large" Width="95%" Height="680px"  >
                                    
                                    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BorderWidth="1px" CellPadding="4" 
                                         OnRowEditing="GridView1_RowEditing"  DataKeyNames="AdmissionID"
                                    EmptyDataText="No record present" Width="100%">
                                        <Columns>
                                            
                                          
                                              <asp:TemplateField HeaderText="Name" SortExpression="Name" ItemStyle-Width="300px" HeaderStyle-Width="300px">
                                            <EditItemTemplate>
                                                
                                                <asp:Label ID="FirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label84" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle Width="300px" />
                                                  <ItemStyle Width="300px" />
                                    </asp:TemplateField>
                                       
                                     <asp:TemplateField HeaderText="RollNo" SortExpression="RollNo" ItemStyle-Width="250px" HeaderStyle-Width="250px">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="RollNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRollNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                              
                                            </ItemTemplate>
                                            <HeaderStyle Width="250px" />
                                            <ItemStyle Width="250px" />
                                     </asp:TemplateField>
                                             <asp:TemplateField HeaderText="AdmissionID" SortExpression="AdmissionID" Visible="False">
                                            <EditItemTemplate>
                                                 <asp:Label ID="lb" runat="server" Text='<%# Eval("AdmissionID") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                               <asp:Label ID="Labelt4" runat="server" Text='<%# Eval("AdmissionID") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                     </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px" HeaderStyle-Width="80px">
        <ItemTemplate>
        
             <asp:LinkButton ID="btnupdate" runat="server" CommandName="Edit" Text="Update" ValidationGroup="grid" CausesValidation="False"/>
        </ItemTemplate>
         
                                               <HeaderStyle Width="80px" />
                                               <ItemStyle Width="80px" />
         
        </asp:TemplateField> 
                                        </Columns>
                                         <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" Font-Size="Medium" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>--%>

                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="AdmissionID,RollNo"  BorderWidth="1px" CellPadding="4" 
                                        EmptyDataText="No record present" Width="100%" >


                                        <Columns>
                                            <asp:TemplateField HeaderText="Name" SortExpression="Name" ItemStyle-Width="300px" HeaderStyle-Width="300px">
                                            <EditItemTemplate>
                                                
                                                <asp:Label ID="FirstName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label84" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle Width="300px" />
                                                  <ItemStyle Width="300px" />
                                    </asp:TemplateField>

                                             <asp:TemplateField HeaderText="RollNo" SortExpression="RollNo" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                            <EditItemTemplate>
                                                <asp:Label ID="RollNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                 <asp:TextBox ID="txtRollNo" runat="server" Text='<%# Eval("RollNo") %>' Visible="false"></asp:TextBox>
                                              
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle Width="200px" />
                                     </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" OnClick="lnkbtnEdit_Click"  Text="Edit" ValidationGroup="grid" CausesValidation="False" Visible="true" />
                                                     <asp:LinkButton ID="btnUpdate" runat="server" OnClick="lnkbtnUpdate_Click" Text="Update" ValidationGroup="grid" CausesValidation="False" Visible="false"/>
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="lnkbtnCancel_Click"  Text="Cancel" ValidationGroup="grid" CausesValidation="False" Visible="false"/>
                                                </ItemTemplate>
         
         
                                            </asp:TemplateField> 

                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" Font-Size="Medium" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />


                                    </asp:GridView>

                                    <center> <asp:Button ID="btnUpdate" runat="server" Class="btn btn-primary" OnClick="btnUpdate_Click" Text="Update" CssClass="auto-style1" Visible="false" /></center>
                                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
                                        SelectCommand="SELECT [AdmissionID], [FirstName]+' '+ [MiddleName]+' '+ [LastName] Name, --isnull([RollNo],0)
                                        RollNo
                                        FROM [tblStudent] WHERE (([CourseId] = @CourseId) AND ([BranchId] = @BranchId) AND ([ClassId] = @ClassId) AND ([OrgID] = @OrgID)) and Status='Admission Completed' Order By [RollNo]">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourses" DefaultValue="0" Name="CourseId" PropertyName="SelectedValue" Type="Decimal" />
                                            <asp:ControlParameter ControlID="ddlBranches" DefaultValue="0" Name="BranchId" PropertyName="SelectedValue" Type="Decimal" />
                                            <asp:ControlParameter ControlID="ddlClasses" DefaultValue="0" Name="ClassId" PropertyName="SelectedValue" Type="Decimal" />
                                            <asp:SessionParameter DefaultValue="1" Name="OrgID" SessionField="OrgId" Type="Decimal" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                </asp:Panel>
                                    </div>
                              
                            
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20px" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
       
</asp:Content>