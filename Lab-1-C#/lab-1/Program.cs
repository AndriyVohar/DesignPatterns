using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataLoaderFactory factory = new DataLoaderFactory();
            dynamic loader = factory.CreateLoader("user.json"); // або "meeting.xml"
            dynamic data = loader.LoadFromFile("user.json");
            if (data != null)
            {
                Console.WriteLine(data.ToString());
            }
            else
            {
                Console.WriteLine("Помилка завантаження даних");
            }
            //Console.WriteLine(data.ToString());
        }
    }
}
