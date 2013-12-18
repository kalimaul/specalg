using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marley
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Images images = new Images();

        void ImgEventHandler(string message)
        {
            logBox.Text += message + "\n";
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
            Refresh();
        }

        private void ImgsLoadButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowNewFolderButton = false;
            browser.SelectedPath = Application.ExecutablePath;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                string path = browser.SelectedPath;
                images.LoadDir(path, ImgEventHandler);
                ImgEventHandler("Loaded.");
            }
        }
    }
}
