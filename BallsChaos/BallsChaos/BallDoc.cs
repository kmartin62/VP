using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsChaos
{
    public class BallDoc
    {
        public List<Ball> Balls { get; set; }

        public BallDoc()
        {
            Balls = new List<Ball>();
        }

        public void AddBall(Ball b)
        {
            Balls.Add(b);
        }

        public void Draw(Graphics g)
        {
            foreach(Ball b in Balls)
            {
                b.Draw(g);
            }
        }

        public void Move(int left, int top, int width, int height)
        {
            foreach(Ball b in Balls)
            {
                b.Move(left, top, width, height);
            }
        }

        public void CheckCollisions()
        {
            for(int i = 0; i < Balls.Count; i++)
            {
                for(int j = i + 1; j < Balls.Count; j++)
                {
                    if (Balls[i].isColiding(Balls[j]))
                    {
                        Balls[i].IsColided = true;
                        Balls[j].IsColided = true;
                    }
                }
            }

            for(int i = Balls.Count - 1; i >= 0; i--)
            {
                if (Balls[i].IsColided)
                {
                    Balls.RemoveAt(i);
                }
            }
        }

    }
}
