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
        //List where randomly chosen cards are stored
        List<PictureBox> Cardslist = new List<PictureBox>();
        //List wich len is only 0, 1 or 2, it stores which cards user is checking right now
        List<PictureBox> Clicekd = new List<PictureBox>();

        List<string> FilesNames = null;
        List<string> CardsNames = null;

        int gameTime;
        int tryCounter;
        bool clikckAllowed = false;

        public Form3()
        {
            InitializeComponent();

            //Checking how many cards on the boarad user have chosen
            int iterations = Settings.getInstance().getNumberOfCards();

            //Getting all files and cards name from Cards folder
            getCardsAndFilesNames();

            TableLayoutPanel cardsTable = new TableLayoutPanel();
            List<int> usedIndexes = new List<int>();

            Random random = new Random();
            int index = random.Next(60);

            
            //Filling CardsList 
            for (int i=0; i<iterations/2; i++)
            {
                //Getting random indexes to randomize cards that will be in the game
                while (usedIndexes.Contains(index))
                {
                    index = random.Next(60);
                }
                //usedIndexes is a list of unique int number in range(0, numberOfAllCards)
                usedIndexes.Add(index);

                //48 cards game
                if (iterations == 48)
                {
                    //Initializing TableLayoutPanel with specific number of rows and columns for this type of game
                    MakeTableLayoutPanel(4, 12, cardsTable);

                    //Creating new picture box with hidden card image and name of source image in tag
                    PictureBox card = new PictureBox
                    {
                        Name = CardsNames[usedIndexes[i]],
                        Size = new Size(112, 175),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[usedIndexes[i]]
                    };
                    //Creating On_Click function to every card in the loop
                    card.Click += (s, e) => 
                    {
                        //If the card image=null thats mean that the card has been guessed so you can't click it one more time
                        if(card.Image != null && clikckAllowed)
                        {
                            //If len of Clicked list is less than 2, it means that we can chose first or second card and turn it over
                            if (Clicekd.Count < 2)
                            {
                                //Turning the card over
                                card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card.Tag.ToString());
                                //Adding card to Clicked list 
                                Clicekd.Add(card);
                            }
                            //If len of Clicked list is equal to 2, it means that user chose 2 cards and we need to check if it is pair or not
                            if (Clicekd.Count == 2)
                            {
                                clikckAllowed = false;
                                //Checking that the user did not choose the same card twice so we are comparing PictureBoxes names
                                //If first card tag is the same as second card tag, thats mean it is a pair
                                if (Clicekd[0].Tag == Clicekd[1].Tag && Clicekd[0].Name != Clicekd[1].Name)
                                {
                                    //Setting PictureBoxex image to null to make the cards disappeared from the board
                                    Clicekd[0].Image = null;
                                    Clicekd[1].Image = null;
                                }
                                //If it wasn't pair, wait CardsOpenTime
                                if (Clicekd[0].Tag != Clicekd[1].Tag)
                                {
                                    List<PictureBox> pictureBoxes = new List<PictureBox>();
                                    foreach(PictureBox p in Clicekd)
                                    {
                                        pictureBoxes.Add(p);
                                    }
                                    timer2.Enabled = true;
                                    DateTime time = DateTime.Now;
                                    timer2.Tick += (s_, e_) =>
                                    {
                                        TimeSpan actualTime = DateTime.Now.Subtract(time);
                                        int seconds = actualTime.Seconds;
                                        if (seconds == Settings.getInstance().getCardsOpenTime())
                                        {
                                            turnOver(pictureBoxes);
                                            clikckAllowed = true;
                                        }
                                        label2.Text = seconds.ToString();
                                        
                                    };

                                }
                                //Clearing Clicked list to use it one more time in the future user types
                                Clicekd.Clear();
                                tryCounter++;
                            }
                        }
                        
                    };
                    //Adding PictureBox with specific On_Click function into CardsList
                    Cardslist.Add(card);

                }
                //96 Cards game
                if (iterations == 96)
                {
                    //Initializing TableLayoutPanel with specific number of rows and columns for this type of game
                    MakeTableLayoutPanel(6, 16, cardsTable);

                    //Creating new picture box with hidden card image and name of source image in tag
                    PictureBox card = new PictureBox
                    {
                        Name = CardsNames[usedIndexes[i]],
                        Size = new Size(75, 116),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[usedIndexes[i]]
                    };
                    card.Click += (s, e) =>
                    {
                        if (Clicekd.Count < 2)
                        {
                            card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card.Tag.ToString());
                            Clicekd.Add(card);
                        }
                    };
                    Cardslist.Add(card);
                }
                //120 Cards game
                if (iterations == 120)
                {
                    //Initializing TableLayoutPanel with specific number of rows and columns for this type of game
                    MakeTableLayoutPanel(8, 15, cardsTable);

                    //Creating new picture box with hidden card image and name of source image in tag
                    PictureBox card = new PictureBox
                    {
                        Name = CardsNames[usedIndexes[i]],
                        Size = new Size(56, 88),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[usedIndexes[i]]
                    };
                    card.Click += (s, e) =>
                    {
                        if (Clicekd.Count < 2)
                        {
                            card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card.Tag.ToString());
                            Clicekd.Add(card);
                        }
                         
                    
                    };
                    Cardslist.Add(card);
                    
                }
            }

            List<PictureBox> cardsToPlay = new List<PictureBox>();

            foreach (PictureBox p in Cardslist)
            {
                PictureBox card_2 = new PictureBox
                {
                    Name = p.Name+"2",
                    Size = p.Size,
                    Image = p.Image,
                    SizeMode = p.SizeMode,
                    Tag =p.Tag
                };
                card_2.Click += (s, e) =>
                {
                    if (card_2.Image != null && clikckAllowed)
                    {
                        if (Clicekd.Count < 2)
                        {
                            card_2.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card_2.Tag.ToString());
                            Clicekd.Add(card_2);
                        }
                        if (Clicekd.Count == 2)
                        {
                            clikckAllowed = false;
                            if (Clicekd[0].Tag == Clicekd[1].Tag && Clicekd[0].Name != Clicekd[1].Name)
                            {
                                Clicekd[0].Image = null;
                                Clicekd[1].Image = null;
                            }
             
                            if (Clicekd[0].Tag != Clicekd[1].Tag)
                            {
                                List<PictureBox> pictureBoxes = new List<PictureBox>();
                                foreach (PictureBox p_ in Clicekd)
                                {
                                    pictureBoxes.Add(p_);
                                }
                                timer2.Enabled = true;
                                DateTime time = DateTime.Now;
                                timer2.Tick += (s_, e_) =>
                                {
                                    TimeSpan actualTime = DateTime.Now.Subtract(time);
                                    int seconds = actualTime.Seconds;
                                    if (seconds == Settings.getInstance().getCardsOpenTime())
                                    {
                                        clikckAllowed = true;
                                        turnOver(pictureBoxes);
                                    }
                                    label2.Text = seconds.ToString();
                                };
                            }
                            Clicekd.Clear();
                            tryCounter++;
                        }
                    }
                };
                cardsToPlay.Add(card_2);
                cardsToPlay.Add(p);
            }

            usedIndexes.Clear();

            index = random.Next(cardsToPlay.Count);

            for (int i=0; i < cardsToPlay.Count; i++)
            {
                while (usedIndexes.Contains(index))
                {
                    index = random.Next(cardsToPlay.Count);
                }
                usedIndexes.Add(index);
                cardsTable.Controls.Add(cardsToPlay[index]);
            }

            showCards(cardsTable);


        }

        private void countScore()
        {
            int initialScore = 1000000;
            initialScore = initialScore - gameTime;
            initialScore = initialScore - tryCounter;
            Player.getInstance().setScore(initialScore);
            TextWriter tsw = new StreamWriter(@"C:\Users\Piotr\source\repos\Memory\Memory\Rank.txt", true);
            //Writing user score to the file.
            tsw.WriteLine(Player.getInstance().getUsername() + ": " + Player.getInstance().getScore());
            //Close the file.
            tsw.Close();
        }

        private bool checkWin(TableLayoutPanel tlp)
        {
            bool win = true;
            foreach(PictureBox p in tlp.Controls)
            {
                if(p.Image != null)
                {
                    win = false;
                }
            }
            return win;
        }

        private void turnOver(List<PictureBox> list)
        {
            foreach(PictureBox p in list)
            {
                p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg");
            }
        }

        private void showCards(TableLayoutPanel tlp)
        {
            foreach(PictureBox p in tlp.Controls)
            {
                p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + p.Tag.ToString());
            }
            timer1.Enabled = true;
            DateTime time = DateTime.Now;
            timer1.Tick += (s, e) => 
            { 
                TimeSpan actualTime = DateTime.Now.Subtract(time);
                int seconds = actualTime.Seconds;
                int minutes = actualTime.Minutes;
                int hours = actualTime.Hours;
                if (seconds+minutes*60 == Settings.getInstance().getInitialTime()) {
                    foreach(PictureBox p in tlp.Controls)
                    {
                        p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg");
                        clikckAllowed = true;
                    }
                }
                label1.Text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
                gameTime = hours * 3600 + minutes * 60 + seconds;
                if (checkWin(tlp))
                {
                    timer1.Stop();
                    countScore();
                    this.Hide();
                    new Form4().ShowDialog();
                    this.Close();
                }
            };
        }


        private List<PictureBox> MakeListOfRandomCards(List<PictureBox> list, int iterations)
        {
            List<PictureBox> cards = new List<PictureBox>();
            List<int> usedIndexes = new List<int>();
            Random random = new Random();
            int index = random.Next(list.Count);

            for (int i = 0; i < iterations/2; i++)
            {
                while (!usedIndexes.Contains(index))
                {
                    index = random.Next(list.Count);
                }
                cards.Add(list[index]);
                usedIndexes.Add(index);
            }
            return cards;
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
