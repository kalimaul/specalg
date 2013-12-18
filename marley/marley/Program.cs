using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace marley
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new MainWindow().ShowDialog();

#if false
            string baseDir = "imgs";
            if (!Directory.Exists(baseDir))
            {
                Console.WriteLine("Img dir " + baseDir + " doesn't exist!");
            }
            else
            {
                const string bigImg = "imgs/14432.jpg";
                const int rows = 40;
                const int cols = 40;
                Bitmap bigBitmap = Bitmap.FromFile(bigImg) as Bitmap;
                int rowWidth = bigBitmap.Width / rows;
                int colWidth = bigBitmap.Width / cols;

                Images images = new Images(baseDir, rowWidth, colWidth);

                for (int x = 0; x < rows; ++x)
                {
                    for (int y = 0; y < cols; ++y)
                    {
                        Bitmap cropped = Images.CropArea(bigBitmap, x * rowWidth, y * colWidth, rowWidth, colWidth);
                        Color avg = Images.AverageColor(cropped);
                        Bitmap nearest = images.FindNearestColoredImage(avg, rowWidth, colWidth);
                        Images.DrawOver(bigBitmap, nearest, x * rowWidth, y * colWidth);
                    }
                }

                bigBitmap.Save("bin/produce.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
#endif
        }
    }
}
