using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    [Serializable]
    public class GlobalDoc
    {
        public List<Hole> Holes { get; set; }
        public List<Ball> Balls { get; set; }
        public Random r { get; set; }

        public GlobalDoc()
        {
            Balls = new List<Ball>();
            Holes = new List<Hole>();
            r = new Random();
        }

        public void GenerateHolesR()
        {
            if (Holes.Count == 5) return;

            int x = r.Next(50, 700);
            int y = r.Next(50, 350);

            bool touch = false;

            foreach (Hole d in Holes)
            {
                touch = d.Colliding(new Hole(new Point(x, y)));

                if (touch) break;
            }

            if (!touch)
            {
                Holes.Add(new Hole(new Point(x, y)));
            }
            GenerateHolesR();


        }

        public void GenerateHoles()
        {
            GenerateHolesR();
        }

        public void Draw(Graphics g)
        {
            foreach(Hole h in Holes)
            {
                h.Draw(g);
            }

            foreach(Ball b in Balls)
            {
                b.Draw(g);
            }
        }

        public void AddBall(Ball b)
        {
            Balls.Add(b);
        }

        public void Move()
        {
            foreach(Ball b in Balls)
            {
                b.Move();
            }
        }

        public void CheckCollision()
        {
            for(int i = 0; i < Balls.Count; i ++)
            {
                for(int j = 0; j < Holes.Count; j ++)
                {
                    if (Balls[i].TouchHole(Holes[j]))
                    {
                        Balls[i].InHole = true;
                        Holes[j].Count++;
                    }
                }
            }

            for(int i = Balls.Count - 1; i >= 0; i--)
            {
                if (Balls[i].InHole)
                {
                    Balls.RemoveAt(i);
                }
            }
        }
    }
}
