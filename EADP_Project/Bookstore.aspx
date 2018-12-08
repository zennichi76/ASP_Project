<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Bookstore.aspx.cs" Inherits="EADP_Project_Education.Bookstore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
    <link href="css/Base.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top:25px">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Bookstore</h4>
                        </div>
                        <div class="card-body">
                            <asp:DropDownList ID="ddl_EduLevel" runat="server" AutoPostBack="True" Height="34px" OnSelectedIndexChanged="ddl_EduLevel_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Education Level--</asp:ListItem>
                                <asp:ListItem Value="0">Any</asp:ListItem>
                                <asp:ListItem Value="1">Primary </asp:ListItem>
                                <asp:ListItem Value="2">Secondary</asp:ListItem>
                                <asp:ListItem Value="3">Junior College</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddl_Sort" runat="server" AutoPostBack="True" Height="34px" OnSelectedIndexChanged="ddl_Sort_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Sort By--</asp:ListItem>
                                <asp:ListItem Value="1">Alphabetical</asp:ListItem>
                                <asp:ListItem Value="2">Price (Low - High)</asp:ListItem>
                                <asp:ListItem Value="3">Price (High - Low)</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddl_ItemType" runat="server" AutoPostBack="True" Height="34px" OnSelectedIndexChanged="ddl_ItemType_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Select Item Type--</asp:ListItem>
                                <asp:ListItem Value="0">Any</asp:ListItem>
                                <asp:ListItem Value="1">Textbooks</asp:ListItem>
                                <asp:ListItem Value="2">Stationary</asp:ListItem>
                                <asp:ListItem Value="3">Files</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TB_Search" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" CssClass="btn btn-outline-dark" Text="Search" />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="375px" style="max-width:800px;width:100%" AllowPaging="True" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" ItemStyle-Width="100px" SelectText="Add to Cart">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Preview" ReadOnly="True" SortExpression="ImageURL" ControlStyle-Height="100px" ControlStyle-Width="100px" ItemStyle-Width="110px">
                                        <ControlStyle Height="100px" Width="100px"></ControlStyle>

                                        <ItemStyle Width="110px"></ItemStyle>
                                    </asp:ImageField>
                                    <asp:BoundField DataField="NAME" HeaderText="Title" SortExpression="NAME" />
                                    <asp:BoundField DataField="PRICE" HeaderText="Price" SortExpression="PRICE" />
                                </Columns>
                                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#330099" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                <SortedDescendingHeaderStyle BackColor="#7E0000" />
                            </asp:GridView>
                            <asp:Panel ID="PanelQuantity" runat="server" Visible="False">
                                <p>You have chosen: <asp:Label ID="lbl_Item" runat="server" Font-Bold="True"></asp:Label></p>
                
                                How many would you like to buy:
                                <div class="row"><div class="col-lg-8"><div class="input-group mb-3">
                            <asp:TextBox ID="TB_Quantity" CssClass="form-control" runat="server" placeholder="Quantity"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="btn_AddCart" runat="server" CssClass="btn btn-outline-dark" OnClick="btn_AddCart_Click" Text="Add to Cart" />
                            </div>
                        </div></div></div>
                                
                
                                

                                <asp:Label ID="lbl_Error" runat="server" ForeColor="Red" Text="Sorry, there is not enough stock left for your required quantity" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_Success" runat="server" ForeColor="#00CC00" Text="Successfully added to shopping cart" Visible="False"></asp:Label>
                            </asp:Panel>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Products.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ImageURL], [NAME], [PRICE] FROM [Products]"></asp:SqlDataSource>
                        </div>
                        <div class="card-footer">
                            <asp:HyperLink ID="HL_StaffCorner" runat="server" NavigateUrl="~/StaffCorner.aspx">Staff Corner</asp:HyperLink>

                            <asp:HyperLink ID="HL_ShoppingCart" runat="server" NavigateUrl="~/Shopping Cart.aspx">Shopping Cart</asp:HyperLink>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
