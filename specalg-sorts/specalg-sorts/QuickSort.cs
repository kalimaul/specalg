using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specalg_sorts
{
    class QuickSort : SortingAlgorithm
    {
        protected override void DoSort(int[] array, Result res)
        {
            Sort(array, 0, array.Length - 1, res);
        }

        void Sort(int[] array, int from, int to, Result res)
        {
            if (from < to)
            {
                int pivot = (from + to) / 2;
                pivot = Partition(array, from, to, pivot, res);
                Sort(array, from, pivot - 1, res);
                Sort(array, pivot + 1, to, res);
            }
        }

        int Partition(int[] array, int from, int to, int pivot, Result res)
        {
            int pivotVal = array[pivot];
            Helpers.Swap(array, pivot, to, res);
            pivot = from;

            for (int i = from; i < to; ++i)
            {
                ++res.innerIterationCount;
                ++res.accessCount;

                if (array[i] <= pivotVal)
                {
                    Helpers.Swap(array, i, pivot, res);
                    ++pivot;
                }
            }

            Helpers.Swap(array, pivot, to, res);
            return pivot;
        }
    }

    /// <summary>
    ///  Randomized QuickSort (random pivot selection)
    /// </summary>
    class RandomQSort : SortingAlgorithm
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
                pivot = Partition(array, from, to, pivot, res);
                Sort(array, from, pivot - 1, res);
                Sort(array, pivot + 1, to, res);
            }
        }

        int Partition(int[] array, int from, int to, int pivot, Result res)
        {
            int pivotVal = array[pivot];
            Helpers.Swap(array, pivot, to, res);
            pivot = from;

            for (int i = from; i < to; ++i)
            {
                ++res.innerIterationCount;
                ++res.accessCount;

                if (array[i] <= pivotVal)
                {
                    Helpers.Swap(array, i, pivot, res);
                    ++pivot;
                }
            }

            Helpers.Swap(array, pivot, to, res);
            return pivot;
        }
    }
}
