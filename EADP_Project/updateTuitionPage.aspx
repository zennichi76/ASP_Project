<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTuitionPage.aspx.cs" Inherits="EADP_Project.StudentTutorPage.updateTuitionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="js/jquery-3.2.1.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />

      <!-- Boostrap DatePicker CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePicker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>


     <link rel="stylesheet" type="text/css" href="css/jquery.datetimepicker.css" />
    <script src="js/timepicker-1.3.5/jquery.timepicker.js"></script>
    <link rel="stylesheet" href="js/timepicker-1.3.5/jquery.timepicker.css" />  

    <%-- for timepicker --%>
       <script src="js/bootstrap-timepicker.js"></script>
     <script src="js/jquery.datetimepicker.js"></script>
    <link rel="stylesheet" href="js/jquery.datetimepicker.css" />  
    <script src="js/JavaScript.js"></script>
    <script src="js/jquery.timepicker.min.js" type="text/javascript"></script>


    <script type="text/javascript">

        $(document).ready(function () {
            var dp = $('#<%=sessionSDateTB.ClientID%>');
            dp.datepicker({
                autoclose: true,
                todayHighlight: true,
                changeMonth: true,
                changeYear: true,
                format: "dd-M-yyyy",
                //format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });

        $(document).ready(function () {
            var dp = $('#<%=sessionSTimeTB.ClientID%>');
            dp.timepicker({
                timeFormat: 'h:mm p',
                interval: 60,
                minTime: '6',
                maxTime: '2359',
                dynamic: false,
                dropdown: true,
                scrollbar: true
            });
        });
        $(document).ready(function () {
            var dp = $('#<%=sessionETimeTB.ClientID%>');
            dp.timepicker({
                timeFormat: 'h:mm p',
                interval: 60,
                minTime: '6',
                maxTime: '2359',
                dynamic: false,
                dropdown: true,
                scrollbar: true
            });
        });

        //for confirmination

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to leave? Once you leave, your input data won't be save!")) {
                confirm_value.value = "Yes";
            } else {

            }
            document.forms[0].appendChild(confirm_value);
        }

     
        </script>
        <style type="text/css">
        
 .boxsizingBorder {
    -webkit-box-sizing: border-box;
       -moz-box-sizing: border-box;
            box-sizing: border-box;
}

        .input-group-addon {
  border-left-width: 0;
  border-right-width: 0;
}
.input-group-addon:first-child {
  border-left-width: 1px;
}
.input-group-addon:last-child {
  border-right-width: 1px;
}

    </style>
</head>




<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
        
                <div class="col-lg-12 col-md-12 col-sm-12 ">

                    <asp:Panel ID="successpanel" runat="server" Visible="False" CssClass="alert-success text-center" Height="80px" > Session has been updated successfully</asp:Panel>


                    <div class="card">
                        <div class="card bg-primary text-white card-outline-primary">Edit Session</div>



                        <div class="card-body">


                         <table class="table table-bordered" style="margin-left: 0px">

    <tbody>
      <tr>
        <td>Session Details:
           <%-- <asp:TextBox ID="sessionDetailsTB" runat="server" CssClass="form-control" type="text" ></asp:TextBox>--%>
             <asp:TextBox ID="sessionDetailsTB" runat="server" CssClass="form-control" type="text" Rows="4" TextMode="MultiLine" required></asp:TextBox>
        </td>
       
      </tr>
      <tr>
             <td>
                 <div class="row">
                         <div class="col-4">
            Start Date:<asp:Label ID="sdateErrLbl" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
&nbsp;<asp:TextBox ID="sessionSDateTB" runat="server" CssClass="form-control"  required></asp:TextBox>
                         </div>
                     </div>
            </td>
          </tr>
        <tr>
            <td>
                         <div class="row form-inline">
                         <div class="col-3 form-inline">
            Start Time:<asp:Label ID="timeErrLbl" runat="server" Text="" ForeColor="Red" Visible ="false"></asp:Label>
&nbsp; <asp:TextBox ID="sessionSTimeTB" runat="server" CssClass="form-control" required></asp:TextBox>
                             </div>
                             <div class="col-3">
 End Time:<asp:TextBox ID="sessionETimeTB" runat="server" CssClass="form-control" required></asp:TextBox>
                         </div>
                     </div>

            </td>
        </tr>
        <tr>
            <td>
                Status:
                 <asp:DropDownList ID="statusDDL" runat="server" CssClass="form-control-sm" AutoPostBack="True">
                                    <asp:ListItem>Ongoing</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>Canceled</asp:ListItem>
                                   </asp:DropDownList> 
            </td>
        </tr>
                 </tbody>
  </table>      

                        </div>
                        <%--end of card body--%>
                        <div class="card-footer bg-light text-dark">

                            <asp:Button ID="updateBtn" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="updateBtn_Click" />

                            <asp:Button ID="cancelBtn" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="cancelBtn_Click" UseSubmitBehavior="false" OnClientClick="Confirm()" />





                        </div>

                        

                    </div>
                    <%--end of card--%>

                  

                </div>
                <%--end of col-12--%>
            </div>
            <%--end of row--%>
        </div>
        <%--end of container--%>


    </form>
</body>

        <%-- timepicker --%>
   <link rel="stylesheet" type="text/css" href="js/jquery.datetimepicker.css"/ >

<script src="js/jquery.datetimepicker.full.min.js"></script>

</html>
