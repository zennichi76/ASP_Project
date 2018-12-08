<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Diet Tracker Home.aspx.cs" Inherits="WebApplication3.Diet_Tracker_Home" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top:25px">
                <div class="col-lg-12" style="margin:0 auto">
                    <div class="card">
                        <div class="card-header"><h4 class="auto-style6">Diet Tracker </h4></div>
            <div class="card-body">
            <p>This diet tracker below allows you to choose from thousands of foods and brands and see nutrition facts such as calories, fat, protein and carbohydrates. Start by entering your food and drink choices under &quot;Keywords&quot;. After doing so, it will tally all your choices by clicking on the Plus icon next to the item to display a summary of what you have added below. Once you have added your foods that you have eaten, to reset, you can remove the food by clicking on the Dustbin icon.</p>
            <p>
                <strong>
                    <asp:Button ID="btnRedirectFood" runat="server" CssClass="btn btn-info" OnClick="btnRedirectFood_Click" Text="Help us add more foods into our database!" />
                </strong>
            </p>
                <p></p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Keywords:"></asp:Label>
            <div class="input-group mb-3">
                <asp:TextBox ID="tbSearch" placeholder="Food Item" CssClass="form-control" runat="server" Width="238px"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="btnSearch" CssClass="btn btn-outline-dark" runat="server" Text="Search for Food Item" OnClick="btnSearch_Click" />
                </div>
            </div> 
            

            <asp:GridView ID="gvFood" runat="server" AutoGenerateColumns="False" DataKeyNames="foodID" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvFood_PageIndexChanging"
                OnRowCommand="gvFood_RowCommand" AllowPaging="True" CssClass="table table-light" >

                <FooterStyle BackColor="#333333" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" />
                <PagerSettings NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

                <Columns>


                    <asp:BoundField DataField="Food" HeaderText="Food" />
                    <asp:BoundField DataField="Calories" HeaderText="Calories" />
                    <asp:BoundField DataField="Protein" HeaderText="Protein" />
                    <asp:BoundField DataField="Fat" HeaderText="Fat" />
                    <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate" />


                    <asp:ButtonField ItemStyle-CssClass="Add_btn" CommandName="Select"  ControlStyle-Width="40px"  ControlStyle-Height="40px" ImageUrl="img/add.png" ButtonType="Image" />


                </Columns>
            </asp:GridView>
                                        </div>
                        </div>
                </div>
            </div>
            <div class="row" style="margin-top:25px">
                <div class="col-lg-12" style="margin:0 auto">
                    <div class="card">
                <div class="card-header"><h4>Summary</h4></div>
<div class="card-body">
            <asp:GridView ID="gvDietTracker" runat="server" AutoGenerateColumns="False" DataKeyNames="foodID" ShowHeaderWhenEmpty="True"
                OnRowDeleting="gvDietTracker_RowDeleting"
                 CssClass="table table-light" PageSize="15" ShowFooter="True">

                <FooterStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Font-Bold="True" Font-Size="Large" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" Font-Size="Large" />
                <PagerSettings NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

                <Columns>


                    <asp:TemplateField HeaderText="Food">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Food") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFood" Text='<%# Eval("Food") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtFoodFooter" runat="server" />--%>
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Calories">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Calories") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCalories" Text='<%# Eval("Calories") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtCaloriesFooter" runat="server" />--%>
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Protein">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Protein") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProtein" Text='<%# Eval("Protein") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtProteinFooter" runat="server" />--%>
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fat">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Fat") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFat" Text='<%# Eval("Fat") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtFatFooter" runat="server" />--%>
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Carbohydrate">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Carbohydrate") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCarbohydrate" Text='<%# Eval("Carbohydrate") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtCarbohydrateFooter" runat="server" />--%>
                        </FooterTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">

                        <ItemTemplate>

                            <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="40px" Height="40px" />
                        </ItemTemplate>

                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
    <div runat="server" id="calculateDiv">
        <h5>Please enter your target Calories</h5>
        <h6><asp:Label ID="WeightStatusLB" runat="server" ForeColor="Red"></asp:Label></h6>
            <div class="input-group mb-3">
                
                <asp:TextBox ID="targetCaloriesTB" placeholder="Target Calories" CssClass="form-control col-lg-4" runat="server" Width="238px" TextMode="Number"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="calculateBtn" CssClass="btn btn-outline-dark" runat="server" Text="Calculate" OnClick="calculateBtn_Click" />
                </div>
            </div> 
        </div>
            <p></p>
            <asp:Button ID="excelSheetBtn" CssClass="btn btn-outline-dark" runat="server" Text="Export Table to Excel Sheet" OnClick="excelSheetBtn_Click" />
            <p class="auto-style6">
                <asp:Label ID="LblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </p>
            <p class="auto-style6">
                <asp:Label ID="LblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

            </p>
</div>
                </div>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>
