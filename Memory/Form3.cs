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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
            if(Settings.getInstance().getCardsOpenTime() == 10)
            {
                label1.Text = "Easy";
            }
            if (Settings.getInstance().getCardsOpenTime() == 6)
            {
                label1.Text = "Medium";
            }
            if (Settings.getInstance().getCardsOpenTime() == 2)
            {
                label1.Text = "Hard";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
