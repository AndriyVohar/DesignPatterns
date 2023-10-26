using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class UkrainianFoodOrderingSystem : OrderingSystem
    {
        public void PlaceOrder(int[][] orderArray)
        {
            HashSet<int> uniqueValues = new HashSet<int>(orderArray[0]);
            Console.WriteLine("Вас вітає ресторан української їжі. Ваші замовлення вже готуються, а саме:");
            foreach (var element in uniqueValues)
            {
                Console.WriteLine($"Id: {element}, Кількість: {orderArray.Count(item => item[0] == element)}");
            }
        }
    }
}
