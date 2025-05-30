using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{

    public class BlackJackHand : Hand
    {
 
        public BlackJackHand() : base() { }

        public BlackJackHand(Deck deck, int numCards) : base(deck, numCards) { }

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

        public bool IsBusted()
        {
            return GetScore() > 21;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Busted: {IsBusted()}");
            return sb.ToString();
        }
    }
}
