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

namespace HalfCircles
{
    public partial class Form1 : Form
    {
        // HalfCircle hc = new HalfCircle(new Point(50, 50));
        private HalfCircleDoc doc;
        private bool Start;
        private String FileName;
        public Form1()
        {
            InitializeComponent();
            doc = new HalfCircleDoc();
            //timer1.Start();
            Start = false;
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            doc.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Start)
            {
                doc.Pulse();
                Invalidate(true);
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            doc.Add(new HalfCircle(e.Location));
            Invalidate(true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Start = !Start;

            if (Start)
            {
                toolStripLabel1.Text = "Стоп";
            }
            else
            {
                toolStripLabel1.Text = "Старт";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Save your file *.hcc | *.hcc";
                dialog.Title = "Save your file";
                dialog.FileName = FileName;

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Open your file *.hcc | *.hcc";
            dialog.Title = "Open your file";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;

                try
                {
                    FileStream fs = new FileStream(FileName, FileMode.Open);
                    IFormatter fi = new BinaryFormatter();
                    doc = (HalfCircleDoc)fi.Deserialize(fs);
                }
                catch
                {
                    throw new Exception("Invalid");
                }
            }
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Total: {0}", doc.circles.Count);
        }
    }
}
