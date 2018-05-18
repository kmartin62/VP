using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfCircles
{
    [Serializable]
    public class HalfCircleDoc
    {
        public List<HalfCircle> circles { get; set; }

        public HalfCircleDoc()
        {
            circles = new List<HalfCircle>();
        }

        public void Draw(Graphics g)
        {
            foreach(HalfCircle c in circles)
            {
                c.Draw(g);
            }
        }

        public void Add(HalfCircle c)
        {
            circles.Add(c);
        }

        public void Pulse()
        {
            foreach(HalfCircle c in circles)
            {
                c.Pulse();
            }
        }
    }
}
