using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class SushiOrderingSystem : OrderingSystem
    {
        public void PlaceOrder(int[][] orderArray)
        {
            // Логіка обробки замовлення фастфуду
            Console.WriteLine("Вас вітає сушист. Ваші замовлення вже готуються, а саме:");
            for(int i = 0; i < orderArray[0].Length; i++)
            {
                Console.WriteLine($"Id: {orderArray[0][i]}, Кількість: {orderArray[1][i]}");
            }
        }
    }
}
