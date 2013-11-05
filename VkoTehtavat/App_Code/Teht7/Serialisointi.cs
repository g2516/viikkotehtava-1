using System;
using System.IO;
using System.Xml.Serialization;

public class Serialisointi
{
    // Serialisointi
    public static void SerialisoiXml(string tiedosto, AutoLista autot)
    {
        XmlSerializer xs = new XmlSerializer(autot.GetType());
        TextWriter tw = new StreamWriter(tiedosto);
        try
        {
            xs.Serialize(tw, autot);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            tw.Close();
        }
    }

    // Deserialisointi
    public static void DeSerialisoiXml(string filePath, ref AutoLista autot)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(AutoLista));
        try
        {
            FileStream xmlFile = new FileStream(filePath, FileMode.Open);
            autot = (AutoLista)deserializer.Deserialize(xmlFile);
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