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
            new MainForm().ShowDialog();
        }

        /*static void TestAlgorithm(SortingAlgorithm sort)
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
        }*/
    }
}
