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

namespace FlyingBalls
{
    public partial class Form1 : Form
    {
        private int y;
        public BallDoc doc { get; set; }
        private String FileName;
        private bool Go;
        public Form1()
        {
            InitializeComponent();
            doc = new BallDoc();
            timer1.Start();
            timer2.Start();
            DoubleBuffered = true;
            Go = true;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            doc.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Go)
            {
                doc.Move();
                doc.IsOut(Width);
            }
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Go)
            {
                Random r = new Random();
                y = r.Next(90, Height - 90);
                Ball b = new Ball(new Point(-20, y));
                doc.AddBall(b);
            }
            Invalidate(true);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Go)
            {
                doc.IsHit(e.Location);
            }
            Invalidate(true);
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Hits: {0} Miss: {1}", doc.Hits, doc.Miss);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Save your FUCKING file *.fck | *.fck";
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
                    fi.Serialize(fs, doc);
                }
                catch
                {
                    throw new Exception("Invalid!");
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doc = new BallDoc();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Open your balls *.fck | *.fck";
                dialog.Title = "Open your balls";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = dialog.FileName;
                }
            }

            if(FileName != null)
            {
                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    IFormatter fi = new BinaryFormatter();
                    doc = (BallDoc)fi.Deserialize(fs);
                }
                catch
                {
                    throw new Exception("Invalid!");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Go = !Go;

            if (Go)
            {
                toolStripButton1.Text = "Стоп";
            }
            else
            {
                toolStripButton1.Text = "Старт";
            }
        }
    }
}
