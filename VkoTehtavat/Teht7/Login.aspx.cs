using System;
using System.Web.Security;

public partial class Teht7_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    // Käyttäjän tarkistus
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (FormsAuthentication.Authenticate(tbUser.Text, tbPasswd.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(tbUser.Text, false);
        }
        else
        {
            lbError.Text = "Käyttäjätunnus tai salasana ei täsmää!";
        }
    }
    protected void btnAnonymousLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("NotLoggedIn.aspx");
    }
}