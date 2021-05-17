<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegistrationUI.aspx.cs" Inherits="DemoUI.EmployeeRegistrationUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Employee Registration</h1>

            <table>

                <tr>
                    <th>Name: </th>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                   </td>
                </tr>

                <tr>
                    <th>Position: </th>
                    <td>
                        <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                   </td>
                </tr>

                <tr>
                    <th>Age: </th>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                   </td>
                </tr>

                <tr>
                    <th>Salary: </th>
                    <td>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                   </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                   </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnHome" runat="server" Text="<Back Home Page" OnClick="btnHome_Click" />
                   </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
