<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="UploadStudentList.aspx.cs" Inherits="CMS.Forms.SuperAdmin.UploadStudentList" %>
<%@ Register Src="~/UserControls/MessageBox.ascx" TagName="MsgBox" TagPrefix="ucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../js/bootstrap.js" type="text/javascript"></script>
    <script src="../../js/bootstrap.min.js" type="text/javascript"></script>   
    <script type="text/javascript">  
        $(document).ready(function () {  
            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();  
        });  
</script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
<%--<div style="margin-top:-445px;margin-left:50px">--%>
   <div style="width: 900px; height: 900px;">
       <asp:Panel ID="Panel_SendMessage" runat="server" Visible="true" Style="height:900px;
            width: 100%; border: medium double#0C7BFA;">
       <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <th colspan="4" style="background-color: #0C7BFA; color: White">
                        <ul class="nav nav-list">
                            <li><i class="icon-book"></i>Upload student excel file in database</li>
                        </ul>
                    </th>
                </tr>
            </table>
           
       <center>   
             <div style="width: 100%; height: 300px; margin-left: auto; margin-right: auto;">
<div class=" bg-primary text-uppercase text-white" style="font-weight:bold;">  
                    <h5>Import Excel File</h5>  
                </div>  
                <table style="border: 3px solid #0099FF;" width="600px">
                                    
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td>
                                            &nbsp;</td>
                                       
                                        <td>
                                            &nbsp;</td>
                                       
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="Label9" runat="server" CssClass="formlable" Text="Select School " Font-Bold="True"></asp:Label>
                                            </td>
                                        <td colspan="5">
                                            <asp:DropDownList ID="DDL_SelectCollege" runat="server" Width="180px" class="form" OnSelectedIndexChanged="DDL_SelectCollege_SelectedIndexChanged"
                                        placeholder="Select College" AutoPostBack="True">
                                       
                                    </asp:DropDownList>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">
                                            <asp:Label ID="Label7" runat="server" CssClass="formlable" Text="Select Course: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName1" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="100px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Enter Cours Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" CssClass="formlable" Text="Select Branch: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName4" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" Height="29px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="100px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Please Enter Branch Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="formlable" Text="Select Class: " Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblMiddleName2" runat="server" CssClass="formlable" Font-Bold="True" ForeColor="#FF3300" Text="*"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="false" Height="29px" Width="100px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlClass" ErrorMessage="Please Enter Class Name !!!" ForeColor="red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style14">
                                            &nbsp;</td>
                                        <td class="auto-style15">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>

                                    </table>
                <br />
                <div >   <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input" runat="server" />  
                                                                          <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-outline-primary" Text="Upload" OnClick="btnUpload_Click" />  

                        
                    

                    <div class="modal fade" id="myModal">  
                        <div class="modal-dialog">  
                            <div class="modal-content">  
                                <div class="modal-header">  
                                    <h4 class="modal-title">Import Excel File</h4>  
                                      
                                </div>  
                                <div class="modal-body">  
                                    <div class="row">  
                                        <div class="col-md-12">  
                                            <div class="form-group">  
                                                <label>Choose excel file</label>  
                                                <div class="input-group">  
                                                      
                                                    <label id="filename"></label>  
                                                    <div class="input-group-append">  
                                                    </div>  
                                                </div>  
                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>  
                                            </div>  
                                        </div>  
                                    </div>  
                                </div>  
                                
                            </div>  
                        </div>  
                    </div>  <br /> <br />
                    <div style="overflow: scroll; height:600px;" >
                    <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-primary text-white" ShowHeaderWhenEmpty="true" runat="server"  CssClass="table table-bordered``" Width="800px">  
                       
                    </asp:GridView>  </div>
                </div>  
            </div>  
 </center>
       
        <%--</div>--%>

       </asp:Panel> </div>  
    <ucMsgBox:MsgBox ID="msgBox" runat="server" />
</asp:Content>
