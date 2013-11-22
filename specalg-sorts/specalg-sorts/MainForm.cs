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
        public MainForm()
        {
            InitializeComponent();
        }

        void UpdateStuff()
        {
            Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStuff();
            statusLabel.Text = "";
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Filling array...\n";
            UpdateStuff();
            int[] array = new int[(int)elemCount.Value];
            Helpers.FillArrayWithRandomData(array, (int)maxVal.Value);

            int runs = (int)sortRuns.Value;

            Program.RunOnAll(delegate (SortingAlgorithm sort) {
                statusLabel.Text += "Sorting with " + sort.GetType().Name + "\n";
                UpdateStuff();
                SortingAlgorithm.Result res = sort.SetArray(array).Run(runs);
                res.Divide(array.Length);
                statusLabel.Text += sort.GetType().Name + ": " + res.ToString() + "\n";
                UpdateStuff();
            });
        }
    }
}
