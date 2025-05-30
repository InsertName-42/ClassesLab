using System;

namespace CardClasses
{
    public class Card
    {
        //Set up avaliable options using static array
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        //Store values
        private int value;
        private int suit;
        
        //Getters and setters
        public int Value
        {
            get
            {
                return value;
            }
            set
                //Data validation
            {
                if (value >= 1 && value <= 13)
                    this.value = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 13.");
            }
        }

        public int Suit
        {
            get
            {
                return suit;
            }
            set
            {
                //Data validation
                if (value >= 1 && value <= 4)
                    this.suit = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(suit), "Suit must be between 1 and 4.");
            }
        }
        //Default values
        public Card()
        {
            Value = 1;
            Suit = 1;
        }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }
        //Determine card attributes
        public bool IsRed()
        {
            return Suit == 2 || Suit == 3;
        }

        public bool IsBlack()
        {
            return Suit == 1 || Suit == 4;
        }

        public bool IsClub()
        {
            return Suit == 1;
        }

        public bool IsDiamond()
        {
            return Suit == 2;
        }

        public bool IsHeart()
        {
            return Suit == 3;
        }

        public bool IsSpade()
        {
            return Suit == 4;
        }

        public bool IsAce()
        {
            return Value == 1;
        }

        public bool IsFaceCard()
        {
            return Value >= 11 && Value <= 13;
        }

        //Checks if suits match
        public bool SuitMatches(Card otherCard)
        {
            return Suit == otherCard.Suit;
        }
        //Checks if values match
        public bool ValueMatches(Card otherCard)
        {
            return Value == otherCard.Value;
        }

        //Displays string representation of a card
        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }
        //Overides
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Card other = (Card)obj;
            return Value == other.Value && Suit == other.Suit;
        }

        //Consistent Hash for cards
        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Suit.GetHashCode();
        }
    }
}