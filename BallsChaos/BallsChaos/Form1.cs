using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsChaos
{
    public partial class Form1 : Form
    {
        public BallDoc Balls { get; set; }

        int left;
        int top;
        int width;
        int height;

        public Form1()
        {
            InitializeComponent();
            Balls = new BallDoc();
            this.DoubleBuffered = true;
            left = 20;
            top = 60;
            width = this.Width - (3 * left);
            height = this.Height - (int)(2.5 * top);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Balls.Move(left, top, width, height);
            Balls.CheckCollisions();
            Invalidate(true);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Ball b = new Ball(e.Location, Color.Red);
            Balls.AddBall(b);
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), left, top, width, height);
            Balls.Draw(e.Graphics);
        }
    }
}
