using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    class Card
    {
        #region properties
        // The suits and ranks for outputting to console
        public string[] Suits = { "Hearts", "Spades", "Clubs", "Diamonds" };
        public string[] Ranks = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
                                "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        // Since the rank can be 0-13, this is the value of each card at the index above (ace is given 0 to parse later on)
        public int[] Values = { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

        public int Suit { get; set; }
        public int Rank { get; set; }

        #endregion

        public override string ToString()
        {
            return String.Format($"{this.Ranks[this.Rank]} of {this.Suits[this.Suit]}");
        }

        // Could not get this to work
        // Whenever I attempted to make the deck, King would not display as king, instead displaying as a number
        /*
        public enum Suits
        {
            Hearts = 1,
            Spades = 2,
            Clubs = 3,
            Diamonds = 4
        }
        public enum Ranks
        {
            Ace = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten,
            Jack,
            Queen,
            King = 10
        }*/
    }
}
