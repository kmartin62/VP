using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elipsi
{
    [Serializable]
    public class Ellipse
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point point { get; set; }

        private int R, G, B;

        public Ellipse(int w, int h, Point p)
        {
            Width = w;
            Height = h;
            point = p;
            Random r = new Random();
            R = r.Next(256);
            G = r.Next(256);
            B = r.Next(256);

        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.FromArgb(R, G, B)), point.X, point.Y,
                Width, Height);
        }

        public void ChangeColorr()
        {
            R += 5;
            G += 10;
            B += 15;

            if(R > 255)
            {
                R = R % 256;
            }

            if (G > 255)
            {
                G = G % 256;
            }

            if (B > 255)
            {
                B = B % 256;
            }
        }
    }
}
