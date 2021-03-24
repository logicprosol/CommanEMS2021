<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="idcardmarathi.aspx.cs" Inherits="CMS.Forms.Admin.idcardmarathi" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <!--Add CSS Here in contentPlaceHolder1-->
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>




<div id="google_translate_element"></div><script type="text/javascript">
function googleTranslateElementInit() {
  new google.translate.TranslateElement({pageLanguage: 'en', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
}
</script><script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>


    <style type="text/css">
        .auto-style2 {
            width: 265px;
        }
        .auto-style3 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', '');
             printWindow.document.write('<html><head><title>Student I Card</title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>

    <div style="height: 900px; width: 920px; border: medium double#0C7BFA;" >
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th colspan="2" style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>Generate Student-Id Card </li>
                    </ul>
                </th>
            </tr>
        </table>
        <table border="0" width="100%" align="center" cellspacing="2px">
                       <tr>
                       <td colspan="4">
                       <br />
                       </td>
                       </tr>
                            <tr>
                                <td>
                                   
                                    <asp:Label ID="Label1" runat="server" Text="Course:"></asp:Label>
                                
                                    <asp:DropDownList ID="ddlcourse" runat="server" Width="110px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ErrorMessage="Please select Course"
                                      ControlToValidate="ddlCourse" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                     </td>
                                <td>
                                    
                                    <asp:Label ID="Label2" runat="server" Text="Branch:"></asp:Label>
                              
                                    <asp:DropDownList ID="ddlbranch" runat="server" Width="110px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ErrorMessage="Please select Branch"
                                      ControlToValidate="ddlbranch" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                <td>
                                    
                                    <asp:Label ID="Label3" runat="server" Text="Class:"></asp:Label>
                                    <asp:DropDownList ID="ddlclass" runat="server" Width="110px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ErrorMessage="Please select Class"
                                      ControlToValidate="ddlClass" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                <td>
                                    
                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Course"
                                      ControlToValidate="ddlCourse" InitialValue="Select" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                  </td>
                                  </tr>
                             <tr>
                                <td align="center" colspan="4">
                                    
                                    <asp:Button ID="btnGo" runat="server" Text="Go" class="btn btn-primary" OnClick="btnGo_Click" />
                                </td>
                            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Panel ID="Panel3" runat="server" class="well well-large" Height="200px" Width="90%"  style="max-height: 400px; overflow-y:scroll">
                        <asp:GridView ID="grdIcard" runat="server" AutoGenerateColumns="False" Width="95%" 
                            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" DataKeyNames="UserCode,FullName" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  OnPageIndexChanging="grdIcard_PageIndexChanging"  ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
                            <Columns>
                                <asp:BoundField HeaderText="Student ID" DataField="UserCode" />
                                <asp:BoundField HeaderText="Student Name" DataField="FullName" />
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <center><asp:Button ID="btnView" runat="server" class="btn btn-primary" Text="Preview" OnClick="btnView_Click" /></center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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
                </td>
            </tr>
        </table>
        <table border="0" width="80%" align="center" style="height: auto" cellspacing="2px">
            <tr>
                <td align="center">
                    <asp:Panel ID="pnlContents" runat="server" Width="300px" Height="347px" Visible="false"
                        class="well well-large">
                        <asp:Panel ID="Panel2" runat="server" Width="300px" Style="border: medium double#82191D; margin-left: 0px;">
                            <table width="300px" border="0" align="center" >
                                <tr>
                                    <td rowspan="2" width="60px">
                                        <asp:Image ID="imgClgLogo" runat="server" Height="50px" Width="50px" />
                                    </td>
                                   
                                    <%--<td colspan="3">
                                        <asp:Label ID="lblTrustName" runat="server" Height="16px" forcolor="#C13D1F"></asp:Label>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <%--<td height="10px">
                                        &nbsp;
                                    </td>--%>
                                    <td colspan="2">
                                        <asp:Label ID="lblCollageFullName" runat="server" Style="font-size: 15px; color: #82191D"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lbldate" runat="server" Text="lbldate"></asp:Label>
                                    </td>
                                    </tr>
                            </table>
                                    <table align="center">
                                        <tr>
                                     <td rowspan="3" >
                                        <asp:Image ID="imgStud" runat="server" Width="85px" Height="80px" Style="margin-top: 0px;border-radius:70px"   />
                                    </td>
</tr>
                                     </table>
                             <table>
                                 <tr>
                                    <td>
                                     <%--   <asp:Label ID="lblAddress" runat="server" Text="" Style="font-size: xx-small"></asp:Label>--%>
                                    </td>
                                   <%-- <td rowspan="3" >
                                        <asp:Image ID="imgStud" runat="server" Width="75px" Height="70px" Style="margin-top: 0px;border-radius:70px"   />
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="3" width="70px" >
                                       &nbsp;<asp:Label ID="Label23" runat="server" Text="Name" Style="font-weight: 500"></asp:Label>
                                  
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" width="70px">
                                       &nbsp;<asp:Label ID="Label5" runat="server" Text="Stud Id" Style="font-weight: 500"></asp:Label>
                                   
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStudentId" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" width="70px" class="auto-style3">
                                        &nbsp;<asp:Label ID="Label6" runat="server" Text="D.O.B" Style="font-weight: 500"></asp:Label>
                                     
                                    </td>
                                    <td class="auto-style3">
                                        <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="auto-style3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" width="70px">
                                         &nbsp;<asp:Label ID="Label12" runat="server" Text="BloodGp" Style="font-weight: 200"></asp:Label>
                                     
                                         </td>
                                    <td>
                                        <asp:Label ID="lblbloodGroup" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    
                                  <%--  <td>
                                        <asp:Image ID="imgSign" runat="server" Height="20px" Width="75px" />
                                    </td>--%>
                                      <td colspan="3" width="70px">
                                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Course" Style="font-weight: 500"></asp:Label>
                        
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCourse" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                  <%--  <td>
                                    </td>
                                    <td class="auto-style1">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>--%>
                                   
                                    <td colspan="3" width="70px">
                                        &nbsp;<asp:Label ID="Label7" runat="server" Text="Class" Style="font-weight: 500"></asp:Label>
                                     
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStream" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" Width="300px" Style="border: medium double#82191D;">
                            <table width="300px" border="0" >
                                <tr>
                                    <td colspan="6" width="120px">
                                        &nbsp;<asp:Label ID="Label8" runat="server" Text="Address" Style="font-weight: 500"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentAddress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Permanent Address:" Style="font-weight: 500"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address" Style="font-weight: 500"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <%--<td colspan="6" width="120px">
                                        &nbsp;<asp:Label ID="Label10" runat="server" Text="E_mail" Style="font-weight: 500"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td colspan="6" width="120px">
                                         &nbsp;<asp:Label ID="Label13" runat="server" Text="Mobile" Style="font-weight: 500"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblParentConctact" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" width="120px">
                                        &nbsp;<asp:Label ID="Label11" runat="server" Text="Aadhar" Style="font-weight: 500"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:Label ID="lblAdharCard" runat="server" Text="" Style="font-weight: 500"></asp:Label>
                                    </td>
                                </tr>
                               
                            </table>
                            <table style="width:300px">
                                 <tr style="width:700px;color: #FFFFFF; background-color: #0099FF">
                                    <td  align="center" style="color: #FFFFFF; background-color: #82191D" class="auto-style2"  >
                                        Powered By LogicPro Solutions.
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center">
               <asp:Button ID="btnPrint" runat="server" Text="Print" Visible="false" class=" btn btn-info" OnClientClick="return PrintPanel();" OnClick="btnPrint_Click" />
                </td>
            </tr>
        </table>
        <ucMsgBox:MsgBox ID="msgBox" runat="server" />
    </div>
</asp:Content>
