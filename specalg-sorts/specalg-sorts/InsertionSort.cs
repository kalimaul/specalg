using System;

namespace specalg_sorts
{
    public class InsertionSort : SortingAlgorithm
    {
        protected override void DoSort(int[] array, Result res)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                ++res.accessCount;
                int val = array[i];
                int holePos = i;

                while (holePos > 0 && val < array[holePos - 1])
                {
                    ++res.innerIterationCount;
                    res.accessCount += 2;
                    array[holePos] = array[holePos - 1];
                    --holePos;
                }

                ++res.accessCount;
                array[holePos] = val;
            }
        }
    }
}