<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AdminManagement.aspx.cs" Inherits="EADP_Project.AdminManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 405px;
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
                                    <table class="table table-bordered table-light">
                                        <tr>
                                            <th>NRIC</th>
                                            <th>Role</th>
                                        </tr>
                                        <tr>
                                            <td>Sample Data</td>
                                            <td>Sample Data</td>
                                        </tr>
                                        <tr>
                                            <td>Sample Data</td>
                                            <td>Sample Data</td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="StudentTables" CssClass="table table-bordered table-light" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30%" HeaderText="Student's NRIC ">
                                            </asp:BoundField>
                                        </Columns>
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
                                                <asp:TextBox ID="tb_log_raw" runat="server" Height="476px" TextMode="MultiLine" Width="492px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto">

                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="w-100">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Possible Intruders Detected"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TextBox1" runat="server" Height="281px" TextMode="MultiLine" Width="722px"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
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
        text: 'Highest Percentage of traffic by users'
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
