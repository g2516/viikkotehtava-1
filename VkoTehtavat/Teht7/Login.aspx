<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Teht7_Login" Theme="Teht7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tehtävä 7 - Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login</h1>
        Käyttäjätunnus
        <br />
        <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
        <br />
        <br />
        Salasana
        <br />
        <asp:TextBox ID="tbPasswd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLogin" class="myButton" runat="server" Text="Kirjaudu sisään" OnClick="btnLogin_Click" />
        <br />
        <br />
        <asp:Button ID="btnAnonymousLogin" class="myButton" runat="server" Text="Kirjaudu sisään anonyymisti" OnClick="btnAnonymousLogin_Click" />
        <br />
        <br />
        <asp:Label ID="lbError" runat="server" class="error" Text=""></asp:Label>
    </form>
</body>
</html>
