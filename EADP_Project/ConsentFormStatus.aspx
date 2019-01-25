<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConsentFormStatus.aspx.cs" Inherits="EADP_Project.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card" style="margin-top:25px">
                        <div class="card-header">
                            <h4>Manage Consent Forms</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <a href="ManageConsentFormsPage.aspx">Return to Managing Consent Forms</a>
                                    <div style="margin-top:25px">
                                    <h5>Select a class to view</h5>
                                        </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:DropDownList ID="ClassesDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClassesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 25px">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:GridView ID="StudentTables" CssClass="table table-bordered table-light" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="UserID" HeaderText="Student's NRIC ">
                                                <ItemStyle Width="40%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="Name" HeaderText="Student's Name">
                                                <ItemStyle Width="40%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="FoodPreferrence" HeaderText="Indicated Food Preferrence">
                                                <ItemStyle Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="10%" DataField="Status" HeaderText="Parent's signature">
                                                <ItemStyle Width="20%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <p><asp:Label ID="noStudentsMsg" runat="server" Text="No students found."></asp:Label></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:Button ID="ExportBtn" CssClass="btn btn-info" runat="server" Text="Export to Excel File" OnClick="ExportBtn_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <button type="button" style="margin-top:10px" class="btn-success btn" onclick="window.print()">Print</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</asp:Content>
