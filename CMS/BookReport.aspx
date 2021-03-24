<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookReport.aspx.cs" Inherits="CMS.BookReport"  EnableEventValidation="false"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            
                <h2>Book Report</h2>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                     <Columns>
                                                    
                         <asp:BoundField DataField="BookCode" HeaderText="Book Code" />
                         <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                         <asp:BoundField DataField="GroupName" HeaderText="Group Name" />
                         <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                         <asp:BoundField DataField="Author" HeaderText="Author" />
                         <asp:BoundField DataField="PublishingYear" HeaderText="Publish Year" />
                         <asp:BoundField DataField="Edition" HeaderText="Edition" />
                         <asp:BoundField DataField="barcode" HeaderText="Barcode" />
                         <asp:BoundField DataField="Price" HeaderText="Price" />
                         <asp:BoundField DataField="qty" HeaderText="Quantity" />
                     

                     </Columns>

                </asp:GridView>
            
        </asp:Panel>
    </div>
    </form>
</body>
</html>
