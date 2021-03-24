<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true"
    CodeBehind="BasicPaySettings.aspx.cs" Inherits="CMS.Forms.HR.BasicPaySettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ==============================================JavaScript below!-->
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <!-- ==============================================JavaScript below!-->
    <!--  For Tab Navigation Use This jQuery  -->
    <script src="../../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="">        window.jQuery || document.write('<script src="js/jquery-1.7.1.min.js"><\/script>')</script>
    <!-- Bootstrap JS: compiled and minified -->
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Example plugin: Prettify -->
    <!-- Initialize Scripts -->
    <script type="">
        // Activate Google Prettify in this page
        addEventListener('load', prettyPrint, false);
        $(document).ready(function () {
            // Add prettyprint class to pre elements
            $('pre').addClass('prettyprint');
        }); // end document.ready
    </script>


    <script type="text/javascript">
        function fnAllowNumeric() {
            if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 8) {
                event.keyCode = 0;
                alert("Accept only Integer..!");
                return false;
            }
        }
</script>

    <script type = "text/javascript">
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
        <asp:UpdatePanel ID="UpdatePanel_Department" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
    <div style="height: 900px; width: 920px;">
        <asp:Panel ID="Panel_BasicPaySettings" runat="server" Visible="true" Style="height: 897px;
            width: 920px; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Basic Pay Settings</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <div class="MainBody">
                <div class="frmwidth" align="center">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#sp1" data-toggle="tab"><font color="blue">Set Pay Group</font></a></li>
                        <li><a href="#sp2" data-toggle="tab"><font color="blue">Set Earning/Deduction</font></a></li>
