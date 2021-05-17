<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInUI.aspx.cs" Inherits="DemoUI.UI.LogInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: aliceblue">
    <form id="form1" runat="server">
        <div style="height: 900px; width: 500px; padding: 90px">
            <asp:Panel ID="PnlAdd" runat="server" CssClass="Panel" GroupingText="Employee Registration" Width="1050px">
                <h2>Employee Registration</h2>

                <table>

                    <tr>
                        <th>User Id: </th>
                        <td>
                            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>Password: </th>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>


                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                        </td>
                    </tr>


                </table>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
