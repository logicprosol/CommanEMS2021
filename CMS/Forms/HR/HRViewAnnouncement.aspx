<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="HRViewAnnouncement.aspx.cs" Inherits="CMS.Forms.HR.HRViewAnnouncement" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function DeleteAll(oCheckbox) {
            var GridView2 = document.getElementById("<%=GrdViewAnnouncement.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
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

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 930px;height: 900px; border: medium double#0C7BFA;"><%-- --%>
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center">
            <div style="height: 798px; width: 930px;"><%----%>
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>View Announcement</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="90%" align="center">
                            <tr>
                                <td colspan="3" align="left">
                                    <asp:Label ID="lblInbox" runat="server" Text="Inbox : "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left">
                                    <asp:GridView ID="GrdViewAnnouncement" runat="server" CellPadding="4"
                                        DataKeyNames="MessageId,StaffUserCode,Sender,Subject,SendDate,MessageContent" 
                                        Width="80%" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" 
                                        BorderColor="#3366CC" BorderStyle="None"
                                        OnSelectedIndexChanged="GrdViewAnnouncement_SelectedIndexChanged" 
                                        BackColor="White" BorderWidth="1px" 
                                        onrowdeleting="GrdViewAnnouncement_RowDeleting" 
                                        onpageindexchanging="GrdViewAnnouncement_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField HeaderText="From" DataField="Sender" HtmlEncode="false" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Subject" DataField="Subject" HtmlEncode="false" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnView" runat="server" Text='<%#Eval("Subject") %>' OnClick="linkbtnView_Click" />
                                                    <span class="body" style="display: none"></span>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:BoundField HeaderText="Date" DataField="SendDate" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxDeleteAll" runat="server" Text="Delete All" onclick=" DeleteAll(this) " />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="checkbox" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>

                                                <asp:LinkButton ID="lnkbtnView" runat="server" Text='View' OnClick="linkbtnView_Click" />
                                                    <span class="body" style="display: none"></span>

                                                    <%--<asp:LinkButton ID="lnkbtnView" Text="View" runat="server" />--%>
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
                                        <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" 
                                            HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" 
                                            ForeColor="#CCFF99" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>
                                        <asp:Label ID="lblNoMessageFound" runat="server" Text="No Message found !!!" Visible="false"
                                            ForeColor="Red"></asp:Label></h3>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left">
                                    <asp:Button runat="server" ID="HiddenTargetControlForModalPopup" Style="display: none;" />
                                    <asp:ModalPopupExtender ID="MessagePopUp" runat="server" TargetControlID="HiddenTargetControlForModalPopup"
                                        CancelControlID="btnClose" PopupControlID="PopupDiv" DropShadow="True">
                                    </asp:ModalPopupExtender>
                                    <!-- Button trigger modal -->
                                    <div id="PopupDiv" style="width: 400px; height: 330px; padding: 10px; background-color: #E1DCF2;
                                        border: medium double#0C7BFA;">
                                        <h4 style="background-color: Blue; color: White; font-size: 15px;">
                                            View Message</h4>
                                        <hr />
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    From :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFrom" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Subject :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblMessage" runat="server" Text="Message : "></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left">
                                                    <asp:TextBox ID="txtMessage" runat="server" Rows="4" Columns="100" TextMode="MultiLine"
                                                 style = "resize:none"       Width="93%" Height="100px" OnTextChanged="txtMessage_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left">
                                                    <asp:Label ID="lblAttachment" runat="server" Text="Attachments" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <%--<asp:GridView ID="GrdAttachement" DataKeyNames="FileId,MessageId" runat="server"
                                                        AutoGenerateColumns="false" GridLines="None" BorderStyle="None" Width="100%" OnSelectedIndexChanged="GrdAttachement_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="FileName" HeaderText="" />
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="lnkDownload" />
                                                                        </Triggers>
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"></asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnClose" class="btn btn-danger" runat="server" Text="Close" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- /.modal -->
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />



</asp:Content>
