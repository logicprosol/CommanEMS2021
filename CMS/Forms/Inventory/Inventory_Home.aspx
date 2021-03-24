<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Inventory/Inventory.Master"
    AutoEventWireup="true" CodeBehind="Inventory_Home.aspx.cs" Inherits="CMS.Forms.Inventory.Inventory_Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
        <!--Start of Tawk.to Script-->
<script type="text/javascript">
    var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
    (function () {
        var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
        s1.async = true;
        //s1.src = 'https://embed.tawk.to/5ae031b45f7cdf4f0533978e/1cbtvpt7e';
          s1.src='https://embed.tawk.to/5c287cd582491369ba9fec5b/default';
        s1.charset = 'UTF-8';
        s1.setAttribute('crossorigin', '*');
        s0.parentNode.insertBefore(s1, s0);
    })();
</script>
<!--End of Tawk.to Script-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 900px; width: 900px; margin-top: 0px; border: medium double#0C7BFA;"
        align="center">
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>WelCome To College Management Systems </li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Width="800px" Height="860px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/AddCategories2.jpg" alt="Add Categories" height="150px" width="150px" />
                    </td>
                    <td align="center">
                        &nbsp;<img src="../../images/AddUnits.jpg" alt="Add Units" height="150px" width="150px" />
                    </td>
                    <td align="center">
                        &nbsp;<img src="../../images/AddItems1.jpg" alt="Add Items" height="150px" width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnCategoryMaster" runat="server" class=" btn btn-primary" ForeColor="White"
                        style="background: linear-gradient( #82191D, #221E1B );" OnClick="lbtnCategoryMaster_Click" Width="120px">Add Categories</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnUnitMaster" runat="server" class=" btn btn-primary" ForeColor="White"
                           style="background: linear-gradient( #82191D, #221E1B );"  OnClick="lbtnUnitMaster_Click" Width="120px">Add Units</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnStock" runat="server" class=" btn btn-primary" ForeColor="White"
                           style="background: linear-gradient( #82191D, #221E1B );"  OnClick="lbtnItem_Click" Width="120px">Add Items</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                        <img src="../../images/AddSupplier1.jpg" alt="Suppliers" height="150px" width="150px" />
                    </td>
                    <td style="" align="center">
                        <img src="../../images/PurchaseOrder.png" alt="Purchase Order" height="150px" width="150px" />
                    </td>
                    <td style="" align="center">
                         <img src="../../images/StockMgmt.jpg" alt="Stock View" height="150px" width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtnSupplier" runat="server" class=" btn btn-primary" ForeColor="White"
                          style="background: linear-gradient( #82191D, #221E1B );"   OnClick="lbtnSupplier_Click" Width="120px">Supplier</asp:LinkButton>
                    </td>
                    <td align="center">
                        <asp:LinkButton ID="lbtnPurchaseOrder" runat="server" class=" btn btn-primary" ForeColor="White"
                          style="background: linear-gradient( #82191D, #221E1B );"   OnClick="lbtnPurchaseOrder_Click" Width="120px">Purchase Order</asp:LinkButton>
                    </td>
                    <td align="center">
                      <asp:LinkButton ID="LinkButton1" runat="server" class=" btn btn-primary" ForeColor="White"
                          style="background: linear-gradient( #82191D, #221E1B );"   OnClick="lbtnStockMgmt_Click" Width="120px">Stock View</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 150px">
                         <img src="../../images/Admin_Settings.jpg" alt="Setting" height="150px" width="150px" />
                    </td>
                    <td align="center" style="height: 150px">
                        &nbsp;</td>
                    <td style="" align="center">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                       <asp:LinkButton ID="LinkButton2" runat="server" class=" btn btn-primary" ForeColor="White"
                           style="background: linear-gradient( #82191D, #221E1B );"  OnClick="lbtnSettings_Click" Width="120px">Settings</asp:LinkButton>
                    </td>
                    <td align="center">
                        &nbsp;</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
                
            </table>
        </asp:Panel>
    </div>
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
