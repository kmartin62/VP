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

namespace BallsInHoles
{
    public partial class Form1 : Form
    {

        private string FileName;
        public GlobalDoc ballsDoc { get; set; }
        public Color color { get; set; }
        public Form1()
        {
            color = Color.Red;
            ballsDoc = new GlobalDoc();
            InitializeComponent();
            this.DoubleBuffered = true;
            timer1.Start();
            ballsDoc.GenerateHoles();
            
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 3), 30, 30, 750, 400);
            ballsDoc.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ballsDoc.Move();
            ballsDoc.CheckCollision();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ballsDoc.AddBall(new Ball(e.Location, color));
            Invalidate(true);
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog() == DialogResult.OK)
            {
                color = c.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Balls doc files (*.bll) | *.bll";
                sv.Title = "Save your file";

                if(sv.ShowDialog() == DialogResult.OK)
                {
                    FileName = sv.FileName;
                }
            }

            if(FileName != null)
            {
                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Create);
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, ballsDoc);
                }
                catch
                {
                    throw new Exception("File cannot be saved!");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                OpenFileDialog sv = new OpenFileDialog();
                sv.Filter = "Balls doc files (*.bll) | *.bll";
                sv.Title = "Open your file";

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    FileName = sv.FileName;
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        ballsDoc = (GlobalDoc)formatter.Deserialize(fs);
                    }
                    catch
                    {
                        throw new Exception("File cannot be saved!");
                    }
                }
            

            
        }
    }
}
