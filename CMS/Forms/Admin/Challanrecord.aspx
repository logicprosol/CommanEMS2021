<%@ Page Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Challanrecord.aspx.cs" Inherits="CMS.Forms.Admin.Challanrecord" %>

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

   

<%--
 <script type="text/javascript" language="javascript">
     $(document).ready(function () {
         $('#<%=GrdStudent.ClientID %>').Scrollable();
     }
)
</script>--%>

    <script type="text/javascript">
			function disableButton(btn){
			    document.getElementById(btnapprove).disabled = true;
				alert("Record has been Approved.");
			}
		</script>
     <script type="text/javascript">
    function disablebtnapprove() {

    document.getElementById("btnapprove").disabled = true;
   

}
	</script>

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content2">
   
    <div style="height: 1050px; width: 920px">
          <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="UpdatePanel" runat="server" align="center">       
           <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="btnGetDetails" />--%>

                </Triggers>
                <ContentTemplate>
                    <table border="0" width="50%" align="center" cellspacing="2px">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblStudentCode" runat="server" Visible="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblChallanrepNo" Text="Challan Receipt No: " runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChallanrepNo" runat="server" class="autosuggest" AutoPostBack="true"></asp:TextBox>
                                <%--          <input type="text" id="txtStudentNameId" name="_name" class="autosuggest" />--%>

                            </td>
                             <td>
                                <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" CssClass="btn btn-primary" OnClick="btnGetDetails_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" CausesValidation="false" OnClick="btnNew_Click" />
                            </td>
                        </tr>
                    </table>
            <div class="col-md-3" style="max-height: 660px;overflow: auto;" >
                <h1>Student Fees Paid List</h1>
                <asp:GridView ID="grid" runat="server" BorderStyle="None" CssClass="" Width="98%" CellPadding="4" Style="margin-left: -19px;" 
                    AutoGenerateColumns="false" AutoPostBack="false" DataKeyNames="studentId"  PageSize="10" OnRowCommand="grid_RowCommand" AllowPaging="true"
    OnPageIndexChanging="grid_PageIndexChanging" >
                    <Columns>
                         <asp:BoundField HeaderText="Id" ItemStyle-HorizontalAlign="Center" DataField="Id" Visible="false"/>
                        <asp:BoundField HeaderText="Group Recp.No" ItemStyle-HorizontalAlign="Center" DataField="GroupReceiptNo" />
                        <asp:BoundField HeaderText="Student Id" ItemStyle-HorizontalAlign="Center" DataField="StudentId" />
                        <asp:BoundField HeaderText="Student Name" ItemStyle-HorizontalAlign="Center" DataField="StudentName" />
                        <asp:BoundField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center" DataField="TotalAmount" />
                        <asp:BoundField HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Center" DataField="PaidAmount" />
                        <asp:BoundField HeaderText="Pending Amount" ItemStyle-HorizontalAlign="Center" DataField="PendingAmount" />
                        <asp:TemplateField HeaderText="Student Approve" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnapprove" runat="server" CommandName="Approve" Text="Approve" CommandArgument="<%# Container.DataItemIndex %>" Enabled="true" value="You Want to Approve." onclick="disablebtnapprove()"/>
                            </ItemTemplate>
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

        </ContentTemplate>

    </asp:UpdatePanel>
   
        </div>
</asp:Content>