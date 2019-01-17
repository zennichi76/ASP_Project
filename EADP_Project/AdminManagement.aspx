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
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</asp:Content>
