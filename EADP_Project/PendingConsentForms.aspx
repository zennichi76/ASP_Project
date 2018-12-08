<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PendingConsentForms.aspx.cs" Inherits="EADP_Project.PendingConsentForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Hidden-Field {
            display: none;
        }
    </style>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card" style="margin-top: 25px">
                        <div class="card-header">
                            <h4>Pending Items</h4>
                        </div>
                        <div class="card-body">
                            <a href="Dashboard.aspx">Return to Dashboard</a>
                            <div class="row">
                                <div class="col-lg-8" style="margin: 0 auto;">
                                    
                                    <asp:GridView ID="pendingForms" style="margin-top:25px" CssClass="table table-bordered table-hover table-light" runat="server" ControlStyle-Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="pendingForms_SelectedIndexChanged" Width="100%">
                                        <Columns>
                                            <asp:BoundField ItemStyle-CssClass="Hidden-Field" HeaderStyle-CssClass="Hidden-Field" DataField="ConsentFormID" HeaderText="ConsentFormID" >
<HeaderStyle CssClass="Hidden-Field"></HeaderStyle>

<ItemStyle CssClass="Hidden-Field"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85%" DataField="Title" HeaderText="Pending Consent Forms to Sign">
                                                <ItemStyle Width="85%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:CommandField ItemStyle-Width="15%" HeaderText="View" SelectText="View" ShowSelectButton="True">
                                                <ItemStyle Width="15%"></ItemStyle>
                                            </asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8" style="margin: 0 auto;text-align:center">
                                    <asp:Label ID="formalert" runat="server" Text="You have no pending items."></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>


