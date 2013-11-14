using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class BLAutot
{
    public BLAutot()
    {

    }

    // Haetaan tiedot xml tiedostosta
    public static List<Auto> LataaAutot()
    {
        AutoLista autot = new AutoLista();
        List<Auto> autoLista = new List<Auto>();

        Serialisointi.DeSerialisoiXml(HttpContext.Current.Server.MapPath("~/App_Data/Teht7/WanhatAutot.xml"), ref autot);

        for (int i = 0; i < autot.Autot.Count; i++)
        {
            autoLista.Add(autot.Autot[i]);
        }

        return autoLista;
    }

    // Tallenetaan muutokset xml tiedostoon
    public static void TallennaAutot(List<Auto> autoLista)
    {
        AutoLista lista = new AutoLista();
        foreach (Auto item in autoLista)
        {
            lista.Autot.Add(item);
        }
        Serialisointi.SerialisoiXml(HttpContext.Current.Server.MapPath("~/App_Data/Teht7/WanhatAutot.xml"), lista);
    }

    // Listaus
    public static List<Auto> SortList(List<Auto> autoLista, string GridViewSortExpression, string SortDirection)
    {
        if (autoLista != null)
        {
            if (GridViewSortExpression != string.Empty)
            {
                if (SortDirection == "ASC")
                {
                    autoLista = autoLista.OrderBy
                        (a => a.GetType().GetProperty(GridViewSortExpression)
                            .GetValue(a, null)).ToList();
                }
                else
                {
                    autoLista = autoLista.OrderByDescending
                        (a => a.GetType().GetProperty(GridViewSortExpression)
                            .GetValue(a, null)).ToList();
                }
            }
            return autoLista;
        }
        else
        {
            return autoLista;
        }
    }

    // Käyttäjän autentikointi
    public static bool AuthenticateUser(string username, string password)
    {
        // Haetaan käyttäjät xml-tiedostosta
        UserLista users = new UserLista();
        Serialisointi.DeSerialisoiKayttajat(HttpContext.Current.Server.MapPath("~/App_Data/Teht7/Users.xml"), ref users);

        // Suolaus
        byte[] saltBytes = Encoding.UTF8.GetBytes("suolaa");
        byte[] saltedHashBytesUserName = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(username));
        byte[] saltedHashBytesPassword = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(password));
        string saltedHashStringUserName = Convert.ToBase64String(saltedHashBytesUserName);
        string saltedHashStringPassword = Convert.ToBase64String(saltedHashBytesPassword);

        // Tarkistetaan käyttäjät
        for (int i = 0; i < users.users.Count; i++)
        {
            if (saltedHashStringUserName == users.users[i].UserName && saltedHashStringPassword == users.users[i].Password)
            {
                return true;
            }
        }
        return false;
    }
}