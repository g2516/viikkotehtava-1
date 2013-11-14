using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teht7_NotLoggedIn : System.Web.UI.Page
{
    // Auto-lista ja sen sorttaus
    List<Auto> autoLista = new List<Auto>();
    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string GridViewSortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }

    private string GetSortDirection()
    {
        switch (GridViewSortDirection)
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;
            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    protected void autoNakyma_Sort(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        toGridView(BLAutot.SortList(autoLista, GridViewSortExpression, GetSortDirection()));
    }

    // Sivun lataus
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            initStuff();
        }
        else
        {
            autoLista = (List<Auto>)ViewState["autoLista"];
        }
    }

    protected void initStuff()
    {
        autoLista = BLAutot.LataaAutot();
        toGridView(autoLista);
    }

    // Bindataan lista gridiin
    protected void toGridView(List<Auto> autoLista)
    {
        ViewState["autoLista"] = autoLista;

        autoNakyma.DataSource = autoLista;
        autoNakyma.DataBind();
    }

    protected void autoNakyma_PageIndexChange(object sender, GridViewPageEventArgs e)
    {
        autoNakyma.PageIndex = e.NewPageIndex;
        toGridView(autoLista);
    }

}