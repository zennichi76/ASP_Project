<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ViewParticipators.aspx.cs" Inherits="EADP_Project.EventPage.ViewParticipators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon">
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.2.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>

    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you assigned points to user?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmCancel() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you cancel?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }





    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">

        <div class="container" >
            <asp:Panel ID="Panel1" runat="server">
                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card" style="margin-top:25px">
                        <div class="card-header">
                            Allocate CCA Points / Orion Points
                        </div>
                        <div class="card-block">
                            <div class="card-block">
                                <h5 class="card-title">Allocation of Points to Events</h5>
                            </div>
                            <asp:GridView ID="viewParticipatorsGV" runat="server" AllowPaging="True" CssClass="table table-light table-bordered" AutoGenerateColumns="False" EmptyDataText="No Events to retireve" OnSelectedIndexChanged="viewParticipatorsGV_SelectedIndexChanged" PageSize="5" HorizontalAlign="Center" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="eventId" HeaderText="Id" ReadOnly="True" />
                                    <asp:BoundField DataField="participatorID" HeaderText="Participator Id" ReadOnly="True" />
                                    <asp:BoundField DataField="CCAPoints" HeaderText="CCA Points" ReadOnly="True" />
                                    <asp:BoundField DataField="Orion_Points" HeaderText="Orion Points" ReadOnly="True" />
                                    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>

                            <div class="card-block">
                            </div>

                        </div>
                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>

            <asp:Panel ID="allocatePanel" runat="server" Visible="false">

                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card">
                        <div class="card-block">

                            <div class="card-block">
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <label for="participatorId">
                                            Participator Id: 
             <asp:Label ID="participatorIdLbl" runat="server" CssClass="form-inline" Text=""></asp:Label>

                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="CCAPoints">
                                            CCA Points:
             <asp:Label ID="CCAPointsLbl" runat="server" CssClass="form-inline" Text=""></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="OrionPoints">
                                            Orion Points: 
             <asp:Label ID="OrionPointsLbl" runat="server" CssClass="form-inline" Text=""></asp:Label>
                                        </label>
                                    </div>
                                </div>
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <asp:Button ID="addPoints" runat="server" Text="Allocate Points" CssClass="btn btn-sm btn-success" OnClick="addPoints_Click" OnClientClick="Confirm()" />
                                        <asp:Button ID="EcancelBtn" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="EcancelBtn_Click" OnClientClick="ConfirmCancel()" />
                                    </div>
                                </div>
                                <div class="row">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>

            <asp:Panel ID="AllocationToTution" runat="server">
                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card">
                        <h5 class="card-title">Allocation of Points to Tution Session</h5>
                        <div class="card-block">
                            <asp:GridView ID="tutionPointsGV" runat="server" AllowPaging="True" CssClass="table table-light table-bordered" AutoGenerateColumns="False" EmptyDataText="No Student to retireve" PageSize="5" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="tutionPointsGV_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="tutorId" HeaderText="Id" ReadOnly="True" />

                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>


            <asp:Panel ID="AllocationToTutionPointsPanel" runat="server" Visible="false">

                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card">
                        <div class="card-block">
                            <div class="card-block">
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <label for="tutorId">
                                            Tutor Id: 
                 <asp:Label ID="TuserIdLbl" runat="server" CssClass="form-inline" Text=""></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="CCAPoints">
                                            CCA Points:
             <asp:Label ID="TCCAPointsLbl" runat="server" CssClass="form-inline" Text="1"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="OrionPoints">
                                            Orion Points: 
             <asp:Label ID="TOrionPointsLbl" runat="server" CssClass="form-inline" Text="1"></asp:Label>
                                        </label>
                                    </div>
                                </div>
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <asp:Button ID="TaddPointsBtn" runat="server" Text="Allocate Points" CssClass="btn btn-sm btn-success" OnClick="TaddPointsBtn_Click" OnClientClick="Confirm()" />
                                        <asp:Button ID="TCancelBtn" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="TCancelBtn_Click" OnClientClick="ConfirmCancel()" />
                                    </div>
                                </div>

                                <div class="row">
                                </div>

                            </div>
                        </div>


                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>


            <asp:Panel ID="Panel2" runat="server">
                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card">
                        <h5 class="card-title">Allocation of Points to Request Session</h5>
                        <div class="card-block">
                            <asp:GridView ID="requestPointsGV" runat="server" AllowPaging="True" CssClass="table table-light table-bordered" AutoGenerateColumns="False" EmptyDataText="No Student to retireve" PageSize="5" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="requestPointsGV_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="requestTo" HeaderText="Id" ReadOnly="True" />

                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>

            <asp:Panel ID="AllocationToRequestPointsPanel" runat="server" Visible="false">

                <div class="col-12 col-md-auto col-sm-12 col-lg-10">
                    <div class="card">
                        <div class="card-header">
                            To allocate panel
                        </div>
                        <div class="card-block">
                            <div class="card-block">
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <label for="tutorId">
                                            User ID: 
                 <asp:Label ID="RequestToLbl" runat="server" CssClass="form-inline" Text=""></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="CCAPoints">
                                            CCA Points:
             <asp:Label ID="RCCAPointsLbl" runat="server" CssClass="form-inline" Text="1"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-3">
                                        <label for="OrionPoints">
                                            Orion Points: 
             <asp:Label ID="ROrionPointsLbl" runat="server" CssClass="form-inline" Text="1"></asp:Label>
                                        </label>
                                    </div>
                                </div>
                                <div class="row form-inline">
                                    <div class="col-4">
                                        <asp:Button ID="RaddPointsBtn" runat="server" Text="Allocate Points" CssClass="btn btn-sm btn-success" OnClick="RaddPointsBtn_Click" OnClientClick="Confirm()" />
                                        <asp:Button ID="RcancelBtn" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="RcancelBtn_Click" OnClientClick="ConfirmCancel()" />
                                    </div>
                                </div>

                                <div class="row">
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <%--end of column--%>
            </asp:Panel>

            <div class="row">
            </div>

        </div>
        <%--end of container--%>
    </form>
</asp:Content>
