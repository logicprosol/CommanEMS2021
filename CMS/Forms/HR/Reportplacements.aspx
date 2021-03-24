<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/HR/HR.Master" AutoEventWireup="true" CodeBehind="Reportplacements.aspx.cs" Inherits="CMS.Forms.HR.Reportplacements" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jsapi.js" type="text/javascript"></script>
      <style type="text/css">
    h1 {
  display: inline-block;
  color: white;
  font-family: 'Righteous', serif;
  font-size: 12em; 
  text-shadow: .03em .03em 0 hsla(230,40%,50%,1);
  }
  

@keyframes shad-anim {
  0% {background-position: 0 0}
  0% {background-position: 100% -100%}
  }
   #ranjit
{
  width: 100px;
	height: 100px;
	background: red;
	
  float:left;
  margin:5px;
}
.count
{
  line-height: 100px;
  color:#0e105a;
    margin-left: 30%;
    font-size: 40px;
}
#talkbubble {
   width: 120px;
   height: 80px;
   background: red;
   position: relative;
   -moz-border-radius:    10px;
   -webkit-border-radius: 10px;
   border-radius:         10px;
  float:left;
  margin:20px;
}
#talkbubble:before {
   content:"";
   position: absolute;
   right: 100%;
   top: 26px;
   width: 0;
   height: 0;
   border-top: 13px solid transparent;
   border-right: 26px solid red;
   border-bottom: 13px solid transparent;
}

.linker
{
  font-size : 20px;
}
.page {
  background: #fff;
  width: 250px;
  height: 330px;
  margin: 50px;
  
 /* Optional Gradient */
  background: -moz-linear-gradient(top,  #ffffff 0%, #e5e5e5 100%); /* FF3.6+ */
  background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ffffff), color-stop(100%,#e5e5e5)); /* Chrome,Safari4+ */
  background: -webkit-linear-gradient(top,  #ffffff 0%,#e5e5e5 100%); /* Chrome10+,Safari5.1+ */
  background: -o-linear-gradient(top,  #ffffff 0%,#e5e5e5 100%); /* Opera 11.10+ */
  background: -ms-linear-gradient(top,  #ffffff 0%,#e5e5e5 100%); /* IE10+ */
  background: linear-gradient(top,  #ffffff 0%,#e5e5e5 100%); /* W3C */
  filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#e5e5e5',GradientType=0 ); /* IE6-9 */
}
.card {
box-shadow: 0 14px 11px 0 rgba(109, 17, 17, 0.16), 0 2px 10px 0 rgba(68, 15, 15, 0.12);
}

.card {
  margin-top: 10px;
  box-sizing: border-box;
  border-radius: 2px;
  background-clip: padding-box;
}
.card span.card-title {
    color: #fff;
    font-size: 21px;
    font-weight: 300;
    text-transform: uppercase;
    float: left;
}

.card .card-image {
  position: relative;
  overflow: hidden;
}
.card .card-image img {
  border-radius: 2px 2px 0 0;
  background-clip: padding-box;
  position: relative;
  z-index: -1;
}
.card .card-image span.card-title {
  position: absolute;
  bottom: 0;
  left: 0;
  padding: 16px;
}
.card .card-content {
  padding: 33px;
  border-radius: 0 0 2px 2px;
  background-clip: padding-box;
  box-sizing: border-box;
      background:rgba(79, 82, 186, 0.39);
}
.card .card-content p {
  margin: 0;
  color: inherit;
}
.card .card-content span.card-title {
  line-height: 48px;
}
.card .card-action {
      border-top: 1px solid #030679;
    padding: 18px;
    background: #f5f5f5;
    height:30px;
}
.card .card-action a {
  color: #ffab40;
  margin-right: 16px;
  transition: color 0.3s ease;
  text-transform: uppercase;
}
.card .card-action a:hover {
  color: #ffd8a6;
  text-decoration: none;
}
          .auto-style9 {
              width: 109px;
          }
          .auto-style13 {
              width: 164px
          }
          .auto-style14 {
              width: 66px
          }
          .auto-style15 {
              width: 70px
          }
          .auto-style16 {
              width: 34px;
          }
 </style>
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
               
        <table  width="700px">
            <tr>
                <td class="input-medium">&nbsp;</td>
                <td class="auto-style14"> &nbsp;</td>
                <td class="input-medium"> &nbsp;</td>
                <td class="auto-style15"> &nbsp;</td>
                <td class="auto-style13"> &nbsp;</td>
                <td> &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="input-medium"><div class="card-action" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Placed Students" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                                           
                            </div></td>
                <td class="auto-style14"> <asp:Label ID="lblplaced" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td class="input-medium"> 
                    
                     <asp:Label ID="Label2" runat="server" Text="Offered Students" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style15"> <asp:Label ID="LblOffered" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                <td class="auto-style13">  
                     <asp:Label ID="Label3" runat="server" Text="Unplaced Students" Font-Bold="True" Font-Size="Medium"></asp:Label>
                   

                </td>
                <td> <asp:Label ID="lblUnplaced" runat="server" Text="0" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
            </tr>
            </table>


    
    
  


    
   
        <asp:Panel ID="Panel_SetDeptDes" runat="server" Visible="true" Style=" border: medium double#0C7BFA;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnDownload" />
                </Triggers>
                <ContentTemplate>
                  

                    
                    <table border="0" align="center" cellspacing="2px">
                            
                            <tr>
                                <td class="auto-style9">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="auto-style16">
                                    &nbsp;</td>
                                
                                <td>&nbsp;</td>
                                
                            </tr>
                           
                            <tr>
                                <td class="auto-style9">
                                    <asp:RequiredFieldValidator ID="rfvSearchStudent" runat="server" ControlToValidate="ddlSearchStudent" ErrorMessage="Please Select Type !!!" ForeColor="red" InitialValue="Select" ValidationGroup="GeneralDetails"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblSearchStudent" runat="server" CssClass="formlable" Font-Bold="True" Font-Size="Medium" Text="Search Student : "></asp:Label>
                                    <asp:Label ID="Label11" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSearchStudent" runat="server" AutoPostBack="true" Height="30px" OnSelectedIndexChanged="ddlSearchStudent_SelectedIndexChanged" SelectedIndexChanged="ddlSearchStudent_SelectedIndexChanged" ValidationGroup="GeneralDetails" Width="200px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem Value="Offered &amp; Joined">Placed Student</asp:ListItem>
                                        <asp:ListItem Value="Offered">Offered Student</asp:ListItem>
                                        <asp:ListItem Value="UnPlaced">Unplaced Student</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style16">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" OnClick="btnDownload_Click" Text="DownLoad" ValidationGroup="GeneralDetails" />
                                </td>
                            </tr>
                           
                        </table>
                    <asp:Panel ID="PanelStudent" runat="server" HorizontalAlign="Center"  ScrollBars="Auto" >
                        <h2>Student Placement Report</h2>
                        <asp:GridView ID="grdStudent" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%">
                            <EmptyDataTemplate>
                                <asp:Label ID="lblSearchStudent" runat="server" CssClass="formlable" ForeColor="#FF3300" Text="No record present!"></asp:Label>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>

                    </asp:Panel>

                    </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
                </div>
           </asp:Panel>
        </div>
</asp:Content>

