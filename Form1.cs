using System;
using System.IO;
using System.Windows.Forms;

namespace breakout
{
    public partial class Form1 : Form
    {
        public static int portalno = 0;
        public static int oxo = 0;
        public static int oxt = 0;
        public static int oxth = 0;
        public static int txt = 0;
        public static int txth = 0;
        public static int gm = 1;
        public int vspeed = 1;
        public int hspeed = 1;
        public bool win = false;
        public readonly int row = 5, col = 7;
        public int point = 0;
        public bool stop = false;
        public int x = 0, y = 0;
        public PictureBox[,] blocks;
        public bool donotopenabout = false;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gt = "";
            portalno = Convert.ToInt32(numericUpDown1.Value);
            oxo = Convert.ToInt32(numericUpDown2.Value);
            oxt = Convert.ToInt32(numericUpDown3.Value);
            oxth = Convert.ToInt32(numericUpDown4.Value);
            txt = Convert.ToInt32(numericUpDown5.Value);
            txth = Convert.ToInt32(numericUpDown6.Value);
            try
            {
                try
                {
                    gt = comboBox1.SelectedItem.ToString();
                }
                catch
                {
                    MessageBox.Show("You didn't choose anything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto ed;
                }
                switch (gt)
                {
                    case "Simple":
                        Form2 f2 = new Form2();
                        f2.Show();
                        break;
                    case "Portal":
                        Form4 f4 = new Form4();
                        f4.Show();
                        break;
                    case "Obstacle":
                        Form5 f5 = new Form5();
                        f5.Show();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("You didn't choose anything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto ed;
            }
        ed:;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string gt = comboBox1.SelectedItem.ToString();
            switch (gt)
            {
                case "Simple":
                    label3.Visible = false;
                    numericUpDown1.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    numericUpDown2.Visible = false;
                    numericUpDown3.Visible = false;
                    numericUpDown4.Visible = false;
                    numericUpDown5.Visible = false;
                    numericUpDown6.Visible = false;
                    break;
                case "Portal":
                    label3.Visible = true;
                    numericUpDown1.Visible = true;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    numericUpDown2.Visible = false;
                    numericUpDown3.Visible = false;
                    numericUpDown4.Visible = false;
                    numericUpDown5.Visible = false;
                    numericUpDown6.Visible = false;
                    break;
                case "Obstacle":
                    label3.Visible = false;
                    numericUpDown1.Visible = false;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    numericUpDown2.Visible = true;
                    numericUpDown3.Visible = true;
                    numericUpDown4.Visible = true;
                    numericUpDown5.Visible = true;
                    numericUpDown6.Visible = true;
                    break;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            comboBox1.SelectedItem = "Simple";
            try
            {
                FileStream file = new FileStream("App Setting\\dns.bgd", FileMode.Open);
                StreamReader sr = new StreamReader(file);
                if (Convert.ToString(sr.ReadToEnd()) == "true")
                {
                    donotopenabout = true;
                }
                file.Close();
                sr.Close();
                if (donotopenabout == false)
                {
                    Form6 f = new Form6();
                    f.ShowDialog();
                }
                
            }
            catch
            {
                MessageBox.Show("You may accidently removed or renamed or replaced the \" App Setting\" file, try to redownload the whole folder again!!\nDO NOT CONTINUE TO RUN THIS APPLICATION AGAIN UNTILL YOU REDOWNLOAD THE WHOLE FOLDER!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
