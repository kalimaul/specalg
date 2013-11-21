using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specalg_sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arrayCount = 1000;
            const int max = int.MaxValue;
            const int runCount = 1000;

            int[] numbers = new int[arrayCount];
            System.Random rand = new Random();
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = rand.Next() % max;
            }

            SelectionSort sort = new SelectionSort();
            sort.SetArray(numbers);
            SortingAlgorithm.Result res = sort.Run(runCount);
            res.Divide(arrayCount);

            Console.WriteLine(res);

        }
    }
}
