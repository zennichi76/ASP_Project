<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback ="true" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StudyGuide.aspx.cs" Inherits="EADP_Project_Education.StudyGuide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 283px;
        }
        .auto-style2 {
            width: 285px;
        }
        .auto-style3 {
            width: 133px;
        }
        .auto-style4 {
            width: 250px;
        }
        .auto-style5 {
            width: 1523px;
        }
        .auto-style6 {
            width: 456px;
        }
        .auto-style7 {
            width: 177px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-lg-12" style="margin-top:25px">
                <div class="card">
                    <div class="card-header">
                        <h4>Study Planner</h4>
                    </div>
                    <div class="card-body">
               
    <p class="auto-style5">
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Study Guides"></asp:Label>
    </p>
        <p class="auto-style5">
            <asp:GridView ID="GridViewGuides" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridViewGuides_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="GuideTitle" HeaderText="GuideTitle" SortExpression="GuideTitle" />
                    <asp:BoundField DataField="GuideURL" HeaderText="GuideURL" SortExpression="GuideURL" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\applicationData.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [GuideURL], [GuideTitle] FROM [StudyGuides]"></asp:SqlDataSource>
    </p>
        <p class="auto-style5">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Size="XX-Large" Text="Study Planner"></asp:Label>
    </p>
        <asp:Panel ID="PanelEntry" runat="server">
            <table class="w-100">
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject1" runat="server">English</asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score1" runat="server">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject2" runat="server">Maths</asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score2" runat="server">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject3" runat="server">Science</asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score3" runat="server">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject4" runat="server">Mother Tongue</asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score4" runat="server">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject0" runat="server" OnClick="ButtonAddSubject0_Click" Text="Add Another Subject" Width="235px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject5" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score5" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject1" runat="server" OnClick="ButtonAddSubject1_Click" Text="Add Another Subject" Visible="False" Width="235px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonRemoveSubject1" runat="server" OnClick="ButtonRemoveSubject1_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject6" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score6" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject2" runat="server" OnClick="ButtonAddSubject2_Click" Text="Add Another Subject" Visible="False" Width="235px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonRemoveSubject2" runat="server" OnClick="ButtonRemoveSubject2_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject7" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score7" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject3" runat="server" OnClick="ButtonAddSubject3_Click" Text="Add Another Subject" Visible="False" Width="235px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonRemoveSubject3" runat="server" OnClick="ButtonRemoveSubject3_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject8" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score8" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject4" runat="server" OnClick="ButtonAddSubject4_Click" Text="Add Another Subject" Visible="False" Width="235px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonRemoveSubject4" runat="server" OnClick="ButtonRemoveSubject4_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject9" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score9" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonAddSubject5" runat="server" OnClick="ButtonAddSubject5_Click" Text="Add Another Subject" Visible="False" Width="235px" />
                    </td>
                    <td>
                        <asp:Button ID="ButtonRemoveSubject5" runat="server" OnClick="ButtonRemoveSubject5_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TB_Subject10" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddl_Score10" runat="server" Visible="False">
                            <asp:ListItem Value="-1">-Grade-</asp:ListItem>
                            <asp:ListItem Value="0">A</asp:ListItem>
                            <asp:ListItem Value="2">B+</asp:ListItem>
                            <asp:ListItem Value="3">B</asp:ListItem>
                            <asp:ListItem Value="4">C+</asp:ListItem>
                            <asp:ListItem Value="5">C</asp:ListItem>
                            <asp:ListItem>D+</asp:ListItem>
                            <asp:ListItem Value="7">D</asp:ListItem>
                            <asp:ListItem Value="8">E</asp:ListItem>
                            <asp:ListItem Value="9">F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonRemoveSubject6" runat="server" OnClick="ButtonRemoveSubject6_Click" Text="Remove Subject" Visible="False" Width="235px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table class="w-100">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lbl_Error1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_Error2" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Button ID="btn_Generate" runat="server" OnClick="btn_Generate_Click" Text="Generate Personal Schedule" ToolTip="Generate based on recent result" Width="304px" />
                    </td>
                    <td class="auto-style18">
                        <asp:Button ID="btn_Reset" runat="server" OnClick="btn_Reset_Click" Text="Reset" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanelSchedule" runat="server" Height="476px" Visible="False">
            <asp:Label ID="LabelHeader" runat="server" Text="Recommended Schedule" Font-Bold="True"></asp:Label>
            <table class="w-100">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject1" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_TotalHours" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject2" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_notice" runat="server" Font-Bold="True">You may check the boxes once you have completed the allocated hours for the week</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject3" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject4" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox2" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject5" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox3" runat="server" Visible="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox4" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject6" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox5" runat="server" Visible="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox6" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject7" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox7" runat="server" Visible="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox8" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject8" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox9" runat="server" Visible="False" />
                        &nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox10" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject9" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btn_weekDone" runat="server" OnClick="btn_weekDone_Click" Text="Week Completed" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lbl_Subject10" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Button ID="btn_redoEntry" runat="server" OnClick="redoEntry_Click" Text="Redo Entry" />
            <br />
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="auto-style2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
                     </div>
                    </div>
            </div>
        </div>
            </div>
</form>
</asp:Content>
