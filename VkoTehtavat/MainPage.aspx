<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
    <div>
        <h1>Viikkotehtävät</h1>
        <h3>Petri Matilainen G2516 [IIO11S1]</h3>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
    <div>
        <asp:HyperLink id="teht1" Text="Tehtävä 1" NavigateUrl="~/Teht1/Default.aspx" runat="server" />
        <br />
        <asp:HyperLink id="teht2" Text="Tehtävä 2" NavigateUrl="~/Teht2/Default.aspx" runat="server" />
        <br />
        <br />
        <asp:HyperLink id="teht3" Text="Tehtävä 3" NavigateUrl="~/Teht3/Home.aspx" runat="server" />
        <br />
        <br />
        <asp:HyperLink id="teht4" Text="Tehtävä 4" NavigateUrl="~/Teht4/Default.aspx" runat="server" />
        <br />
        <asp:HyperLink id="teht5" Text="Tehtävä 5" NavigateUrl="~/Teht5/Default.aspx" runat="server" />
        <br />
        <br />
        <asp:HyperLink id="teht6" Text="Tehtävä 6" NavigateUrl="~/Teht6/Default.aspx" runat="server" />
        <br />
        <br />
    </div>
</asp:Content>

