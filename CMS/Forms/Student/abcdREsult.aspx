<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Student/Student_Home.Master" AutoEventWireup="true" 
    CodeBehind="abcdREsult.aspx.cs" Inherits="CMS.Forms.Student.abcdREsult" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
     </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="margin-left:370px; margin-top:-50px">  
          
         <table style="border:outset;width:210px;"> 
          
             <tr>
                 <td>
                    
           <asp:Label ID="Label1" runat="server" Text="Number of Questions" Font-Size="Medium" Font-Bold="True"></asp:Label> 
         &nbsp; &nbsp; 
          <asp:Label ID="lblOutOf" runat="server" Text="Total Marks" Font-Size="Medium" Font-Bold="True" ForeColor="Red"></asp:Label>

                 </td>
     </tr>
             <tr>
                 <td>
         <asp:Label ID="Label2" runat="server" Text="Correct Answer" Font-Size="Medium" Font-Bold="True"></asp:Label> &nbsp; &nbsp;
          <asp:Label ID="lblObtain" runat="server" Text="Obtain Marks" Font-Size="Medium" Font-Bold="True" ForeColor="Red"></asp:Label>
                     </td>
                </tr>
              
             </table>
                  
     </div>
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div style="margin-top:-430px" >
    <center><asp:Button ID="Button1" runat="server" Text="Show Report" OnClick="Button1_Click" CssClass="btn-primary" Visible="false"/></center>
    <br/>
        <br/>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="500px" Width="1000px"></rsweb:ReportViewer>

      
    </div>
        </asp:Content>
