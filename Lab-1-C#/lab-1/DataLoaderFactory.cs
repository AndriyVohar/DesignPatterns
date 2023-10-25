using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace lab_1
{
    internal class DataLoaderFactory
    {
        public dynamic CreateLoader(string file)
        {
            string fileType = Path.GetExtension(file).TrimStart('.').ToLower();

            if (fileType == "json")
            {
                return new JsonLoader();
            }
            else if (fileType == "xml")
            {
                return new XmlLoader();
            }
            else
            {
                throw new ArgumentException("Unsupported file format");
            }
        }
    }
}
