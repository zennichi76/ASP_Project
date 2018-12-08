<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="viewMyTuitionPage.aspx.cs" Inherits="EADP_Project.StudentTutorPage.viewMyTuitionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../js/jquery-3.2.1.js"></script>
    <script src="../js/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="../Scripts/moment.js"></script>
    <script src="../Scripts/moment.min.js"></script>



    <link rel="stylesheet" href="../css/bootstrap.css" />

    <link rel="stylesheet" href="../css/bootstrap.min.css" />

    <style>
    
        .auto-style1 {
            height: 39px;
        }
    
    </style>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to update the status?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmCancel() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to cancel the request?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmQuit() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to quit this session?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class =" container">
            <div class="col-sm-11 col-lg-11">
        <div class="card">
            <div class="card-header">
                <asp:Button ID="viewAllTutorSession" runat="server" Text="All Tutor Session" CssClass="btn-sm btn-info" OnClick="viewAllTutorSession_Click" />
                &nbsp;
                <asp:Button ID="createTuition" runat="server" Text="Create Tutor Session" CssClass="btn-sm btn-info" OnClick="createTuition_Click" />
                &nbsp;
                <asp:Button ID="requestToMeBtn" runat="server" Text="View Request To Me" CssClass="btn-sm btn-info" OnClick="requestToMeBtn_Click" />
                &nbsp;
                <asp:Button ID="RequestByMeBtn" runat="server" Text="View Request To Other People" CssClass="btn-sm btn-info" OnClick="RequestByMeBtn_Click" />
                &nbsp;
                <asp:Button ID="SessionCreatedByMeBtn" runat="server" Text="My Session" CssClass="btn-sm btn-info" OnClick="SessionCreatedByMe_Click" />
                &nbsp;
                <asp:Button ID="SessionJoinedBtn" runat="server" Text="Session Joined" CssClass="btn-sm btn-info" OnClick="SessionJoinedBtn_Click"  />
            </div>

            <div class="card-block">
                 <%--session by me panel--%>
            <asp:Panel ID="SessionByMePanel" runat="server">
            
                    <asp:GridView ID="tuitionGrid" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="tuitionGrid_SelectedIndexChanged"  CssClass="table table-light table-bordered" HorizontalAlign="Center"
                        DataKeyNames="sessionId" EmptyDataText="No Tuition Session Found. " ShowHeaderWhenEmpty="True" OnPageIndexChanging="tuitionGrid_PageIndexChanging" PageSize="5">

                        <Columns>
                            <asp:BoundField DataField="SessionID" HeaderText="Id" ReadOnly="True" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                                <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                                <ItemStyle CssClass="hidden-xs"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="sessionDetails" HeaderText="Details" ReadOnly="True" />
                            <asp:BoundField DataField="sessionDate" HeaderText="Date" ReadOnly="True" SortExpression="sessionDate" />
                            <asp:BoundField DataField="sessionSTime" HeaderText="Start Time" ReadOnly="True" />
                            <asp:BoundField DataField="sessionETime" HeaderText="End Time" ReadOnly="True" />
                            <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View Details" >
                            <ControlStyle CssClass="btn btn-outline-primary btn-sm" />
                            </asp:CommandField>
                        </Columns>

                    </asp:GridView>
    
  
            </asp:Panel>
                 <asp:Panel ID="sessionDetailsPanel" runat="server" Visible="false">
                <div class="col-sm-10 col-lg-10">
                    <div class="card-body">
                          <table class="table table-striped">
                    <asp:Button ID="EditBtn" CssClass="btn-primary btn" runat="server" Text="Edit" OnClick="EditBtn_Click" />
                             
                    <tbody>
                        <tr>
                            <td>Session Details:&nbsp;
                                <asp:Label ID="tutionDescriptionLbl" runat="server" Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>Date:&nbsp;
                                 <asp:Label ID="dateLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Session Time:&nbsp;
                                     <asp:Label ID="stimeLbl" runat="server" Text="Label"></asp:Label>&nbsp;
                                To
                                 &nbsp;<asp:Label ID="etimeLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Tutor Id:&nbsp;
                                 <asp:Label ID="tutorIdLbl" runat="server" Text="Label"></asp:Label>
                                &nbsp;&nbsp;
                                Tutee Id:&nbsp;
                                <asp:Label ID="tuteeIdLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                    </div>
            </div>
                

            </asp:Panel>

         <%--end session I Joined me panel--%>

                  <asp:Panel ID="sessionIjoinedPanel" runat="server" visible="false">
            
                    <asp:GridView ID="JoinedSessionGV" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="JoinedSessionGV_SelectedIndexChanged"  CssClass="table table-light table-bordered" HorizontalAlign="Center"
                        DataKeyNames="sessionId" EmptyDataText="No Tuition Joined Found. " ShowHeaderWhenEmpty="True" OnPageIndexChanging="JoinedSessionGV_PageIndexChanging" PageSize="5" AllowPaging="True">

                        <Columns>
                            <asp:BoundField DataField="SessionID" HeaderText="Id" ReadOnly="True" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                                <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                                <ItemStyle CssClass="hidden-xs"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="sessionDetails" HeaderText="Details" ReadOnly="True" />
                            <asp:BoundField DataField="sessionDate" HeaderText="Date" ReadOnly="True" SortExpression="sessionDate" />
                            <asp:BoundField DataField="sessionSTime" HeaderText="Start Time" ReadOnly="True" />
                            <asp:BoundField DataField="sessionETime" HeaderText="End Time" ReadOnly="True" />
                            <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View Details" >
                            <ControlStyle CssClass="btn btn-outline-primary btn-sm" />
                            </asp:CommandField>
                        </Columns>

                    </asp:GridView>
    
  
            </asp:Panel>
                 <asp:Panel ID="sessionIjoinedDetailsPanel" runat="server" Visible="false">
                <div class="col-sm-10 col-lg-10">
                    <div class="card-body">
                          <table class="table table-striped">
                    
                             
                    <tbody>
                        <tr>
                            <td class="auto-style1">Session Details:&nbsp;
                                <asp:Label ID="SJDeatilsLbl" runat="server" Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>Date:&nbsp;
                                 <asp:Label ID="SJDateLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Session Time:&nbsp;
                                     <asp:Label ID="SJSTimeLbl" runat="server" Text="Label"></asp:Label>&nbsp;
                                To
                                 &nbsp;<asp:Label ID="SJETimeLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Tutor Id:&nbsp;
                                 <asp:Label ID="SJTutorId" runat="server" Text="Label"></asp:Label>
                                &nbsp;&nbsp;
                                Tutee Id:&nbsp;
                                <asp:Label ID="SJTuteeId" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <asp:Button ID="unjoinSessionButton" CssClass="btn-danger btn" runat="server" Text="Unjoin" OnClientClick="ConfirmQuit()" OnClick="unjoinSessionButton_Click"  />
                        </tr>
                    </tbody>
                </table>
                    </div>
            </div>
                

            </asp:Panel>

         <%--end session by me panel--%>


