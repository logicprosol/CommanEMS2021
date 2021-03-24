<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagePopup.ascx.cs" Inherits="BTSDemo.UserControls.PagePopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<cc2:ModalPopupExtender ID="mpext" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnOk"
    DropShadow="true" TargetControlID="pnlPopup" PopupControlID="pnlPopup">
</cc2:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="pagelPopup" DefaultButton="btnOk"
    Style="display: block;">
    <table width="100%">
        <tr class="topHandle">
            <td align="right" runat="server" id="tdCaption">
                <asp:Label ID="lblCaption" ForeColor="White" runat="server"></asp:Label>
                <asp:ImageButton ID="btnOk" runat="server" Height="25px" CausesValidation="false" 
                    ImageUrl="~/Images/CloseBtn2.png" Width="25px" OnClientClick="fnPopup()" />
            </td>
        </tr>
        <tr>
            <td valign="middle" align="left">
                <iframe id="PgPopup" height="400px" scrolling="auto" runat="server" style="width: 990px">
                </iframe>
            </td>
        </tr>
    </table>
</asp:Panel>
<script type="text/javascript">
    function fnClickOK(sender, e) {
        __doPostBack(sender, e);
    }
</script>