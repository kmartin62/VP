using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    [Serializable]
    public class Ball
    {
        
        public Point Centar { get; set; }
        public int RADIUS = 25;

        public Double Velocity { get; set; }
        public Double Angle { get; set; }

        private float velocityX, velocitY;
        public bool InHole { get; set; }

        public Color color { get; set; }

        public Ball(Point c, Color b)
        {
            Centar = c;
            color = b;
            InHole = false;

            Velocity = 10;
            Random r = new Random();
            Angle = r.NextDouble() * 2 * Math.PI;

            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocitY = (float)(Math.Sin(Angle) * Velocity);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);

        }

        public void Move()
        {
            int nextX = (int)(Centar.X + velocityX);
            int nextY = (int)(Centar.Y + velocitY);

            if(nextX <= 50)
            {
                nextX = 50;
                velocityX = -velocityX;
            }

            if(nextX > 750)
            {
                nextX = 750;
                velocityX = -velocityX;
            }

            if(nextY <= 50)
            {
                nextY = 50;
                velocitY = -velocitY;
            }

            if(nextY > 400)
            {
                nextY = 400;
                velocitY = -velocitY;
            }

            Centar = new Point(nextX, nextY);
        }

        public bool TouchHole(Hole hole)
        {
            return ((Centar.X - hole.Centar.X) * (Centar.X - hole.Centar.X) + (Centar.Y - hole.Centar.Y) * (Centar.Y - hole.Centar.Y)) <= RADIUS * RADIUS;
        }
    }
}
