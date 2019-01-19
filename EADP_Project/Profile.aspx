<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EADP_Project.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12">
                <div runat="server" id="mainPanel" class="card" style="margin: 0 auto; margin-top: 25px">
                    <div class="card-header">
                        <h4>Profile</h4>
                    </div>
                    <div class="card-body">
                        <a href="Dashboard.aspx">Return to Dashboard</a>
                        <p></p>
                        <p>
                            Username:
                            <asp:Label ID="UsernameTB" runat="server"></asp:Label>
                        <br>
                            Name:
                            <asp:Label ID="NameTB" runat="server"></asp:Label>
                        <br>
                            Email:
                            <asp:Label ID="EmailTB" runat="server"></asp:Label>
                        <br>
                            Access History 

                            <asp:GridView ID="accessLogView"  CssClass="table table-bordered table-light" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ip" HeaderText="IP Address" />
                                    <asp:BoundField HeaderText="Access Time" DataField="accessTime" />
                                </Columns>
                            </asp:GridView>

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
                        <asp:Button ID="Button2" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Email" OnClick="Button2_Click" UseSubmitBehavior="False" />
                        <p></p>
                        <p>
                            Change Password:                       
                        </p>
                        <p style="color: grey">
                            Password Last Changed on <asp:Label ID="LastPwdChangeLbl" runat="server"></asp:Label> &nbsp;(Valid for: <asp:Label ID="DaysToChangeLbl" runat="server"></asp:Label> )
                        </p>
                        <p style="color: red">
                            <asp:Label ID="ErrorMsgLabel" runat="server"></asp:Label>
                        </p>

                        <div class="row">
                            <asp:TextBox ID="ChangePwdTB" runat="server" TextMode="Password" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="New Password"></asp:TextBox>
                            <asp:TextBox ID="ChangePwdConfirmTB" runat="server" TextMode="Password" Style="margin-left: 15px" CssClass="form-control col-lg-2" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                        <asp:Button ID="Button1" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Change Password" OnClick="Button1_Click" UseSubmitBehavior="False" />
                    
                        <p></p>
                        <p>
                            Google Authenticator: <asp:LinkButton ID="gAuthEnableLink" runat="server" OnClick="gAuthEnableLink_Click" CausesValidation="False">Add Google Authenticator</asp:LinkButton>                       
                            <asp:LinkButton ID="gAuthDisableLink" runat="server" OnClick="gAuthDisableLink_Click" CausesValidation="False" >Remove Google Authenicator</asp:LinkButton>                       
                            <asp:Label ID="gAuthSuccessMessage" style="color: red" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="card"  runat="server" id="gAuthCard" style="margin: 0 auto; margin-top: 25px">
                    <div class="card-header">
                        <h4>Google Authenticator</h4>
                    </div>
                    <div class="card-body">
                        <p>To enable Google Authenticator, first scan this QR code in the Google Authenticator App on your phone:</p>
                        <asp:Image ID="gAuthImage" runat="server" />
                        <p>Alternatively, enter this secret key to your Google Authenticator App on your phone <br><asp:Label ID="gAuthManualKeyLbl" runat="server"></asp:Label></p>
                        <p>Next, enter the 6-digit passcode it gives you here to activate</p>
                        <asp:TextBox ID="gAuthPassTb" runat="server" CssClass="form-control col-lg-2" TextMode="Password"></asp:TextBox>
                        
                        <p style="color: red">
                            <asp:Label ID="GoogleAuthErrorMsgLabel" runat="server"></asp:Label>
                        </p>
                        <asp:Button ID="activateBtn" type="button" CssClass="btn btn-outline-dark" runat="server" Style="margin-top: 15px" Text="Activate" OnClick="activateBtn_Click" UseSubmitBehavior="False"/>
                     
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
