using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CA1
{
    class Hand
    {
        // This class mimics a player's hand. 
        // It initializes a new deck and list of cards for a hand.


        public Deck DeckCards { get; set; }
        public List<Card> HandCards { get; set; }
        // The score is the total of cards, assuming the ace is equal to 1
        public int Score { get; set; }
        // the AcesScore is the total, assuming the ace is equal to 11
        public int AcesScore { get; set; }


        static Random rnd = new Random();

        public Hand()
        {
            DeckCards = new Deck();
            HandCards = new List<Card>();
        }
        public Card AddCard()
        {
            // Add a card from the deck to your hand
            // The card is chosen through the Random object
            // The card is then removed from the deck
            
            // Since when a card is chosen it is removed from the list, the random index is in the range of the 
            // size of the deck.
            int temp = rnd.Next(DeckCards.Cards.Count);
            Card result = DeckCards.Cards[temp];
            DeckCards.Cards.RemoveAt(temp);

            Console.WriteLine(DeckCards.Cards.Count);
            HandCards.Add(result);

            // If the Rank of the resulting card is 0, then it is an Ace. Which can equal to both 1 or 11
            if (result.Rank == 0)
            {
                Score += 1;
                AcesScore += 11;
            }
            // If the card is not an ace, update both scores equally
            else
            {
                Score += result.Values[result.Rank];
                AcesScore += result.Values[result.Rank];
            }

            return result;
        }

        public string DisplayHandTotal()
        {
            // Display the hand total, depending on whether you have aces or not
            // If the Score is equal to the AcesScore, clearly there are no aces in the hand
            if (Score == AcesScore)
                return String.Format($"Score is {Score}");
            else
                return String.Format($"Score is {Score} or {AcesScore}");
        }

        public Result CompareHands(Hand other)
        {
            // Compares two hands of cards using the current hand instance and another hand instance for comparison
            // The ruleset below is written in code

            /* Ruleset:
            If the player is dealt an Ace and a ten-value card(called a "blackjack" or "natural"), and the dealer does not, the player wins and usually receives a bonus.
            If the player exceeds a sum of 21("busts"), the player loses, even if the dealer also exceeds 21.
            If the dealer exceeds 21("busts") and the player does not, the player wins.
            If the player attains a final sum higher than the dealer and does not bust, the player wins.
            If both dealer and player receive a blackjack or any other hands with the same sum called a "push", no one wins.
            Source: https://en.wikipedia.org/wiki/Blackjack#Rules
            */
            
            // Since aces have to be considered as both 1 or 11, this gets the best score which is still under 21
            int playerBest = 0;
            int otherBest = 0;


            // If the Aces score is below 21, it is clearly higher or at least the same as the normal score
            // If neither scores are below 21, clearly it is a bust. If the player busts, it is an automatic loss

            // Player hand
            if (this.AcesScore <= 21)
                playerBest = this.AcesScore;
            else if (this.Score <= 21)
                playerBest = this.Score;
            else
                return Result.PLAYERLOSS;

            // Other hand
            if (other.AcesScore <= 21)
                otherBest = other.AcesScore;
            else if (other.Score <= 21)
                otherBest = other.Score;
            else
                return Result.PLAYERWIN;

            // Comparing best scores
            if (playerBest > otherBest)
                return Result.PLAYERWIN;
            else if (playerBest < otherBest)
                return Result.PLAYERLOSS;
            else
                return Result.PLAYERDRAW;
        }

    }
}
