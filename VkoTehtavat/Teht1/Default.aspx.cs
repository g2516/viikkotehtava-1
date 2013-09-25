using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSendParameter_Click(object sender, EventArgs e)
    {
        string s = Server.HtmlEncode(tbName.Text);
        Response.Redirect("Valuuttamuunnin.aspx?user=" + s, false);
    }
    protected void btnSaveSession_Click(object sender, EventArgs e)
    {
        string s = Server.HtmlEncode(tbName.Text);
        Session["userName"] = s;
        Response.Redirect("Valuuttamuunnin.aspx");
    }
    protected void btnSaveCookie_Click(object sender, EventArgs e)
    {
        string s = Server.HtmlEncode(tbName.Text);
        HttpCookie myCookie = new HttpCookie("userNameCookie");
        myCookie.Value = s;
        myCookie.Expires = DateTime.Now.AddMinutes(1); // Yhden minuutin keksi
        Response.Cookies.Add(myCookie);
        Response.Redirect("Valuuttamuunnin.aspx");
    }
}