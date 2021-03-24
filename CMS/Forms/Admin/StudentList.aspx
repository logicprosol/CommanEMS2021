<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="StudentList.aspx.cs" Inherits="CMS.Forms.Admin.StudentAdmissionList" %>

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
 </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    
  
  
  
    
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px">
        <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">       
            <ContentTemplate>
                <div style="min-height: 897px; height: auto; width: 900px; border: medium double#0C7BFA;">
                    <table width="95%">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Student List</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%">
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
                                            <asp:Label ID="Label8" runat="server" Text="Division : " Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" Width="200px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="200px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="200px"
                                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDivision" runat="server" Width="180px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"
                                                AutoPostBack="true" Visible="False">
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCasteCategory" runat="server" Width="200px" Text="CasteCategory : " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStudName" runat="server" Text="Student Name : " CssClass="formlable"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year : " CssClass="formlable"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCasteCategory"  Width="200px" runat="server" ValidationGroup="GeneralDetails" OnSelectedIndexChanged="ddlCasteCategory_SelectedIndexChanged"
                                               >
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStudName" runat="server" Width="200px" OnTextChanged="txtStudName_TextChanged"
                                                AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails" OnSelectedIndexChanged="DDLAcademicYear_SelectedIndexChanged"
                                                Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                <%--    <tr>
                                        <td>
                                            <asp:Label ID="lbl1" runat="server" Text=" select Filter Criteria: "></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lbl2" runat="server" Text="Filter Value:"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                      <%--  <td>
                                             <asp:DropDownList ID="DDLFilterCriteria" runat="server" Width="200px"
                                                AutoPostBack="true" Visible="true">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Student Code" Value="UserCode"></asp:ListItem>
                                                   <asp:ListItem Text="Student" Value="FirstName"></asp:ListItem>
                                                   <asp:ListItem Text="Class" Value="Class"></asp:ListItem>
                                                  <asp:ListItem Text="Fees Category" Value="FeesCategoryName"></asp:ListItem>
                                                   <asp:ListItem Text="Catse Category" Value="CasteCategoryName"></asp:ListItem>
                                                 <asp:ListItem Text="Academic Year" Value="AcademicYear"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtFilterCriterai" runat="server" Width="200px"></asp:TextBox>
                                        </td>--%>
                                        <td>

                                        </td>
                                       
                                          <td>
                                            <asp:Button ID="BtnGo" runat="server" class="btn btn-primary" OnClick="BtnGo_Click" Text="Go" />
                                        <asp:Button ID="btnFeesInformation" runat="server" Style="border-radius: 10px;" class="btn btn-primary" Text="Student Wise Fees Details" OnClick="btnFeesInformation_Click"/>
                                          </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="2"><label style="color:red">*Note: For get Student fees Details Copy Student Code And Click on Stud Wise Fees Details Button </label></td>
                                      
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>                        
                        <tr>
                            <td>
                                <%--<div style="max-height: 660px; overflow: auto;">
                                    <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="750px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>--%>

                                <div style="max-height: 660px; overflow: auto;">
                                   <asp:GridView ID="GrdStudent" runat="server" CellPadding="4" DataKeyNames="AdmissionID,StudentName,CourseName,BranchName,ClassName,CasteCategoryName,UserCode"
                                        Width="98%" AutoGenerateColumns="False" BorderColor="#3366CC"
                                        BorderStyle="None" BackColor="White" BorderWidth="1px">
                                        <Columns>
                                             <asp:BoundField HeaderText="AdmissionID" ItemStyle-HorizontalAlign="Center" DataField="AdmissionID" Visible="False">
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Student Code" ItemStyle-HorizontalAlign="Center" DataField="UserCode" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            <asp:TemplateField HeaderText= "Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                                        OnClick="lnkBtnStudentName_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="Class" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                             <asp:BoundField HeaderText="Fees Category" ItemStyle-HorizontalAlign="Center" DataField="FeesCategoryName" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            
                                           <%-- <asp:BoundField HeaderText="Division" ItemStyle-HorizontalAlign="Center" DataField="DivisionName" />--%>
                                            <asp:BoundField HeaderText="Caste Category" ItemStyle-HorizontalAlign="Center" DataField="CasteCategoryName" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Academic Year" ItemStyle-HorizontalAlign="Center" DataField="AcademicYear" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                            <asp:TemplateField HeaderText="View Profile" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnView" runat="server" Text="View"
                                                        OnClick="lnkBtnView_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="BtnPrint"  OnClientClick="return printpage()"    runat="server" class="btn btn-primary" Text="Print"  />
                            </td>
                        </tr>
                    </table>
                </div>







                  <div class="col-md-3" style="display:none ;">
                        <asp:Panel ID="pnlContents" runat="server">
                            <center>
                               

                                  
                                 <h1> Student List</h1>
                                <br />
                                <br />
                                   <asp:GridView ID="gvPrint" runat="server" BorderStyle="Groove" CellSpacing="5" 
                                        CssClass=""   style=" margin-left: -19px;" AutoGenerateColumns="False"  >
                                        <Columns>
                                             <asp:BoundField HeaderText="AdmissionID" ItemStyle-HorizontalAlign="Center" DataField="AdmissionID" Visible="False">
                                            
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Student Code" ItemStyle-HorizontalAlign="Center" DataField="UserCode" >
                                             
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Name" ItemStyle-HorizontalAlign="Center" DataField="StudentName" >
                                            
                                             </asp:BoundField>
                                             <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="Class" >
                                            
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Fees Category" ItemStyle-HorizontalAlign="Center" DataField="FeesCategoryName" >
                                             <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                          <%--  <asp:BoundField HeaderText="Course" ItemStyle-HorizontalAlign="Center" DataField="CourseName" >
                                             
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" DataField="BranchName" >
                                            
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="ClassName" >
                                             
                                             </asp:BoundField>--%>
                                           <%-- <asp:BoundField HeaderText="Division" ItemStyle-HorizontalAlign="Center" DataField="DivisionName" />--%>
                                            <asp:BoundField HeaderText="Caste" ItemStyle-HorizontalAlign="Center" DataField="CasteCategoryName" >
                                            
                                             </asp:BoundField>
                                            <asp:BoundField HeaderText="Academic Year" ItemStyle-HorizontalAlign="Center" DataField="AcademicYear" >
                                             
                                             </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle BorderStyle="None" HorizontalAlign="Justify" Width="50px" />
                                        <HeaderStyle BorderStyle="None" />
                                    </asp:GridView>
                                   
                                    
                            </center>
                        </asp:Panel>
                    </div>


                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


   


</asp:Content>
