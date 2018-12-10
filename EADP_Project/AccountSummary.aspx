<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AccountSummary.aspx.cs" Inherits="EADP_Project.AccountSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top:25px">
                <div class="card">
                    <div class="card-header"><h4>Account Summary</h4></div>
                    <div class="card-body">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mail Test" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
