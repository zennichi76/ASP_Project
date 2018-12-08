<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="EADP_Project.PurchaseHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="container">
        <div class="col-lg-12" style="margin-top:25px;">
            <div class="card" style="padding-bottom:100px">
                <div class="card-header"><h4>Purchase History</h4></div>
                <div class="card-body">
                    <a href="Dashboard.aspx">Return to Dashboard</a>
                    <asp:GridView ID="PurchaseHistoryGridView" CssClass="table table-bordered"  style="margin-top:25px;" runat="server" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" OnPageIndexChanging="PurchaseHistoryGridView_PageIndexChanging" OnSelectedIndexChanged="PurchaseHistoryGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="ReceiptId" HeaderText="Receipt No." />
                            <asp:BoundField DataField="Items" HeaderText="Items" />
                            <asp:BoundField DataField="Price" HeaderText="Price($)" DataFormatString="{0:0.00}" />
                            <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" />
                            <asp:CommandField HeaderText="View Receipt" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="ErrorMsgGridView" runat="server" Text="There were no purchases made."></asp:Label>
                    <div runat="server" id="receiptPanel">
                        <h4>Receipt</h4>
                        <p>Receipt No. : <asp:Label ID="ReceiptNoLB" runat="server" ></asp:Label></p>
                        <p>Items : <asp:Label ID="ItemsLB" runat="server" ></asp:Label></p>
                        <p>Price : $<asp:Label ID="PriceLB" runat="server" ></asp:Label></p>
                        <p>Purchase Date : <asp:Label ID="DateLB" runat="server" ></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
        
    
    </form>
</asp:Content>
