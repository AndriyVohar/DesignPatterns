using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class OrderProcessor
    {
        public void ProcessOrder(int[][]orderItems)
        {
            OrderingSystem orderingSystem;
            if (orderItems.Length == 1)
            {
                orderingSystem = new UkrainianFoodOrderingSystem();
            } else if (orderItems.Length==2)
            {
                orderingSystem = new SushiOrderingSystem();
            } else
            {
                orderingSystem = new FastFoodOrderingSystem();
            }
            orderingSystem.PlaceOrder(orderItems);
        }
    }
}
