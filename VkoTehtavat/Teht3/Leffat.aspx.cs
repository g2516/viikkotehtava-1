using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Leffat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Create DOM Document and load XML data
            XmlDocument dom = new XmlDocument();
            dom.Load(Server.MapPath("~/Teht3/Elokuvat.xml"));

            // Initialize TreeView
            puu.Nodes.Clear();
            puu.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
            TreeNode td = new TreeNode();
            td = puu.Nodes[0];

            // Populate TreeViw with DOM nodes
            AddNode(dom.DocumentElement, td);
            puu.CollapseAll();
        }
        catch
        {
        }
    }

    private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
    {
        XmlNode xNode;
        TreeNode tNode;
        XmlNodeList nodeList;
        int i;

        // Loop through the XML nodes until the leaf is reached.
        // Add the nodes to the TreeView during the looping process.
        if (inXmlNode.HasChildNodes)
        {
            nodeList = inXmlNode.ChildNodes;
            for (i = 0; i <= nodeList.Count - 1; i++)
            {
                xNode = inXmlNode.ChildNodes[i];
                inTreeNode.ChildNodes.Add(new TreeNode(xNode.Name));
                tNode = inTreeNode.ChildNodes[i];
                AddNode(xNode, tNode);
            }
        }
        else
        {
            // Here you need to pull the data from the XmlNode based on the
            // type of node, whether attribute values are required, and so forth.
            inTreeNode.Text = (inXmlNode.OuterXml).Trim();
        }
    }          
}