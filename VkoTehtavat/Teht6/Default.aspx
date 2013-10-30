<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Teht6_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Valitse pelaajat seuran tai pelipaikan mukaan</h3>
            <asp:Button ID="btnKaikki" runat="server" Text="Valitse kaikki" Width="350px" OnClick="btnKaikki_Click" />
            <br />
            <asp:ListBox ID="lbSeurat" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="seura" DataValueField="seura" Width="175px" OnTextChanged="ListBox1_TextChanged" />
            <asp:ListBox ID="lbPelipaikat" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource5" DataTextField="pelipaikka" DataValueField="pelipaikka" Width="175px" OnTextChanged="ListBox2_TextChanged" />
        </div>
        
        <asp:GridView ID="gwPelaajat" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="350px">
            <Columns>
                <asp:BoundField DataField="nro" HeaderText="nro" SortExpression="nro" />
                <asp:BoundField DataField="sukunimi" HeaderText="sukunimi" SortExpression="sukunimi" />
                <asp:BoundField DataField="etunimi" HeaderText="etunimi" SortExpression="etunimi" />
                <asp:BoundField DataField="seura" HeaderText="seura" SortExpression="seura" />
                <asp:BoundField DataField="pelipaikka" HeaderText="pelipaikka" SortExpression="pelipaikka" />
                <asp:BoundField DataField="pisteet" HeaderText="pisteet" SortExpression="pisteet" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" 
            SelectCommand="SELECT DISTINCT * FROM [Pisteet] ORDER BY [sukunimi]">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" 
            SelectCommand="SELECT DISTINCT * FROM [Pisteet] WHERE [seura] = ? ORDER BY [sukunimi]">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbSeurat" PropertyName="SelectedValue" Name="seura" Type="String" DefaultValue=""/>
            </SelectParameters>        
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" 
            SelectCommand="SELECT DISTINCT * FROM [Pisteet] WHERE [pelipaikka] = ? ORDER BY [sukunimi]">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbPelipaikat" PropertyName="SelectedValue" Name="pelipaikka" Type="String" DefaultValue=""/>
            </SelectParameters>        
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" SelectCommand="SELECT DISTINCT [seura] FROM [Pisteet] ORDER BY [seura]" />
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" SelectCommand="SELECT DISTINCT [pelipaikka] FROM [Pisteet] ORDER BY [pelipaikka]" />
    </form>
</body>
</html>
