using Lab_2;
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
        public void PlaceOrder(int[][] items)
        {
            Console.WriteLine("Вас вітає фастфуд. Ваші замовлення вже готуються, а саме:");
            for (int i = 0; i < items.GetLength(0); i++)
            {
                Console.WriteLine($"Id: {items[i][0]}, Quantity: {items[i][1]}");
            }
        }
    }

    // Клас для суші
    class SushiOrderSystem
    {
        public void PlaceOrder(int[] codes, int[] quantities)
        {
            Console.WriteLine("Вас вітає сушист. Ваші замовлення вже готуються, а саме:");
            for (int i = 0; i < codes.Length; i++)
            {
                Console.WriteLine($"Id: {codes[i]}, Quantity: {quantities[i]}");
            }
        }
    }

    // Клас для традиційної української кухні
    class UkrainianCuisineOrderSystem
    {
        public void PlaceOrder(int[] codes)
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
        private int[][] convertToFastFood(int[][] array)
        {
            int[][] fastFood = new int[array.GetLength(0)][];
            for(int i = 0; i < array.GetLength(0); i++)
            {
                fastFood[i] = new int[2];
                fastFood[i][0] = array[i][1];
                fastFood[i][1] = array[i][0];

            }
            return fastFood;
        }
        private int[] idSushiOrders(int[][] array)
        {
            int[] idSushi = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                idSushi[i] = array[i][1];
            }
            return idSushi;
        }
        private int[] quantitySushiOrders(int[][] array)
        {
            int[] quantitySushi = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                quantitySushi[i] = array[i][0];
            }
            return quantitySushi;
        }
        private int[] ukrainianOrder(int[][] array)
        {
            int[] oneDimensionalArray = new int[array[0].Length*array.GetLength(0)];
            int currentIndex = 0;
            foreach (var pair in array)
            {
                int code = pair[1];
                int quantity = pair[0];

                for (int i = 0; i < quantity; i++)
                {
                    oneDimensionalArray[currentIndex] = code;
                    currentIndex++;
                }
            }
            return oneDimensionalArray;
        }
        public void PlaceOrder(char foodType, int[][] orderDetails)
        {
            if (foodType == 'a')
            {
                fastFoodOrderSystem.PlaceOrder(convertToFastFood(orderDetails));
            }
            else if (foodType == 'b')
            {
                int[] codes = idSushiOrders(orderDetails);
                int[] quantities = quantitySushiOrders(orderDetails);
                sushiOrderSystem.PlaceOrder(codes, quantities);
            }
            else if (foodType == 'c')
            {
                ukrainianCuisineOrderSystem.PlaceOrder(ukrainianOrder(orderDetails));
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
            int[][] foodList = new int[3][];
            foodList[0] = new int[2] { 3, 123 };
            foodList[1] = new int[2] { 1, 500 };
            foodList[2] = new int[2] { 2, 42 };
            facade.PlaceOrder('a', foodList);
            facade.PlaceOrder('b', foodList);
            facade.PlaceOrder('c', foodList);
        }
    }
}
