using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public sealed class Settings
    {
        int initialTime;
        int cardsOpenTime;
        int numberOfCards;

        private Settings() {
            initialTime = 120;
            cardsOpenTime = 10;
            numberOfCards = 48;
        }

        private static Settings instance;

        public static Settings getInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }

        public void setInitialTime(int time)
        {
            initialTime = time;
        }

        public void setCardsOpenTime(int time)
        {
            cardsOpenTime = time;
        }

        public void setNumberOfCards(int number)
        {
            numberOfCards = number;
        }


        public int getInitialTime()
        {
            return initialTime;
        }

        public int getCardsOpenTime()
        {
            return cardsOpenTime;
        }

        public int getNumberOfCards()
        {
            return numberOfCards;
        }


    }
}
