<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Faculty/Faculty.Master" AutoEventWireup="true"
    CodeBehind="ViewAnnouncementStaff.aspx.cs" Inherits="CMS.Forms.Faculty.ViewAnnouncementStaff" %>

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

    <script type="text/javascript">
        function ConfirmDelete() {

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            //document.forms[0].replaceChild(confirm_value, document.forms[0].lastChild);
            document.forms[0].appendChild(confirm_value);

        }

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }

        .auto-style2 {
            height: 22px;
            width: 101px;
        }

        .auto-style3 {
            width: 101px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 930px; height: 900px; border: medium double#0C7BFA;">
        <%----%>
        <asp:Panel ID="Panel_ViewAnnouncement" runat="server" align="center" ChildrenAsTriggers="True">
            <div style="height: 798px; width: 930px;">
                <%----%>
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <th colspan="4" style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>View Announcement</li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <br />
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="overflow: scroll; height: 750px">
                            <table width="90%" align="center">
                                <tr>
                                    <td colspan="3" align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <%--  <asp:Label ID="lblInbox" runat="server" Text="Inbox : "></asp:Label>--%>
                                                    <asp:RadioButtonList ID="rbtnSender" runat="server" RepeatDirection="Horizontal"
                                                        CssClass="radio" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rbtnSender_SelectedIndexChanged">
                                                        <asp:ListItem Text="Inbox" Selected="True" Value="Inbox"> </asp:ListItem>
                                                        <asp:ListItem Text="Send" Value="Send"></asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </td>
                                               <%-- <td>
                                                    <asp:Label ID="lblsearch" runat="server" Text="Search: " Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Empsearch" runat="server" Width="250px" placeholder="Enter Emp Name"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                                </td>--%>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="left">
                                        <div id="InboxDiv" runat="server" visible="true">
                                            <asp:GridView ID="GrdViewAnnouncement" runat="server" CellPadding="4"
                                                DataKeyNames="MessageId,StaffUserCode,Sender,Subject,SendDate,MessageContent"
                                                Width="100%" AutoGenerateColumns="False" AllowPaging="false" PageSize="10"
                                                BorderColor="#3366CC" BorderStyle="None"
                                                OnSelectedIndexChanged="GrdViewAnnouncement_SelectedIndexChanged"
                                                BackColor="White" BorderWidth="1px"
                                                OnRowDeleting="GrdViewAnnouncement_RowDeleting" OnRowDataBound="GrdViewAnnouncement_RowDataBound" 
                                                OnPageIndexChanging="GrdViewAnnouncement_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField HeaderText="From" DataField="Sender" HtmlEncode="false" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                  <%--  <asp:BoundField HeaderText="Subject" DataField="Subject" HtmlEncode="false" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>--%>
                                                     <asp:TemplateField HeaderText="Subject" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>

                                                <asp:LinkButton ID="lnkbtnSubjectView" ForeColor="blue" runat="server" Text='<%#Eval("Subject") %>' Visible="false" OnClick="lnkbtnSubjectView_Click"/>
                                                 <asp:Label ID="lblSubjectView" runat="server" Text='<%#Eval("Subject") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnView" runat="server" Text='<%#Eval("Subject") %>' OnClick="linkbtnView_Click" />
                                                    <span class="body" style="display: none"></span>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                                    <asp:BoundField HeaderText="Date" DataField="SendDate" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
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
                                                            <asp:LinkButton ID="lnkbtnDelete" Text="Delete" CommandName="Delete" runat="server" OnClientClick="ConfirmDelete()" />
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
                                                <RowStyle BackColor="White" ForeColor="#003399" Font-Size="Medium" />
                                                <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True"
                                                    ForeColor="#CCFF99" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3" align="left">
                                        <div id="SendBox" runat="server" visible="false">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="780px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject">
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MessageContent" HeaderText="MessageContent" SortExpression="MessageContent">
                                                        <ItemStyle Width="300px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SendDate" HeaderText="SendDate" ReadOnly="True" SortExpression="SendDate">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lbld" runat="server" Text="No record present"></asp:Label>
                                                </EmptyDataTemplate>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>


                                        </div>
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
                                        <div id="PopupDiv" style="width: 400px; height: 330px; padding: 10px; background-color: #E1DCF2; border: medium double#0C7BFA;">
                                            <h4 style="background-color: Blue; color: White; font-size: 15px;">View Message</h4>
                                            <hr />
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="auto-style2">&nbsp;<asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="From :"></asp:Label>
                                                    </td>
                                                    <td align="left" class="auto-style1">
                                                        <asp:Label ID="lblFrom" runat="server" Font-Size="Medium"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">&nbsp;<asp:Label ID="Label8" runat="server" Font-Size="Medium" Text="Subject :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSubject" runat="server" Visible="false" Font-Size="Medium"></asp:Label>
                                                        <asp:linkbutton Id="lnkbtnViewSubjectClick" Visible="false" runat="server" Font-Size="Medium" OnClick="lnkbtnViewSubjectClick_Click"  ></asp:linkbutton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style3">
                                                        <asp:Label ID="lblMessage" runat="server" Text="Message : " Font-Size="Medium"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="left">
                                                        <asp:TextBox ID="txtMessage" runat="server" Rows="4" Columns="100" TextMode="MultiLine"
                                                            Style="resize: none" Width="93%" Height="100px" Font-Size="Medium"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="left">
                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachments" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <center>
                                                            <asp:Button ID="btnClose" runat="server" class="btn btn-danger" Text="Close" />
                                                        </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">&nbsp;
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                        <!-- /.modal -->
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                            SelectCommand="SELECT dbo.tblEmployee.FirstName + ' ' + dbo.tblEmployee.LastName AS Name, dbo.tblMessageSave.Subject, dbo.tblMessageSave.MessageContent, Convert( Varchar(20),dbo.tblMessageDetails.SendDate,105) SendDate
 FROM dbo.tblMessageSave INNER JOIN dbo.tblMessageDetails ON dbo.tblMessageSave.MessageId = dbo.tblMessageDetails.MessageId INNER JOIN dbo.tblEmployee ON dbo.tblMessageDetails.StaffUserCode = dbo.tblEmployee.UserCode WHERE (dbo.tblMessageSave.StaffUserCode = @StaffUserCode) AND (dbo.tblMessageSave.OrgId = @OrgId) order by dbo.tblMessageSave.MessageId desc"
                           >
                            <SelectParameters>
                                <asp:SessionParameter Name="StaffUserCode" SessionField="UserCode" />
                                <asp:SessionParameter Name="OrgId" SessionField="OrgId" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                            SelectCommand="SELECT dbo.tblEmployee.FirstName + ' ' + dbo.tblEmployee.LastName AS Name, dbo.tblMessageSave.Subject, dbo.tblMessageSave.MessageContent, Convert( Varchar(20),dbo.tblMessageDetails.SendDate,105) SendDate
 FROM dbo.tblMessageSave INNER JOIN dbo.tblMessageDetails ON dbo.tblMessageSave.MessageId = dbo.tblMessageDetails.MessageId INNER JOIN dbo.tblEmployee ON dbo.tblMessageDetails.StaffUserCode = dbo.tblEmployee.UserCode WHERE (dbo.tblMessageSave.StaffUserCode = @StaffUserCode)
                                                    AND (dbo.tblMessageSave.OrgId = @OrgId) AND (tblEmployee.FirstName=@FirstName)
                                                    order by dbo.tblMessageSave.MessageId desc">
                            <SelectParameters>
                                <asp:SessionParameter Name="StaffUserCode" SessionField="UserCode" />
                                <asp:SessionParameter Name="OrgId" SessionField="OrgId" />
                      <asp:ControlParameter ControlID="Empsearch" Name="FirstName" 
                                 PropertyName="Text" Type="String" />
                            </SelectParameters>

                        </asp:SqlDataSource>

                        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
    </div>

</asp:Content>
