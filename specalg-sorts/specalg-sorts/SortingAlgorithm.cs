using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specalg_sorts
{
    public abstract class SortingAlgorithm
    {
        int[] originalArray;
        int[][] results;

        public int[][] GetResults()
        {
            return results;
        }

        public SortingAlgorithm SetArray(int[] array)
        {
            originalArray = array;
            return this;
        }

        public class Result
        {
            public double accessCount;
            public double innerIterationCount;
            public double elapsedTime;

            public void Divide(double div)
            {
                accessCount = accessCount / div;
                innerIterationCount = innerIterationCount / div;
                // elapsedTime = elapsedTime / div;
            }

            public override string ToString()
            {
                return "Access: " + (long)accessCount +
                    ", Inner Iteration: " + (long)innerIterationCount +
                    ", Elapsed (ms): " + (long)elapsedTime;
            }
        }

        protected abstract void DoSort(int[] array, Result res);

        public Result RunOnce()
        {
            return Run(1);
        }

        public Result Run(int count)
        {
            Result avg = new Result();

            // Clone the array multiple times so both in-place and non-in-place algorithms can run
            // without the array copy skewing the results.
            results = new int[count][];
            for (int i = 0; i < count; ++i)
            {
                results[i] = new int[originalArray.Length];
                System.Array.Copy(originalArray, results[i], originalArray.Length);
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            System.GC.Collect();
            sw.Start();

            for (int i = 0; i < count; ++i)
            {
                DoSort(results[i], avg);
            }

            sw.Stop();
            avg.elapsedTime = (double)sw.ElapsedMilliseconds;
            avg.Divide(count);

            return avg;
        }
    }
}
