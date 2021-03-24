<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="id.aspx.cs" Inherits="CMS.Forms.Admin.id" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script language="">
        google.load("elements", "1", { packages: "transliteration" });

        function onLoad() {
            var options = {
                //Source for  Language
                sourceLanguage: google.elements.transliteration.LanguageCode.ENGLISH,
                // Destination language to Transliterate
                destinationLanguage: [google.elements.transliteration.LanguageCode.KANNADA],
                shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            var control = new google.elements.transliteration.TransliterationControl(options);
            //control.makeTransliteratable(['abc']); // for .aspx page
            control.makeTransliteratable(['<%=txtmarathi.ClientID%>']); //for Master page use

        }
        google.setOnLoadCallback(onLoad);
</script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial"  >
    <Columns>
        <asp:BoundField DataField = "ApplicationId" ItemStyle-Height = "150" HeaderText = "ID" />
        <asp:BoundField DataField = "FirstName" ItemStyle-Height = "150" HeaderText = "Image Name" />
        <asp:TemplateField ItemStyle-Height = "150" ItemStyle-Width = "170" HeaderText = "Image Preview">
            <ItemTemplate>
                <asp:Image ID="Image1" Height="100px" Width="150px"  runat="server" ImageUrl = '<%# Eval("ApplicationId", GetUrl("ImageCSharp.aspx?ImageID={0}"))%>' />
            </ItemTemplate> 
        </asp:TemplateField> 
    </Columns> 
 </asp:GridView>





        <asp:TextBox ID="txtmarathi" runat="server"  >

        </asp:TextBox>

        </div>
        <br />
        <asp:Button ID="btnExportWord" CommandArgument = "Word" runat="server" Text="Export-Word" OnClick = "Export_Grid" />
        <asp:Button ID="btnExportExcel" CommandArgument = "Excel" runat="server" Text="Export-Excel" OnClick = "Export_Grid" />
        <asp:Button ID="btnExportPDF" CommandArgument = "PDF" runat="server" Text="Export-PDF" OnClick = "Export_Grid" />
    
    </div>
    </form>
</body>
</html>