<%--Request To Me Panel--%>
             <asp:Panel ID="viewRequestToMePanel" runat="server"  Visible="false">
                    <asp:GridView ID="RequestToMeGV" runat="server" AutoGenerateColumns="False"  CssClass="table table-light table-bordered" EmptyDataText="No request To You is Found. " ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="RequestToMeGV_PageIndexChanging" OnSelectedIndexChanged="RequestToMeGV_SelectedIndexChanged" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="requestId" HeaderText="RequestId" ReadOnly="True" />
                            <asp:BoundField DataField="requestDetails" HeaderText="Request Details" ReadOnly="True" />
                            <asp:BoundField DataField="requestTo" HeaderText="Request To" ReadOnly="True" />
                            <asp:BoundField DataField="requestBy" HeaderText="Request By" ReadOnly="True" />
                            <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" NullDisplayText="Pending" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View Details" >
                            <ControlStyle CssClass="btn btn-outline-primary btn-sm" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

                <%-- details --%>
               
                <asp:Panel ID="requestToMeDetailsPanel" runat="server" Visible="false">
                <table class="table table-light table-bordered">
                        <thead>
                            <tr>
                                <th>Request To Me</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Request ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="requestIdLbl" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Request Details:
                                 <asp:Label ID="requestDetailsLbl" runat="server"
                                     Text="" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   Request To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="requestToLbl" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              <td>
                                   Request By:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="requestByLbl" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              <td>
                                   Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="statusDDL" runat="server" CssClass="form-control-sm" AutoPostBack="True">
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Accepted</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem Enabled="False">Canceled</asp:ListItem>
                                   </asp:DropDownList> &nbsp;&nbsp;
                                  <asp:Label ID="cancelLbl" runat="server" Text="" visible="false"></asp:Label>
                                  <asp:Button ID="updateBtn" runat="server" Text="Send" OnClick="updateBtn_Click" CssClass="btn btn-success" OnClientClick="Confirm()"/>

                              </td>
                            </tr>

                                
                        </tbody>
                    </table>
                    </asp:Panel>
            <%--End Request To Me Panel--%>

            <%--Request By Me Panel--%>
             <asp:Panel ID="viewRequestByMePanel" runat="server">
                    <asp:GridView ID="requestByMeGV" runat="server" AutoGenerateColumns="False"  CssClass="table table-light table-bordered" EmptyDataText="No request to other is found " ShowHeaderWhenEmpty="True" AllowPaging="True" OnPageIndexChanging="requestByMeGV_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="requestByMeGV_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="requestId" HeaderText="RequestId" />
                            <asp:BoundField DataField="requestDetails" HeaderText="Request Details" />
                            <asp:BoundField DataField="requestTo" HeaderText="Request To" />
                            <asp:BoundField DataField="requestBy" HeaderText="Request By" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View Details" >
                            <ControlStyle CssClass="btn btn-outline-primary btn-sm" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

            <asp:Panel ID="requestByMeDetailsPanel" runat="server" Visible="false">
                <table class="table table-light table-bordered">
                        <thead>
                            <tr>
                                <th>Request By Me</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Request ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="myRequestId" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Request Details:
                                 <asp:Label ID="myRequestDetails" runat="server"
                                     Text="" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   Request To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="myRequestTo" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              <td>
                                   Request By:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="myRequestBy" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                              <td>
                                   Status:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:Label ID="myStatusLbl" runat="server"
                                     Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                              </td>
                            </tr>
                            <tr>
                                <td>
                                      <asp:Button ID="cancelRequestBtn" runat="server" Text="Cancel Request" CssClass="btn btn-danger" OnClick="cancelRequestBtn_Click" OnClientClick="ConfirmCancel()" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="row">
                      
                    </div>
                    </asp:Panel>

            <%--End Request By Me Panel--%>
            </div>
            <%--end of mySession card block--%>

             



        </div>
            <%--end of card--%>
                    </div>
        </div>
        <%--end on main container--%>
    </form>
</asp:Content>