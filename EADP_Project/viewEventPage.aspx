<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="viewEventPage.aspx.cs" Inherits="EADP_Project.EventPage.viewEventPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <!--bootstrap cscs-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.3/css/bootstrap.min.css" integrity="sha384-Zug+QiDoJOrZ5t4lssLdxGhVrurbmBWopoEl+M6BdEfwnCJZtKxi1KgxUyJq13dy" crossorigin="anonymous" />
     <script src="../js/jquery-3.2.1.js"></script>
    <script src="../js/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="../Scripts/moment.js"></script>
    <script src="../Scripts/moment.min.js"></script>
    <link rel="stylesheet" href="../css/bootstrap.css" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />--%>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        @media (min-width: 34em) {
    .card-columns {
        -webkit-column-count: 2;
        -moz-column-count: 2;
        column-count: 2;
    }
}
 
        </style>

            <script type="text/javascript">
                function myFunction() {
                    window.print();
                }
</script>
    <form runat="server">
       <%-- container--%>
        <div class="container">
 <div class="row">
  <div class="col-xs-12 col-md-12">
 <asp:Panel ID="eventPanel" runat="server">
<div class="card" style="margin-top:25px">
  <div class="card-header">My Events
         <asp:Button ID="createBtn" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="createBtn_Click" />
      <asp:Button ID="AllocatePointsBtn" runat="server" CssClass="btn btn-success" OnClick="AllocatePointsBtn_Click" Text="Allocate Points" />
  </div>
  <div class="card-body">
                <div class="row"> 
                    <div class="col-xs-12 col-md-12" style="background-color: ghostwhite" >
                       
  <asp:GridView ID="taskGridView" runat="server" AutoGenerateColumns="False" 
               OnRowDataBound="taskGridView_RowDataBound" HorizontalAlign="Center"  CssClass="table table-light table-bordered" DataKeyNames="eventId" OnSelectedIndexChanged="taskGridView_SelectedIndexChanged"
                        EmptyDataText="No Events Found. " ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="5" OnPageIndexChanged="taskGridView_PageIndexChanged" OnPageIndexChanging="taskGridView_PageIndexChanging" >

               <Columns>
       
                   <asp:BoundField DataField="eventId" HeaderText="Id" ReadOnly="True" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" >
<HeaderStyle CssClass="hidden-xs"></HeaderStyle>
<ItemStyle CssClass="hidden-xs"></ItemStyle>
                   </asp:BoundField>
     
                   <asp:BoundField DataField="eventName" HeaderText="Name" ReadOnly="True" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
<HeaderStyle CssClass="visible-md"></HeaderStyle>
                       <ItemStyle Width="3cm" />
                   </asp:BoundField>

                   <asp:BoundField DataField="eventSDate" HeaderText="Start Date" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" >
<HeaderStyle CssClass="visible-md"></HeaderStyle>

<ItemStyle CssClass="visible-md"></ItemStyle>
                   </asp:BoundField>

                   <asp:BoundField DataField="eventEDate"  HeaderText="End Date" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" >
<HeaderStyle CssClass="visible-md"></HeaderStyle>

<ItemStyle CssClass="visible-md"></ItemStyle>
                   </asp:BoundField>

                   <asp:BoundField DataField="eventSTime" HeaderText="Start Time" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" >
<HeaderStyle CssClass="visible-md"></HeaderStyle>

<ItemStyle CssClass="visible-md"></ItemStyle>
                   </asp:BoundField>
             
                   <asp:BoundField DataField="eventETime" HeaderText="End Time" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" >
<HeaderStyle CssClass="visible-md"></HeaderStyle>

<ItemStyle CssClass="visible-md"></ItemStyle>
                   </asp:BoundField>
                  
                   <asp:CommandField ButtonType="Button" ShowSelectButton="True" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" >
<HeaderStyle CssClass="visible-md"></HeaderStyle>

<ItemStyle CssClass="visible-md"></ItemStyle>
                   </asp:CommandField>
               </Columns>

               <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

           </asp:GridView>
                    
                  

</div>
<%-- end of ET --%>
                     </div> <%--end of row--%>
      </div> <%--end of card body--%>
    </div> <%--end of card--%>

 </asp:Panel>
                     <asp:Panel ID="eventDetails" runat="server" style="margin-top:25px" Visible="false">
      <div class="card">
          <div class="card-body">
<div class="row">
       <%-- details table --%>
            <div class="col-xs-12 col-md-12" style="background-color: ghostwhite" >
       
                <div class="table-responsive">   
                
                <table class="table table-striped">
                    <tr>
                        <td>
                                <asp:Button ID="Back" CssClass="btn btn-light" runat="server" Text="Back To MyEvents" OnClick="Back_Click" Width="216px" /> 
                            <asp:Button ID="editBtn" CssClass="btn btn-primary" runat="server" OnClick="editBtn_Click" Text="Edit" /> 
                             <asp:Button ID="getParticipantList" CssClass="btn btn-success" runat="server" Text="View Participant List" OnClick="getParticipantList_Click" /> 
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
                         <td>Max Capacity: 
                             <asp:Label ID="selectedMaxCapLbl" runat="server" Text="Label" ></asp:Label> &nbsp;&nbsp;
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
               </div> <%-- end of row --%>

              </div>
      </div>
      
                  </asp:Panel>  

      <asp:Panel ID="attendancePanel" runat="server" Visible="false" >
          <asp:Button ID="printBtn" runat="server" CssClass="btn btn-success"  Text="Print Attendance List" onClientclick="window.print();"/>
          <asp:GridView ID="printParticipatorGV" runat="server" CssClass="table table-light table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="printParticipatorGV_SelectedIndexChanged" HorizontalAlign="Center" >
              <Columns>
                  <asp:BoundField DataField="participatorId" HeaderText="Participator Id" /> 
              </Columns>
          </asp:GridView>
      </asp:Panel>

  </div> 

</div>
</div>
        </form>
</asp:Content>




