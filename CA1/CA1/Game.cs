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
        // 
        #region properties

        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

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

            Console.WriteLine("Welcome to blackjack...");
            Console.WriteLine("Press enter to play!");

            Console.ReadLine();

            string playAgain = "";

            // Enter "n" to exit loop
            do
            {
                Play();
                Console.Write("\nPlay again? (y/n) : ");
                playAgain = Console.ReadLine().ToLower();
            } while (playAgain != "n");

            Console.WriteLine($"Out of {Games} games, you\nWon : {Wins}\nDrew : {Draws}\nLost : {Losses}");

            Console.ReadLine();
        }
        
        public void Play()
        {
            // Play a game of blackjack


            string choice = "";

            // Initializes a hand for the player and dealer.
            Player = new Hand();
            Dealer = new Hand();

            // The player is dealt 2 cards
            Console.WriteLine($"You drew a {Player.AddCard()}");
            Console.WriteLine($"You drew a {Player.AddCard()}");


            Console.WriteLine(Player.DisplayHandTotal());

            // While the player is below the bust threshold (21) they can draw another card (or exit by typing "n");
            while (Player.Score < 21)
            {
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