using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace breakout
{
    public partial class Form2 : Form
    {
        public bool started = false;
        public int s = 0;
        public int vspeed = 1;
        public int hspeed = 1;
        public bool win = false;
        public readonly int row = 5, col = 7;
        public int point = 0;
        public bool stop = false;
        public int x = 0, y = 0;
        public PictureBox[,] blocks;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            vspeed = 1;
            hspeed = 1;
            Random r = new Random();
            int i = r.Next(1, 2);
            if (i == 1)
            {
                hspeed = -hspeed;
            }
            setblocks();
            Random ram = new Random();
            int x = ram.Next(1, 643);
            int y = ram.Next(200, 300);
            ball.Location = new Point(x, y);
            this.ball.Show();
            Controls.Add(ball);
            ball.BringToFront();
            timer1.Enabled = false;
            timer2.Enabled = true;
            label1.BringToFront();
        }

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
            if (win == true)
            {
                timer1.Enabled = false;
                goto end;
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

        private void Form2_MouseMove(object sender, MouseEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
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
