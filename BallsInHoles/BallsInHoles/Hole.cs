using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    [Serializable]
    public class Hole
    {
        public Point Centar { get; set; }
        public int RADIUS { get; set; }
        public int Count { get; set; }

        public Hole(Point c)
        {
            RADIUS = 30;
            Centar = c;
            Count = 0;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), Centar.X, Centar.Y, RADIUS * 2, RADIUS * 2);
            g.DrawString(string.Format("{0}", Count), new Font("Arial", 20), new SolidBrush(Color.White), Centar.X + RADIUS, Centar.Y + RADIUS);
        }

        public bool Colliding(Hole hole)
        {
            return ((hole.Centar.X - Centar.X) * (hole.Centar.X - Centar.X) + (hole.Centar.Y - Centar.Y) * (hole.Centar.Y - Centar.Y)) <= hole.RADIUS * RADIUS;
            //return (x - Centar.X) * (x - Centar.X) + (y - Centar.Y) * (y - Centar.Y) <= RADIUS * RADIUS;
        }

    }
}
