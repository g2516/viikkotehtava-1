<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Default</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Nimesi, kiitos
        <asp:TextBox ID="tbName" runat="server" />
        <br />
        <asp:Button ID="btnSendParameter" runat="server" Text="Välitä parametrina" OnClick="btnSendParameter_Click"/>
        <asp:Button ID="btnSaveSession" runat="server" Text="Tallenna Session" OnClick="btnSaveSession_Click" />
        <asp:Button ID="btnSaveCookie" runat="server" Text="Tallenna Cookie" OnClick="btnSaveCookie_Click" />
    </div>
    </form>
</body>
</html>
