<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createTuitionPage.aspx.cs" Inherits="EADP_Project.StudentTutorPage.viewTuitionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
     <script src="js/jquery-3.2.1.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="jsbootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    
    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>
      <script src="js/bootstrap-timepicker.js"></script>
     <script src="js/jquery.datetimepicker.js"></script>
    <script src="js/JavaScript.js"></script>
    <script src="js/jquery.timepicker.min.js" type="text/javascript"></script>

    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />


       <!-- Boostrap DatePicker CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePicker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>`

    <%-- for timepicker --%>
 <link rel="stylesheet" href="../js/jquery.timepicker.min.css" type="text/css" />
 <script src="../js/jquery.timepicker.min.js" type="text/javascript"></script>

<script type="text/javascript">

    $(function () {
        $("#datepicker").datepicker();
    });

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
            <div class="col-md-11 col-sm-11">
                <asp:Panel ID="successpanel" runat="server" CssClass="alert-success text-center" height="50px" Visible="false"> Tuiton Session has been created successfully! </asp:Panel>
 <div class="card ">
  <div class="card-header bg-primary text-white">Create Session</div>
  <div class="card-body">

      <table class="table table-bordered" style="margin-left: 0px">

    <tbody>
      <tr>
        <td>Session Details:
          
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
                 </tbody>
  </table>      
                 
                 </div>
  

  </div> 
  <div class="card-footer">
      <asp:Button ID="createBtn" runat="server" Text="Create" OnClick="createBtn_Click" CssClass="btn btn-info" style="width: 103px" />
      <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="btn btn-danger" style="width: 103px" OnClick="cancelBtn_Click" UseSubmitBehavior="false" />

  </div>
</div> <%--end of card--%>

                 

            </div><%-- end of col lg 11--%>
          


  
    </form>
</body>

    <%-- timepicker --%>
   <link rel="stylesheet" type="text/css" href="../js/jquery.datetimepicker.css"/ >

<script src="../js/jquery.datetimepicker.full.min.js"></script>


</html>
