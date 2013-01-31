using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DotNet.Common.Extensions
{
    public static class XmlNodeExtension
    {
        public static string GetXmlNodeAttValue(this XmlNode node, string attrName)
        {
            return node.Attributes[attrName] == null ? "" : node.Attributes[attrName].Value;
        }
    }
}
