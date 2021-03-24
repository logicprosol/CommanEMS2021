<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StudentAdmissionList.aspx.cs" Inherits="CMS.Forms.Admin.StudentAdmissionList1" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../js/ScrollableGridPlugin.js" type="text/javascript"></script>

    <script type="text/javascript">
        function basicPopup() {
            popupWindow = window.open("../Reports/PrintFeesReceipt.aspx", 'popUpWindow', 'height=800,width=900,left=100,top=30,resizable=No,scrollbars=YES,toolbar=no,menubar=no,location=no,directories=no, status=No');
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
    </script>

    <%--
 <script type="text/javascript" language="javascript">
     $(document).ready(function () {
         $('#<%=GrdStudent.ClientID %>').Scrollable();
     }
)
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 1050px; width: 920px">
        <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="min-height: 897px; height: 1050px; width: 920px; border: medium double#0C7BFA;">
                    <table width="100%">
                        <tr>
                            <th style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Student Admission Status</li>
                                </ul>
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="95%">
                                    <tr>
                                        <td style="width: 80px;">
                                            <asp:Label ID="Label2" runat="server" Text="Status : " Width="80px"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rblStatus" runat="server" CssClass="radio" Width="480px" AutoPostBack="true"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged">
                                                <%--OnSelectedIndexChanged="rblStatus_SelectedIndexChanged"--%>
                                                <asp:ListItem Value="Pending" Text="Pending" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="Admission Completed" Text="Admission Completed"></asp:ListItem>
                                                <asp:ListItem Value="Cancel" Text="Admission Cancelled"></asp:ListItem>
                                                <%--<asp:ListItem Value="Pending for pay" Text="Pending For Pay"></asp:ListItem>--%>
                                            </asp:RadioButtonList>
                                        </td>


                                    </tr>
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
                                            <asp:DropDownList ID="ddlClass" runat="server" Width="180px">
                                                <%--OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"--%>
                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lb1" runat="server" Text="Student: "></asp:Label>
                                            <asp:TextBox ID="txtSearchStudname" Width="250px" runat="server" ToolTip="Enter Student Name"></asp:TextBox>
                                        </td>
                                        <td>

                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary" OnClick="btnSearch_Click" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnGo" runat="server" Text="Go" class="btn btn-primary"
                                                OnClick="btnGo_Click" />


                                            <asp:Button ID="btnPrint" runat="server" class="btn btn-primary" OnClick="btnPrint_Click" OnClientClick="return printpage();" Text="Print" />
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%--<div ID="divGrid" style="width: 100%; height: 280px; overflow: auto; margin: 0 auto;" runat="server"  align="left" >
                                --%>
                                <asp:Panel runat="server" Height="860px" ScrollBars="Auto">
                                    <asp:GridView ID="GrdStudent" runat="server" DataKeyNames="AdmissionID,StudentName"
                                        AutoGenerateColumns="false" AllowPaging="False" BorderColor="#3366CC"
                                        BorderStyle="None" BackColor="White" BorderWidth="1px" Width="98%" CssClass="GVFixedHeader">
                                        <Columns>

                                            <asp:BoundField HeaderText="Code" ItemStyle-HorizontalAlign="Center" DataField="AdmissionId" Visible="False" />
                                            <asp:BoundField HeaderText="Date" ItemStyle-HorizontalAlign="Center" DataField="ApplicationDate" />
                                            <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnStudentName" runat="server" Text='<%#Eval("StudentName") %>'
                                                        OnClick="lnkBtnStudentName_Click" CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:BoundField HeaderText="Caste" ItemStyle-HorizontalAlign="Center" DataField="Caste" />--%>
                                            <asp:BoundField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" DataField="Mobile" />
                                            <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" />
                                            <asp:BoundField HeaderText="Course" ItemStyle-HorizontalAlign="Center" DataField="CourseName" />
                                            <asp:BoundField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" DataField="BranchName" />
                                            <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="ClassName" />
                                            <asp:BoundField HeaderText="Caste" ItemStyle-HorizontalAlign="Center" DataField="Caste" />
                                            <asp:BoundField HeaderText="FeesCategory" ItemStyle-HorizontalAlign="Center" DataField="Feescategory" />
                                            <asp:BoundField HeaderText="Status" ItemStyle-HorizontalAlign="Center" DataField="Status" />

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
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>


                <div class="col-md-3" style="display: none;">
                    <asp:Panel ID="pnlContents" runat="server">
                        <center>



                            <h1>Student Admission List</h1>
                            <br />
                            <br />
                            <asp:GridView ID="gvPrint" runat="server" BorderStyle="None" CellSpacing="5"
                                CssClass="" Style="margin-left: -19px;" AutoGenerateColumns="False">
                                <%--GridLines="None" OnRowDataBound="gvPrint_RowDataBound"--%>
                                <Columns>

                                    <asp:BoundField HeaderText="Code" ItemStyle-HorizontalAlign="Center" DataField="AdmissionId" Visible="False" />
                                    <asp:BoundField HeaderText="Date" ItemStyle-HorizontalAlign="Center" DataField="ApplicationDate" />
                                    <asp:BoundField HeaderText="Student" ItemStyle-HorizontalAlign="Center" DataField="StudentName" />

                                    <%--  <asp:BoundField HeaderText="Caste" ItemStyle-HorizontalAlign="Center" DataField="Caste" />--%>
                                    <asp:BoundField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center" DataField="Mobile" />
                                    <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" />
                                    <asp:BoundField HeaderText="Course" ItemStyle-HorizontalAlign="Center" DataField="CourseName" />
                                    <asp:BoundField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" DataField="BranchName" />
                                    <asp:BoundField HeaderText="Class" ItemStyle-HorizontalAlign="Center" DataField="ClassName" />
                                    <asp:BoundField HeaderText="Status" ItemStyle-HorizontalAlign="Center" DataField="Status" />

                                </Columns>
                                <EmptyDataRowStyle BorderStyle="None" Width="50px" />
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
