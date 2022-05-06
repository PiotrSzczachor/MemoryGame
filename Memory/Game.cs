using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    internal class Game
    {
        private void countScore(int gameTime, int tryCounter)
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
            foreach (PictureBox p in tlp.Controls)
            {
                if (p.Image != null)
                {
                    win = false;
                }
            }
            return win;
        }
        private void addClickFunction(PictureBox card, bool clikckAllowed, List<PictureBox> Clicekd, Timer timer2, Label label2, Button button1, int tryCounter)
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

        private void showCards(TableLayoutPanel tlp, Timer timer1, bool clikckAllowed, int gameTime, Button button1, Label label1, int tryCounter, Form3 this_)
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
                    countScore(gameTime, tryCounter);
                    this_.Hide();
                    new Form4().ShowDialog();
                    this_.Close();
                }
            };
        }


        private List<PictureBox> MakeListOfRandomCards(List<PictureBox> list, int iterations)
        {
            List<PictureBox> cards = new List<PictureBox>();
            List<int> usedIndexes = new List<int>();
            Random random = new Random();
            int index = random.Next(list.Count);

            for (int i = 0; i < iterations / 2; i++)
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

        private void MakeTableLayoutPanel(int rows, int cols, TableLayoutPanel tableLayoutPanel_, Form3 this_)
        {
            tableLayoutPanel_.RowCount = rows;
            tableLayoutPanel_.ColumnCount = cols;
            tableLayoutPanel_.BackColor = Color.Transparent;
            tableLayoutPanel_.AutoSize = true;
            tableLayoutPanel_.Location = new Point(70, 70);

            tableLayoutPanel_.RowStyles.Clear();
            tableLayoutPanel_.ColumnStyles.Clear();

            this_.Controls.Add(tableLayoutPanel_);

        }



        private void getCardsAndFilesNames(List<string> FilesNames, List<string> CardsNames)
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

        //Adding PictureBoxes to Controls
        private void drawCards(Form3 this_, List<PictureBox> Cardslist)
        {
            foreach (PictureBox picture in Cardslist)
            {
                this_.Controls.Add(picture);
            }
        }
    }
}
