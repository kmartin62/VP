using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    [Serializable]
    public class BallDoc
    {
        public List<Ball> topcinja { get; set; }
        public int Hits { get; set; }
        public int Miss { get; set; }

        public BallDoc()
        {
            topcinja = new List<Ball>();
            Hits = 0;
            Miss = 0;
        }

        public void AddBall(Ball b)
        {
            topcinja.Add(b);
        }

        public void Draw(Graphics g)
        {
            foreach(Ball b in topcinja)
            {
                b.Draw(g);
            }
        }

        public void Move()
        {
            foreach(Ball b in topcinja)
            {
                b.Move();
            }
        }

        public void IsHit(Point p)
        {
            foreach(Ball b in topcinja)
            {
                if (b.IsHit(p))
                {
                    b.Status--;
                }
            }

            ShouldGo();
        }

        public void ShouldGo()
        {
            for(int i = 0; i < topcinja.Count; i++)
            {
                if(topcinja[i].Status < 0)
                {
                    topcinja.RemoveAt(i);
                    Hits++;
                }
            }
        }

        public void IsOut(int width)
        {
            for(int i = 0; i < topcinja.Count; i++)
            {
                if(topcinja[i].Centar.X + 30 > width)
                {
                    topcinja[i].IsOut = true;
                }
            }

            for(int i = topcinja.Count - 1; i >= 0; i--)
            {
                if (topcinja[i].IsOut)
                {
                    topcinja.RemoveAt(i);
                    Miss++;
                }
            }
        }
    }
}
