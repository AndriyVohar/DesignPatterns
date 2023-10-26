using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class FastFoodOrderingSystem:OrderingSystem
    {
        public void PlaceOrder(int[][] orderArray)
        {
            // Логіка обробки замовлення фастфуду
            Console.WriteLine("Вас вітає фастфуд. Ваші замовлення вже готуються, а саме:");
            foreach (int[]element in orderArray)
            {
                Console.WriteLine($"Id: {element[0]}, Кількість: {element[1]}");    
            }
        }
    }
}
