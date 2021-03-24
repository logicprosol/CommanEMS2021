<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Forms.Student.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
         .auto-style1 {
             width: 317px;
         }
         .auto-style2 {
             width: 267px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_DeptDesignation" runat="server" Visible="true" Style="height: 897px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li>Result </li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
                <table border="0" width="80%" align="center" cellspacing="2px">
                    <tr>
                        <td class="auto-style2">
                            <br />
                        </td>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblstudname" runat="server" Text="Student Name"></asp:Label>
                          
                        </td>
                        <td>
                                <asp:Label ID="lblstud" runat="server" Text="Student Name"></asp:Label>
                            <br />
                        </td>
                        <td>
                        
                     
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                         
                        </td>
                        <td>
                                   <asp:Label ID="lblclassname" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td>
                      
                        </td>
                    </tr>
                       <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label1" runat="server" Text="Course"></asp:Label>
                         
                        </td>
                        <td>
                                   <asp:Label ID="lblCourse" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td>
                      
                        </td>
                    </tr>
                       <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label3" runat="server" Text="Branch"></asp:Label>
                         
                        </td>
                        <td>
                                   <asp:Label ID="lblBranch" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td>
                      
                        </td>
                    </tr>
                   
                 
                    <tr>
                        <td colspan="4">
                            <br />
                        </td>
                    </tr>
                       
                       
                      
                </table>

                <div>
                    <table style="margin-left:40px">
                        <tr>
                            <td>
                                 
                               <asp:GridView ID="GridView2" runat="server" Width="600px" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="Record not found">
                                   <AlternatingRowStyle BackColor="White" />
                                   <EditRowStyle BackColor="#2461BF" />
                                   <EmptyDataRowStyle ForeColor="Red" />
                                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                   <RowStyle BackColor="#EFF3FB" />
                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                           
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
          
         


        </asp:Panel>
        
    </div>
</asp:Content>
