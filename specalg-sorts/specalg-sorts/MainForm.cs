using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace specalg_sorts
{
    public partial class MainForm : Form
    {
        List<SortingAlgorithm> sorts;
        private Thread sortThread = null;
        private Thread printSpeedThread = null;
        private Thread arrayRaceThread = null;

        public MainForm()
        {
            InitializeComponent();
            UpdateStuff();
        }

        void UpdateStuff()
        {
            sorts = new List<SortingAlgorithm>();
            if (selectionCheckBox.Checked)
            {
                sorts.Add(new SelectionSort());
            }

            if (insertionCheckBox.Checked)
            {
                sorts.Add(new InsertionSort());
            }

            if (quicksortCheckBox.Checked)
            {
                sorts.Add(new QuickSort());
            }

            if (threewayQSCheckbox.Checked)
            {
                sorts.Add(new ThreeWayQuickSort());
            }

            if (optimizedQSCheckbox.Checked)
            {
                sorts.Add(new OptimizedQuickSort((int)optimizedQSSwitchAt.Value));
            }

            Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStuff();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            sortThread = new Thread(delegate()
            {
                try
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("=====  Sort operation has been started  =====\n");

                        if (sortButton.Enabled)
                        {
                            sortButton.Enabled = false;
                            runSpeedButton.Enabled = false;
                            arrayCountRaceButton.Enabled = false;

                            elemCount.Enabled = false;
                            maxVal.Enabled = false;
                            sortRuns.Enabled = false;
                            optimizedQSSwitchAt.Enabled = false;

                            selectionCheckBox.Enabled = false;
                            insertionCheckBox.Enabled = false;
                            quicksortCheckBox.Enabled = false;
                            threewayQSCheckbox.Enabled = false;
                            optimizedQSCheckbox.Enabled = false;
                        }
                    }));

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("=====  Filling array  =====\n");
                    }));

                    int[] array = new int[(int)elemCount.Value];
                    Helpers.FillArrayWithRandomData(array, (int)maxVal.Value);

                    int runs = (int)sortRuns.Value;
                    foreach (SortingAlgorithm sort in sorts)
                    {
                        statusLogBox.BeginInvoke(new MethodInvoker(delegate
                        {
                            statusLogBox.AppendText("\nSorting with " + sort.GetType().Name + "\n");
                            statusLogBox.Refresh();
                        }));

                        SortingAlgorithm.Result res = sort.SetArray(array).Run(runs);
                        res.Divide(array.Length);

                        statusLogBox.BeginInvoke(new MethodInvoker(delegate
                        {
                            statusLogBox.AppendText(sort.GetType().Name + ": " + res.ToString() + "\n");
                            statusLogBox.Refresh();
                        }));
                    }

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("\n=====  Sort operation has been finished  =====\n\n\n");

                        if (!sortButton.Enabled)
                        {
                            sortButton.Enabled = true;
                            runSpeedButton.Enabled = true;
                            arrayCountRaceButton.Enabled = true;

                            elemCount.Enabled = true;
                            maxVal.Enabled = true;
                            sortRuns.Enabled = true;
                            optimizedQSSwitchAt.Enabled = true;

                            selectionCheckBox.Enabled = true;
                            insertionCheckBox.Enabled = true;
                            quicksortCheckBox.Enabled = true;
                            threewayQSCheckbox.Enabled = true;
                            optimizedQSCheckbox.Enabled = true;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("Exception has been caught during sort!: " + ex.Message);
                    }));
                }
            });

            sortThread.Start();
        }

        private void SmallArrayCountRace()
        {
            const int runCount = 10000;
            const int qsWinRequirement = 10;

            int arrayCount = 0;

            string qsname = typeof(QuickSort).Name;
            string rqsname = /*typeof(RandomQSort).Name*/"nonde";
            int quickSortWins = 30;

            while (arrayCount < 100)
            {
                int[] numbers = new int[arrayCount];
                Helpers.FillArrayWithRandomData(numbers, int.MaxValue);

                Dictionary<SortingAlgorithm.Result, string> results = new Dictionary<SortingAlgorithm.Result, string>();

                RunOnAll(delegate(SortingAlgorithm sort)
                {
                    results.Add(sort.SetArray(numbers).Run(runCount), sort.GetType().Name);
                });

                this.raceChart.BeginInvoke(new MethodInvoker(delegate
                {
                    this.raceChart.Series["Selection Sort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(0).elapsedTime);
                    this.raceChart.Series["Insertion Sort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(1).elapsedTime);
                    this.raceChart.Series["Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(2).elapsedTime);
                    this.raceChart.Series["3-way Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(3).elapsedTime);
                    this.raceChart.Series["Optimized Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(4).elapsedTime);
                }));

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

                this.statusLogBox.BeginInvoke(new MethodInvoker(delegate
                {
                    this.statusLogBox.AppendText(String.Format("S: {0, -8} Acc: {1, -25} It: {2, -25} Wr: {3, -25} El: {4, -25}\n", arrayCount.ToString(), accessCountWinner, iterationWinner, writeWinner, elapsedWinner));
                    this.Refresh();
                }));

                if (qsWinRequirement <= quickSortWins)
                {
                    this.statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        this.statusLogBox.AppendText("QuickSort Won!!\n");
                        this.Refresh();
                    }));
                    //break;
                }

                ++arrayCount;
            }
        }

        private void PrintRunSpeeds()
        {
            const int arrayCount = 1000;
            const int max = int.MaxValue;
            const int runCount = 1000;

            int[] numbers = new int[arrayCount];
            Helpers.FillArrayWithRandomData(numbers, max);

            this.statusLogBox.BeginInvoke(new MethodInvoker(delegate
            {
                this.statusLogBox.AppendText(arrayCount + " elements, Max Value: " + max + ", Runs: " + runCount + "\n");
                this.Refresh();
            }));

            RunOnAll(delegate(SortingAlgorithm sort)
            {
                PrintRunningSpeed(sort, numbers, runCount);
            });
        }

        private delegate void AlgorithmDelegate(SortingAlgorithm algo);

        private void RunOnAll(AlgorithmDelegate del)
        {
            del(new SelectionSort());
            del(new InsertionSort());
            //del(new RandomQSort());
            del(new QuickSort());
            del(new ThreeWayQuickSort());
            del(new OptimizedQuickSort(30));
        }

        private void PrintRunningSpeed(SortingAlgorithm sort, int[] numbers, int runCount)
        {
            sort.SetArray(numbers);
            SortingAlgorithm.Result res = sort.Run(runCount);
            res.Divide(numbers.Length);

            this.statusLogBox.BeginInvoke(new MethodInvoker(delegate
            {
                this.statusLogBox.AppendText(sort.GetType().Name + ": ");
                this.statusLogBox.AppendText(res.ToString() + "\n");
                this.Refresh();
            }));
        }

        private void runSpeedButton_Click(object sender, EventArgs e)
        {
            printSpeedThread = new Thread(delegate()
            {
                try
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (runSpeedButton.Enabled)
                        {
                            sortButton.Enabled = false;
                            runSpeedButton.Enabled = false;
                            arrayCountRaceButton.Enabled = false;

                            elemCount.Enabled = false;
                            maxVal.Enabled = false;
                            sortRuns.Enabled = false;
                            optimizedQSSwitchAt.Enabled = false;

                            selectionCheckBox.Enabled = false;
                            insertionCheckBox.Enabled = false;
                            quicksortCheckBox.Enabled = false;
                            threewayQSCheckbox.Enabled = false;
                            optimizedQSCheckbox.Enabled = false;
                        }

                        statusLogBox.AppendText("=====  Run speed has been started  =====\n\n");
                        statusLogBox.Refresh();
                    }));

                    PrintRunSpeeds();

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("\n=====  Run speed has been finished  =====\n\n");
                        statusLogBox.Refresh();

                        if (!runSpeedButton.Enabled)
                        {
                            sortButton.Enabled = true;
                            runSpeedButton.Enabled = true;
                            arrayCountRaceButton.Enabled = true;

                            elemCount.Enabled = true;
                            maxVal.Enabled = true;
                            sortRuns.Enabled = true;
                            optimizedQSSwitchAt.Enabled = true;

                            selectionCheckBox.Enabled = true;
                            insertionCheckBox.Enabled = true;
                            quicksortCheckBox.Enabled = true;
                            threewayQSCheckbox.Enabled = true;
                            optimizedQSCheckbox.Enabled = true;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("Exception has been caught during speed print!: " + ex.Message);
                    }));
                }
            });

            printSpeedThread.Start();
        }

        private void arrayCountRaceButton_Click(object sender, EventArgs e)
        {
            arrayRaceThread = new Thread(delegate()
            {
                try
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (arrayCountRaceButton.Enabled)
                        {
                            sortButton.Enabled = false;
                            runSpeedButton.Enabled = false;
                            arrayCountRaceButton.Enabled = false;

                            elemCount.Enabled = false;
                            maxVal.Enabled = false;
                            sortRuns.Enabled = false;
                            optimizedQSSwitchAt.Enabled = false;

                            selectionCheckBox.Enabled = false;
                            insertionCheckBox.Enabled = false;
                            quicksortCheckBox.Enabled = false;
                            threewayQSCheckbox.Enabled = false;
                            optimizedQSCheckbox.Enabled = false;
                        }

                        statusLogBox.AppendText("=====  Array count race has been started  =====\n\n");
                        statusLogBox.Refresh();

                        raceChart.Series["Selection Sort"].Points.Clear();
                        raceChart.Series["Insertion Sort"].Points.Clear();
                        raceChart.Series["Quicksort"].Points.Clear();
                        raceChart.Series["3-way Quicksort"].Points.Clear();
                        raceChart.Series["Optimized Quicksort"].Points.Clear();
                    }));

                    SmallArrayCountRace();

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("\n=====  Array count race has been finished  =====\n\n");
                        statusLogBox.Refresh();

                        if (!arrayCountRaceButton.Enabled)
                        {
                            sortButton.Enabled = true;
                            runSpeedButton.Enabled = true;
                            arrayCountRaceButton.Enabled = true;

                            elemCount.Enabled = true;
                            maxVal.Enabled = true;
                            sortRuns.Enabled = true;
                            optimizedQSSwitchAt.Enabled = true;

                            selectionCheckBox.Enabled = true;
                            insertionCheckBox.Enabled = true;
                            quicksortCheckBox.Enabled = true;
                            threewayQSCheckbox.Enabled = true;
                            optimizedQSCheckbox.Enabled = true;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("Exception has been caught during array count race!: " + ex.Message);
                    }));
                }
            });

            arrayRaceThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Action<object> stop = (object obj) =>
            {
                if (sortThread != null)
                {
                    sortThread.Abort();
                }

                if (printSpeedThread != null)
                {
                    printSpeedThread.Abort();
                }

                if (arrayRaceThread != null)
                {
                    arrayRaceThread.Abort();
                }
            };

            Task t1 = new Task(stop, "alpha");
            t1.Start();
        }
    }
}
