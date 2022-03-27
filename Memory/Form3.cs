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

        List<PictureBox> Cardslist = new List<PictureBox>();
        public Form3()
        {
            InitializeComponent();
            
            int iterations = Settings.getInstance().getNumberOfCards();
            int x = 10;
            int y = 10;
            for (int i=1; i<=iterations; i++)
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
            DrawCards();
        }

        private void DrawCards()
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
    }
}
