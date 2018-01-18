using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Content
{
    class Graphs
    {

        int imageSize = 1000;

        Bitmap bitmap;

        public Graphs()
        {

        }

        public void DrawReperesentationOfDisc(List<Charge> allCharges)
        {
            bitmap = new Bitmap(imageSize, imageSize);

            Graphics graphics = Graphics.FromImage(bitmap);

            Pen blackPen = new Pen(Color.Black);

            graphics.DrawEllipse(blackPen, 0, imageSize, imageSize, imageSize);
            
            for (int i = 0; i < allCharges.Count; i++)
            {
                graphics.DrawEllipse(blackPen, 2, imageSize, imageSize, imageSize);
            }
        }
    }
}
