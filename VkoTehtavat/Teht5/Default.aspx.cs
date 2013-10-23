using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

public partial class Teht5_Default : System.Web.UI.Page
{
#region Käytetyt luokat
    public class Serialisointi
    {
        public static void DeSerialisoiXml(string filePath, ref Records records)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Records));
            try
            {

                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                records = (Records)deserializer.Deserialize(xmlFile);
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
    [Serializable()]
    [XmlRoot("Records")]
    public class Records
    {
        public Records()
        {
            genre = new Genre();

        }

        [XmlElement("genre")]
        public Genre genre { get; set; }

    }

    [Serializable()]
    public class Genre
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlElement("record")]
        public List<Record> Records { get; set; }
        public Genre()
        {
            Records = new List<Record>();
        }
    }

    [Serializable()]
    public class Record
    {
        [XmlAttribute("ISBN")]
        public string ISBN { get; set; }
        [XmlAttribute("Artist")]
        public string Artist { get; set; }
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Price")]
        public Double Price { get; set; }
        [XmlElement("song")]
        public List<Song> Songs { get; set; }

        public string ArtistTitle
        {
            get
            {
                return Artist + " : " + Title;
            }
            set { ArtistTitle = value; }
        }
        public string Kuva
        {
            get
            {
                return "Images/" + ISBN + ".jpg";
            }
            set { Kuva = value; }
        }
        public Record()
        {
            Songs = new List<Song>();
        }
    }


    [Serializable()]
    public class Song
    {
        [XmlAttribute("num")]
        public int Num { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        public Song()
        {
        }
    }
#endregion

    public List<Record> Albumit { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            initStuff();
        }
        else
        {
            Albumit = (List<Record>)ViewState["Records"];
        }
    }

    private void initStuff()
    {
        try
        {
            Records records = new Records();
            Serialisointi.DeSerialisoiXml(Server.MapPath("~/Teht5/LevykauppaX.xml"), ref records);
            Albumit = records.genre.Records;
            ViewState["Records"] = Albumit;
            loadListWiew(Albumit);
        }
        catch (Exception ex)
        {
            er.InnerText = ex.Message;
        }
    }

    protected void loadListWiew(List<Record> r)
    {
        ViewState["currentRecords"] = r;
        ListView1.DataSource = r;
        ListView1.DataBind();
    }

    protected void OpenAlbum_Click(object sender, EventArgs e)
    {
        LinkButton button = sender as LinkButton;
        string isbn = button.CommandArgument;
        ListView1.DataSource = null;
        ListView1.DataBind();
        List<Record> record = Albumit.FindAll(
        delegate(Record r) { return r.ISBN == isbn; });
        ListView2.DataSource = record;
        ListView2.DataBind();
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        ListView2.DataSource = null;
        ListView2.DataBind();
        loadListWiew(Albumit);
    }
}