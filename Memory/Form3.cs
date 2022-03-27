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
            int x = 10;
            int y = 10;
            /*for (int i=1; i<=iterations; i++)
            {
                if (iterations == 48)
                {
                    PictureBox picture = new PictureBox
                    {
                        Name = "card",
                        Size = new Size(100,50),
                        Location = new Point(x, y),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\card.png"),
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };
                    Cardslist.Add(picture);
                    x+=55;
                    if(i % 12 == 0)
                    {
                        Console.WriteLine(i.ToString());
                        y += 105;
                        x = 10;
                    }
                }
                if (iterations == 96)
                {
                    PictureBox picture = new PictureBox
                    {
                        Name = "card",
                        Size = new Size(100, 50),
                        Location = new Point(x, y),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\card.png"),
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };
                    Cardslist.Add(picture);
                    x += 55;
                    if (i % 12 == 0)
                    {
                        Console.WriteLine(i.ToString());
                        y += 105;
                        x = 10;
                    }

                }
                if (iterations == 96)
                {
                    PictureBox picture = new PictureBox
                    {
                        Name = "card",
                        Size = new Size(100, 50),
                        Location = new Point(x, y),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\card.png"),
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };
                    Cardslist.Add(picture);
                    x += 55;
                    if (i % 12 == 0)
                    {
                        Console.WriteLine(i.ToString());
                        y += 105;
                        x = 10;
                    }

                }
            }
            drawCards();*/
            getCardsAndFilesNames();
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
