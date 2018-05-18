using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class Ball
    {
        public Point Centar { get; set; }
        private int RADIUS = 30;
        public Color color { get; set; }
        public bool IsClicked { get; set; }
        public bool IsOut { get; set; }
        public bool IsColliding;
        Random r = new Random();

        public Ball(Point c, Color d)
        {
            Centar = c;
            color = d;
            IsClicked = false;
            IsOut = false;
            IsColliding = false;
        }

        public void Draw(Graphics g)
        {
            if (IsClicked)
            {
                g.DrawEllipse(new Pen(Color.Black), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            }

            g.FillEllipse(new SolidBrush(color), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
        }

        private float Distance(Point p1, Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }

        public void Check(Point p)
        {
            if (Distance(Centar, p) <= RADIUS * RADIUS) IsClicked = !IsClicked;
        }

        public void Move()
        {
            double Angle = r.NextDouble() * 2 * Math.PI;
            float velocityX = (float)(Math.Cos(Angle) * 100);
            float velocityY = (float)(Math.Sin(Angle) * 100);

            Centar = new Point((int)(Centar.X + velocityX), (int)(Centar.Y + velocityY));
        }

        public bool Colliding(Ball b)
        {
            return (Centar.X - b.Centar.X) * (Centar.X - b.Centar.X) + (Centar.Y - b.Centar.Y) * (Centar.Y - b.Centar.Y) <= RADIUS * RADIUS;
        }
    }
}
