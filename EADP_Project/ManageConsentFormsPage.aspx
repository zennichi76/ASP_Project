<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ManageConsentFormsPage.aspx.cs" Inherits="EADP_Project.ManageConsentFormsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-direction: column;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border-radius: .25rem;
            left: 0px;
            top: 0px;
        }

        .Hide_Item {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 25px; margin-bottom: 25px;">
            <%---Modal Overlay stuffs----%>
            <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="modalOverlay">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align: center; z-index: 11; padding: 50px;">
                    <p>
                        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                    </p>
                    <p>Click on the button to proceed</p>
                    <asp:Button ID="ProceedBtn" runat="server" CssClass="btn btn-light" Text="Proceed" OnClick="Button2_Click" UseSubmitBehavior="False" />
                </div>
            </div>
            <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="confirmationOverlay">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align: center; z-index: 11; padding: 50px;">
                    <p>Are you sure that you want to remove the draft selected?</p>
                    <p></p>
                    <asp:Button ID="YesBtn" runat="server" CssClass="btn btn-light" Text="Yes" UseSubmitBehavior="False" OnClick="YesBtn_Click" />
                    <asp:Button ID="NoBtn" runat="server" CssClass="btn btn-light" Text="No" OnClick="NoBtn_Click" UseSubmitBehavior="False" />
                </div>
            </div>
           <%-- ClassList--%>
            <div runat="server" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 10; background-color: rgba(0,0,0,0.5);" id="classListDiv">
                <div class="content" style="width: 600px; height: 100% auto; position: fixed; top: 50%; left: 50%; margin-top: -350px; margin-left: -350px; background-color: white; border-radius: 5px; text-align: center; z-index: 11; padding: 50px;">
                    <p>Class List</p>
                    <p></p>
                    <asp:DropDownList ID="classesDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="classesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                    <asp:GridView ID="classListGridView" style="margin-top:25px" runat="server" CssClass="table table-sm table-bordered" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="User_ID" HeaderText="NRIC" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="closeClassListBtn" style="margin-top:25px" CssClass="btn btn-outline-dark" runat="server" Text="Close" OnClick="closeClassListBtn_Click" UseSubmitBehavior="False" />
                    
                </div>
            </div>


            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-lg-10">
                                    <asp:Button ID="CreateFormBtn" Style="margin-top: 5px;" CssClass="btn btn-info" runat="server" Text="Create new consent form" OnClick="CreateFormBtn_Click" UseSubmitBehavior="False" />
                                    <asp:Button ID="ManageFormBtn" Style="margin-top: 5px;" runat="server" CssClass="btn btn-info" Text="Manage /Check Consent Forms" OnClick="ManageFormBtn_Click" UseSubmitBehavior="False" />
                                    <asp:Button ID="ManageFormDraftsBtn" Style="margin-top: 5px;" runat="server" CssClass="btn btn-info" Text="Manage Drafts" UseSubmitBehavior="False" OnClick="ManageFormDraftsBtn_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="padding: 25px">
                            <div class="row">
                                <div class="col-lg-10" style="margin: 0 auto;">
                                    <a href="Dashboard.aspx">Return to Dashboard</a>
                                    <div style="margin-top: 25px;">
                                        <h4>
                                            <asp:Label ID="Current_screen_LB" runat="server"></asp:Label></h4>
                                    </div>
                                    <asp:GridView ID="ConsentFormList" CssClass="table table-sm table-bordered table-light table-hover" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="ConsentFormList_PageIndexChanging" PageSize="5" OnRowCommand="ConsentFormList_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="ConsentFormID" HeaderText="FormID" />
                                            <asp:BoundField DataField="Title" HeaderText="Title" />
                                            <asp:BoundField ItemStyle-CssClass="Hide_Item" HeaderStyle-CssClass="Hide_Item" DataField="SenderID" HeaderText="Sender's user ID" >
<HeaderStyle CssClass="Hide_Item"></HeaderStyle>

<ItemStyle CssClass="Hide_Item"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="School" HeaderText="School" />
                                            <asp:BoundField DataField="RecievingClasses" HeaderText="Classes Sent To" />
                                            <asp:BoundField DataField="FoodPreferrence" HeaderText="Food Pref. Enabled" />
                                            <asp:ButtonField CommandName="Select" HeaderText="View Form" Text="View Form" />
                                            <asp:ButtonField CommandName="viewParticipants" HeaderText="View Participants" Text="View Participants" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="formErrorMsg" runat="server"></asp:Label>
                                    <asp:GridView ID="DraftList" CssClass="table table-sm table-bordered table-light table-hover" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanged="DraftList_PageIndexChanged" OnPageIndexChanging="DraftList_PageIndexChanging" OnSelectedIndexChanged="DraftList_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="ConsentFormID" HeaderText="FormID" />
                                            <asp:BoundField DataField="Title" HeaderText="Title" />
                                            <asp:BoundField ItemStyle-CssClass="Hide_Item" HeaderStyle-CssClass="Hide_Item" DataField="SenderID" HeaderText="Sender's user ID">
                                                <HeaderStyle CssClass="Hide_Item"></HeaderStyle>

                                                <ItemStyle CssClass="Hide_Item"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="School" HeaderText="School" />
                                            <asp:BoundField DataField="RecievingClasses" HeaderText="Classes Sent To" />
                                            <asp:BoundField DataField="FoodPreferrence" HeaderText="Food Pref. Enabled" />
                                            <asp:CommandField HeaderText="Edit Draft" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="DraftFormErrorMsg" runat="server"></asp:Label>
                                    <%--<asp:SqlDataSource ID="ConsentFormRecords" runat="server"></asp:SqlDataSource>--%>
                                </div>
                            </div>
                            <div class="row" id="CreateConsentFormDiv" runat="server">
                                <div class="col-lg-10" style="margin: 0 auto">
                                    <p><a href="#" id="classListHyperLink" runat="server" onserverclick="classListHyperLink_ServerClick">View Class List</a></p>
                                    <div class="d-lg-inline-block">
                                        <p>Please select classes to send to</p>
                                        
                                        <asp:ListBox ID="SelectedClassesListBox" Style="width: 15em;" CssClass="list-group" runat="server"></asp:ListBox>
                                        <asp:Button ID="addBtn" Style="margin-top: 5px" CssClass="btn btn-info" runat="server" Text="Add" OnClick="addBtn_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="d-inline-block">
                                        <p>Selected Classes</p>
                                        <asp:ListBox ID="SelectedClassesListBox_Selected" Style="width: 15em;" CssClass="list-group" runat="server"></asp:ListBox>
                                        <asp:Button ID="Button1" Style="margin-top: 5px" CssClass="btn btn-danger" runat="server" Text="Remove" OnClick="Button1_Click" CausesValidation="False" UseSubmitBehavior="False" />

                                    </div>
                                    

                                    <h4>Title</h4>
                                    <asp:TextBox ID="TitleTB" placeholder="-Consent Form Title-" Style="width: 15em; min-width: 15em; max-width: 15em;" CssClass="form-control" runat="server" required></asp:TextBox>
                                    <h4>Consent Form description</h4>
                                    <asp:TextBox ID="DescriptionTB" placeholder="-Consent Form Description-" CssClass="form-control radioButtonList" Style="height: 15em;" runat="server" TextMode="MultiLine" required></asp:TextBox>
                                    <h4>Food Preferrences (Where applicable)</h4>
                                    <asp:CheckBox ID="FoodPreferrences" runat="server" Text="Enable Food Preferrences Option" TextAlign="Left" OnCheckedChanged="FoodPreferrences_CheckedChanged" AutoPostBack="True" />
                                    <div class="card" runat="server" id="foodprefcard">
                                        <div class="card-body" style="padding: 20px;">
                                            <p>Example of having the Food Preferrences Option Turned On</p>
                                            <asp:RadioButtonList ID="FoodRadioButton" runat="server">

                                                <asp:ListItem Selected="True">No Food Preferrence</asp:ListItem>
                                                <asp:ListItem>Vegatarian</asp:ListItem>
                                                <asp:ListItem>No Pork</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>

                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="OthersTB" placeholder="-Others- Please indicate" Style="width: 20em; min-width: 20em; max-width: 20em;" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg-10">
                                            <asp:Button ID="SendFormBtn" Style="margin-top: 20px;" CssClass="btn btn-info" runat="server" Text="Submit and Send Form" OnClick="SendFormBtn_Click" />
                                            <asp:Button ID="SaveDraftBtn" Style="margin-top: 20px; margin-left: 10px" runat="server" CssClass="btn btn-secondary" Text="Save As Draft" CausesValidation="False" OnClick="SaveDraftBtn_Click" />
                                            <asp:Button ID="ClearBtn" Style="margin-top: 20px; margin-left: 10px" runat="server" CssClass="btn btn-danger" Text="Clear" CausesValidation="False" OnClick="ClearBtn_Click" UseSubmitBehavior="False" />


                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row" id="updateFormDiv" runat="server">
                                <div class="col-lg-10" style="margin: 0 auto;">
                                    <h4>Updating Draft Consent Form ( ID no:
                        <asp:Label ID="hiddenFieldID" runat="server"></asp:Label>
                                        )</h4>
                                    <p><a href="#" id="A1" runat="server" onserverclick="classListHyperLink_ServerClick">View Class List</a></p>
                                    <div class="d-lg-inline-block">
                                        <p>Please select classes to send to</p>
                                        <asp:ListBox ID="updateSelectedClassesListBox" Style="width: 15em;" CssClass="list-group" runat="server"></asp:ListBox>
                                        <asp:Button ID="updateAddBtn" Style="margin-top: 5px" CssClass="btn btn-info" runat="server" Text="Add" OnClick="updateAddBtn_Click1" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="d-inline-block">
                                        <p>Selected Classes</p>
                                        <asp:ListBox ID="updateSelectedClassesListBox_Selected" Style="width: 15em;" CssClass="list-group" runat="server"></asp:ListBox>
                                        <asp:Button ID="updateRemoveBtn" Style="margin-top: 5px" CssClass="btn btn-danger" runat="server" Text="Remove" OnClick="updateRemoveBtn_Click1" CausesValidation="False" UseSubmitBehavior="False" />

                                    </div>
                                    <h5>Title</h5>
                                    <asp:TextBox ID="UpdateTitleTB" placeholder="-Consent Form Title-" Style="width: 15em; min-width: 15em; max-width: 15em;" CssClass="form-control" runat="server" required></asp:TextBox>
                                    <h5>Consent Form description</h5>
                                    <asp:TextBox ID="UpdateDescriptionTB" placeholder="-Consent Form Description-" CssClass="form-control radioButtonList" Style="height: 15em;" runat="server" TextMode="MultiLine" required></asp:TextBox>
                                    <h5>Food Preferrences (Where applicable)</h5>
                                    <asp:CheckBox ID="UpdateFoodPreferrences" runat="server" Text="Enable Food Preferrences Option" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="UpdateFoodPreferrences_CheckedChanged" />
                                    <div class="card" runat="server" id="foodprefcardupdate">
                                        <div class="card-body" style="padding: 20px;">
                                            <p>Example of having the Food Preferrences Option Turned On</p>
                                            <asp:RadioButtonList ID="UpdateFoodRadioButton" runat="server">

                                                <asp:ListItem Selected="True">No Food Preferrence</asp:ListItem>
                                                <asp:ListItem>Vegatarian</asp:ListItem>
                                                <asp:ListItem>No Pork</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>

                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="TextBox3" placeholder="-Others- Please indicate" Style="width: 20em; min-width: 20em; max-width: 20em;" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg-10">
                                            <asp:Button ID="sendDraftBtn" Style="margin-top: 20px;" CssClass="btn btn-info" runat="server" Text="Finish Draft and Send" OnClick="sendDraftBtn_Click" />
                                            <asp:Button ID="updateBtn" Style="margin-top: 20px; margin-left: 10px" CssClass="btn btn-secondary" runat="server" Text="Update Draft" OnClick="updateBtn_Click" />
                                            <asp:Button ID="updateClearBtn" Style="margin-top: 20px; margin-left: 10px" runat="server" CssClass="btn btn-danger" Text="Clear" CausesValidation="False" OnClick="updateClearBtn_Click" UseSubmitBehavior="False" />
                                            <asp:Button ID="removeDraftBtn" Style="margin-top: 20px; margin-left: 50px" runat="server" CssClass="btn btn-danger" Text="Remove Draft" CausesValidation="False" UseSubmitBehavior="False" OnClick="removeDraftBtn_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="FormInfoDiv" runat="server">
                                <div class="col-lg-10" style="margin: 0 auto;">
                                    <h4>Title: <asp:Label ID="ViewFormTitleLB" runat="server"></asp:Label></h4>
                                    <h4>Consent Form description</h4>
                                    <asp:TextBox ID="ViewFormDescriptionTB" placeholder="-Consent Form Description-" CssClass="radioButtonList" Style="height: 15em;width:100%" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                     <div class="card" runat="server" id="ViewFormFoodPrefCard">
                                        <div class="card-body" style="padding: 20px;">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">

                                                <asp:ListItem Selected="True">No Food Preferrence</asp:ListItem>
                                                <asp:ListItem>Vegatarian</asp:ListItem>
                                                <asp:ListItem>No Pork</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>

                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="TextBox1" placeholder="-Others- Please indicate" Style="width: 20em; min-width: 20em; max-width: 20em;" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
