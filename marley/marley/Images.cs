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
        const int avgColorPxSize = 24;

        ImageDatabase images = new ImageList();

        public delegate void OnLoadEvent(string message);

        public void LoadDir(string dir, OnLoadEvent handler = null)
        {
            foreach (string imgPath in Directory.EnumerateFiles(dir))
            {
                if (handler != null)
                {
                    handler("Loading " + imgPath);
                }

                try
                {
                    using (Bitmap img = Bitmap.FromFile(imgPath) as Bitmap)
                    {
                        images.Insert(new ImageDatabase.Element(imgPath, AverageColor(img)));
                    }
                }
                catch (Exception e)
                {
                    if (handler != null)
                    {
                        handler("Error loading " + imgPath + ": " + e.ToString());
                    }
                }
            }
        }

        public string FindNearestColoredImage(Color color)
        {
            return images.GetNearest(color).image;
        }

        public delegate void MosaicEventHandler(Bitmap bmp);

        public void CreateMosaic(Bitmap bmp, int rows, int cols, MosaicEventHandler handler = null)
        {
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
                        string nearest = FindNearestColoredImage(avg);

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
                            if (handler != null)
                            {
                                handler(bmp);
                            }
                        }
                    }
                }
            }
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
            if (img.Width > avgColorPxSize && img.Height > avgColorPxSize)
            {
                img = ResizeBitmap(img, avgColorPxSize, avgColorPxSize);
            }

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
