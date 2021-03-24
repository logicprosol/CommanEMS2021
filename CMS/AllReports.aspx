<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllReports.aspx.cs" Inherits="CMS.ResultFormat" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">


a:link, a:visited
{
    color: #034af3;
}

a{color:#08c;text-decoration:none}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            
                <h2>Student Admission Report</h2>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
        </asp:Panel>
    </div>
    </form>
</body>
</html>