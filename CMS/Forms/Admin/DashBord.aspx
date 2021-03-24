<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="DashBord.aspx.cs" Inherits="CMS.Forms.Admin.DashBord" %>

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
            0% {
                background-position: 0 0;
            }

            0% {
                background-position: 100% -100%;
            }
        }

        #ranjit {
            width: 100px;
            height: 100px;
            background: red;
            float: left;
            margin: 5px;
        }

        .count {
            line-height: 100px;
            color: #0e105a;
            margin-left: 30%;
            font-size: 40px;
        }

        #talkbubble {
            width: 120px;
            height: 80px;
            background: red;
            position: relative;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            float: left;
            margin: 20px;
        }

            #talkbubble:before {
                content: "";
                position: absolute;
                right: 100%;
                top: 26px;
                width: 0;
                height: 0;
                border-top: 13px solid transparent;
                border-right: 26px solid red;
                border-bottom: 13px solid transparent;
            }

        .linker {
            font-size: 20px;
            font-color: black;
        }

        .page {
            background: #fff;
            width: 250px;
            height: 330px;
            margin: 50px;
            /* Optional Gradient */
            background: -moz-linear-gradient(top, #ffffff 0%, #e5e5e5 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ffffff), color-stop(100%,#e5e5e5)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #ffffff 0%,#e5e5e5 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #ffffff 0%,#e5e5e5 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #ffffff 0%,#e5e5e5 100%); /* IE10+ */
            background: linear-gradient(top, #ffffff 0%,#e5e5e5 100%); /* W3C */
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
                background: rgba(79, 82, 186, 0.39);
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
                height: 30px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin-top: 0px; border: medium double#0C7BFA; background-image: url(../../images/back_img.png); background-repeat: no-repeat; height: 1050px; width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel_Document" runat="server" align="center" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" width="100%" cellspacing="2px">
                    <tr>
                        <th style="background-color: #0C7BFA; color: White">
                            <ul class="nav nav-list">
                                <li><i class="icon-book"></i>welcome To Education Management Systems </li>
                            </ul>
                        </th>
                    </tr>
                </table>
                <%--<asp:Panel ID="Panel1" runat="server" Width="800px" Height="860px">
            <table border="0" width="100%" align="center" cellspacing="2px">
                <tr>
                    <td>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text="Student Admission Report Bar Chart"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server" Text="Course Wise Student Report Chart"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="Panel2" runat="server" Width="400px" Height="300px" class="well well large"
                            BackColor="CadetBlue">
                            <div>
                                <asp:Literal ID="lt" runat="server">
                                </asp:Literal>
                            </div>
                            <div id="chart_div">
                            </div>
                        </asp:Panel>
                    </td>
                    <td align="center">
                        <asp:Panel ID="Panel3" runat="server" Width="400px" Height="300px" class="well well large"  BackColor="CadetBlue">
                            <asp:PieChart ID="PieChart1" runat="server" ChartHeight="300" ChartWidth="400" ChartTitleColor="#0E426C">
                            </asp:PieChart>

                        </asp:Panel>
                    </td>
                 
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
            </table>--%>

                <div class="col-sm-12" style="margin-left: 50px; width: 300px; margin-top: 50px">
                    <asp:Label ID="lbltype" runat="server" Text="Type : " Font-Bold="true"></asp:Label>
                    <asp:DropDownList ID="ddlType" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">

                        <asp:ListItem Text="---Select---" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                        <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="TeacherDiv" visible="false" runat="server" class="col-md-12" style="margin-left: 50px; width: 800px; margin-top: 10px">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDepartment" runat="server" Text="Department : " Font-Bold="True"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblFacultyType" runat="server" Style="margin-left: 20px;" Text="Faculty Type : " Font-Bold="True"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDesignation" runat="server" Text="Designation : " Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" Width="180px" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtnFacultyType" runat="server" RepeatDirection="Horizontal"
                                    class="radio" Width="220px" AutoPostBack="true" Style="margin-left: 20px;" OnSelectedIndexChanged="rbtnFacultyType_SelectedIndexChanged">
                                    <asp:ListItem Text="Teaching" Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Text="NonTeaching" Value="2">Non Teaching</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                <asp:DropDownList ID="ddlDesignation" runat="server" Width="180px" AutoPostBack="true">
                                    <asp:ListItem Text="Select"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </div>
                <div id="StudentDiv" visible="false" runat="server" class="col-md-12" style="margin-left: 50px; width: 800px; margin-top: 10px">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Course : " Font-Bold="True"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Branch : " Font-Bold="True"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Class : " Font-Bold="True"></asp:Label></td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Academic Year : " Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlClass" runat="server" Width="180px" AutoPostBack="true">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="DDLAcademicYear" runat="server" ValidationGroup="GeneralDetails"
                                    AutoPostBack="true"
                                    Width="180px">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </div>
                 <div class="col-sm-12" style="margin-left: 120px; width: 300px; margin-top:10px">
                     <asp:Button runat="server" ID="btnGo" Text="GO" Visible="false" CssClass="btn-success" Width="80px" style="border-radius:20px;" OnClick="btnGo_Click" />
                     </div>

                <div class="col-sm-12" style="margin-left: 120px; width: 300px; margin-top: 100px">

                    <div class="col-sm-4"></div>
                    <div class="col-md-4">
                        <div class="card">

                            <div class="card-content">
                                <span class="count" style="margin-left: 50px;">
                                    <asp:Label ID="lblCurrentOrder" runat="server" Text="0"></asp:Label></span>
                            </div>
                            <div class="card-action">

                                <span class="card-title" style="color: #111; margin-left: 70px;">Total Students</span>


                                <%--  <a href="#" target="new_blank">Link</a> <a href="#" target="new_blank">Link</a>
                                <a href="#" target="new_blank">Link</a> <a href="#" target="new_blank">Link</a>
                                <a href="#" target="new_blank">Link</a>
                                --%>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4"></div>
                </div>

                <div class="col-sm-12" style="margin-left:120px; width: 300px; margin-top: 100px">

                    <div class="col-sm-4"></div>
                    <div class="col-md-4">
                        <div class="card">

                            <div class="card-content">
                                <span class="count" style="margin-left: 50px;">
                                    <asp:Label ID="lblemplyee" runat="server" Text="0"></asp:Label></span>
                            </div>
                            <div class="card-action">

                                <span class="card-title" style="color: #111; margin-left: 70px;">Total Employee's</span>


                                <%--  <a href="#" target="new_blank">Link</a> <a href="#" target="new_blank">Link</a>
                                <a href="#" target="new_blank">Link</a> <a href="#" target="new_blank">Link</a>
                                <a href="#" target="new_blank">Link</a>
                                --%>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4"></div>
                </div>


                <%--</asp:Panel>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
