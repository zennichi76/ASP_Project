<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="viewAllTuition.aspx.cs" Inherits="EADP_Project.StudentTutorPage.viewAllTuition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon">
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.2.1.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>

    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>

    <script src="js/JavaScript.js"></script>


    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to sign up for this tution?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            display: block;
            /*width: 100%;*/
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            border: 1px solid #ced4da;
            margin-left: 0;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
        <div class =" container">
            <div class="col-sm-11 col-lg-11">
                  <asp:Panel ID="viewAllTutionPanel" runat="server">
                      <div class="card">
                            <h3 class="card-header">
                                 <asp:Button ID="backToTution" runat="server" Text="All Tution Page" CssClass="btn btn-primary" OnClick="backToTution_Click" UseSubmitBehavior="False"  />
                      <asp:Button ID="viewRequestBtn" runat="server" Text="Send Request" CssClass="btn btn-primary" OnClick="viewRequestBtn_Click" />
                     <asp:Button ID="backToMySessionBtn" runat="server" Text="My Session & Request" CssClass="btn btn-primary" UseSubmitBehavior="False" OnClick="backToMySessionBtn_Click"  />
                            </h3>
                             <div class="card-block">
                <asp:Panel ID="tutionPanel" runat="server">
                     <h4 class="card-title">All Available Sessions</h4>

                                <asp:GridView ID="viewAllTuitionGV" CssClass="table table-light table-bordered" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="True"
                                    PageSize="5" ShowHeaderWhenEmpty="True" HorizontalAlign="Center" EmptyDataText="No Sessions Found." OnPageIndexChanging="viewAllTuitionGV_PageIndexChanging" OnSelectedIndexChanged="viewAllTuitionGV_SelectedIndexChanged1">
                                    <Columns>
                                        <asp:BoundField DataField="SessionID" HeaderText="ID" />
                                        <asp:BoundField DataField="sessionDetails" HeaderText="Details" />
                                        <asp:BoundField DataField="sessionDate" HeaderText="Date" />
                                        <asp:BoundField DataField="sessionSTime" HeaderText="Start Time" />
                                        <asp:BoundField DataField="sessionETime" HeaderText="End Time" />
                                        <asp:BoundField DataField="tutorId" HeaderText="Tutor Id" />
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                      </asp:Panel>

                                  <asp:Panel ID="detailsPanel" runat="server" Visible="false">
                    <div class="card">
                            
                        
                        <table class="table table-light table-bordered">
                            <tbody>
                                <tr>
                                    <td>Tuition Id:
                      <asp:Label ID="tutionIdLbl" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Session Details:
                       <asp:Label ID="sessionDetailsLbl" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>Date:
                                    <asp:Label ID="dateLbl" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Time:
                                    <asp:Label ID="stimeLbl" runat="server" Text="Label"></asp:Label>
                                        To
                                    <asp:Label ID="etimeLbl" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tutor Id:
                                <asp:TextBox ID="tutorIdTB" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Tutee Id:
                                <asp:TextBox ID="tuteeIdTB" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="JoinTuition" CssClass="btn btn-primary" runat="server" Text="I want to Join!" OnClick="JoinTuition_Click" OnClientClick="Confirm()" />
                                        <asp:Button ID="backToSessionBtn" CssClass="btn btn-danger" runat="server" Text="Nah, I've changed my mind" UseSubmitBehavior="False" OnClick="backToSessionBtn_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
               
                            </div>


                        </div> <%--end of card--%>

                  </asp:Panel>
  
                    <asp:Panel ID="requestPanel" runat="server" Visible="false">
                        <div class ="card">
                        <div class="card-body">
                            <asp:Panel ID="tutorListPanel" runat="server" Visible="false">
                      <h4 class="card-title">List of tutors to send request</h4>

                   
                        <asp:GridView ID="studentGV" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-bordered" OnSelectedIndexChanged="studentGV_SelectedIndexChanged" ShowHeaderWhenEmpty="True" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="studentGV_PageIndexChanging" PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="user_Id" HeaderText="user_Id" />

                                <asp:BoundField DataField="education_level" HeaderText="Education Level" />

                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                </asp:Panel>

                             <asp:Panel ID="detailsTable" runat="server" Visible="false">
                          <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th scope="col" colspan="1">Send A Request</th>
                             
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Request Details
          <textarea class="form-control" rows="4" id="requestDetailsTB" name="requestDetails" required></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>Request To:
                                    <asp:Label ID="requestToLbl" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Request By: 
                                    <asp:Label ID="requestByLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="sendRequestBtn" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="sendRequestBtn_Click" />
                            <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="cancelBtn_Click" UseSubmitBehavior="False" />

                            </td>
                        </tr>
                    </tbody>
                </table>
                     </asp:Panel>

                        </div>
                            </div>
                    </asp:Panel>
       
            </div>
        </div> <%--end of container--%>

        <%-- request for tution  --%>

    </form>


</asp:Content>
