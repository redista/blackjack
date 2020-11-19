using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            // Create a new list of 52 cards
            // the initial for loop is the 4 suits
            // the inner loop is the 13 cards in a suit

            Cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int q = 0; q < 13; q++)
                    Cards.Add(new Card { Suit = i, Rank = q });
            }
        }
    }
}
