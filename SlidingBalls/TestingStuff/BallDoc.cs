using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class BallDoc
    {
        public List<Ball> balls { get; set; }
        public List<Ball> redballs { get; set; }

        public BallDoc()
        {
            balls = new List<Ball>();
            redballs = new List<Ball>();
        }

        public void Draw(Graphics g)
        {
            foreach(Ball b in balls)
            {
                b.Draw(g);
            }

            foreach (Ball b in redballs)
            {
                b.Draw(g);
            }
        }

        public void Add(Ball b)
        {
            balls.Add(b);
        }

        public void AddRed(Ball b)
        {
            redballs.Add(b);
        }

        public void Check(Point p)
        {
            foreach(Ball b in redballs)
            {
                if (b.color == Color.Red)
                {
                    b.Check(p);
                }
            }
        }

        public void Move()
        {
            foreach(Ball b in redballs)
            {
                if (b.IsClicked) b.Move();
            }
        }

        public void CheckOut(int width, int height)
        {
            for(int i = 0; i < redballs.Count; i++)
            {
                if(redballs[i].Centar.X > width || redballs[i].Centar.Y > height || redballs[i].Centar.X < 0 || redballs[i].Centar.Y < 0)
                {
                    redballs[i].IsOut = true;
                }
            }

            for(int i = redballs.Count - 1; i >= 0; i--)
            {
                if (redballs[i].IsOut)
                {
                    redballs.RemoveAt(i);
                }
            }
        }

        public bool IsItOut(int width, int height)
        {
            for (int i = 0; i < redballs.Count; i++)
            {
                if (redballs[i].Centar.X > width || redballs[i].Centar.Y > height || redballs[i].Centar.X < 0 || redballs[i].Centar.Y < 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void CheckColliding()
        {
            for(int i = 0; i < redballs.Count; i++)
            {
                for(int j = 0; j < balls.Count; j++)
                {
                    if(redballs[i].Colliding(balls[j]))
                    {
                        balls[j].IsColliding = true;
                        //balls[i].IsColliding = true;
                    }
                }
            }

            for(int i = balls.Count - 1; i >= 0; i--)
            {
                if (balls[i].IsColliding && balls[i].color == Color.Green)
                {
                    balls.RemoveAt(i);
                }
            }
        }
    }
}
