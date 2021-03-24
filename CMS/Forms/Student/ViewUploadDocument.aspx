<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master"
    AutoEventWireup="true" CodeBehind="ViewUploadDocument.aspx.cs" Inherits="CMS.Forms.Student.ViewUploadDocument" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />

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
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="GrdUploadDocument" />
    <asp:PostBackTrigger ControlID="lnkDownload" />
    </Triggers>
        <ContentTemplate>
            <div style="height:900px; width:1000px; margin-top: 0px; border: medium double#0C7BFA;"
                align="left">
                <asp:Panel ID="Panel_UploadDocument" runat="server" align="center" Visible="true"
                    Style="height: 100%; width: 100%;">
                    <div style="width: 100%; height: auto;">
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i>View Upload Document</li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 72%; height: auto; margin-top: 30px;"
                        align="center">
                        <table width="100%" align="center">
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblUploadPurpose" runat="server" Text="Select Purpose  " Font-Size="Medium"
                                        ForeColor="Black"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*" Font-Size="Medium"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:RadioButtonList ID="rbtnPurpose" Width="414px" runat="server" RepeatDirection="Horizontal"
                                        Class="radio" AutoPostBack="true" OnSelectedIndexChanged="rbtnPurpose_SelectedIndexChanged"
                                        Font-Size="Medium" ForeColor="Black">
                                        <%--<asp:ListItem Text="Course Material" Value="1" Selected="False"> </asp:ListItem>
                                        <asp:ListItem Text="Assignment" Value="0" Selected="False"></asp:ListItem>--%>
                                        <asp:ListItem Value="2" Text="Home Work" Selected="True"></asp:ListItem><%--Selected="True"--%>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Documents   " Font-Size="Medium" ForeColor="Black"></asp:Label>
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <div class=""  style="max-height:250px; overflow-y:scroll;">
                         <table width="100%"    align="center" >
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GrdUploadDocument" runat="server" AutoGenerateColumns="False" DataKeyNames="UploadDocReceiptId,DocumentName,SenderName,Date,Subject,MessageContent,UploadDocId"
                                        BorderColor="#3366CC" BorderStyle="None" CellPadding="4" Width="100%" BackColor="White"
                                        BorderWidth="1px" onrowdeleting="GrdUploadDocument_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="DocumentName" HeaderText="DocumentName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SenderName" HeaderText="SenderName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnView" Text="View" runat="server" OnClick="linkbtnView_Click" />
                                                    <asp:Label ID="Label2" runat="server" Text="/"></asp:Label>
                                                    <asp:LinkButton ID="lnkbtnDelete" Text="Delete" CommandName="Delete" runat="server" OnClientClick = "ConfirmDelete()" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
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
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                            </div>
                    </div>
                    <div style="width: 72%; height: 322px; border: medium double#0C7BFA;" align="left">
                        <table border="0" width="100%" align="center" cellspacing="2px">
                            <tr>
                                <th colspan="4" style="background-color: #0C7BFA; color: White; text-align:center;">
                                    <ul class="nav nav-list">
                                        <li><i class="icon-book"></i><asp:Label ID="lblTitle" runat="server" Text="Please select purpose" Font-Size="Medium" ForeColor="White"></asp:Label></li>
                                    </ul>
                                </th>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel1" runat="server" align="left" Visible="true" Style="height: 250px;
                            width: 92%;" class="well well-large">
                            
                            <table width="60%">
                                <%--<tr>
                                    <td colspan="2" align="right">
                                        <asp:Label ID="lblTitle" runat="server" Text="" Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSubject" runat="server" Text="Subject  " Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDocumentSubject" runat="server" Text="No Document Selected" Font-Size="Medium"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 100px;">
                                    <td>
                                        <asp:Label ID="lblMessage" runat="server" Text="Message  " Font-Size="Medium" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDocumentMessage" runat="server" Text="Message Not Found" Font-Size="Medium"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDocumentDownload" runat="server" Text="Downloads  " Font-Size="Medium"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="No Document Selected" 
                                            Font-Size="Medium" onclick="DownloadFile"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </div>
            <ucMsgBox:MsgBox ID="msgBox" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
