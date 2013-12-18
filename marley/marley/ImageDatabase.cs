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

            return rdiff * rdiff + gdiff * gdiff + bdiff * bdiff;
        }

        public abstract void Insert(Element element);
        public abstract Element GetNearest(Color color);
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
