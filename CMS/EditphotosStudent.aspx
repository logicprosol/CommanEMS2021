<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditphotosStudent.aspx.cs" Inherits="CMS.EditphotosStudent" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

select {
  width: 220px;
  background-color: #ffffff;
  border: 1px solid #cccccc;
}

select,
input[type="file"] {
  height: 30px;
  /* In IE7, the height of the select element cannot be changed by height, only font-size */

  *margin-top: 4px;
  /* For IE7, add top margin to align select with labels */

  line-height: 30px;
}

select,
textarea,
input[type="text"],
input[type="password"],
input[type="datetime"],
input[type="datetime-local"],
input[type="date"],
input[type="month"],
input[type="time"],
input[type="week"],
input[type="number"],
input[type="email"],
input[type="url"],
input[type="search"],
input[type="tel"],
input[type="color"],
.uneditable-input {
  display: inline-block;
  height: 20px;
  padding: 4px 6px;
  margin-bottom: 9px;
  font-size: 14px;
  line-height: 20px;
  color: #555555;
  -webkit-border-radius: 3px;
     -moz-border-radius: 3px;
          border-radius: 3px;
}

input,
button,
select,
textarea {
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}

label,
input,
button,
select,
textarea {
  font-size: 14px;
  font-weight: normal;
  line-height: 20px;
}

button,
input,
select,
textarea {
  margin: 0;
  font-size: 100%;
  vertical-align: middle;
}

select{background-color:#fff;border:1px solid #ccc;
    }select,input[type="file"]{height:30px;*line-height:30px
}select,textarea,input[type="text"],input[type="password"],input[type="datetime"],input[type="datetime-local"],input[type="date"],input[type="month"],input[type="time"],input[type="week"],input[type="number"],input[type="email"],input[type="url"],input[type="search"],input[type="tel"],input[type="color"],.uneditable-input{display:inline-block;padding:4px 6px;margin-bottom:9px;line-height:20px;-webkit-border-radius:3px;-moz-border-radius:3px;border-radius:3px
}label,input,button,select,textarea{font-size:14px;line-height:20px
}button,input,select,textarea{font-size:100%;
    margin-left: 0;
    margin-right: 0;
    }select{background-color:#fff;border:1px solid #ccc;
    }select,input[type="file"]{height:30px;*line-height:30px
}select,textarea,input[type="text"],input[type="password"],input[type="datetime"],input[type="datetime-local"],input[type="date"],input[type="month"],input[type="time"],input[type="week"],input[type="number"],input[type="email"],input[type="url"],input[type="search"],input[type="tel"],input[type="color"],.uneditable-input{display:inline-block;padding:4px 6px;margin-bottom:9px;line-height:20px;-webkit-border-radius:3px;-moz-border-radius:3px;border-radius:3px
}label,input,button,select,textarea{font-size:14px;line-height:20px
}button,input,select,textarea{font-size:100%;
    margin-left: 0;
    margin-right: 0;
    }</style>
</head>
<body>
    <form id="form1" runat="server">
      
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                                                                            <asp:Label ID="lblGrNo2" runat="server" Font-Bold="True" ForeColor="#272727" Text="Organization"></asp:Label>
                                                                            </td>
                <td>
                                                                            <asp:DropDownList ID="DDL_SelectCollege" runat="server" AutoPostBack="True" class="form" placeholder="Select College" Width="300px" DataSourceID="SqlDataSource1" DataTextField="OrgName" DataValueField="OrganizationId">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
                                                                                SelectCommand="SELECT [OrganizationId], [OrgName] FROM [tblOrganization]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                                                                            <asp:Label ID="lblGrNo3" runat="server" Font-Bold="True" ForeColor="#272727" Text="Course" Visible="False"></asp:Label>
                                                                            </td>
                <td>
                                                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" class="form" placeholder="Select College" Width="300px" DataSourceID="SqlDataSource3" DataTextField="CourseName" DataValueField="CourseId" Visible="False">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [CourseId], [CourseName] FROM [tblCourse] WHERE ([OrgId] = @OrgId)">
                                                                                <SelectParameters>
                                                                                    <asp:ControlParameter ControlID="DDL_SelectCollege" DefaultValue="1" Name="OrgId" PropertyName="SelectedValue" Type="Decimal" />
                                                                                </SelectParameters>
                                                                            </asp:SqlDataSource>
                </td>
                <td>
                                                                            <asp:Label ID="lblGrNo4" runat="server" Font-Bold="True" ForeColor="#272727" Text="Branch" Visible="False"></asp:Label>
                                                                            </td>
                <td>
                                                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" class="form" placeholder="Select College" Width="300px" DataSourceID="SqlDataSource4" DataTextField="BranchName" DataValueField="BranchId" Visible="False">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [BranchId], [BranchName] FROM [tblBranch] WHERE ([CourseId] = @CourseId)">
                                                                                <SelectParameters>
                                                                                    <asp:ControlParameter ControlID="ddlCourse" DefaultValue="1" Name="CourseId" PropertyName="SelectedValue" Type="Decimal" />
                                                                                </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
       
        <div style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"
                        AutoGenerateColumns="False" DataKeyNames="ApplicationId" DataSourceID="SqlDataSource2" EmptyDataText="No record present" 
                        Width="70%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" >
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                           
                            <asp:TemplateField HeaderText="Photo">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" width="30px" Height="30px" runat="server" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="90px"/>
                                                        </EditItemTemplate>
                                                        
                                                    </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" HeaderText="Action" >
                            <ItemStyle Width="100px" />
                            </asp:CommandField>
<asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MiddleName" SortExpression="MiddleName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMiddleName" runat="server" Text='<%# Bind("MiddleName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("MiddleName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" InsertVisible="False" ReadOnly="True" SortExpression="ApplicationId" />
                            <asp:TemplateField HeaderText="AdmissionID" SortExpression="AdmissionID">
                              
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AdmissionID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="CourseName" SortExpression="CourseName">
                              
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BranchName" SortExpression="BranchName">
                              
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
        </div>

<%--AND (dbo.tblAdmissionDetails.CourseId = @CourseId) AND (dbo.tblAdmissionDetails.BranchId = @BranchId) --%>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>"
                        DeleteCommand="DELETE FROM [tblAdmissionDetails] WHERE [ApplicationId] = @ApplicationId" 
                        InsertCommand="INSERT INTO [tblAdmissionDetails] ([AdmissionID], [OrgID], [FirstName], [MiddleName], [LastName], [Photo], [Status]) VALUES (@AdmissionID, @OrgID, @FirstName, @MiddleName, @LastName, @Photo, @Status)" 
                        SelectCommand="SELECT dbo.tblAdmissionDetails.ApplicationId, dbo.tblAdmissionDetails.AdmissionID, dbo.tblAdmissionDetails.OrgID, dbo.tblAdmissionDetails.FirstName,
                        dbo.tblAdmissionDetails.MiddleName, dbo.tblAdmissionDetails.LastName, dbo.tblAdmissionDetails.Photo, dbo.tblAdmissionDetails.Status, dbo.tblCourse.CourseName,
                        dbo.tblBranch.BranchName 
                        FROM dbo.tblAdmissionDetails INNER JOIN dbo.tblBranch ON dbo.tblAdmissionDetails.BranchId = dbo.tblBranch.BranchId 
                        INNER JOIN dbo.tblCourse ON dbo.tblAdmissionDetails.CourseId = dbo.tblCourse.CourseId 
                        WHERE (dbo.tblAdmissionDetails.OrgID = @OrgID) 
                        
                        AND (dbo.tblAdmissionDetails.Photo IS NULL) 
                        ORDER BY dbo.tblAdmissionDetails.CourseId, 
                        dbo.tblAdmissionDetails.BranchId, dbo.tblAdmissionDetails.ClassId, dbo.tblAdmissionDetails.FirstName, dbo.tblAdmissionDetails.LastName" 
                        UpdateCommand="UPDATE [tblAdmissionDetails] SET [AdmissionID] = @AdmissionID, [OrgID] = @OrgID, 
                        [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, [Photo] = @Photo, [Status] = @Status WHERE [ApplicationId] = @ApplicationId">
                        <DeleteParameters>
                            <asp:Parameter Name="ApplicationId" Type="Decimal" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AdmissionID" Type="String" />
                            <asp:Parameter Name="OrgID" Type="Decimal" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="MiddleName" Type="String" />
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="Photo" Type="Object" />
                            <asp:Parameter Name="Status" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DDL_SelectCollege" DefaultValue="1" Name="OrgID" PropertyName="SelectedValue" Type="Decimal" />
                            
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AdmissionID" Type="String" />
                            <asp:Parameter Name="OrgID" Type="Decimal" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="MiddleName" Type="String" />
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="Photo" Type="Object" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="ApplicationId" Type="Decimal" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
       <%-- <asp:ControlParameter ControlID="ddlCourse" DefaultValue="1" Name="CourseId" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlBranch" DefaultValue="1" Name="BranchId" PropertyName="SelectedValue" />--%>
    </form>
</body>
</html>
