using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExampleForAddOn_VisualStudio
{
    class XMLFormatterHelper
    {
        public static string Format(string text)
        {
            XmlDocument xmlDoc = new XmlDocument();

            using (MemoryStream ms = new MemoryStream())
            {
                xmlDoc.LoadXml(text);
                using (XmlTextWriter writer = new XmlTextWriter(ms, Encoding.Unicode))
                {
                    // format content
                    writer.Formatting = Formatting.Indented;
                    xmlDoc.WriteContentTo(writer);
                    writer.Flush();
                    ms.Position = 0; 

                    StreamReader sr = new StreamReader(ms);
                    string formatted = sr.ReadToEnd();
                    Debug.Print(formatted);
                    return formatted;
                }
            }
        }
    }
}
