/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace HandTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);

            Console.WriteLine("Hand Class Tests  ");

            TestHandConstructorEmpty();
            TestHandConstructorDeal();
            TestHandAddAndDiscard();
            TestHandIndexer();
            TestHandHasCardAndIndexOf();
            TestHandOperatorOverloading();

            Console.WriteLine("Finished Hand Tests ");

            Console.ReadLine();
        }

        static void TestHandConstructorEmpty()
        {
            Console.WriteLine("\n--- Testing Hand() Constructor ---");
            Hand hand = new Hand();
            Console.WriteLine("NumCards: " + hand.NumCards);
            Console.WriteLine("IsEmpty: " + hand.IsEmpty);
            Console.WriteLine("Hand contents:\n" + hand.ToString());
            Console.WriteLine();
        }

        static void TestHandConstructorDeal()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("Dealing 5 cards from a shuffled deck:");
            Hand hand = new Hand(deck, 5);
            Console.WriteLine("NumCards: " + hand.NumCards);
            Console.WriteLine("IsEmpty: " + hand.IsEmpty);
            Console.WriteLine("Hand contents:\n" + hand.ToString());

            Console.WriteLine("Dealing 50 more cards (empty the deck):");
            Hand hand2 = new Hand(deck, 50);
            Console.WriteLine("NumCards: " + hand2.NumCards);
            Console.WriteLine("Hand contents:\n" + hand2.ToString());
            Console.WriteLine("Deck NumCards after dealing 50: " + deck.NumCards);

            Console.WriteLine("Ddeal from an empty deck:");
            Hand hand3 = new Hand(deck, 5);
            Console.WriteLine("NumCards: " + hand3.NumCards);
            Console.WriteLine("Hand contents:\n" + hand3.ToString());
            Console.WriteLine();
        }

        static void TestHandAddAndDiscard()
        {
            Console.WriteLine("\n--- Testing Add() and Discard() Methods ---");
            Hand hand = new Hand();
            Card card1 = new Card(1, 1);
            Card card2 = new Card(7, 3);
            Card card3 = new Card(10, 2);

            Console.WriteLine("Initial hand:\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            hand.Add(card1);
            Console.WriteLine("\nAfter adding Ace of Clubs:\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            hand.Add(card2);
            hand.Add(card3);
            Console.WriteLine("\nAfter adding 7 of Hearts and 10 of Diamonds:\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            Console.WriteLine("\nDiscarding Ace of Clubs:");
            Card discardedCard = hand.Discard(card1);
            Console.WriteLine("Discarded card: " + (discardedCard?.ToString() ?? "None"));
            Console.WriteLine("Hand after discard:\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            Console.WriteLine("\nDiscarding card at index 0 (should be 7 of Hearts):");
            discardedCard = hand.DiscardAt(0);
            Console.WriteLine("Discarded card: " + (discardedCard?.ToString() ?? "None"));
            Console.WriteLine("Hand after discard:\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            Console.WriteLine("\nAttempting to discard a non-existent card (King of Spades):");
            Card nonExistentCard = new Card(13, 4);
            discardedCard = hand.Discard(nonExistentCard);
            Console.WriteLine("Discarded card: " + (discardedCard?.ToString() ?? "None"));
            Console.WriteLine("NumCards (should be unchanged): " + hand.NumCards);

            Console.WriteLine("\nAttempting to discard at an invalid index (10):");
            discardedCard = hand.DiscardAt(10);
            Console.WriteLine("Discarded card: " + (discardedCard?.ToString() ?? "None"));
            Console.WriteLine("NumCards (should be unchanged): " + hand.NumCards);
            Console.WriteLine();
        }

        static void TestHandIndexer()
        {
            Console.WriteLine("\n--- Testing Hand Indexer ---");
            Deck deck = new Deck();
            deck.Shuffle();
            Hand hand = new Hand(deck, 3);
            Console.WriteLine("Hand for Indexer Test:\n" + hand.ToString());

            Console.WriteLine("Card at index 0: " + hand[0].ToString());
            Console.WriteLine("Card at index 1: " + hand[1].ToString());

            try
            {
                Console.WriteLine($"Invalid index (10): {hand[10].ToString()}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid index: {ex.Message}");
            }
            Console.WriteLine();
        }

        static void TestHandHasCardAndIndexOf()
        {
            Console.WriteLine("\n--- Testing HasCard() and IndexOf() Methods ---");
            Hand hand = new Hand();
            hand.Add(new Card(1, 1));
            hand.Add(new Card(5, 2));
            hand.Add(new Card(10, 3));
            Console.WriteLine("Hand for HasCard/IndexOf Test:\n" + hand.ToString());

            Console.WriteLine("\nHasCard(Ace of Clubs): " + hand.HasCard(new Card(1, 1)));
            Console.WriteLine("HasCard(2 of Clubs): " + hand.HasCard(new Card(2, 1)));

            Console.WriteLine("HasCard(Value 10, Suit 3 - Ten of Hearts): " + hand.HasCard(10, 3));
            Console.WriteLine("HasCard(Value 8, Suit 4 - 8 of Spades): " + hand.HasCard(8, 4));

            Console.WriteLine("HasCard(Value 1 - Ace): " + hand.HasCard(1));
            Console.WriteLine("HasCard(Value 12 - Queen): " + hand.HasCard(12));

            Console.WriteLine("\nIndexOf(Ace of Clubs): " + hand.IndexOf(new Card(1, 1)));
            Console.WriteLine("IndexOf(5 of Diamonds): " + hand.IndexOf(new Card(5, 2)));
            Console.WriteLine("IndexOf(Non-existent card): " + hand.IndexOf(new Card(2, 1)));

            Console.WriteLine("IndexOf(Value 10, Suit 3 - Ten of Hearts): " + hand.IndexOf(10, 3));
            Console.WriteLine("IndexOf(Value 8, Suit 4 - 8 of Spades): " + hand.IndexOf(8, 4));

            Console.WriteLine("IndexOf(Value 1 - Ace): " + hand.IndexOf(1));
            Console.WriteLine("IndexOf(Value 5 - 5): " + hand.IndexOf(5));
            Console.WriteLine("IndexOf(Value 12 - Queen): " + hand.IndexOf(12));
            Console.WriteLine();
        }

        static void TestHandOperatorOverloading()
        {
            Console.WriteLine("\n--- Testing Operator Overloading (+ and -) ---");
            Hand hand = new Hand();
            Card card1 = new Card(1, 1);
            Card card2 = new Card(2, 2);
            Card card3 = new Card(3, 3);

            Console.WriteLine("Initial Empty Hand:\n" + hand.ToString());

            hand = hand + card1;
            Console.WriteLine("\nHand after adding Ace of Clubs (+ operator):\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            hand += card2;
            Console.WriteLine("\nHand after adding 2 of Diamonds (+= operator):\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            hand = hand - card1;
            Console.WriteLine("\nHand after removing Ace of Clubs (- operator):\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);

            hand -= card3;
            Console.WriteLine("\nHand after attempting to remove 3 of Hearts (-= operator, not in hand):\n" + hand.ToString());
            Console.WriteLine("NumCards (should be unchanged): " + hand.NumCards);

            hand -= card2;
            Console.WriteLine("\nHand after removing 2 of Diamonds (-= operator):\n" + hand.ToString());
            Console.WriteLine("NumCards: " + hand.NumCards);
            Console.WriteLine();
        }
    }
}
*/