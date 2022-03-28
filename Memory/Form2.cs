using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                checkBox1.Checked = true;
                MessageBox.Show("You need to set one of difficulty",
                                "Set difficulty",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            } else
            {
                if(checkBox1.Checked == true)
                {
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                settings.setNumberOfCards(48);
                }
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                checkBox2.Checked = true;
                MessageBox.Show("You need to set one of difficulty",
                                "Set difficulty",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if(checkBox2.Checked == true)
                {
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    settings.setNumberOfCards(96);
                }
                
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                checkBox3.Checked = true;
                MessageBox.Show("You need to set one of difficulty",
                                "Set difficulty",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox3.Checked == true)
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    settings.setNumberOfCards(120);
                }

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                checkBox4.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox4.Checked == true)
                {
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    settings.setInitialTime(120);
                }

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                checkBox5.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox5.Checked == true)
                {
                    checkBox4.Checked = false;
                    checkBox6.Checked = false;
                    settings.setInitialTime(60);
                }

            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                checkBox6.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox6.Checked == true)
                {
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    settings.setInitialTime(0);
                }

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false)
            {
                checkBox7.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox7.Checked == true)
                {
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                    settings.setCardsOpenTime(10);
                }

            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false)
            {
                checkBox8.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox8.Checked == true)
                {
                    checkBox7.Checked = false;
                    checkBox9.Checked = false;
                    settings.setCardsOpenTime(6);
                }

            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.getInstance();
            if (checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false)
            {
                checkBox9.Checked = true;
                MessageBox.Show("You need to set one of avable Initial times",
                                "Set Initial Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox9.Checked == true)
                {
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    settings.setCardsOpenTime(2);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        
    }
}
