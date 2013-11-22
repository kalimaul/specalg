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

                // partition
                ++res.accessCount;
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

                Sort(array, from, pivot - 1, res);
                Sort(array, pivot + 1, to, res);
            }
        }
    }

    /// <summary>
    ///  Quicksort with 3-way partitioning
    /// </summary>
    class ThreeWayQuickSort : SortingAlgorithm
    {
        protected override void DoSort(int[] array, Result res)
        {
            Sort(array, 0, array.Length - 1, res);
        }

        void Sort(int[] array, int from, int to, Result res)
        {
            if (from < to)
            {
                // 3-way partition
                int pivot = from;
                int lower = from;
                int upper = to;

                ++res.accessCount;
                int pivotVal = array[pivot];

                while (pivot <= upper)
                {
                    ++res.innerIterationCount;
                    ++res.accessCount;

                    int diff = array[pivot] - pivotVal;

                    if (diff < 0) // less
                    {
                        Helpers.Swap(array, lower, pivot, res);
                        ++pivot;
                        ++lower;
                    }
                    else if (diff == 0) // eq
                    {
                        ++pivot;
                    }
                    else // greater
                    {
                        Helpers.Swap(array, pivot, upper, res);
                        --upper;
                    }
                }

                Sort(array, from, lower - 1, res);
                Sort(array, upper + 1, to, res);
            }
        }
    }

    /// <summary>
    ///  Quicksort switching to insertion when array is small
    /// </summary>
    class OptimizedQuickSort : SortingAlgorithm
    {
        int smallSwitch;

        public OptimizedQuickSort(int sw)
        {
            smallSwitch = sw;
        }

        protected override void DoSort(int[] array, Result res)
        {
            Sort(array, 0, array.Length - 1, res);
        }

        void SmallSort(int[] array, int from, int to, Result res)
        {
            for (int i = from + 1; i <= to; ++i)
            {
                ++res.accessCount;
                int val = array[i];
                int holePos = i;

                while (holePos > from && val < array[holePos - 1])
                {
                    ++res.innerIterationCount;
                    res.accessCount += 2;
                    ++res.arrayWriteCount;
                    array[holePos] = array[holePos - 1];
                    --holePos;
                }

                ++res.accessCount;
                ++res.arrayWriteCount;
                array[holePos] = val;
            }
        }

        void Sort(int[] array, int from, int to, Result res)
        {
            if (from < to)
            {
                if (to - from < smallSwitch)
                {
                    SmallSort(array, from, to, res);
                }
                else
                {
                    int pivot = (from + to) / 2;

                    // partition
                    ++res.accessCount;
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

                    Sort(array, from, pivot - 1, res);
                    Sort(array, pivot + 1, to, res);
                }
            }
        }
    }

#if false
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
#endif
}
