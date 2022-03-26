using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public sealed class Player
    {
        string username;
        int score;

        private Player() { }

        private static Player _instance;

        public static Player getInstance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }

        public void setUsername(string name)
        {
            this.username = name;
        }

        public void setScore(int score_)
        {
            this.score = score_;
        }

        public string getUsername()
        {
            return username;
        }

        public int getScore()
        {
            return score;
        }
    }
}
