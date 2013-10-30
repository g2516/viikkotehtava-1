using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teht6_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnKaikki_Click(object sender, EventArgs e)
    {
        gwPelaajat.DataSourceID = "SqlDataSource1";
        gwPelaajat.DataBind();
    }

    protected void ListBox1_TextChanged(object sender, EventArgs e)
    {
        gwPelaajat.DataSourceID = "SqlDataSource2";
        gwPelaajat.DataBind();
    }
    protected void ListBox2_TextChanged(object sender, EventArgs e)
    {
        gwPelaajat.DataSourceID = "SqlDataSource3";
        gwPelaajat.DataBind();

    }
}