<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentFeesReport.aspx.cs" Inherits="CMS.StudentFeesReport" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
   
    <div>
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            
                <%--<h2>Student Fees Status</h2>--%>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
        
            <asp:Label ID="lblStatus" runat="server" Text="Label" Font-Size="16px" Font-Bold="true" ForeColor="Blue"></asp:Label>
                <br />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
        </asp:Panel>
    </div>
  
</body>
</html>
