<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true" CodeBehind="Upload_result.aspx.cs" Inherits="Forms.Faculty.Upload_result" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Image ID="PleaseWaitImage" ImageUrl="~/images/please_wait.gif" AlternateText="Processing"
                runat="server" Height="42px" Width="121px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height:auto; width: 920px;">
        <asp:Panel ID="Panel_SendMessage" runat="server" Visible="true" Style="height:1030px;
            width: 100%; border: medium double#0C7BFA;">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Upload Result</li>
                        </ul>
                    </th>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel_SendMessage" runat="server" align="center" UpdateMode="Conditional">
                <ContentTemplate>

                    <div style="width: 100%; height: auto; margin-left: auto; margin-right: auto;">
                        <table border="0" width="90%" align="center" cellspacing="2px">
                            <tr>
                                <td colspan="4">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCourse" Text="Select Course :" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblBranch" Text="Select Branch :" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ForeColor="Red" ErrorMessage="Please Select Course !!!"
                                        ControlToValidate="ddlCourse" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ForeColor="Red" ErrorMessage="Please Select Branch !!!"
                                        ControlToValidate="ddlBranch" ValidationGroup="grpSave" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" Text="Select Class :" runat="server" ></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" width="180" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lblSemester" runat="server" Text="Select Semester :"></asp:Label>--%>
                                    <%--<asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>--%>
                                </td>
                                <td>
                                    <%--<asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" width="180">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlClass0" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Select Class !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfvddlSemester" runat="server" ControlToValidate="ddlSemester" ErrorMessage="Please Select Semester !!!" ForeColor="Red" InitialValue="0" ValidationGroup="grpSave"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label3" Text="Test Name :" runat="server" ></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTestName" runat="server" width="180"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Total Marks :"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalMarks" runat="server" width="180" TextMode="Number"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please Enter Test Name !!!"
                                        ControlToValidate="txtTestName" ValidationGroup="grpSave" ></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtTotalMarks" ErrorMessage="Please Enter Total Marks !!!" ForeColor="Red"  ValidationGroup="grpSave"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <%--<tr>
                                <td>
                                    <asp:Label ID="Label9" Text="Choose File :" runat="server" ></asp:Label>
                                    <asp:Label ID="Label10" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>
                                   
                                </td>
                                <td>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Please Choose Excel File !!!"
                                        ControlToValidate="FileUpload1" ValidationGroup="grpSave" ></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>--%>


                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="2">

                                    <asp:Button ID="btnGo" runat="server" class="btn btn-primary" 
                                        Text="Show" ValidationGroup="grpSave" OnClick="btnGo_Click" style="height: 28px" />
                                    
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                        </table>
                    </div>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Height="650px" HorizontalAlign="Center"  Width="100%" ScrollBars="Auto" Visible="False">
                                        <asp:GridView ID="grdResultFormat" runat="server" BackColor="White" BorderColor="#3366CC" 
                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="80%"  AutoGenerateColumns="False" >

                                            <EditRowStyle BorderStyle="None" />
                                            <EmptyDataRowStyle BorderStyle="None" />
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                            <PagerStyle BackColor="#99CCCC" BorderStyle="None" ForeColor="#003399" 
                                                HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                            <SelectedRowStyle BackColor="#009999" BorderStyle="None" Font-Bold="True" 
                                                ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>
                                    
                                        </asp:Panel>
                    <br /><center><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"  CssClass="btn-primary form-control" ValidationGroup="grpSave" Visible="False"/></center>


                    <%--<asp:Panel ID="Panel2" runat="server" Height="350px" ScrollBars="Auto" Width="100%" Visible="False">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
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
                        </asp:Panel>--%>
                        <br />
                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>

            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br /><center><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"  CssClass="btn-primary form-control" ValidationGroup="grpSave" Visible="False"/></center>

                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>--%>
        </asp:Panel>
    </div>
</asp:Content>
