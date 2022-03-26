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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBox t = new TextBox();
            t.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Player player = Player.getInstance();
                player.setUsername(textBox1.Text);
                
                this.Hide();
                new Form3().ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Username text box can not be empty.",
                                "Add username",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            
        }

    }
}
