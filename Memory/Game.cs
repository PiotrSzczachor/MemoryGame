﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class Game
    {
        List<string> FilesNames = null;
        List<string> CardsNames = null;
        //List where randomly chosen cards are stored
        List<PictureBox> Cardslist = new List<PictureBox>();
        //List which len is only 0, 1 or 2, it stores which cards user is checking right now
        List<PictureBox> Clicekd = new List<PictureBox>();
        List<int> usedIndexes = new List<int>();
        int gameTime;
        int tryCounter;
        bool clikckAllowed = false;
        bool timeStopped = false;
        Form3 form;

        public Game(Form3 form_)
        {
            form = form_;
        }

        public void start(Button button1, Label label2, TableLayoutPanel cardsTable, Timer timer1, Timer timer2, Label label1)
        {
            button1.Enabled = false;
            label2.Visible = false;
            int iterations = Settings.getInstance().getNumberOfCards();
            getCardsAndFilesNames();
            Random random = new Random();
            int index = random.Next(60);
            fillingCardsList(iterations, usedIndexes, cardsTable, index, timer1, timer2, label2, button1);
            List<PictureBox> cardsToPlay = new List<PictureBox>();
            makeCardsToPlayList(usedIndexes, index, cardsToPlay, cardsTable, timer1, timer2, label2, button1);
            showCards(cardsTable, timer1, label1, button1);
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
                CardsNames.Add(parts[0] + '_');
            }

        }

        private void fillingCardsList(int iterations, List<int> usedIndexes, TableLayoutPanel cardsTable, int index, Timer timer1, Timer timer2, Label label2, Button button1)
        {
            Random random = new Random();
            //Filling CardsList 
            for (int i = 0; i < iterations / 2; i++)
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
                        Size = new Size(103, 153),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[usedIndexes[i]]
                    };
                    //Creating On_Click function to every card in the loop
                    addClickFunction(card, timer1, timer2, label2, button1);
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
                    addClickFunction(card, timer1, timer2, label2, button1);
                    Cardslist.Add(card);
                }
                //120 Cards game
                if (iterations == 120)
                {
                    //Initializing TableLayoutPanel with specific number of rows and columns for this type of game
                    MakeTableLayoutPanel(6, 20, cardsTable);

                    //Creating new picture box with hidden card image and name of source image in tag
                    PictureBox card = new PictureBox
                    {
                        Name = CardsNames[usedIndexes[i]],
                        Size = new Size(60, 92),
                        Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = FilesNames[usedIndexes[i]]
                    };
                    addClickFunction(card, timer1, timer2, label2, button1);
                    Cardslist.Add(card);

                }
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

            form.Controls.Add(tableLayoutPanel_);

        }

        private void addClickFunction(PictureBox card, Timer timer1, Timer timer2, Label label2, Button button1)
        {
            card.Click += (s, e) =>
            {
                //If the card image=null thats mean that the card has been guessed so you can't click it one more time
                if (card.Image != null && clikckAllowed)
                {
                    //Console.WriteLine(Clicekd.Count.ToString());
                    //If len of Clicked list is 0, it means that we can chose first card and turn it over
                    if (Clicekd.Count == 0)
                    {
                        //Turning the card over
                        card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card.Tag.ToString());
                        //Adding card to Clicked list 
                        Clicekd.Add(card);
                    }
                    if (Clicekd.Count == 1 && Clicekd[0].Name != card.Name)
                    {
                        //Turning the card over
                        card.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + card.Tag.ToString());
                        //Adding card to Clicked list 
                        Clicekd.Add(card);
                        clikckAllowed = false;
                    }
                    Console.WriteLine(Clicekd.Count.ToString());
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
                            clikckAllowed = true;
                        }
                        //If it wasn't pair, wait CardsOpenTime
                        if (Clicekd[0].Tag != Clicekd[1].Tag)
                        {
                            List<PictureBox> pictureBoxes = new List<PictureBox>();
                            foreach (PictureBox p in Clicekd)
                            {
                                pictureBoxes.Add(p);
                            }
                            timer2.Enabled = true;
                            //DateTime time = DateTime.Now;
                            int seconds = 0;
                            timer2.Tick += (s_, e_) =>
                            {
                                //TimeSpan actualTime = DateTime.Now.Subtract(time);
                                //int seconds = actualTime.Seconds;
                                seconds++;
                                if (seconds == Settings.getInstance().getCardsOpenTime())
                                {
                                    turnOver(pictureBoxes);
                                    clikckAllowed = true;
                                }
                                label2.Text = seconds.ToString();
                                if (clikckAllowed == true)
                                {
                                    button1.Enabled = true;
                                }
                                else
                                {
                                    button1.Enabled = false;
                                }
                            };

                        }
                        //Clearing Clicked list to use it one more time in the future user types
                        Clicekd.Clear();
                        tryCounter++;
                    }
                }

            };
        }

        private void turnOver(List<PictureBox> list)
        {
            foreach (PictureBox p in list)
            {
                p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg");
            }
        }

        private void makeCardsToPlayList(List<int> usedIndexes, int index, List<PictureBox> cardsToPlay, TableLayoutPanel cardsTable, Timer timer1, Timer timer2, Label label2, Button button1)
        {
            Random random = new Random();
            foreach (PictureBox p in Cardslist)
            {
                PictureBox card_2 = new PictureBox
                {
                    Name = p.Name + "2",
                    Size = p.Size,
                    Image = p.Image,
                    SizeMode = p.SizeMode,
                    Tag = p.Tag
                };
                addClickFunction(card_2, timer1, timer2, label2, button1);
                cardsToPlay.Add(card_2);
                cardsToPlay.Add(p);
            }

            usedIndexes.Clear();

            index = random.Next(cardsToPlay.Count);

            for (int i = 0; i < cardsToPlay.Count; i++)
            {
                while (usedIndexes.Contains(index))
                {
                    index = random.Next(cardsToPlay.Count);
                }
                usedIndexes.Add(index);
                cardsTable.Controls.Add(cardsToPlay[index]);
            }
        }

        private void showCards(TableLayoutPanel tlp, Timer timer1, Label label1, Button button1)
        {
            foreach (PictureBox p in tlp.Controls)
            {
                p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\Cards\" + p.Tag.ToString());
            }
            timer1.Enabled = true;
            int seconds = 0;
            timer1.Tick += (s, e) =>
            {
                seconds++;
                if (seconds == Settings.getInstance().getInitialTime())
                {
                    foreach (PictureBox p in tlp.Controls)
                    {
                        p.Image = Image.FromFile(@"C:\Users\Piotr\source\repos\Memory\Memory\HideCard\hide.jpg");
                        clikckAllowed = true;
                    }
                }
                int hours = seconds / 3600;
                int minutes = seconds / 60;
                label1.Text = hours.ToString() + ":" + minutes.ToString() + ":" + (seconds % 60).ToString();
                gameTime = seconds;
                if (clikckAllowed == true)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
                if (checkWin(tlp))
                {
                    timer1.Stop();
                    countScore();
                    form.Hide();
                    new Form4().ShowDialog();
                    form.Close();
                }
            };
        }

        private bool checkWin(TableLayoutPanel tlp)
        {
            bool win = true;
            foreach (PictureBox p in tlp.Controls)
            {
                if (p.Image != null)
                {
                    win = false;
                }
            }
            return win;
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

        public void handleButton(Timer timer1, Button button1)
        {
            if (button1.Text == "Time stop")
            {
                timer1.Stop();
                timeStopped = true;
                clikckAllowed = false;
                button1.Text = "Time start";
            }
            else
            {
                timer1.Start();
                timeStopped = false;
                clikckAllowed = true;
                button1.Text = "Time stop";
            }
        }

    }
}
