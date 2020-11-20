using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// This program allows you to play double deck blackjack (The player and dealer each use a seperate deck)

/*
 * It is a comparing card game between one or more players and a dealer,
 * where each player in turn competes against the dealer. Players do not compete against each other. 
 * It is played with one or more decks of 52 cards, and is the most widely played casino banking game in the world.
 * 
 * Ruleset:
 * If the player is dealt an Ace and a ten-value card(called a "blackjack" or "natural"), and the dealer does not, the player wins and usually receives a bonus.
 * If the player exceeds a sum of 21("busts"), the player loses, even if the dealer also exceeds 21.
 * If the dealer exceeds 21("busts") and the player does not, the player wins.
 * the player attains a final sum higher than the dealer and does not bust, the player wins.
 * If both dealer and player receive a blackjack or any other hands with the same sum called a "push", no one wins.
 * Sources: https://en.wikipedia.org/wiki/Blackjack
 *          https://en.wikipedia.org/wiki/Blackjack#Rules
*/

namespace CA1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game();
        }
    }
}
