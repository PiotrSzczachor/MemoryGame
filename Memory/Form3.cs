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

        List<PictureBox> Cardslist = new List<PictureBox>();
        List<string> FilesNames = null;
        List<string> CardsNames = null;

        public Form3()
        {
            InitializeComponent();

            int iterations = Settings.getInstance().getNumberOfCards();
 
            TableLayoutPanel table = null;

            getCardsAndFilesNames();

            for (int i=0; i<iterations; i++)
            {
                if (iterations == 48)
                {
                    table = MakeTableLayoutPanel(4, 12);
                    //table.Padding = GetCorrectionPadding(table, 4);
                    PictureBox picture = new PictureBox
                    {
                        Name = CardsNames[i],
                        Size = new Size(112,175),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\"+FilesNames[i]),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Cardslist.Add(picture);
                }
            }
            
            foreach(PictureBox p in Cardslist)
            {
                Console.WriteLine(p.Name);
                table.Controls.Add(p);
            }
            

        }

        private TableLayoutPanel MakeTableLayoutPanel(int rows, int cols)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = rows;
            tableLayoutPanel.BackColor = Color.Transparent;
            tableLayoutPanel.ColumnCount = cols;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.Location = new Point(70, 70);

            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            Controls.Add(tableLayoutPanel);
            
            return tableLayoutPanel;
        }


        private Padding GetCorrectionPadding(TableLayoutPanel TLP, int minimumPadding)
        {
            int minPad = minimumPadding;
            Rectangle netRect = TLP.ClientRectangle;
            netRect.Inflate(-minPad, -minPad);

            int w = netRect.Width / TLP.ColumnCount;
            int h = netRect.Height / TLP.RowCount;

            int deltaX = (netRect.Width - w * TLP.ColumnCount) / 2;
            int deltaY = (netRect.Height - h * TLP.RowCount) / 2;

            int OddX = (netRect.Width - w * TLP.ColumnCount) % 2;
            int OddY = (netRect.Height - h * TLP.RowCount) % 2;

            return new Padding(minPad + deltaX, minPad + deltaY,
                               minPad + deltaX + OddX, minPad + deltaY + OddY);
        }

        private void getCardsAndFilesNames()
        {
            DirectoryInfo dir1 = new DirectoryInfo(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\");
            FileInfo[] files = dir1.GetFiles("*.png", SearchOption.AllDirectories);

            //Saving files names with .png extension into FilesNames list

            if (FilesNames == null)
            {
                FilesNames = new List<string>();
            }
            else
            {
                FilesNames.Clear();
            }

            foreach (FileInfo f in files)
            {
                FilesNames.Add(f.Name);
            }

           //saving files names without .png extenxion but with _ at the end into CardsNames list

            if (CardsNames == null)
            {
                CardsNames = new List<string>();
            }
            else
            {
                CardsNames.Clear();
            }

            foreach (string s in FilesNames)
            {
                string[] parts = s.Split('.');
                CardsNames.Add(parts[0]+'_');
            }
            

        }

        //Adding PictureBoxes to Controls
            private void drawCards()
        {
            foreach (PictureBox picture in Cardslist)
            {
                Controls.Add(picture);
            }
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
    }
}
