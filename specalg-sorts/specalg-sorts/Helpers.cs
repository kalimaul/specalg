using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specalg_sorts
{
    class Helpers
    {
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i] + ", ");
            }

            Console.WriteLine();
        }

        public static void Swap(int[] array, int idx1, int idx2, SortingAlgorithm.Result res)
        {
            int tmp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = tmp;
            res.accessCount += 4;
            res.arrayWriteCount += 2;
        }

        public static void FillArrayWithRandomData(int[] array, int maxVal)
        {
            System.Random rand = new Random();
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rand.Next() % maxVal;
            }
        }
    }
}
