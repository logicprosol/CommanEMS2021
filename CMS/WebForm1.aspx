<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CMS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>fnfgnf</title>

    <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=pnlContents1.ClientID %>");
             var printWindow = window.open('', '', '');
             printWindow.document.write('<html><head><title>Student Receipt</title>');
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
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 19px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Panel ID="pnlContents1" runat="server" Width="100%" Style="border:solid 2px black;">
            <div style="width:100%;height:100%;">
                <table style="width:100%;height:100%;" border="1" >
                    <tr >
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label1" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label12" runat="server"  Text="(For the Bank)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label2" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label5" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label6" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label7" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label9" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Label101" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label10" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="Label100" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. DevelopmentFee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label13" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label102" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label15" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label98" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label16" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label99" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label18" runat="server" Text="during the Year 20  -20 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="Label97" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label21" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label22" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label23" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label24" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label25" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label26" runat="server"  Text="(For the Student)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label27" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label28" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label29" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label30" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label31" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label32" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label34" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Label35" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label36" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="Label37" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. DevelopmentFee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label39" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label40" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label41" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label42" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label43" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label44" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label45" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label47" runat="server" Text="during the Year 20  -20 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="Label115" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label116" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label117" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label118" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label119" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label120" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr >
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label49" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label50" runat="server"  Text="(For the Office)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label51" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label52" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label53" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label54" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label55" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label56" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label57" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label58" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Label59" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label60" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="Label61" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label62" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. DevelopmentFee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label63" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label64" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label65" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label66" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label67" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label68" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label69" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label70" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label71" runat="server" Text="during the Year 20  -20 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label72" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="Label109" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label110" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label111" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label112" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label113" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label114" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width:50%;">
                            <div style="margin:0px;margin-left:5px;margin-right:5px;">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="Right" style="width:64%;">
                                            <asp:Label ID="Label73" runat="server" Text="Account Section" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="Label74" runat="server"  Text="(For the Office)" Font-Bold="True" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div align="Center">
                                    <asp:Label ID="Label75" runat="server" Text="Punjab National Bank, Dhule" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label76" runat="server" Text="S. S. V. P. Sanstha's Bapusaheb Shivajirao Deore" Font-Bold="True" Font-Size="12px"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label77" runat="server" Text="College of Engineering, Dhule {M. S.]" Font-Bold="True" Font-Size="12px"></asp:Label>
                                </div>

                                <table style="width:100%;height:100%;" >
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label78" runat="server" Text="Paid in to the Credit of" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label79" runat="server" Text="Principal," Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:50%;" align="Right">
                                            <asp:Label ID="Label80" runat="server" Text="A/c.No.0139000109181098" Font-Size="12px"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label81" runat="server" Text="S.S.V.P.S's Bapusaheb Shivajirao Deore College of Engineering Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td style="width:22%;">
                                            <asp:Label ID="Label82" runat="server" Text="the sum of Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:25%;">
                                            <asp:Label ID="Label83" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td style="width:20%;">
                                            <asp:Label ID="Label84" runat="server" Text="(In Words Rs. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:33%;">
                                            <asp:Label ID="Label85" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                                <table style="width:100%;height:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label86" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <table style="width:100%;height:100%;font-size:12px;" border="1">
                                        <tr>
                                            <th  style="width:70%;">Particulars</th>
                                            <th>Rs.</th>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">1. Tuition Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">2. Interium Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">3. DevelopmentFee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">4. University fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">5. Miscellneous Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">6. Deposit</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td  style="width:70%;">7. Other Fee</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th  style="width:70%;" align="Right">Grand Total - </th>
                                            <th></th>
                                        </tr>
                                    </table>
                                </div>

                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:72%;">
                                            <asp:Label ID="Label87" runat="server" Text="Name of the Student (In full Block letters) Mr./Miss " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label88" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label89" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:10%;">
                                            <asp:Label ID="Label90" runat="server" Text="Class " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label91" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td  style="width:15%;">
                                            <asp:Label ID="Label92" runat="server" Text="Roll No. " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td style="width:27%;">
                                            <asp:Label ID="Label93" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="95%"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label94" runat="server" Text="I<sup>st</sup>/II<sup>nd</sup> term" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:50%;">
                                            <asp:Label ID="Label95" runat="server" Text="during the Year 20  -20 " Font-Size="12px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label96" runat="server" Text="I Card No. " Font-Size="12px"></asp:Label>
                                            <asp:Label ID="Label103" runat="server" Text="-" Font-Size="12px" style="border-bottom:dotted 1px black;" Width="30%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label104" runat="server" Text="Sign & Designation of varifying office of the College/Hostel/deptt." Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="width:55%;"></td>
                                        <td >
                                            <asp:Label ID="Label105" runat="server" Text="Received Cashier" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table  style="width:100%;">
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label106" runat="server" Text="Date : " Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:55%;">
                                            <asp:Label ID="Label107" runat="server" Text="Place : Dhule" Font-Size="12px"></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label108" runat="server" Text="Seal of Bank" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>

        <br />
        <br />
        <center>
            <asp:Button ID="Button1" runat="server" Text="Print"  class=" btn btn-info" OnClientClick="return PrintPanel();"></asp:Button>
        </center>
    
    </div>
    </form>
</body>
</html>
