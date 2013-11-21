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
            RunOnAll(TestAlgorithm);
            PrintRunSpeeds();
        }

        static void PrintRunSpeeds()
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

            Console.WriteLine(arrayCount + " elements, Max Value: " + max + ", Runs: " + runCount);

            RunOnAll(delegate(SortingAlgorithm sort)
            {
                PrintRunningSpeed(sort, numbers, runCount);
            });
        }

        delegate void AlgorithmDelegate(SortingAlgorithm algo);

        static void RunOnAll(AlgorithmDelegate del)
        {
            del(new SelectionSort());
            del(new InsertionSort());
            del(new QuickSort());
        }

        static void PrintRunningSpeed(SortingAlgorithm sort, int[] numbers, int runCount)
        {
            sort.SetArray(numbers);
            SortingAlgorithm.Result res = sort.Run(runCount);
            res.Divide(numbers.Length);
            Console.Write(sort + ": ");
            Console.WriteLine(res);
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
