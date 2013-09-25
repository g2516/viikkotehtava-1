<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Teht2_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eläkesäästäminen</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="outerbody">
        
    <form id="form1" runat="server">
        <h2>Tänään on paras päivä aloittaa eläkesäästäminen.</h2>
        <div id="ikkuna">
            <h3>1. Tiedätkö kuinka paljon saat aikanaan eläkettä? Laske tästä!</h3>
            <br />

            Ikä
            <br />
            <asp:Button ID="btnMiinustaIkaa" runat="server" Text="-" OnClick="btnMiinusIka_Click" class="button" />
            <asp:TextBox ID="tbIka" runat="server" Text="" class="textbox" />
            <asp:Button ID="btnLisaaIkaa" runat="server" Text="+" OnClick="btnPlusIka_Click" class="button" />
            vuotta
            <br />

            Palkka
            <br />
            <asp:Button ID="btnMiinustaEuroja" runat="server" Text="-" OnClick="btnMiinusEuro_Click" class="button" />
            <asp:TextBox ID="tbEuro" runat="server" Text="" class="textbox" />
            <asp:Button ID="btnLisaaEuroja" runat="server" Text="+" OnClick="btnPlusEuro_Click" class="button" />
            euroa
            <br />
            <br />
            <br />

            <table cellspacing="0">
                <tr>
                <td>
                    Lakisääteinen eläke: 
                </td>
                <td>
                    <asp:Label ID="lbElake" runat="server" Text="" class="label" />
                </td>
                </tr>
                <tr>
                <td>
                    Elinaikakertoimen vaikutus: 
                </td>
                <td>
                    <asp:Label ID="lbVaikutus" runat="server" Text="" class="label" />
                </td>
                </tr>
                <tr>
                <td>
                    Arvio lakisääteisestä eläkkeestä:
                </td>
                <td>
                    <asp:Label ID="lbArvio" runat="server" Text="" />
                </td>
                </tr>
            </table>
        </div>
        <br />

        <p>2. Riittääkö se sinulle? Paranna toimeentuloasi säästämällä.</p>
        <br />
        <asp:Button ID="btnToinenSivu" runat="server" Text="Lue lisää" OnClick="btnToinenSivu_Click" class="lue" />
        
    </form>
    </div>
</body>
</html>
