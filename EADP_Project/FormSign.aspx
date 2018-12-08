<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormSign.aspx.cs" Inherits="EADP_Project.FormSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .CheckBox {
            padding-right: 0.5em;
        }
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -ms-flex: 0 0 83.333333%;
            flex: 0 0 83.333333%;
            max-width: 83.333333%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <form id="form1" runat="server">
        <div class="container">
            <%----overlay----%>
            <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="modalOverlay">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align: center; z-index: 11; padding: 50px;">
                    <p>Form is signed successfully</p>
                    <p>Click on the button to prcoeed</p>
                    <asp:Button ID="ProceedBtn" runat="server" CssClass="btn btn-light" Text="Proceed" OnClick="ProceedBtn_Click" UseSubmitBehavior="False" />
                </div>
            </div>
            <%--------------%>
            <div class="row">
                <div class="col-lg-12" style="margin-top:25px">
                    <div class="card">
                        <div class="card-header">
                            <h4>Consent Form</h4>
                        </div>
                        <div class="card-body">
                            <a href="PendingConsentForms.aspx">Return to Pending Items</a>
                            <div class="row" style="margin-top:25px">
                                <div class="col-lg-10" style="margin: 0 auto">
                                    <h5>Title:
                                        <asp:Label ID="TitleLB" runat="server"></asp:Label></h5>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-10" style="margin: 0 auto">
                                    <h5>Description:</h5>
                                </div>
                            </div>
                            <div class="row">
                                <div class="auto-style1" style="margin: 0 auto">
                                    <asp:TextBox ID="DescriptionTB" Width="100%" Height="25em" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-10" style="margin: 0 auto">
                                    <div class="card" runat="server" id="foodprefcard">
                                        <div class="card-body" style="padding: 20px;">
                                            <asp:RadioButtonList ID="FoodRadioButton" runat="server">

                                                <asp:ListItem Selected="True">No Food Preferrence</asp:ListItem>
                                                <asp:ListItem>Vegatarian</asp:ListItem>
                                                <asp:ListItem>No Pork</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>

                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="OthersTB" placeholder="-Others- Please indicate" Style="width: 20em; min-width: 20em; max-width: 20em;" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:Label ID="OthersAlert" ForeColor="Red" runat="server" Text="Please enter your food preferrence."></asp:Label>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <div runat="server" id="signgroup">
                                <div class="row">
                                    <div class="col-lg-10" style="margin: 0 auto">

                                        <div style="padding-top: 10px; padding-bottom: 10px">
                                            <label for="signedCheck">I agree to sign this form</label>
                                            <input id="signedCheck" class="form-check form-check-inline" type="checkbox" required />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-10" style="margin: 0 auto">
                                        <asp:Button ID="signBtn" CssClass="btn btn-success" runat="server" Text="Sign" OnClick="signBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-10" style="margin: 0 auto">
                                    <asp:Label ID="alertLB" ForeColor="Red" runat="server" Text="Please ask your parent to sign this form"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
