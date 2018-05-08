using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman3.Properties;

namespace Pacman3
{
    public partial class Form1 : Form
    {

        Pacman pacman;
        Timer timer;
        int TIMER_INTERVAL = 500;
        Image foodImage = Resources.orange;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        bool[][] foodWorld;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            newGame();
        }

        private void newGame()
        {
            pacman = new Pacman();
            foodWorld = new bool[WORLD_HEIGHT][];
            for (int i = 0; i < foodWorld.Length; i++)
            {
                foodWorld[i] = new bool[WORLD_HEIGHT];
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    foodWorld[i][j] = true;
                }
            }

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TIMER_INTERVAL;
            timer.Start();
            this.Width = pacman.RADIUS * 2 * (WORLD_WIDTH + 1) - 25;
            this.Height = pacman.RADIUS * 2 * (WORLD_HEIGHT + 1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < foodWorld.Length; i++)
            {
                for(int j = 0; j < foodWorld[i].Length; j++)
                {
                    if(pacman.X == j && pacman.Y == i)
                    {
                        foodWorld[i][j] = false;
                    }
                }
                
            }
            pacman.Move(WORLD_WIDTH, WORLD_HEIGHT);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (foodWorld[i][j])
                    {
                        // g.DrawImageUnscaled(foodImage, j * pacman.RADIUS * 3 + (pacman.RADIUS * 2 - foodImage.Height) / 2, i * pacman.RADIUS * 2 + (pacman.RADIUS * 2 - foodImage.Width) / 2);
                        g.DrawImageUnscaled(foodImage, j*pacman.RADIUS*3, i*pacman.RADIUS*2);
                    }
                }
            }
            pacman.Draw(g);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.UP);
            }

            if (e.KeyCode == Keys.Down)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.DOWN);
            }

            if (e.KeyCode == Keys.Left)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.LEFT);
            }

            if (e.KeyCode == Keys.Right)
            {
                pacman.ChangeDirection(Pacman.DIRECTION.RIGHT);
            }

            Invalidate();
        }
    }
}
