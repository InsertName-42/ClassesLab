using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{

    public class BlackJackHand : Hand
    {
        //Hand specifically for blackjack, inherented from hand
        public BlackJackHand() : base() { }
        //Initializes blackjack for a specific decksize
        public BlackJackHand(Deck deck, int numCards) : base(deck, numCards) { }

        //Methods
        //Checks for ace
        public bool HasAce()
        {
 
            foreach (Card card in cards)
            {
                if (card.IsAce())
                {
                    return true;
                }
            }
            return false;
        }

        //Calculates scores
        public int GetScore()
        {
            int score = 0;
            int numAces = 0;

            foreach (Card card in cards)
            {
                if (card.IsAce())
                {
                    numAces++;
                    score += 1;
                }
                else if (card.IsFaceCard())
                {
                    score += 10;
                }
                else
                {
                    score += card.Value;
                }
            }

            while (numAces > 0 && score <= 11)
            {
                score += 10;
                numAces--;
            }

            return score;
        }

        //Checks for a score greater than 21
        public bool IsBusted()
        {
            return GetScore() > 21;
        }

        //Displays a hand as a string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Busted: {IsBusted()}");
            return sb.ToString();
        }
    }
}
