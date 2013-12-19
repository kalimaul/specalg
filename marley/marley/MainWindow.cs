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
        ImgForm imgForm = new ImgForm();

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
                if (imageDBStructure.Text == "kdtree")
                {
                    images.images = new KDTree();
                }
                else
                {
                    images.images = new ImageList();
                }
                images.LoadDir(path, ImgEventHandler);
                ImgEventHandler("Loaded.");
            }
        }

        private void imgLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                imgForm.Hide();
                imgForm = new ImgForm();
                ImgEventHandler("Loading " + path + "\n");
                try
                {
                    Bitmap img = Bitmap.FromFile(path) as Bitmap;
                    imgForm.pictureBox.Image = img;
                    imgForm.Show();
                }
                catch (Exception ex)
                {
                    ImgEventHandler("Error loading " + path + ": " + ex.ToString());
                }
            }
        }

        void MosaicEventHandler(Bitmap bmp)
        {
            imgForm.pictureBox.Image = bmp;
            imgForm.Refresh();
        }

        private void generateMosaicButton_Click(object sender, EventArgs e)
        {
            if (imgForm.pictureBox.Image != null)
            {
                Bitmap bmp = imgForm.pictureBox.Image as Bitmap;
                images.CreateMosaic(bmp, (int)rowsCounter.Value, (int)colsCounter.Value, MosaicEventHandler);
            }
        }
    }
}
