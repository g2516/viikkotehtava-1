<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Valuuttamuunnin.aspx.cs" Inherits="Valuuttamuunnin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Valuuttamuunnin</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbName" runat="server" Text="<h1>Tervetuloa:</h1>" />
        <br />
        <asp:TextBox ID="tbUser" runat="server" Text="" Enabled="false"/>
        <br />
        <asp:TextBox ID="tbMonny" runat="server" Text="0" />
        <br />
        <asp:Button ID="btnConvertCurrency" runat="server" Text="Markat euroiksi" OnClick="btnConvertCurrency_Click"/>
        <br />
        <asp:Label ID="lbCounter" runat="server" Text ="Laskutoimituksia: 0" />
    </div>
    </form>
</body>
</html>
