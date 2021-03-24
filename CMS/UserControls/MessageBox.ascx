<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs"
    Inherits="CMS.UserControls.MessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
<cc2:ModalPopupExtender ID="mpext" runat="server" BackgroundCssClass="modalBackground"
    DropShadow="true" TargetControlID="pnlPopup" PopupControlID="pnlPopup">
</cc2:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" DefaultButton="btnOk"
    Style="display: none;">
    <table width="400px" style="border: double #B8BEE0; border-color: Blue; background-color: #B8BEE8">
        <tr style="height: 35px; width: 400px;">
            <td colspan="2" align="left" runat="server" id="tdCaption" style="background-color: Blue;
                height: 35px; width: 400px">
                &nbsp;
                <asp:Label ID="lblCaption" ForeColor="White" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="min-height: 40px; width: 400px;">
            <td style="width:100px" valign="middle" align="center" >
                <asp:Image ID="imgInfo" runat="server" ImageUrl="~/images/msg_information.png" Height="100px"
                    Width="100px" />
            </td>
            <td valign="middle" align="left">
                <asp:Label ID="lblMessage" ForeColor="#289615" runat="server"></asp:Label>
            </td> 
        </tr>
        <tr style="height: auto; width: 400px;">
            <td colspan="2" align="right" style="height: 50px; width: 400px;">
                <asp:Button ID="btnYes" Width="80px" Height="45px" runat="server" OnClientClick="btnYesClick()"
                    Text="Yes" class="btn btn-success" />
                <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" CssClass="ButtonsCSS"
                    Width="80px" Height="45px" class="btn btn-success" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Panel>
<script type="text/javascript">
    function fnClickOK(sender, e) {
        __doPostBack(sender, e);
    }
</script>