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
                                    <br />
                                    <br />
                                    <table class="w-100">
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:TextBox ID="TextBox1" runat="server" Height="476px" TextMode="MultiLine" Width="492px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto">

                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btn_python" runat="server" OnClick="btn_python_Click" Text="Run Python Script" />
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
    Highcharts.chart('container', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Hello Friend'
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
        name: 'Brands',
        colorByPoint: true,
        data: [{
            name: 'Chrome',
            y: 61.41,
            sliced: true,
            selected: true
        }, {
            name: 'Internet Explorer',
            y: 11.84
        }, {
            name: 'Firefox',
            y: 10.85
        }, {
            name: 'Edge',
            y: 4.67
        }, {
            name: 'Safari',
            y: 4.18
        }, {
            name: 'Sogou Explorer',
            y: 1.64
        }, {
            name: 'Opera',
            y: 1.6
        }, {
            name: 'QQ',
            y: 1.2
        }, {
            name: 'Other',
            y: 2.61
        }]
    }]
});
</script>
</asp:Content>
