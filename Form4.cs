using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace breakout
{
    public partial class Form4 : Form
    {
        public int portal_number = 0;
        public Random ram = new Random();
        public bool started = false;
        public int s = 0;
        public int vspeed = 1;
        public int hspeed = 1;
        public bool win = false;
        public readonly int row = 5, col = 7;
        public int point = 0;
        public bool stop = false;
        public int x = 0, y = 0;
        public int pe = 0;
        public PictureBox[,] blocks;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (point == 35)
            {
                MessageBox.Show("You win!");
                var result = MessageBox.Show("Do you want to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                    goto end;
                }
                else
                {
                    Application.Exit();
                    goto end;
                }
            }
            if (win)
            {
                timer1.Enabled = false;
                goto end;
            }
            if (pe == 0)
            {
                if (ball.Bounds.IntersectsWith(p1.Bounds))
                {
                    ball.Location = p2.Location;
                    timer3.Enabled = true;
                    int p1x = ram.Next(1, 643);
                    int p1y = ram.Next(150, 325);
                    p1.Location = new Point(p1x, p1y);
                }
                if (ball.Bounds.IntersectsWith(p2.Bounds))
                {
                    ball.Location = p1.Location;
                    timer3.Enabled = true;
                    int p2x = ram.Next(1, 643);
                    int p2y = ram.Next(150, 325);
                    p2.Location = new Point(p2x, p2y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox2.Bounds) && pictureBox2.Visible)
                {
                    ball.Location = pictureBox3.Location;
                    timer3.Enabled = true;
                    int p1x = ram.Next(1, 643);
                    int p1y = ram.Next(150, 325);
                    pictureBox2.Location = new Point(p1x, p1y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox3.Bounds) && pictureBox3.Visible)
                {
                    ball.Location = pictureBox2.Location;
                    timer3.Enabled = true;
                    int p2x = ram.Next(1, 643);
                    int p2y = ram.Next(150, 325);
                    pictureBox3.Location = new Point(p2x, p2y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox4.Bounds) && pictureBox4.Visible)
                {
                    ball.Location = pictureBox5.Location;
                    timer3.Enabled = true;
                    int p1x = ram.Next(1, 643);
                    int p1y = ram.Next(150, 325);
                    pictureBox4.Location = new Point(p1x, p1y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox5.Bounds) && pictureBox5.Visible)
                {
                    ball.Location = pictureBox4.Location;
                    timer3.Enabled = true;
                    int p2x = ram.Next(1, 643);
                    int p2y = ram.Next(150, 325);
                    pictureBox5.Location = new Point(p2x, p2y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox6.Bounds) && pictureBox6.Visible)
                {
                    ball.Location = pictureBox7.Location;
                    timer3.Enabled = true;
                    int p1x = ram.Next(1, 643);
                    int p1y = ram.Next(150, 325);
                    pictureBox6.Location = new Point(p1x, p1y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox7.Bounds) && pictureBox7.Visible)
                {
                    ball.Location = pictureBox6.Location;
                    timer3.Enabled = true;
                    int p2x = ram.Next(1, 643);
                    int p2y = ram.Next(150, 325);
                    pictureBox7.Location = new Point(p2x, p2y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox8.Bounds) && pictureBox8.Visible)
                {
                    ball.Location = pictureBox9.Location;
                    timer3.Enabled = true;
                    int p1x = ram.Next(1, 643);
                    int p1y = ram.Next(150, 325);
                    pictureBox8.Location = new Point(p1x, p1y);
                }
                if (ball.Bounds.IntersectsWith(pictureBox9.Bounds) && pictureBox9.Visible)
                {
                    ball.Location = pictureBox8.Location;
                    timer3.Enabled = true;
                    int p2x = ram.Next(1, 643);
                    int p2y = ram.Next(150, 325);
                    pictureBox9.Location = new Point(p2x, p2y);
                }
            }
            if (ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                timer1.Enabled = false;
                MessageBox.Show("You lose!");
                win = true;
                var result = MessageBox.Show("Do you want to play again?", "Play again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                    goto end;
                }
                else
                {
                    Application.Exit();
                    goto end;
                }
            }
            ball.Top += vspeed;
            ball.Left += hspeed;
            if (ball.Bottom > this.ClientSize.Height)
            {
                vspeed -= 2 * vspeed;
            }
            if (ball.Top < 0)
            {
                vspeed -= 2 * vspeed;
            }
            if (ball.Right > this.ClientSize.Width)
            {
                hspeed -= 2 * hspeed;
            }
            if (ball.Left < 0)
            {
                hspeed -= 2 * hspeed;
            }
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                vspeed -= 2 * vspeed;
            }
            for (int x = 0; x < row; ++x)
            {
                for (int y = 0; y < col; ++y)
                {
                    if (ball.Bounds.IntersectsWith(blocks[x, y].Bounds) && blocks[x, y].Visible)
                    {
                        point++;
                        vspeed -= 2 * vspeed;
                        paddle.Width -= 3;
                        hspeed++;
                        vspeed++;
                        blocks[x, y].Visible = false;
                    }
                }
            }
        end:;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (stop)
            {
                goto te;
            }
            paddle.Left = e.X - (paddle.Width / 2);
        te:;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            s++;
            switch (s)
            {
                case 1:
                    label1.Text = "3";
                    break;
                case 2:
                    label1.Text = "2";
                    break;
                case 3:
                    label1.Text = "1";
                    break;
                case 4:
                    label1.Text = "";
                    timer1.Enabled = true;
                    label1.Location = new Point(200, 254);
                    started = true;
                    break;
            }
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (started)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (stop == false)
                    {
                        stop = true;
                        timer1.Stop();
                        label1.Text = "Game is stop!";
                    }
                    else
                    {
                        stop = false;
                        timer1.Start();
                        label1.Text = "";
                    }
                }
            }
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pe++;
            if (pe > 50)
            {
                pe = 0;
                timer3.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void p1_Click(object sender, EventArgs e)
        {

        }

        
        private void Form4_Load(object sender, EventArgs e)
        {
            portal_number = Form1.portalno;
            vspeed = 1;
            hspeed = 1;
            Random r = new Random();
            int i = r.Next(1, 2);
            if (i == 1)
            {
                hspeed = -hspeed;
            }
            else
            {
                hspeed = 1;
            }
            setblocks();
            Random ram = new Random();
            int x = ram.Next(1, 643);
            int y = ram.Next(200, 300);
            ball.Location = new Point(x, y);
            this.ball.Show();
            Controls.Add(ball);
            ball.BringToFront();
            int p1x = ram.Next(1, 643);
            int p1y = ram.Next(150, 300);
            int p2x = ram.Next(1, 643);
            int p2y = ram.Next(150, 300);
            p1.Location = new Point(p1x, p1y);
            p2.Location = new Point(p2x, p2y);
            if (portal_number >= 2)
            {
                int p3x = ram.Next(1, 643);
                int p3y = ram.Next(150, 325);
                int p4x = ram.Next(1, 643);
                int p4y = ram.Next(150, 325);
                pictureBox2.Location = new Point(p3x, p3y);
                pictureBox3.Location = new Point(p4x, p4y);
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
            }
            if (portal_number >= 3)
            {
                int p5x = ram.Next(1, 643);
                int p5y = ram.Next(150, 325);
                int p6x = ram.Next(1, 643);
                int p6y = ram.Next(150, 325);
                pictureBox4.Location = new Point(p5x, p5y);
                pictureBox5.Location = new Point(p6x, p6y);
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
            }
            if (portal_number >= 4)
            {
                int p7x = ram.Next(1, 643);
                int p7y = ram.Next(150, 325);
                int p8x = ram.Next(1, 643);
                int p8y = ram.Next(150, 325);
                pictureBox6.Location = new Point(p7x, p7y);
                pictureBox7.Location = new Point(p8x, p8y);
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
            }
            if (portal_number == 5)
            {
                int p9x = ram.Next(1, 643);
                int p9y = ram.Next(150, 325);
                int p10x = ram.Next(1, 643);
                int p10y = ram.Next(150, 325);
                pictureBox8.Location = new Point(p9x, p9y);
                pictureBox9.Location = new Point(p10x, p10y);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
            }
            timer1.Enabled = false;
            timer2.Enabled = true;
            label1.BringToFront();
        }
        private void setblocks()
        {
            int h = 25, w = 95;
            blocks = new PictureBox[row, col];
            for (x = 0; x < row; ++x)
            {
                for (y = 0; y < col; ++y)
                {
                    blocks[x, y] = new PictureBox();
                    blocks[x, y].Width = w;
                    blocks[x, y].Height = h;
                    blocks[x, y].Top = h * x;
                    blocks[x, y].Left = w * y;
                    blocks[x, y].BackColor = Color.White;
                    blocks[x, y].BorderStyle = BorderStyle.FixedSingle;
                    blocks[x, y].Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                    Controls.Add(blocks[x, y]);
                }
            }
        }
    }
}
