using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{ 
    enum Result
    {
        PLAYERWIN,
        PLAYERDRAW,
        PLAYERLOSS
    }

    class Game
    {
        // Controls game state.
        #region properties

        // Wins, draws, losses of player
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }

        public Hand Player { get; set; }
        public Hand Dealer { get; set; }

        public int Games
        {
            get
            {
                return this.Wins + this.Draws + this.Losses;
            }
        }
        #endregion properties

        public Game()
        {
            // On construction, begins a a game of blackjack.

            string playAgain = "";

            Console.WriteLine("Welcome to blackjack...");
            Console.WriteLine("Press enter to play!");

            Console.ReadLine();

            // First game
            Play();

            // Option to play again
            while(true)
            {
                Console.Write("\nPlay again? (y/n) : ");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain == "y")
                {
                    Play();
                }
                else if (playAgain == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input invalid. Must be y/n");
                }
            }

            // Display total wins, draws, losses
            Console.WriteLine($"Out of {Games} game(s), you\nWon : {Wins}\nDrew : {Draws}\nLost : {Losses}");

            Console.ReadLine();
        }
        
        public void Play()
        {
            // Play a round of blackjack
            // It flows as:
            // Player is dealt 2 cards, the dealer is dealt 2, but only the first is shown to
            // the player, the player can then draw another card if their score is under 21. 
            // After the players turn, if the dealer is under 17 total score, they continue drawing
            // until they're over it. Then it compares both hands.

            string choice = "";

            // Initializes a hand for the player and dealer.
            Player = new Hand();
            Dealer = new Hand();

            // The player is dealt 2 cards
            Console.WriteLine($"You drew a {Player.AddCard()}");
            Console.WriteLine($"You drew a {Player.AddCard()}");
            Console.WriteLine($"Your {Player.DisplayHandTotal()}");

            // The dealer is dealt a card and displays the score, then is given another card ( to hide the second card )
            Console.WriteLine($"\nThe dealer drew a {Dealer.AddCard()} and an unknown card:");
            Console.WriteLine($"The dealers {Dealer.DisplayHandTotal()} plus an unknown card\n");
            Dealer.AddCard();

            // While the player is below the bust threshold (21) they can draw another card (or exit by typing "n");
            while (Player.Score < 21)
            {
                if (Player.AcesScore == 21 || Player.Score == 21)
                {
                    Console.WriteLine("Blackjack!");
                    break;
                }

                Console.Write("Draw another? (y/n) : ");
                choice = Console.ReadLine().ToLower();


                if (choice == "n")
                {
                    Console.WriteLine(Player.DisplayHandTotal());
                    break;
                }
                else if (choice == "y")
                {
                    Console.WriteLine($"You drew a {Player.AddCard()}");
                    Console.WriteLine($"Your {Player.DisplayHandTotal()}");
                }
                else
                {
                    Console.WriteLine("Input invalid. Must be y/n");
                }
            }

            // After the player loop exits, the dealer loop begins. This automatically draws cards until it is above or equal to 17
            Console.WriteLine("\nThe dealer's turn...\n");
            while (Dealer.Score < 17)
            {
                Console.WriteLine($"The dealer drew a {Dealer.AddCard()}");
                Console.WriteLine($"The dealers {Dealer.DisplayHandTotal()}\n");
            }


            // Compare the hand of the player with the dealer. Then add to the total wins/draws/losses
            switch(Player.CompareHands(Dealer))
            {
                case Result.PLAYERWIN:
                    Wins++;
                    Console.WriteLine("You won!");
                    break;
                case Result.PLAYERDRAW:
                    Draws++;
                    Console.WriteLine("You drew with the dealer!");
                    break;
                case Result.PLAYERLOSS:
                    Losses++;
                    Console.WriteLine("You lost against the dealer!");
                    break;
                default:
                    break;
            }
        }
    }
}