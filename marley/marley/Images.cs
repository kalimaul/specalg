using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using BitmapProcessing;

namespace marley
{
    class Images
    {
        const int avgColorPxSize = 24;

        public ImageDatabase images;

        public delegate void OnLoadEvent(string message);

        public void LoadDir(string dir, OnLoadEvent handler = null)
        {
            foreach (string imgPath in Directory.EnumerateFiles(dir))
            {
#if false
                if (handler != null)
                {
                    handler("Loading " + imgPath);
                }
#endif

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

            while (colWidth * (cols + 1) < bmp.Width)
            {
                ++cols;
            }

            while (rowHeight * (rows + 1) < bmp.Height)
            {
                ++rows;
            }

            for (int x = 0; x <= cols; ++x)
            {
                int startX = x * colWidth;
                if (startX < bmp.Width)
                {
                    int width = Math.Min(bmp.Width - startX, colWidth);

                    for (int y = 0; y <= rows; ++y)
                    {
                        int startY = y * rowHeight;

                        if (startY < bmp.Height)
                        {
                            int height = Math.Min(bmp.Height - startY, rowHeight);

                            using (Bitmap cropped = CropArea(bmp, startX, startY, width, height))
                            {
                                Color avg = AverageColor(cropped);
                                string nearest = FindNearestColoredImage(avg);

                                if (nearest != null)
                                {
                                    using (Bitmap nearestBmp = Bitmap.FromFile(nearest) as Bitmap)
                                    {
                                        using (Bitmap nearestResized = ResizeAndCut(nearestBmp, width, height))
                                        {
                                            DrawOver(bmp, nearestResized, startX, startY);
                                            if (handler != null)
                                            {
                                                handler(bmp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static Bitmap Resize(Bitmap sourceBMP, int width, int height)
        {
            return new Bitmap(sourceBMP, new Size(width, height));
        }

        public static Bitmap ResizeAndCut(Bitmap sourceBMP, int width, int height)
        {
#if false
            float targetRatio = (float)width / height;
            int targetWidth;
            int targetHeight;

            if (width > height)
            {
                targetWidth = sourceBMP.Width;
                targetHeight = (int)(targetWidth / targetRatio);
            }
            else
            {
                targetHeight = sourceBMP.Height;
                targetWidth = (int)(targetHeight * targetRatio);
            }

            using (Bitmap cropped = CropArea(sourceBMP, (sourceBMP.Width - targetWidth) / 2, (sourceBMP.Height - targetHeight) / 2, targetWidth, targetHeight))
            {
                return new Bitmap(cropped, new Size(width, height));
            }
#else
            return Resize(sourceBMP, width, height);
#endif
        }

        unsafe public static Bitmap CropArea(Bitmap original, int posX, int posY, int width, int height)
        {
            Bitmap ret = new Bitmap(width, height);
#if false
            FastBitmap retFast = new FastBitmap(ret);
            FastBitmap origFast = new FastBitmap(original);

            retFast.LockImage();
            origFast.LockImage();

            for (int x = posX; x < posX + width && x < original.Width; ++x)
            {
                for (int y = posY; y < posY + height && y < original.Height; ++y)
                {
                    retFast.CopyFrom(x - posX, y - posY, origFast.GetPixelData(x, y));
                }
            }

            retFast.UnlockImage();
            origFast.UnlockImage();
#else
            using (Graphics g = Graphics.FromImage(ret))
            {
                RectangleF source = new RectangleF(posX, posY, width, height);
                RectangleF target = new RectangleF(0, 0, width, height);
                g.DrawImage(original, target, source, GraphicsUnit.Pixel);
            }
#endif

            return ret;
        }

        public static void DrawOver(Bitmap original, Bitmap small, int posX, int posY)
        {
            using (Graphics g = Graphics.FromImage(original))
            {
                g.DrawImage(small, posX, posY, small.Width, small.Height);
            }
        }

        unsafe public static Color AverageColor(Bitmap img)
        {
#if true
            if (img.Width > avgColorPxSize && img.Height > avgColorPxSize)
            {
                img = Resize(img, avgColorPxSize, avgColorPxSize);
            }
#endif

            double r = 0, g = 0, b = 0;

            FastBitmap fast = new FastBitmap(img);
            fast.LockImage();
            FastBitmap.PixelData* px = fast.GetPixelData(0, 0);

            for (int i = 0; i < img.Width * img.Height; ++i)
            {
                r += px->red;
                g += px->green;
                b += px->blue;
                ++px;
            }

            fast.UnlockImage();

            r /= (img.Width * img.Height);
            g /= (img.Width * img.Height);
            b /= (img.Width * img.Height);

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}
