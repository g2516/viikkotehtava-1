<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UusiPelaaja.aspx.cs" Inherits="Teht6_UusiPelaaja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teht6: Luo uusi pelaaja</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink id="palaa" Text="Takaisin pelaajalistaan" NavigateUrl="Default.aspx" runat="server" />
        
            <h3>Pelaajan tiedot</h3>
            Etunimi
            <br />
            <asp:TextBox ID="tbEtunimi" runat="server" /> 
            <br />
            Sukunimi
            <br />
            <asp:TextBox ID="tbSukunimi" runat="server" /> 
            <br />
            Numero
            <br />
            <asp:DropDownList ID="ddlNumero" runat="server" AutoPostBack="True"/>
            <br />
            Seura
            <br />
            <asp:DropDownList ID="ddlSeura" runat="server" DataSourceID="SqlDataSource1" DataTextField="seura" AutoPostBack="True" />
            <br />
            Pelipaikka
            <br />
            <asp:DropDownList ID="ddlPelipaikka" runat="server" DataSourceID="SqlDataSource2" DataTextField="pelipaikka" AutoPostBack="True" />
            <br />
            <br />
            <asp:Button ID="btnLisaaPelaaja" runat="server" Text="Uusi Pelaaja" OnClick="btnLisaaPelaaja_Click" />
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" SelectCommand="SELECT DISTINCT [seura] FROM [Pisteet] ORDER BY [seura]" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" SelectCommand="SELECT DISTINCT [pelipaikka] FROM [Pisteet] ORDER BY [pelipaikka]" />

    </form>
</body>
</html>
