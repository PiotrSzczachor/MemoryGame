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
        List<PictureBox> Clicekd = new List<PictureBox>();
        List<string> FilesNames = null;
        List<string> CardsNames = null;

        public Form3()
        {
            InitializeComponent();

            int iterations = Settings.getInstance().getNumberOfCards();

            getCardsAndFilesNames();
            TableLayoutPanel cardsTable = new TableLayoutPanel();

            for (int i=0; i<iterations; i++)
            {
                if (iterations == 48)
                {
                    MakeTableLayoutPanel(4, 12, cardsTable);

                    PictureBox card = new PictureBox
                    {
                        Name = CardsNames[i],
                        Size = new Size(112, 175),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[i]
                    };
                    card.Click += (s, e) => { card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\"+card.Tag.ToString()); };
                    Cardslist.Add(card);

                }
                if (iterations == 96)
                {
                    MakeTableLayoutPanel(6, 16, cardsTable);

                    //Do zmiany
                    PictureBox picture = new PictureBox
                    {
                        Name = "hiddenCard",
                        Size = new Size(75, 116),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Cardslist.Add(picture);
                }
                if (iterations == 120)
                {
                    MakeTableLayoutPanel(8, 15, cardsTable);

                    //Do zmiany
                    PictureBox picture = new PictureBox
                    {
                        Name = "hideCard",
                        Size = new Size(56, 88),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    Cardslist.Add(picture);
                }
            }


            foreach (PictureBox p in Cardslist)
            {
                cardsTable.Controls.Add(p);
            }
            

        }

        private void MakeTableLayoutPanel(int rows, int cols, TableLayoutPanel tableLayoutPanel_)
        {
            tableLayoutPanel_.RowCount = rows;
            tableLayoutPanel_.ColumnCount = cols;
            tableLayoutPanel_.BackColor = Color.Transparent;
            tableLayoutPanel_.AutoSize = true;
            tableLayoutPanel_.Location = new Point(70, 70);

            tableLayoutPanel_.RowStyles.Clear();
            tableLayoutPanel_.ColumnStyles.Clear();

            Controls.Add(tableLayoutPanel_);

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
