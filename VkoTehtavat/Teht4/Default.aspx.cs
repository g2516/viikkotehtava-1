using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public partial class Teht4_Default : System.Web.UI.Page
{
    #region Käytetyt luokat
    // Serialisointi
    public class Serialisointi
    {
        public static void DeSerialisoiXml(string filePath, ref AutoLista autoja)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(AutoLista));
            try
            {
                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                autoja = (AutoLista)deserializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }

    // Lista autoista
    [Serializable()]
    [XmlRoot("Wanhatautot")]
    public class AutoLista
    {
        public AutoLista()
        {
            Autot = new List<Auto>();
        }

        [XmlElement("Auto")]
        public List<Auto> Autot { get; set; }

    }

    // Auto
    [Serializable()]
    public class Auto
    {
        [XmlElement("merkki")]
        public string Merkki { get; set; }
        [XmlElement("aid")]
        public string Aid { get; set; }
        [XmlElement("rekkari")]
        public string Rekkari { get; set; }
        [XmlElement("malli")]
        public string Malli { get; set; }
        [XmlElement("vm")]
        public int Vm { get; set; }
        [XmlElement("myyntiHinta")]
        public int MyyntiHinta { get; set; }
        [XmlElement("sisaanOstoHinta")]
        public int SOstoHinta { get; set; }

        public Auto()
        {
        }
    }
    #endregion
    
    public List<Auto> Autot { get; set; }
    public string SortExpression
    {
        get
        {
            return (string)ViewState["SortExpression"];
        }
        set
        {
            ViewState["SortExpression"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            initStuff();
        }
        else
        {
            Autot = (List<Auto>)ViewState["AutotLista"];
        }
    }

    private void initStuff()
    {
        try
        {
            AutoLista autot = new AutoLista();
            Serialisointi.DeSerialisoiXml(Server.MapPath("~/teht4/WanhatAutot.xml"), ref autot);
            Random random = new Random();
            List<Auto> satunnaisetAutot = new List<Auto>();

            while (satunnaisetAutot.Count < 4)
            {
                int luku = random.Next(0, autot.Autot.Count - 1);
                if (!satunnaisetAutot.Contains(autot.Autot.ElementAt(luku)))
                {
                    satunnaisetAutot.Add(autot.Autot.ElementAt(luku));
                }
            }
            Autot = autot.Autot;
            ViewState["AutotLista"] = Autot;
            List<string> merkit = new List<string>();
            merkit.Add("Kaikki");

            foreach (Auto auto in autot.Autot)
            {
                string merkki = auto.Merkki;

                if (!merkit.Contains(merkki))
                {
                    merkit.Add(merkki);
                }
            }

            ListBox1.DataSource = merkit;
            ListBox1.DataBind();
            ListBox1.Height = 150;
            SortExpression = "DESC";
            loadListView(satunnaisetAutot);
        }
        catch (Exception ex)
        {
            er.InnerText = ex.Message;
        }
    }

    protected void loadListView(List<Auto> a)
    {
        ViewState["currentAutot"] = a;
        ListView1.DataSource = a;
        ListView1.DataBind();
    }

    public void filterAutot(string merkki)
    {
        List<Auto> results = Autot.FindAll(
             delegate(Auto a)
             {
                 return a.Merkki == merkki;
             });

        loadListView(results);
    }

    protected List<Auto> OrderList(List<Auto> autot)
    {
        if (SortExpression == ("ASC"))
        {
            var inOrder = autot.OrderBy(Auto => Auto.MyyntiHinta).ToList<Auto>();
            autot = inOrder as List<Auto>;
        }
        else
        {
            var inOrder = autot.OrderByDescending(Auto => Auto.MyyntiHinta).ToList<Auto>();
            autot = inOrder as List<Auto>;
        }

        return autot;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        List<Auto> currentAutot = (List<Auto>)ViewState["currentAutot"];

        if (!string.IsNullOrEmpty(SortExpression))
        {
            currentAutot = OrderList(currentAutot);
        }

        loadListView(currentAutot);
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > 0)
        {
            filterAutot(ListBox1.SelectedValue);
        }
        else
        {
            loadListView(Autot);
        }
    }

    protected void ListView1_Sorting(object sender, ListViewSortEventArgs e)
    {
        if (SortExpression == ("ASC"))
        {
            SortExpression = "DESC";
        }
        else
        {
            SortExpression = "ASC";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string haku = TextBox1.Text;
        List<Auto> results = Autot.FindAll(
            delegate(Auto a)
            {
                return a.Merkki.ToLower().Contains(haku.ToLower()) || a.Malli.ToLower().Contains(haku.ToLower());
            }
        );

        loadListView(results);
    }
}