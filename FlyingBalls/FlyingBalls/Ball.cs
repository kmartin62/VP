using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    [Serializable]
    public class Ball
    {
        public int RADIUS = 30;
        public Point Centar { get; set; }
        public int Status { get; set; }
        private Random r = new Random();
        public bool IsOut;

        public Ball(Point c)
        {
            Centar = c;
            Status = r.Next(3);
            IsOut = false;
        }

        public void Draw(Graphics g)
        {
            if(Status == 0)
            {
                
                g.FillEllipse(new SolidBrush(Color.Red), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            }

            if (Status == 1)
            {
                g.FillEllipse(new SolidBrush(Color.Green), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            }

            if (Status == 2)
            {
                g.FillEllipse(new SolidBrush(Color.Blue), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            }
        }

        public void Move()
        {
            Centar = new Point(Centar.X + 10, Centar.Y);
        }

        public bool IsHit(Point p1)
        {
            return (Centar.X - p1.X) * (Centar.X - p1.X) + (Centar.Y - p1.Y) * (Centar.Y - p1.Y) <= RADIUS * RADIUS;
        }
    }
}
