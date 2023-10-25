using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_1
{
    internal class XmlLoader
    {
        public dynamic LoadFromFile(string file)
        {
            try
            {
                XDocument xml = XDocument.Load(file);
                XElement root = xml.Root;

                dynamic data = new { };

                if (root.Element("date") != null)
                {
                    data.date = root.Element("date").Value;
                    data.description = root.Element("description").Value;
                    data.url = root.Element("url").Value;

                    List<string> participants = root.Elements("participant").Select(p => p.Value).ToList();
                    data.participants = participants;
                }
                else if (root.Element("id") != null)
                {
                    data.id = root.Element("id").Value;
                    data.name = root.Element("name").Value;
                    data.avatar = root.Element("avatar").Value;
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading XML data: " + ex.Message);
                return null;
            }
        }
    }
}
