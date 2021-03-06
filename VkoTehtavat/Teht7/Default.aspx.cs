﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teht7_Default : System.Web.UI.Page
{
    // Validointikriteerit
    Regex regexNum = new Regex(@"[\d]");
    Regex regexAlph = new Regex(@"^[a-zA-Z0-9]+$");
    Regex regexRek = new Regex(@"^[A-Z]{3}-[0-9]{3}$");
    
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

    // Metodit lisäykselle, editoimiselle, tuhoamiselle, etc...
    protected void autoNakyma_PageIndexChange(object sender, GridViewPageEventArgs e)
    {
        autoNakyma.PageIndex = e.NewPageIndex;
        toGridView(autoLista);
    }

    protected void autoNakyma_RowEdit(object sender, GridViewEditEventArgs e)
    {
        autoNakyma.EditIndex = e.NewEditIndex;
        toGridView(autoLista);
    }

    protected void autoNakyma_RowCancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        autoNakyma.EditIndex = -1;
        toGridView(autoLista);
        lbVirhe.Text = "";
    }

    // Update & validointi
    protected void autoNakyma_RowUpdate(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = autoNakyma.Rows[e.RowIndex];
        try
        {
            if (!regexAlph.IsMatch(((TextBox)(row.Cells[1].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[1].Controls[0])).Text))
            {
                lbVirhe.Text = "Merkki hyväksyy vain kirjaimia ja numeroita!";
            }
            else if (!regexAlph.IsMatch(((TextBox)(row.Cells[2].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[2].Controls[0])).Text))
            {
                lbVirhe.Text = "Aid hyväksyy vain kirjaimia ja numeroita!";
            }
            else if (!regexRek.IsMatch(((TextBox)(row.Cells[3].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[3].Controls[0])).Text))
            {
                lbVirhe.Text = "Syötä rekisterinumero muodossa ABC-123!";
            }
            else if (!regexAlph.IsMatch(((TextBox)(row.Cells[4].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[4].Controls[0])).Text))
            {
                lbVirhe.Text = "Malli hyväksyy vain kirjaimia ja numeroita!";
            }
            else if (!regexNum.IsMatch(((TextBox)(row.Cells[5].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[5].Controls[0])).Text))
            {
                lbVirhe.Text = "Vuosimalli hyväksyy vain numeroita!";
            }
            else if (!regexNum.IsMatch(((TextBox)(row.Cells[6].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[6].Controls[0])).Text))
            {
                lbVirhe.Text = "Myyntihinta hyväksyy vain numeroita!";
            }
            else if (!regexNum.IsMatch(((TextBox)(row.Cells[7].Controls[0])).Text) || string.IsNullOrEmpty(((TextBox)(row.Cells[7].Controls[0])).Text))
            {
                lbVirhe.Text = "SOstohinta hyväksyy vain numeroita!";
            }
            else
            {
                autoLista[e.RowIndex].Merkki = ((TextBox)(row.Cells[1].Controls[0])).Text;
                autoLista[e.RowIndex].Aid = ((TextBox)(row.Cells[2].Controls[0])).Text;
                autoLista[e.RowIndex].Rekkari = ((TextBox)(row.Cells[3].Controls[0])).Text;
                autoLista[e.RowIndex].Malli = ((TextBox)(row.Cells[4].Controls[0])).Text;
                autoLista[e.RowIndex].Vm = int.Parse(((TextBox)(row.Cells[5].Controls[0])).Text);
                autoLista[e.RowIndex].MyyntiHinta = int.Parse(((TextBox)(row.Cells[6].Controls[0])).Text);
                autoLista[e.RowIndex].SOstoHinta = int.Parse(((TextBox)(row.Cells[7].Controls[0])).Text);
                autoNakyma.EditIndex = -1;
                toGridView(autoLista);
                lbVirhe.Text = "";
            }
        }
        catch
        {
        }
    }

    protected void autoNakyma_RowDelete(object sender, GridViewDeleteEventArgs e)
    {
        autoLista.RemoveAt(e.RowIndex);
        toGridView(autoLista);
    }
    
    // Napit
    protected void addNew_Click(object sender, EventArgs e)
    {
        autoLista.Add(new Auto());
        autoLista = BLAutot.SortList(autoLista, "Malli", "ASC");
        autoNakyma.EditIndex = 0;
        toGridView(autoLista);
    }

    protected void saveToFile_Click(object sender, EventArgs e)
    {
        BLAutot.TallennaAutot(autoLista);
    }
}