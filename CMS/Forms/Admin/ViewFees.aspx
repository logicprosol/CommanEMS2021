<%@ Page Language="C#"  MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewFees.aspx.cs" Inherits="CMS.Forms.Admin.ViewFees" %>
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
        function ConfirmDelete() {
            confirm_value.value = "Yes";
            document.forms[0].removeChild(confirm_value);
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px;">
        <asp:Panel ID="Panel_SetCourseClass" runat="server" Visible="true" Style="height: 897px; width: 900px; border: medium double#0C7BFA; margin-left: 25px;">
            <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
             <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>View Fee Structure</li>
                        </ul>
                    </th>
                </tr>
            </table>

            <table border="0" width="80%" align="center" cellspacing="2px">
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="350px" BorderStyle="None">
                            <asp:GridView ID="GRDFee" runat="server" AllowPaging="true" AutoGenerateColumns="False" BackColor="White"
                                 BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GRDFee_PageIndexChanging"
                                 Width="100%" EmptyDataText="Record Not Found!" OnRowCommand="GRDFee_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FeesId" HeaderText="FeesId" />
                                    <asp:BoundField DataField="Course" HeaderText="Course" />
                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                     <asp:BoundField DataField="class" HeaderText="class" />
                                     <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year" />
                                   <%--  <asp:BoundField DataField="FeesCategoryName" HeaderText="FeesCategory" />--%>
                                   <asp:BoundField DataField="TotalAmount" HeaderText="Total Amt" />
                                     <asp:TemplateField HeaderText="Particular" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnParticular" runat="server" Text="Particular" CssClass="btn btn-primary"
                                                    CausesValidation="false" CommandName="ShowParticular" CommandArgument='<%#Eval("FeesId") %>'></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                </Columns>
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

                        </asp:Panel>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
          
            </table>
             <div id="DivFeesShow" visible="false" runat="server" width="110px" height="450px" style="background-color:cornflowerblue;border:solid; margin-left: 80px; margin-top:100px">
                      
                        
                        <table>
                            <tr>
                                <td style="background-color:dodgerblue;">
                                    <asp:Label ID="lbl1" Text="Fee Information" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="white" ></asp:Label>
                                </td>
                                <td></td>
                                 <td></td>
                            </tr>
                            <tr>
                                <td>
                       
                         <asp:GridView ID="GRDFeedeatils" runat="server" Visible="false" CellPadding="4" Width="99%" AutoGenerateColumns="False"
                            AllowPaging="True" Height="50px" ShowHeader="true" PageSize="10" BorderColor="#3366CC" BorderStyle="None" BackColor="White" BorderWidth="1px">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:BoundField HeaderText="FeesDetailsId" ItemStyle-HorizontalAlign="Center" DataField="FeesDetailsId">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                               <asp:BoundField HeaderText="FeesId" ItemStyle-HorizontalAlign="Center" DataField="FeesId">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="Particular" ItemStyle-HorizontalAlign="Center" DataField="Particular">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Amount" ItemStyle-HorizontalAlign="Center" DataField="Amount">
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
                            <tr>
                                <td>   <asp:Button ID="btnDivFeesCancel" runat="server" Text="Cancel" OnClick="btnDivFeesCancel_Click" CssClass="btn btn-danger" /></td>
                            </tr>
                        </table>
                    </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>
    </div>

</asp:Content>

