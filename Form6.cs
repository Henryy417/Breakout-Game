using System;
using System.Windows.Forms;
using System.IO;
namespace breakout
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = "Breakout Game (Version 1.5)  Copyright (C) 2020  Chen Hang Tsz\nThis application comes with ABSOLUTELY NO WARRANTY.\nThis is free and open-source software, \nand you are welcome to redistribute itunder certain conditions.\nThe uses and/or operations of Breakout Game (Version 1.5) \nis bound by GNU GENERAL PUBLIC LICENSE (Version 3)\nYou MUST agree to the GNU General Public License (Version 3) to use this application!\nIf you don't read GNU GENERAL PUBLIC LICENSE (Version 3), \nyou may use this application in an infringing manner, the author will take legal actions!\nIf the file is unopenanle, please go to  https://www.gnu.org/licenses/gpl-3.0.en.html. \nFor other languages, please visit https://www.gnu.org/licenses/translations.html";
            FileStream file = new FileStream("App Setting\\dns.bgd", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            if (Convert.ToString(sr.ReadToEnd()) == "true")
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                button1.Visible = false;
            }
            file.Close();
            sr.Close();
            file.Close();
            sr.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("App Setting\\License.txt");
            }
            catch
            {
                MessageBox.Show("You may accidently removed or renamed or replaced the \" App Setting\" file, try to redownload the whole folder again!!\nDO NOT CONTINUE TO RUN THIS APPLICATION AGAIN UNTILL YOU REDOWNLOAD THE WHOLE FOLDER!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                FileStream file = new FileStream("App Setting\\dns.bgd", FileMode.Open);
                StreamReader sr = new StreamReader(file);
                if (sr.ReadToEnd() == "")
                {
                    file.Close();
                    sr.Close();
                    StreamWriter str = new StreamWriter("App Setting\\dns.bgd");
                    str.Write("true");
                    str.Close();
                }
                file.Close();
                sr.Close();
            }

            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
