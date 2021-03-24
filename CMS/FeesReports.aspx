<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeesReports.aspx.cs" Inherits="CMS.FeesReports" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div>
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            
                <h2>Student Fees Report</h2>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TransDate" HeaderText="Date" />
                        <asp:BoundField DataField="ReceiptNo" HeaderText="Rec.No." />
                        <%--<asp:BoundField DataField="StudentCode" HeaderText="UserCode" />--%>
                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" />
                        <asp:BoundField DataField="PaidAmount" HeaderText="Paid" />
                        <asp:BoundField DataField="PendingAmount" HeaderText="Pending" />
                        <asp:BoundField DataField="Class" HeaderText="Class" />
                    </Columns>
                </asp:GridView>
            
        </asp:Panel>
    </div>
</body>
</html>
