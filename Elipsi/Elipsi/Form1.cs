using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elipsi
{
    public partial class Form1 : Form
    {
        public EllipseDoc elipsi { get; set; }
        public Point firstPoint { get; set; }
        public Point secondPoint { get; set; }

        string FileName;
        int x, y, width, height;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            secondPoint = e.Location;

            x = firstPoint.X;
            y = firstPoint.Y;

            if (x > secondPoint.X) x = secondPoint.X;
            if (y > secondPoint.Y) y = secondPoint.Y;

            width = Math.Abs(firstPoint.X - secondPoint.X);
            height = Math.Abs(firstPoint.Y - secondPoint.Y);

            Invalidate(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elipsi.ChangeColor();
            Invalidate(true);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Save your file *.ell | *.ell";
                dialog.Title = "Save your file";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName;
                }
            }

            if(FileName != null)
            {
                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Create);
                    IFormatter fi = new BinaryFormatter();
                    fi.Serialize(fs, elipsi);
                }
                catch
                {
                    throw new Exception("Invalid!");
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Open your file *.ell | *.ell";
            dialog.Title = "Open your file";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    IFormatter fi = new BinaryFormatter();
                    elipsi = (EllipseDoc)fi.Deserialize(fs);
                }
                catch
                {
                    throw new Exception("Invalid!");
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (firstPoint.IsEmpty)
            {
                firstPoint = e.Location;
            }
            else
            {
                elipsi.Add(new Ellipse(width, height, new Point(x, y)));
                firstPoint = Point.Empty;
                secondPoint = Point.Empty;
            }

            Invalidate(true);
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            elipsi = new EllipseDoc();
            DoubleBuffered = true;
            firstPoint = Point.Empty;
            secondPoint = Point.Empty;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            elipsi.Draw(e.Graphics);

            if (!firstPoint.IsEmpty)
            {
                Pen p = new Pen(Color.Black, 3);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawEllipse(p, x, y, width, height);
                p.Dispose();
            }
        }
    }
}
