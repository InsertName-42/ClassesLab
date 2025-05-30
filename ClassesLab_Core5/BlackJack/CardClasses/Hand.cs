using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards;

        //Default constructor: Initializes an empty hand
        public Hand()
        {
            cards = new List<Card>();
        }

        //Initializes a hand with a specified number of cards dealt from a deck
        public Hand(Deck deck, int numCards)
        {
            cards = new List<Card>();
            for (int i = 0; i < numCards; i++)
            {
                if (!deck.IsEmpty)
                {
                    cards.Add(deck.Deal());
                }
                else
                {
                    Console.WriteLine("Warning: Not enough cards in the deck.");
                    break; 
                }
            }
        }

        //Get the number of cards in the hand
        public int NumCards
        {
            get { return cards.Count; }
        }

        //Determine if the hand is empty
        public bool IsEmpty
        {
            get { return cards.Count == 0; }
        }

        //Get a card based on its index
        public Card this[int i]
        {
            get
            {
                if (i >= 0 && i < cards.Count)
                {
                    return cards[i];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }
            }
        }

        //Add a card to the hand
        public void Add(Card card)
        {
            cards.Add(card);
        }

        //Discard a specific card from the hand
        public Card Discard(Card card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
                return card;
            }
            return null;
        }

        //Discard a card at a specific index from the hand
        public Card DiscardAt(int index)
        {
            if (index >= 0 && index < cards.Count)
            {
                Card cardToDiscard = cards[index];
                cards.RemoveAt(index);
                return cardToDiscard;
            }
            return null;
        }

        //Determine if a hand has a card given a card
        public bool HasCard(Card card)
        {
            return cards.Contains(card);
        }

        //Determine if a hand has a card given a value and a suit
        public bool HasCard(int value, int suit)
        {
            foreach (Card c in cards)
            {
                if (c.Value == value && c.Suit == suit)
                {
                    return true;
                }
            }
            return false;
        }

        //Determine if a hand has a card given just a value
        public bool HasCard(int value)
        {
            foreach (Card c in cards)
            {
                if (c.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        //Determine the index of a card in a hand given a card
        public int IndexOf(Card card)
        {
            return cards.IndexOf(card);
        }

        //Determine the index of a card in a hand given a value and a suit
        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value && cards[i].Suit == suit)
                {
                    return i;
                }
            }
            return -1;
        }

        //Determine the index of the first card in a hand given just a value
        public int IndexOf(int value)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value)
                {
                    return i;
                }
            }
            return -1;
        }

        // Override to display cards in hand
        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Hand is empty.";
            }

            string output = "Cards in Hand:\n";
            foreach (Card c in cards)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

        //Add a card to a hand
        public static Hand operator +(Hand hand, Card card)
        {
            hand.Add(card);
            return hand;
        }

        //Remove a card from a hand
        public static Hand operator -(Hand hand, Card card)
        {
            hand.Discard(card);
            return hand;
        }
    }
}