<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSalryReport.aspx.cs" Inherits="CMS.StaffSalryReport"  EnableEventValidation="false"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            
                <h2>Staff Salary Report</h2>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
        </asp:Panel>
    </div>
    </form>
</body>
</html>
