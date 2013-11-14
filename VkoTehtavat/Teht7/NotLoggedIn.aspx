<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotLoggedIn.aspx.cs" Inherits="Teht7_NotLoggedIn" Theme="Teht7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tehtävä 7</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
    <h1>Autokauppias Jinta-Rouppi</h1>
    <h2>(Anonymous user)</h2>
    <br />
    <asp:GridView ID="autoNakyma" runat="server" AllowSorting="True" AllowPaging="True" OnSorting="autoNakyma_Sort" 
        OnPageIndexChanging="autoNakyma_PageIndexChange" PageSize="20" Width="350px"/>
    </div>
    </form>
</body>
</html>
