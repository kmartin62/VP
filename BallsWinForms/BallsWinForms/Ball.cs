using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsWinForms
{
    public class Ball
    {
        public Point Center { get; set; }
        public static readonly int RADIUS = 25;
        public Color color { get; set; }

        public Ball(Point c, Color c1)
        {
            Center = c;
            color = c1;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

    }
}
