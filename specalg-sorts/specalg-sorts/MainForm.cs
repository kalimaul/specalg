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
            UpdateStuff();

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
                            arrayCountRaceButton.Enabled = false;
                            arrayCountAllRaceButton.Enabled = false;

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
                            arrayCountRaceButton.Enabled = true;
                            arrayCountAllRaceButton.Enabled = true;

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

        private void SmallArrayCountRaceOnFew()
        {
            const int runCount = 10000;
            const int qsWinRequirement = 10;

            int arrayCount = 0;

            string qsname = typeof(QuickSort).Name;
            string rqsname = /*typeof(RandomQSort).Name*/"nonde";
            int quickSortWins = 0;

            while (arrayCount < 50)
            {
                int[] numbers = new int[arrayCount];
                Helpers.FillArrayWithRandomData(numbers, int.MaxValue);

                Dictionary<SortingAlgorithm.Result, string> results = new Dictionary<SortingAlgorithm.Result, string>();

                RunOnFew(delegate(SortingAlgorithm sort)
                {
                    results.Add(sort.SetArray(numbers).Run(runCount), sort.GetType().Name);
                });

                this.raceChart.BeginInvoke(new MethodInvoker(delegate
                {
                    this.raceChart.Series["Insertion Sort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(0).elapsedTime);
                    this.raceChart.Series["Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(1).elapsedTime);
                    this.raceChart.ResetAutoValues();
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

                arrayCount++;
            }
        }

        private void SmallArrayCountRaceOnAll()
        {
            const int runCount = 10000;

            int arrayCount = 0;

            while (arrayCount < 100)
            {
                int[] numbers = new int[arrayCount];
                Helpers.FillArrayWithRandomData(numbers, int.MaxValue);

                Dictionary<SortingAlgorithm.Result, string> results = new Dictionary<SortingAlgorithm.Result, string>();

                RunOnAll(delegate(SortingAlgorithm sort)
                {
                    results.Add(sort.SetArray(numbers).Run(runCount), sort.GetType().Name);
                });

                this.allRaceChart.BeginInvoke(new MethodInvoker(delegate
                {
                    this.allRaceChart.Series["Selection Sort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(0).elapsedTime);
                    this.allRaceChart.Series["Insertion Sort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(1).elapsedTime);
                    this.allRaceChart.Series["Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(2).elapsedTime);
                    this.allRaceChart.Series["3-way Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(3).elapsedTime);
                    this.allRaceChart.Series["Optimized Quicksort"].Points.AddXY(arrayCount.ToString(), results.Keys.ElementAt(4).elapsedTime);
                    this.allRaceChart.ResetAutoValues();
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

                this.statusLogBox.BeginInvoke(new MethodInvoker(delegate
                {
                    this.statusLogBox.AppendText(String.Format("S: {0, -8} Acc: {1, -25} It: {2, -25} Wr: {3, -25} El: {4, -25}\n", arrayCount.ToString(), accessCountWinner, iterationWinner, writeWinner, elapsedWinner));
                    this.Refresh();
                }));

                arrayCount++;
            }
        }

        private delegate void AlgorithmDelegate(SortingAlgorithm algo);

        private void RunOnFew(AlgorithmDelegate del)
        {
            del(new InsertionSort());
            del(new QuickSort());
        }

        private void RunOnAll(AlgorithmDelegate del)
        {
            del(new SelectionSort());
            del(new InsertionSort());
            del(new QuickSort());
            del(new ThreeWayQuickSort());
            del(new OptimizedQuickSort(30));
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
                            arrayCountRaceButton.Enabled = false;
                            arrayCountAllRaceButton.Enabled = false;

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

                        raceChart.Series["Insertion Sort"].Points.Clear();
                        raceChart.Series["Quicksort"].Points.Clear();
                    }));

                    SmallArrayCountRaceOnFew();

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("\n=====  Array count race has been finished  =====\n\n");
                        statusLogBox.Refresh();

                        if (!arrayCountRaceButton.Enabled)
                        {
                            sortButton.Enabled = true;
                            arrayCountRaceButton.Enabled = true;
                            arrayCountAllRaceButton.Enabled = true;

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

        private void arrayCountAllRaceButton_Click(object sender, EventArgs e)
        {
            arrayRaceThread = new Thread(delegate()
            {
                try
                {
                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        if (arrayCountAllRaceButton.Enabled)
                        {
                            sortButton.Enabled = false;
                            arrayCountRaceButton.Enabled = false;
                            arrayCountAllRaceButton.Enabled = false;

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

                        statusLogBox.AppendText("=====  Array count race on all algorithm has been started  =====\n\n");
                        statusLogBox.Refresh();

                        allRaceChart.Series["Selection Sort"].Points.Clear();
                        allRaceChart.Series["Insertion Sort"].Points.Clear();
                        allRaceChart.Series["Quicksort"].Points.Clear();
                        allRaceChart.Series["3-way Quicksort"].Points.Clear();
                        allRaceChart.Series["Optimized Quicksort"].Points.Clear();
                    }));

                    SmallArrayCountRaceOnAll();

                    statusLogBox.BeginInvoke(new MethodInvoker(delegate
                    {
                        statusLogBox.AppendText("\n=====  Array count race on all algorithm has been finished  =====\n\n");
                        statusLogBox.Refresh();

                        if (!arrayCountAllRaceButton.Enabled)
                        {
                            sortButton.Enabled = true;
                            arrayCountRaceButton.Enabled = true;
                            arrayCountAllRaceButton.Enabled = true;

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
                        statusLogBox.AppendText("Exception has been caught during array count race on all algorithm!: " + ex.Message);
                    }));
                }
            });

            arrayRaceThread.Start();
        }
    }
}
