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

        private void generateMosaicButton_Click(object sender, EventArgs e)
        {
            if (imgForm.pictureBox.Image != null)
            {
                const int rows = 80;
                const int cols = 80;
                Bitmap bmp = imgForm.pictureBox.Image as Bitmap;
                int rowHeight = bmp.Height / rows;
                int colWidth = bmp.Width / cols;

                Dictionary<string, Bitmap> resizedBitmaps = new Dictionary<string, Bitmap>();

                for (int x = 0; x < cols; ++x)
                {
                    for (int y = 0; y < rows; ++y)
                    {
                        using (Bitmap cropped = Images.CropArea(bmp, x * colWidth, y * rowHeight, colWidth, rowHeight))
                        {
                            Color avg = Images.AverageColor(cropped);
                            string nearest = images.FindNearestColoredImage(avg);

                            if (nearest != null)
                            {
                                Bitmap resized = null;
                                if (!resizedBitmaps.TryGetValue(nearest, out resized))
                                {
                                    using (Bitmap nearestBmp = Bitmap.FromFile(nearest) as Bitmap)
                                    {
                                        using (Bitmap nearestResized = Images.ResizeBitmap(nearestBmp, colWidth, rowHeight))
                                        {
                                            resized = nearestResized.Clone() as Bitmap;
                                            resizedBitmaps.Add(nearest, resized);
                                        }
                                    }
                                }
                                Images.DrawOver(bmp, resized, x * colWidth, y * rowHeight);
                                imgForm.pictureBox.Image = bmp;
                                imgForm.Refresh();
                            }
                        }
                    }
                }
            }
        }
    }
}
