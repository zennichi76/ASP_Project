<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEventPage.aspx.cs" Inherits="EADP_Project.EventPage.CreateEventPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">


      <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon"> 
    <script src="js/moment.js"></script>
    <script src="js/moment.min.js"></script>

    <script src="js/jquery-3.2.1.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/jquery-3.2.1.slim.js"></script>
    <script src="js/jquery-3.2.1.slim.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>

   <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.min.css">

    
   

    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
  

       <!-- Boostrap DatePicker CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePciker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    
    <!--time picker -->
 <link rel="stylesheet" href="js/jquery.timepicker.min.css" type="text/css" />
 <script src="js/jquery.timepicker.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        var date = new Date();
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());

        $(document).ready(function () {
            var dp = $('#<%=txtStartDate.ClientID%>');
         dp.datepicker({
             autoclose: true,
             todayHighlight: true,
             changeMonth: true,
             changeYear: true,
             format: "dd-M-yyyy",
             //format: "dd.mm.yyyy",
             language: "tr",
             minDate: today,
             

         }).on('changeDate', function (ev) {
             $(this).blur();
             $(this).datepicker('hide');
         });
        });

        $(document).ready(function () {
            var dp = $('#<%=STimeTB.ClientID%>');
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
            var dp = $('#<%=ETimeTB.ClientID%>');
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
           var dp = $('#<%=txtEndDate.ClientID%>');
     
            dp.datepicker({
                autoclose: true,
                todayHighlight: true,

                changeMonth: true,
                changeYear: true,
                format: "dd-M-yyyy",
                language: "tr",
                minDate: function () {
                    return $('#txtStartDate').val();
                }
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        })





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

                function ConfirmClear() {
                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    if (confirm("Are you sure you want to clear everything? All your input will be gone!")) {
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
    <%--&nbsp;--%>
</head>

<body>
    <form id="form1" runat="server" class="form-vertical">
         <asp:Panel ID="successPanel" runat="server" Visible="false">
            <div class="alert alert-success">
                <strong>Success!</strong> You have successfully created an event!
            </div>
    </asp:Panel>
        <asp:Panel ID="createPanel" runat="server" Visible="true">
             <div class="container">
         <div class="col-xs-12 col-md-12 ">
             <div class="card">
                 <div class="card-header">
                     <div class="row"><asp:Button ID="BackBtn" runat="server" Text="Back" CssClass="btn btn-danger" UseSubmitBehavior="False" OnClick="BackBtn_Click1" OnClientClick="Confirm()"
                        /> &nbsp; <h4>Create Event </h4></div>
                     </div>
               
  <div class="card-body">     
      <div class="row"> 
           <asp:Label ID="eventNameErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
          Event Name:
           <asp:TextBox ID="eventNameTB" runat="server" CssClass="form-control" type="text" required></asp:TextBox>
         
      </div>
      <div class="row">
                   <asp:Label ID="dateErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
          Start Date - End Date: 
                  </div>
      <div class="row">
    <div class="input-group">
              <asp:TextBox ID="txtStartDate" ClientIDMode="Static" runat="server" CssClass="form-control" required Width="150px" Height="35px" ></asp:TextBox>
          
        <div class="input-group-addon">To</div>
  
              <asp:TextBox ID="txtEndDate" ClientIDMode="Static" runat="server" CssClass="form-control" Height="35px" Width="150px" required ></asp:TextBox>  
         
    </div>

          </div>


      <div class="row">
           <asp:Label ID="timeErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
          Start Time - End Time: 
          </div>
      <div class="row">
           <div class="input-group">
               <asp:TextBox ID="STimeTB" runat="server" Height="35px" Width="150px"  CssClass="form-control" required ></asp:TextBox>

                     <span class="input-group-addon" style="border-left: 0; border-right: 0;"> &nbsp To &nbsp; </span>
   <asp:TextBox ID="ETimeTB" runat="server"  Height="35px"  Width="150px" CssClass="form-control" required ></asp:TextBox>
   
    </div>
          </div>
        
        
        <br/>

      <div class="row">
          <asp:Label ID="descErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
          Description: 
       <textarea class="form-control" rows="4"  id="eventDescTB" name="eventDesc" required ></textarea> 
          
      </div>
        <br/>

      <div class="row">
         
          <div class="input-group"> 
              <asp:Label ID="mcErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
              <asp:Label ID="Label2" runat="server" Text="Max Capacity:"></asp:Label>
            <asp:TextBox ID="maxCapTB" runat="server" type="number" CssClass="form-inline form-control" Width="100px" required></asp:TextBox> 
               
       <asp:Label ID="errCpLbl" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
               <asp:Label ID="Label3" runat="server" Text="CCA Points:"></asp:Label>
               <asp:TextBox ID="ccaPointsTB" runat="server" CssClass="form-inline form-control" type="number" Width="100px" required></asp:TextBox>
              <asp:Label ID="opErr" runat="server" Text="*" ForeColor="Red" Visible="False"></asp:Label>
         <asp:Label ID="Label1" runat="server" Text="Orion Points:"> 
               </asp:Label>
             
 <asp:TextBox ID="orionPointsTB" runat="server" CssClass="form-inline form-control" type="number" Width="100px" required></asp:TextBox>
          
      </div>

             </div>
       
 
      

  </div>

</div>
             <%--end of card--%>
     <div class="card-footer text-muted bg-light ">
  <asp:Button ID="createBtn" runat="server" Text="Create Event" CssClass="btn btn-primary" OnClick="createBtn_Click1" />
            <asp:Button ID="clearBtn" runat="server" Text="Clear" CssClass="btn btn-danger" OnClick="clearBtn_Click" UseSubmitBehavior="False" OnClientClick="ConfirmClear()"  />
  </div>
             </div>
                    </div> 

        <%--end of container--%>
        </asp:Panel>
   
       

        <asp:Panel ID="errorPanel" runat="server" Visible="false">
            <div class="alert alert-danger">
                
                  <asp:Label ID="cpErrLbl" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
                  <asp:Label ID="OpErrLbl" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
                <asp:Label ID="errLblMax" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="errTLbl" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;
                <asp:Label ID="errLbl" runat="server" ForeColor="Red"></asp:Label>
            </div>
    </asp:Panel>

    
        




      </form>
    
    
</body>


    
   
</html>
