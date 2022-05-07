using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form3 : Form
    {
        
        TableLayoutPanel cardsTable = new TableLayoutPanel();
        
        public Form3()
        {
            InitializeComponent();
            Game game = new Game(this);
            game.start(button1, label2, cardsTable, timer1, timer2, label1);
            
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Changing CardsOpenTime while playing
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.getInstance().setCardsOpenTime(10);
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.getInstance().setCardsOpenTime(6);
        }

        private void secToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings.getInstance().setCardsOpenTime(2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(this);
            game.handleButton(timer1, button1);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
