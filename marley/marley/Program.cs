using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace marley
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string baseDir = Directory.GetCurrentDirectory() + "\\imgs";
            if (!Directory.Exists(baseDir))
            {
                Console.WriteLine("Img dir " + baseDir + " doesn't exist!");
            }
            else
            {
                Images images = new Images(baseDir, Images.AvgMethod.Resize);
                images.ListPixelValues();
            }
        }
    }
}
