using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MicrowaveOven
{
    public class Loader
    {
        public static void Load()
        {
            if (!File.Exists(Transfer.PATH_OF_SAVES))
                return;

            XDocument xDoc = XDocument.Load(Transfer.PATH_OF_SAVES);
            XElement xContainers = xDoc.Root;
            XElement xMicrowave = xContainers.Element("microwave");
            if (xMicrowave.HasElements)
                foreach(XElement product in xMicrowave.Descendants())
                    Transfer.Microwave.CreateNewProductAndAddInList(product.Attribute("name").Value);

            XElement xTable = xContainers.Element("table");
            if (xTable.HasElements)
                foreach (XElement product in xTable.Descendants())
                    Transfer.Table.CreateNewProductAndAddInList(product.Attribute("name").Value);


        }
    }
}
