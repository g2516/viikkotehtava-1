using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teht6_UusiPelaaja : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int nro = 0;
        while (nro < 99)
        {
            nro++;
            ddlNumero.Items.Add(nro.ToString());
        }
    }
    protected void btnLisaaPelaaja_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbEtunimi.Text) && !string.IsNullOrEmpty(tbSukunimi.Text))
        {
            try
            {
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MapPath("~/App_Data/Teht6/SMLiiga.accdb") + ";Persist Security Info=False;");
                OleDbCommand cmd = new OleDbCommand("SELECT MAX(id) FROM Pisteet");
                cmd.Connection = conn;
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int i = reader.GetInt16(0) + 1;
                OleDbConnection cna = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MapPath("~/App_Data/Teht6/SMLiiga.accdb") + ";Persist Security Info=False;");
                OleDbCommand cmds = new OleDbCommand("INSERT INTO Pisteet (id, sukunimi, etunimi, seura, nro, pelipaikka, pisteet) VALUES('" + i + "','" + tbSukunimi.Text + "','" + tbEtunimi.Text + "','" + ddlSeura.SelectedValue + "','" + ddlNumero.SelectedValue + "','" + ddlPelipaikka.SelectedValue + "','" + 0 +"')");
                cmds.Connection = cna;
                cna.Open();
                cmds.ExecuteNonQuery();
            }
            catch
            {
            }
            Response.Redirect("Default.aspx");
        }
        
    }
}