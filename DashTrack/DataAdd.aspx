<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DataAdd.aspx.vb" Inherits="DashTrack.DataAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DashTrack</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Add Weeks Income"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Add Gas Expense"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Add Data To Database" />
            <asp:Button ID="Button2" runat="server" PostBackUrl="~/MainPage.aspx" Text="Back To Main Page" />
        </div>
    </form>
</body>
</html>
