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
            //new MainForm().ShowDialog();
            PrintRunSpeeds();
            //SmallArrayCountRace();
        }

        static void SmallArrayCountRace()
        {
            const int runCount = 10000;
            const int qsWinRequirement = 20;

            int arrayCount = 1;

            string qsname = typeof(QuickSort).Name;
            string rqsname = /*typeof(RandomQSort).Name*/"nonde";
            int quickSortWins = 0;

            while (arrayCount < 1000)
            {
                int[] numbers = new int[arrayCount];
                Helpers.FillArrayWithRandomData(numbers, int.MaxValue);

                Dictionary<SortingAlgorithm.Result, string> results = new Dictionary<SortingAlgorithm.Result, string>();

                RunOnAll(delegate(SortingAlgorithm sort)
                {
                    results.Add(sort.SetArray(numbers).Run(runCount), sort.GetType().Name);
                });

                List<SortingAlgorithm.Result> resList = new List<SortingAlgorithm.Result>(results.Keys);
                resList.Sort((t1, t2) => (t1.accessCount.CompareTo(t2.accessCount)));
                string accessCountWinner = results[resList[0]];

                resList.Sort((t1, t2) => (t1.innerIterationCount.CompareTo(t2.innerIterationCount)));
                string iterationWinner = results[resList[0]];

                resList.Sort((t1, t2) => (t1.elapsedTime.CompareTo(t2.elapsedTime)));
                string elapsedWinner = results[resList[0]];

                resList.Sort((t1, t2) => (t1.arrayWriteCount.CompareTo(t2.arrayWriteCount)));
                string writeWinner = results[resList[0]];

                if (elapsedWinner == qsname || elapsedWinner == rqsname)
                {
                    ++quickSortWins;
                }
                else
                {
                    quickSortWins = 0;
                }

                Console.WriteLine("S: " + arrayCount.ToString().PadLeft(2)
                    + " Acc: " + accessCountWinner.PadRight(13) +
                    " It: " + iterationWinner.PadRight(13) +
                    " Wr: " + writeWinner.PadRight(13) +
                    " El: " + elapsedWinner.PadRight(13));

                if (qsWinRequirement <= quickSortWins)
                {
                    break;
                }

                ++arrayCount;
            }
        }

        static void PrintRunSpeeds()
        {
            const int arrayCount = 1000;
            const int max = int.MaxValue;
            const int runCount = 1000;

            int[] numbers = new int[arrayCount];
            Helpers.FillArrayWithRandomData(numbers, max);

            Console.WriteLine(arrayCount + " elements, Max Value: " + max + ", Runs: " + runCount);

            RunOnAll(delegate(SortingAlgorithm sort)
            {
                PrintRunningSpeed(sort, numbers, runCount);
            });
        }

        public delegate void AlgorithmDelegate(SortingAlgorithm algo);

        public static void RunOnAll(AlgorithmDelegate del)
        {
            del(new SelectionSort());
            del(new InsertionSort());
            //del(new RandomQSort());
            del(new QuickSort());
            del(new ThreeWayQuickSort());
            del(new OptimizedQuickSort(30));
        }

        static void PrintRunningSpeed(SortingAlgorithm sort, int[] numbers, int runCount)
        {
            sort.SetArray(numbers);
            SortingAlgorithm.Result res = sort.Run(runCount);
            res.Divide(numbers.Length);
            Console.Write(sort.GetType().Name + ": ");
            Console.WriteLine(res);
        }

        static void TestAlgorithm(SortingAlgorithm sort)
        {
            const int count = 10000;
            int[] numbers = new int[count];
            Helpers.FillArrayWithRandomData(numbers, int.MaxValue);

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
