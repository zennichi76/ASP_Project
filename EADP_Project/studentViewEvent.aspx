<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="studentViewEvent.aspx.cs" Inherits="EADP_Project.studentEventPage.studentViewEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>
    
     <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to quit this event?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

            <div class="col-lg-11 col-sm-11" style="margin:0 auto;margin-top:25px">

                <asp:Button ID="viewAllEventBtn" runat="server" Text="View All Event" CssClass="btn btn-info" OnClick="viewAllEventBtn_Click" />

              <asp:Panel ID="myEventsPanel" runat="server">

 <div class="card ">
  <div class="card-header">My Events</div>
  <div class="card-body">

        <asp:GridView ID="myEventsGV" runat="server" AutoGenerateColumns="False" CssClass="table table-light table-bordered" OnSelectedIndexChanged="myEventsGV_SelectedIndexChanged" EmptyDataText="You did not joined any events" ShowHeaderWhenEmpty="True" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="event Id" />
                <asp:BoundField DataField="eventName" HeaderText="Event Name" />
                <asp:BoundField DataField="eventSDATE" HeaderText="Start Date" />
                <asp:BoundField DataField="eventEDATE" HeaderText="End Date" />
                <asp:BoundField DataField="eventSTime" HeaderText="Start Time" />
                <asp:BoundField DataField="eventETime" HeaderText="End Time" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="View Details" >

                <ControlStyle CssClass="btn btn-outline-primary btn-sm" />
                </asp:CommandField>

            </Columns>
        </asp:GridView>

   

       <asp:Panel ID="eventDetails" runat="server" Visible="false">
       <%-- details table --%>
            <div class="col-xs-12 col-md-12">
       
                <div class="table-responsive">   
                
                <table class="table table-light table-bordered table-hover">
                    <tr>
                        <td>
                                <asp:Button ID="Back" CssClass="btn btn-primary" runat="server" Text="Back To Events" OnClick="Back_Click" /> 
                                <asp:Button ID="unjoinBtn" CssClass="btn btn-danger" runat="server" Text="Unjoin" OnClick="unjoinBtn_Click"  OnClientClick="Confirm()"  />

                        </td>
                    </tr>
                    <%-- event details panel --%>
                    <tr class =" active">

                        <td > Event Name:&nbsp; 
                            <asp:Label ID="selectedEventLbl" runat="server" Text="Label"></asp:Label> 
                          <%--<asp:TextBox ID="selectedEvent" runat="server" CssClass="form-control" ReadOnly="True" Width="" ></asp:TextBox>--%>
                        </td>
                    </tr>

                     <tr class =" active">
                        <td> Start Date - End Date:&nbsp;
                            <asp:Label ID="selectedSDateLbl" runat="server" Text="Label"></asp:Label> &nbsp;- 
                            <asp:Label ID="selectedEDateLbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>

                     <tr class =" active">
                        <td> Start Time - End Time:  
                             <asp:Label ID="selectedSTimeLbl" runat="server" Text="Label"></asp:Label> &nbsp;-
                            <asp:Label ID="selectedETimeLbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                        
                     <tr class =" active">
                        <td>Description:
                            <br />
                             <asp:Label ID="selectedDescripLbl" runat="server" Text="Label" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                        </td>
                    </tr>

                     <tr class =" active">
                         <td>
                             CCA Points: 
                              <asp:Label ID="selectedCcaPointsLbl" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
                             Orion Points:
                              <asp:Label ID="selectedOrionPointsLbl" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
                    </td>
                    </tr>
                    
                </table>
            </div>

                <%-- end of DT --%>
            </div>

                  </asp:Panel>  

  </div> 

</div> <%--end of card--%>
</asp:Panel>
                

            </div><%-- end of col lg 11--%>

       

    </form>

</asp:Content>
