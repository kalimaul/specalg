using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marley
{
    public abstract class ImageDatabase
    {
        public class Element
        {
            public Element(string image, Color color)
            {
                this.image = image;
                this.color = color;
            }

            public string image;
            public Color color;
        }

        public static double ColorDiff(Color c1, Color c2)
        {
            double rdiff = (double)c2.R - (double)c1.R;
            double gdiff = (double)c2.G - (double)c1.G;
            double bdiff = (double)c2.B - (double)c1.B;

            return Math.Sqrt(rdiff * rdiff + gdiff * gdiff + bdiff * bdiff);
        }

        public abstract void Insert(Element element);
        public abstract Element GetNearest(Color color);
    }

    public class KDTree : ImageDatabase
    {
        public class Node
        {
            public ImageDatabase.Element data;
            Node[] children = new Node[2];
            int depth;
            public int dimension
            {
                get
                {
                    return depth % 3;
                }
            }

            public Node(ImageDatabase.Element data, int depth)
            {
                this.data = data;
                this.depth = depth;
            }

            public void Insert(ImageDatabase.Element element)
            {
                byte refPos = GetColorDimension(dimension, element.color);
                byte cmpPos = GetColorDimension(dimension, data.color);
                int child = refPos < cmpPos ? 0 : 1;
                if (children[child] == null)
                {
                    children[child] = new Node(element, depth + 1);
                }
                else
                {
                    children[child].Insert(element);
                }
            }

            public Node NN(KDBox box, Color color, Node best)
            {
                double bestDiff = 0;
                double boxDiff = 0;

                if (best != null)
                {
                    bestDiff = ImageDatabase.ColorDiff(color, best.data.color);
                    boxDiff = box.Distance(color);
                }

                if (best == null || bestDiff > boxDiff)
                {
                    if (best == null || bestDiff > ImageDatabase.ColorDiff(color, data.color))
                        best = this;

                    KDBox leftBox = new KDBox(
                        GetColorDimension(0, box.lowest),
                        GetColorDimension(1, box.lowest),
                        GetColorDimension(2, box.lowest),
                        GetColorDimension(0, dimension == 0 ? data.color : box.highest),
                        GetColorDimension(1, dimension == 1 ? data.color : box.highest),
                        GetColorDimension(2, dimension == 2 ? data.color : box.highest)
                        );

                    KDBox rightBox = new KDBox(
                        GetColorDimension(0, dimension == 0 ? data.color : box.lowest),
                        GetColorDimension(1, dimension == 1 ? data.color : box.lowest),
                        GetColorDimension(2, dimension == 2 ? data.color : box.lowest),
                        GetColorDimension(0, box.highest),
                        GetColorDimension(1, box.highest),
                        GetColorDimension(2, box.highest)
                        );

                    if (GetColorDimension(dimension, color) < GetColorDimension(dimension, data.color))
                    {
                        if (children[0] != null)
                        {
                            best = children[0].NN(leftBox, color, best);
                        }

                        if (children[1] != null)
                        {
                            best = children[1].NN(rightBox, color, best);
                        }
                    }
                    else
                    {
                        if (children[1] != null)
                        {
                            best = children[1].NN(rightBox, color, best);
                        }

                        if (children[0] != null)
                        {
                            best = children[0].NN(leftBox, color, best);
                        }
                    }
                }

                return best;
            }
        }

        public class KDBox
        {
            public Color lowest;
            public Color highest;

            public KDBox(byte x1, byte y1, byte z1, byte x2, byte y2, byte z2)
            {
                byte xLow = Math.Min(x1, x2);
                byte xHigh = Math.Max(x1, x2);
                byte yLow = Math.Min(y1, y2);
                byte yHigh = Math.Max(y1, y2);
                byte zLow = Math.Min(z1, z2);
                byte zHigh = Math.Max(z1, z2);

                lowest = Color.FromArgb(xLow, yLow, zLow);
                highest = Color.FromArgb(xHigh, yHigh, zHigh);
            }

            public double Distance(Color color)
            {
                double result = 0;

                for (int dimension = 0; dimension < 3; ++dimension)
                {
                    double dist = 0;
                    byte colorDim = GetColorDimension(dimension, color);
                    byte lowDim = GetColorDimension(dimension, lowest);
                    byte highDim = GetColorDimension(dimension, highest);

                    if (colorDim < lowDim)
                    {
                        dist = lowDim - colorDim;
                    }
                    else if (colorDim > highDim)
                    {
                        dist = colorDim - highDim;
                    }

                    result += dist * dist;
                }

                return Math.Sqrt(result);
            }
        }

        Node root = null;

        static byte GetColorDimension(int dimension, Color color)
        {
            if (dimension == 0)
            {
                return color.R;
            }
            else if (dimension == 1)
            {
                return color.G;
            }
            else if (dimension == 2)
            {
                return color.B;
            }
            else
            {
                throw new Exception("invalid dimension");
            }
        }

        public override void Insert(ImageDatabase.Element element)
        {
            if (root == null)
            {
                root = new Node(element, 0);
            }
            else
            {
                root.Insert(element);
            }
        }

        public override ImageDatabase.Element GetNearest(Color color)
        {
            KDBox box = new KDBox(0, 0, 0, 255, 255, 255);
            return root.NN(box, color, null).data;
        }
    }

    public class ImageList : ImageDatabase
    {
        List<ImageDatabase.Element> elems = new List<ImageDatabase.Element>();

        public override void Insert(ImageDatabase.Element element)
        {
            elems.Add(element);
        }

        public override ImageDatabase.Element GetNearest(Color color)
        {
            ImageDatabase.Element ret = null;

            for (int i = 0; i < elems.Count; ++i)
            {
                if (ret == null ||
                    ImageDatabase.ColorDiff(elems[i].color, color) < ImageDatabase.ColorDiff(ret.color, color))
                {
                    ret = elems[i];
                }
            }

            return ret;
        }
    }
}
