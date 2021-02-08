using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace breakout
{
    public partial class Form5 : Form
    {
        public int oxo = 0;
        public int oxt = 0;
        public int oxth = 0;
        public int txt = 0;
        public int txth = 0;
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
        int s1 = 0;
        int s2 = 0;
        int s3 = 0;
        int s4 = 0;
        int s5 = 0;
        int s6 = 0;
        int s7 = 0;
        int s8 = 0;
        int s9 = 0;
        int s10 = 0;

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

            s1 = rebound(pictureBox3, s1);
            pictureBox3.Left += s1;


            s2 = rebound(pictureBox4, s2);
            pictureBox4.Top += s2;

            s3 = rebound(pictureBox6, s3);
            pictureBox6.Left += s3;



            s4 = rebound(pictureBox7, s4);
            pictureBox7.Top += s4;



            s5 = rebound(pictureBox8, s5);
            pictureBox8.Left += s5;



            s6 = rebound(pictureBox9, s6);
            pictureBox9.Top += s6;


            s7 = rebound(pictureBox11, s7);
            pictureBox11.Left += s7;



            s8 = rebound(pictureBox12, s8);
            pictureBox12.Top += s8;



            s9 = rebound(pictureBox15, s9);
            pictureBox15.Left += s9;



            s10 = rebound(pictureBox14, s10);
            pictureBox14.Top += s10;


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
            if (ball.Bounds.IntersectsWith(pictureBox3.Bounds) && pictureBox3.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox4.Bounds) && pictureBox4.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox6.Bounds) && pictureBox6.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox7.Bounds) && pictureBox7.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox8.Bounds) && pictureBox8.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox9.Bounds) && pictureBox9.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox11.Bounds) && pictureBox11.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox12.Bounds) && pictureBox12.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox14.Bounds) && pictureBox14.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
            if (ball.Bounds.IntersectsWith(pictureBox15.Bounds) && pictureBox15.Visible)
            {
                Random r = new Random();
                vspeed = -vspeed;
                int x1 = r.Next(12, 500);
                int y1 = r.Next(100, 400);

            }
        end:;
        }

        private void Form5_MouseMove(object sender, MouseEventArgs e)
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

        private void Form5_KeyDown(object sender, KeyEventArgs e)
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

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            oxo = Form1.oxo;
            oxt = Form1.oxt;
            oxth = Form1.oxth;
            txt = Form1.txt;
            txth = Form1.txth;
            vspeed = 1;
            hspeed = 1;
            Random r = new Random();
            int x1 = r.Next(12, 500);
            int y1 = r.Next(100, 400);
            pictureBox3.Location = new Point(x1, y1);
            int x2 = r.Next(12, 500);
            int y2 = r.Next(100, 400);
            pictureBox4.Location = new Point(x2, y2);
            int x3 = r.Next(12, 500);
            int y3 = r.Next(100, 400);
            pictureBox6.Location = new Point(x3, y3);
            int x4 = r.Next(12, 500);
            int y4 = r.Next(100, 400);
            pictureBox7.Location = new Point(x4, y4);
            int x5 = r.Next(12, 500);
            int y5 = r.Next(100, 400);
            pictureBox8.Location = new Point(x5, y5);
            int x6 = r.Next(12, 500);
            int y6 = r.Next(100, 400);
            pictureBox9.Location = new Point(x6, y6);
            int x7 = r.Next(12, 500);
            int y7 = r.Next(100, 400);
            pictureBox11.Location = new Point(x7, y7);
            int x8 = r.Next(12, 500);
            int y8 = r.Next(100, 400);
            pictureBox12.Location = new Point(x8, y8);
            int x9 = r.Next(12, 500);
            int y9 = r.Next(100, 400);
            pictureBox14.Location = new Point(x9, y9);
            int x10 = r.Next(12, 500);
            int y10 = r.Next(100, 400);
            pictureBox15.Location = new Point(x10, y10);
            if (oxo == 1)
            {
                pictureBox4.Visible = false;
            }
            if (oxt == 1)
            {
                pictureBox6.Visible = false;
            }
            if (oxth == 1)
            {
                pictureBox8.Visible = false;
            }
            if (txt == 1)
            {
                pictureBox11.Visible = false;
            }
            if (txth == 1)
            {
                pictureBox14.Visible = false;
            }
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
            while (ball.Bounds.IntersectsWith(pictureBox3.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox4.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox6.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox7.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox8.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox9.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox11.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox12.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox14.Bounds)
                || ball.Bounds.IntersectsWith(pictureBox15.Bounds))
            {
                int newx = ram.Next(1, 643);
                int newy = ram.Next(200, 300);
                ball.Location = new Point(newx, newy);
            }
            s1 = ram.Next(1, 5);
            s2 = ram.Next(1, 5);
            s3 = ram.Next(1, 5);
            s4 = ram.Next(1, 5);
            s5 = ram.Next(1, 5);
            s6 = ram.Next(1, 5);
            s7 = ram.Next(1, 5);
            s8 = ram.Next(1, 5);
            s9 = ram.Next(1, 5);
            s10 = ram.Next(1, 5);
            this.ball.Show();
            Controls.Add(ball);
            ball.BringToFront();
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
        private int rebound(PictureBox picbox, int var)
        {
            if (picbox.Bounds.IntersectsWith(pictureBox2.Bounds)
                || picbox.Bounds.IntersectsWith(pictureBox5.Bounds)
                || picbox.Bounds.IntersectsWith(pictureBox10.Bounds)
                || picbox.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                var -= 2 * var;
            }
            return var;
        }
    }
}
        