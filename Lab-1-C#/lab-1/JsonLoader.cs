using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;

namespace lab_1
{
    internal class JsonLoader
    {
        public dynamic LoadFromFile(string file)
        {
            try
            {
                string json = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading JSON data: " + ex.Message);
                return null;
            }
        }
    }
}
