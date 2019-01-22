<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ConsentFormStatus.aspx.cs" Inherits="EADP_Project.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.simulate.js"></script>
      <script type="text/javascript">
          function openModal() {
              $('#sessionResetSucceed').modal('show');
          }

          function openFModal() {
              $('#errModal').modal('show');
          }
          ////Testing for idle timeout 
          var idleTime = 0;
          var timeout = 0;
          var tempTime = 0;

          function sessionAlert(timeout) {
              //Increment the idle time counter every minute.
              var time = timeout;
              var seconds = timeout / 1000;
              var minute = timeout / 60000;
              console.log("reach");

              $("#seconds").html(seconds);
              setInterval(function () {
                  seconds--;
                  $("#seconds").html(seconds);
              }, 1000);
              setTimeout(function () {
                  //Show Popup before 20 seconds of timeout.
                  $('#sessionTimeOutWarningModal').modal('show');
              }, timeout - 30 * 1000);
              setTimeout(function () {
                  //Show Popup after the previous popup
                  $('#sessionTimeOutWarningModal').modal('hide');
                  $('#reloadWarning').modal('show');
                  //setTimeout(function () {
                  //    $("#RemoveSessionBtn").simulate("click");
                  //}, 6000);
              }, timeout - 0 * 1000);
          }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card" style="margin-top:25px">
                        <div class="card-header">
                            <h4>Manage Consent Forms</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <a href="ManageConsentFormsPage.aspx">Return to Managing Consent Forms</a>
                                    <div style="margin-top:25px">
                                    <h5>Select a class to view</h5>
                                        </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:DropDownList ID="ClassesDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClassesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 25px">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:GridView ID="StudentTables" CssClass="table table-bordered table-light" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="UserID" HeaderText="Student's NRIC ">
                                                <ItemStyle Width="40%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="Name" HeaderText="Student's Name">
                                                <ItemStyle Width="40%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30%" DataField="FoodPreferrence" HeaderText="Indicated Food Preferrence">
                                                <ItemStyle Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="10%" DataField="Status" HeaderText="Parent's signature">
                                                <ItemStyle Width="20%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <p><asp:Label ID="noStudentsMsg" runat="server" Text="No students found."></asp:Label></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <asp:Button ID="ExportBtn" CssClass="btn btn-info" runat="server" Text="Export to Excel File" OnClick="ExportBtn_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="margin: 0 auto">
                                    <button type="button" style="margin-top:10px" class="btn-success btn" onclick="window.print()">Print</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

           <div class="modal" tabindex="-1" role="dialog" id="sessionTimeOutWarningModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Are you still there?</h5>
                            </div>
                            <div class="modal-body">
                                <p><%--<span id="minute"></span>&nbsp;minutes and --%>
                                    Hello,You're going to be timed out due to inactivity in&nbsp;<span id="seconds"></span>&nbsp;seconds.<br />
                                    Do You want to reset?'
                                </p>
                            </div>
                            <div class="modal-footer">
                              <asp:Button ID="Button3" runat="server" Text="Yes" OnClick="ResetSessionBtn_OnClick"  class="btn btn-light"/>
                              <%--  <button type="button" class="btn btn-light" id="ResetSessionBtn" onserverclick="ResetSessionBtn_OnClick" runat="server" AutoPostBack="False">Yes</button>--%>
                                <button type="button" class="btn btn-primary" id="Button4" onserverclick="RemoveSessionBtn_OnClick" runat="server">No</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--end of session modal-->
            

       <div class="modal" tabindex="-1" role="dialog" id="sessionResetSucceed" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Session Reset Succeed</h5>
                    
                </div>
                <div class="modal-body">
                    <p>
                       Your Session is reset successfully!
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Thank You.</button>
                </div>
            </div>
        </div>
    </div>
    <!--end of session modal-->
     <div class="modal" tabindex="-1" role="dialog" id="errModal" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Session Reset Failed</h5>
                </div>
                <div class="modal-body">
                    <p>
                      Your session is not reset. You will be redirected to the login page.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onserverclick="RemoveSessionBtn_OnClick" runat="server">Okay I got it.</button>
                </div>
            </div>
        </div>
    </div>
    <!--end of session modal-->


    </form>
</asp:Content>
