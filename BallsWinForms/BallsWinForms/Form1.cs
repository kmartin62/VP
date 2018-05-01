using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsWinForms
{
    public partial class Form1 : Form
    {
        public BallDoc balls { get; set; }
        Random rand;

        public Form1()
        {
            balls = new BallDoc();
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Ball b = new Ball(e.Location, Color.Red);
                balls.AddBall(b);
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
            balls.Draw(e.Graphics);
        }
    }
}
