<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="UploadDocument.aspx.cs" Inherits="CMS.Forms.Faculty.UploadDocument" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 268435488px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 900px; width: 920px;">
                <asp:Panel ID="Panel_UploadDocument" runat="server" align="center" Visible="true"
                    Style="height: 900px; width: 915px; border: medium double#0C7BFA;">
                    <div style="width: 100%; height: auto;">
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>Upload Document</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                        <table width="80%" align="center">
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblUploadPurpose" runat="server" Text="Select Purpose : "></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="center" colspan="3" class="auto-style1">
                                    <asp:RadioButtonList ID="rbtnPurpose" Width="426px" runat="server" RepeatDirection="Horizontal"
                                        Class="radio" AutoPostBack="true" ValidationGroup="ValidateControl" OnSelectedIndexChanged="rbtnPurpose_SelectedIndexChanged">
                                       <%-- <asp:ListItem Text="Course Material" Value="1" Selected="False"> </asp:ListItem>
                                        <asp:ListItem Text="Assignment" Value="0" Selected="False"></asp:ListItem>--%>
                                        <asp:ListItem Text="Home Work/Assignment" Value ="2" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvrbtnPurpose" runat="server" ErrorMessage="Please Choose purpose !!!"
                                        ControlToValidate="rbtnPurpose" ForeColor="Red" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 90%; height: auto; margin-top: 10px;" align="center">
                        <table width="80%" align="center">
                            <tr>
                                <td align="left" width="125px">
                                    <asp:Label ID="lblCourse" runat="server" Text="Select Course : "></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                        OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" ValidationGroup="ValidateControl"  width="180">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ErrorMessage="Please Select Course !!!"
                                        ControlToValidate="ddlCourse" InitialValue="-1" ForeColor="Red" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblBranch" runat="server" Text="Select Branch : "></asp:Label>
                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                        OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" ValidationGroup="ValidateControl"  width="180">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ErrorMessage="Please Select Branch !!!"
                                        ControlToValidate="ddlBranch" InitialValue="-1" ForeColor="Red" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblClass" runat="server" Text="Select Class : "></asp:Label>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" Style="margin-top: 5px;"
                                        ValidationGroup="ValidateControl" 
                                        onselectedindexchanged="ddlClass_SelectedIndexChanged"  width="180">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ErrorMessage="Please Select Class !!!"
                                        ControlToValidate="ddlClass" InitialValue="-1" ForeColor="Red" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblDivision" runat="server" Text="Select Division : " Visible="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" Style="margin-top: 5px;"  width="180" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" Visible="False">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject : "></asp:Label>
                                    <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSubject" runat="server" ValidationGroup="ValidateControl"></asp:TextBox>
                                    <asp:DropDownList ID="DDSubject" runat="server" AutoPostBack="true" Style="margin-top: 5px;" width="180" ValidationGroup="ValidateControl">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvtxtSubject" runat="server" ErrorMessage="Please enter Subject !!!"
                                        ControlToValidate="DDSubject" ForeColor="Red" ValidationGroup="ValidateControl" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvDDSubject" runat="server" ControlToValidate="DDSubject" Display="Dynamic" ErrorMessage="Please Select Subject !!!" ForeColor="Red" InitialValue="0" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblMessage" runat="server" Text="Message : "></asp:Label>
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtMessage" runat="server" Rows="4" TextMode="MultiLine" Height="50px" ValidationGroup="ValidateControl"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:FileUpload ID="flpUploadFile" runat="server" accept=".png,.jpg,.jpeg,.gif,.pdf"/>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="* .png,.jpg,.jpeg,.gif,.pdf files only"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSend" runat="server" Text="Upload" class="btn btn-primary" CausesValidation="true"
                                        OnClick="btnSend_Click"  />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvflpUploadFile" runat="server" ControlToValidate="flpUploadFile" ErrorMessage="Please Select File !!!" ForeColor="Red" ValidationGroup="ValidateControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                 <td class="auto-style10" style="color:red" colspan="3">Upload image only with maximum size of 1MB </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>
             <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSend" />
        </Triggers>
    </asp:UpdatePanel>
   
</asp:Content>