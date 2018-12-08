<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.Master" MaintainScrollPositionOnPostback="true" CodeBehind="Food.aspx.cs" Inherits="WebApplication3.Food" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top:25px">
                <div class="card">
                    <div class="card-header">
                        <h4 class="auto-style1">Food Recommendation</h4>
                    </div>
                    <div class="card-body">
                        <p class="auto-style1">Welcome to our Food database.
                            <br />
                            <br />
                            Here is where all the Foods are registered and how you can select them in the Diet Tracker's page.
                            <br />
                            <br />
                            Help our website by adding your own food reccomendation in the respective text boxes in the table below!
                <br />
                            You can also edit or delete foods and their respective nutritional values if you want.</p>
                        <strong><asp:Label ID="Label1" runat="server" Text="Keywords:"></asp:Label></strong>
                        <div class="input-group mb-3">
                            <asp:TextBox ID="tbSearch" CssClass="form-control" placeholder="Food" runat="server" Width="238px"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="btnSearch" CssClass="btn btn-outline-dark" runat="server" OnClick="btnSearch_Click" Text="Search for Food Item" />
                            </div>
                        </div>
                        <strong>
                            
                            
                            
                            <br />
                            <br />
                        </strong>
                        <asp:GridView ID="gvFood" runat="server" AutoGenerateColumns="False" DataKeyNames="foodID" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvFood_PageIndexChanging"
                            OnRowCommand="gvFood_RowCommand" ShowFooter="true" OnRowEditing="gvFood_RowEditing" OnRowDeleting="gvFood_RowDeleting" OnRowUpdating="gvFood_RowUpdating" OnRowCancelingEdit="gvFood_RowCancelingEdit"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Both" Width="100%" AllowPaging="True" HorizontalAlign="Center" PageSize="15">

                            <FooterStyle BackColor="#333333" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
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
                                        <asp:TextBox ID="txtFoodFooter" runat="server" />
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
                                        <asp:TextBox ID="txtCaloriesFooter" runat="server" />
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
                                        <asp:TextBox ID="txtProteinFooter" runat="server" />
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
                                        <asp:TextBox ID="txtFatFooter" runat="server" />
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
                                        <asp:TextBox ID="txtCarbohydrateFooter" runat="server" />
                                    </FooterTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>

                                        <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="40px" Height="40px" />
                                        <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="40px" Height="40px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/img/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="50px" Height="50px" />
                                        <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="40px" Height="40px" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/img/add.png" runat="server" CommandName="Add" ToolTip="Add" Width="80px" Height="80px" />
                                    </FooterTemplate>

                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                        <p class="auto-style1">
                            <asp:Label ID="LblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                        </p>
                        <p class="auto-style1">
                            <asp:Label ID="LblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
