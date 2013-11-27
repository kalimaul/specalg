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
        int width, height;

        List<KeyValuePair<Color, Bitmap>> images = new List<KeyValuePair<Color, Bitmap>>();

        public Images(string dir, int w, int h)
        {
            width = w;
            height = h;

            int i = 0;

            foreach (string imgPath in Directory.EnumerateFiles(dir))
            {
                Console.WriteLine("Loading " + i);
                if (imgPath.EndsWith(".jpg"))
                {
                    using (Bitmap img = Bitmap.FromFile(imgPath) as Bitmap)
                    {
                        Bitmap resized = ResizeBitmap(img, width, height);
                        images.Add(new KeyValuePair<Color, Bitmap>(AverageColor(resized), resized));
                    }
                }

                ++i;
            }
        }

        public Bitmap FindNearestColoredImage(Color color, int width, int height)
        {
            Bitmap best = null;
            Color bestAvg = Color.White;

            foreach (KeyValuePair<Color, Bitmap> image in images)
            {
                if (best == null)
                {
                    best = image.Value;
                    bestAvg = image.Key;
                }
                else
                {
                    if (ColorDiff(image.Key, color) < ColorDiff(bestAvg, color))
                    {
                        best = image.Value;
                        bestAvg = image.Key;
                    }
                }
            }

            return best;
        }

        public static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            return new Bitmap(sourceBMP, new Size(width, height));
        }

        public static Bitmap CropArea(Bitmap original, int posX, int posY, int width, int height)
        {
            Bitmap ret = new Bitmap(width, height);
            for (int x = posX; x < posX + width && x < original.Width; ++x)
            {
                for (int y = posY; y < posY + height && y < original.Height; ++y)
                {
                    ret.SetPixel(x - posX, y - posY, original.GetPixel(x, y));
                }
            }
            return ret;
        }

        public static void DrawOver(Bitmap original, Bitmap small, int posX, int posY)
        {
            for (int x = posX; x < posX + small.Width && x < original.Width; ++x)
            {
                for (int y = posY; y < posY + small.Height && y < original.Height; ++y)
                {
                    original.SetPixel(x, y, small.GetPixel(x - posX, y - posY));
                }
            }
        }

        public static Color AverageColor(Bitmap img)
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

        public static double ColorDiff(Color c1, Color c2)
        {
            double rdiff = (double)c2.R - (double)c1.R;
            double gdiff = (double)c2.G - (double)c1.G;
            double bdiff = (double)c2.B - (double)c1.B;

            return Math.Sqrt(rdiff * rdiff + gdiff * gdiff + bdiff * bdiff);
        }
    }
}
