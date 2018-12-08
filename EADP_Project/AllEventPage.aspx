<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AllEventPage.aspx.cs" Inherits="EADP_Project.EventPage.AllEventPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon"> 

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to join this event?")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form2" runat="server">
    <asp:Panel ID="EventPanel" runat="server">
 <div class="container">

      <div class="card" style="margin-top:25px">
  <div class="card-block">
      <div class="card-header">
             <asp:Button ID="viewMyEventBtn" runat="server" Text="View My Event" CssClass="btn btn-info" OnClick="viewMyEventBtn_Click" />
          <h3 class="card-title">Event List</h3>

      </div>


    
      <asp:GridView ID="AllEventGridView" runat="server" AutoGenerateColumns="False" 
          OnSelectedIndexChanged="AllEventGridView_SelectedIndexChanged" AllowPaging="True"  CssClass="table table-light table-bordered"
          PageSize="5" ShowHeaderWhenEmpty="True" HorizontalAlign="Center"  EmptyDataText="No Events Found." OnPageIndexChanging="AllEventGridView_PageIndexChanging"> 
           <Columns>
               <asp:BoundField DataField="eventId" HeaderText="Event Id" />
               <asp:BoundField DataField="eventName" HeaderText="Event Name" />
               <asp:BoundField DataField="eventSDATE" HeaderText="Start Date" />
               <asp:BoundField DataField="eventEDATE" HeaderText="End Date" />
               <asp:BoundField DataField="eventSTime" HeaderText="Start Time" DataFormatString="{0:t}" />
               <asp:BoundField DataField="eventETime" HeaderText="End Time" DataFormatString="{0:t}" />
               <asp:CommandField ShowSelectButton="True" SelectText="View Details" >
               <ControlStyle CssClass="btn btn-outline-primary" />
               </asp:CommandField>
           </Columns>
       </asp:GridView>

  </div>
</div>
            </div>
    </asp:Panel>
       
            <asp:Panel ID="eventDetailsPanel" runat="server" Visible="false">
                <div class="container">
                <div class="card col-md-12" style="margin-top:25px">
    
    <div class="card-header"><asp:Button ID="openEventPanelBtn" runat="server" Text="Back to Event Page" CssClass="btn btn-info" OnClick="openEventPanelBtn_Click" /></div>
<div class="card-body">

     <div class="table-responsive">   
                <table class="table table-striped">
                    <%-- event details panel --%>
                    <tr class =" active">
                        
                        <td > Event Name:&nbsp; 
                            <asp:Label ID="selectedEventIdLbl" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="selectedEventLbl" runat="server" Text=""></asp:Label> 
                            <asp:Label ID="creatorIdLbl" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>

                     <tr class =" active">
                        <td> Start Date - End Date:&nbsp;
                            <asp:Label ID="selectedSDateLbl" runat="server" Text=""></asp:Label> &nbsp;- 
                            <asp:Label ID="selectedEDateLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                     <tr class =" active">
                        <td> Start Time - End Time:  
                             <asp:Label ID="selectedSTimeLbl" runat="server" Text=""></asp:Label> &nbsp;-
                            <asp:Label ID="selectedETimeLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                        
                     <tr class =" active">
                        <td>Description:
                            <br />
                             <asp:Label ID="selectedDescripLbl" runat="server" Text="" style="width:100px; overflow-y:auto;overflow-x:auto; word-break:inherit;"></asp:Label>
                        </td>
                    </tr>

                     <tr class =" active">
                         <td>Max Capacity: 
                             <asp:Label ID="selectedMaxCapLbl" runat="server" Text="" ></asp:Label> &nbsp;&nbsp; ;
                             CCA Points: 
                              <asp:Label ID="ccaPointLbl" runat="server" Text=""></asp:Label>&nbsp;&nbsp; ;
                             Orion Points:
                              <asp:Label ID="orionPointLbl" runat="server" Text=""></asp:Label>&nbsp;&nbsp;  ;
                             Number of People Joined: &nbsp; <asp:Label ID="currentCapacLbl" runat="server" Text=""></asp:Label> ;
                    </td>
                    </tr>
                    <tr class="active">
                        <td> Your User ID:
                            <asp:Label ID="idLbl" runat="server" Text=""></asp:Label>
                            &nbsp;<asp:Button ID="joinBtn" runat="server" Text="Sign up" OnClick="joinBtn_Click" CssClass="btn btn-success" OnClientClick="Confirm()"  />
                        </td>
                    </tr>
                    
                </table>
            </div>

  

</div>
  

</div>
                    </div>
       </asp:Panel>

    </form>

</asp:Content>
