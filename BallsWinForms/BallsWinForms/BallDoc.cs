using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsWinForms
{
    public class BallDoc
    {
        public List<Ball> balls { get; set; }

        public BallDoc()
        {
            balls = new List<Ball>();
        }

        public void AddBall(Ball b)
        {
            balls.Add(b);
        }

        public void Draw(Graphics g)
        {
            foreach(Ball obj in balls)
            {
                obj.Draw(g);
            }
        }

    }
}
