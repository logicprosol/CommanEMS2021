<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="addmissiondetails.aspx.cs" Inherits="CMS.Forms.SuperAdmin.addmissiondetails" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <center> <div style="margin-top:-445px;margin-left:50px">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:DropDownList ID="ddlCountries" runat="server" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged"
    AutoPostBack="true">
</asp:DropDownList>
<hr />
<AjaxControlToolkit:BarChart ID="BarChart1" runat="server" ChartHeight="300" ChartWidth = "450"
    ChartType="Column" ChartTitleColor="#82191D" Visible = "false"
    CategoryAxisLineColor="#82191D" ValueAxisLineColor="#82191D" BaseLineColor="#82191D">
</AjaxControlToolkit:BarChart>
    </div>
       </center>
</asp:Content>
