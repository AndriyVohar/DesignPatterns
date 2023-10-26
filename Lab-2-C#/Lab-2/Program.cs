using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] fastfood = new int[3][];
            fastfood[0] = new int[2] {123,3};
            fastfood[1] = new int[2] {500,1};
            fastfood[2] = new int[2] {42,2};

            int[][] sushi = new int[2][];
            sushi[0] = new int[3] { 123, 500, 42 };
            sushi[1] = new int[3] { 3, 1, 2 };

            int[][]ukrainianfood = new int[1][];
            ukrainianfood[0] = new int[] { 123, 123, 123, 500, 42, 42 };

            var orderProcessor = new OrderProcessor();
            orderProcessor.ProcessOrder(fastfood);
            orderProcessor.ProcessOrder(sushi);
            orderProcessor.ProcessOrder(ukrainianfood);
        }
    }
}
