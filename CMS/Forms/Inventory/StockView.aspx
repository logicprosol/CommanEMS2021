<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master" AutoEventWireup="true" CodeBehind="StockView.aspx.cs" Inherits="CMS.Forms.Inventory.StockView" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            margin-top: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 920px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_PurchaseOrder" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel_PurchaseOrder" runat="server" Visible="true" Style="height: 900px;
                    width: 900px; border: medium double#0C7BFA;">
                    <table border="0" width="100%" align="center" cellspacing="2px">
                        <tr>
                            <th colspan="4" style="background-color: #0C7BFA; color: White">
                                <ul class="nav nav-list">
                                    <li><i class="icon-book"></i>Stock View</li>
                                </ul>
                            </th>
                        </tr>
   
                    </table>
                                       
                        <br />
                    <div style="border: 3px solid #0099FF; width: 800px">
                       <table style="width: 80%">
                        <tr>
                         <%--   <td>
                                <asp:GridView ID="GrdStock" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="ItemId,ItemName,ItemCode,CategoryId,UnitId,Stock"
                                    Width="80%" OnPageIndexChanging="GrdStock_PageIndexChanging" AutoGenerateColumns="False"
                                    AllowPaging="True" PageSize="7" BorderColor="#3366CC" BorderStyle="None" BackColor="White"
                                    BorderWidth="1px">
                                   <%-- <Columns>
                                        <asp:TemplateField HeaderText="Item Name " ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnItemName" runat="server" Text='<%#Eval("ItemName") %>'
                                                    OnClick="lnkBtnItemName_Click" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Code" DataField="ItemCode" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Category" DataField="CategoryName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Unit" DataField="UnitName" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="New Current Stock" DataField="Stock" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="New Purchase Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="Purchase Rate" DataField="Rate" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="Grand Total" DataField="GrandTotal" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BorderStyle="None" />
                                    <EmptyDataRowStyle BorderStyle="None" />
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BorderStyle="None" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BorderStyle="None" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </td>--%>
                            <asp:GridView ID="GrdStock" runat="server" CellPadding="4" ForeColor="#333333" Width="80%" OnRowDataBound="GrdStock_RowDataBound" GridLines="None" CssClass="auto-style1">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </tr>
                    </table>
</div>
                    </asp:Panel>
                     <ucMsgBox:MsgBox ID="msgBox" runat="server" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
</asp:Content>
