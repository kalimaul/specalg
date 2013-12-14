using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace specalg_sorts
{
    public partial class MainForm : Form
    {
        List<SortingAlgorithm> sorts;

        public MainForm()
        {
            InitializeComponent();
            UpdateStuff();
        }

        void UpdateStuff()
        {
            sorts = new List<SortingAlgorithm>();
            if (insertionCheckBox.Checked)
            {
                sorts.Add(new InsertionSort());
            }

            if (selectionCheckBox.Checked)
            {
                sorts.Add(new SelectionSort());
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
            if (sortButton.Enabled)
            {
                sortButton.Enabled = false;

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

            statusLogBox.Text = "Filling array...\n";
            UpdateStuff();
            int[] array = new int[(int)elemCount.Value];
            Helpers.FillArrayWithRandomData(array, (int)maxVal.Value);

            int runs = (int)sortRuns.Value;
            foreach (SortingAlgorithm sort in sorts)
            {
                statusLogBox.Text += "\nSorting with " + sort.GetType().Name + "\n";
                Refresh();
                SortingAlgorithm.Result res = sort.SetArray(array).Run(runs);
                res.Divide(array.Length);
                statusLogBox.Text += sort.GetType().Name + ": " + res.ToString() + "\n";
                Refresh();
            }

            if (!sortButton.Enabled)
            {
                sortButton.Enabled = true;

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
        }
    }
}
