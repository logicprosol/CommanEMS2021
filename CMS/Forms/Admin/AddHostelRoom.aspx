<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddHostelRoom.aspx.cs" Inherits="CMS.Forms.Admin.AddHostelRoom" %>
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
        }    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 930px;">
        <asp:Panel ID="Panel_CasteCategory" runat="server" Visible="true" Style="height: 895px;
            width: 930px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">

                            <li><i class="icon-book"></i>Add Hostel</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>
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
                                &nbsp;</td>
                            <td width="200px">
                               <%-- <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" 
                                    ValidationGroup="validaiton">
                                    <asp:ListItem Text="Select" Value="Select">
                                    </asp:ListItem>
                                </asp:DropDownList>--%>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" Text="Hostel Name :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" 
                                    ValidationGroup="validaiton">
                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Width="210px" OnTextChanged="TextBox2_TextChanged" CausesValidation="True" ValidationGroup="validaiton"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="TextBox2"
                                     ErrorMessage="Please select Hostel Name" ForeColor="Red" ValidationGroup="validaiton" BorderStyle="None" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblHostel" runat="server" Text="Types Of Hostel :"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                        
                                        <asp:DropDownList ID="ddlHostel" runat="server" AutoPostBack="true"  width="220"
                                    ValidationGroup="validaiton">
                                    <asp:ListItem Text="Select" Value="Select" Enabled="true"></asp:ListItem>
                                    <asp:ListItem Value="1">Boys Hostel</asp:ListItem>
                                    <asp:ListItem Value="2">Girls Hostel</asp:ListItem>
									<asp:ListItem Value="3">Co-Ed</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlHostel"
                                    InitialValue="Select" ErrorMessage="Please select Hostel Type" ForeColor="Red" ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                            
                               <%-- <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" ValidationGroup="validaiton"
                                    >
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" CssClass="form-control" Width="210px" CausesValidation="True" ValidationGroup="validaiton"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvddlAcademicYear" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please provide Hostel Address" ForeColor="Red"
                                    ValidationGroup="validaiton"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblfes" runat="server" Text="Fees :"></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:DropDownList ID="ddlCastCategory" runat="server" AutoPostBack="true" 
                                    ValidationGroup="validaiton">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtFees" runat="server" CausesValidation="True" CssClass="form-control" onkeypress="return isNumberKey(event)"
                                    OnTextChanged="TextBox2_TextChanged" ValidationGroup="validaiton" Width="210px"></asp:TextBox>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                         <tr>
                           <%-- <td>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td
                            <td>
                               <%-- <asp:DropDownList ID="ddlCastCategory" runat="server" AutoPostBack="true" 
                                    ValidationGroup="validaiton">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                           <tr>
                               <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2"><%--  <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false"  />--%>
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click1" Text="Save" ValidationGroup="validaiton" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" ValidationGroup="validaiton" />

                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="validaiton"  Visible="false" OnClientClick = "ConfirmUpdate()" />
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" OnClick="btnDelete_Click" Text="Delete" ValidationGroup="validaiton3" Visible="false" OnClientClick = "ConfirmDelete()" />
                            </td>
                            <td>
                                 <label style="color:red;">Note:For Create Room Click Here..</label>
                                 <a href="Addroom1.aspx" style="color:blue;font-family:Cambria;font-size:large;text-decoration:underline;">Create Room</a>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnid" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>
                        <caption>
                        </caption>
                    </table>

                    <table>
                        <tr>
                            <td>
                                  <div class="form-group" style="overflow-x: scroll;">
                        <asp:GridView ID="gvhostel" runat="server" AllowPaging="True"
                            PageSize="7" Width="800px" HeaderStyle-ForeColor="White" BackColor="#ECF0F1" HeaderStyle-BackColor="#5DADE2" ForeColor="Black" AutoGenerateColumns="False"
                            DataKeyNames="Hostel_id" DataSourceID="BindGv">

                            <Columns>



                                <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl='<%# "AddHostelRoom.aspx?Hostel_id="+Eval("Hostel_id") %>'>select</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="Hostel_name" HeaderText="Hostel_name" SortExpression="Hostel_name" />
                                <asp:BoundField DataField="Hostel_Types" HeaderText="Hostel_Types" SortExpression="Hostel_Types" />
                                <asp:BoundField DataField="Hostel_Address" HeaderText="Hostel_Address" SortExpression="Hostel_Address" />
                             
                            </Columns>

                            <HeaderStyle BackColor="#5DADE2" ForeColor="White" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="BindGv" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
                            SelectCommand="SELECT [Hostel_id], [Hostel_name], [Hostel_Types] type,case when Hostel_Types='1' then 'Boys Hostel'when Hostel_Types='2' then 'Girls Hostel' when Hostel_Types='3' then 'Co-Ed' end as Hostel_Types , [Hostel_Address],[Fees] FROM [AddHostel] where OrgId=@OrgId">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnid" Name="OrgId" PropertyName="Value" />
                            </SelectParameters>
                                      </asp:SqlDataSource>
                    </div>
                    <br />

                    <asp:HiddenField ID="hdbId" runat="server" />
                    <br />
                </div>
                            </td>
                        </tr>
                    </table>
                   <%-- <table style="width: 80%">
                        <tr>
                            <td>
                                <!--Gridview Starts here-->
                                <!--Add this gridview in .aspx page-->
                                <!--Add this gridview in .aspx page-->
                                <asp:GridView ID="GrdFees" runat="server" CellPadding="4" DataKeyNames="Particular,Amount"
                                    Width="80%" AutoGenerateColumns="False" BorderColor="#3366CC" BorderStyle="None"
                                    ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowEditing="GrdFees_RowEditing"
                                    OnRowCommand="GrdFees_RowCommand" OnRowDeleting="GrdFees_RowDeleting" OnRowUpdating="GrdFees_RowUpdating"
                                    OnRowCancelingEdit="GrdFees_RowCancelingEdit" BackColor="White" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Perticular" SortExpression="Perticular">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPerticular" runat="server" Text='<%#Eval("Particular") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPerticular" runat="server" Text='<%#Eval("Particular") %>'>
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPerticular" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtPerticular" Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterPerticular" runat="server">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterPerticular" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterPerticular" Text="*" ValidationGroup="validaiton" />
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("Amount") %>' Style="text-align: right">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtAmount" runat="server" ForeColor="Red" ControlToValidate="txtAmount"
                                                    Text="*" ValidationGroup="validaiton1" Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtAmount" runat="server" TargetControlID="txtAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtFooterAmount" runat="server" Style="text-align: right;">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFooterAmount" runat="server" ForeColor="Red"
                                                    ControlToValidate="txtFooterAmount" Text="*" ValidationGroup="validaiton" Display="Dynamic" />
                                                <asp:FilteredTextBoxExtender ID="ftbetxtFooterAmount" runat="server" TargetControlID="txtFooterAmount"
                                                    FilterType="Custom, Numbers" ValidChars=".">
                                                </asp:FilteredTextBoxExtender>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:CommandField ShowDeleteButton="True" />--%>
                                        <%--  <asp:CommandField HeaderText="Edit-Update" ShowEditButton="True" />
                                        <asp:TemplateField HeaderText="SrNo">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Particular" runat="server" Text='<%#Eval("Particular") %>' OnClick="lnkBtnFeesName_Click"
                                                    CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Perticulars">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPerticulars" runat="server" Width="25px" />
                                            </ItemTemplate>
                                            <ItemStyle Width="25px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
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
                                            <%--<EditItemTemplate>
                                                <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update" Text="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel" Text="Delete">
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="Delete">
                                                </asp:LinkButton>
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
                                <!--Gridview end here-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
    --%>                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
   
</asp:Content>