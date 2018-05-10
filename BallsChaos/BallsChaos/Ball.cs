using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsChaos
{
    public class Ball
    {
        public static readonly int RADIUS = 20;
        public Point Centar { get; set; }
        public Color Boja { get; set; }

        public double Velocity { get; set; }
        public double Angle { get; set; }

        public float velocityX;
        public float velocityY;

        public bool IsColided { get; set; }

        public static Random g = new Random();
        int red = g.Next(0, 255);
        int green = g.Next(0, 255);
        int blue = g.Next(0, 255);
           
        public Ball(Point c, Color b)
        {
            Centar = c;
            Boja = b;
            Random r = new Random();
            Velocity = 10;
            IsColided = false;

            Angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);
        }

        public void Draw(Graphics g)
        {
            
            //Color c = Color.FromArgb(red, green, blue);
            Brush b = new SolidBrush(Color.FromArgb(red, green, blue));
            g.FillEllipse(b, Centar.X - RADIUS, Centar.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

        public bool isColiding(Ball b)
        {
            return ((Centar.X - b.Centar.X) * (Centar.X - b.Centar.X)) +
                ((Centar.Y - b.Centar.Y) * (Centar.Y - b.Centar.Y)) 
                <= RADIUS * RADIUS + RADIUS * RADIUS;
        }

        public void Move(int left, int top, int width, int height)
        {
            float nextX = Centar.X + velocityX;
            float nextY = Centar.Y + velocityY;

            if (nextX - RADIUS <= left || nextX + RADIUS >= width + left)
            {
                velocityX = -velocityX;
            }

            if(nextY - RADIUS <= top || nextY + RADIUS >= top + height)
            {
                velocityY = -velocityY;
            }

            Centar = new Point((int)(Centar.X + velocityX), (int)(Centar.Y + velocityY));
        }

    }
}
