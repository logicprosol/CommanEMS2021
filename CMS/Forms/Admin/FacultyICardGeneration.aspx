<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="FacultyICardGeneration.aspx.cs" Inherits="CMS.Forms.Admin.FacultyICardGeneration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Add CSS Here-->
 <link href="../../css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <!--End here-->
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', '');
            printWindow.document.write('<html><head><title>Faculty I Card</title>');
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
    <style type="text/css">
        .auto-style15 {
            width: 5px;
            height: 80%;
        }
        .auto-style16 {
            height: 41px;
        }
        .auto-style17 {
            width: 10%;
            height: 41px;
        }
        .auto-style18 {
            height: 23px;
        }
        .auto-style19 {
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
    <!--Add Design Page Code Here-->
    <div style="height: 940px; width: 920px; border: medium double#0C7BFA;">
        <table border="0" width="100%" align="center" cellspacing="2px">
            <tr>
                <th colspan="2" style="background-color: #0C7BFA; color: White">
                    <ul class="nav nav-list">
                        <li><i class="icon-book"></i>Generate Faculty I-Card</li>
                    </ul>
                </th>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel_FacultyICard" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" width="100%" align="center" cellspacing="2px">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Width="100%" align="Left">
                                <table border="0" width="80%" align="center">
                                    <tr>
                                        <%--<td style="height: 20px;">
                                </td>--%>
                                        <td colspan="5">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                                Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDesignation1" runat="server" Text="Designation:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnGo" runat="server" class="btn btn-primary" OnClick="btnGo_Click"
                                                Text="Go" ValidationGroup="FacultyInfo" />
                                        </td>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment"
                                                    ErrorMessage="Please Select Department !!!" ForeColor="red" ValidationGroup="FacultyInfo" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation"
                                                    ErrorMessage="Please Select Designation !!!" ForeColor="red" ValidationGroup="FacultyInfo" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Panel ID="Panel3" runat="server" Width="700px" Height="250px" Visible="false"
                                class="well well-large" HorizontalAlign="Center" ScrollBars="Auto">
                                <asp:GridView ID="grdIcard" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" DataKeyNames="UserCode,FullName" 
                                    PageSize="5" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="UserCode" HeaderText="Emp Code" />
                                        <asp:BoundField DataField="FullName" HeaderText="Emp Name" />
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
                                                <asp:Button ID="btnView" runat="server" class="btn btn-primary" OnClick="btnView_Click"
                                                    Text="Preview" />
                                            </ItemTemplate>
                                            <ItemStyle Width="200px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lblDesignation1" runat="server" Text="No record present" ForeColor="#FF3300"></asp:Label>
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

                              <br />
                                     <asp:Button ID="btnPrintLoad" runat="server" class="btn btn-primary" OnClick="btnPrintLoad_Click" Text="Next" Visible="false" />
                                     <br />
                        </td>
                    </tr>
                   <table border="0" width="80%" align="center" cellspacing="2px" class="auto-style19">
                    
                       <tr>
                <td>
                    <asp:Panel ID="pnlContents" runat="server" ScrollBars="Auto" Height="450px" Visible="false">
                       
                        <table width="100%">
                            <tr>
                                <td width="33%">
 
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div style="height:374px;" >

                                 <asp:Panel ID="Panel2" runat="server" Width="220px"   Style="border:solid 2px #FB562D;border-radius:10px; margin-left: 0px;">
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
                                <%--<tr style="height:15px;">
                                    <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                    <td style="background-color:#94083F;width:20%;"></td>
                                    <td style="background-color:#CB0033;width:20%;"></td>
                                    <td style="background-color:#FB562D;width:20%;"></td>
                                    <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                </tr>--%>
                                <tr>
                                    <td  width="40px" >
                                        <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="30px" Width="30px" style="margin-top:5px;margin-left:5px;" />
                                    </td>
                                    <td colspan="4" >
                                        <%--<asp:Label ID="lblTrustName" runat="server" Style="font-size: 10px;margin-left:3px;" ></asp:Label><br />--%>
                                        <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #FB562D"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="5">
                                        <asp:Label ID="lbldate" runat="server" Text="lbldate" style="margin-left:5px;"></asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                            <table align="center">
                                <tr >
                                     <td  >
                                        <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%#Eval("Faculty")%>' Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                    </td>
                                </tr>
                             </table>
                            <table align="center" width="100%">
                                 <tr>
                                     <td  ></td>
                                </tr>
                                
                                <tr align="center">
                                     <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#FB562D" ></asp:Label></td>
                                </tr>
                                <tr align="center">
                                     <td  >
                                         <%--<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Faculty Id : "></asp:Label>--%>
                                         <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>' Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                </tr>
                             </table>

                            <table width="100%">
                                <tr>
                                    <td align="center"><div style="border-bottom:dotted 3px #82191D;width:50%;" ></div></td>
                                </tr>
                            </table>

                            <table  width="100%" style="margin-top:4px;margin-bottom:3px;" >
                                 <tr>
                                     <td  colspan="2"  ></td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <asp:Label ID="Label1" runat="server" Text="Emp ID" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblFacultyId" runat="server" Text='<%#Eval("FacultyId")%>' Font-Size="10px"></asp:Label>
                                    </td >
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td style="width:40%;" align="center" >
                                        <asp:Label ID="Label3" runat="server" Text="Date Of Birth" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td >
                                    <td style="width:10%;"></td>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label9" runat="server" Font-Size="10px" ForeColor="#FB562D" Text="Blood Grp"></asp:Label><br />
                                        <asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label16" runat="server" Text="Contact" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                
                             </table>
                            <div style="border-bottom:dashed 1px #FB562D;"></div>

                            
                          <table width="100%">
                                
                              <tr>
                                  <td rowspan="2" align="center">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'  ForeColor="#FB562D" Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td  align="right" style="Width:30%;">
                                        <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                        <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                    </td>
                              </tr>
                              <tr>
                                  <td  align="right" >
                                       <asp:Label ID="Label15" runat="server" Text="Signature" ForeColor="#FB562D" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                    </td>
                              </tr>
                            </table>
                            <table style="width:100%">
                                 <tr style="color: #FFFFFF; background-color: #FB562D;">
                                    <td  align="center" style="color: #FFFFFF; background-color: #FB562D;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                        
                                        <asp:Label ID="Label19" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
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

                                 <asp:Panel ID="Panel2" runat="server" Width="220px"   Style="border:solid 2px #FB562D;border-radius:10px; margin-left: 0px;">
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
                                <%--<tr style="height:15px;">
                                    <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                    <td style="background-color:#94083F;width:20%;"></td>
                                    <td style="background-color:#CB0033;width:20%;"></td>
                                    <td style="background-color:#FB562D;width:20%;"></td>
                                    <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                </tr>--%>
                                <tr>
                                    <td  width="40px" >
                                        <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="30px" Width="30px" style="margin-top:5px;margin-left:5px;" />
                                    </td>
                                    <td colspan="4" >
                                        <%--<asp:Label ID="lblTrustName" runat="server" Style="font-size: 10px;margin-left:3px;" ></asp:Label><br />--%>
                                        <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #FB562D"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="5">
                                        <asp:Label ID="lbldate" runat="server" Text="lbldate" style="margin-left:5px;"></asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                            <table align="center">
                                <tr >
                                     <td  >
                                        <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%#Eval("Faculty")%>' Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                    </td>
                                </tr>
                             </table>
                            <table align="center" width="100%">
                                 <tr>
                                     <td  ></td>
                                </tr>
                                
                                <tr align="center">
                                     <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#FB562D" ></asp:Label></td>
                                </tr>
                                <tr align="center">
                                     <td  >
                                         <%--<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Faculty Id : "></asp:Label>--%>
                                         <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>' Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                </tr>
                             </table>

                            <table width="100%">
                                <tr>
                                    <td align="center"><div style="border-bottom:dotted 3px #82191D;width:50%;" ></div></td>
                                </tr>
                            </table>

                            <table  width="100%" style="margin-top:4px;margin-bottom:3px;" >
                                 <tr>
                                     <td  colspan="2"  ></td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <asp:Label ID="Label1" runat="server" Text="Emp ID" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblFacultyId" runat="server" Text='<%#Eval("FacultyId")%>' Font-Size="10px"></asp:Label>
                                    </td >
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td style="width:40%;" align="center" >
                                        <asp:Label ID="Label3" runat="server" Text="Date Of Birth" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td >
                                    <td style="width:10%;"></td>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label9" runat="server" Font-Size="10px" ForeColor="#FB562D" Text="Blood Grp"></asp:Label><br />
                                        <asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label16" runat="server" Text="Contact" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                
                             </table>
                            <div style="border-bottom:dashed 1px #FB562D;"></div>

                            
                          <table width="100%">
                                
                              <tr>
                                  <td rowspan="2" align="center">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'  ForeColor="#FB562D" Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td  align="right" style="Width:30%;">
                                        <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                        <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                    </td>
                              </tr>
                              <tr>
                                  <td  align="right" >
                                       <asp:Label ID="Label15" runat="server" Text="Signature" ForeColor="#FB562D" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                    </td>
                              </tr>
                            </table>
                            <table style="width:100%">
                                 <tr style="color: #FFFFFF; background-color: #FB562D;">
                                    <td  align="center" style="color: #FFFFFF; background-color: #FB562D;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                        
                                        <asp:Label ID="Label19" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
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

                                 <asp:Panel ID="Panel2" runat="server" Width="220px"   Style="border:solid 2px #FB562D;border-radius:10px; margin-left: 0px;">
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
                                <%--<tr style="height:15px;">
                                    <td style="background-color:#541742;width:20%;border-top-left-radius:7px;"></td>
                                    <td style="background-color:#94083F;width:20%;"></td>
                                    <td style="background-color:#CB0033;width:20%;"></td>
                                    <td style="background-color:#FB562D;width:20%;"></td>
                                    <td style="background-color:#FFC301;width:20%;border-top-right-radius:7px;"></td>
                                </tr>--%>
                                <tr>
                                    <td  width="40px" >
                                        <asp:Image ID="imgClgLogo" runat="server" ImageUrl='<%#Eval("imgClgLogo")%>' Height="30px" Width="30px" style="margin-top:5px;margin-left:5px;" />
                                    </td>
                                    <td colspan="4" >
                                        <%--<asp:Label ID="lblTrustName" runat="server" Style="font-size: 10px;margin-left:3px;" ></asp:Label><br />--%>
                                        <asp:Label ID="lblCollageFullName" runat="server" Text='<%#Eval("CollageFullName")%>' Font-Bold="true" Style="font-size: 11px;margin-left:3px; color: #FB562D"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="5">
                                        <asp:Label ID="lbldate" runat="server" Text="lbldate" style="margin-left:5px;"></asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                            <table align="center">
                                <tr >
                                     <td  >
                                        <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%#Eval("Faculty")%>' Width="75px" Height="70px" Style="margin-top: 0px;border-radius:60px"   />
                                    </td>
                                </tr>
                             </table>
                            <table align="center" width="100%">
                                 <tr>
                                     <td  ></td>
                                </tr>
                                
                                <tr align="center">
                                     <td  ><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>' Font-Bold="True" Font-Size="11px" ForeColor="#FB562D" ></asp:Label></td>
                                </tr>
                                <tr align="center">
                                     <td  >
                                         <%--<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="10px"  Text="Faculty Id : "></asp:Label>--%>
                                         <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>' Font-Bold="True" Font-Size="10px" ></asp:Label></td>
                                </tr>
                             </table>

                            <table width="100%">
                                <tr>
                                    <td align="center"><div style="border-bottom:dotted 3px #82191D;width:50%;" ></div></td>
                                </tr>
                            </table>

                            <table  width="100%" style="margin-top:4px;margin-bottom:3px;" >
                                 <tr>
                                     <td  colspan="2"  ></td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <asp:Label ID="Label1" runat="server" Text="Emp ID" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblFacultyId" runat="server" Text='<%#Eval("FacultyId")%>' Font-Size="10px"></asp:Label>
                                    </td >
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td style="width:40%;" align="center" >
                                        <asp:Label ID="Label3" runat="server" Text="Date Of Birth" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td >
                                    <td style="width:10%;"></td>
                                    <td style="width:40%;" align="center">
                                        <div style="width:80%;border-bottom:dotted 1px #666666;"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label9" runat="server" Font-Size="10px" ForeColor="#FB562D" Text="Blood Grp"></asp:Label><br />
                                        <asp:Label ID="lblbloodGroup" runat="server" Text='<%#Eval("bloodGroup")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td style="width:10%;" align="center"><div style="width:5px;height:80%;border-right:dotted 1px #666666;"><br /></div></td>
                                    <td align="center" class="auto-style16">
                                        <asp:Label ID="Label16" runat="server" Text="Contact" ForeColor="#FB562D"  Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                </tr>
                                
                             </table>
                            <div style="border-bottom:dashed 1px #FB562D;"></div>

                            
                          <table width="100%">
                                
                              <tr>
                                  <td rowspan="2" align="center">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'  ForeColor="#FB562D" Font-Size="10px"></asp:Label><br />
                                        <asp:Label ID="lblCurrentAddress" runat="server" Text='<%#Eval("CurrentAddress")%>' Font-Size="10px"></asp:Label>
                                    </td>
                                    <td  align="right" style="Width:30%;">
                                        <asp:Image ID="Sign" runat="server" ImageUrl='<%#Eval("Sign")%>' AlternateText="" Width="40px" Height="30px" style="margin-right:5px;"  />
                                        <%--<img src="../../Sign/principal_Sign.png" style="margin-right:28px;" width="40px" height="30px" />--%>
                                    </td>
                              </tr>
                              <tr>
                                  <td  align="right" >
                                       <asp:Label ID="Label15" runat="server" Text="Signature" ForeColor="#FB562D" Font-Size="10px" Font-Bold="true" Style="margin-right:20px;"></asp:Label>
                                    </td>
                              </tr>
                            </table>
                            <table style="width:100%">
                                 <tr style="color: #FFFFFF; background-color: #FB562D;">
                                    <td  align="center" style="color: #FFFFFF; background-color: #FB562D;border-bottom-left-radius:7px;border-bottom-right-radius:7px;"   >
                                        
                                        <asp:Label ID="Label19" runat="server" Font-Size="8px" Text="copyright ©2016 by LOGICPRO SOLUTIONS."></asp:Label>
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
                            <asp:Button ID="btnPrint" runat="server" Visible="false" Text="Print" class=" btn btn-info" OnClientClick="return PrintPanel();"  />
                        </td>
                    </tr>
                </table>
                <ucMsgBox:MsgBox ID="msgBox" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--</asp:Panel>--%>
    </div>
    <!--End Design Page Code Here-->
   
</asp:Content>
