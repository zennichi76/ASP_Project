<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EADP_Project.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
     .card{
         margin-top:5px;
         margin-bottom:20px;
     }
    .container{
        padding-top: 50px;
        
        }
    </style>

     <script type="text/javascript">
   
    </script>

    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-lg-6">
                    <div class="card" style="width: 100%;">
                        <div class="card-header">
                            <h5 class="h5">
                                Welcome
                            <asp:Label ID="ProfileName_LB" runat="server"></asp:Label>

                            </h5>
                        </div>
                        <div class="card-body">                           
                            <h4>
                                <asp:Label ID="Role_LB" runat="server"></asp:Label></h4>
                            <p class="card-text">
                                User ID:
                            <asp:Label ID="UserID_LB" runat="server"></asp:Label>
                            </p>
                            <p class="card-text">
                                Orion points:
                            <asp:Label ID="OrionPoints_LB" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;CCA Points:
                            <asp:Label ID="CCAPoints_LB" runat="server"></asp:Label>
                            </p>

                            <a href="Profile.aspx" class="card-link">Click here to view or edit your profile!</a>
                        </div>
                        `          
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card" style="width: 100%;">
                        <div class="card-header">
                            <h5 class="h5">Past Purchases</h5>
                        </div>
                        <div class="card-body">
                            <h6 class="card-subtitle mb-2 text-muted">Past Purchases</h6>
                            <asp:GridView ID="purchaseHistoryGridView" CssClass="table table-sm table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ReceiptId" HeaderText="Receipt No." />
                                    <asp:BoundField DataField="purchaseDate" HeaderText="Date" />
                                </Columns>
                            </asp:GridView>
                            <p class="card-text">
                                <asp:Label ID="ErrorLabelPurchase" runat="server" Text="You have not purchased anything."></asp:Label>

                            </p>
                            <a href="PurchaseHistory.aspx" class="card-link">See Purchase History</a>
                        </div>
                        `          
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6" id="PendingItems_Col" runat="server">
                    <div class="card" style="width: 100%;">
                        <div class="card-header">
                            <h5 class="h5">Pending Items</h5>
                        </div>
                        <div class="card-body">
                            <h6 class="card-subtitle mb-2 text-muted">Pending Items</h6>
                            <p><asp:Label ID="pendingItemsLabel" runat="server"></asp:Label></p>
                            <asp:HyperLink ID="ToPendingItems" CssClass="card-link" runat="server" NavigateUrl="~/PendingConsentForms.aspx">Click here to see pending items</asp:HyperLink>
                        </div>
                        `          
                    </div>
                </div>
                <div class="col-lg-6" id="RegisteredActivities_Col" runat="server">
                    <div class="card" style="width: 100%;">
                        <div class="card-header">
                            <h5 class="h5">Registered Events</h5>
                        </div>
                        <div class="card-body">
                            <h6 class="card-subtitle mb-2 text-muted">Registered Events</h6>
                            <asp:GridView ID="RegisteredEventGridView" CssClass="table table-sm table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField HeaderText="Event Name" DataField="eventName" />
                                    <asp:BoundField HeaderText="Start Date " DataField="eventSDate" />
                                    <asp:BoundField HeaderText="End Date" DataField="eventEDate" />
                                    <asp:BoundField HeaderText="Start Time" DataField="eventSTime" />
                                    <asp:BoundField HeaderText="End Time" DataField="eventETime" />
                                </Columns>
                            </asp:GridView>
                            <p><asp:Label ID="EventsErrorMsg" runat="server" Text="No Event Registered"></asp:Label></p>
                            <a href="studentViewEvent.aspx" class="card-link">View Registered Events</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6" id="ConsentForms_Col" runat="server">
                    <div class="card" style="width: 100%;">
                        <div class="card-header">
                            <h5 class="h5">Manage Consent forms</h5>
                        </div>
                        <div class="card-body">                           
                            <h6 class="card-subtitle mb-2 text-muted">Recently sent consent forms</h6>
                            <asp:GridView ID="GridViewSentForms" CssClass="table table-sm table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="Recently Sent Forms" />
                                </Columns>
                            </asp:GridView>
                            <p class="card-text"><asp:Label ID="ErrorConsentForm" runat="server" Text="No consent form sent recently."></asp:Label></p>
                            <asp:HyperLink ID="ToConsentFormsManagementBtn" CssClass="card-link" runat="server">Manage consent forms</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>

     

        </div>

        
  

    </form>

</asp:Content>
