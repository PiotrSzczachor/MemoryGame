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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label1.Text = "Your score is: " + Player.getInstance().getScore().ToString();
            readRankFromFile();
        }

        private void readRankFromFile()
        {
            Dictionary<string, int> rank = new Dictionary<string, int>();
            string readText = File.ReadAllText(@"C:\Users\Piotr\source\repos\Memory\Memory\Rank.txt");
            string[] splitted = readText.Split('\n');
            foreach (string line in splitted)
            {
                if(line.Contains(" "))
                {
                    string[] parts = line.Split(' ');
                    rank[parts[0]] = int.Parse(parts[1]);
                }
            }
            var myList = rank.ToList();
            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            foreach(var i in myList)
            {
                listBox1.Items.Add(i.Key + " " + i.Value);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }
    }
}
