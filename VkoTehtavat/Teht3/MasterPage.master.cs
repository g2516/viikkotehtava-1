using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void MainMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        var response = base.Response;

        switch (e.Item.Value)
        {
            case "Home": response.Redirect("~/Teht3/Home.aspx");
                break;
            case "About": response.Redirect("~/Teht3/About.aspx");
                break;
            case "Leffat": response.Redirect("~/Teht3/Leffat.aspx");
                break;
            case "Contact": response.Redirect("~/Teht3/Contact.aspx");
                break;
            default:
                break;
        }
    }
}
