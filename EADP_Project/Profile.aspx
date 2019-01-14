<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EADP_Project.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12">
                <div class="card" style="margin: 0 auto; margin-top: 25px">
                    <div class="card-header">
                        <h4>Profile</h4>
                    </div>
                    <div class="card-body">
                        <a href="Dashboard.aspx">Return to Dashboard</a>
                        <p></p>
                        <p>
                            Username:
                            <asp:Label ID="UsernameTB" runat="server"></asp:Label>
                        </p>
                        <p>
                            Name:
                            <asp:Label ID="NameTB" runat="server"></asp:Label>
                        </p>
                        <p>
                            Email:
                            <asp:Label ID="EmailTB" runat="server"></asp:Label>
                        </p>
                        <p>
                            Change Email:                       
                        </p>
                        <p style="color: red">
                            <asp:Label ID="ErrorMsgLabelEmail" runat="server"></asp:Label>
                        </p>
                        <div class="row">
                            <asp:TextBox ID="newEmailTB" runat="server" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="New Email" OnTextChanged="newEmailTB_TextChanged" ></asp:TextBox>
                            
                        </div>
                        <asp:Button ID="Button2" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Email" OnClick="Button2_Click" />
                        <p></p>
                        <p>
                            Change Password:                       
                        </p>
                        <p style="color: grey">
                            Password Last Changed on: <asp:Label ID="LastPwdChangeLbl" runat="server"></asp:Label>
                        </p>
                        <p style="color: grey">
                            Please Change Your Password in: <asp:Label ID="DaysToChangeLbl" runat="server"></asp:Label>
                        </p>
                        <p style="color: red">
                            <asp:Label ID="ErrorMsgLabel" runat="server"></asp:Label>
                        </p>

                        <div class="row">
                            <asp:TextBox ID="ChangePwdTB" runat="server" TextMode="Password" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="New Password"></asp:TextBox>
                            <asp:TextBox ID="ChangePwdConfirmTB" runat="server" TextMode="Password" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Password" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
