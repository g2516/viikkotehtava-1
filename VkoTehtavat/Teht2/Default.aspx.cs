using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teht2_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Ladataan tarvittavat kentät web.configista ensimmäisellä sivun latauskerralla
        if (String.IsNullOrEmpty((string)Session["firstLoad"]))
        {
            tbIka.Text = ConfigurationManager.AppSettings["ika"];
            tbEuro.Text = ConfigurationManager.AppSettings["palkka"];
            laskeElake();
            Session["firstLoad"] = "loaded";
        }

        // Validoinnit
        try
        {
            int temp = Convert.ToInt32(tbIka.Text);
        }
        catch
        {
            tbIka.Text = "18";
        }
        try
        {
            int temp = Convert.ToInt32(tbEuro.Text);
        }
        catch
        {
            tbEuro.Text = "0";
        }
    }

    protected void btnMiinusIka_Click(object sender, EventArgs e)
    {
        int ika = Convert.ToInt32(tbIka.Text);
        if (ika > 18)
        {
            ika--;
        }
        else
        {
            ika = 18;
        }
        tbIka.Text = ika.ToString();
        laskeElake();
    }

    protected void btnPlusIka_Click(object sender, EventArgs e)
    {
        int ika = Convert.ToInt32(tbIka.Text);
        if (ika < 63)
        {
            ika++;
        }
        else
        {
            ika = 63;
        }
        tbIka.Text = ika.ToString();
        laskeElake();
    }

    protected void btnMiinusEuro_Click(object sender, EventArgs e)
    {
        int palkka = Convert.ToInt32(tbEuro.Text);
        if (palkka > 0)
        {
            palkka--;
        }
        tbEuro.Text = palkka.ToString();
        laskeElake();
    }

    protected void btnPlusEuro_Click(object sender, EventArgs e)
    {
        int palkka = Convert.ToInt32(tbEuro.Text);
        palkka++;
        tbEuro.Text = palkka.ToString();        
        laskeElake();
    }

    protected void btnToinenSivu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Yhteystiedot.aspx");
    }

    // Lasketaan eläkkeet sun muut ja täytetään asiaankuuluvat kentät
    protected void laskeElake()
    {
        double elake = Convert.ToDouble(tbEuro.Text) / 2;
        double vaikutus = ((63 - Convert.ToDouble(tbIka.Text)) * 5.5) * -1;
        double arvio = elake + vaikutus;

        lbElake.Text = elake.ToString();
        lbVaikutus.Text = vaikutus.ToString();
        lbArvio.Text = arvio.ToString();
    }
}