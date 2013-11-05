using System.Collections.Generic;
using System.Linq;
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
    public static void TallennaAutot(AutoLista autot)
    {
        Serialisointi.SerialisoiXml(HttpContext.Current.Server.MapPath("~/App_Data/Teht7/WanhatAutot.xml"), autot);
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
}