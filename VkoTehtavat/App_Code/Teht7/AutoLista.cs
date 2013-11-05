using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable()]
[XmlRoot("Wanhatautot")]
public class AutoLista
{
    [XmlElement("Auto")]
    public List<Auto> Autot { get; set; }

    public AutoLista()
    {
        Autot = new List<Auto>();
    }
}