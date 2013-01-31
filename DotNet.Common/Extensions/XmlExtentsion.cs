using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace System.Xml
{
    public static class XmlExtentsion
    {
        public static string GetAttributeValue(this XmlNode node, string attributeName)
        {
            return node.Attributes[attributeName] == null ? "" : node.Attributes[attributeName].Value;
        }        
    }
}
