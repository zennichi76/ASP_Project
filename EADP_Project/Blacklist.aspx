<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Blacklist.aspx.cs" Inherits="EADP_Project.Blacklist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" BackColor="White">
            <asp:Label ID="Label1" runat="server" Text="Your IP address has been blacklisted by our administrator due to illegal activity" Font-Bold="True" Font-Size="18pt"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="18pt" Text="  If you have any enquiries please email to us at: orionedu@gmail.com"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18pt" Text="  Thank you."></asp:Label>
        </asp:Panel>
    </form>
</asp:Content>
