using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_2
{
    // Клас для фастфуду
    class FastFoodOrderSystem
    {
        public void PlaceOrder(List<Tuple<int, int>> items)
        {
            Console.WriteLine("Вас вітає фастфуд. Ваші замовлення вже готуються, а саме:");
            foreach(var item in items)
            {
                Console.WriteLine($"Id: {item.Item1}, Quantity: {item.Item2}");
            }
        }
    }

    // Клас для суші
    class SushiOrderSystem
    {
        public void PlaceOrder(List<int> codes, List<int> quantities)
        {
            Console.WriteLine("Вас вітає сушист. Ваші замовлення вже готуються, а саме:");
            for (int i = 0; i < codes.Count; i++)
            {
                Console.WriteLine($"Id: {codes[i]}, Quantity: {quantities[i]}");
            }
        }
    }

    // Клас для традиційної української кухні
    class UkrainianCuisineOrderSystem
    {
        public void PlaceOrder(List<int> codes)
        {
            HashSet<int> uniqueValues = new HashSet<int>(codes);
            Console.WriteLine("Вас вітає ресторан української їжі. Ваші замовлення вже готуються, а саме:");
            foreach (var element in uniqueValues)
            {
                Console.WriteLine($"Id: {element}, Quantity: {codes.Count(item => item == element)}");
            }
        }
    }

    //Фасад
    class FoodDeliveryFacade
    {
        private FastFoodOrderSystem fastFoodOrderSystem;
        private SushiOrderSystem sushiOrderSystem;
        private UkrainianCuisineOrderSystem ukrainianCuisineOrderSystem;

        public FoodDeliveryFacade()
        {
            fastFoodOrderSystem = new FastFoodOrderSystem();
            sushiOrderSystem = new SushiOrderSystem();
            ukrainianCuisineOrderSystem = new UkrainianCuisineOrderSystem();
        }

        public void PlaceOrder(char foodType, object orderDetails)
        {
            if (foodType == 'a' && orderDetails is List<Tuple<int, int>> fastFoodOrder)
            {
                fastFoodOrderSystem.PlaceOrder(fastFoodOrder);
            }
            else if (foodType == 'b' && orderDetails is List<List<int>> sushiOrder)
            {
                var codes = sushiOrder[0];
                var quantities = sushiOrder[1];
                sushiOrderSystem.PlaceOrder(codes, quantities);
            }
            else if (foodType == 'c' && orderDetails is List<int> ukrainianCuisineOrder)
            {
                ukrainianCuisineOrderSystem.PlaceOrder(ukrainianCuisineOrder);
            }
            else
            {
                Console.WriteLine("Непідтримуваний тип їжі або некоректні дані.");
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            var facade = new FoodDeliveryFacade();
            facade.PlaceOrder('a', new List<Tuple<int, int>> { Tuple.Create(123, 3), Tuple.Create(500, 1), Tuple.Create(42, 2) });
            facade.PlaceOrder('b', new List<List<int>> { new List<int> { 123, 500, 42 }, new List<int> { 3, 1, 2 } });
            facade.PlaceOrder('c', new List<int> { 123, 123, 123, 500, 42, 42 });
        }
    }
}
