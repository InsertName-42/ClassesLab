using System;

namespace CardClasses
{
    public class Card
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        public int Value
        {
            get
            {
                return value;
            }
            set
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
                if (value >= 1 && value <= 4)
                    this.suit = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(suit), "Suit must be between 1 and 4.");
            }
        }

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

        public bool SuitMatches(Card otherCard)
        {
            return Suit == otherCard.Suit;
        }

        public bool ValueMatches(Card otherCard)
        {
            return Value == otherCard.Value;
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }
    }
}