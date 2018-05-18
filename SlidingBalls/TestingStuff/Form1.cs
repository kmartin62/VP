using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingStuff
{
    public partial class Form1 : Form
    {
        public BallDoc doc { get; set; }
        private bool test;
        public Color color { get; set; }
        private int b;
        private int k;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            doc = new BallDoc();
            timer1.Start();
            test = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                doc.AddRed(new Ball(e.Location, Color.Red));
                b = doc.redballs.Count;
            }

            if (test)
            {
                if (e.Button == MouseButtons.Left)
                {
                    test = false;
                    //b = doc.redballs.Count;
                    doc.Check(e.Location);

                }
            }

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            doc.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!test)
            {
                doc.Move();
                doc.CheckOut(Width, Height);
                doc.CheckColliding();
                
                if(doc.redballs.Count == b - 1)
                {
                    test = true;
                    b--;
                }
            }
            
            
            Invalidate();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            k = r.Next(2);
            if(k == 0)
            {
                doc.Add(new Ball(e.Location, Color.Blue));
            }
            else
            {
                doc.Add(new Ball(e.Location, Color.Green));
            }

            Invalidate();
        }
    }
}
