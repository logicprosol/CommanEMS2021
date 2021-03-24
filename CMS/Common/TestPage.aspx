<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CMS.Common.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
    <asp:DropDownList ID="DdlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlCountry_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
    <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlState_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
    <asp:DropDownList ID="DdlCity" runat="server">
    </asp:DropDownList>
    <asp:CheckBox ID="chkSameasAbove" runat="server" OnCheckedChanged="chkSameasAbove_CheckedChanged" />
    </form>
</body>
</html>