<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback ="true" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Shopping Cart.aspx.cs" Inherits="EADP_Project_Education.Shopping_Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style2 {
            width: 771px;
        }
        .auto-style4 {
            width: 195px;
        }

        .auto-style5 {
            width: 180px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-lg-12" style="margin-top:25px">
                <div class="card">
                    <div class="card-header"><h4>Welcome to your Shopping Cart</h4></div>
                    <div class="card-body">

        <p>
            <asp:HyperLink ID="HyperBookstore" runat="server" NavigateUrl="~/Bookstore.aspx">Back to Bookstore</asp:HyperLink>
        </p>
        <asp:Panel ID="PanelCartDisplay" runat="server" >
            <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewCart_SelectedIndexChanged" HorizontalAlign="NotSet">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField HeaderText="Delete From Cart" SelectText="Delete From Cart" ShowSelectButton="True"/>
                    <asp:ImageField ControlStyle-Height="100px" ControlStyle-Width="100px" DataImageUrlField="ImageURL" HeaderText="Preview" ItemStyle-Width="110px" ReadOnly="True">
                        <ControlStyle Height="100px" Width="100px" />
                        <ItemStyle Width="110px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="NAME" HeaderText="Title" ReadOnly="True" SortExpression="NAME" />
                    <asp:BoundField DataField="PRICE" HeaderText="Price" ReadOnly="True" SortExpression="PRICE" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" SortExpression="Quantity" />
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
            <br />
            
            <asp:Button ID="btn_pay" runat="server"  OnClick="btn_pay_Click" Text="Proceed to transaction" />
        </asp:Panel>
        <asp:Panel ID="PanelPaymentSelection" runat="server" Visible="False" style="margin-top:25px">
            &nbsp;&nbsp; Select your choice of payment:<br /> &nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="-1">~Select One~</asp:ListItem>
                <asp:ListItem Value="1">Credit/Debit Card</asp:ListItem>
                <asp:ListItem Value="2">Cash on collection</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
        <asp:Panel ID="Panel_Entry" runat="server" Visible="False">
            <asp:Label ID="LabelCardTitle" runat="server" Font-Bold="True" Text="Credit/Debit Card Credentials"></asp:Label>
            <table class="w-100">
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelCardNum" runat="server" Font-Bold="True" Text="Card Number:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_CardNum" runat="server" placeholder="Omit dashes" AutoPostBack="True" ForeColor="Black" maxlength="16" OnTextChanged="TB_CardNum_TextChanged"></asp:TextBox>
                        &nbsp;
                        <asp:Image ID="ImageCardType" runat="server" Height="32px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelCardCVV" runat="server" Font-Bold="True" Text="CVV:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_CardCVV" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelCardDate" runat="server" Font-Bold="True" Text="Expiry Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_CardDate" runat="server" placeholder="MM/YY" ToolTip="MM/YY" maxlength="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelCardName" runat="server" Font-Bold="True" Text="Name on Card:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_CardName" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="TB_ErrorCard" runat="server" ForeColor="Red" Height="112px" TextMode="MultiLine" Visible="False" Width="664px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_Proceed" runat="server" OnClick="btn_Proceed_Click" Text="Submit" />
        </asp:Panel>
        <asp:Panel ID="Panel_Cash" runat="server" Visible="False" Height="288px" ForeColor="Black">
            <asp:Label ID="LabelReceiptTitle" runat="server" Font-Bold="True" Text="Receipt"></asp:Label>
            <table class="w-100">
                <tr>
                    <td class="auto-style5">Receipt Number:</td>
                    <td>
                        <asp:Label ID="lbl_ReceiptNum" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Purchased Items:</td>
                    <td>
                        <asp:Label ID="lbl_ItemList" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Total Cost:</td>
                    <td>
                        <asp:Label ID="lbl_Cost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Purchase Date:</td>
                    <td>
                        <asp:Label ID="lbl_PurchaseDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="Please present this slip to the counter upon collection of items either in hard or soft copy form."></asp:Label>
            <br />
            <asp:Button ID="btn_Done" runat="server" OnClick="btn_Done_Click" Text="Done" />
        </asp:Panel>
        <br />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
