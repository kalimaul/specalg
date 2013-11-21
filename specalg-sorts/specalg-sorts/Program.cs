using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace specalg_sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAlgorithms();

            const int arrayCount = 1000;
            const int max = int.MaxValue;
            const int runCount = 1000;

            int[] numbers = new int[arrayCount];
            System.Random rand = new Random();
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = rand.Next() % max;
            }

            //Helpers.PrintArray(numbers);

            SortingAlgorithm sort = new QuickSort();
            sort.SetArray(numbers);
            SortingAlgorithm.Result res = sort.Run(runCount);
            res.Divide(arrayCount);

            /*
            {
                int[] result = sort.GetResults()[0];
                Helpers.PrintArray(result);
            }*/

            Console.WriteLine(res);
        }

        static void TestAlgorithms()
        {
            TestAlgorithm(new SelectionSort());
            TestAlgorithm(new QuickSort());
        }

        static void TestAlgorithm(SortingAlgorithm sort)
        {
            const int count = 10000;
            int[] numbers = new int[count];
            System.Random rand = new Random();
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = rand.Next();
            }

            sort.SetArray(numbers);
            sort.RunOnce();
            int[] result = sort.GetResults()[0];
            Debug.Assert(result.Length == numbers.Length);

            Array.Sort(numbers);

            bool match = true;
            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] != result[i])
                {
                    match = false;
                    break;
                }
            }

            Debug.Assert(match);
        }
    }
}
