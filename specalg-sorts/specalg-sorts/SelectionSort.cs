using System;

namespace specalg_sorts
{
    public class SelectionSort : SortingAlgorithm
    {
        protected override void DoSort(int[] array, Result res)
        {
            for (int pivot = array.Length - 1; pivot >= 0; --pivot)
            {
                int maxPos = pivot;
                for (int i = 0; i < pivot; ++i)
                {
                    ++res.innerIterationCount;
                    res.accessCount += 2;
                    if (array[i] > array[maxPos])
                    {
                        maxPos = i;
                    }
                }

                res.accessCount += 4;
                int tmp = array[pivot];
                array[pivot] = array[maxPos];
                array[maxPos] = tmp;
            }
        }
    }
}