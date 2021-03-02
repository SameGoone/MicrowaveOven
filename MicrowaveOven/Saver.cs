using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MicrowaveOven
{
    public class Saver
    {
        public static void Save()
        {
            XDocument xDoc = new XDocument();
            XElement xMicrowave = new XElement("microwave");
            foreach (Product product in Transfer.Microwave.GetProductList())
            {
                XElement xProduct = new XElement("product");
                XAttribute ProductNameAttribute = new XAttribute("name", product.Name);
                xProduct.Add(ProductNameAttribute);
                xMicrowave.Add(xProduct);
            }

            XElement xTable = new XElement("table");
            foreach (Product product in Transfer.Table.GetProductList())
            {
                XElement xProduct = new XElement("product");
                XAttribute ProductNameAttribute = new XAttribute("name", product.Name);
                xProduct.Add(ProductNameAttribute);
                xTable.Add(xProduct);
            }

            XElement xContainers = new XElement("containers");
            xContainers.Add(xMicrowave, xTable);

            xDoc.Add(xContainers);
            xDoc.Save(Transfer.PATH_OF_SAVES);
        }
    }
}
