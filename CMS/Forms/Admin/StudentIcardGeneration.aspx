<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="StudentIcardGeneration.aspx.cs" Inherits="CMS.Forms.Admin.AdminIcardGeneration" %>

<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Add CSS Here in contentPlaceHolder1-->
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap-tab.js" type="text/javascript"></script>

    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  
   
    
    <style type="text/css">
        .auto-style9 {
            height: auto;
        }
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents1.ClientID %>");
             var printWindow = window.open('', '', '');
             printWindow.document.write('<html><head><title>Student I Card</title>');
             printWindow.document.write('<style type="text/css">@page{size: auto;margin: 0mm;}</style>');
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
    <script type="text/javascript">
        
        function CheckAllParent(oCheckbox) {
            var GridView2 = document.getElementById("<%=grdIcard.ClientID %>");
            for (i = 1; i < GridView2.rows.length; i++) {
                GridView2.rows[i].cells[2].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
  <ContentTemplate>
     <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
            <asp:Image ID="PleaseWaitImage" ImageUrl="~/images/please_wait.gif" AlternateText="Processing"
                runat="server" Height="42px" Width="121px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
   
     <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground" />
    

    <div style="height: 950px; width: 920px; border: medium double#0C7BFA;">
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
                       <td align="center">
                           <table width="50%">
                               <tr>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvddlCourse" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please select Course" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvddlBranch" runat="server" ControlToValidate="ddlbranch" ErrorMessage="Please select Branch" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvddlClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please select Class" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:Label ID="Label1" runat="server" Text="Course:"></asp:Label>
                                       <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged" Width="110px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label2" runat="server" Text="Branch:"></asp:Label>
                                       <asp:DropDownList ID="ddlbranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" Width="110px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label3" runat="server" Text="Class:"></asp:Label>
                                       <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" Width="110px">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>&nbsp;</td>
                                   <td>
                                       <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click" Text="Go" />
                                   </td>
                                   <td>&nbsp;</td>
                               </tr>
                           </table>
                       </td>
                       </tr>
                             <tr>
                                 <td align="center">
                                     <asp:Panel ID="Panel3" runat="server" class="well well-large" Height="200px" style="max-height: 400px; overflow-y:scroll" Width="90%">
                                         <asp:GridView ID="grdIcard" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                             DataKeyNames="UserCode,FullName" EmptyDataText="No records Found"   ShowHeaderWhenEmpty="True" Width="95%">
                                             <Columns>

                                                 <asp:BoundField DataField="UserCode" HeaderText="Student Code" />
                                                 <asp:BoundField DataField="FullName" HeaderText="Student Name" />
                                                 <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick=" CheckAllParent(this)"
                                                            Text="Select All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="checkbox" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                 <%--<asp:TemplateField HeaderText="Status" ItemStyle-Width="200px">
                                                     <ItemTemplate>
                                                         <center>
                                                             <asp:Button ID="btnView" runat="server" class="btn btn-primary" OnClick="btnView_Click" Text="Preview" />
                                                         </center>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>--%>
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
                                     
                                         <br />
                                     <asp:Button ID="btnPrintLoad" runat="server" class="btn btn-primary" OnClick="btnPrintLoad_Click" Text="Next" Visible="false" />
                                     <br />
                                 </td>
                       </tr>
        </table>
        <table border="0" width="80%" align="center" cellspacing="2px" >
            
            <tr>
                <td>
                    <asp:Panel ID="pnlContents1" runat="server" ScrollBars="Auto" Height="450px" >
                        
                       
                        <table width="100%">
                            <tr>
                                <td width="33%">
 
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div style="height:374px;" >

                                 <asp:Panel ID="Panel1" runat="server" Width="220px"  Style="border:solid 2px #82191D;border-radius:10px; margin-left: 0px;">
                                     <table width="100%" border="0" align="center">
                                         <tr style="height:15px;">
                                             <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                             <td style="background-color:#94083F;width:20%;"></td>
                                             <td style="background-color:#CB0033;width:20%;"></td>
                                             <td style="background-color:#FB562D;width:20%;"></td>
                                             <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                         </tr>
                                     </table>
                                     <table width="100%" border="0" align="center">
                                         
                                         <tr>
                                             <td  width="60px" >
                                                 <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="50px" Width="50px" style="margin-top:5px;margin-left:5px;" />
                                             </td>
                                             <td colspan="4" >
                                                 
                                                 <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #82191D"></asp:Label>
                                             </td>
                                         </tr>
                                     </table>
                                     <table align="center">
                                         <tr >
                                              <td  >
                                                 <asp:Image ID="imgStud" ImageUrl='<%#Eval("Stud")%>' runat="server" Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                             </td>
                                         </tr>
                                      </table>
                                     <table align="center" width="100%">
                                          <tr>
                                              <td  ></td>
                                         </tr>
                                         
                                         <tr align="center">
                                              <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#94083F" ></asp:Label></td>
                                         </tr>
                                         <tr align="center">
                                              <td  >
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Student Id : "></asp:Label>
                                                  <asp:Label ID="lblStudentId" Text='<%#Eval("StudentId")%>' runat="server" Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                         </tr>
                                      </table>

                                     <table  width="100%">
                                          <tr>
                                              <td  colspan="5"></td>
                                         </tr>
                                         <tr >
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                             <td style="width:3%;" ></td>
                                             <td style="width:23%;" ><asp:Label ID="Label15" runat="server" Text="D.O.B"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:3%;" ><asp:Label ID="Label20" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#FB562D;" ></td>
                                             <td ></td>
                                             <td ><asp:Label ID="Label21" runat="server" Text="Blood Grp"  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="Label22" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#FB562D;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#94083F;" ></td>
                                             <td  ></td>
                                             <td ><asp:Label ID="Label23" runat="server" Text="Class"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label24" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblStream" runat="server" Text='<%#Eval("Stream")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#94083F;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#541742;" ></td>
                                             <td style="width:8%;" ></td>
                                             <td style="width:25%;" ><asp:Label ID="Label25" runat="server" Text="Mobile"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:5%;" ><asp:Label ID="Label26" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblConctact" runat="server" Text='<%#Eval("Conctact")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#541742;" ></td>
                                         </tr>
                                         <tr >
                                             <td  ></td>
                                             <td ></td>
                                             <td  ><asp:Label ID="Label27" runat="server" Text="Aadhar"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label28" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblAdharCard" runat="server" Text='<%#Eval("AdharCard")%>'  Font-Size="10px"></asp:Label></td>
                                             <td ></td>
                                         </tr>

                                         
                                      </table>
                                     <div style="border-bottom:dashed 1px #82191D;"></div>

                                     
                                   <table width="100%">
                                         <tr>
                                             <td align="center" rowspan="2" >
                                                 <asp:Label ID="Label29" runat="server" Text="Address" Font-Bold="true" ForeColor="#94083F" Font-Size="10px"></asp:Label><br />
                                                 <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                             </td>

                                             <td  align="right" style="width:30%;" >
                                                 <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                                 <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                             </td>
                                         </tr>
                                       <tr>
                                           <td  align="right" >
                                                <asp:Label ID="Label11" runat="server" Text="Signature" ForeColor="#94083F" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                             </td>
                                       </tr>
                                     </table>
                                     <table style="width:100%">
                                          <tr style="color: #FFFFFF; background-color: #94083F">
                                             <td  align="center" style="color: #FFFFFF; background-color: #94083F;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                                 
                                                 <asp:Label ID="Label30" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
                                             </td>
                                         </tr>
                                     </table>

                                 </asp:Panel>
                                     
                                </div>  
                                  
                            </ItemTemplate>
                        </asp:Repeater>
                                    
                                    </td>
                                <td  width="33%">

                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div style="height:374px;" >

                                 <asp:Panel ID="Panel1" runat="server" Width="220px"  Style="border:solid 2px #82191D;border-radius:10px; margin-left: 0px;">
                                     <table width="100%" border="0" align="center">
                                         <tr style="height:15px;">
                                             <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                             <td style="background-color:#94083F;width:20%;"></td>
                                             <td style="background-color:#CB0033;width:20%;"></td>
                                             <td style="background-color:#FB562D;width:20%;"></td>
                                             <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                         </tr>
                                     </table>
                                     <table width="100%" border="0" align="center">
                                         
                                         <tr>
                                             <td  width="60px" >
                                                 <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="50px" Width="50px" style="margin-top:5px;margin-left:5px;" />
                                             </td>
                                             <td colspan="4" >
                                                 
                                                 <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #82191D"></asp:Label>
                                             </td>
                                         </tr>
                                     </table>
                                     <table align="center">
                                         <tr >
                                              <td  >
                                                 <asp:Image ID="imgStud" ImageUrl='<%#Eval("Stud")%>' runat="server" Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                             </td>
                                         </tr>
                                      </table>
                                     <table align="center" width="100%">
                                          <tr>
                                              <td  ></td>
                                         </tr>
                                         
                                         <tr align="center">
                                              <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#94083F" ></asp:Label></td>
                                         </tr>
                                         <tr align="center">
                                              <td  >
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Student Id : "></asp:Label>
                                                  <asp:Label ID="lblStudentId" Text='<%#Eval("StudentId")%>' runat="server" Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                         </tr>
                                      </table>

                                     <table  width="100%">
                                          <tr>
                                              <td  colspan="5"></td>
                                         </tr>
                                         <tr >
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                             <td style="width:3%;" ></td>
                                             <td style="width:23%;" ><asp:Label ID="Label15" runat="server" Text="D.O.B"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:3%;" ><asp:Label ID="Label20" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#FB562D;" ></td>
                                             <td ></td>
                                             <td ><asp:Label ID="Label21" runat="server" Text="Blood Grp"  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="Label22" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#FB562D;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#94083F;" ></td>
                                             <td  ></td>
                                             <td ><asp:Label ID="Label23" runat="server" Text="Class"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label24" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblStream" runat="server" Text='<%#Eval("Stream")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#94083F;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#541742;" ></td>
                                             <td style="width:8%;" ></td>
                                             <td style="width:25%;" ><asp:Label ID="Label25" runat="server" Text="Mobile"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:5%;" ><asp:Label ID="Label26" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblConctact" runat="server" Text='<%#Eval("Conctact")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#541742;" ></td>
                                         </tr>
                                         <tr >
                                             <td  ></td>
                                             <td ></td>
                                             <td  ><asp:Label ID="Label27" runat="server" Text="Aadhar"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label28" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblAdharCard" runat="server" Text='<%#Eval("AdharCard")%>'  Font-Size="10px"></asp:Label></td>
                                             <td ></td>
                                         </tr>

                                         
                                      </table>
                                     <div style="border-bottom:dashed 1px #82191D;"></div>

                                     
                                   <table width="100%">
                                         <tr>
                                             <td align="center" rowspan="2" >
                                                 <asp:Label ID="Label29" runat="server" Text="Address" Font-Bold="true" ForeColor="#94083F" Font-Size="10px"></asp:Label><br />
                                                 <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                             </td>

                                             <td  align="right" style="width:30%;" >
                                                 <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                                 <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                             </td>
                                         </tr>
                                       <tr>
                                           <td  align="right" >
                                                <asp:Label ID="Label11" runat="server" Text="Signature" ForeColor="#94083F" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                             </td>
                                       </tr>
                                     </table>
                                     <table style="width:100%">
                                          <tr style="color: #FFFFFF; background-color: #94083F">
                                             <td  align="center" style="color: #FFFFFF; background-color: #94083F;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                                 
                                                 <asp:Label ID="Label30" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
                                             </td>
                                         </tr>
                                     </table>

                                 </asp:Panel>
                                     
                                </div>  
                                  
                            </ItemTemplate>
                        </asp:Repeater>
                              </td>

                                 <td>

                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <div style="height:374px;" >

                                 <asp:Panel ID="Panel1" runat="server" Width="220px"  Style="border:solid 2px #82191D;border-radius:10px; margin-left: 0px;">
                                     <table width="100%" border="0" align="center">
                                         <tr style="height:15px;">
                                             <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                             <td style="background-color:#94083F;width:20%;"></td>
                                             <td style="background-color:#CB0033;width:20%;"></td>
                                             <td style="background-color:#FB562D;width:20%;"></td>
                                             <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                         </tr>
                                     </table>
                                     <table width="100%" border="0" align="center">
                                         
                                         <tr>
                                             <td  width="60px" >
                                                 <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="50px" Width="50px" style="margin-top:5px;margin-left:5px;" />
                                             </td>
                                             <td colspan="4" >
                                                 
                                                 <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #82191D"></asp:Label>
                                             </td>
                                         </tr>
                                     </table>
                                     <table align="center">
                                         <tr >
                                              <td  >
                                                 <asp:Image ID="imgStud" ImageUrl='<%#Eval("Stud")%>' runat="server" Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                             </td>
                                         </tr>
                                      </table>
                                     <table align="center" width="100%">
                                          <tr>
                                              <td  ></td>
                                         </tr>
                                         
                                         <tr align="center">
                                              <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#94083F" ></asp:Label></td>
                                         </tr>
                                         <tr align="center">
                                              <td  >
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Student Id : "></asp:Label>
                                                  <asp:Label ID="lblStudentId" Text='<%#Eval("StudentId")%>' runat="server" Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                         </tr>
                                      </table>

                                     <table  width="100%">
                                          <tr>
                                              <td  colspan="5"></td>
                                         </tr>
                                         <tr >
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                             <td style="width:3%;" ></td>
                                             <td style="width:23%;" ><asp:Label ID="Label15" runat="server" Text="D.O.B"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:3%;" ><asp:Label ID="Label20" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="width:10%;background-color:#FFC301;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#FB562D;" ></td>
                                             <td ></td>
                                             <td ><asp:Label ID="Label21" runat="server" Text="Blood Grp"  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="Label22" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#FB562D;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#94083F;" ></td>
                                             <td  ></td>
                                             <td ><asp:Label ID="Label23" runat="server" Text="Class"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label24" runat="server" Text=": " Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblStream" runat="server" Text='<%#Eval("Stream")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#94083F;" ></td>
                                         </tr>
                                         <tr >
                                             <td style="background-color:#541742;" ></td>
                                             <td style="width:8%;" ></td>
                                             <td style="width:25%;" ><asp:Label ID="Label25" runat="server" Text="Mobile"  Font-Size="10px"></asp:Label></td>
                                             <td style="width:5%;" ><asp:Label ID="Label26" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblConctact" runat="server" Text='<%#Eval("Conctact")%>' Font-Size="10px"></asp:Label></td>
                                             <td style="background-color:#541742;" ></td>
                                         </tr>
                                         <tr >
                                             <td  ></td>
                                             <td ></td>
                                             <td  ><asp:Label ID="Label27" runat="server" Text="Aadhar"  Font-Size="10px"></asp:Label></td>
                                             <td ><asp:Label ID="Label28" runat="server" Text=": "  Font-Size="10px"></asp:Label></td>
                                             <td  ><asp:Label ID="lblAdharCard" runat="server" Text='<%#Eval("AdharCard")%>'  Font-Size="10px"></asp:Label></td>
                                             <td ></td>
                                         </tr>

                                         
                                      </table>
                                     <div style="border-bottom:dashed 1px #82191D;"></div>

                                     
                                   <table width="100%">
                                         <tr>
                                             <td align="center" rowspan="2" >
                                                 <asp:Label ID="Label29" runat="server" Text="Address" Font-Bold="true" ForeColor="#94083F" Font-Size="10px"></asp:Label><br />
                                                 <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                             </td>

                                             <td  align="right" style="width:30%;" >
                                                 <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                                 <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                             </td>
                                         </tr>
                                       <tr>
                                           <td  align="right" >
                                                <asp:Label ID="Label11" runat="server" Text="Signature" ForeColor="#94083F" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                             </td>
                                       </tr>
                                     </table>
                                     <table style="width:100%">
                                          <tr style="color: #FFFFFF; background-color: #94083F">
                                             <td  align="center" style="color: #FFFFFF; background-color: #94083F;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                                 
                                                 <asp:Label ID="Label30" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
                                             </td>
                                         </tr>
                                     </table>

                                 </asp:Panel>
                                     
                                </div>  
                                  
                            </ItemTemplate>
                        </asp:Repeater>
                              </td>
                            </tr>

                        </table>
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
    </div></ContentTemplate>
        </asp:UpdatePanel>
   
    
    
   
</asp:Content>   
