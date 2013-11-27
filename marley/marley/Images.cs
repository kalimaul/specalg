using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace marley
{
    class Images
    {
        public enum AvgMethod
        {
            Resize, FullSize
        };

        const int resizedSize = 16;

        List<string> imgFiles = new List<string>();
        AvgMethod avgMethod;

        public Images(string dir, AvgMethod avgMethod)
        {
            this.avgMethod = avgMethod;

            foreach (string img in Directory.EnumerateFiles(dir))
            {
                if (img.EndsWith(".jpg"))
                {
                    imgFiles.Add(img);
                }
            }
        }

        public void ListPixelValues()
        {
            foreach (string imgPath in imgFiles)
            {
                using (Bitmap img = Bitmap.FromFile(imgPath) as Bitmap)
                {
                    Color avg;
                    if (avgMethod == AvgMethod.FullSize)
                    {
                        avg = AverageColor(img);
                    }
                    else
                    {
                        Bitmap resized = ResizeBitmap(img, resizedSize, resizedSize);
                        avg = AverageColor(resized);
                    }

                    System.Console.WriteLine(imgPath + ": " + avg);
                }
            }
        }

        static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }

        static Color AverageColor(Bitmap img)
        {
            double r = 0, g = 0, b = 0;

            for (int x = 0; x < img.Width; ++x)
            {
                for (int y = 0; y < img.Height; ++y)
                {
                    Color px = img.GetPixel(x, y);
                    r += px.R;
                    g += px.G;
                    b += px.B;
                }
            }

            r /= (img.Width * img.Height);
            g /= (img.Width * img.Height);
            b /= (img.Width * img.Height);

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}
