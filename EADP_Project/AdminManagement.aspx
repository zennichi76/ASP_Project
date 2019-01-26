<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AdminManagement.aspx.cs" Inherits="EADP_Project.AdminManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 405px;
        }
        .auto-style2 {
            width: 445px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card" style="margin-top:25px">
                        <div class="card-header">
                            <h4>Admin Management</h4>
                        </div>
                        <div class="card-body">
                            <div class="row" style="margin-top: 25px">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <div class="input-group mb-3">

                                        <asp:TextBox ID="tbSearch" placeholder="Users" CssClass="form-control" runat="server" Width="238px"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnSearch" CssClass="btn btn-outline-dark" runat="server" Text="Search Users" Onclick="btnSearch_Click" />
                                        </div>
                                    </div> 
                                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" 
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                                        OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" Width="100%"
                                        AllowPaging="true" OnPageIndexChanging="gvUsers_PageIndexChanging"> 
                                        <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="Role" HeaderText="Role" />
                                            </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <PagerSettings NextPageText="Next" PreviousPageText="Previous" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView>

                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Text="Intrusion Detection &amp; Logging"></asp:Label>
                                    <br />
                                    <br />
                                    <table class="w-100">
                                        <tr>
                                            <td>
                                               
                                                <asp:FileUpload ID="FileUpload_Log" runat="server" Width="495px" />
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btn_upload_file" runat="server" OnClick="btn_upload_file_Click" Text="Process Server Logging File" Width="492px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="tb_log_raw" runat="server" Height="476px" TextMode="MultiLine" Width="492px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto">

                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Possible Intruders Detected"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Trace User Traffic"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                &nbsp;</td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload_iptrace" runat="server" Width="250px" />
                                                <asp:TextBox ID="tb_ip_trace" runat="server" Width="180px"></asp:TextBox>
                                                <asp:Button ID="btn_begin_trace" runat="server" OnClick="btn_begin_trace_Click" Text="Begin Trace" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="tb_flag" runat="server" Height="280px" TextMode="MultiLine" Width="491px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tb_usertraffic" runat="server" Height="280px" ReadOnly="True" TextMode="MultiLine" Width="580px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="w-100">
                                        <tr>
                                            <td class="auto-style2">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Current Blacked Listed IPs (Add/Remove Accordingly)" Width="625px"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="tb_blacklist" runat="server" Height="300px" OnTextChanged="tb_blacklist_TextChanged" TextMode="MultiLine" Width="625px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        </table>
                                    <asp:TextBox ID="tb_crud" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_apply" runat="server" OnClick="btn_apply_Click" Text="Insert" />
                                    &nbsp;<asp:Button ID="btn_remove" runat="server" OnClick="btn_remove_Click" Text="Remove" />
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script src="https://code.highcharts.com/modules/export-data.js"></script>
<script>
    var ip1 = '<%=ip1%>';
    var ip2 = '<%=ip2%>';
    var ip3 = '<%=ip3%>';
    var ip4 = '<%=ip4%>';
    var ip5 = '<%=ip5%>';
    var count1 = parseFloat('<%=count1%>');
    var count2 = parseFloat('<%=count2%>');
    var count3 = parseFloat('<%=count3%>');
    var count4 = parseFloat('<%=count4%>');
    var count5 = parseFloat('<%=count5%>');
    Highcharts.chart('container', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Top 5 IPs Generating Traffic Today'
    },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                style: {
                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                }
            }
        }
    },
    series: [{
        name: 'Ip Address',
        colorByPoint: true,
        data: [{
            name: ip1,
            y: count1,
            sliced: true,
            selected: true
        }, {
            name: ip2,
            y: count2
        }, {
            name: ip3,
            y: count3
        }, {
            name: ip4,
            y: count4
        }, {
            name: ip5,
            y: count5
        }]
    }]
    });
</script>
</asp:Content>
