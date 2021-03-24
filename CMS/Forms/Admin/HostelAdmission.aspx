<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="HostelAdmission.aspx.cs" Inherits="CMS.Forms.Admin.HostelAdmission" %>
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
        }    
        function forceNumeric() {
            var $input = $(this);
            $input.val($input.val().replace(/[^\d]+/g, ''));
        }
        $('body').on('propertychange input', 'input[type="number"]', forceNumeric);
    </script>

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
                                <asp:DropDownList ID="ddlHostel" runat="server" AutoPostBack="true" Height="26px" Width="190px" OnSelectedIndexChanged="ddlHostel_SelectedIndexChanged" 
                                    >
                                  
                                </asp:DropDownList>
                            </td>
                         <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlScheme" runat="server" ControlToValidate="ddlHostel"
                                    InitialValue="--Select Hostel--" ErrorMessage="Please select Hostel" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>


                         <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Assign Room :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="ddlRoom" runat="server" AutoPostBack="true" Height="30px" Width="188px" 
                                    >
                                    <asp:ListItem Text="--Select Type--" Value="--Select Type--">
                                    </asp:ListItem>
                                </asp:DropDownList>

                               <%-- <asp:TextBox ID="TextBox1" runat="server" Width="210px" CssClass="form-control"></asp:TextBox>--%>
                            </td>

                         <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlRoom"
                                    InitialValue="--Select Type--" ErrorMessage="Please select schema" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                         <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Select Student UserId :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="true"  Height="30px" Width="186px"
                                    ><%--OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"--%>
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStudent"
                                    InitialValue="--Select Student--" ErrorMessage="Please select Scheme" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                      

                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Total Fees :"></asp:Label>
                            </td>
                            <td >
                              <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                &nbsp;<asp:TextBox ID="txtTotalFees" runat="server" onkeypress="return  forceNumeric(event)" ReadOnly="True"></asp:TextBox>

                            </td>
                             <td align="left">
                                 &nbsp;</td>
                        </tr>
                        
                         <tr>
                             <td>
                                 <asp:Label ID="Label10" runat="server" Text="Fees Paid :"></asp:Label>
                                 <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*" Visible="false"></asp:Label>
                             </td>
                             <td><%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                                 <asp:TextBox ID="txtFees" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                             </td>
                             <td align="left">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFees" ErrorMessage="Please enter Hostel Fees " ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                             </td>
                        </tr>
                        
                         <%-- %>  <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Pending Fees :"></asp:Label>
                                <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td >
                              <%--  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    >
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="false"></asp:TextBox>

                            </td>
                        </tr>--%>

                    <tr>
                      <td colspan="2" align="center">
                      <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="validaiton" OnClick="btnSave_Click" 
                                     />
                      <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnUpdate_Click" 
                         OnClientClick = "ConfirmUpdate()"            />
                     <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="ValidateDocument" OnClick="btnDelete_Click" 
                             OnClientClick = "ConfirmDelete()"       />
                      <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" ValidationGroup="validaiton" OnClick="btnCancel_Click"
                                    CausesValidation="false" />
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
                       

                     <table>
                        <tr>
                            <td>
                        <asp:GridView ID="gvhostelInfo" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="750px" AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
                           <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl='<%# "HostelAdmission.aspx?AdmissionId="+Eval("AdmissionId") %>'>select</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="RoomName" HeaderText="Room" />
                                          
                                        <asp:BoundField DataField="fees" HeaderText="Total Fees" />
                                        <asp:BoundField DataField="H_fees" HeaderText="Paid Fees" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                          
                                    </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
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
                    </table>


                    <%--<table style="width: 80%">
                        <tr>
                            <td>
                                
                                <asp:GridView ID="GrdScheme" runat="server" CellPadding="4" DataKeyNames="SchemeDetailsId,SchemeId"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                    ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowEditing="GrdScheme_RowEditing"
                                    OnRowCommand="GrdScheme_RowCommand" OnRowDeleting="GrdScheme_RowDeleting" OnRowUpdating="GrdScheme_RowUpdating"
                                    OnRowCancelingEdit="GrdScheme_RowCancelingEdit" BackColor="White" 
                                    BorderWidth="1px" onrowdatabound="GrdScheme_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Details Id" SortExpression="SchemeDetailsId"
                                            Visible="false" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchemeDetailsId" runat="server" Text='<%#Eval("SchemeDetailsId") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Id" SortExpression="SchemeId" Visible="false"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchemeId" runat="server" Text='<%#Eval("SchemeId") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fund Name" SortExpression="FundName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFundName" runat="server" Text='<%#Eval("FundName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFundName" runat="server" Text='<%#Eval("FundName") %>' Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFundName" runat="server" ForeColor="Red" ControlToValidate="txtFundName"
                                                    Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Total Amount :" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="txtFooterFundName" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterFundName" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterFundName" Text="*" ValidationGroup="validaiton" Display="Dynamic" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Distributed Amount" SortExpression="DistributedAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistributedAmount" runat="server" Text='<%#Eval("DistributedAmount") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDistributedAmount" runat="server" Text='<%#Eval("DistributedAmount") %>'
                                                    Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDistributedAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtDistributedAmount" Text="*" ValidationGroup="validaiton1"
                                                    Display="Dynamic" />
                                                <%--<asp:FilteredTextBoxExtender ID="ftbetxtDistributedAmount" runat="server" TargetControlID="txtDistributedAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblSummary" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                                <asp:TextBox ID="txtFooterDistributedAmount" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterDistributedAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterDistributedAmount" Text="*" ValidationGroup="validaiton"
                                                    Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtFooterDistributedAmount" runat="server" TargetControlID="txtFooterDistributedAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/images/update.jpg"
                                                    ToolTip="Update" Height="20px" Width="20px" ValidationGroup="validaiton1" />
                                                <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/images/Cancel.jpg"
                                                    ToolTip="Cancel" Height="20px" Width="20px" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/images/Edit.jpg"
                                                    ToolTip="Edit" Height="20px" Width="20px" />
                                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                                            </ItemTemplate>                                            
                                            <FooterTemplate>
                                                <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/images/AddNewitem.jpg"
                                                    CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new particular"
                                                    ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
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
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>--%>
                    <br />

                
                
                </asp:Panel>
              
            </div>
   <%--           <ucMsgBox:MsgBox ID="msgBox" runat="server" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
  
  
  
</asp:Content>