<%--                        <li style="visibility:hidden"><a href="#sp3" data-toggle="tab"><font color="blue">Set Tax Slabs</font></a></li>--%>
                    </ul>
                    <div class="tab-content">
                        <div id="sp1" class="tab-pane active" align="center">
                          <asp:UpdatePanel ID="UpdatePanel_Branch" runat="server" align="center" UpdateMode="Conditional">
                              <Triggers>
                                  <asp:PostBackTrigger ControlID="btnSave" />
                              </Triggers>
                                <ContentTemplate>
                                    <%--   Pay Group Settings   --%>
                                    <table width="90%" align="center">
                                        <tr>
                                            <td colspan="3">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPayGroupName" runat="server" Text="Pay Group Name :"></asp:Label>
                                                <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPayGroupName" runat="server" ValidationGroup="Basic" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:RequiredFieldValidator ID="rfvPayGroupName" ValidationGroup="Basic" runat="server"
                                                    ErrorMessage="Please Enter Pay Group Name" ControlToValidate="txtPayGroupName"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Basic Salary :"></asp:Label>
                                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBasicSalary" runat="server" ValidationGroup="Basic" Enabled="False"></asp:TextBox>
                                                <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBasicSalary" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td colspan="2">
                                                <asp:RequiredFieldValidator ID="rfvBasicSalary" runat="server" ErrorMessage="Please Enter Basic Salary" 
                                                    ControlToValidate="txtBasicSalary" ValidationExpression="^[0-9]{10}" Type="Double"
                                                    ValidationGroup="Basic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator ID="RegExpVal" runat="server" ControlToValidate="txtBasicSalary" ValidationExpression="^(?!0$|0\d)\d{1,7}(\.\d{1,2})?$|^$" ErrorMessage="Enter a valid Amount" Display="Dynamic" ValidationGroup="Basic">Enter a valid Amount</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="90%">
                                        <tr>
                                            <td colspan="4">


                                             


                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Button ID="btnNew" Text="New" runat="server" class="btn btn-primary" OnClick="btnNew_Click"
                                                    CausesValidation="false" />
                                                <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-primary" OnClick="btnSave_Click"
                                                    Enabled="False" ValidationGroup="Basic" />
                                                <asp:Button ID="btnUpdate" Text="Update" runat="server" class="btn btn-primary" ValidationGroup="Basic" OnClick="btnUpdate_Click" OnClientClick = "return ConfirmUpdate()" Enabled="False" style="height: 28px" />
                                                <asp:Button ID="btnDelete" Text="Delete" runat="server" class="btn btn-primary" ValidationGroup="Basic" OnClick="btnDelete_Click" OnClientClick = "return ConfirmDelete()" Enabled="False" />
                                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" class="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">   
                                               <asp:Panel ID="Panel3" runat="server" Width="90%" class="well well-large" Height="600px">
                                                  <div style="height: 600px; overflow: scroll;">
                                                    <asp:GridView ID="GrdPayGroupName" runat="server" AutoGenerateColumns="False"
                                                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                                        CellPadding="4" DataKeyNames="PayGrpID,PayGrpName,BasicSalary"  Width="80%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>.
                                                                </ItemTemplate>
                                                              
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pay Group Name" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkBtnPayGrpName" runat="server" Text='<%#Eval("PayGrpName") %>'
                                                                        OnClick="lnkBtnPayGrpName_Click" CausesValidation="false"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" />
                                                        </Columns>
                                                        <EditRowStyle BorderStyle="None" />
                                                        <EmptyDataRowStyle BorderStyle="None" />
                                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                                    </asp:GridView> </div>
                                                </asp:Panel>
                                               
                                            </td>
                                        </tr>
                                    </table>
                               </ContentTemplate></asp:UpdatePanel>
                        </div>
                        <div id="sp2" class="tab-pane ">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" align="center" UpdateMode="Conditional">
                                <ContentTemplate>
                                <%--   Earning / Deduction Settings   --%>
                                <asp:Panel ID="Panel1" runat="server" Width="90%" class="well well-large" Height="700px">
                                    <table width="90%">
                                        <caption>
                                            <br />
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Select Pay Group :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DDL_PayGroup" runat="server" AutoPostBack="True"  width="180"
                                                        onselectedindexchanged="DDL_PayGroup_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDL_PayGroup"
                                                        ErrorMessage="Please Select Pay Group" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Basic Salary :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPBasicSalary" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                   
                                                </td>
                                            </tr>


                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Category Name :"></asp:Label>
                                                    <asp:Label ID="Label13" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvEarningHeads" runat="server" ControlToValidate="txtCategoryName"
                                                        ErrorMessage="Please Enter Salary Heads" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Value Type:"></asp:Label>
                                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rbtnValueType" runat="server" class="radio" RepeatDirection="Horizontal"
                                                        Width="200px" OnSelectedIndexChanged="rbtnValueType_SelectedIndexChanged" CausesValidation="false"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Text="Amount (RS)" Value="RS"></asp:ListItem>
                                                        <asp:ListItem Text="Percent (%)" Value="%"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                               
                                                    <asp:RequiredFieldValidator ID="rfvEarningHeads1" runat="server" 
                                                        ControlToValidate="rbtnValueType" ErrorMessage="Please Select Value Type" 
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                               
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Category Value :"></asp:Label>
                                                    <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCategoryValue" runat="server" AutoPostBack="true"  onkeypress="return fnAllowNumeric()" OnTextChanged="txtCategoryValue_TextChanged"></asp:TextBox>
                                                </td>
                                                <td colspan="2">

                                                   
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtCategoryValue" ErrorMessage="Please Enter Content Value"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red" Text="Please Select value Less Than 100"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Content Action :"></asp:Label>
                                                    <asp:Label ID="Label12" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rbtnContentType" runat="server" class="radio" RepeatDirection="Horizontal"
                                                        Width="200px" AutoPostBack="True">
                                                        <asp:ListItem Text="Earning" Value="Earning"></asp:ListItem>
                                                        <asp:ListItem Text="Deduction" Value="Deduction"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td colspan="2">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCategoryValue"
                                                        ErrorMessage="Please Select Content Type" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" OnClick="btnAdd_Click"
                                                        Text="ADD" />
                                                    <br />
                                                    <br />
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="GrdSalaryHeads" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                                        CellPadding="4" 
                                                        DataKeyNames="PayGrpContentID,PayGrpID,CategoryName,CategoryValue,ValueType,ContentAction" 
                                                        PageSize="8" Width="100%"  
                                                        onpageindexchanging="GrdSalaryHeads_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>.
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                                                            <asp:BoundField DataField="CategoryValue" HeaderText="Category Value" ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                          
                                                            <asp:BoundField DataField="ValueType" HeaderText="Value Type" />
                                                       
                                                            <asp:BoundField DataField="ContentAction" HeaderText="Content Action" />
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px" 
                                                                HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgBtnRemove" runat="server" CausesValidation="false" Height="14" OnClick="ImgBtnRemove_Click"
                                                                        ImageUrl="~/images/removebtn.png" Width="20px" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BorderStyle="None" />
                                                        <EmptyDataRowStyle BorderStyle="None" />
                                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                        <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                                        <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" ForeColor="#CCFF99" />
                                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </caption>
                                    </table>
                                </asp:Panel>
                           </ContentTemplate></asp:UpdatePanel>
                    </div>
                    </div>
                </div>
            </div>
          
        </asp:Panel>
    </div>
    </ContentTemplate></asp:UpdatePanel>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
