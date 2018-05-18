using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfCircles
{
    [Serializable]
    public class HalfCircle
    {
        public Point Centar { get; set; }
        public int RADIUS { get; set; }
        private int R, G, B;

        public HalfCircle(Point c)
        {
            Centar = c;
            RADIUS = 30;
            Random r = new Random();
            R = r.Next(255);
            G = r.Next(255);
            B = r.Next(255);
        }

        public void Draw(Graphics g)
        {
            g.FillPie(new SolidBrush(Color.FromArgb(R, G, B)), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2, 0, 180);
            g.FillPie(new SolidBrush(Color.FromArgb(255 - R, 255 - G, 255 - B)), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2, 180, 180);
        }

        public void Pulse()
        {
            RADIUS = RADIUS + 3;

            if(RADIUS > 60)
            {
                RADIUS = 30;
            }
        }
    }
}
