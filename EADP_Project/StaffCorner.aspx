<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StaffCorner.aspx.cs" Inherits="EADP_Project_Education.StaffCorner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 156px;
        }
        .auto-style2 {
            width: 152px;
        }
        .auto-style3 {
            width: 155px;
        }
        .auto-style4 {
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top:25px;">
                <div class="col-lg-12">
                    <div class="auto-style4">
                        <div class="card-header">
                            <h4>Staff Corner</h4>
                        </div>
                        <div class="card-body" style="padding-bottom:100px">
                            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                                &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Welcome Fellow Staff Members" Font-Size="XX-Large"></asp:Label>
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Bookstore.aspx">Back to Bookstore</asp:HyperLink>
                            <div style="margin: 0 auto; text-align: center;">
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add Product" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update Product" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonDelete" runat="server" Text="Delete Product" OnClick="ButtonDelete_Click" />
                                &nbsp;&nbsp;&nbsp;
        <br />
                                <br />
                                <br />
                            </div>
                            <asp:Panel ID="PanelCreate" runat="server" Visible="False">
                                &nbsp;&nbsp;<asp:Label ID="lbl_Add" runat="server" Font-Bold="True" Font-Italic="False" Text="Add Product"></asp:Label>
                                <br />
                                &nbsp;<asp:FileUpload ID="FileUploadImage" runat="server" accept=".png,.jpg,.jpeg" />
                                <asp:Label ID="lbl_Image_Name" runat="server" Visible="False"></asp:Label>
                                <br />
                                <table class="w-100">
                                    <tr>
                                        <td class="auto-style1">&nbsp; Product ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                        <td>
                                            <asp:TextBox ID="TB_ID_Add" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp; Product Name :&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="TB_Name_Add" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">&nbsp; Product Price&nbsp;&nbsp; :&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="TB_Price_Add" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;
            <asp:DropDownList ID="Ddl_Edu_Add" runat="server">
                <asp:ListItem Value="-1">~Education Level~</asp:ListItem>
                <asp:ListItem Value="0">Any</asp:ListItem>
                <asp:ListItem Value="1">Primary</asp:ListItem>
                <asp:ListItem Value="2">Secondary</asp:ListItem>
                <asp:ListItem Value="3">Junior College</asp:ListItem>
            </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Ddl_Item_Add" runat="server">
                <asp:ListItem Value="-1">~Item Type~</asp:ListItem>
                <asp:ListItem Value="1">Files</asp:ListItem>
                <asp:ListItem Value="2">Stationary</asp:ListItem>
                <asp:ListItem Value="3">Textbooks</asp:ListItem>
            </asp:DropDownList>
                                &nbsp;&nbsp;
            <asp:Label ID="lbl_Any" runat="server" Text="Any" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_AnyType" runat="server" Text="Any" Visible="False"></asp:Label>
                                <br />
                                &nbsp;
            <table class="w-100">
                <tr>
                    <td class="auto-style2">&nbsp; Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                    <td>
                        <asp:TextBox ID="TB_Quantity_Add" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
                                <br />
                                &nbsp;
            <asp:Label ID="lbl_Message" runat="server" ForeColor="#00CC00" Visible="False"></asp:Label>
                                <br />
                                &nbsp;&nbsp;<asp:TextBox ID="TB_Error_Add" runat="server" ForeColor="Red" Height="101px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="436px"></asp:TextBox>
                                <br />
                                &nbsp;
            <asp:Button ID="btn_Submit_Add" runat="server" OnClick="btn_Submit_Add_Click" Text="Submit" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Clear_Add" runat="server" OnClick="btn_Clear_Click" Text="Clear" Width="84px" />
                                <br />
                            </asp:Panel>
                            <asp:Panel ID="PanelUpdate" runat="server" Visible="False">
                                &nbsp;
            <asp:Label ID="lbl_Update" runat="server" Font-Bold="True" Font-Italic="False" Text="Update Product"></asp:Label>
                                <br />
                                &nbsp;<asp:FileUpload ID="FileUploadImage_Update" runat="server" Visible="False" />
                                <asp:Label ID="lbl_Image_Name1" runat="server" Visible="False"></asp:Label>
                                <asp:Button ID="btn_image_change_update" runat="server" Height="42px" OnClick="btn_image_change_update_Click" Text="Change Image" Width="170px" />
                                <asp:Button ID="btn_image_cancel_update" runat="server" Height="42px" OnClick="btn_image_cancel_update_Click" Text="Cancel Change" Visible="False" Width="170px" />
                                <br />
                                <table class="w-100">
                                    <tr>
                                        <td class="auto-style3">&nbsp; Product ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                        <td>
                                            <asp:TextBox ID="TB_ID_Update" runat="server"></asp:TextBox>
                                            &nbsp;
                        <asp:Button ID="btn_ID_search" runat="server" Height="42px" OnClick="btn_ID_search_Click" Text="Search" Width="99px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp; Product Name :</td>
                                        <td>
                                            <asp:TextBox ID="TB_Name_Update" runat="server" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">&nbsp; Product Price&nbsp;&nbsp; :&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="TB_Price_Update" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Ddl_Edu_Update" runat="server">
                                    <asp:ListItem Value="-1">~Education Level~</asp:ListItem>
                                    <asp:ListItem>Any</asp:ListItem>
                                    <asp:ListItem Value="1">Primary</asp:ListItem>
                                    <asp:ListItem Value="2">Secondary</asp:ListItem>
                                    <asp:ListItem Value="3">Junior College</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Ddl_Item_Update" runat="server">
                <asp:ListItem Value="-1">~Item Type~</asp:ListItem>
                <asp:ListItem Value="1">Files</asp:ListItem>
                <asp:ListItem Value="2">Stationary</asp:ListItem>
                <asp:ListItem Value="3">Textbooks</asp:ListItem>
            </asp:DropDownList>
                                <table class="w-100">
                                    <tr>
                                        <td class="auto-style7">&nbsp; Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                        <td>
                                            <asp:TextBox ID="TB_Quantity_Update" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                &nbsp;
            <asp:Label ID="lbl_Message1" runat="server" Visible="False" ForeColor="#00CC00"></asp:Label>
                                <br />
                                &nbsp;<asp:TextBox ID="TB_Error_Update" runat="server" Height="101px" ReadOnly="True" TextMode="MultiLine" Visible="False" Width="436px" ForeColor="Red"></asp:TextBox>
                                <br />
                                &nbsp;
            <asp:Button ID="btn_Submit_Update" runat="server" OnClick="btn_Submit_Update_Click" Text="Submit" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Clear_Update" runat="server" OnClick="btn_Clear_Click" Text="Clear" Width="84px" />
                                <br />
                            </asp:Panel>
                            <asp:Panel ID="PanelDelete" runat="server" Visible="False" Height="115px">
                                &nbsp;&nbsp;
            <asp:Label ID="lbl_Delete" runat="server" Font-Bold="True" Font-Italic="False" Text="Delete Product"></asp:Label>
                                <table class="w-100">
                                    <tr>
                                        <td class="auto-style3">&nbsp; Product ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                                        <td>
                                            <asp:TextBox ID="TB_ID_Delete" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;<br />
                                &nbsp;
            &nbsp;<asp:Label ID="lbl_Message2" runat="server" ForeColor="#00CC00" Visible="False"></asp:Label>
                                &nbsp;&nbsp;
            <br />
                                &nbsp;
            <asp:TextBox ID="TB_Error_Delete" runat="server" Visible="False" Width="424px" ForeColor="Red"></asp:TextBox>
                                <br />
                                &nbsp;
            <asp:Button ID="btn_Delete" runat="server" OnClientClick="if (!confirm('Do you want to delete this product?')) return false;" OnClick="btn_Delete_Click" Text="Delete" />
                                <br />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
