using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Valuuttamuunnin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("userNameCookie");
        myCookie = Request.Cookies["userNameCookie"];

        if (!String.IsNullOrEmpty(Request.QueryString["user"]))
        {
            tbUser.Text = Request.QueryString["user"];
        }
        else if (!String.IsNullOrEmpty((string)Session["userName"]))
        {
            tbUser.Text = (string)Session["userName"];
        }
        else if (myCookie != null && !String.IsNullOrEmpty(myCookie.Value))
        {
            tbUser.Text = myCookie.Value;
        }

    }

    protected void btnConvertCurrency_Click(object sender, EventArgs e)
    {
        double div = 5.94573;
        double euros = Convert.ToDouble(tbMonny.Text) / div;
        tbMonny.Text = euros.ToString();

        if (Session["counter"] != null)
        {
            Session["counter"] = (int)Session["counter"] + 1;
        }
        else
        {
            Session["counter"] = 1;
        }
        lbCounter.Text = "Laskutoimituksia: " + Session["counter"];
    }
}