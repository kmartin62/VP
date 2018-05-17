using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elipsi
{
    [Serializable]
    public class EllipseDoc
    {
        public List<Ellipse> Ellipses { get; set; }

        public EllipseDoc()
        {
            Ellipses = new List<Ellipse>();
        }

        public void Draw(Graphics g)
        {
            foreach(Ellipse e in Ellipses)
            {
                e.Draw(g);
            }
        }

        public void Add(Ellipse e)
        {
            Ellipses.Add(e);
        }

        public void ChangeColor()
        {
            foreach(Ellipse c in Ellipses)
            {
                c.ChangeColorr();
            }
        }
    }
}
