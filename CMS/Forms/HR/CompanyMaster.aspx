<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="CMS.Forms.HR.CompanyMaster" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>

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
                return true;
                confirm_value.value = "Yes";
            } else {
                return false;
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

                            <li>New Company </li>
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
                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name :"></asp:Label>
                                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" Width="210px" ValidationGroup="validation"></asp:TextBox>
                            </td>
                            <td align="left">


                                <asp:RequiredFieldValidator ID="repname" ControlToValidate="txtCompanyName" runat="server" ErrorMessage="Please select Company Name" ValidationGroup="validation" />
                          
                            </td>
                        </tr>
                        <tr>                           
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Width="210px" ValidationGroup="validation"></asp:TextBox>
                            </td>
                            <td align="left">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCompanyAddress" runat="server" ErrorMessage="Please provide Company Address" ValidationGroup="validation" />
                             
                            </td>
                           
                        </tr>

                        <tr>
                            <td>                        
                                <asp:Label ID="lblCompanyEmail0" runat="server" Text="Website:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtwebsite" runat="server" CssClass="form-control" ValidationGroup="validation" Width="210px"></asp:TextBox>
                            </td>
                            <td align="left">

                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCompanyEmail" runat="server" Text="E-mail:"></asp:Label>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="form-control" ValidationGroup="validation" Width="210px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCompanyEmail" 
                                    ErrorMessage="Please Enter Company Email" ValidationGroup="validation" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCompanyEmail" ErrorMessage="Please Enter Valid E-mail address" 
    ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="validation" Text="Please Enter Valid E-mail address">
  </asp:RegularExpressionValidator>

                            </td>
                            </td>
                        </tr>
                        <tr>
                           <td>
                                    <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label21" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="10" Width="212px" ValidationGroup="validation"></asp:TextBox>
                                </td>
                                <td style="text-align: left">


                                    
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMobileNumber" runat="server" ErrorMessage="Please Enter Mobile Number !!!" ValidationGroup="validation" />


                                   
                                    <asp:FilteredTextBoxExtender ID="ftbeMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                        FilterType="Numbers">
                                    </asp:FilteredTextBoxExtender>
                                </td>

                        </tr>
                        <tr>
                           <td class="auto-style1">
                                <asp:Label ID="Label1" runat="server" Text="Contact Person :"></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" Width="210px" ValidationGroup="validation"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Please Enter Contact Person" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       <%-- <tr>
                                  <td>
                                    <a <td>
                                    <asp:Label ID="lblPermanentCountry" runat="server" Text="Country : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentCountry" runat="server" Width="225px" AutoPostBack="true"
                                        ValidationGroup="GeneralDetails" Height="23px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvPermanentCountry" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select Country !!!" ControlToValidate="ddlPermanentCountry"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>                      
                        </tr>
                        <tr>
                             <td>
                                    <asp:Label ID="lblPermanentState" runat="server" Text="State : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label17" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentState" runat="server" Width="223px" AutoPostBack="true"
                                        ValidationGroup="GeneralDetails" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvPermanentState" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select State !!!" ControlToValidate="ddlPermanentState"
                                        ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                        </tr>
                         <tr>
                                <td>
                                    <asp:Label ID="lblPermanentCity" runat="server" Text="City : " CssClass="formlable"></asp:Label>
                                    <asp:Label ID="Label18" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPermanentCity" runat="server" Width="218px" ValidationGroup="GeneralDetails" Height="24px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="rfvPermanentCity" runat="server" ForeColor="red"
                                        ErrorMessage="Please Select City !!!" ControlToValidate="ddlPermanentCity" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Criteria :"></asp:Label>
                            </td>
                            <td>
                               <%-- <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="true" ValidationGroup="validaiton"
                                    >
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtCriteria" runat="server" CssClass="form-control" TextMode="MultiLine" Width="210px" ValidationGroup="validation" ></asp:TextBox>
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
                                </asp:DropDownList>--%></td>
                        </tr>
                           <tr>
                               <td align="left">&nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td align="center" colspan="3"><%--  <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-primary" ValidationGroup="ValidateDocument"
                                    CausesValidation="false"  />--%>
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click1" Text="Save" ValidationGroup="validation" />
                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" OnClick="btnUpdate_Click" Text="Update"  ValidationGroup="validation" /><%--OnClientClick = "return ConfirmUpdate()"--%>
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" OnClientClick = "ConfirmDelete()" />
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" OnClick="btnCancel_Click" Text="Cancel" />
                            </td>
                            <asp:HiddenField ID="hdnid" runat="server"  />
                            <td><%--                                       <asp:HiddenField ID="hdnid" runat="server" />--%></td>
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
                                  <div class="form-group" style="overflow: scroll;">
                        <asp:GridView ID="gvcompany" runat="server" 
                            Width="800px" HeaderStyle-ForeColor="White" BackColor="#ECF0F1" HeaderStyle-BackColor="#5DADE2" ForeColor="Black" AutoGenerateColumns="False" DataKeyNames="Company_id" >

                            <Columns>
                                  <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl='<%# "CompanyMaster.aspx?Company_id="+Eval("Company_id") %>'>select</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             
                                <asp:BoundField DataField="Company_Name" HeaderText="Company_Name" SortExpression="Company_Name" />
                                <asp:BoundField DataField="Company_email" HeaderText="Company_email" SortExpression="Company_email" />
                                <asp:BoundField DataField="Company_mob" HeaderText="Company_mob" SortExpression="Company_mob" />
                                <asp:BoundField DataField="Contact_Person" HeaderText="Contact_Person" SortExpression="Contact_Person" />
                                   <asp:BoundField DataField="Website" HeaderText="Website" InsertVisible="False" ReadOnly="True" SortExpression="Website" />

                            </Columns>

                            <HeaderStyle BackColor="#5DADE2" ForeColor="White" />
                        </asp:GridView>
                                     <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [Company_id], [Company_Name], [Company_email], [Company_mob], [Contact_Person] FROM [tblCompanyPlacementMaster]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnid" Name="OrgId" PropertyName="Value" />
                            </SelectParameters>
                            </asp:SqlDataSource> --%>  
                                          
                    </div>  
                        <asp:HiddenField ID="hdbId" runat="server" />                
                </div>
                          </td>
                        </tr>
                    </table>
                  <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>