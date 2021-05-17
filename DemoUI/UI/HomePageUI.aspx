<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageUI.aspx.cs" Inherits="DemoUI.UI.HomePageUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" />
                    </td>
                </tr>

                <tr>
                    <td style="width: 800px; height: 220px;">
                        <div style="width: 1000px; height: 200px; overflow: scroll;" class="gridBorder">
                            <asp:GridView ID="gvShowAll" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvShowAll_RowDeleting" OnSelectedIndexChanged="gvShowAll_SelectedIndexChanged">
                                <HeaderStyle BackColor="LightSteelBlue" BorderColor="SteelBlue" BorderStyle="Solid"
                                    BorderWidth="1px" VerticalAlign="Top" />
                                <SelectedRowStyle BackColor="#FFE0C0" />
                                <AlternatingRowStyle BackColor="WhiteSmoke" />
                                <Columns>
                                    <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id">
                                        <HeaderStyle CssClass="fixedHeader" Width="100px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle CssClass="fixedHeader" Width="100px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Position" HeaderText="Position">
                                        <HeaderStyle CssClass="fixedHeader" Width="100px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Age" HeaderText="Age">
                                        <HeaderStyle CssClass="fixedHeader" Width="100px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Salary" HeaderText="Salary">
                                        <HeaderStyle CssClass="fixedHeader" Width="100px" />
                                    </asp:BoundField>


                                    <asp:CommandField HeaderText="EDIT" SelectText="Edit" ShowSelectButton="True">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="DELETE" DeleteText="Remove" />
                                </Columns>
                                <RowStyle BorderColor="#FF8080" BorderStyle="Solid" BorderWidth="1px" />
                                <PagerStyle CssClass="fixedPager" />
                            </asp:GridView>


                            <asp:HiddenField ID="LstxtHideMemoRowId" runat="server" />
                            <asp:HiddenField ID="lshideselectindex" runat="server" />
                        </div>
                    </td>
                </tr>

                



                
            </table>
        </div>

        <div>
            <tr>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="Add Employee" OnClick="BtnAdd_Click" />
                    </td>

                </tr>
        </div>
    </form>
</body>
</html>
