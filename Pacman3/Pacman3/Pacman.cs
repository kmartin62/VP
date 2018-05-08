using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman3
{
    public class Pacman
    {
        public int X { get; set; }
        public int Y { get; set; }
        public enum DIRECTION
        {
            UP, DOWN, LEFT, RIGHT
        }
        public DIRECTION direction;
        public int RADIUS = 20;
        public int Speed { get; set; }
        public bool mouth { get; set; }

        Brush b = new SolidBrush(Color.Yellow);

        public Pacman()
        {
            Speed = RADIUS;
            X = 5;
            Y = 7;
            direction = DIRECTION.DOWN;
        }

        public void ChangeDirection(DIRECTION dir)
        {
            direction = dir;
        }

        public void Move(int width, int height)
        {
            if(direction == DIRECTION.DOWN)
            {
                Y += 1;
                if(Y >= height)
                {
                    Y = 0;
                }
            }

            if (direction == DIRECTION.UP)
            {
                Y -= 1;
                if (Y < 0)
                {
                    Y = height - 1;
                }
            }

            if (direction == DIRECTION.RIGHT)
            {
                X += 1;
                if (X >= width)
                {
                    X = 0;
                }
            }

            if (direction == DIRECTION.LEFT)
            {
                X -= 1;
                if (X < 0)
                {
                    X = height - 1;
                }
            }

            mouth = !mouth;
        }

        public void Draw(Graphics g)
        {
            if (mouth)
            {
                g.DrawEllipse(new Pen(Color.Black), (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2);
                g.FillEllipse(b, (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2 , RADIUS * 2);
            }
            else
            {
                if(direction == DIRECTION.RIGHT)
                {
                    g.DrawPie(new Pen(Color.Black), (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 45, 270);
                    g.FillPie(b, (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 45, 270);
                }

                if (direction == DIRECTION.DOWN)
                {
                    g.DrawPie(new Pen(Color.Black), (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 135, 270);
                    g.FillPie(b, (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 135, 270);
                }

                if (direction == DIRECTION.LEFT)
                {
                    g.DrawPie(new Pen(Color.Black), (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 225, 270);
                    g.FillPie(b, (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 225, 270);
                }

                if (direction == DIRECTION.UP)
                {
                    g.DrawPie(new Pen(Color.Black), (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 315, 270);
                    g.FillPie(b, (RADIUS * 2 * X) + 115, RADIUS * 2 * Y, RADIUS * 2, RADIUS * 2, 315, 270);
                }
            }
        }

    }
}
