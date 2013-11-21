using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specalg_sorts
{
    class QuickSort : SortingAlgorithm
    {
        Random random = new Random();

        protected override void DoSort(int[] array, Result res)
        {
            Sort(array, 0, array.Length - 1, res);
        }

        void Sort(int[] array, int from, int to, Result res)
        {
            if (from < to)
            {
                int pivot = random.Next() % (to - from) + from;
                //Console.WriteLine("From: " + from + ", To: " + to + ", Pivot: " + pivot);
                pivot = Partition(array, from, to, pivot, res);
                //Helpers.PrintArray(array);
                Sort(array, from, pivot - 1, res);
                Sort(array, pivot + 1, to, res);
            }
        }

        int Partition(int[] array, int from, int to, int pivot, Result res)
        {
            int pivotVal = array[pivot];
            Swap(array, pivot, to, res);
            pivot = from;

            for (int i = from; i < to; ++i)
            {
                ++res.innerIterationCount;

                if (array[i] <= pivotVal)
                {
                    Swap(array, i, pivot, res);
                    ++pivot;
                }
            }

            Swap(array, pivot, to, res);
            return pivot;
        }
    }
}
